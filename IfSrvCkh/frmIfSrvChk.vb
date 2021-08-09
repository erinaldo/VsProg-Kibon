Public Class frmIfSrvChk

    Public KbCipPlanejCtrlCn As KbCipPlanejCtrl.clsIPlanej
    Public KbCipPlanejCtrlDd As KbCipPlanejCtrl.clsPlanejD
    Public KbCipPlanejCtrlSt As Boolean = False

    Public KbMatGravaCn As KbMatGrava.clsIMat
    Public KbMatGravaDd As KbMatGrava.clsMatD
    Public KbMatGravaSt As Boolean = False

    Public KbMistGravaCn As KbMistGrava.clsIMist
    Public KbMistGravaDd As KbMistGrava.clsMistD
    Public KbMistGravaSt As Boolean = False

    Public KbPastGravaCn As KbPastGrava.clsIPast
    Public KbPastGravaDd As KbPastGrava.clsPastD
    Public KbPastGravaSt As Boolean = False

    Public KbProdPlanejCtrlCn As KbProdPlanejCtrl.clsIPlanej
    Public KbProdPlanejCtrlDd As KbProdPlanejCtrl.clsPlanejD
    Public KbProdPlanejCtrlSt As Boolean = False

    Public KbGeralSt As Boolean = False

    Sub SrvConectar()

        Dim Caminho As String = Util.UtAppPath
        Dim Cfg As New Util.clsTrataCfg(Caminho & "\..\Bin\cfgGeral.xml")
        Dim ServIp As String = Cfg.colCfg("ServerIp")

        'Tenta inicializar a comunicação com o programas servidores
        Dim KbCipPlanejCtrlEp As String = "http://" & ServIp & ":8080/KbCipPlanejCtrl"
        KbCipPlanejCtrlCn = New ChannelFactory(Of KbCipPlanejCtrl.clsIPlanej)(New BasicHttpBinding(), New EndpointAddress(KbCipPlanejCtrlEp)).CreateChannel()

        Dim KbMatGravaEp As String = "http://" & ServIp & ":8080/KbMatGrava"
        KbMatGravaCn = New ChannelFactory(Of KbMatGrava.clsIMat)(New BasicHttpBinding(), New EndpointAddress(KbMatGravaEp)).CreateChannel()

        Dim KbMistGravaEp As String = "http://" & ServIp & ":8080/KbMistGrava"
        KbMistGravaCn = New ChannelFactory(Of KbMistGrava.clsIMist)(New BasicHttpBinding(), New EndpointAddress(KbMistGravaEp)).CreateChannel()

        Dim KbPastGravaEp As String = "http://" & ServIp & ":8080/KbPastGrava"
        KbPastGravaCn = New ChannelFactory(Of KbPastGrava.clsIPast)(New BasicHttpBinding(), New EndpointAddress(KbPastGravaEp)).CreateChannel()

        Dim KbProdPlanejCtrlEp As String = "http://" & ServIp & ":8080/KbProdPlanejCtrl"
        KbProdPlanejCtrlCn = New ChannelFactory(Of KbProdPlanejCtrl.clsIPlanej)(New BasicHttpBinding(), New EndpointAddress(KbProdPlanejCtrlEp)).CreateChannel()

    End Sub

    Sub RefreshComm()

        Static Conta As Integer = -1

        Conta = Conta + 1
        If Conta >= 5 Then Conta = 0

        'KbCipPlanejCtrl
        If Conta = 0 Then
            Try
                KbCipPlanejCtrlDd = KbCipPlanejCtrlCn.BuscaDados

                If KbCipPlanejCtrlDd.ContaD <> lblKbCipPlanejCtrlSrv.Text Then
                    KbCipPlanejCtrlSt = True
                Else
                    KbCipPlanejCtrlSt = False
                End If
                lblKbCipPlanejCtrlSrv.Text = KbCipPlanejCtrlDd.ContaD

            Catch
                KbCipPlanejCtrlDd = Nothing
                KbCipPlanejCtrlSt = False
            End Try
        End If


        'KbMatGrava
        If Conta = 1 Then
            Try
                KbMatGravaDd = KbMatGravaCn.BuscaDados

                If KbMatGravaDd.ContaD <> lblKbMatGravaSrv.Text Then
                    KbMatGravaSt = True
                Else
                    KbMatGravaSt = False
                End If
                lblKbMatGravaSrv.Text = KbMatGravaDd.ContaD

            Catch
                KbMatGravaDd = Nothing
                KbMatGravaSt = False
            End Try
        End If


        'KbMistGrava
        If Conta = 2 Then
            Try
                KbMistGravaDd = KbMistGravaCn.BuscaDados

                If KbMistGravaDd.ContaD <> lblKbMistGravaSrv.Text Then
                    KbMistGravaSt = True
                Else
                    KbMistGravaSt = False
                End If
                lblKbMistGravaSrv.Text = KbMistGravaDd.ContaD

            Catch
                KbMistGravaDd = Nothing
                KbMistGravaSt = False
            End Try
        End If


        'KbPastGrava
        If Conta = 3 Then
            Try
                KbPastGravaDd = KbPastGravaCn.BuscaDados

                If KbPastGravaDd.ContaD <> lblKbPastGravaSrv.Text Then
                    KbPastGravaSt = True
                Else
                    KbPastGravaSt = False
                End If
                lblKbPastGravaSrv.Text = KbPastGravaDd.ContaD

            Catch
                KbPastGravaDd = Nothing
                KbPastGravaSt = False
            End Try
        End If


        'KbProdPlanejCtrl
        If Conta = 4 Then
            Try
                KbProdPlanejCtrlDd = KbProdPlanejCtrlCn.BuscaDados

                If KbProdPlanejCtrlDd.ContaD <> lblKbProdPlanejCtrlSrv.Text Then
                    KbProdPlanejCtrlSt = True
                Else
                    KbProdPlanejCtrlSt = False
                End If
                lblKbProdPlanejCtrlSrv.Text = KbProdPlanejCtrlDd.ContaD

            Catch
                KbProdPlanejCtrlDd = Nothing
                KbProdPlanejCtrlSt = False
            End Try
        End If


        'Geral
        If KbCipPlanejCtrlSt = True And
           KbMatGravaSt = True And
           KbMistGravaSt = True And
           KbPastGravaSt = True And
           KbProdPlanejCtrlSt = True Then

            KbGeralSt = True

        Else

            KbGeralSt = False

        End If

    End Sub

    Sub RefreshDados()

        'KbCipPlanejCtrl
        If KbCipPlanejCtrlSt = True Then
            shKbCipPlanejCtrlSrv.FillColor = Color.LightGreen
        Else
            shKbCipPlanejCtrlSrv.FillColor = Color.Red
        End If


        'KbMatGrava
        If KbMatGravaSt = True Then
            shKbMatGravaSrv.FillColor = Color.LightGreen
        Else
            shKbMatGravaSrv.FillColor = Color.Red
        End If


        'KbMistGrava
        If KbMistGravaSt = True Then
            shKbMistGravaSrv.FillColor = Color.LightGreen
        Else
            shKbMistGravaSrv.FillColor = Color.Red
        End If


        'KbPastGrava
        If KbPastGravaSt = True Then
            shKbPastGravaSrv.FillColor = Color.LightGreen
        Else
            shKbPastGravaSrv.FillColor = Color.Red
        End If


        'KbProdPlanejCtrl
        If KbProdPlanejCtrlSt = True Then
            shKbProdPlanejCtrlSrv.FillColor = Color.LightGreen
        Else
            shKbProdPlanejCtrlSrv.FillColor = Color.Red
        End If


        'Geral
        If KbGeralSt = True Then
            shKbGeral.FillColor = Color.LightGreen
            niIcone.Icon = Global.IfSrvCkh.My.Resources.Resources.Tse
        Else
            shKbGeral.FillColor = Color.Red
            niIcone.Icon = Global.IfSrvCkh.My.Resources.Resources.TseRed
        End If

    End Sub

    Private Sub frmIfSrvChk_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load

        Geral.basTrataDados.DllInit()
        SrvConectar()

        tmrInit.Enabled = True
        tmrComm.Enabled = True

    End Sub

    Private Sub frmIfSrvChk_FormClosing(sender As Object, e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing

        Dim Ret As DialogResult = frmConfirmaFim.ShowDialog
        If Ret <> Windows.Forms.DialogResult.OK Then

            e.Cancel = True
            Exit Sub

        End If

        niIcone.Visible = False
        niIcone.Dispose()

        tmrComm.Enabled = False
        KbCipPlanejCtrlDd = Nothing

    End Sub

    Private Sub tmrComm_Tick(sender As System.Object, e As System.EventArgs) Handles tmrComm.Tick

        'Comunica
        RefreshComm()
        RefreshDados()

    End Sub

    Private Sub butFechar_Click(sender As System.Object, e As System.EventArgs) Handles butFechar.Click

        WindowState = FormWindowState.Minimized
        Visible = False

    End Sub

    Private Sub butKbCipPlanejCtrlSrv_Click(sender As System.Object, e As System.EventArgs) Handles butKbCipPlanejCtrlSrv.Click

        frmKbCipPlanejCtrl.ShowDialog()

    End Sub

    Private Sub butKbMatGravaSrv_Click(sender As System.Object, e As System.EventArgs) Handles butKbMatGravaSrv.Click

        frmKbMatGrava.ShowDialog()

    End Sub

    Private Sub butKbMistGravaSrv_Click(sender As System.Object, e As System.EventArgs) Handles butKbMistGravaSrv.Click

        frmKbMistGrava.ShowDialog()

    End Sub

    Private Sub butKbPastGravaSrv_Click(sender As System.Object, e As System.EventArgs) Handles butKbPastGravaSrv.Click

        frmKbPastGrava.ShowDialog()

    End Sub

    Private Sub niIcone_Click(sender As System.Object, e As System.EventArgs) Handles niIcone.Click

        Visible = True
        WindowState = FormWindowState.Normal
        Activate()

    End Sub

    Private Sub tmrInit_Tick(sender As System.Object, e As System.EventArgs) Handles tmrInit.Tick

        tmrInit.Enabled = False
        WindowState = FormWindowState.Minimized
        Visible = False

    End Sub
End Class
