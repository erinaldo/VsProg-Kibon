Public Class frmRecEdit

    Dim AcessoUsuario As Integer = 0

    Public Sub UsrLogin(Optional ByVal UsrId As Integer = 0, Optional ByVal UsrNome As String = "")

        tsbFileNew.Enabled = True
        tsbFileSave.Enabled = True
        tsbFileDuplicar.Enabled = True
        tsbFileDelete.Enabled = True
        tsbIngr.Enabled = True
        tsbIngrMat.Enabled = True
        tsbAlerg.Enabled = True

        butItemNovo.Enabled = True
        butBlocoRemove.Enabled = True
        butUp.Enabled = True
        butDown.Enabled = True

        mnuArqNovo.Enabled = True
        mnuArqSalvar.Enabled = True
        mnuArqDuplicar.Enabled = True
        mnuArqExcluir.Enabled = True
        mnuBlocoInsere.Enabled = True
        mnuBlocoRemoveBloco.Enabled = True
        mnuBlocoIngredMan.Enabled = True
        mnuBlocoIngredMat.Enabled = True
        mnuAlergenicos.Enabled = True
        ckbHab.Enabled = True

        mnuBloco.Enabled = True
        mnuConfig.Enabled = True

        grdParam.Columns(2).ReadOnly = False
        grdParam.Columns(4).ReadOnly = False

        tsbLogin.Text = "Logout"
        mnuLogin.Text = "Logout"

        tslUsr.Tag = UsrId
        tslUsr.Text = UsrNome

    End Sub

    Public Sub UsrLogout()

        tsbFileNew.Enabled = False
        tsbFileSave.Enabled = False
        tsbFileDuplicar.Enabled = False
        tsbFileDelete.Enabled = False
        tsbIngr.Enabled = False
        tsbIngrMat.Enabled = False
        tsbAlerg.Enabled = false

        butItemNovo.Enabled = False
        butBlocoRemove.Enabled = False
        butUp.Enabled = False
        butDown.Enabled = False

        mnuArqNovo.Enabled = False
        mnuArqSalvar.Enabled = False
        mnuArqDuplicar.Enabled = False
        mnuArqExcluir.Enabled = False
        mnuBlocoInsere.Enabled = False
        mnuBlocoRemoveBloco.Enabled = False
        mnuBlocoIngredMan.Enabled = False
        mnuBlocoIngredMat.Enabled = False
        mnuAlergenicos.Enabled = False
        ckbHab.Enabled = False

        mnuBloco.Enabled = False
        mnuConfig.Enabled = False

        grdParam.Columns(2).ReadOnly = True
        grdParam.Columns(4).ReadOnly = True

        tsbLogin.Text = "Login"
        mnuLogin.Text = "Login"

        tslUsr.Text = ""

    End Sub

    Public Sub RefreshReceita()

        If Rc Is Nothing Then Return

        'Dim UsrNome As String = "..."
        'Dim taCadUsuarios As New Geral.dcReceitaTableAdapters.taxCadUser
        'Dim dtCadUsuarios As New Geral.dcReceita.CadUserDataTable

        If Rc.RecNum > 0 Then
            txtReceitaNum.Text = Rc.RecNum
        Else
            txtReceitaNum.Text = ""
        End If

        txtReceitaNome.Text = Rc.RecNome
        txtReceitaCod.Text = Rc.Codigo
        txtReceitaDescr.Text = Rc.RecDescr
        txtPesoReferencia.Text = Rc.PesoRefer
        txtDensidade.Text = Rc.Densidade
        txtPasta.Text = Rc.Pasta
        txtSubpasta.Text = Rc.Subpasta
        txtPressao01.Text = Rc.Pressao01
        txtPressao02.Text = Rc.Pressao02
        If Rc.Habilitada > 0 Then
            ckbHab.Checked = True
        Else
            ckbHab.Checked = False
        End If

        '****** IVAN - Santização **********
        If Rc.Densidade > 0 And Rc.Densidade <= 3 Then
            cmbTipoCip.SelectedIndex = Rc.Densidade
        Else
            cmbTipoCip.SelectedIndex = 0
        End If

        'Busca o nome do usuario
        'taCadUsuarios.FillUserId(dtCadUsuarios, rc.UltAlteracaoUsrId)
        'If dtCadUsuarios.Rows.Count > 0 Then UsrNome = dtCadUsuarios(0).Nome
        'lblUltAlteracao.Text = "Ultima alteração por " & UsrNome & " em " & Format(rc.UltAlteracaoData, "dd/MM/yyyy HH:mm:ss")

        RefreshBlocos(0)
        RefreshParam(0)

    End Sub

    Public Sub RefreshBlocos(Optional ByVal BlkPosSel As Integer = 0)

        Dim TopRow As Integer = grdBlocos.FirstDisplayedScrollingRowIndex
        grdBlocos.Rows.Clear()

        If Rc Is Nothing Then Return
        If Rc.RecNum <= 0 Then Return

        Try
            If Rc.Blocos.Count <= 0 Then Return
        Catch
            Return
        End Try

        For Conta As Integer = 0 To Rc.Blocos.Count - 1
            grdBlocos.Rows.Add()
            grdBlocos.Rows(Conta).Cells(0).Value = Format(Rc.Blocos(Conta).BlkNum, "000")
            grdBlocos.Rows(Conta).Cells(2).Value = Rc.Blocos(Conta).BlkDescr

            'Carrega imagem do bloco
            'Dim ImagemNome As String = Util.UtAppPath & _
            '            "\..\Bin\Bmp\" & AreaDados("Area") & "_Blk" & Microsoft.VisualBasic.Right("000" & Rc.Blocos(Conta).BlkNum, 3) & ".png"

            'Try
            '    Le imagem do arquivo do bloco Ex: ..\Bmp\Blk001.png
            '    grdBlocos.Rows(Conta).Cells(1).Value = New Bitmap(ImagemNome)
            'Catch
            'Arquivo do bloco nao encontrado, carrega imagem default
            grdBlocos.Rows(Conta).Cells(1).Value = ilBlks.Images(0)
            'End Try

        Next

        ''Refresh Rcs
        ''If chkRc.Checked = True Then RefreshRc()


        If (BlkPosSel > 0) And (BlkPosSel < grdBlocos.Rows.Count) Then
            grdBlocos.ClearSelection()
            grdBlocos.Rows(BlkPosSel).Selected = True
        End If

        Try
            grdBlocos.FirstDisplayedScrollingRowIndex = TopRow
        Catch : End Try

    End Sub

    Private Sub RefreshRc()

        'Try

        '    Dim MyRcs() As Geral.dcReceita.CadRcRow = dtCadRc.Select("Subarea = '" & cmbSubareas.Text & "'", "Rc")

        '    'Loop para cada coluna de Rc
        '    For ContaRc As Integer = 0 To MyRcs.Length - 1

        '        Dim Sts As Boolean = False

        '        With rc.Subareas(cmbSubareas.SelectedIndex)

        '            'Loop para cada linha
        '            For ContaRow As Integer = 0 To .lstBlks.Count - 1

        '                'Caso seja o bloco de inicio da Rc liga o Status
        '                If .lstBlks(ContaRow).BlkNum = MyRcs(ContaRc).BlkLiga Then Sts = True


        '                If Sts = True Then

        '                    'Carrega imagem da Rc
        '                    Dim ImagemNome As String = Util.UtAppPath & _
        '                                "\..\Bin\Bmp\" & AreaDados("Area") & "_Rc" & Microsoft.VisualBasic.Right("000" & MyRcs(ContaRc).Rc, 3) & ".png"

        '                    Try
        '                        'Le imagem do arquivo do bloco Ex: ..\Bmp\Blk001.png
        '                        grdBlocos.Rows(ContaRow).Cells(ContaRc + 3).ToolTipText = MyRcs(ContaRc).Descr
        '                        grdBlocos.Rows(ContaRow).Cells(ContaRc + 3).Value = New Bitmap(ImagemNome)
        '                    Catch
        '                        'Arquivo do bloco nao encontrado, carrega imagem default
        '                        grdBlocos.Rows(ContaRow).Cells(ContaRc + 3).Value = ilBlks.Images(0)
        '                    End Try
        '                Else
        '                    'Sem imagem
        '                    grdBlocos.Rows(ContaRow).Cells(ContaRc + 3).ToolTipText = ""
        '                    grdBlocos.Rows(ContaRow).Cells(ContaRc + 3).Value = ilBlks.Images(1)
        '                End If


        '                'Caso seja o bloco de fim da Rc desliga o Status
        '                If .lstBlks(ContaRow).BlkNum = MyRcs(ContaRc).BlkDesl Then Sts = False

        '            Next

        '        End With
        '    Next

        'Catch
        'End Try

    End Sub

    Private Sub RefreshParam(ByVal Idx As Integer)

        grdParam.Rows.Clear()
        If Rc Is Nothing Then Return
        If Rc.RecNum <= 0 Then Return

        Try
            If Rc.Blocos.Count <= 0 Then Return
        Catch
            Return
        End Try

        With Rc.Blocos(Idx)

            For Conta As Integer = 0 To .Param.Count - 1

                grdParam.Rows.Add()
                grdParam.Rows(Conta).Cells(0).Value = Conta
                grdParam.Rows(Conta).Cells(1).Value = .Param(Conta).ItemDescr
                grdParam.Rows(Conta).Cells(2).Value = .Param(Conta).Valor
                grdParam.Rows(Conta).Cells(3).Value = .Param(Conta).UEng

                If .Param(Conta).FlagPeso = 1 And txtPesoReferencia.Text <> "" And TrataArea.AreaDados("UsaPesoRef") = "1" Then

                    Dim Peso As Double = txtPesoReferencia.Text * .Param(Conta).Valor / 100.0

                    grdParam.Rows(Conta).Cells(4).Value = Format(Peso, "0.00")

                End If

            Next

        End With

    End Sub

    Private Function BuscaMaxRecNum() As Integer

        Dim RecIdNova As Integer = 1

        Dim myDb As New Geral.nsReceitas.dcReceitas

        Dim myArea As String = TrataArea.AreaDados("Area")

        Dim myMax As Integer = 0

        Try
            myMax = (From It In myDb.Rec Where It.Area = myArea Select It.RecNum).Max
        Catch : End Try

        Try
            RecIdNova = myMax + 1
        Catch : End Try

        BuscaMaxRecNum = RecIdNova

    End Function

    Public Function ConfSalvarDados() As MsgBoxResult

        If FlagDadosEdit = False Then Return MsgBoxResult.Ok

        Dim Ret As MsgBoxResult = MsgBox("Atenção: Os dados não salvos serão perdidos! " & vbCr & _
                         "Você quer SALVAR os dados editados?", MsgBoxStyle.YesNoCancel + MsgBoxStyle.Question, "Editor de receitas")

        'Salvar dados
        If Ret = MsgBoxResult.Yes Then
            SalvaReceita()
        Else

            'EXCLUIR ALERGENICOS DA RECEITA
            'ExcluirAlerg()

        End If

        'Reseta o flag
        If Ret = MsgBoxResult.Yes Or Ret = MsgBoxResult.No Then

            FlagDadosEdit = False
            SalvaBloq()

        End If

        Return Ret

    End Function

    Function SalvaReceita() As Boolean

        If Trim(txtReceitaNome.Text) = "" Then
            MsgBox("Erro: o nome da receita é inválido.", MsgBoxStyle.Critical, "Editor de Receita")
            Return False
        End If

        If Trim(txtReceitaCod.Text) = "" Then
            MsgBox("Erro: o codigo da receita é inválido.", MsgBoxStyle.Critical, "Editor de Receita")
            Return False
        End If

        If Rc Is Nothing Then
            MsgBox("Erro: Selecione a função 'Nova Receita' antes de entrar com novos dados.", MsgBoxStyle.Critical, "Editor de Receita")
            Return False
        End If

        If IsNumeric(txtReceitaNum.Text) = False Then

            MsgBox("Erro: digite o número da receita.", MsgBoxStyle.Critical, "Editor de Receita")
            Return False

        End If

        'If IsNumeric(txtReceitaCod.Text) = False Then

        '    MsgBox("Erro: o codigo da receita deve ser numérico", MsgBoxStyle.Critical, "Editor de Receita")
        '    Return False

        'End If

        If txtPesoReferencia.Visible = True Then

            If Trim(txtPesoReferencia.Text) = "" Then
                MsgBox("Erro: peso de referência da receita é inválido", MsgBoxStyle.Critical, "Editor de Receita")
                Return False
            End If

            If IsNumeric(txtPesoReferencia.Text) = False Then

                MsgBox("Erro: o peso de referência da receita deve ser numérico", MsgBoxStyle.Critical, "Editor de Receita")
                Return False

            End If
        End If

        If txtDensidade.Visible = True Then

            If Trim(txtDensidade.Text) = "" Then
                MsgBox("Erro: a densidade da receita é inválida", MsgBoxStyle.Critical, "Editor de Receita")
                Return False
            End If

            If IsNumeric(txtDensidade.Text) = False Then

                MsgBox("Erro: a densidade da receita deve ser numérico", MsgBoxStyle.Critical, "Editor de Receita")
                Return False

            End If
        End If


        If Trim(txtPressao01.Text) = "" Then
            MsgBox("Erro: a pressão 01 da receita é inválida", MsgBoxStyle.Critical, "Editor de Receita")
            Return False
        End If

        If IsNumeric(txtPressao01.Text) = False Then

            MsgBox("Erro: a pressão 01 da receita é inválida", MsgBoxStyle.Critical, "Editor de Receita")
            Return False

        End If

        If Trim(txtPressao02.Text) = "" Then
            MsgBox("Erro: a pressão 02 da receita é inválida", MsgBoxStyle.Critical, "Editor de Receita")
            Return False
        End If

        If IsNumeric(txtPressao02.Text) = False Then

            MsgBox("Erro: a pressão 02 da receita é inválida", MsgBoxStyle.Critical, "Editor de Receita")
            Return False

        End If

        Dim Soma As Double = Rc.SomaQtd

        Dim LimitePeso As Boolean = Rc.ComparaDouble(Soma)

        Dim Ret As MsgBoxResult

        If LimitePeso = False Then
            Ret = MsgBox("ATENÇÂO: A soma total das porcentagens da receita não é 100%." & vbCr & _
                            "Soma total dos ingredientes = " & Format(Soma, "#.00") & "%" & vbCr & _
                            "Deseja Gravar a receita mesmo assim?", MsgBoxStyle.Question + MsgBoxStyle.YesNo, "Editor de Receita")
        Else
            Ret = MsgBox("Soma total dos ingredientes = " & Format(Soma, "#.00") & "% esta dentro dos limites aceitáveis!" & vbCr & _
                           "Deseja continuar e Gravar a receita?", MsgBoxStyle.Question + MsgBoxStyle.YesNo, "Editor de Receita")
        End If

        If Ret = MsgBoxResult.No Then Return False

        Rc.RecNome = txtReceitaNome.Text
        Rc.Codigo = txtReceitaCod.Text
        Rc.RecDescr = txtReceitaDescr.Text
        Rc.PesoRefer = txtPesoReferencia.Text
        Rc.Densidade = txtDensidade.Text
        Rc.Pasta = txtPasta.Text
        Rc.Subpasta = txtSubpasta.Text
        Rc.Pressao01 = txtPressao01.Text
        Rc.Pressao02 = txtPressao02.Text
        If ckbHab.Checked = True Then
            Rc.Habilitada = 1
        Else
            Rc.Habilitada = 0
        End If

        '********* IVAN - Sanitização ***********
        Rc.Densidade = cmbTipoCip.SelectedIndex

        Rc.Salvar()

        Return True

    End Function

    Private Sub EdicaoBloqueia()

        tsbFileDelete.Enabled = False
        tsbFileDuplicar.Enabled = False

        mnuArqDuplicar.Enabled = False
        mnuArqExcluir.Enabled = False

        mnuBlocoInsere.Enabled = False
        mnuBlocoRemoveBloco.Enabled = False

        butDown.Enabled = False
        butUp.Enabled = False
        butItemNovo.Enabled = False
        butBlocoRemove.Enabled = False

    End Sub

    Private Sub EdicaoHabilita()

        If AcessoUsuario = 1 Then
            tsbFileDelete.Enabled = True
            tsbFileDuplicar.Enabled = True

            mnuArqDuplicar.Enabled = True
            mnuArqExcluir.Enabled = True

            mnuBlocoInsere.Enabled = True
            mnuBlocoRemoveBloco.Enabled = True

            butDown.Enabled = True
            butUp.Enabled = True
            butItemNovo.Enabled = True
            butBlocoRemove.Enabled = True
        End If

    End Sub

    Private Sub SalvaBloq()

        'mnuArqSalvar.Enabled = False
        'tsbFileSave.Enabled = False

    End Sub

    Private Sub SalvaHab()

        'If AcessoUsuario = 1 Then

        '    tsbFileSave.Enabled = True
        '    mnuArqSalvar.Enabled = True
        'End If

    End Sub

    Private Sub TravaUsuarioComum()

        mnuConfig.Enabled = False
        mnuBloco.Enabled = False

        mnuArqNovo.Enabled = False
        tsbFileNew.Enabled = False

        EdicaoBloqueia()
        SalvaBloq()

        txtPasta.ReadOnly = True
        txtSubpasta.ReadOnly = True
        txtReceitaCod.ReadOnly = True
        txtReceitaDescr.ReadOnly = True
        txtReceitaNome.ReadOnly = True
        txtPesoReferencia.ReadOnly = True
        txtDensidade.ReadOnly = True

        txtPressao01.ReadOnly = True
        txtPressao02.ReadOnly = True

        grdParam.Enabled = False

    End Sub

    Private Sub frmRecEdit_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        'Verifica se a data das configurações regionais está configurada como d/M/yyyy
        Dim RetDataConf As Boolean = Util.ChkDataConfReg(Me.Text)
        If RetDataConf = False Then End

        Geral.DllInit()

        Dim arCmd() As String = Command.Split

        TrataArea = New Geral.clsTrataArea

        'se não passar parametro de area, assume CIP como padrao
        If arCmd(0) = "" Then
            TrataArea.AreaLe("CIP")
        Else
            Try
                TrataArea.AreaLe(arCmd(0))
            Catch
                Me.Close()
            End Try
        End If

        'If arCmd.Length = 1 Then

        '    'não passou o nivel de acesso do usuario
        '    AcessoUsuario = 0
        '    UsrLogout()

        'ElseIf arCmd.Length = 2 Then

        '    If arCmd(1) = "" Or arCmd(1) = "0" Then
        '        AcessoUsuario = 0
        '        UsrLogout()
        '    ElseIf arCmd(1) = "1" Then
        '        AcessoUsuario = 1
        '        UsrLogin()
        '    End If

        'End If
        UsrLogout()

        If TrataArea.AreaDados.Count <= 0 Then End

        'Desabilita botoes de ingredientes manuais
        If TrataArea.AreaDados("UsaIngredMan") <> "1" Then
            mnuBlocoIngredMan.Enabled = False
        End If


        '******* IVAN - Santização ***********
        'Caso seja uma receita sem peso (CIP)
        If TrataArea.AreaDados("UsaPesoRef") <> "1" Then

            'Desabilita uso de peso de referencia
            txtPesoReferencia.Visible = False
            lblPesoRef.Visible = False

            'Muda texto de Densidade para Tipo de CIP
            lblDensidadeCip.Text = "Tipo de CIP"
            txtDensidade.Visible = 0

            'Exibe combobox de densidade como tipo de CIP
            cmbTipoCip.Visible = 1

            Dim tipoCip() As String = {"", "Enxague", "Sanitização", "CIP"}
            cmbTipoCip.DataSource = tipoCip
            cmbTipoCip.SelectedIndex = 0

            'Desabilita uso de presões do Homo
            Label8.Visible = 0
            Label9.Visible = 0
            txtPressao01.Visible = 0
            txtPressao02.Visible = 0


        End If



        'Mostra area no Status Bar
        tslAreaDescr.Text = TrataArea.AreaDados("Descr")

        lblUltAlteracao.Text = "Ver.: 2016.08"

        tmrInicio.Enabled = True

    End Sub

    Private Sub frmRecEdit_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing

        Dim Ret As MsgBoxResult = ConfSalvarDados()
        If Ret = MsgBoxResult.Cancel Then e.Cancel = True

    End Sub

    Private Sub frmMain_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
        'Codigo 224 é enviado para fazer logout
        If e.KeyValue = 224 Then UsrLogout()
    End Sub

    Private Sub tsbSair_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tsbSair.Click
        Me.Close()
    End Sub

    Private Sub tsbFileNew_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tsbFileNew.Click

        Dim RetConf As MsgBoxResult = ConfSalvarDados()
        If RetConf = MsgBoxResult.Cancel Then Exit Sub

        Dim RecIdNova As Integer = BuscaMaxRecNum()

        Dim Ret As String = InputBox("Digite o número da nova receita ", "Nova receita - Área " & TrataArea.AreaDados("Area"), RecIdNova)
        If Ret = "" Then Exit Sub

        Rc = New clsReceita(TrataArea.AreaDados("Area"), CLng(Ret))

        Rc.Area = TrataArea.AreaDados("Area")
        Rc.RecNum = CLng(Ret)

        RefreshReceita()

        EdicaoHabilita()

    End Sub

    Private Sub tsbFileOpen_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tsbFileOpen.Click

        Dim Ret As MsgBoxResult = ConfSalvarDados()
        If Ret = MsgBoxResult.Cancel Then Return

        Dim MyArea As String = ""
        Try
            MyArea = TrataArea.AreaDados("Area")
        Catch : End Try

        If MyArea = "" Then
            MsgBox("Erro: selecione a área antes de abrir a receita", MsgBoxStyle.Exclamation, "Editor de Receita")
            Return
        End If

        'abre form para selecionar a receita
        Dim Frm As New Geral.frmSelRec
        Frm.Abre(MyArea)

        'traz o numero da receita selecionada
        Dim RecNum As Integer = Frm.SelRecNum

        If RecNum <= 0 Then Return

        'monta os dados da receita escolhida em memoria
        Rc = New clsReceita
        Rc.Abre(MyArea, RecNum)

        'atualiza dados da receita na janela principal
        RefreshReceita()

        EdicaoHabilita()

        CarregaAlergenicos()

    End Sub

    Private Sub CarregaAlergenicos()

        Dim DbAlerg = New Geral.nsReceitas.dcReceitas

        Dim vArea As String = TrataArea.AreaDados("Area")
        Dim vRecNum As Integer = Convert.ToInt32(txtReceitaNum.Text)
        Dim vReceitaCod As String = txtReceitaCod.Text
        Dim wordAlerg As String = String.Empty

        Dim dtAlergRec = (From It In DbAlerg.AlergenicosRec Where It.Area = vArea And It.RecNum = vRecNum).ToList

        gvAlergRecPrincipal.Rows.Clear()

        'CARREGA ALERGÊNICOS DA RECEITA
        For Each Alerg In dtAlergRec
            Dim dtAlerg = (From It In DbAlerg.Alergenico Where It.CodAlergenico = Alerg.CodAlergenico).ToList
            If dtAlerg.Count = 1 Then
                gvAlergRecPrincipal.Rows.Add(ImageListAleg.Images(0), dtAlerg.First.Nome, dtAlerg.First.Letra)
                wordAlerg = wordAlerg & Trim(dtAlerg.First.Letra)
            Else
                gvAlergRecPrincipal.Rows.Add(ImageListAleg.Images(0), "Inconsistente", "Inconsistente")
            End If

        Next

        txtWordAlerg.Text = wordAlerg

    End Sub

    Private Sub tsbFileSave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tsbFileSave.Click

        Dim Ret As Boolean = SalvaReceita()
        If Ret = False Then Return
        RefreshReceita()
        FlagDadosEdit = False
        SalvaBloq()

    End Sub

    Private Sub tsbFileDuplicar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tsbFileDuplicar.Click

        Dim RecIdNova As Integer = BuscaMaxRecNum()

        Dim RecNum As String = InputBox("Digite o número da nova receita ", "Nova receita - Área " & TrataArea.AreaDados("Area"), RecIdNova)
        If RecNum = "" Or IsNumeric(RecNum) = False Then Return

        Dim Ret As Boolean = Rc.Duplicar(CLng(RecNum), True)

        If Ret = True Then

            Rc.RecNum = CLng(RecNum)
            txtReceitaNum.Text = CLng(RecNum)
            RefreshReceita()
            FlagDadosEdit = True
            SalvaHab()

        End If

    End Sub

    Private Sub tsbFileDelete_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tsbFileDelete.Click

        If txtReceitaNum.Text = "" Then Return

        Dim Msg As MsgBoxResult = MsgBox("Atenção: A receita " & txtReceitaNum.Text & " será apagada!" & vbCr & _
                                         "Deseja realmente apagar esta Receita?", MsgBoxStyle.YesNo + MsgBoxStyle.Question, "Editor de Receita")

        If Msg <> MsgBoxResult.Yes Then Return

        Dim Ret As Boolean = Rc.Deletar()
        If Ret <> True Then Return

        ExcluirAlerg()
       
        Rc = New clsReceita

        RefreshReceita()

        txtReceitaNum.Text = ""

        FlagDadosEdit = False
        SalvaBloq()

    End Sub

    Sub ExcluirAlerg()

        Dim vArea As String = TrataArea.AreaDados("Area")
        Dim vRecNum As Integer = Convert.ToInt32(txtReceitaNum.Text)
        Dim DbRc = New Geral.nsReceitas.dcReceitas
        Dim dtReceitaAlerg = (From It In DbRc.AlergenicosRec Where It.Area = vArea And It.RecNum = vRecNum).ToList
        'EXCLUI REGISTROS
        DbRc.AlergenicosRec.DeleteAllOnSubmit(dtReceitaAlerg)
        DbRc.SubmitChanges()
        CarregaAlergenicos()

    End Sub

    Private Sub tsbLogin_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tsbLogin.Click

        'Logout
        If tslUsr.Text <> "" Then

            'Verifica se ha dados editados antes de fazer logout
            Dim Ret As MsgBoxResult = ConfSalvarDados()
            If Ret = MsgBoxResult.Cancel Then Exit Sub

            UsrLogout()
            Return

        End If


        'Login
        Dim MyForm As New Geral.frmLogin
        MyForm.ShowDialog()
        If MyForm.SelUsrId = 0 Then Exit Sub

        UsrLogin(MyForm.SelUsrId, MyForm.SelUsrNome)

    End Sub

    Private Sub tsbAreaSel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tsbAreaSel.Click

        'Dim RetConf As MsgBoxResult = ConfSalvarDados()
        'If RetConf = MsgBoxResult.Cancel Then Exit Sub

        'Dim MyForm As New Geral.frmAreaSel
        'MyForm.Abre()
        'If MyForm.SelArea = "" Then Exit Sub

        'tsbAreaSel.Text = MyForm.SelArea
        'LeArea(MyForm.SelArea)

        'Rc = New Geral.clsRc
        'Rc.Area = AreaDados("Area")
        'RefreshReceita()

    End Sub

    Private Sub tsbRelat_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tsbRelat.Click

        Dim Cmd As String = Util.UtAppPath & "\..\Bin\KbRecRelat.exe " & TrataArea.AreaDados("Area")

        Try
            Shell(Cmd, AppWinStyle.NormalFocus)
        Catch ex As Exception

        End Try

    End Sub

    Private Sub butItemNovo_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles butItemNovo.Click

        If txtReceitaNum.Text = "" Then Return

        frmSelBloco.Abre(TrataArea.AreaDados("Area"))

        Dim BlocoIdxSel As Integer = frmSelBloco.BlkSel

        If IsNumeric(BlocoIdxSel) = True And BlocoIdxSel > 0 Then

            Rc.IncluirBloco(BlocoIdxSel)

            FlagDadosEdit = True
            SalvaHab()

        End If

        RefreshBlocos()

    End Sub

    Private Sub butBlocoRemove_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles butBlocoRemove.Click

        If grdBlocos.SelectedRows.Count <= 0 Then Return

        Dim Pos As Integer = grdBlocos.SelectedRows(0).Index
        Rc.Blocos.RemoveAt(Pos)
        RefreshBlocos(Pos)

        FlagDadosEdit = True
        SalvaHab()

    End Sub

    Private Sub butUp_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles butUp.Click

        If grdBlocos.SelectedRows.Count <= 0 Then Return
        If grdBlocos.SelectedRows(0).Index < 1 Then Return
        Dim Pos As Integer = grdBlocos.SelectedRows(0).Index

        Dim MyBlk As clsRcBlk = Rc.Blocos(Pos)

        Rc.Blocos.RemoveAt(Pos)

        Rc.Blocos.Insert(Pos - 1, MyBlk)

        RefreshBlocos(Pos - 1)

        FlagDadosEdit = True
        SalvaHab()

    End Sub

    Private Sub butDown_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles butDown.Click

        If grdBlocos.SelectedRows.Count <= 0 Then Exit Sub
        If grdBlocos.SelectedRows(0).Index >= grdBlocos.Rows.Count - 1 Then Exit Sub
        Dim Pos As Integer = grdBlocos.SelectedRows(0).Index

        Dim MyBlk As clsRcBlk = Rc.Blocos(Pos)

        Rc.Blocos.RemoveAt(Pos)

        Rc.Blocos.Insert(Pos + 1, MyBlk)

        RefreshBlocos(Pos + 1)

        FlagDadosEdit = True
        SalvaHab()

    End Sub

    Private Sub grdBlocos_RowStateChanged(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewRowStateChangedEventArgs) Handles grdBlocos.RowStateChanged

        'Trata somente a row selecionada
        If e.Row.Selected = False Then Return

        If txtReceitaNum.Text = "" Then Return
        RefreshParam(e.Row.Index)

    End Sub

    Private Sub grdParam_CellEndEdit(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles grdParam.CellEndEdit

        If e.ColumnIndex = 2 Then

            If IsNumeric(grdParam.Rows(e.RowIndex).Cells(2).Value) = False Then Return

            With Rc.Blocos(grdBlocos.SelectedRows(0).Index)

                'Guarda o valor digitado
                .Param(e.RowIndex).Valor = grdParam.Rows(e.RowIndex).Cells(2).Value

                If .Param(e.RowIndex).FlagPeso = 1 And txtPesoReferencia.Text <> "" And TrataArea.AreaDados("UsaPesoRef") = "1" Then

                    Dim Peso As Double = txtPesoReferencia.Text * .Param(e.RowIndex).Valor / 100.0

                    grdParam.Rows(e.RowIndex).Cells(4).Value = Format(Peso, "0.00")

                End If

            End With

            FlagDadosEdit = True
            SalvaHab()

        End If

    End Sub

    Private Sub txtPesoReferencia_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtPesoReferencia.TextChanged

        If grdBlocos.SelectedRows.Count <= 0 Then Return

        Dim Idx As Integer = grdBlocos.SelectedRows(0).Index

        RefreshParam(Idx)

    End Sub

    Private Sub txtPesoRef_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtPesoReferencia.KeyPress
        If Asc(e.KeyChar) <= &H20 Or Asc(e.KeyChar) >= &H127 Then Exit Sub
        FlagDadosEdit = True
        SalvaHab()
    End Sub

    Private Sub txtReceitaNome_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtReceitaNome.KeyPress
        If Asc(e.KeyChar) <= &H20 Or Asc(e.KeyChar) >= &H127 Then Exit Sub
        FlagDadosEdit = True
        SalvaHab()

    End Sub

    Private Sub txtCodigo_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtReceitaCod.KeyPress
        If Asc(e.KeyChar) <= &H20 Or Asc(e.KeyChar) >= &H127 Then Exit Sub
        FlagDadosEdit = True
        SalvaHab()
    End Sub

    Private Sub txtRecDescr_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtReceitaDescr.KeyPress
        If Asc(e.KeyChar) <= &H20 Or Asc(e.KeyChar) >= &H127 Then Exit Sub
        FlagDadosEdit = True
        SalvaHab()
    End Sub

    Private Sub txtPasta_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtPasta.KeyPress
        If Asc(e.KeyChar) <= &H20 Or Asc(e.KeyChar) >= &H127 Then Exit Sub
        FlagDadosEdit = True
        SalvaHab()
    End Sub

    Private Sub txtSubpasta_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtSubpasta.KeyPress
        If Asc(e.KeyChar) <= &H20 Or Asc(e.KeyChar) >= &H127 Then Exit Sub
        FlagDadosEdit = True
        SalvaHab()
    End Sub

    Private Sub grdBlocos_DragEnter(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DragEventArgs) Handles grdBlocos.DragEnter

        If (e.KeyState And CtrlMask) = CtrlMask Then
            e.Effect = DragDropEffects.Copy
        Else
            e.Effect = DragDropEffects.Move
        End If

    End Sub

    Private Sub grdBlocos_DragDrop(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DragEventArgs) Handles grdBlocos.DragDrop

        Dim Txt As String = e.Data.GetData(DataFormats.Text)

        Dim Dados() As String = Txt.Split(";")
        Dim BlkNum As String = Dados(0)
        Dim IdxOrigem As Integer = Dados(1)

        If IsNumeric(BlkNum) = False Then
            Return
        End If

        If BlkNum <= 0 Then Return

        Dim NovoBlk As New clsRcBlk(Rc, TrataArea.AreaDados("Area"), BlkNum)

        Dim Pos As Integer = grdBlocos.Rows.Count

        Dim DropPoint As Point = grdBlocos.PointToClient(New Point(e.X, e.Y))
        For Conta As Integer = 0 To grdBlocos.Rows.Count - 1

            Dim RowRect As Rectangle = grdBlocos.GetRowDisplayRectangle(Conta, False)
            If RowRect.Contains(DropPoint) Then
                Pos = Conta
                Exit For
            End If

        Next

        'If dgBlocos.SelectedRows.Count > 0 Then Pos = dgBlocos.SelectedRows(0).Index + 1
        Rc.Blocos.Insert(Pos, NovoBlk)
        RefreshBlocos(Pos)

        FlagDadosEdit = True
        SalvaHab()
    End Sub

    Private Sub tmrInicio_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tmrInicio.Tick

        tmrInicio.Enabled = False
        WindowState = FormWindowState.Minimized
        WindowState = FormWindowState.Normal
        Activate()

    End Sub

    Private Sub mnuArqNovo_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuArqNovo.Click
        tsbFileNew_Click(sender, e)
    End Sub

    Private Sub mnuArqAbrir_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuArqAbrir.Click
        tsbFileOpen_Click(sender, e)
    End Sub

    Private Sub mnuArqSalvar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuArqSalvar.Click
        tsbFileSave_Click(sender, e)
    End Sub

    Private Sub mnuArqDuplicar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuArqDuplicar.Click
        tsbFileDuplicar_Click(sender, e)
    End Sub

    Private Sub mnuArqExcluir_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuArqExcluir.Click
        tsbFileDelete_Click(sender, e)
    End Sub

    Private Sub mnuArqSair_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuArqSair.Click
        tsbSair_Click(sender, e)
    End Sub

    Private Sub mnuBlocoInsere_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuBlocoInsere.Click
        butItemNovo_Click(sender, e)
    End Sub

    Private Sub mnuBlocoRemoveBloco_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuBlocoRemoveBloco.Click
        butBlocoRemove_Click(sender, e)
    End Sub

    Private Sub mnuAjudaSobre_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuAjudaSobre.Click
        Dim MyForm As New Geral.frmAbout
        MyForm.ShowDialog()
    End Sub

    Private Sub mnuLogin_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuLogin.Click
        tsbLogin_Click(sender, e)
    End Sub

    Private Sub mnuArqAreaSel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuArqlAreaSel.Click
        tsbAreaSel_Click(sender, e)
    End Sub

    Private Sub mnuArqRelatorio_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        tsbRelat_Click(sender, e)
    End Sub

    Private Sub mnuAjudaHelp_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuAjudaHelp.Click

        Dim myPath As String = Util.UtAppPath & "\Help\EditRec\EditorReceitaProdHlp.HLP"

        Dim Cmd As String = "Winhlp32 " & myPath

        Shell(Cmd)

    End Sub

    Private Sub mnuConfigAreas_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuConfigAreas.Click
        frmCadAreas.ShowDialog()
    End Sub

    Private Sub mnuConfigIngred_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuConfigIngred.Click

        frmCadIngred.Abre(TrataArea.AreaDados("Area"))

    End Sub

    Private Sub mnuConfigBlocos_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuConfigBlocos.Click
        frmCadBlocos.ShowDialog()
    End Sub

    Private Sub mnuBlocoIngredMan_Click(sender As System.Object, e As System.EventArgs) Handles mnuBlocoIngredMan.Click
        tsbIngr_Click(sender, e)
    End Sub

    Private Sub mnuBlocoIngredMat_Click(sender As System.Object, e As System.EventArgs) Handles mnuBlocoIngredMat.Click
        tsbIngrMat_Click(sender, e)
    End Sub

    Private Sub tsbIngr_Click(sender As System.Object, e As System.EventArgs) Handles tsbIngr.Click

        If IsNumeric(txtReceitaNum.Text) = False Then Return
        If txtReceitaNum.Text < 0 Then Return

        frmIngred.Abre(TrataArea.AreaDados("Area"), txtReceitaNum.Text, txtPesoReferencia.Text)

    End Sub

    Private Sub tsbIngrMat_Click(sender As System.Object, e As System.EventArgs) Handles tsbIngrMat.Click

        If IsNumeric(txtReceitaNum.Text) = False Then Return
        If txtReceitaNum.Text < 0 Then Return

        frmIngredMat.Abre(TrataArea.AreaDados("Area"), txtReceitaNum.Text, txtPesoReferencia.Text)

    End Sub

    Private Sub mnuAlergenicos_Click(sender As Object, e As EventArgs) Handles mnuAlergenicos.Click

        frmCadAlerg.Abre()

    End Sub

    Private Sub tsbAlerg_Click(sender As Object, e As EventArgs) Handles tsbAlerg.Click

        If IsNumeric(txtReceitaNum.Text) = False Then Return
        If txtReceitaNum.Text < 0 Then Return
        frmCadAlergRec.Abre(TrataArea.AreaDados("Area"), Convert.ToInt32(txtReceitaNum.Text), txtReceitaCod.Text)

        CarregaAlergenicos()

    End Sub

End Class
