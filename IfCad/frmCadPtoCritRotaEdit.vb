Public Class frmCadPtoCritRotaEdit

    Public RotaId As Integer
    Public PtoCrId As Integer
    Public Seq As Integer

    Dim FlagEdit As Boolean = False

    Sub Abre(Optional ByVal RotaId As Integer = 0, Optional ByVal PtoCrId As Integer = 0, Optional ByVal Seq As Integer = 0)

        'RotaId
        txtRotaId.Text = RotaId
        txtPtoCrId.Text = PtoCrId
        txtSeq.Text = Seq

        If RotaId <= 0 Then
            'Novo
            FlagEdit = False
            butPtoCrSel.Enabled = True
            butRotaSel.Enabled = True
        Else
            'Edita
            FlagEdit = True
            butPtoCrSel.Enabled = False
            butRotaSel.Enabled = False
        End If

        RefreshDados()
        ShowDialog()

    End Sub

    Sub RefreshDados()

        'RotaId
        txtRotaDescr.Text = ""

        Dim Cr As New Geral.nsCipRotas.dcCipRotas
        Dim dtCcr = (From It In Cr.RotaCad Where It.RotaId = txtRotaId.Text).ToList
        If dtCcr.Count > 0 Then txtRotaDescr.Text = dtCcr.First.Descr

        'Ponto Crítico
        txtPtoCrPergunta.Text = ""

        Dim Cv As New Geral.nsCipValid.dcCipValid
        Dim dtCadPtoCr = (From It In Cv.CadPtoCr Where It.PtoCrId = txtPtoCrId.Text).ToList
        If dtCadPtoCr.Count > 0 Then txtPtoCrPergunta.Text = dtCadPtoCr.First.Pergunta

        'Seq
        If FlagEdit = False Then
            txtSeq.Text = 1
            Dim dtCrPr = (From It In Cv.CadRotaPtoCr Where It.RotaId = txtRotaId.Text Order By It.Seq Descending).Take(1).ToList
            If dtCrPr.Count > 0 Then txtSeq.Text = dtCrPr.First.Seq + 1
        End If

    End Sub

    Private Sub butSalva_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles butSalva.Click

        If txtRotaId.Text <= 0 Then
            MsgBox("Erro: selecione uma rota.")
            Return
        End If

        If txtPtoCrId.Text <= 0 Then
            MsgBox("Erro: selecione um ponto crítico.")
            Return
        End If

        RotaId = txtRotaId.Text
        PtoCrId = txtPtoCrId.Text
        Seq = txtSeq.Text

        Close()

    End Sub

    Private Sub butCancelar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles butCancelar.Click

        Close()

    End Sub

    Private Sub butRotaSel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles butRotaSel.Click

        Dim Frm As New Geral.frmSelRota
        Frm.Abre()

        If Frm.SelRotaId <= 0 Then Return

        txtRotaId.Text = Frm.SelRotaId
        RefreshDados()

    End Sub

    Private Sub butPtoCrSel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles butPtoCrSel.Click

        Dim Frm As New Geral.frmSelPtoCr
        Frm.Abre()

        If Frm.SelPtoCrId <= 0 Then Return

        txtPtoCrId.Text = Frm.SelPtoCrId
        txtPtoCrPergunta.Text = Frm.SelPtoCrIdPergunta

    End Sub

    Private Sub frmCadPtoCritRotaEdit_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

    End Sub
End Class