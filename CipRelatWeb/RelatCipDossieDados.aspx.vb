
Imports System.Drawing

Partial Class RelatCipDados
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        If IsPostBack = False Then

            lblCipId.Text = Session("SelRotaId")

        End If

        RefreshRelat()

    End Sub

    Sub RefreshRelat()

        MontaCabecalho()
        MontaPlanTempos()
        MontaAnormalidades()
        MontaPtoCr()
        MontaGraf()

    End Sub

    Sub MontaCabecalho()

        Dim DbCv As New nsCipValid.dcCipValid
        Dim dtCipHist As List(Of nsCipValid.CipHist) = Nothing
        Try
            dtCipHist = (From It In DbCv.CipHist Where It.CipId = lblCipId.Text).ToList
        Catch : End Try

        If dtCipHist.Count <= 0 Then Return
        With dtCipHist(0)

            txtRotaId.Text = .RotaId
            txtDataIni.Text = Format(.DataHoraIni, "dd/MM/yyyy HH:mm:ss")
            txtDataFim.Text = Format(.DataHoraFim, "dd/MM/yyyy HH:mm:ss")
            txtUserId.Text = .UserId
            txtLimRev.Text = .LimRev

            txtRecNum.Text = .RecNum

            If .FlagCancelado = 0 Then
                chkSts.Checked = False
            Else
                chkSts.Checked = True
            End If

            If .FlagAtrasado = 0 Then
                chkFlagAtrasado.Checked = False
            Else
                chkFlagAtrasado.Checked = True
            End If

        End With

        'Dados do cadastro de rotas
        Dim DbCr As New nsCipRotas.dcCipRotas
        Dim dtRotaCad = (From It In DbCr.RotaCad Where It.RotaId = txtRotaId.Text).ToList

        If dtRotaCad.Count > 0 Then
            With dtRotaCad(0)
                txtRotaDescr.Text = .Descr
                txtRotaCirc.Text = .Circ
            End With
        End If

        'Dados do cadastro de receitas
        Dim DbRc As New nsReceitas.dcReceitas
        Dim dtRec = (From It In DbRc.Rec Where It.Area = "CIP" And It.RecNum = txtRecNum.Text).ToList

        If dtRec.Count > 0 Then
            With dtRec(0)
                txtRecNome.Text = .RecNome
                txtRecDescr.Text = .RecDescr
                txtRecCodigo.Text = .Codigo
            End With
        End If

        'Dados do cadastro do usuário
        Dim UserId As Integer = dtCipHist(0).UserId
        Dim dtCadUser = (From It In DbCv.CadUser Where It.UserId = UserId).ToList
        If dtCadUser.Count > 0 Then txtUserNome.Text = dtCadUser.First.Nome

        'Usuario que validou o CIP
        Dim UserIdVlid As Integer = dtCipHist(0).UserIdValid
        Dim dtCadUserValid = (From It In DbCv.CadUser Where It.UserId = UserIdVlid).ToList
        If dtCadUserValid.Count > 0 Then txtUserNomeValid.Text = dtCadUserValid.First.Nome

    End Sub

    Sub MontaPlanTempos()

        If IsNumeric(lblCipId.Text) = False Then Return

        'Dados do grid
        Dim MyDados As New Data.DataTable("Dados")
        MyDados.Columns.Add("BlkNum")
        MyDados.Columns.Add("BlkDescr")
        MyDados.Columns.Add("DataHoraIni")
        MyDados.Columns.Add("Duracao")
        MyDados.Columns.Add("Prog")


        'Busca os tempos programados para este CIP
        Dim DbCv As New nsCipValid.dcCipValid
        Dim dtCipHistDados = (From It In DbCv.CipHistDados Where It.CipId = lblCipId.Text Order By It.DataHora).ToList

        If dtCipHistDados.Count <= 0 Then Return
        Dim BlkDataIni As Date = dtCipHistDados(0).DataHora

        Dim BlkNumAnt As Integer = -1
        For Conta As Integer = 0 To dtCipHistDados.Count - 1
            With dtCipHistDados(Conta)

                If .BlkNum <> BlkNumAnt Then

                    'Termino de um bloco de CIP
                    If BlkNumAnt <> -1 Then

                        Dim Duracao As Integer = DateDiff(DateInterval.Second, BlkDataIni, .DataHora)
                        MyDados.Rows.Add(BlkNumAnt, BuscaBlkDescr(BlkNumAnt), Format(BlkDataIni, "dd/MM/yyyy HH:mm:ss"),
                                         UtConvDhms(Duracao), BuscaBlkDuracao(BlkNumAnt))
                    End If

                    'Memoriza dados do bloco atual
                    BlkNumAnt = .BlkNum
                    BlkDataIni = .DataHora

                End If

            End With
        Next

        'Calcula duracao do ultimo passo do loop
        Dim DhFimS() As String = txtDataFim.Text.Split("/"c, " "c, ":")
        Dim DhFim As New Date(DhFimS(2), DhFimS(1), DhFimS(0), DhFimS(3), DhFimS(4), DhFimS(5))

        Dim DuracaoFim As Integer = DateDiff(DateInterval.Second, BlkDataIni, DhFim)
        MyDados.Rows.Add(BlkNumAnt, BuscaBlkDescr(BlkNumAnt), Format(BlkDataIni, "dd/MM/yyyy HH:mm:ss"),
                         UtConvDhms(DuracaoFim), BuscaBlkDuracao(BlkNumAnt))


        'Envia dados ao grid
        gvTempos.DataSource = MyDados
        gvTempos.DataBind()

    End Sub

    Sub MontaAnormalidades()

        'Dados do grid
        Dim MyDados As New Data.DataTable("Dados")
        MyDados.Columns.Add("DataHora")
        MyDados.Columns.Add("Mensagem")
        MyDados.Columns.Add("Obs")
        MyDados.Columns.Add("BlkNum")
        MyDados.Columns.Add("BlkDescr")


        'Busca os tempos programados para este CIP
        Dim DbCv As New nsCipValid.dcCipValid
        Dim dtCipHistAnorm As List(Of nsCipValid.CipHistAnorm) = Nothing
        Try
            dtCipHistAnorm = (From It In DbCv.CipHistAnorm Where It.CipId = lblCipId.Text Order By It.DataHora).ToList
        Catch : End Try

        If dtCipHistAnorm.Count <= 0 Then Return

        For Conta As Integer = 0 To dtCipHistAnorm.Count - 1
            With dtCipHistAnorm(Conta)

                MyDados.Rows.Add(Format(.DataHora, "dd/MM/yyyy HH:mm:ss"), BuscaAnormEvento(.AnormEquip, .AnormEvnt),
                                 Trim(.Obs), .BlkNum, BuscaBlkDescr(.BlkNum))

            End With
        Next

        'Envia dados ao grid
        gvAnorm.DataSource = MyDados
        gvAnorm.DataBind()

    End Sub

    Sub MontaPtoCr()

        If IsNumeric(lblCipId.Text) = False Then Return

        'Dados do grid
        Dim MyDados As New Data.DataTable("Dados")
        MyDados.Columns.Add("Pergunta")
        MyDados.Columns.Add("Resposta")

        Dim DbCv As New nsCipValid.dcCipValid
        Dim dtCadPtoCr = (From It In DbCv.CadPtoCr).ToList

        'Busca os tempos programados para este CIP
        Dim dtCipHistPtoCr = (From It In DbCv.CipHistPtoCr Where It.CipId = lblCipId.Text Order By It.PtoCrId).ToList

        For Conta As Integer = 0 To dtCipHistPtoCr.Count - 1
            With dtCipHistPtoCr(Conta)

                Dim Pergunta As String = .PtoCrId
                Dim MyPtCr = (From It In dtCadPtoCr Where It.PtoCrId = .PtoCrId).ToList
                If MyPtCr.Count > 0 Then Pergunta = MyPtCr(0).Pergunta

                Dim RespTxt As String = "."
                If .Resp = 0 Then
                    RespTxt = "Pend"
                ElseIf .Resp = 1 Then
                    RespTxt = "Sim"
                Else
                    RespTxt = "Não"
                End If

                MyDados.Rows.Add(Pergunta, RespTxt)

            End With
        Next

        'Envia dados ao grid
        gvPtoCr.DataSource = MyDados
        gvPtoCr.DataBind()

    End Sub

    Sub MontaGraf()

        'Dados do CIP
        Dim DbCv As New nsCipValid.dcCipValid
        Dim dtHistDados As List(Of nsCipValid.CipHistDados) = Nothing
        Try
            dtHistDados = (From It In DbCv.CipHistDados Where It.CipId = lblCipId.Text Order By It.DataHora).ToList
        Catch : End Try


        'Limites das variáveis por passo do CIP
        Dim dtCadRotasLim As List(Of nsCipValid.CadRotasLim) = Nothing
        Try
            dtCadRotasLim = (From It In DbCv.CadRotasLim Where It.RotaId = txtRotaId.Text And It.LimRev = txtLimRev.Text
                             Order By It.BlkNum).ToList
        Catch : End Try

        'Deleta os arquivos
        Dim MyPath As String = My.Request.MapPath("") & "\" & "Charts\Cht*.xml"
        Dim MyName As String = Dir(MyPath)
        Do While MyName <> ""

            Dim MyFile As String = My.Request.MapPath("") & "\Charts\" & MyName

            Try
                Kill(MyFile)
            Catch : End Try

            MyName = Dir()

        Loop

        'Graficos de temperatura, concentração e vazao
        MontaXml("Charts\ChtTemp_" & lblCipId.Text & ".xml", "Temperatura", "", dtHistDados, dtCadRotasLim, "Temp", 100, 0)
        MontaXml("Charts\ChtCond_" & lblCipId.Text & ".xml", "Concentração", "", dtHistDados, dtCadRotasLim, "Cond", 200, 0)
        MontaXml("Charts\ChtVazao_" & lblCipId.Text & ".xml", "Vazão", "", dtHistDados, dtCadRotasLim, "Vazao", 40, 0)
        MontaXml("Charts\ChtBlkNum_" & lblCipId.Text & ".xml", "Blocos de CIP", "", dtHistDados, dtCadRotasLim, "BlkNum", 12, 0)

    End Sub

    Sub MontaXml(ByVal ArqPath As String, ByVal Titulo As String, ByVal SubTitulo As String, _
            ByVal dtHistDados As List(Of nsCipValid.CipHistDados), _
            ByVal dtCadRotasLim As List(Of nsCipValid.CadRotasLim), _
            ByVal ColVar As String, _
            ByVal EixoYMax As Double, ByVal EixoYMin As Double)

        Dim MyPathName As String = My.Request.MapPath("") & "\" & ArqPath

        Dim ArqId As Integer = FreeFile()
        Try : FileOpen(ArqId, MyPathName, OpenMode.Output, OpenAccess.Write) : Catch : End Try

        Dim Txt As String = "<graph caption='" & Titulo & "' " & _
                            "subcaption='" & SubTitulo & "' " & _
                            "hovercapbg='FFECAA' hovercapborder='F47E00' formatNumberScale='0' decimalPrecision='0' showvalues='0' numdivlines='3' numVdivlines='0' " & _
                            "yaxisminvalue='" & EixoYMin & "' " & _
                            "yaxismaxvalue='" & EixoYMax & "' " & _
                            "rotateNames='1'>"

        Try : PrintLine(ArqId, Txt) : Catch : End Try

        'Categorias, eixo X
        PrintLine(ArqId, " ")
        PrintLine(ArqId, "<categories >")

        Dim MinAnt As Integer = -1
        For Conta As Integer = 0 To dtHistDados.Count - 1

            Dim DataHora As String = Format(dtHistDados(Conta).DataHora, "HH:mm:ss")

            Dim MinAtual As Integer = Val(Format(dtHistDados(Conta).DataHora, "mm"))
            If MinAtual <> MinAnt And _
                (MinAtual = 0 Or MinAtual = 10 Or MinAtual = 20 Or MinAtual = 30 Or MinAtual = 40 Or MinAtual = 50) Then
                PrintLine(ArqId, "    <category name='" & DataHora & "' />")
            Else
                PrintLine(ArqId, "    <category name='' />")
            End If

            MinAnt = MinAtual
        Next

        PrintLine(ArqId, "</categories >")


        'Pena da variavel
        PrintLine(ArqId, " ")
        PrintLine(ArqId, "<dataset seriesName='" & Titulo & "' color='0000FF' showAnchors='0'>")

        For Conta As Integer = 0 To dtHistDados.Count - 1
            PrintLine(ArqId, "    <set value='" & GetHistDadosColVar(dtHistDados(Conta), ColVar) & "' />")
        Next
        PrintLine(ArqId, "</dataset >")


        'Pena do passo
        'PrintLine(ArqId, " ")
        'PrintLine(ArqId, "<dataset seriesName='Passo' color='000000' showAnchors='0'>")

        'For Conta As Integer = 0 To dtHistDados.Rows.Count - 1
        '    PrintLine(ArqId, "    <set value='" & dtHistDados(Conta).Passo & "' />")
        'Next
        'PrintLine(ArqId, "</dataset >")

        If ColVar <> "BlkNum" Then
            'Limite máximo
            PrintLine(ArqId, " ")
            PrintLine(ArqId, "<dataset seriesName='Máximo' color='FF0000' showAnchors='0'>")

            Dim CipBlkNumMaxAnt As Integer = -1
            Dim ValorMax As Double = 0
            For Conta As Integer = 0 To dtHistDados.Count - 1

                'Otimiza as chamadas de Select
                Dim CipBlkNumMax As Integer = dtHistDados(Conta).BlkNum
                If CipBlkNumMax <> CipBlkNumMaxAnt Then

                    Dim MyRow = (From It In dtCadRotasLim Where It.BlkNum = CipBlkNumMax).ToList
                    If MyRow.Count > 0 Then ValorMax = GetCadRotasLimColVar(MyRow.First, ColVar, True)
                    If ValorMax > EixoYMax Then ValorMax = EixoYMax

                End If

                PrintLine(ArqId, "    <set value='" & ValorMax & "' />")
                CipBlkNumMaxAnt = CipBlkNumMax

            Next
            PrintLine(ArqId, "</dataset >")


            'Limite mínimo
            PrintLine(ArqId, " ")
            PrintLine(ArqId, "<dataset seriesName='Mínimo' color='FF0000' showAnchors='0'>")

            Dim CipBlkNumMinAnt As Integer = -1
            Dim ValorMin As Double = 0
            For Conta As Integer = 0 To dtHistDados.Count - 1

                'Otimiza as chamadas de Select
                Dim CipBlkNumMin As Integer = dtHistDados(Conta).BlkNum
                If CipBlkNumMin <> CipBlkNumMinAnt Then

                    Dim MyRow = (From It In dtCadRotasLim Where It.BlkNum = CipBlkNumMin).ToList
                    If MyRow.Count > 0 Then ValorMin = GetCadRotasLimColVar(MyRow.First, ColVar, False)
                    If ValorMin > EixoYMin Then ValorMin = EixoYMin

                End If

                PrintLine(ArqId, "    <set value='" & ValorMin & "' />")
                CipBlkNumMinAnt = CipBlkNumMin

            Next
            PrintLine(ArqId, "</dataset >")

        End If


        ''Linhas de maxmino e minimo
        'PrintLine(ArqId, "<trendlines>")
        'PrintLine(ArqId, "    <line startValue='" & ValorMaximo & "' endValue='" & ValorMaximo & "' color='FF0000' displayValue='Máximo' thickness='1' alpha='80' />")
        'PrintLine(ArqId, "    <line startValue='" & ValorMinimo & "' endValue='" & ValorMinimo & "' color='FF0000' displayValue='Mínimo' thickness='1' alpha='80' />")
        'PrintLine(ArqId, "</trendlines>")

        PrintLine(ArqId, " ")
        PrintLine(ArqId, "</graph >")


        'Fecha o arquivo
        FileClose(ArqId)

    End Sub

    Function GetHistDadosColVar(dtHistDados As nsCipValid.CipHistDados, ColVar As String) As Double

        Dim Valor As Double = 0

        If ColVar = "Temp" Then
            Valor = dtHistDados.Temp
        ElseIf ColVar = "Cond" Then
            Valor = dtHistDados.Cond
        ElseIf ColVar = "Vazao" Then
            Valor = dtHistDados.Vazao
        ElseIf ColVar = "BlkNum" Then
            Valor = dtHistDados.BlkNum
        End If

        Return Valor

    End Function

    Function GetCadRotasLimColVar(dtCadRotasLim As nsCipValid.CadRotasLim, ColVar As String, SelMax As Boolean) As Double

        Dim Valor As Double = 0

        If ColVar = "Temp" Then
            If SelMax = True Then
                Valor = dtCadRotasLim.TempMax
            Else
                Valor = dtCadRotasLim.TempMin
            End If
        ElseIf ColVar = "Cond" Then
            If SelMax = True Then
                Valor = dtCadRotasLim.CondMax
            Else
                Valor = dtCadRotasLim.CondMin
            End If
        ElseIf ColVar = "Vazao" Then
            If SelMax = True Then
                Valor = dtCadRotasLim.VazaoMax
            Else
                Valor = dtCadRotasLim.VazaoMin
            End If
        ElseIf ColVar = "BlkNum" Then
            Valor = dtCadRotasLim.BlkNum
        End If

        Return Valor

    End Function

    Function MontaGrafTemp() As String

        Return InfoSoftGlobal.InfoSoftGlobal.FusionCharts.RenderChartHTML("Charts\FCF_MSLine.swf", _
                                "Charts\ChtTemp_" & lblCipId.Text & ".xml", "", "Temp", "1024", "300", False)

    End Function

    Function MontaGrafCond() As String

        Return InfoSoftGlobal.InfoSoftGlobal.FusionCharts.RenderChartHTML("Charts\FCF_MSLine.swf", _
                                "Charts\ChtCond_" & lblCipId.Text & ".xml", "", "Cond", "1024", "300", False)

    End Function

    Function MontaGrafVazao() As String

        Return InfoSoftGlobal.InfoSoftGlobal.FusionCharts.RenderChartHTML("Charts\FCF_MSLine.swf", _
                                "Charts\ChtVazao_" & lblCipId.Text & ".xml", "", "Vazao", "1024", "300", False)

     End Function

    Function MontaGrafBlkNum() As String

        Return InfoSoftGlobal.InfoSoftGlobal.FusionCharts.RenderChartHTML("Charts\FCF_MSLine.swf", _
                                "Charts\ChtBlkNum_" & lblCipId.Text & ".xml", "", "BlkNum", "1024", "300", False)

    End Function

    Function BuscaBlkDescr(ByVal BlkNum As Integer) As String

        Dim DbRc As New nsReceitas.dcReceitas
        Dim dtBlocos = (From It In DbRc.Blocos Where It.Area = "CIP" And It.BlkNum = BlkNum).ToList

        If dtBlocos.Count <= 0 Then Return ""

        Return dtBlocos(0).BlkDescr

    End Function

    Function BuscaBlkDuracao(ByVal BlkNum As Integer) As Integer

        Dim DbRc As New nsReceitas.dcReceitas
        Dim dtRecBlocos = (From It In DbRc.RecBlocos Where It.Area = "CIP" And It.RecNum = txtRecNum.Text And It.BlkNum = BlkNum
                           Order By It.ItemSeq).ToList
        If dtRecBlocos.Count <= 0 Then Return 0


        Dim dtBlocosItens = (From It In DbRc.BlocosItens Where It.Area = "CIP" And It.BlkNum = BlkNum Order By It.ItemSeq).ToList

        Dim Duracao As Integer = 0
        For Conta As Integer = 0 To dtBlocosItens.Count - 1
            With dtBlocosItens(Conta)

                If .UEng <> "seg" Then Continue For

                Dim NSeg As Integer = BuscaPrm(dtRecBlocos(0), .ItemSeq)
                Duracao = Duracao + NSeg

            End With
        Next

        Return Duracao

    End Function

    Function BuscaPrm(ByVal rwRecBlocos As nsReceitas.RecBlocos, ByVal ContaPrm As Integer) As Integer

        Dim Prm As Integer = 0

        Select Case ContaPrm
            Case 0
                Prm = rwRecBlocos.Param01
            Case 1
                Prm = rwRecBlocos.Param02
            Case 2
                Prm = rwRecBlocos.Param03
            Case 3
                Prm = rwRecBlocos.Param04
            Case 4
                Prm = rwRecBlocos.Param05
            Case 5
                Prm = rwRecBlocos.Param06
            Case 6
                Prm = rwRecBlocos.Param07
            Case 7
                Prm = rwRecBlocos.Param08
            Case 8
                Prm = rwRecBlocos.Param09
        End Select

        Return Prm

    End Function

End Class
