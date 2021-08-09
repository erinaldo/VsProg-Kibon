Public Class KbToledoCtrlSrv

    Public Com As KbToledoCtrl.clsCom
    Dim tmrInit As System.Timers.Timer

    Private Sub TrataTmrInit(ByVal sender As Object, ByVal e As System.Timers.ElapsedEventArgs)

        tmrInit.Enabled = False

        Geral.DllInit()

        Com = New KbToledoCtrl.clsCom
        Com.Inicia()

    End Sub

    Protected Overrides Sub OnStart(ByVal args() As String)
        ' Add code here to start your service. This method should set things
        ' in motion so your service can do its work.

        'Dispara timer para retardo na inicializacao
        tmrInit = New System.Timers.Timer(15000)
        AddHandler tmrInit.Elapsed, AddressOf TrataTmrInit
        tmrInit.Enabled = True

    End Sub

    Protected Overrides Sub OnStop()
        ' Add code here to perform any tear-down necessary to stop your service.

        Com.Para()
        Com = Nothing

    End Sub

End Class
