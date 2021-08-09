Imports System.Net.Sockets
Imports System.Net
Imports System.Text

Public Module basComTcpIp

    Public NumIp As String = ""
    Public NumPorta As Integer = 0

    Public ClientSocket As New TcpClient()
    Public ServerStream As NetworkStream

    Public CmdTestCom As String = ""
    Public CmdMaqinfo As String = ""
    Public CmdArtNames As String = ""
    Public CmdSenden As String = ""
    Public CmdHistDados As String = ""
    Public CmdProdDados As String = ""

    Public Const Resp As String = "WD_OK"

    Public Const CR As Char = Chr(13) '<CR> = 0DHex = carriage return
    Public Const LF As Char = Chr(10) '<LF> = 0AHex = line feed

    Public FlagConecta As Boolean = False
    Public FlagCom As Boolean = False

    Public ContaCmd As Integer = 0
    Public Comando As String = ""

    Public ComD As clsComD
    Public serviceHost As New ServiceHost(GetType(clsCom))

End Module

Public Class clsCom
    Implements clsICom

    Dim TrdCtrl As Thread
    Dim TrdCtrlRun As Boolean = False

    Dim Trata As clsTrataDados
    Dim Grava As clsGravaDados

    Public Sub Inicia()

        ComD = New clsComD

        'Dispara a task de solicitação de dados para o equipamento
        TrdCtrl = New Thread(AddressOf trdCom)

        Conecta(NumIp, NumPorta)

        'Testa conexão
        If FlagConecta = True Then

            TestCom()
            'Testa conectividade
            If FlagCom = True Then

                TrdCtrlRun = True
                TrdCtrl.Start()


            Else
                'MsgBox("Erro: Falha na comunicação", vbExclamation)
            End If

        Else
            'MsgBox("Erro: Falha na conexão.", vbExclamation)
        End If

        'Inicia serviço Wcf (servidor de dados via Http)
        Try
            serviceHost.Open()
        Catch
        End Try

    End Sub

    Public Sub Para()

        'Para serviço Wcf (servidor de dados via Http)
        serviceHost.Close()

        TrdCtrlRun = False
        TrdCtrl.Join()
        Desconecta()

    End Sub

    Private Sub trdCom()

        Do While TrdCtrlRun = True
            'Envia solicitação de dados
            'EnviaCmd()
            Trata = New clsTrataDados
            Grava = New clsGravaDados
            Contador()

            'trata os dados
            'Trata = New Geral.clsTrataDados
            'Trata.TrataResp()

            Thread.Sleep(5000)

        Loop

    End Sub

    Public Function Conecta(Optional ByVal EndIp As String = "", Optional ByVal Porta As Integer = 0) As Boolean


        Dim dtCadCfg As List(Of Geral.CadCfg)
        Dim Ck As New Geral.dcToledo

        dtCadCfg = (From It In Ck.CadCfg Where It.Cfg = "IP").ToList
        If dtCadCfg.Count <= 0 Then Return False
        NumIp = dtCadCfg.First.Valor

        dtCadCfg = (From It In Ck.CadCfg Where It.Cfg = "Porta").ToList
        If dtCadCfg.Count <= 0 Then Return False
        NumPorta = dtCadCfg.First.Valor

        Try
            'Conecta no Socket especificado
            ClientSocket.Connect(NumIp, NumPorta)
            FlagConecta = True
        Catch

            FlagConecta = False
        End Try

        Return True

    End Function

    Public Function TestCom() As Boolean

        'Comando que testa comunicação: WD_TEST
        'Resposta de comunicação OK: WD_OK

        'Le o comando do DB
        Dim dtCadCfg As List(Of Geral.CadCfg)
        Dim Ck As New Geral.dcToledo

        dtCadCfg = (From It In Ck.CadCfg Where It.Cfg = "CmdTestCom").ToList
        If dtCadCfg.Count <= 0 Then Return False
        CmdTestCom = dtCadCfg.First.Valor

        'Fornece fluxo de dados de acesso a rede
        Dim ServerStream As NetworkStream = ClientSocket.GetStream()

        Dim Buff As Integer
        Dim Cmd As String = CmdTestCom

        'Identifica o tamanho da mensagem a ser enviada para inseri-la no array de byte que será enviado para a porta
        Dim Qtd As Integer = Cmd.Length

        'Declara o array de byte a ser enviado com o tamanho do Texto a ser enviado somado ao CR, LF
        Dim CmdDeEnvio(Qtd + 1) As Byte

        'Insere o texto a ser enviado no array de envio
        For Conta As Integer = 0 To Qtd - 1

            'Converte os caracteres do texto a ser enviado em Byte 
            Dim Bytes As Byte = Convert.ToInt16(Cmd(Conta))

            'Escreve os caracteres convertidos em byte nas posições do array de envio
            CmdDeEnvio(Conta) = Bytes

        Next

        'Insere o CR na primeira posição após o término do texto no array de envio
        CmdDeEnvio(Qtd) = AscW(CR)

        'Insere o LF na segunda posição após o término do texto no Array de envio
        CmdDeEnvio(Qtd + 1) = AscW(LF)
        Dim CmdCli As Byte() = CmdDeEnvio

        Try

            'Executa escrita
            ServerStream.Write(CmdCli, 0, CmdCli.Length)
            ServerStream.Flush()


            Dim CliBytes(ClientSocket.ReceiveBufferSize) As Byte
            Buff = ClientSocket.ReceiveBufferSize

            'Le o NetworkStream em um buffer
            ServerStream.Read(CliBytes, 0, Buff)

            'Exibe os dados recebidos
            Dim Dados As String = System.Text.Encoding.ASCII.GetString(CliBytes)
            Dados = Dados.Substring(0, 5)

            If Dados = Resp Then
                'Comunicando...
                FlagCom = True
            Else
                'Comunicação falhou...
                Return False
            End If

            DadosCli = Cmd
            DadosServ = Dados

        Catch ex As Exception
            'MsgBox(ex.Message)
            Return False
        End Try

        Return True

    End Function

    Private Function Desconecta(Optional ByVal EndIp As String = "", Optional ByVal Porta As Integer = 0) As Boolean

        Try

            ClientSocket.Close()

            Return True

        Catch ex As Exception
            'MsgBox(ex.Message)
            Return False
        End Try


    End Function

    Private Function Contador() As Boolean

        For Conta As Integer = 1 To 5

            ContaCmd = ContaCmd + 1

            'Busca comandos de solicitação no banco de dados
            CmdDB()

            'Seleciona comando de solicitação de dados
            SelComando()

            'Envia solicitação de dados
            TrataCmd()
            EnviaCmd()

            'Trata os dados recebidos
            'Trata = New Geral.clsTrataDados
            Trata.TrataResp()

            'Salva os dados recebidos
            Grava.GravaDados()

            'If ComD.LeituraDadosPlc = True Then ComD.ContaD = ComD.ContaD + 1
            ComD.LeituraDadosPlc = True
            ComD.ContaD = ComD.ContaD + 1
            If ComD.ContaD > 9999 Then ComD.ContaD = 1

        Next

        ContaCmd = 0

        Return True

    End Function

    Private Function CmdDB()

        'Le o comando do DB
        Dim dtCadCfg As List(Of Geral.CadCfg)
        Dim Ck As New Geral.dcToledo


        dtCadCfg = (From It In Ck.CadCfg Where It.Cfg = "CmdMaqinfo").ToList
        If dtCadCfg.Count <= 0 Then Return False
        CmdMaqinfo = dtCadCfg.First.Valor

        dtCadCfg = (From It In Ck.CadCfg Where It.Cfg = "CmdArtNames").ToList
        If dtCadCfg.Count <= 0 Then Return False
        CmdArtNames = dtCadCfg.First.Valor

        dtCadCfg = (From It In Ck.CadCfg Where It.Cfg = "CmdSenden").ToList
        If dtCadCfg.Count <= 0 Then Return False
        CmdSenden = dtCadCfg.First.Valor

        dtCadCfg = (From It In Ck.CadCfg Where It.Cfg = "CmdHistDados").ToList
        If dtCadCfg.Count <= 0 Then Return False
        CmdHistDados = dtCadCfg.First.Valor

        dtCadCfg = (From It In Ck.CadCfg Where It.Cfg = "CmdProdDados").ToList
        If dtCadCfg.Count <= 0 Then Return False
        CmdProdDados = dtCadCfg.First.Valor

        Return True

    End Function

    Private Function SelComando() As String


        If ContaCmd = 1 Then
            Comando = CmdMaqinfo

        ElseIf ContaCmd = 2 Then
            Comando = CmdArtNames

        ElseIf ContaCmd = 3 Then
            Comando = CmdSenden

        ElseIf ContaCmd = 4 Then
            Comando = CmdHistDados

        ElseIf ContaCmd = 5 Then
            Comando = CmdProdDados

        Else
            Comando = ""
        End If

        Return Comando

    End Function

    Private Function EnviaCmd(Optional ByVal CmdDB As String = "") As Boolean

        'Comando = "FB_SENDEN"
        'Comando = "FB_ABLAGEN"

        '(CR)(LF)
        'CR - Carriage Return (ASCII HEX 0Dh) 
        'LF - Line Feed (ASCII HEX 0Ah) 
        'Estes dois caracteres indicam o término da mensagem!

        If Comando <> Nothing Then

            'Fornece fluxo de dados de acesso a rede
            Dim ServerStream As NetworkStream = ClientSocket.GetStream()

            'Dim Buff As Integer
            Dim Buff As Integer = 0
            Dim Cmd As String = Comando


            'Identifica o tamanho da mensagem a ser enviada para inseri-la no array de byte que será enviado para a porta
            Dim Qtd As Integer = Cmd.Length

            'Declara o array de byte a ser enviado com o tamanho do Texto a ser enviado somado ao CR, LF.
            Dim CmdDeEnvio(Qtd + 1) As Byte

            'Insere o texto a ser enviado no array de envio
            For Conta As Integer = 0 To Qtd - 1

                'Converte os caracteres do texto a ser enviado em Byte 
                Dim Bytes As Byte = Convert.ToInt16(Cmd(Conta))

                'Escreve os caracteres convertidos em byte nas posições do array de envio
                CmdDeEnvio(Conta) = Bytes

            Next

            'Insere o CR na primeira posição após o término do texto no array de envio
            CmdDeEnvio(Qtd) = AscW(CR)

            'Insere o LF na segunda posição após o término do texto no Array de envio
            CmdDeEnvio(Qtd + 1) = AscW(LF)
            Dim CmdCli As Byte() = CmdDeEnvio

            Try

                'Executa escrita
                ServerStream.Write(CmdCli, 0, CmdCli.Length)
                ServerStream.Flush()


                Dim CliBytes(ClientSocket.ReceiveBufferSize) As Byte
                Buff = ClientSocket.ReceiveBufferSize

                'Le o NetworkStream em um buffer
                ServerStream.Read(CliBytes, 0, Buff)

                'Exibe os dados recebidos
                Dim Dados As String = System.Text.Encoding.ASCII.GetString(CliBytes)
                DadosCli = ""
                DadosCli = Comando

                DadosServ = ""
                DadosServ = Dados

                Return True

            Catch ex As Exception
                'MsgBox(ex.Message)
                Return False
            End Try

        Else

            Para()
        End If

        Return True
    End Function

    Private Function TrataCmd()

        If Comando <> Nothing Then

            If ContaCmd = 4 Or ContaCmd = 5 Then

                Dim dtCadCfg As List(Of Geral.CadCfg)
                Dim Ck As New Geral.dcToledo

                'Busca no banco pelo Artigo ativo
                dtCadCfg = (From it In Ck.CadCfg Where it.Cfg = "ArtigoAtivo").ToList
                Dim ArtAtivo As String = dtCadCfg.First.Valor

                'Busca no banco pelos artigos registrados
                Dim dtCadCmd = (From It In Ck.CadCfg Where It.Valor = ArtAtivo).ToList
                If dtCadCmd.Count <= 0 Then Return False
                Dim ArtigoAtv As String = dtCadCfg.First.Valor


                'Compara se algum dos artigos registrados e igual ao artigo ativo
                'se for, chama funcao ConcCmd 
                If ArtAtivo = ArtigoAtv Then
                    ConcCmd(ArtAtivo)
                End If

                Return True
            Else

            End If

        Else

            Para()

        End If

        Return True

    End Function

    Private Function ConcCmd(Optional ByVal ArtAtv As String = "") As String

        If ContaCmd = 4 Then
            Comando = CmdHistDados + " " + ArtAtv

        ElseIf ContaCmd = 5 Then
            Comando = CmdProdDados + " " + ArtAtv

        Else

        End If

        Return Comando

    End Function

    Public Function BuscaDados() As clsComD Implements clsICom.BuscaDados
        Return ComD
    End Function

End Class

<ServiceContract()> _
Public Interface clsICom

    <OperationContract()> _
    Function BuscaDados() As clsComD

End Interface
