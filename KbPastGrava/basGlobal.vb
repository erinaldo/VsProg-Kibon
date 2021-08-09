Module basGlobal

    Public ServerOpcHist As OPCAutomation.OPCServer

    Public PastD As clsPastD
    Public PastT As OPCAutomation.OPCItem
    Public CipRT As OPCAutomation.OPCItem
    Public CipIT As OPCAutomation.OPCItem

    Public Const OPC_SRV_NAME = "OPC.SimaticNET"
    Public PlcTopicoAs1 As String = "Opc1"
    Public PlcTopicoAs2 As String = "Opc2"

    Public Const MAT_MAX_NUM = 24

    Public Past As New clsPast
    Public serviceHost As New ServiceHost(GetType(clsPast))

End Module
