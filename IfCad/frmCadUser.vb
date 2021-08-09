Public Class frmCadUser
    Public Bp As New Geral.nsCipValid.dcCipValid

    Public dtCadUserHab As New List(Of Geral.nsCipValid.CadUserHab)
    Public dtCadUserSeg As New List(Of Geral.nsCipValid.CadUserSeg)
    Public dtCadUser As New List(Of Geral.nsCipValid.CadUser)

    Public FlagDadosEdit As Boolean = False

    Sub RefreshDados()

        gvCadUser.Rows.Clear()

        For Conta As Integer = 0 To dtCadUser.Count - 1

            With dtCadUser(Conta)

                gvCadUser.Rows.Add(.UserId, .Nome, .Login)

             End With
        Next

    End Sub

    Private Sub frmCadUser_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        'carrega dados
        dtCadUserHab = (From It In Bp.CadUserHab).ToList
        dtCadUserSeg = (From It In Bp.CadUserSeg).ToList
        dtCadUser = (From It In Bp.CadUser).ToList

        WindowState = FormWindowState.Maximized

        RefreshDados()

    End Sub

    Private Sub frmCadUser_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles MyBase.FormClosing

        If FlagDadosEdit = True Then

            Dim Ret As MsgBoxResult = MsgBox("ATENÇÃO! Os dados editados serão perdidos. Deseja salvar os dados editados?", MsgBoxStyle.YesNoCancel)

            'Cancelar, continua editando os dados
            If Ret = MsgBoxResult.Cancel Then
                e.Cancel = True
                Return
            End If

            'Não salvar, prosseguir perdendo os dados editados
            If Ret = MsgBoxResult.No Then Return

            'Salva os dados
            butSalva_Click(sender, e)

        End If

    End Sub

    Private Sub butSalva_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSalva.Click

        'Salva todas as mudanças feitas na tabela
        Bp.SubmitChanges()
        FlagDadosEdit = False

    End Sub

    Private Sub butNovo_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnNovo.Click

        'cria nova identificação de usuário
        Dim UserId As Integer = 1
        Dim MyUser = (From It In dtCadUser Order By It.UserId Descending).ToList
        If MyUser.Count > 0 Then UserId = MyUser(0).UserId + 1

        frmCadUserEdit.Abre(UserId)
        If frmCadUserEdit.SelNome = "" Then Return
        If frmCadUserEdit.sellogin = "" Then Return

        Dim Nome As String = frmCadUserEdit.SelNome
        Dim Login As String = frmCadUserEdit.SelLogin
        Dim Senha As String = Util.basCrypto.CalcHashHex(frmCadUserEdit.SelLogin.ToUpper, Util.EncMode.UTF8, Util.HashMode.MD5)

        'cria novo data table para receber o novo registro inserido
        Dim CadUserNew As New List(Of Geral.nsCipValid.CadUser)
        CadUserNew.Add(New Geral.nsCipValid.CadUser With {.UserId = UserId, .Nome = Nome, .Login = Login, .Senha = Senha})

        'insere o novo registro na tabela
        Bp.CadUser.InsertAllOnSubmit(CadUserNew)

        'adiciona o novo registo ao data table de escopo geral, para visualizar o novo registro no refresh dados
        dtCadUser = dtCadUser.Union(CadUserNew).ToList

        RefreshDados()
        FlagDadosEdit = True

    End Sub

    Private Sub btnEdita_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnEdita.Click

        If gvCadUser.SelectedRows.Count <= 0 Then Return

        Dim UserId As Integer = gvCadUser.SelectedRows(0).Cells(0).Value
        frmCadUserEdit.Abre(UserId, gvCadUser.SelectedRows(0).Cells(1).Value, gvCadUser.SelectedRows(0).Cells(2).Value)

        If frmCadUserEdit.SelNome = "" Then Return

        'verifica se a identificação a ser editada realmente existe
        Dim CadUserEdit = (From It In dtCadUser Where It.UserId = UserId).ToList
        If CadUserEdit.Count <= 0 Then
            MsgBox("frmCadUser: Erro salvando dados do usuario: " & frmCadUserEdit.SelLogin)
            Return
        End If

        CadUserEdit(0).Nome = frmCadUserEdit.SelNome
        CadUserEdit(0).Login = frmCadUserEdit.SelLogin

        RefreshDados()
        FlagDadosEdit = True

    End Sub

    Private Sub btnTrocaSenha_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnTrocaSenha.Click

        If gvCadUser.SelectedRows.Count <= 0 Then Return

        frmCadUserEditSenha.Abre()
        If frmCadUserEditSenha.SelSenha = "" Then Return

        Dim UserId As Integer = gvCadUser.SelectedRows(0).Cells(0).Value

        Dim MyRows = From It In dtCadUser Where It.UserId = UserId
        If MyRows.Count <= 0 Then
            MsgBox("frmCadUser: Erro salvando a senha do usuario: " & UserId)
            Return
        End If

        MyRows(0).Senha = frmCadUserEditSenha.SelSenha

        RefreshDados()
        FlagDadosEdit = True

    End Sub

    Private Sub gvCadUser_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles gvCadUser.DoubleClick
        btnEdita_Click(sender, e)
    End Sub

    Private Sub btnUserHabSeg_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnUserHabSeg.Click
        If gvCadUser.SelectedRows.Count <= 0 Then Return

        Dim UserId As Integer = gvCadUser.SelectedRows(0).Cells(0).Value
        Dim Nome As String = gvCadUser.SelectedRows(0).Cells(1).Value

        frmCadUserHab.Abre(UserId, Nome)
    End Sub

    Private Sub btnDeleta_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnDeleta.Click

        If gvCadUser.SelectedRows.Count <= 0 Then Return
        Dim UserId As Integer = gvCadUser.SelectedRows(0).Cells(0).Value
        Dim Nome As String = gvCadUser.SelectedRows(0).Cells(1).Value


        Dim Ret As MsgBoxResult = MsgBox("O usuário " & Nome & " será excluido. Confirma?", MsgBoxStyle.OkCancel)
        If Ret = MsgBoxResult.Cancel Then Return

        'Apaga os dados de habilitacao
        Dim MyHabRows = (From It In dtCadUserHab Where It.UserId = UserId).ToList
        If MyHabRows.Count > 0 Then
            Bp.CadUserHab.DeleteAllOnSubmit(MyHabRows)
        End If

        'Apaga este cadastro
        Dim MyUserRows = (From It In dtCadUser Where It.UserId = UserId).ToList
        If MyUserRows.Count < 0 Then Return

        Bp.CadUser.DeleteAllOnSubmit(MyUserRows)

        'remove o registro deletado do data table de escopo geral
        dtCadUser.Remove(MyUserRows(0))

        RefreshDados()
        FlagDadosEdit = True

    End Sub

    Private Sub btnSair_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSair.Click
        Close()
    End Sub
End Class