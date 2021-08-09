Public Class KbMatGravaService

    Dim Mat As KbMatGrava.clsMat
    Dim tmrInit As System.Timers.Timer

    public Sub TrataTmrInit(ByVal sender As Object, ByVal e As System.Timers.ElapsedEventArgs)

        KbMatGrava.basLog.LogAdd("TrataTmrInit ini")

        tmrInit.Enabled = False

        Geral.DllInit()

        Mat = New KbMatGrava.clsMat
        Mat.Iniciar()

        KbMatGrava.basLog.LogAdd("TrataTmrInit fim")

    End Sub

    Protected Overrides Sub OnStart(ByVal args() As String)

        KbMatGrava.basLog.LogAdd("OnStart ini")

        'Dispara timer para retardo na inicializacao
        'tmrInit = New System.Timers.Timer(1000)
        tmrInit = New System.Timers.Timer(15000)
        AddHandler tmrInit.Elapsed, AddressOf TrataTmrInit
        tmrInit.Enabled = True

        KbMatGrava.basLog.LogAdd("OnStart fim")

    End Sub

    Protected Overrides Sub OnStop()

        KbMatGrava.basLog.LogAdd("OnStop ini")

        Mat.Parar()
        Mat = Nothing

        KbMatGrava.basLog.LogAdd("OnStop fim")

    End Sub

End Class
