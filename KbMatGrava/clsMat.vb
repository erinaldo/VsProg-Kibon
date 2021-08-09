Public Class clsMat
    Implements clsIMat

    Dim Trd As Thread
    Dim TrdRun As Boolean = False

    Public CommCentral As Boolean = False
    Public OpcSrv As OPCAutomation.OPCServer
    Public Const cnstServerOpcGrupo = "KbMatGrava"


    Public Sub Iniciar()

        LogAdd("Iniciar...")
        InicializaDados()

        Trd = New Thread(AddressOf TrdTrata)
        TrdRun = True
        Trd.Start()

        'Inicia serviço Wcf (servidor de dados via Http)
        LogAdd("Inicializando Servicehost...")
        Try
            serviceHost.Open()
        Catch
            LogAdd("Erro: Falha inicializando Servicehost")
        End Try

        LogAdd("Iniciado.")

    End Sub

    Public Sub Parar()

        LogAdd("Parar...")
        OpcDesmonta()

        'Para serviço Wcf (servidor de dados via Http)
        serviceHost.Close()

        TrdRun = False
        Trd.Join()

        LogAdd("Parado.")

    End Sub

    Private Sub InicializaDados()

        'PlanejD
        MatD = New clsMatD

        MatD.Dados.Add(New clsMatDIt("6201", 0, 48, 96, 144))
        MatD.Dados.Add(New clsMatDIt("6202", 2, 50, 98, 146))
        MatD.Dados.Add(New clsMatDIt("6203", 4, 52, 100, 148))
        MatD.Dados.Add(New clsMatDIt("6204", 6, 54, 102, 150))
        MatD.Dados.Add(New clsMatDIt("6205", 8, 56, 104, 152))
        MatD.Dados.Add(New clsMatDIt("6206", 10, 58, 106, 154))
        MatD.Dados.Add(New clsMatDIt("6207", 12, 60, 108, 156))
        MatD.Dados.Add(New clsMatDIt("6208", 14, 62, 110, 158))
        MatD.Dados.Add(New clsMatDIt("6209", 16, 64, 112, 160))
        MatD.Dados.Add(New clsMatDIt("6210", 18, 66, 114, 162))
        MatD.Dados.Add(New clsMatDIt("6211", 20, 68, 116, 164))
        MatD.Dados.Add(New clsMatDIt("6212", 22, 70, 118, 166))
        MatD.Dados.Add(New clsMatDIt("6213", 24, 72, 120, 168))
        MatD.Dados.Add(New clsMatDIt("6214", 26, 74, 122, 170))
        MatD.Dados.Add(New clsMatDIt("6215", 28, 76, 124, 172))
        MatD.Dados.Add(New clsMatDIt("6216", 30, 78, 126, 174))
        MatD.Dados.Add(New clsMatDIt("6217", 32, 80, 128, 176))
        MatD.Dados.Add(New clsMatDIt("6218", 34, 82, 130, 178))
        MatD.Dados.Add(New clsMatDIt("6255", 36, 84, 132, 180))
        MatD.Dados.Add(New clsMatDIt("6256", 38, 86, 134, 182))
        MatD.Dados.Add(New clsMatDIt("6257", 40, 88, 136, 184))
        MatD.Dados.Add(New clsMatDIt("6258", 42, 90, 138, 186))
        MatD.Dados.Add(New clsMatDIt("6259", 44, 92, 140, 188))
        MatD.Dados.Add(New clsMatDIt("6260", 46, 94, 142, 190))


        CommCentral = False

    End Sub

    Sub TrdTrata()

        'Try
        Static HoraAnt As Integer = Now.Hour

        While TrdRun = True

            'Verifica comunicação com os PLCs
            VerificaComunicacao()

            'Monta Dados para comunicacao com os Clientes
            LeDados()

            'Atualiza a programação do dia à meia-noite
            If Now.Hour <> HoraAnt Then
                'Geral.ChkSchedPer()
                GravaDados()
            End If
            HoraAnt = Now.Hour


            Thread.Sleep(5000)

        End While

    End Sub

    Private Sub VerificaComunicacao()

        Try
            'Verifica comunicação com o PLC da Central 1
            If CommCentral <> True Then

                CommCentral = OpcMonta()

                If CommCentral = True Then
                    LogAdd("===> CommCentral1 - OPC criado - retornou True <===")
                Else
                    LogAdd("===> CommCentral1 - OPC retornou False <===")
                End If
            End If
        Catch
            LogAdd("===> CommCentral1 - ERRO ao montar OPC <===")
        End Try

    End Sub

    Private Sub LeDados()

        MatD.LeituraDadosPlc = True

        'Atualiza dados de PlanejD
        For Conta As Integer = 0 To (MAT_MAX_NUM - 1)

            Try

                MatD.Dados(Conta).Te = MatD.Dados(Conta).TeT.Value / 10.0
                MatD.Dados(Conta).CodProd = MatD.Dados(Conta).CodProdT.Value
                MatD.Dados(Conta).Hr = MatD.Dados(Conta).HrT.Value / 60.0

                ' Quando o Cn mudar, soma 1 na SeqTq
                If MatD.Dados(Conta).Cn <> MatD.Dados(Conta).CnT.Value Then
                    MatD.Dados(Conta).SeqTq = MatD.Dados(Conta).SeqTq + 1
                End If

                MatD.Dados(Conta).Cn = MatD.Dados(Conta).CnT.Value


            Catch ex As Exception
                MatD.LeituraDadosPlc = False
            End Try

        Next

        If MatD.LeituraDadosPlc = True Then MatD.ContaD = MatD.ContaD + 1
        If MatD.ContaD > 9999 Then MatD.ContaD = 1
        Geral.SrvChkGrava("KbMatGrava", MatD.ContaD)

    End Sub

    Function GravaDados() As Boolean

        Dim DbMa As New Geral.nsMatGrava.dcMatGrava

        For Each Md In MatD.Dados

            Dim DataHora As String = Format(Now, "yyyyMMddHHmmss")

            Dim NwMhd As New Geral.nsMatGrava.MatHistDados With {.DataHora = DataHora, .Tq = Md.Tq,
                                                .SeqTq = Md.SeqTq, .CodProduto = Md.CodProd,
                                                .Temperatura = Md.Te, .HrsValidade = Md.Hr}
            DbMa.MatHistDados.InsertOnSubmit(NwMhd)

        Next

        DbMa.SubmitChanges()

        Return True

    End Function

    Function OpcMonta() As Boolean

        Dim Hndl As Integer

        OpcSrv = New OPCAutomation.OPCServer

        Try
            OpcSrv.OPCGroups.Remove(cnstServerOpcGrupo)
        Catch : End Try

        Try

            'Monta o grupo de tags OPC para Poll no CIP
            OpcSrv.Connect(OPC_SRV_NAME)
            OpcSrv.OPCGroups.Add(cnstServerOpcGrupo)
            OpcSrv.OPCGroups.Item(cnstServerOpcGrupo).IsActive = False

            With OpcSrv.OPCGroups.Item(cnstServerOpcGrupo).OPCItems

                For Each Dd In MatD.Dados

                    'S7:[Opc2]DB195,INT0,96
                    Dd.TeT = .AddItem(OpcTagMonta(PlcTopicoAs2, 195, OpcTagMontaTipo.Int, Dd.TeAddr, 1), Hndl)
                    Dd.CodProdT = .AddItem(OpcTagMonta(PlcTopicoAs2, 195, OpcTagMontaTipo.Int, Dd.CodProdAddr, 1), Hndl)
                    Dd.HrT = .AddItem(OpcTagMonta(PlcTopicoAs2, 195, OpcTagMontaTipo.Int, Dd.HrAddr, 1), Hndl)
                    Dd.CnT = .AddItem(OpcTagMonta(PlcTopicoAs2, 195, OpcTagMontaTipo.Int, Dd.CnAddr, 1), Hndl)

                Next
            End With

            If OpcSrv.OPCGroups.Item(cnstServerOpcGrupo).OPCItems.Count <> MatD.Dados.Count * 4 Then
                'MsgBox("Houve uma falha inserindo itens no OpcGroup Poll", MsgBoxStyle.Exclamation)
                Return False
            End If

            'Ok
            OpcSrv.OPCGroups.Item(cnstServerOpcGrupo).UpdateRate = 1000
            OpcSrv.OPCGroups.Item(cnstServerOpcGrupo).IsActive = True
            OpcSrv.OPCGroups.Item(cnstServerOpcGrupo).IsSubscribed = True

            Return True

        Catch ex As Exception

            LogAdd("OpcMontaStsCentral1 - " & ex.Message)
            Return False

        End Try

        Return True

    End Function

    Function OpcDesmonta() As Boolean

        Try
            OpcSrv.OPCGroups.Item(cnstServerOpcGrupo).IsActive = False
        Catch ex As Exception
        End Try

        Try
            OpcSrv.OPCGroups.RemoveAll()
            OpcSrv.Disconnect()

            Return True

        Catch ex As Exception

            LogAdd("OpcDesmonta - Ocorreu uma falha ao desconectar o OPC CipSts")
            Return False

        End Try

    End Function

    Public Function BuscaDados() As clsMatD Implements clsIMat.BuscaDados
        Return MatD
    End Function

End Class

<ServiceContract()> _
Public Interface clsIMat

    <OperationContract()> _
    Function BuscaDados() As clsMatD

End Interface
