Public Class KbSrvChkService

    Dim Chk As KbSrvChk.clsChk
    Dim tmrInit As System.Timers.Timer

    Private Sub TrataTmrInit(ByVal sender As Object, ByVal e As System.Timers.ElapsedEventArgs)

        KbSrvChk.basLog.LogAdd("TrataTmrInit ini")

        tmrInit.Enabled = False

        Geral.DllInit()

        Chk = New KbSrvChk.clsChk
        Chk.Iniciar()

        KbSrvChk.basLog.LogAdd("TrataTmrInit fim")

    End Sub

    Protected Overrides Sub OnStart(ByVal args() As String)

        KbSrvChk.basLog.LogAdd("OnStart ini")

        'Dispara timer para retardo na inicializacao
        tmrInit = New System.Timers.Timer(15000)
        AddHandler tmrInit.Elapsed, AddressOf TrataTmrInit
        tmrInit.Enabled = True

        KbSrvChk.basLog.LogAdd("OnStart fim")

    End Sub

    Protected Overrides Sub OnStop()

        KbSrvChk.basLog.LogAdd("OnStop ini")

        Chk.Parar()
        Chk = Nothing

        KbSrvChk.basLog.LogAdd("OnStop fim")

    End Sub


End Class
