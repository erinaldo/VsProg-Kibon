Public Class frmCadPtoCr

    Public Bp As New Geral.nsCipValid.dcCipValid
    Public dtCadPtoCr As New List(Of Geral.nsCipValid.CadPtoCr)

    Private Sub frmCadCfg_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        dtCadPtoCr = (From It In Bp.CadPtoCr).ToList

        WindowState = FormWindowState.Maximized

        RefreshDados()

    End Sub

    Sub RefreshDados()
        gvCadPtoCr.Rows.Clear()

        For Conta As Integer = 0 To dtCadPtoCr.Count - 1

            With dtCadPtoCr(Conta)

                gvCadPtoCr.Rows.Add(.PtoCrId, .Pergunta)

            End With
        Next
    End Sub

    Private Sub frmCadUser_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
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


    End Sub

    Private Sub btnSair_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSair.Click
        Close()
    End Sub

    Private Sub btnNovaPergunta_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnNovaPergunta.Click

        Dim PtoCrLdNova As Integer = 1
        For Conta As Integer = 0 To gvCadPtoCr.RowCount - 1
            If PtoCrLdNova <= gvCadPtoCr.Rows(Conta).Cells(0).Value Then
                PtoCrLdNova = gvCadPtoCr.Rows(Conta).Cells(0).Value + 1
            End If
        Next

        frmCadPtoCrEdit.Abre(PtoCrLdNova)

        Dim nPergunta = frmCadPtoCrEdit.Pergunta

        Dim MyRowNew As New List(Of Geral.nsCipValid.CadPtoCr)
        MyRowNew.Add(New Geral.nsCipValid.CadPtoCr With {.PtoCrId = PtoCrLdNova, .Pergunta = nPergunta})

        Bp.CadPtoCr.InsertAllOnSubmit(MyRowNew)
        dtCadPtoCr = dtCadPtoCr.Union(MyRowNew).ToList

        RefreshDados()

    End Sub

    Private Sub btnSalva_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSalva.Click
        Bp.SubmitChanges()
    End Sub


    Private Sub btnDeleta_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnDeleta.Click

        Dim PtoCrld As Integer = gvCadPtoCr.SelectedRows(0).Cells(0).Value

        Dim Ret As MsgBoxResult = MsgBox("A Pergunta " & PtoCrld & " será excluida. Confirma?", MsgBoxStyle.OkCancel)
        If Ret = MsgBoxResult.Cancel Then Return

        'Apaga este cadastro
        Dim MyPtoRows = (From It In dtCadPtoCr Where It.PtoCrId = PtoCrld).ToList
        If MyPtoRows.Count < 0 Then Return

        Bp.CadPtoCr.DeleteAllOnSubmit(MyPtoRows)

        'remove o registro deletado do data table de escopo geral
        dtCadPtoCr.Remove(MyPtoRows(0))

        RefreshDados()

    End Sub
End Class