Public Class KbSrvIniService

    Dim Ini As KbSrvIni.clsChkIni
    Dim tmrInit As System.Timers.Timer

    Private Sub TrataTmrInit(ByVal sender As Object, ByVal e As System.Timers.ElapsedEventArgs)

        KbSrvIni.basLog.LogAdd("TrataTmrInit ini")

        tmrInit.Enabled = False

        Geral.DllInit()

        Ini = New KbSrvIni.clsChkIni
        Ini.Iniciar()

        KbSrvIni.basLog.LogAdd("TrataTmrInit fim")

    End Sub

    Protected Overrides Sub OnStart(ByVal args() As String)

        KbSrvIni.basLog.LogAdd("OnStart ini")

        'Dispara timer para retardo na inicializacao
        tmrInit = New System.Timers.Timer(15000)
        AddHandler tmrInit.Elapsed, AddressOf TrataTmrInit
        tmrInit.Enabled = True

        KbSrvIni.basLog.LogAdd("OnStart fim")

    End Sub

    Protected Overrides Sub OnStop()

        KbSrvIni.basLog.LogAdd("OnStop ini")

        Ini.Parar()
        Ini = Nothing

        KbSrvIni.basLog.LogAdd("OnStop fim")

    End Sub

End Class
