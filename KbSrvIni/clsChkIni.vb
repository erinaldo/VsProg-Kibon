Public Class clsChkIni
    Implements clsIChkIni

    Dim Trd As Thread
    Dim TrdRun As Boolean = False

    Public Sub Iniciar()

        LogAdd("Iniciar...")
        InicializaDados()

        Trd = New Thread(AddressOf TrdTrata)
        TrdRun = True
        Trd.Start()

        LogAdd("Iniciado.")

    End Sub

    Public Sub Parar()

        LogAdd("Parar...")

        TrdRun = False
        Trd.Join()

        LogAdd("Parado.")

    End Sub

    Private Sub InicializaDados()

        'PlanejD
        ChkD = New clsChkIniD

        ChkD.Dados.Add(New clsChkIniDIt("KbCipPlanejCtrl"))
        ChkD.Dados.Add(New clsChkIniDIt("KbMatGrava"))
        ChkD.Dados.Add(New clsChkIniDIt("KbMistGrava"))
        ChkD.Dados.Add(New clsChkIniDIt("KbPastGrava"))
        ChkD.Dados.Add(New clsChkIniDIt("KbProdPlanejCtrl"))
        ChkD.Dados.Add(New clsChkIniDIt("KbSrvChk"))

    End Sub

    Sub TrdTrata()

        'Try
        Static HoraAnt As Integer = -1

        While TrdRun = True

            'Check Erro
            ChkErro()

            'Trata Erro
            TrataErro()

            Thread.Sleep(5000)

        End While

    End Sub

    Function ChkErro() As Boolean

        For Each Dd In ChkD.Dados

            If Dd.Sc.Status = ServiceControllerStatus.Stopped Then

                'O serviço não está ativo, conta o erro
                Dd.ContaErro = Dd.ContaErro + 1

            Else

                'O serviço está ativo, não tem erro
                Dd.ContaErro = 0

            End If

        Next

        Return True

    End Function

    Function TrataErro() As Boolean

        For Each Dd In ChkD.Dados

            Dd.Sc.Refresh()

            If Dd.ContaErro >= 2 Then

                'O serviço está parado, partir
                LogAdd(" Service Start " & Dd.ServNome)
                Dd.ContaErro = 0
                Try
                    Dd.Sc.Start()
                Catch : End Try

            End If

        Next

        Return True

    End Function

    Public Function BuscaDados() As clsChkIniD Implements clsIChkIni.BuscaDados
        Return ChkD
    End Function

End Class

<ServiceContract()> _
Public Interface clsIChkIni

    <OperationContract()> _
    Function BuscaDados() As clsChkIniD

End Interface