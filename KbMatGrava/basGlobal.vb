Module basGlobal

    Public ServerOpcHist As OPCAutomation.OPCServer

    Public MatD As clsMatD

    Public Const OPC_SRV_NAME = "OPC.SimaticNET"
    Public PlcTopicoAs1 As String = "Opc1"
    Public PlcTopicoAs2 As String = "Opc2"

    Public Const MAT_MAX_NUM = 24

    Public Mat As New clsMat
    Public serviceHost As New ServiceHost(GetType(clsMat))

End Module
