Public Class frmIfProd

    Dim Rp As KbProdPlanejCtrl.clsIPlanej

    Public TrataArea As New Geral.clsTrataArea()
    Public listDestTqs As KbProdPlanejCtrl.clsListaDados
    Public listReceitas As KbProdPlanejCtrl.clsListaDados
    Dim dtReceitasList As List(Of KbProdPlanejCtrl.clsRec)

    Public AreaSelected As String
    Public gPressaoStg01 As Integer = 0
    Public gPressaoStg02 As Integer = 0

    Sub SrvConectar()

        Dim Caminho As String = Util.UtAppPath
        Dim Cfg As New Util.clsTrataCfg(Caminho & "\..\Bin\cfgGeral.xml")
        Dim ServIp As String = Cfg.colCfg("ServerIp")

        'Tenta inicializar a comunicação com o programa servidor
        Dim RpEndPoint As String = "http://" & ServIp & ":8080/KbProdPlanejCtrl"
        Rp = New ChannelFactory(Of KbProdPlanejCtrl.clsIPlanej)(New BasicHttpBinding(), New EndpointAddress(RpEndPoint)).CreateChannel()

    End Sub

    Sub RefreshPastas()

        cmbPasta.Items.Clear()
        cmbPasta.Items.Add("*")
        cmbPasta.Text = "*"

        cmbSubpasta.Items.Clear()
        cmbSubpasta.Items.Add("*")
        cmbSubpasta.Text = "*"

        'Condição txtDed.Text deve ser alimentada no OnLoad da Página
        Dim Rc As New Geral.nsReceitas.dcReceitas
        Dim dtPastas = (From It In Rc.Rec
                        Where
                            It.Area.ToUpper = AreaSelected.ToUpper
                        Order By
                            It.Pasta
                        Select New With {
                            It.Pasta
                        }).Distinct().ToList()

        For Conta As Integer = 0 To dtPastas.Count - 1
            With dtPastas(Conta)

                If .Pasta <> "" And .Pasta <> "*" Then cmbPasta.Items.Add(.Pasta)

            End With
        Next

    End Sub

    Sub RefreshSubpastas()

        cmbSubpasta.Items.Clear()
        cmbSubpasta.Items.Add("*")
        cmbSubpasta.Text = "*"


        'Condição txtDed.Text deve ser alimentada no OnLoad da Página
        Dim Rc As New Geral.nsReceitas.dcReceitas
        Dim dtSubPastas = (From It In Rc.Rec
                           Where
                               It.Area.ToUpper = AreaSelected.ToUpper _
                           And It.Pasta = cmbPasta.Text
                           Order By
                               It.Subpasta
                           Select New With {
                               It.Subpasta
                           }).Distinct().ToList()

        For Conta As Integer = 0 To dtSubPastas.Count - 1
            With dtSubPastas(Conta)

                If .Subpasta <> "" And .Subpasta <> "*" Then cmbSubpasta.Items.Add(.Subpasta)

            End With
        Next

    End Sub

    Sub LoadTqs()

        Dim IdxSel As Integer = 0

        'Le tabela de tanques destino e carrega na estrutura
        cmbDestTqs.Items.Clear()

        listDestTqs = New KbProdPlanejCtrl.clsListaDados

        Dim Rc As New Geral.nsReceitas.dcReceitas
        Dim dtDestTqs = (From It In Rc.DestTqs Where It.Area = AreaSelected Order By It.TqNome).ToList()

        For Conta As Integer = 0 To dtDestTqs.Count - 1
            With dtDestTqs(Conta)

                'IVAN - 2019.03.22
                'cmbDestTqs.Items.Add(.TqNome & " - " & .TqDescr)
                cmbDestTqs.Items.Add(.TqNome)

                listDestTqs.Add(.TqNome, .TqDescr,
                .EndStatus, .EndPlanejamento, .EndProduzido,
                , , , , , , , , , , , , .EndAlergenico, .EndPressao01, .EndPressao02, .TqNome)

                If My.Application.CommandLineArgs.Count >= 2 Then
                    If My.Application.CommandLineArgs(1) = .TqNome Then IdxSel = Conta
                End If

            End With
        Next

        cmbDestTqs.SelectedIndex = IdxSel

    End Sub

    Sub LoadReceitas()

        'IVAN 2019.03.23 - Removida a função e adicionada no click da selação de produto


        'Dim Qry As String = ""
        'Dim txtCmb As String = ""

        ''Le tabela de receitas e carrega na estrutura
        'cmbReceitas.Items.Clear()

        'Dim db As New Geral.nsReceitas.dcReceitas

        'Dim teste = cmbDestTqs.SelectedValue

        'Dim teste2 = (From it In db.tb_CBT_CadastroBatch Select it).ToList()


        'listReceitas = New KbProdPlanejCtrl.clsListaDados

        'Qry = "SELECT " & _
        '            "* " & _
        '        "FROM " & _
        '            "Rec " & _
        '        "WHERE " & _
        '            "Area = '" & AreaSelected & "' "

        'If cmbPasta.Text <> "*" Then
        '    Qry = Qry & _
        '        "AND " & _
        '            "Pasta = '" & cmbPasta.Text & "' "
        'End If

        'If cmbSubpasta.Text <> "*" Then
        '    Qry = Qry & _
        '        "AND " & _
        '            "Subpasta = '" & cmbSubpasta.Text & "' "
        'End If

        'Qry = Qry & _
        '        "And Habilita > 0 ORDER BY " & _
        '            "RecNum"

        'Try

        '    Dim Rc As New Geral.nsReceitas.dcReceitas
        '    Dim dtReceitas = Rc.ExecuteQuery(GetType(KbProdPlanejCtrl.clsRec), Qry)
        '    dtReceitasList = New List(Of KbProdPlanejCtrl.clsRec)(dtReceitas)

        '    For Each Dd In dtReceitasList
        '        With Dd

        '            'txtCmb = Right(.RecNum, 3)
        '            txtCmb = Format(.RecNum, "000")
        '            txtCmb = txtCmb & " - " & .RecNome & " (" & .RecDescr & ") - Cod " & .Codigo
        '            cmbReceitas.Items.Add(txtCmb)
        '            listReceitas.Add(.RecNum, .RecDescr, .RecNome, .Codigo, _
        '        , , , , , , , , , , , , , , , , .RecNum)

        '        End With

        '    Next

        'Catch ex As Exception
        'End Try

    End Sub

    Function SelecionaReceita(ByVal RecNum As Integer) As Boolean

        'Procura na Lista a receita que possui este numero
        For Conta = 0 To listReceitas.Count - 1

            If listReceitas.Item(Conta).Dado0 = RecNum Then

                'Receita encontrada
                cmbReceitas.SelectedIndex = Conta
                Return True

            End If

        Next

        'Receita nao encontrada na Lista
        MsgBox("A Receita de número [" & RecNum & "] não está cadastrada no sistema", MsgBoxStyle.Exclamation)

        Return False

    End Function

    Function DadosTqSel(Optional ByRef outTqNome As String = "", Optional ByRef outTqDescr As String = "",
                        Optional ByRef outEndStatus As String = "", Optional ByRef outEndPlanejamento As String = "",
                        Optional ByRef outEndProduzido As String = "", Optional ByRef outEndAlergenico As String = "") As Boolean


        'Busca dados do tanque selecionado

        If cmbDestTqs.Text = "" Then
            Return False
        End If

        Dim Pos As Integer = cmbDestTqs.SelectedIndex + 1

        outTqNome = listDestTqs(Pos).Dado0
        outTqDescr = listDestTqs(Pos).Dado1
        outEndStatus = listDestTqs(Pos).Dado2
        outEndPlanejamento = listDestTqs(Pos).Dado3
        outEndProduzido = listDestTqs(Pos).Dado4
        outEndAlergenico = listDestTqs(Pos).Dado17

        Return True

    End Function

    Function DadosReceita(ByRef outRecNum, ByRef outRecNome, ByRef outRecCodigo) As Boolean

        'Responde o numero da receita selecionada
        If cmbReceitas.Text = "" Then Return False


        'Receita encontrada
        Dim Pos As Integer = cmbReceitas.SelectedIndex + 1

        outRecNum = listReceitas(Pos).Dado0
        outRecNome = listReceitas(Pos).Dado1
        outRecCodigo = listReceitas(Pos).Dado3

        DadosReceita = True

    End Function

    Private Sub frmIfProd_Load(sender As Object, e As System.EventArgs) Handles Me.Load

        Geral.DllInit()

        If My.Application.CommandLineArgs.Count < 1 Then
            MsgBox("Falha na ativação do programa. Passe como parametro a área das receitas", MsgBoxStyle.Exclamation)
            Me.Close()
        End If


        'Init
        Try
            AreaSelected = My.Application.CommandLineArgs(0)

            TrataArea.AreaLe(AreaSelected)


            'Configuração Inical do formulário
            If TrataArea.AreaDados("Area") = "Mistura" Then
                lblAlergenicos.Visible = True
                txtAlergenicos.Visible = True
                lblProduzir.Visible = False
                lblUnidProduzir.Visible = False
                TotalProduzir.Visible = False
                chkListaAutomatica.CheckState = CheckState.Checked
                chkListaAutomatica.Visible = True
                lblRelatId.Visible = True
                cmdRelatPreench.Visible = True
                cmdRelat.Enabled = False
                TamanhoBatch.Enabled = False
            Else
                cmbPasta.Enabled = True
                cmbSubpasta.Enabled = True
            End If

            'Monta a Lista de tanques destino
            LoadTqs()

            RefreshPastas()

            LoadReceitas()

            'Atualiza a StatusStrip
            labelStrip1.Text = TrataArea.AreaDados("Descr")
            labelStrip2.Text = TrataArea.AreaDados("Area")
        Catch : End Try

        SrvConectar()

        TmrPula.Enabled = True

    End Sub

    Private Sub cmbPasta_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmbPasta.SelectedIndexChanged
        RefreshSubpastas()
        LoadReceitas()
    End Sub

    Private Sub cmbSubpasta_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmbSubpasta.SelectedIndexChanged
        LoadReceitas()
    End Sub

    Private Sub mnuAjuda_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)

        Dim Cmd As String = ""

        'Chama arquivo de help
        Cmd = "Winhlp32 " & Util.UtAppPath & "\Help\frmProdPlanej.HLP"
        Shell(Cmd)

    End Sub

    Private Sub mnuSobre_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Dim MyFrm As New KbProdPlanejCtrl.frmAbout
        MyFrm.Show()
    End Sub

    Private Sub mnuSair_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Close()
    End Sub

    Private Sub mnuPlcLe_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)

        Dim Pos As Integer = 0
        Dim Alergenicos As String = String.Empty

        If cmbDestTqs.Text <> "" Then

            SrvConectar()

            'Posição do Tanque no ComboBox
            Dim Msg As String = "", outTamanhoBatch As Integer = 0, outTotalProd As Integer = 0, outRecNum As Integer = 0
            Pos = cmbDestTqs.SelectedIndex + 1
            Dim ResultadoLe As Boolean = Rp.CmdLe(AreaSelected, listDestTqs.Item(Pos).Dado0, listDestTqs.Item(Pos).Dado1,
                                                       listDestTqs.Item(Pos).Dado2, listDestTqs.Item(Pos).Dado3, "",
                                                       outTamanhoBatch, outTotalProd, outRecNum, Msg, Alergenicos, listDestTqs.Item(Pos).Dado17)


            If ResultadoLe = True Then

                TamanhoBatch.Text = outTamanhoBatch
                TotalProduzir.Text = outTotalProd

                'Busca a receita selecionada
                For Conta As Integer = 0 To cmbReceitas.Items.Count - 1

                    Try

                        Dim TRecNum() As String = cmbReceitas.Items(Conta).ToString.Split(" ")

                        Dim TRn As Integer = TRecNum(0)
                        If TRn = outRecNum Then
                            cmbReceitas.SelectedIndex = Conta
                        End If

                    Catch
                    End Try
                Next

                txtAlergenicos.Text = Alergenicos

            End If

            MsgBox(Msg)

        End If

    End Sub

    Private Sub mnuPlcEnvia_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)

        Dim Pos As Integer = 0
        Dim RecNum As Integer = 0
        Dim RecNome As String = ""
        Dim RecDescr As String = ""
        Dim Codigo As Integer = 0
        Dim Alergenicos As String = String.Empty

        If cmbReceitas.Text <> "" Then

            If chkListaAutomatica.Checked Then

                Dim txt As String = cmbReceitas.Text
                Dim txtReceita As Array = txt.Split("-")

                RecNum = Val(txtReceita(1))

                Dim txtRecNomeDescr As Array = txtReceita(2).Split("(")

                RecNome = txtRecNomeDescr(0)

                Dim txtRecCod As Array = txtReceita(3).Split(" ")

                Codigo = Val(txtRecCod(2))

                'STRING DE ALERGENICOS DA RECEITA
                Alergenicos = txtAlergenicos.Text

                Pos = cmbDestTqs.SelectedIndex + 1

                SrvConectar()

                Dim Msg As String = ""
                Dim ResultadoEnviado As Boolean = Rp.CmdEscr(AreaSelected, listDestTqs.Item(Pos).Dado2, listDestTqs.Item(Pos).Dado3,
                                                         RecNum, RecNome, Codigo, TamanhoBatch.Text, TotalProduzir.Text, Msg, Alergenicos, listDestTqs.Item(Pos).Dado17, listDestTqs.Item(Pos).Dado18, gPressaoStg01, listDestTqs.Item(Pos).Dado19, gPressaoStg02)
                'Dim PlcEnviaReceita As New clsPlcEnviaReceitas(AreaSelected, "", 0, listDestTqs.Item(Pos).Dado2, listDestTqs.Item(Pos).Dado3, RecNum, RecNome, Codigo)
                'Dim ResultadoEnviado = PlcEnviaReceita.PlcEnviaDados(TamanhoBatch.Text, TotalProduzir.Text)

                MessageBox.Show(Msg, "ATENÇÃO", MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1)


            Else

                Dim txt As String = cmbReceitas.Text
                Dim txtReceita As Array = txt.Split("-")

                RecNum = Val(txtReceita(0))

                Dim txtRecNomeDescr As Array = txtReceita(1).Split("(")

                RecNome = txtRecNomeDescr(0)

                Dim txtRecCod As Array = txtReceita(2).Split(" ")

                Codigo = Val(txtRecCod(2))

                'STRING DE ALERGENICOS DA RECEITA
                Alergenicos = txtAlergenicos.Text

                Pos = cmbDestTqs.SelectedIndex + 1


                SrvConectar()

                Dim Msg As String = ""
                Dim ResultadoEnviado As Boolean = Rp.CmdEscr(AreaSelected, listDestTqs.Item(Pos).Dado2, listDestTqs.Item(Pos).Dado3,
                                                         RecNum, RecNome, Codigo, TamanhoBatch.Text, TotalProduzir.Text, Msg, Alergenicos, listDestTqs.Item(Pos).Dado17, listDestTqs.Item(Pos).Dado18, gPressaoStg01, listDestTqs.Item(Pos).Dado19, gPressaoStg02)
                'Dim PlcEnviaReceita As New clsPlcEnviaReceitas(AreaSelected, "", 0, listDestTqs.Item(Pos).Dado2, listDestTqs.Item(Pos).Dado3, RecNum, RecNome, Codigo)
                'Dim ResultadoEnviado = PlcEnviaReceita.PlcEnviaDados(TamanhoBatch.Text, TotalProduzir.Text)

                MessageBox.Show(Msg, "ATENÇÃO", MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1)

            End If

        Else

            MsgBox("Selecione a Receita a ser Enviada !")
            cmbReceitas.Focus()

        End If

    End Sub


    Private Sub ButLe_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButLe.Click
        mnuPlcLe_Click(sender, e)

    End Sub

    Private Sub ButEnvia_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButEnvia.Click

        If cmbReceitas.Text <> "" Then

            If chkListaAutomatica.Checked Then

                'Levanta tanque demandado
                Dim tq = cmbDestTqs.Text

                'Levanta numero do Batch Demandado
                Dim searchChar = " - "
                Dim valorBusca = cmbReceitas.Text
                Dim posicaoChar = valorBusca.IndexOf(searchChar)
                Dim bt = Mid(valorBusca, 10, posicaoChar - 9)

                'Edita o cadastro de batch por tanque e popula tabela de controle
                Dim Rc As New Geral.nsReceitas.dcReceitas
                Dim editaCadastro = (From it In Rc.tb_CTL_ControleBatch Where it.ctl_Tanque = tq Select it).FirstOrDefault()
                editaCadastro.ctl_Batch = bt
                Rc.SubmitChanges()

            End If

        End If

        mnuPlcEnvia_Click(sender, e)

    End Sub



    Private Sub TmrPula_Tick(ByVal sender As Object, ByVal e As System.EventArgs) Handles TmrPula.Tick

        TmrPula.Enabled = False

        Me.WindowState = FormWindowState.Minimized
        Me.WindowState = FormWindowState.Normal

        Activate()

    End Sub

    Private Sub cmdRelat_Click(sender As System.Object, e As System.EventArgs) Handles cmdRelat.Click

        Dim Rc() As String = cmbReceitas.Text.Split
        If Rc(0).Trim = "" Then Return
        Dim RecNum As Integer = Rc(0)

        Dim Dt() As String = cmbDestTqs.Text.Split
        If Dt(0).Trim = "" Then Return
        Dim DestTq As String = Strings.Right(Dt(0), 6)

        Dim Cmd As String = """" & Util.UtAppPath & "\..\Bin\KbImprimeReceita.exe"" " &
                    RecNum & " " &
                    TamanhoBatch.Text & " " &
                    DestTq

        Try
            Shell(Cmd)
        Catch : End Try

    End Sub

    Private Sub cmbReceitas_SelectedValueChanged(sender As Object, e As EventArgs) Handles cmbReceitas.SelectedValueChanged

        Dim Rc As New Geral.nsReceitas.dcReceitas

        Dim vStrAlergenicos As String = String.Empty

        Dim RecSelected As String = cmbReceitas.SelectedItem
        Dim strRec() As String = RecSelected.Split(" - ")
        Dim sRecNum As Integer

        If chkListaAutomatica.Checked Then
            Dim vBatch As Integer = Convert.ToInt32(strRec(1))
            'Dim cbt = (From it In Rc.tb_CBT_CadastroBatch Where it.CBT_IDBatch = vBatch And it.CBT_Tanque = cmbDestTqs.Text Select it).FirstOrDefault
            Dim cbt = (From it In Rc.tb_CPI_CadastroPequenoIngrediente Where it.CPI_IDBlend = vBatch And it.CPI_Tanque = cmbDestTqs.Text Select it).FirstOrDefault
            sRecNum = cbt.RecNum
            TamanhoBatch.Text = (cbt.CPI_VolumeBatch) * 1000


        Else
            sRecNum = Convert.ToInt32(strRec(0))
        End If

        Dim vArea As String = Trim(TrataArea.AreaDados("Area"))

        'ALERGENICOS CADASTRADOS
        Dim dtAlergenicos = (From It In Rc.Alergenico).ToList

        'ALERGENICOS DA RECEITA
        Dim dtRecAlerg = (From It In Rc.AlergenicosRec Where It.Area = vArea And It.RecNum = sRecNum).ToList
        For conta As Integer = 0 To dtRecAlerg.Count - 1

            'ALERGENICOS
            Dim dtAlergLetra = (From it In dtAlergenicos Where it.CodAlergenico = dtRecAlerg(conta).CodAlergenico).ToList
            vStrAlergenicos = vStrAlergenicos & dtAlergLetra.First.Letra

        Next

        txtAlergenicos.Text = vStrAlergenicos

        'PRESSOES DA RECEITA ESTAGIO 01 E 02
        Dim dtRecPressoesStgs = (From It In Rc.Rec Where It.Area = vArea And It.RecNum = sRecNum).ToList
        If dtRecPressoesStgs.Count = 1 Then
            gPressaoStg01 = dtRecPressoesStgs.First.Pressao01
            gPressaoStg02 = dtRecPressoesStgs.First.Pressao02
        Else
            gPressaoStg01 = 0
            gPressaoStg02 = 0
        End If


    End Sub

    Private Sub cmdRelatPreench_Click(sender As Object, e As EventArgs) Handles cmdRelatPreench.Click
        'Dim Rc() As String = cmbReceitas.Text.Split
        'If Rc(0).Trim = "" Then Return
        'Dim RecNum As Integer = Rc(0)

        'Dim Dt() As String = cmbDestTqs.Text.Split
        'If Dt(0).Trim = "" Then Return
        'Dim DestTq As String = Strings.Right(Dt(0), 6)

        'Dim selecionaReceita As New frmSelecionaReceitaRelat
        'selecionaReceita.Abre(RecNum, TamanhoBatch.Text, DestTq)
        'selecionaReceita.ShowDialog()

        frmSelecionaReceitaRelat.Abre()
        'frmSelecionaReceitaRelat.Abre(RecNum, TamanhoBatch.Text, DestTq)
        'frmSelecionaReceitaRelat.Show()
    End Sub

    Private Sub cmbReceitas_Click(sender As Object, e As EventArgs) Handles cmbReceitas.Click

        'Caso o checkbox de Lista automática esteja habilitada deve "puxar" a lista de receitas dos Batches demandados
        If chkListaAutomatica.Checked Then

            Dim vTqDestino As String = ""

            'Le tabela de receitas e carrega na estrutura
            cmbReceitas.Items.Clear()

            vTqDestino = listDestTqs.Item(cmbDestTqs.SelectedIndex + 1).Dado0

            'Acessa o banco RECEITAS
            Dim db As New Geral.nsReceitas.dcReceitas

            'Busca de Batches demandados (Batch Errors / Pesagem)
            'Dim vListaBacthes = (From it In db.tb_CBT_CadastroBatch Where it.CBT_Tanque = vTqDestino And it.CBT_Excluido = False Select it).ToList()
            Dim vListaBacthes = (From it In db.tb_CPI_CadastroPequenoIngrediente Where it.CPI_Tanque = vTqDestino And it.CPI_Excluido = False And it.CPI_ID >= 18680 Select it.CPI_IDBlend, it.RecNum).ToList().Distinct()
            Dim vListaReceitas = (From it In db.Rec Select it).ToList()

            listReceitas = New KbProdPlanejCtrl.clsListaDados

            'For Each vBatch In vListaBacthes
            '    Dim vDescReceita = (From it In vListaReceitas Where it.RecNum = vBatch.RecNum Select it).FirstOrDefault
            '    cmbReceitas.Items.Add("BatchID: " & vBatch.CBT_IDBatch & " - " & vDescReceita.RecNum & " - " & vDescReceita.RecNome & " (" & vDescReceita.RecDescr & ") - Cod " & vDescReceita.Codigo)
            '    listReceitas.Add(vDescReceita.RecNum, vDescReceita.RecDescr, vDescReceita.RecNome, vDescReceita.Codigo,
            '           , , , , , , , , , , , , , , , , vBatch.CBT_IDBatch) 'vDescReceita.RecNum)
            'Next

            For Each vBatch In vListaBacthes
                Dim vDescReceita = (From it In vListaReceitas Where it.RecNum = vBatch.RecNum Select it).FirstOrDefault
                cmbReceitas.Items.Add("BatchID: " & vBatch.CPI_IDBlend & " - " & vDescReceita.RecNum & " - " & vDescReceita.RecNome & " (" & vDescReceita.RecDescr & ") - Cod " & vDescReceita.Codigo)
                listReceitas.Add(vDescReceita.RecNum, vDescReceita.RecDescr, vDescReceita.RecNome, vDescReceita.Codigo,
                       , , , , , , , , , , , , , , , , vBatch.CPI_IDBlend) 'vDescReceita.RecNum)
            Next

        Else
            Dim Qry As String = ""
            Dim txtCmb As String = ""

            'Le tabela de receitas e carrega na estrutura
            cmbReceitas.Items.Clear()

            Dim db As New Geral.nsReceitas.dcReceitas

            Dim teste = cmbDestTqs.SelectedValue

            Dim teste2 = (From it In db.tb_CBT_CadastroBatch Select it).ToList()


            listReceitas = New KbProdPlanejCtrl.clsListaDados


            Qry = "SELECT " &
                        "* " &
                    "FROM " &
                        "Rec " &
                    "WHERE " &
                        "Area = '" & AreaSelected & "' "

            If cmbPasta.Text <> "*" Then
                Qry = Qry &
                    "AND " &
                        "Pasta = '" & cmbPasta.Text & "' "
            End If

            If cmbSubpasta.Text <> "*" Then
                Qry = Qry &
                    "AND " &
                        "Subpasta = '" & cmbSubpasta.Text & "' "
            End If

            Qry = Qry &
                    "And Habilita > 0 ORDER BY " &
                        "RecNum"

            Try

                Dim Rc As New Geral.nsReceitas.dcReceitas
                Dim dtReceitas = Rc.ExecuteQuery(GetType(KbProdPlanejCtrl.clsRec), Qry)
                dtReceitasList = New List(Of KbProdPlanejCtrl.clsRec)(dtReceitas)

                For Each Dd In dtReceitasList
                    With Dd

                        'txtCmb = Right(.RecNum, 3)
                        txtCmb = Format(.RecNum, "000")
                        txtCmb = txtCmb & " - " & .RecNome & " (" & .RecDescr & ") - Cod " & .Codigo
                        cmbReceitas.Items.Add(txtCmb)
                        listReceitas.Add(.RecNum, .RecDescr, .RecNome, .Codigo,
                    , , , , , , , , , , , , , , , , .RecNum)

                    End With

                Next

            Catch ex As Exception
            End Try

        End If




    End Sub

    Private Sub cmbDestTqs_Click(sender As Object, e As EventArgs) Handles cmbDestTqs.Click
        cmbReceitas.Items.Clear()
    End Sub

    Private Sub cmbReceitas_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbReceitas.SelectedIndexChanged

        If TrataArea.AreaDados("Area") <> "Mistura" Then
            TamanhoBatch.Text = "0"
            If cmbReceitas.Text = "1006 - FLUSH DE AÇUCAR DILUIDO (FLUSH DE AÇUCAR DILUIDO ) - Cod 12560" Then
                TamanhoBatch.Text = "200"
            End If
        End If
        'MsgBox(cmbReceitas.Text)



    End Sub

    Private Sub chkListaAutomatica_CheckedChanged(sender As Object, e As EventArgs) Handles chkListaAutomatica.CheckedChanged
        If chkListaAutomatica.Checked = 0 Then
            cmbPasta.Enabled = True
            cmbSubpasta.Enabled = True
            cmdRelat.Enabled = True
            TamanhoBatch.Enabled = True
            cmbReceitas.Items.Clear()
            TamanhoBatch.Text = 0
            txtAlergenicos.Text = ""
        Else
            cmbPasta.Enabled = False
            cmbSubpasta.Enabled = False
            cmdRelat.Enabled = False
            TamanhoBatch.Enabled = False
            cmbReceitas.Items.Clear()
            TamanhoBatch.Text = 0
            txtAlergenicos.Text = ""

        End If
    End Sub

    Private Sub Label4_Click(sender As Object, e As EventArgs) Handles Label4.Click

    End Sub

    Private Sub btValidaRec_Click(sender As Object, e As EventArgs) Handles btValidaRec.Click
        Dim Rc() As String = cmbReceitas.Text.Split
        If Rc(0).Trim = "" Then Return
        Dim RecNum As Integer = Rc(0)

        Dim Dt() As String = cmbDestTqs.Text.Split
        If Dt(0).Trim = "" Then Return
        Dim DestTq As String = Strings.Right(Dt(0), 6)

        Dim Cmd As String = """" & Util.UtAppPath & "\..\Bin\KbImprimeReceita.exe"" " &
                    RecNum & " " &
                    "1000" & " " &
                    DestTq

        Try
            Shell(Cmd)
        Catch : End Try
    End Sub

    Private Sub Label2_Click(sender As Object, e As EventArgs) Handles Label2.Click

    End Sub


End Class

Class ReceitaAlergenicos

    Public RecNum As Integer = 0
    Public WordAlerg As String = String.Empty

    Public Sub New(RecNum As Integer, WordAlerg As String)

        Me.RecNum = RecNum
        Me.WordAlerg = WordAlerg

    End Sub

End Class