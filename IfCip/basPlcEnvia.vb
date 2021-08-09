Module basPlcEnvia

    Function PlcEnvia(ByVal Grupo As String, ByVal Subgrupo As String, ByVal RotaId As String, _
                    ByVal LimRev As Integer, ByVal EndTempos As Integer, _
                    ByVal Tipo As Integer, ByVal UserId As Integer) As Boolean

        'Verifica se tem um CIP deste grupo em execução
        Dim taCipHist As New Geral.dsxCipValidTableAdapters.taxCipHist
        Dim dtCipHist As New Geral.dsxCipValid.CipHistDataTable
        taCipHist.FillGrupoExec(dtCipHist, Grupo)

        If dtCipHist.Rows.Count > 0 Then
            MsgBox("Erro: Há um CIP atualmente em execução no grupo selecionado [" & Grupo & "]." & _
                    ControlChars.CrLf & _
                    "Encerre o CIP em execução antes de iniciar o próximo.")
            Return False
        End If


        'Verifica se este cip está atrasado
        Dim dtDados As New DataTable
        AgendaMontaColunas(dtDados)
        AgendaBuscaCipSchedProg(dtDados)
        AgendaBuscaCipSchedPer(dtDados)
        Dim MyCipAgenda() As DataRow = dtDados.Select("RotaId = " & RotaId & " AND FlagAtrasado = 1")

        Dim FlagAtrasado As Integer = 0
        Dim DescrAtrasado As String = ""

        If MyCipAgenda.Length > 0 Then
            'Este CIP está atrasado, perguntar o motivo para salvar como anormalidade
            FlagAtrasado = 1
            DescrAtrasado = InputBox("Digite o motivo que gerou o atraso do CIP grupo [" & Grupo & Subgrupo & "]")
            If DescrAtrasado.Trim = "" Then
                MsgBox("Erro: o motivo de atraso não foi digitado. Este CIP não será iniciado.", MsgBoxStyle.Critical)
                Return False
            End If
        End If

        'Cria o objeto CIP e envia comandos ao PLC
        Dim MyCip As New clsCipCmd()
        MyCip.OpcMonta(Grupo, EndTempos, Tipo)


        'Envia comando iniciar CIP
        MyCip.CmdTipo.Write(Tipo)
        MyCip.CmdSubgrupo.Write(Subgrupo)

        'Grava o registro deste comando no SqlServer
        Dim CipId As Integer = CipNovoInsereDb(RotaId, UserId, LimRev, Tipo, Grupo, Subgrupo, FlagAtrasado, DescrAtrasado)

        'Grava tempos programados para este CIP
        Dim taCipHistTempoProg As New Geral.dsxCipValidTableAdapters.taxCipHistTempoProg

        Dim CipData As New Object
        Dim RetSts As Boolean = Util.OpcGrupoLe(OpcSrvPoll.OPCGroups.Item("CipCmd"), CipData)
        If RetSts = True Then

            For Conta As Integer = 0 To MyCip.NPassos - 1
                Dim Valor As Integer = CipData(Conta + 3)
                taCipHistTempoProg.InsertQuery(CipId, Conta, Valor)
            Next

        End If

        'Encerra OPC
        MyCip.OpcDesmonta()

        Return True

    End Function

    Function CipIdNovo() As Integer

        Dim Ano As Integer = Now.Year

        'Busca o numero sequencial do ultimo CIP realizado
        Dim taCipSeq As New Geral.dsxCipValidTableAdapters.taxCipSeq
        Dim dtCipSeq As New Geral.dsxCipValid.CipSeqDataTable
        taCipSeq.FillAno(dtCipSeq, Ano)

        If dtCipSeq.Rows.Count <= 0 Then
            'Este é o primeiro CIP do Ano, criar registro
            taCipSeq.InsertQuery(Ano, 1)
            Return Ano * 10000 + 1
        End If


        'Não é o primeiro CIP do ano, incrementa a sequencia
        Dim CipSeqNovo As Integer = dtCipSeq(0).CipSeq + 1
        taCipSeq.UpdateQuery(CipSeqNovo, Ano)

        Return Ano * 10000 + CipSeqNovo

    End Function

    Function CipNovoInsereDb(ByVal RotaId As Integer, ByVal UserId As Integer, ByVal LimRev As Integer, _
        ByVal Tipo As Integer, ByVal Grupo As String, ByVal SubGrupo As String, _
        ByVal FlagAtrasado As Integer, ByVal DescrAtrasado As String) As Integer


        'Grava o registro deste comando no SqlServer
        Dim CipId As Integer = CipIdNovo()
        Dim DataFim As Date = "01/01/2000"

        Try
            Dim taCipHist As New Geral.dsxCipValidTableAdapters.taxCipHist
            taCipHist.InsertQuery(CipId, RotaId, Now, DataFim, UserId, 1, LimRev, Tipo, Grupo, SubGrupo, 0, FlagAtrasado, 0)
        Catch : End Try

        Dim taCadRotaPtoCr As New Geral.dsxCipValidTableAdapters.taxCadRotaPtoCr
        Dim dtCadRotaPtoCr As New Geral.dsxCipValid.CadRotaPtoCrDataTable
        taCadRotaPtoCr.FillRotaId(dtCadRotaPtoCr, RotaId)

        Dim taCipHistPtoCr As New Geral.dsxCipValidTableAdapters.taxCipHistPtoCr
        For Conta As Integer = 0 To dtCadRotaPtoCr.Rows.Count - 1

            taCipHistPtoCr.InsertQuery(CipId, dtCadRotaPtoCr(Conta).PtoCrId, 0)

        Next

        If FlagAtrasado = 1 Then

            'Caso o CIP esteja atrasado, insere uma anormalidade
            Dim taCipHistAnorm As New Geral.dsxCipValidTableAdapters.taxCipHistAnorm
            taCipHistAnorm.InsertQuery(CipId, 1, Now, 4, 0, 1, DescrAtrasado, 0)

        End If

        Return CipId

    End Function

End Module
