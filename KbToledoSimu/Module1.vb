Imports System.Net.Sockets
Imports System.Net
Imports System.Text

Module Module1

    Sub Main()

        'Precisa estar escutando na porta correta , tem que ser a mesma porta na qual o cliente vai usar
        Dim NumIp As IPAddress = IPAddress.Parse("127.0.0.1")
        
        Dim ServerSocket As New TcpListener(NumIp, 9999)
        Dim ClientSocket As TcpClient = Nothing
        Dim Contador As Integer

        ServerSocket.Start()
        Console.WriteLine("Servidor inicializado. Aguardando conexão...")

        Contador = 0

        While (True)

            Contador += 1

            'Aceita a conexao do cliente e retorna uma inicializacao TcpClient 
            ClientSocket = ServerSocket.AcceptTcpClient()
            Console.WriteLine(Convert.ToString(Contador) + " Cliente Conectado!")

            Dim Cliente As New TrataCliente
            Cliente.IniciarCliente(ClientSocket, Convert.ToString(Contador))

        End While

        'Fecha ServerSocket(TcpListener) e ClientSocket(TcpClient).
        ClientSocket.Close()
        ServerSocket.Stop()
        Console.WriteLine("encerrado.")
        Console.ReadLine()

    End Sub

    Public Class TrataCliente


        '====================================
        Dim TestCom As String = ""
        Dim Info As String = ""
        Dim ArtNames As String = ""
        Dim Senden As String = ""
        Dim Hist As String = ""
        Dim Prod As String = ""

        Dim Dados As Integer = 0
        Dim BytesCli() As Byte = Nothing
        Dim ServidorResp As String = ""
        '====================================

        Dim ClientSocket As TcpClient
        Dim ClNo As String

        Public Sub IniciarCliente(ByVal SocketClient As TcpClient, ByVal Cli As String)

            Me.ClientSocket = SocketClient
            Me.ClNo = Cli
            Dim NwThread As Threading.Thread = New Threading.Thread(AddressOf Com)
            NwThread.Start()

        End Sub

        Private Sub Com()

            Dim ContaReq As Integer
            Dim BytesCliente(ClientSocket.ReceiveBufferSize) As Byte
            Dim DadosCliente As String = ""
            Dim DadosCli As String = ""
            Dim EnviaBytes As [Byte]() = Nothing
            Dim RespServidor As String = ""
            Dim Conta As String = ""


            ContaReq = 0

            While (True)

                Try

                    ContaReq = ContaReq + 1

                    'Obtem o stream
                    Dim NetworkStream As NetworkStream = ClientSocket.GetStream()

                    'Le o stream em um array de bytes
                    NetworkStream.Read(BytesCliente, 0, CInt(ClientSocket.ReceiveBufferSize))
                    BytesCli = Nothing
                    BytesCli = BytesCliente

                    'Retorna os dados recebidos do cliente para o console
                    DadosCliente = System.Text.Encoding.ASCII.GetString(BytesCliente)
                    Dados = DadosCliente.Length
                    MontaNwCmd() 'Monta o Cmd novamente excluindo o CR, LF
                    DadosCli = System.Text.Encoding.ASCII.GetString(BytesCli)
                    Console.WriteLine("Cliente enviou : " + DadosCli + ClNo)

                    Conta = Convert.ToString(ContaReq)
                    SelCmd(DadosCli, Conta)

                    'Qualquer comunicacao com o cliente remoto usando o TcpClient pode comecar aqui
                    RespServidor = ServidorResp
                    EnviaBytes = Encoding.ASCII.GetBytes(RespServidor)

                    NetworkStream.Write(EnviaBytes, 0, EnviaBytes.Length)
                    'NetworkStream.Flush()
                    Console.WriteLine(RespServidor)

                Catch ex As Exception
                    MsgBox(ex.ToString)
                End Try

            End While


        End Sub

        Private Sub SelCmd(Optional ByVal CliDados As String = " ", _
                           Optional ByVal Conta As Integer = 0)


            Select Case CliDados

                Case "WD_TEST"

                    RespTest()
                    ServidorResp = TestCom & "(" + ClNo + ")" + Conta

                Case "FB_INFO"

                    RespInfo()
                    ServidorResp = Info & "(" + ClNo + ")" + Conta

                Case "FB_ART_NAMES"

                    RespArtNames()
                    ServidorResp = ArtNames & "(" + ClNo + ")" + Conta

                Case "FB_SENDEN"

                    RespSenden()
                    ServidorResp = Senden & "(" + ClNo + ")" + Conta

                Case "FB_ABLAGEN MINI ESKIBON 104 G"

                    RespHist()
                    ServidorResp = Hist & "(" + ClNo + ")" + Conta

                    'Case "FB_PD +*"
                Case "FB_PD + MINI ESKIBON 104 G"
                    RespProd()
                    ServidorResp = Prod & "(" + ClNo + ")" + Conta

            End Select

        End Sub

        Private Sub MontaNwCmd()

            'Busca a posição do indicador de fim da mensagem
            Dim Conta As Integer = -1
            Dim FimCmd As Integer = 0
            Dim CliBytes As Byte = Nothing

            While CliBytes <> 10

                Conta = Conta + 1
                CliBytes = BytesCli(Conta)

                If CliBytes = 10 Then
                    'Guarda o índice do LF
                    FimCmd = Conta
                End If

            End While

            'Monta o comando recebido excluindo o CR, LF
            'Pega o valor de fim da mensagem (índice) e subtrai por 2 (CR+LF)
            Dim QtdElem As Integer = FimCmd - 2

            'Cria um novo array cujo tamanho é o resultado da operacao anterior
            Dim NwBytes() As Byte
            NwBytes = New Byte(0 To QtdElem) {}

            'Copia os valores do array original para o novo array
            Array.Copy(BytesCli, 0, NwBytes, 0, QtdElem + 1)
            BytesCli = NwBytes

            'Converte apenas para visualização
            Dim NwCmd As String = System.Text.Encoding.ASCII.GetString(NwBytes)


        End Sub

        Private Sub RespTest()

            TestCom = "WD_OK"

        End Sub

        Private Sub RespInfo()

            Info = "FB_INF 35004673  S G"

        End Sub

        Private Sub RespArtNames()

            ArtNames = "FB_AN Default" & _
                                     "FB_AN MINI ESKIBON 104 G" & _
                                     "FB_AN NONAME" & _
                                     "FB_AN_ENDE"

        End Sub

        Private Sub RespSenden()

            Senden = "FB_GRUND 01.10 MINI ESKIBON 104 G                        0" & _
                        "FB_DATA 104.0    11.6     110  5    200  ---- 1.002000 100  -------- -" & _
                        "FB_GLEIT 104.0    200.0    13.5     0.0      104.0    0    99   0.0" & _
                        "FB_ZONES 1 1 M.M.ALTO - 1 M.Alto   - 1 ALTO OK  - 1 NOMINAL  1 1 Baixo" & _
                        "FB_STAT            -------- -------- 104.0    104.0    0    1    1    60   1" & _
                        "FB_STAT2 2.00     - 1 - - 0 0 0" & _
                        "FB_ENDE"

        End Sub

        Private Sub RespHist()

            Hist = "FB_ABL 1  13:34 18.10.13 14:36 18.10.13 78       106.84   0.00" & _
                                "FB_ABL 2  04:32 12.10.13 06:26 12.10.13 109      117.65   0.00" & _
                                "FB_ABL 3  03:32 12.10.13 04:32 12.10.13 686      125.83   0.00" & _
                                "FB_ABL 4  02:31 12.10.13 03:31 12.10.13 1557     125.55   0.00" & _
                                "FB_ABL 102 18:45 07.10.13 19:45 07.10.13 2518     119.99   0.00" & _
                                "FB_ABL 6  00:31 12.10.13 01:31 12.10.13 1748     126.45   0.00" & _
                                "FB_ABL 7  23:31 11.10.13 00:31 12.10.13 1815     124.10   0.00" & _
                                "FB_ABL 8  22:30 11.10.13 23:30 11.10.13 1632     127.29   0.00" & _
                                "FB_ABL 9  21:30 11.10.13 22:30 11.10.13 1982     122.33   0.00" & _
                                "FB_ABL 10 20:30 11.10.13 21:30 11.10.13 2235     122.29   0.00" & _
                                "FB_ABL 11 19:30 11.10.13 20:30 11.10.13 2010     122.57   0.00" & _
                                "FB_ABL 12 18:30 11.10.13 19:30 11.10.13 1059     122.77   0.00" & _
                                "FB_ABL 13 17:30 11.10.13 18:30 11.10.13 1301     125.23   0.00" & _
                                "FB_ABL 14 16:30 11.10.13 17:30 11.10.13 2256     124.80   0.00" & _
                                "FB_ABL 15 15:30 11.10.13 16:30 11.10.13 2622     124.76   0.00" & _
                                "FB_ABL 16 14:30 11.10.13 15:30 11.10.13 2463     122.15   0.00" & _
                                "FB_ABL 17 13:30 11.10.13 14:30 11.10.13 2291     125.50   0.00" & _
                                "FB_ABL 18 12:30 11.10.13 13:30 11.10.13 2482     124.41   0.00" & _
                                "FB_ABL 19 11:30 11.10.13 12:30 11.10.13 2245     123.20   0.00" & _
                                "FB_ABL 20 10:25 11.10.13 11:25 11.10.13 1984     123.99   0.00" & _
                                "FB_ABL 21 09:25 11.10.13 10:25 11.10.13 1836     126.13   0.00" & _
                                "FB_ABL 22 08:25 11.10.13 09:25 11.10.13 2535     123.10   0.00" & _
                                "FB_ABL 23 07:25 11.10.13 08:25 11.10.13 2560     124.21   0.00" & _
                                "FB_ABL 24 06:25 11.10.13 07:25 11.10.13 2436     125.02   0.00" & _
                                "FB_ABL 25 05:25 11.10.13 06:25 11.10.13 2422     124.12   0.00" & _
                                "FB_ABL 26 04:25 11.10.13 05:25 11.10.13 2403     123.82   0.00" & _
                                "FB_ABL 27 03:25 11.10.13 04:25 11.10.13 2359     124.13   0.00" & _
                                "FB_ABL 28 02:25 11.10.13 03:25 11.10.13 2426     124.21   0.00" & _
                                "FB_ABL 29 01:25 11.10.13 02:25 11.10.13 2212     123.99   0.00" & _
                                "FB_ABL 30 00:25 11.10.13 01:25 11.10.13 2454     123.98   0.00" & _
                                "FB_ABL 31 23:25 10.10.13 00:25 11.10.13 2278     122.02   0.00" & _
                                "FB_ABL 32 22:25 10.10.13 23:25 10.10.13 1760     121.98   0.00" & _
                                "FB_ABL 33 21:25 10.10.13 22:25 10.10.13 2346     122.99   0.00" & _
                                "FB_ABL 34 20:25 10.10.13 21:25 10.10.13 2350     124.07   0.00" & _
                                "FB_ABL 35 19:25 10.10.13 20:25 10.10.13 2529     122.89   0.00" & _
                                "FB_ABL 36 18:25 10.10.13 19:25 10.10.13 2468     123.88   0.00" & _
                                "FB_ABL 37 17:25 10.10.13 18:25 10.10.13 283      122.00   0.00" & _
                                "FB_ABL 38 16:25 10.10.13 17:25 10.10.13 365      121.23   0.00" & _
                                "FB_ABL 39 15:25 10.10.13 16:25 10.10.13 2031     121.32   0.00" & _
                                "FB_ABL 40 14:25 10.10.13 15:25 10.10.13 2034     121.59   0.00" & _
                                "FB_ABL 41 13:25 10.10.13 14:25 10.10.13 2049     122.28   0.00" & _
                                "FB_ABL 42 12:25 10.10.13 13:25 10.10.13 2251     124.61   0.00" & _
                                "FB_ABL 43 11:25 10.10.13 12:25 10.10.13 2349     120.98   0.00" & _
                                "FB_ABL 44 10:25 10.10.13 11:25 10.10.13 2365     120.61   0.00" & _
                                "FB_ABL 45 09:25 10.10.13 10:25 10.10.13 2411     122.84   0.00" & _
                                "FB_ABL 46 08:25 10.10.13 09:25 10.10.13 2311     124.41   0.00" & _
                                "FB_ABL 47 07:25 10.10.13 08:25 10.10.13 2392     120.60   0.00" & _
                                "FB_ABL 48 06:25 10.10.13 07:25 10.10.13 2542     121.11   0.00" & _
                                "FB_ABL 49 05:25 10.10.13 06:25 10.10.13 2403     124.20   0.00" & _
                                "FB_ABL 50 04:25 10.10.13 05:25 10.10.13 1799     127.43   0.00" & _
                                "FB_ABL 51 03:24 10.10.13 04:24 10.10.13 2166     121.38   0.00" & _
                                "FB_ABL 52 02:24 10.10.13 03:24 10.10.13 2106     123.93   0.00" & _
                                "FB_ABL 53 01:24 10.10.13 02:24 10.10.13 2262     122.97   0.00" & _
                                "FB_ABL 54 00:24 10.10.13 01:24 10.10.13 2246     125.06   0.00" & _
                                "FB_ABL 55 23:24 09.10.13 00:24 10.10.13 2077     125.03   0.00" & _
                                "FB_ABL 56 22:24 09.10.13 23:24 09.10.13 2431     122.89   0.00" & _
                                "FB_ABL 57 21:24 09.10.13 22:24 09.10.13 2228     124.75   0.00" & _
                                "FB_ABL 58 20:23 09.10.13 21:23 09.10.13 2467     123.57   0.00" & _
                                "FB_ABL 59 19:23 09.10.13 20:23 09.10.13 959      119.24   0.00" & _
                                "FB_ABL 60 18:23 09.10.13 19:23 09.10.13 1909     119.24   0.00" & _
                                "FB_ABL 61 17:23 09.10.13 18:23 09.10.13 2398     125.57   0.00" & _
                                "FB_ABL 62 16:23 09.10.13 17:23 09.10.13 2336     123.73   0.00" & _
                                "FB_ABL 63 15:23 09.10.13 16:23 09.10.13 2299     121.29   0.00" & _
                                "FB_ABL 64 14:23 09.10.13 15:23 09.10.13 2331     122.09   0.00" & _
                                "FB_ABL 65 13:23 09.10.13 14:23 09.10.13 2430     118.39   0.00" & _
                                "FB_ABL 66 12:23 09.10.13 13:23 09.10.13 2397     121.84   0.00" & _
                                "FB_ABL 67 11:23 09.10.13 12:23 09.10.13 2515     121.52   0.00" & _
                                "FB_ABL 68 10:23 09.10.13 11:23 09.10.13 2369     116.78   0.00" & _
                                "FB_ABL 69 09:23 09.10.13 10:23 09.10.13 2411     121.85   0.00" & _
                                "FB_ABL 70 08:23 09.10.13 09:23 09.10.13 2344     121.58   0.00" & _
                                "FB_ABL 71 07:23 09.10.13 08:23 09.10.13 2439     120.35   0.00" & _
                                "FB_ABL 72 06:23 09.10.13 07:23 09.10.13 2379     121.97   0.00" & _
                                "FB_ABL 73 05:23 09.10.13 06:23 09.10.13 2333     121.81   0.00" & _
                                "FB_ABL 74 04:23 09.10.13 05:23 09.10.13 2404     122.35   0.00" & _
                                "FB_ABL 75 03:23 09.10.13 04:23 09.10.13 2269     123.48   0.00" & _
                                "FB_ABL 76 02:23 09.10.13 03:23 09.10.13 1751     122.60   0.00" & _
                                "FB_ABL 77 01:10 09.10.13 02:10 09.10.13 1067     129.31   0.00" & _
                                "FB_ABL 78 00:10 09.10.13 01:10 09.10.13 1210     123.24   0.00" & _
                                "FB_ABL 79 23:10 08.10.13 00:10 09.10.13 1377     127.76   0.00" & _
                                "FB_ABL 80 16:52 08.10.13 17:52 08.10.13 612      125.13   0.00" & _
                                "FB_ABL 81 15:52 08.10.13 16:52 08.10.13 2454     124.32   0.00" & _
                                "FB_ABL 82 14:52 08.10.13 15:52 08.10.13 1217     120.47   0.00" & _
                                "FB_ABL 83 13:52 08.10.13 14:52 08.10.13 2215     118.45   0.00" & _
                                "FB_ABL 84 12:52 08.10.13 13:52 08.10.13 2535     122.47   0.00" & _
                                "FB_ABL 85 11:52 08.10.13 12:52 08.10.13 2422     119.92   0.00" & _
                                "FB_ABL 86 11:01 08.10.13 11:51 08.10.13 1910     120.35   0.00" & _
                                "FB_ABL 87 10:01 08.10.13 11:01 08.10.13 2331     120.01   0.00" & _
                                "FB_ABL 88 09:01 08.10.13 10:01 08.10.13 2427     120.07   0.00" & _
                                "FB_ABL 89 08:01 08.10.13 09:01 08.10.13 2514     117.58   0.00" & _
                                "FB_ABL 90 07:01 08.10.13 08:01 08.10.13 2127     124.74   0.00" & _
                                "FB_ABL 91 06:01 08.10.13 07:01 08.10.13 2437     122.62   0.00" & _
                                "FB_ABL 92 05:01 08.10.13 06:01 08.10.13 2369     122.36   0.00" & _
                                "FB_ABL 93 04:01 08.10.13 05:01 08.10.13 2418     121.35   0.00" & _
                                "FB_ABL 94 03:01 08.10.13 04:01 08.10.13 2031     124.11   0.00" & _
                                "FB_ABL 95 02:01 08.10.13 03:01 08.10.13 1822     122.66   0.00" & _
                                "FB_ABL 96 00:45 08.10.13 01:45 08.10.13 1012     126.02   0.00" & _
                                "FB_ABL 97 23:45 07.10.13 00:45 08.10.13 2188     123.72   0.00" & _
                                "FB_ABL 98 22:45 07.10.13 23:45 07.10.13 2394     121.62   0.00" & _
                                "FB_ABL 99 21:45 07.10.13 22:45 07.10.13 2194     122.34   0.00" & _
                                "FB_ABL 100 20:45 07.10.13 21:45 07.10.13 2259     118.96   0.00" & _
                                "FB_ABL 101 19:45 07.10.13 20:45 07.10.13 2423     121.12   0.00" & _
                                "FB_ABL 102 18:45 07.10.13 19:45 07.10.13 2518     119.99   0.00" & _
                                "FB_ABL 103 17:45 07.10.13 18:45 07.10.13 2364     121.58   0.00" & _
                                "FB_ABL 104 16:45 07.10.13 17:45 07.10.13 2553     123.06   0.00" & _
                                "FB_ABL 105 15:45 07.10.13 16:45 07.10.13 2156     123.74   0.00" & _
                                "FB_ABL 106 14:45 07.10.13 15:45 07.10.13 342      126.58   0.00" & _
                                "FB_ABL 107 13:40 07.10.13 14:40 07.10.13 1009     123.27   0.00" & _
                                "FB_ABL 108 12:40 07.10.13 13:40 07.10.13 2422     124.57   0.00" & _
                                "FB_ABL 109 11:40 07.10.13 12:40 07.10.13 2419     123.92   0.00" & _
                                "FB_ABL 110 10:40 07.10.13 11:40 07.10.13 2525     124.17   0.00" & _
                                "FB_ABL 111 09:40 07.10.13 10:40 07.10.13 2620     123.13   0.00" & _
                                "FB_ABL 112 08:40 07.10.13 09:40 07.10.13 2397     121.37   0.00" & _
                                "FB_ABL 113 07:40 07.10.13 08:40 07.10.13 2354     120.18   0.00" & _
                                "FB_ABL 114 06:40 07.10.13 07:40 07.10.13 2325     118.62   0.00" & _
                                "FB_ABL 115 05:40 07.10.13 06:40 07.10.13 2201     122.87   0.00" & _
                                "FB_ABL 116 04:40 07.10.13 05:40 07.10.13 1988     121.73   0.00" & _
                                "FB_ABL 117 03:40 07.10.13 04:40 07.10.13 1768     120.79   0.00" & _
                                "FB_ABL 118 02:40 07.10.13 03:40 07.10.13 1997     122.17   0.00" & _
                                "FB_ABL 119 01:40 07.10.13 02:40 07.10.13 1839     122.88   0.00" & _
                                "FB_ABL 120 00:40 07.10.13 01:40 07.10.13 903      121.33   0.00" & _
                                "FB_ABL 121 23:40 06.10.13 00:40 07.10.13 1647     129.24   0.00" & _
                                "FB_ABL 122 21:05 07.09.13 08:31 01.01.13 8759     121.12   0.00" & _
                                "FB_ABL 123 23:16 29.09.13 23:40 06.10.13 319779   121.37   0.00" & _
                                "FB_ABL 124 09:18 25.09.13 16:52 27.09.13 8820     116.90   0.00" & _
                                "FB_ABL 125 16:50 19.09.13 23:16 29.09.13 255042   121.10   0.00" & _
                                "FB_ABL 126 05:34 19.09.13 18:56 19.09.13 213      106.78   0.00" & _
                                "FB_ABL 127 05:34 28.12.13 10:40 19.09.13 213      106.78   0.00" & _
                                "FB_ABL_ENDE"

        End Sub

        Private Sub RespProd()

            'Prod = "FB_PD_PLUS -------- -------- -------- 0        0.000    0.0      0        0.000" & _
            '                    "   0.0 " & _
            '                    "FB_PD_GUT 0        0.000    0.0      0        0" & _
            '                    "FB_PD_MINUS 0        0.000    0.0      0        0.000    0.0      -------- -----" & _
            '                    "--- --------" & _
            '                    "FB_PD_STAT 05.11.2013 08:57 MINI ESKIBON 104 G              104.0    11.6     0" & _
            '                    "       0        0.00     0.00     104.0    0        0.00     104.0    0" & _
            '                    "FB_PD_AKTINT 18.10.2013 13:27 78       21       106.84   2.23     104.0    0" & _
            '                    "    0.00     104.0    0" & _
            '                    "FB_PD_LASTINT 18.10.2013 13:27 78       21       106.84   2.23     104.0    0" & _
            '                    "     0.00     104.0    0" & _
            '                    "FB_PD_CHARGE 05.11.2013 08:57            0        0        0.00     0.00     104" & _
            '                    ".0    0        0.00     104.0    0" & _
            '                    "FB_PD_LASTCHR 08.10.2013 11:52 ---------- 173098   4972     123.03   10.84    10" & _
            '                    "4.0    0        0.00     104.0    0" & _
            '                    "FB_ERR_NO_CURRENT_HOUR" & _
            '                    "FB_PD_LASTHR 18.10.2013 13:34 MINI ESKIBON 104 G              104.0    11.6" & _
            '                    "78       21       106.84   2.23     104.0    0        0.00     104.0    0" & _
            '                    "" & _
            '                    "FB_SD_STAT  0        0        0        0" & _
            '                    "FB_SD_AKTINT  0        21       0        0" & _
            '                    "FB_SD_LASTINT  0        21       0        0" & _
            '                    "FB_SD_CHARGE  0        0        0        0" & _
            '                    "FB_SD_LASTCHR  0        4972     0        0" & _
            '                    "FB_ERR_NO_CURRENT_HOUR" & _
            '                    "FB_SD_LASTHR  0        21       0        0" & _
            '                    "FB_PD_TACHO  0    140  200  260" & _
            '                    "FB_ENDE"


            Prod = "FB_PD_PLUS -------- -------- -------- 0        0.000    0.0      0        0.000" & _
                    "  0.0" & _
                    "FB_PD_GUT 0        0.000    0.0      0        0" & _
                    "FB_PD_MINUS 0        0.000    0.0      0        0.000    0.0      -------- -----" & _
                    "--- --------" & _
                    "FB_PD_STAT 05.11.2013 08:55 MINI ESKIBON 104 G              104.0    11.6     0" & _
                    "0        0.00     0.00     104.0    0        0.00     104.0    0" & _
                    "FB_PD_AKTINT 18.10.2013 13:27 78       21       106.84   2.23     104.0    0" & _
                    "0.00     104.0    0" & _
                    "FB_PD_LASTINT 18.10.2013 13:27 78       21       106.84   2.23     104.0    0" & _
                    "0.00     104.0    0" & _
                    "FB_PD_CHARGE 05.11.2013 08:55            0        0        0.00     0.00     104" & _
                    ".0    0        0.00     104.0    0" & _
                    "FB_PD_LASTCHR 08.10.2013 11:52 ---------- 173098   4972     123.03   10.84    10" & _
                    "4.0    0        0.00     104.0    0" & _
                    "FB_ERR_NO_CURRENT_HOUR" & _
                    "FB_ENDE"

        End Sub


    End Class


End Module
