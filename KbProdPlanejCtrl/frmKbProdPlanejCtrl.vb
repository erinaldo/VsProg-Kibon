Public Class frmKbProdPlanejCtrl


    Public TrataArea As New Geral.clsTrataArea()
    Public listDestTqs As clsListaDados
    Public listReceitas As clsListaDados
    Dim dtReceitasList As List(Of clsRec)

    Public AreaSelected As String


    Sub RefreshPastas()

        cmbPasta.Items.Clear()
        cmbPasta.Items.Add("*")
        cmbPasta.Text = "*"

        cmbSubpasta.Items.Clear()
        cmbSubpasta.Items.Add("*")
        cmbSubpasta.Text = "*"

        'Condição txtDed.Text deve ser alimentada no OnLoad da Página
        Dim Rc As New Geral.nsReceitas.dcReceitas
        Dim dtPastas = (From It In Rc.Rec _
                        Where _
                            It.Area.ToUpper = AreaSelected.ToUpper _
                        Order By _
                            It.Pasta _
                        Select New With { _
                            It.Pasta _
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
        Dim dtSubPastas = (From It In Rc.Rec _
                           Where _
                               It.Area.ToUpper = AreaSelected.ToUpper _
                           And It.Pasta = cmbPasta.Text _
                           Order By _
                               It.Subpasta _
                           Select New With { _
                               It.Subpasta _
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

        listDestTqs = New clsListaDados

        Dim Rc As New Geral.nsReceitas.dcReceitas
        Dim dtDestTqs = (From It In Rc.DestTqs Where It.Area = AreaSelected Order By It.TqNome).ToList()

        For Conta As Integer = 0 To dtDestTqs.Count - 1
            With dtDestTqs(Conta)

                cmbDestTqs.Items.Add(.TqNome & " - " & .TqDescr)

                listDestTqs.Add(.TqNome, .TqDescr, _
                .EndStatus, .EndPlanejamento, .EndProduzido, _
                , , , , , , , , , , , , .EndAlergenico, .EndPressao01, .EndPressao02, .TqNome)

                If My.Application.CommandLineArgs.Count >= 2 Then
                    If My.Application.CommandLineArgs(1) = .TqNome Then IdxSel = Conta
                End If

            End With
        Next

        cmbDestTqs.SelectedIndex = IdxSel

    End Sub

    Sub LoadReceitas()

        Dim Qry As String = ""
        Dim txtCmb As String = ""

        'Le tabela de receitas e carrega na estrutura
        cmbReceitas.Items.Clear()

        listReceitas = New clsListaDados

        Qry = "SELECT " & _
                    "* " & _
                "FROM " & _
                    "Rec " & _
                "WHERE " & _
                    "Area = '" & AreaSelected & "' "

        If cmbPasta.Text <> "*" Then
            Qry = Qry & _
                "AND " & _
                    "Pasta = '" & cmbPasta.Text & "' "
        End If

        If cmbSubpasta.Text <> "*" Then
            Qry = Qry & _
                "AND " & _
                    "Subpasta = '" & cmbSubpasta.Text & "' "
        End If

        Qry = Qry & _
                "And Habilita > 0 ORDER BY " & _
                    "RecNum"

        Try

            Dim Rc As New Geral.nsReceitas.dcReceitas
            Dim dtReceitas = Rc.ExecuteQuery(GetType(clsRec), Qry)
            dtReceitasList = New List(Of clsRec)(dtReceitas)

            For Each Dd In dtReceitasList
                With Dd

                    'txtCmb = Right(.RecNum, 3)
                    txtCmb = Format(.RecNum, "000")
                    txtCmb = txtCmb & " - " & .RecNome & " (" & .RecDescr & ") - Cod " & .Codigo
                    cmbReceitas.Items.Add(txtCmb)
                    listReceitas.Add(.RecNum, .RecDescr, .RecNome, .Codigo, _
                , , , , , , , , , , , , , .RecNum)

                End With

            Next

        Catch ex As Exception
        End Try

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

    Function DadosTqSel(Optional ByRef outTqNome As String = "", Optional ByRef outTqDescr As String = "", _
                        Optional ByRef outEndStatus As String = "", Optional ByRef outEndPlanejamento As String = "", _
                        Optional ByRef outEndProduzido As String = "") As Boolean


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

    Private Sub frmProdPlanej_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        'Lê o arquivo CfgGeral.xml
        Geral.basTrataDados.DllInit()

        If My.Application.CommandLineArgs.Count < 1 Then
            AreaSelected = "Mistura"
            'MsgBox("Falha na ativação do programa. Passe como parametro a área das receitas", MsgBoxStyle.Exclamation)
            'Me.Close()

        Else
            AreaSelected = My.Application.CommandLineArgs(0)
        End If


        Try

            TrataArea.AreaLe(AreaSelected)

            'Monta a Lista de tanques destino
            LoadTqs()

            RefreshPastas()

            LoadReceitas()

            'Atualiza a StatusStrip
            labelStrip1.Text = TrataArea.AreaDados("Descr")
            labelStrip2.Text = TrataArea.AreaDados("Area")
        Catch : End Try


        'Inicia o serviço web
        Planej = New clsPlanej
        Planej.Iniciar()


        TmrPula.Enabled = True
        tmrRefresh.Enabled = True

    End Sub

    Private Sub frmKbProdPlanejCtrl_FormClosing(sender As Object, e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing

        tmrRefresh.Enabled = False

        Planej.Parar()
        Planej = Nothing

    End Sub

    Private Sub cmbPasta_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmbPasta.SelectedIndexChanged
        RefreshSubpastas()
        LoadReceitas()
    End Sub

    Private Sub cmbSubpasta_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmbSubpasta.SelectedIndexChanged
        LoadReceitas()
    End Sub

    Private Sub mnuAjuda_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuAjuda.Click

        Dim Cmd As String = ""

        'Chama arquivo de help
        Cmd = "Winhlp32 " & Util.UtAppPath & "\Help\frmProdPlanej.HLP"
        Shell(Cmd)

    End Sub

    Private Sub mnuSobre_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuSobre.Click
        frmAbout.Show()
    End Sub

    Private Sub mnuSair_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuSair.Click
        Close()
    End Sub

    Private Sub mnuPlcLe_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuPlcLe.Click

        Dim Pos As Integer = 0

        If cmbDestTqs.Text <> "" Then

            'Posição do Tanque no ComboBox
            Dim Msg As String = ""
            Dim Alerg As String = ""

            Pos = cmbDestTqs.SelectedIndex + 1
            Dim PlcLeReceitas As New clsPlcLeReceitas(AreaSelected, listDestTqs.Item(Pos).Dado0, listDestTqs.Item(Pos).Dado1, listDestTqs.Item(Pos).Dado2, listDestTqs.Item(Pos).Dado3)
            Dim lstResultadoLido = PlcLeReceitas.PlcLeDados(Msg, Alerg)

            If Not IsNothing(lstResultadoLido) Then

                TamanhoBatch.Text = lstResultadoLido.tamanhoBatch
                TotalProduzir.Text = lstResultadoLido.totalProd

                'Busca a receita selecionada
                Dim RecNum As String = lstResultadoLido.RecNum
                For Conta As Integer = 0 To cmbReceitas.Items.Count - 1

                    Try

                        Dim TRecNum() As String = cmbReceitas.Items(Conta).ToString.Split(" ")

                        Dim TRn As Integer = TRecNum(0)
                        If TRn = RecNum Then
                            cmbReceitas.SelectedIndex = Conta
                        End If

                    Catch
                    End Try
                Next

            End If

            MsgBox(Msg)

        End If

    End Sub

    Private Sub mnuPlcEnvia_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuPlcEnvia.Click

        Dim Pos As Integer = 0
        Dim RecNum As Integer = 0
        Dim RecNome As String = ""
        Dim RecDescr As String = ""
        Dim Codigo As Integer = 0

        If cmbReceitas.Text <> "" Then

            Dim txt As String = cmbReceitas.Text
            Dim txtReceita As Array = txt.Split("-")

            RecNum = Val(txtReceita(0))

            Dim txtRecNomeDescr As Array = txtReceita(1).Split("(")

            RecNome = txtRecNomeDescr(0)

            Dim txtRecCod As Array = txtReceita(2).Split(" ")

            Codigo = Val(txtRecCod(2))

            Pos = cmbDestTqs.SelectedIndex + 1

            Dim Msg As String = ""
            Dim PlcEnviaReceita As New clsPlcEnviaReceitas("", 0, "", 0, AreaSelected, "", 0, listDestTqs.Item(Pos).Dado2, listDestTqs.Item(Pos).Dado3, RecNum, RecNome, Codigo)
            Dim ResultadoEnviado = PlcEnviaReceita.PlcEnviaDados(TamanhoBatch.Text, TotalProduzir.Text, Msg)

            MsgBox(Msg)

        Else

            MsgBox("Selecione a Receita a ser Enviada !")
            cmbReceitas.Focus()

        End If

    End Sub

    Private Sub ButSair_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButSair.Click
        mnuSair_Click(sender, e)
    End Sub

    Private Sub ButAjuda_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButAjuda.Click
        mnuAjuda_Click(sender, e)
    End Sub

    Private Sub ButLe_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButLe.Click

        mnuPlcLe_Click(sender, e)

    End Sub

    Private Sub ButEnvia_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButEnvia.Click

        mnuPlcEnvia_Click(sender, e)

    End Sub

    Private Sub TmrPula_Tick(ByVal sender As Object, ByVal e As System.EventArgs) Handles TmrPula.Tick

        TmrPula.Enabled = False

        Me.WindowState = FormWindowState.Minimized
        Me.WindowState = FormWindowState.Normal

    End Sub

    '' Relatório para o operador preencher todas as informaçoes
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


    ''Relatório após batch finalizado, informaçoes dos ingredientes preenchidas. LOTE, DATA VALIDADE, 
    Private Sub cmdRelatPreench_Click(sender As Object, e As EventArgs) Handles cmdRelatPreench.Click

        Dim Rc() As String = cmbReceitas.Text.Split
        If Rc(0).Trim = "" Then Return
        Dim RecNum As Integer = Rc(0)

        Dim Dt() As String = cmbDestTqs.Text.Split
        If Dt(0).Trim = "" Then Return
        Dim DestTq As String = Strings.Right(Dt(0), 6)

        'Dim selecionaReceita As New frmSelecionaReceitaRelat
        'selecionaReceita.Abre(RecNum, TamanhoBatch.Text, DestTq)
        'selecionaReceita.ShowDialog()
        frmSelecionaReceitaRelat.Abre(RecNum, TamanhoBatch.Text, DestTq)
        frmSelecionaReceitaRelat.ShowDialog()



    End Sub

    Private Sub tmrRefresh_Tick(sender As System.Object, e As System.EventArgs) Handles tmrRefresh.Tick

        txtContaD.Text = PlanejD.ContaD

    End Sub


End Class
