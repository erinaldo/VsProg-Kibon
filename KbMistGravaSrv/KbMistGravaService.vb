Public Class KbMistGravaService

    Dim Mist As KbMistGrava.clsMist
    Dim tmrInit As System.Timers.Timer

    Private Sub TrataTmrInit(ByVal sender As Object, ByVal e As System.Timers.ElapsedEventArgs)

        KbMistGrava.basLog.LogAdd("TrataTmrInit ini")

        tmrInit.Enabled = False

        Geral.DllInit()

        Mist = New KbMistGrava.clsMist
        Mist.Iniciar()

        KbMistGrava.basLog.LogAdd("TrataTmrInit fim")

    End Sub

    Protected Overrides Sub OnStart(ByVal args() As String)

        KbMistGrava.basLog.LogAdd("OnStart ini")

        'Dispara timer para retardo na inicializacao
        tmrInit = New System.Timers.Timer(15000)
        AddHandler tmrInit.Elapsed, AddressOf TrataTmrInit
        tmrInit.Enabled = True

        KbMistGrava.basLog.LogAdd("OnStart fim")

    End Sub

    Protected Overrides Sub OnStop()

        KbMistGrava.basLog.LogAdd("OnStop ini")

        Mist.Parar()
        Mist = Nothing

        KbMistGrava.basLog.LogAdd("OnStop fim")

    End Sub

End Class
