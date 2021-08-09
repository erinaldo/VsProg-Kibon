Public Class clsChk
    Implements clsIChk

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
        ChkD = New clsChkD

    End Sub

    Sub TrdTrata()

        'Try
        Static HoraAnt As Integer = -1

        While TrdRun = True

            'Busca contadores dos serviços do banco de dados Ranges
            LeContaD()

            'Check Erro
            ChkErro()

            'Trata Erro
            TrataErro()

            Thread.Sleep(5000)

        End While

    End Sub

    Function LeContaD() As Boolean

        'Busca contadores dos serviços do banco de dados Ranges
        Dim DbRn As New Geral.nsRanges.dcRanges
        Dim dtSc = (From It In DbRn.SrvChk).ToList

        For Each Sc In dtSc

            'Verifica se este item já está nos Dados
            Dim ServNome As String = Sc.Item
            Dim Dd = (From It In ChkD.Dados Where It.ServNome = ServNome Order By It.ServNome).ToList

            If Dd.Count <= 0 Then

                'Novo item
                Dim NwDd As New clsChkDIt(ServNome, Sc.ContaD)
                ChkD.Dados.Add(NwDd)

            Else

                'Atualiza
                Dd.First.ContaD = Sc.ContaD

            End If

        Next

        Return True

    End Function

    Function ChkErro() As Boolean

        For Each Dd In ChkD.Dados

            If Dd.ContaD = Dd.ContaDAnt Then

                'O serviço não está atualizando o contador, pode estar com bug
                Dd.ContaErro = Dd.ContaErro + 1

            Else

                'O serviço está alterando o contador, não tem erro
                Dd.ContaErro = 0

            End If

            Dd.ContaDAnt = Dd.ContaD

        Next

        Return True

    End Function

    Function TrataErro() As Boolean

        For Each Dd In ChkD.Dados

            Dd.Sc.Refresh()

            If Dd.Sc.Status = ServiceControllerStatus.Stopped Then

                'O serviço está parado, partir
                'LogAdd(" Service Start " & Dd.ServNome)
                'Dd.ContaErro = 0
                'Try
                '    Dd.Sc.Start()
                'Catch : End Try

            ElseIf Dd.ContaErro = (60 / 5) Then

                'O serviço está a 60 segundos em erro, parar o serviço
                LogAdd(" Service Stop " & Dd.ServNome)
                Try
                    Dd.Sc.Stop()
                Catch : End Try

            ElseIf Dd.ContaErro >= (90 / 5) Then

                'O serviço está em erro a 90 segundos ou mais, matar o processo
                LogAdd(" Service Kill " & Dd.ServNome)
                Dd.ContaErro = 0

                Dim localByName As Process() = Process.GetProcessesByName(Dd.ServNome & "Srv")
                For Each Pr In localByName
                    Try
                        Pr.Kill()
                    Catch : End Try
                Next

            End If

        Next

        Return True

    End Function

    Public Function BuscaDados() As clsChkD Implements clsIChk.BuscaDados
        Return ChkD
    End Function

End Class

<ServiceContract()> _
Public Interface clsIChk

    <OperationContract()> _
    Function BuscaDados() As clsChkD

End Interface