Public Class frmSelCip

    Public SelOk As Boolean = False
    Public SelRotaId As Integer
    Public SelRecNum As Integer
    Public Area As String = ""

    Sub Abre(Area As String, ByVal RotaId As Integer, ByVal RecNum As Integer)

        Me.Area = Area
        SelOk = False

        RefreshRota(RotaId)
        RefreshReceita(RecNum)

        ShowDialog()

    End Sub

    Sub RefreshRota(ByVal RotaId As Integer)

        txtRotaId.Text = RotaId

        Dim DbCr As New nsCipRotas.dcCipRotas
        Dim dtRotaCad = (From It In DbCr.RotaCad Where It.RotaId = txtRotaId.Text).ToList
 
        If dtRotaCad.Count <= 0 Then Return

        txtCirc.Text = dtRotaCad(0).Circ
        txtTipo.Text = dtRotaCad(0).Tipo
        txtRotaDescr.Text = dtRotaCad(0).Descr

    End Sub

    Sub RefreshReceita(ByVal RecNum As Integer)

        txtRecNum.Text = RecNum

        Dim DbRc As New nsReceitas.dcReceitas
        Dim dtRec = (From It In DbRc.Rec Where It.Area = "CIP" And It.RecNum = txtRecNum.Text).ToList

        If dtRec.Count <= 0 Then Return

        txtRecNome.Text = dtRec(0).RecNome
        txtCodigo.Text = dtRec(0).Codigo
        txtRecDescr.Text = dtRec(0).RecDescr

    End Sub

    Private Sub butCancela_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles butCancela.Click
        Close()
    End Sub

    Private Sub butOk_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles butOk.Click

        If txtRotaId.Text <= 0 Then
            MsgBox("Erro: elecione uma rota de CIP.")
            Return
        End If

        If txtRecNum.Text <= 0 Then
            MsgBox("Erro: elecione uma receita de CIP.")
            Return
        End If

        SelOk = True
        SelRotaId = txtRotaId.Text
        SelRecNum = txtRecNum.Text

        'Amarração de Rota vs Receita
        'If (txtRotaId.Text = "1012") And (txtRecNum.Text = "1") Then
        '   SelRotaId = 1012
        '   SelRecNum = 15
        'End If

        'If (txtRotaId.Text = "1009") And (txtRecNum.Text = "1") Then
        '    SelRotaId = 1009
        '    SelRecNum = 15
        'End If


        Close()

    End Sub

    Private Sub butSelRota_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles butSelRota.Click

        Dim Frm As New frmSelRota
        Frm.Abre()

        If Frm.SelOk = False Then Return

        RefreshRota(Frm.SelRotaId)

    End Sub

    Private Sub burtSelRec_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles burtSelRec.Click

        Dim Frm As New Geral.frmSelRec
        Frm.Abre(Area)

        If Frm.SelRecNum <= 0 Then Return

        RefreshReceita(Frm.SelRecNum)

    End Sub
End Class