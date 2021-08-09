Public Class clsPlanej
    Implements clsIPlanej

    Dim Trd As Thread
    Dim TrdRun As Boolean = False

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

        'Para serviço Wcf (servidor de dados via Http)
        serviceHost.Close()

        TrdRun = False
        Trd.Join()

        LogAdd("Parado.")

    End Sub

    Private Sub InicializaDados()

        'PlanejD
        PlanejD = New clsPlanejD

    End Sub

    Sub TrdTrata()

        'Try
        Dim HoraAnt As Integer = -1

        While TrdRun = True

            PlanejD.LeituraDadosPlc = True

            If PlanejD.LeituraDadosPlc = True Then PlanejD.ContaD = PlanejD.ContaD + 1
            If PlanejD.ContaD > 9999 Then PlanejD.ContaD = 1
            Geral.SrvChkGrava("KbProdPlanejCtrl", PlanejD.ContaD)

            Thread.Sleep(1000)

        End While

    End Sub

    Function CipCircChk(ByVal CircNum As Integer) As Boolean

        'Busca a identificacao da rota deste gurpo que esta em execucao
        Dim DbCv As New Geral.nsCipValid.dcCipValid
        Dim dtCipHist = (From It In DbCv.CipHist Where It.Status = 1 And It.Circ = Geral.CircTxt(CircNum)).ToList
 
        For Conta As Integer = 0 To dtCipHist.Count - 1

            'Fecha históricos de CIP anteriores que morreram erradamente no status 1 para este circuito
            dtCipHist(Conta).Status = 2
            dtCipHist(Conta).UserIdValid = 0

        Next

        DbCv.SubmitChanges()

        Return True

    End Function

    Public Function BuscaDados() As clsPlanejD Implements clsIPlanej.BuscaDados
        Return PlanejD
    End Function

    Public Function CmdLe(AreaSelected As String, TqNome As String, TqDescr As String,
                     EndStatus As String, EndPlanej As String, EndProduzido As String,
                     ByRef outTamanhoBatch As Integer, ByRef outTotalProd As Integer, ByRef outRecNum As Integer,
                     ByRef outMsg As String, ByRef outAlergenicos As String, ByRef EndAlerg As String) As Boolean Implements clsIPlanej.CmdLe

        Dim PlcLeReceitas As New clsPlcLeReceitas(EndAlerg, outAlergenicos, AreaSelected, TqNome, TqDescr, EndStatus, EndPlanej, EndProduzido)
        Dim lstResultadoLido = PlcLeReceitas.PlcLeDados(outMsg, outAlergenicos)

        If Not IsNothing(lstResultadoLido) Then

            outTamanhoBatch = lstResultadoLido.tamanhoBatch
            outTotalProd = lstResultadoLido.totalProd
            outRecNum = lstResultadoLido.RecNum
            outAlergenicos = lstResultadoLido.Alergenicos

        End If

        Return True

    End Function

    Public Function CmdEscr(AreaSelected As String, EndStatus As String, EndPlanej As String,
                       RecNum As Integer, RecNome As String, Codigo As String,
                       TamanhoBatch As Integer, TotalProduzir As Integer,
                       ByRef outMsg As String, ByRef Alergenicos As String, ByRef EndAlerg As String, ByRef EndPressaoStg01 As String, ByRef ValorPressao01 As Integer, ByRef EndPressaoStg02 As String, ByRef ValorPressao02 As Integer) As Boolean Implements clsIPlanej.CmdEscr

        Dim PlcEnviaReceita As New clsPlcEnviaReceitas(EndPressaoStg01, ValorPressao01, EndPressaoStg02, ValorPressao02, EndAlerg, Alergenicos, AreaSelected, "", 0, EndStatus, EndPlanej, RecNum, RecNome, Codigo)
        Dim ResultadoEnviado As Boolean = PlcEnviaReceita.PlcEnviaDados(TamanhoBatch, TotalProduzir, outMsg)

        Return ResultadoEnviado

    End Function

End Class

<ServiceContract()> _
Public Interface clsIPlanej

    <OperationContract()> _
    Function BuscaDados() As clsPlanejD

    <OperationContract()> _
    Function CmdLe(AreaSelected As String, TqNome As String, TqDescr As String,
                     EndStatus As String, EndPlanej As String, EndProduzido As String,
                     ByRef outTamanhoBatch As Integer, ByRef outTotalProd As Integer,
                     ByRef outRecNum As Integer, ByRef outMsg As String, ByRef Alergenicos As String, ByRef EndAlerg As String) As Boolean

    <OperationContract()> _
    Function CmdEscr(AreaSelected As String, EndStatus As String, EndPlanej As String,
                       RecNum As Integer, RecNome As String, Codigo As String,
                       TamanhoBatch As Integer, TotalProduzir As Integer,
                       ByRef outMsg As String, ByRef Alergenicos As String, ByRef EndAlerg As String, ByRef EndPressaoStg01 As String, ByRef ValorPressao01 As Integer, ByRef EndPressaoStg02 As String, ByRef ValorPressao02 As Integer) As Boolean

End Interface
