Public Class frmKbWebCall

    Private Sub frmKbWebCall_Load(sender As Object, e As System.EventArgs) Handles Me.Load

        tmrCmd.Enabled = True

    End Sub

    Private Sub tmrCmd_Tick(sender As System.Object, e As System.EventArgs) Handles tmrCmd.Tick

        tmrCmd.Enabled = False

        'Dim CmdWeb As String = Command()
        Geral.AbreCipRelatWeb()

        'Try
        '    Dim Browser As Object = CreateObject("InternetExplorer.Application")

        '    'Browser.Navigate2("http://190.0.0.9/RpWeb/Default.aspx")
        '    Browser.Navigate2(CmdWeb)
        '    Browser.Visible = True
        'Catch : End Try

        End

    End Sub
End Class
