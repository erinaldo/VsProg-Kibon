Public Class clsObtemIP

    Shared Function ObtemEnderecoIP(ByRef myIPComputer As List(Of String)) As Boolean

        Dim myIpList As List(Of String) = Nothing

        Dim myHostName As String = System.Net.Dns.GetHostName

        Dim myHost As IPHostEntry = System.Net.Dns.GetHostEntry(myHostName)

        For Conta As Integer = 0 To myHost.AddressList.Length - 1
            myIpList.Add(myHost.AddressList(Conta).ToString)
        Next

        myIPComputer = myIpList

        Return True

    End Function

    Shared Function VerificaIP(ByVal IpServer As String) As Boolean

        Dim myHostName As String = System.Net.Dns.GetHostName

        Dim myHost As IPHostEntry = System.Net.Dns.GetHostEntry(myHostName)

        Dim myPesq As Boolean = False

        For Conta As Integer = 0 To myHost.AddressList.Length - 1

            Dim myIP As String = myHost.AddressList(Conta).ToString

            If myIP.ToUpper = IpServer.ToUpper Then

                myPesq = True

            End If

        Next

        Return myPesq

    End Function

End Class
