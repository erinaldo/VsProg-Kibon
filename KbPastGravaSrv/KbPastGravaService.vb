Public Class KbPastGravaService

    Dim Past As KbPastGrava.clsPast
    Dim tmrInit As System.Timers.Timer

    Private Sub TrataTmrInit(ByVal sender As Object, ByVal e As System.Timers.ElapsedEventArgs)

        KbPastGrava.basLog.LogAdd("TrataTmrInit ini")

        tmrInit.Enabled = False

        Geral.DllInit()

        Past = New KbPastGrava.clsPast
        Past.Iniciar()

        KbPastGrava.basLog.LogAdd("TrataTmrInit fim")

    End Sub

    Protected Overrides Sub OnStart(ByVal args() As String)

        KbPastGrava.basLog.LogAdd("OnStart ini")

        'Dispara timer para retardo na inicializacao
        tmrInit = New System.Timers.Timer(15000)
        AddHandler tmrInit.Elapsed, AddressOf TrataTmrInit
        tmrInit.Enabled = True

        KbPastGrava.basLog.LogAdd("OnStart fim")

    End Sub

    Protected Overrides Sub OnStop()

        KbPastGrava.basLog.LogAdd("OnStop ini")

        Past.Parar()
        Past = Nothing

        KbPastGrava.basLog.LogAdd("OnStop fim")

    End Sub

End Class
