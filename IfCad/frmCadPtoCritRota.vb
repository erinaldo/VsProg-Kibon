Public Class frmCadProduto

    Public dtCadRotaPtoCr As New List(Of Geral.nsCipValid.CadRotaPtoCr)
    Public dtCadPtoCr As New List(Of Geral.nsCipValid.CadPtoCr)

    Public FlagEdit As Boolean

    Private Sub frmCadPtoCritRota_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        Me.WindowState = FormWindowState.Maximized

        RefreshDados()

    End Sub

    Sub RefreshDados()

        gvCadPtoCrRota.Rows.Clear()

        Dim Cv As New Geral.nsCipValid.dcCipValid
        Dim dtCadPtoCrRota = (From It In Cv.CadRotaPtoCr Order By It.RotaId, It.Seq).ToList

        For Conta As Integer = 0 To dtCadPtoCrRota.Count - 1

            With dtCadPtoCrRota(Conta)

                Dim Pergunta As String = "..."
                dtCadPtoCr = (From It In Cv.CadPtoCr Where It.PtoCrId = .PtoCrId).ToList
                If dtCadPtoCr.Count > 0 Then Pergunta = dtCadPtoCr.First.Pergunta

                gvCadPtoCrRota.Rows.Add(.RotaId, .PtoCrId, Pergunta, .Seq)

            End With
        Next

    End Sub

    Private Sub btnNovaPergunta_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnNova.Click

        FlagEdit = False

        frmCadPtoCritRotaEdit.Abre()
        If frmCadPtoCritRotaEdit.RotaId <= 0 Then Return

        Dim RotaId As Integer = frmCadPtoCritRotaEdit.RotaId
        Dim PtoCrId As Integer = frmCadPtoCritRotaEdit.PtoCrId
        Dim Seq As Integer = frmCadPtoCritRotaEdit.Seq

        Dim Bp As New Geral.nsCipValid.dcCipValid
        Dim dtCadPtoCrRota = (From It In Bp.CadRotaPtoCr Where It.RotaId = RotaId And It.PtoCrId = PtoCrId).ToList
        If dtCadPtoCrRota.Count > 0 Then
            MsgBox("Erro: Ponto Crítico já cadastrado para está Rota!!!")
            Return
        End If

        Dim dtCadPtoCrRotaSeq = (From It In Bp.CadRotaPtoCr Where It.Seq = Seq).ToList
        If dtCadPtoCrRota.Count > 0 Then
            MsgBox("Erro: Esta sequencia já está em uso nestá Rota!!!")
            Return
        End If

        Dim MyRowNew As New List(Of Geral.nsCipValid.CadRotaPtoCr)

        MyRowNew.Add(New Geral.nsCipValid.CadRotaPtoCr With {.RotaId = RotaId, .PtoCrId = PtoCrId, .Seq = Seq})

        Bp.CadRotaPtoCr.InsertAllOnSubmit(MyRowNew)

        Bp.SubmitChanges()

        RefreshDados()

    End Sub

    Private Sub btnEdita_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnEdita.Click

        FlagEdit = True

        If gvCadPtoCrRota.SelectedRows.Count <= 0 Then Return

        Dim ReqRotaId As Integer = gvCadPtoCrRota.SelectedRows(0).Cells(0).Value
        Dim ReqPtoCrId As Integer = gvCadPtoCrRota.SelectedRows(0).Cells(1).Value
        Dim ReqSeq As String = gvCadPtoCrRota.SelectedRows(0).Cells(3).Value

        frmCadPtoCritRotaEdit.Abre(ReqRotaId, ReqPtoCrId, ReqSeq)
        If frmCadPtoCritRotaEdit.RotaId <= 0 Then Return

        Dim RotaId As Integer = frmCadPtoCritRotaEdit.RotaId
        Dim PtoCrId As Integer = frmCadPtoCritRotaEdit.PtoCrId
        Dim Seq As Integer = frmCadPtoCritRotaEdit.Seq

        Dim Bp As New Geral.nsCipValid.dcCipValid
        Dim dtCadPtoCrRota = (From It In Bp.CadRotaPtoCr Where It.RotaId = RotaId And It.PtoCrId = PtoCrId And It.Seq = Seq).ToList
        If dtCadPtoCrRota.Count > 0 Then
            MsgBox("Erro: Ponto Crítico já cadastrado para está Rota!!!")
            Return
        End If

        dtCadPtoCrRota = (From It In Bp.CadRotaPtoCr Where It.RotaId = RotaId And It.PtoCrId = PtoCrId).ToList
        If dtCadPtoCrRota.Count <= 0 Then Return

        dtCadPtoCrRota.First.RotaId = RotaId
        dtCadPtoCrRota.First.PtoCrId = PtoCrId
        dtCadPtoCrRota.First.Seq = Seq

        Bp.SubmitChanges()

        RefreshDados()

    End Sub

    Private Sub btnDeleta_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnDeleta.Click

        If gvCadPtoCrRota.SelectedRows.Count <= 0 Then Return

        Dim RotaId As Integer = gvCadPtoCrRota.SelectedRows(0).Cells(0).Value
        Dim PtoCrId As String = gvCadPtoCrRota.SelectedRows(0).Cells(1).Value

        Dim Ret As MsgBoxResult = MsgBox("Deseja excluir o Ponto Crítico. Confirma?", MsgBoxStyle.OkCancel)
        If Ret = MsgBoxResult.Cancel Then Return

        Dim Bp As New Geral.nsCipValid.dcCipValid
        Dim dtCadPtoCrRot = (From It In Bp.CadRotaPtoCr Where It.RotaId = RotaId And It.PtoCrId = PtoCrId).ToList
        If dtCadPtoCrRot.Count <= 0 Then Return

        Bp.CadRotaPtoCr.DeleteAllOnSubmit(dtCadPtoCrRot)

        Bp.SubmitChanges()

        RefreshDados()

        FlagEdit = True

    End Sub

    Private Sub btnSair_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSair.Click
        Close()
    End Sub
End Class