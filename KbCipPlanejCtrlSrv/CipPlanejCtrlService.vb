Public Class CipPlanejCtrlService

    Dim Planej As KbCipPlanejCtrl.clsPlanej
    Dim tmrInit As System.Timers.Timer

    Private Sub TrataTmrInit(ByVal sender As Object, ByVal e As System.Timers.ElapsedEventArgs)

        KbCipPlanejCtrl.basLog.LogAdd("TrataTmrInit ini")

        tmrInit.Enabled = False

        Geral.DllInit()

        Planej = New KbCipPlanejCtrl.clsPlanej
        Planej.Iniciar()

        KbCipPlanejCtrl.basLog.LogAdd("TrataTmrInit fim")

    End Sub

    Protected Overrides Sub OnStart(ByVal args() As String)

        KbCipPlanejCtrl.basLog.LogAdd("OnStart ini")

        'Dispara timer para retardo na inicializacao
        tmrInit = New System.Timers.Timer(15000)
        'tmrInit = New System.Timers.Timer(30000)
        AddHandler tmrInit.Elapsed, AddressOf TrataTmrInit
        tmrInit.Enabled = True

        KbCipPlanejCtrl.basLog.LogAdd("OnStart fim")

    End Sub

    Protected Overrides Sub OnStop()

        KbCipPlanejCtrl.basLog.LogAdd("OnStop ini")

        Planej.Parar()
        Planej = Nothing

        KbCipPlanejCtrl.basLog.LogAdd("OnStop fim")

    End Sub

End Class
