Public Class KbProdPlanejCtrlService

    Dim Planej As KbProdPlanejCtrl.clsPlanej
    Dim tmrInit As System.Timers.Timer

    Private Sub TrataTmrInit(ByVal sender As Object, ByVal e As System.Timers.ElapsedEventArgs)

        KbProdPlanejCtrl.basLog.LogAdd("TrataTmrInit ini")

        tmrInit.Enabled = False

        Geral.DllInit()

        Planej = New KbProdPlanejCtrl.clsPlanej
        Planej.Iniciar()

        KbProdPlanejCtrl.basLog.LogAdd("TrataTmrInit fim")

    End Sub

    Protected Overrides Sub OnStart(ByVal args() As String)

        KbProdPlanejCtrl.basLog.LogAdd("OnStart ini")

        'Dispara timer para retardo na inicializacao
        tmrInit = New System.Timers.Timer(15000)
        AddHandler tmrInit.Elapsed, AddressOf TrataTmrInit
        tmrInit.Enabled = True

        KbProdPlanejCtrl.basLog.LogAdd("OnStart fim")

    End Sub

    Protected Overrides Sub OnStop()

        KbProdPlanejCtrl.basLog.LogAdd("OnStop ini")

        Planej.Parar()
        Planej = Nothing

        KbProdPlanejCtrl.basLog.LogAdd("OnStop fim")

    End Sub

End Class
