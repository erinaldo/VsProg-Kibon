Module basGlobal

    Public ServerOpcHist As OPCAutomation.OPCServer

    Public MistD As clsMistD

    Public Const OPC_SRV_NAME = "OPC.SimaticNET"
    Public PlcTopicoAs1 As String = "Opc1"
    Public PlcTopicoAs2 As String = "Opc2"

    Public Mist As New clsMist
    Public serviceHost As New ServiceHost(GetType(clsMist))

End Module
