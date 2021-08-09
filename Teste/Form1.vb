Public Class Form1

    Private Sub Button1_Click(sender As System.Object, e As System.EventArgs) Handles Button1.Click

        Dim BlkNum As Integer = 1001

        Dim DbRc As New Geral.nsReceitas.dcReceitas
        Dim dtBlocos = (From It In DbRc.Blocos Where It.Area = "Acucar" And It.BlkNum = BlkNum).ToList

        For Each z In dtBlocos

            Dim a = z.BlkDescr

        Next

    End Sub
End Class
