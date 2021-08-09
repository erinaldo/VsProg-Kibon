Public Class frmCadUserSeg

    Public Bp As New Geral.nsCipValid.dcCipValid
    Public dtCadUserSeg As New List(Of Geral.nsCipValid.CadUserSeg)

    Public FlagDadosEdit As Boolean = False

    Sub RefreshDados()

        gvCadUserSeg.Rows.Clear()

        For Conta As Integer = 0 To dtCadUserSeg.Count - 1

            With dtCadUserSeg(Conta)

                'If .RowState <> DataRowState.Deleted And .RowState <> DataRowState.Detached Then

                gvCadUserSeg.Rows.Add(.SegId, .Nome, .Descr)

                'End If
            End With
        Next

    End Sub

    Private Sub frmCadUser_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        'carrega dados
        dtCadUserSeg = (From It In Bp.CadUserSeg).ToList

        WindowState = FormWindowState.Maximized

        RefreshDados()

    End Sub

    Private Sub frmCadUser_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing

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
            btnSalva_Click(sender, e)

        End If

    End Sub

    Private Sub btnSalva_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSalva.Click

        'Salva todas as mudanças feitas na tabela
        Bp.SubmitChanges()
        FlagDadosEdit = False

    End Sub

    Private Sub btnNovo_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnNovo.Click

        'Cria o Id  para evitar duplicação do Id na rede depois verifica se tem algum criado em memória
        Dim SegId As Integer = 1
        Dim MyRows = From It In dtCadUserSeg Order By It.SegId Descending
        If MyRows.Count > 0 Then
            If SegId <= MyRows(0).SegId Then SegId = MyRows(0).SegId + 1
        End If

        frmCadUserSegEdit.Abre(SegId)
        If frmCadUserSegEdit.SelNome = "" Then Return
        Dim Nome As String = frmCadUserSegEdit.SelNome
        Dim Descr As String = frmCadUserSegEdit.SelDescr

        'cria novo data table para receber o novo registro inserido
        Dim CadUserSegNew As New List(Of Geral.nsCipValid.CadUserSeg)
        CadUserSegNew.Add(New Geral.nsCipValid.CadUserSeg With {.SegId = SegId, .Nome = Nome, .Descr = Descr})

        'insere o novo registro na tabela
        Bp.CadUserSeg.InsertAllOnSubmit(CadUserSegNew)

        'adiciona o novo registo ao data table de escopo geral, para visualizar o novo registro no refresh dados
        dtCadUserSeg = dtCadUserSeg.Union(CadUserSegNew).ToList


        RefreshDados()
        FlagDadosEdit = True

    End Sub

    Private Sub btnEdita_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnEdita.Click

        If gvCadUserSeg.SelectedRows.Count <= 0 Then Return

        Dim SegId As Integer = gvCadUserSeg.SelectedRows(0).Cells(0).Value
        frmCadUserSegEdit.Abre(SegId, gvCadUserSeg.SelectedRows(0).Cells(1).Value, gvCadUserSeg.SelectedRows(0).Cells(2).Value)
        If frmCadUserSegEdit.SelNome = "" Then Return

        'verifica se a identificação a ser editada realmente existe
        Dim CadUserSegEdit = (From It In dtCadUserSeg Where It.SegId = SegId).ToList
        If CadUserSegEdit.Count <= 0 Then
            MsgBox("Erro: falha salvando dados do usuario (" & frmCadUserSegEdit.SelDescr & ")")
            Return
        End If

        CadUserSegEdit(0).Nome = frmCadUserSegEdit.SelNome
        CadUserSegEdit(0).Descr = frmCadUserSegEdit.SelDescr

        RefreshDados()
        FlagDadosEdit = True

    End Sub

    Private Sub gvCadUser_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles gvCadUserSeg.DoubleClick
        btnEdita_Click(sender, e)
    End Sub

    Private Sub btnDeleta_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnRemove.Click

        If gvCadUserSeg.SelectedRows.Count <= 0 Then Return
        Dim SegId As Integer = gvCadUserSeg.SelectedRows(0).Cells(0).Value
        Dim Nome As String = gvCadUserSeg.SelectedRows(0).Cells(1).Value

        Dim Ret As MsgBoxResult = MsgBox("A área de segurança [" & Nome & "] será excluida. Confirma?", MsgBoxStyle.OkCancel)
        If Ret = MsgBoxResult.Cancel Then Return

        'Apaga este cadastro
        Dim MyUserSegRows = (From It In dtCadUserSeg Where It.SegId = SegId).ToList
        If MyUserSegRows.Count < 0 Then Return

        Bp.CadUserSeg.DeleteAllOnSubmit(MyUserSegRows)

        'remove o registro deletado do data table de escopo geral
        dtCadUserSeg.Remove(MyUserSegRows(0))

        RefreshDados()
        FlagDadosEdit = True

    End Sub

    Private Sub btnSair_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSair.Click
        Close()
    End Sub
End Class