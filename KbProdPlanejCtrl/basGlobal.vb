Module basGlobal

    Public ServerOpcHist As OPCAutomation.OPCServer

    Public RecT As OPCAutomation.OPCItem
    Public PlanT As OPCAutomation.OPCItem
    Public AlergT As OPCAutomation.OPCItem
    Public Pressoes01T As OPCAutomation.OPCItem
    Public Pressoes02T As OPCAutomation.OPCItem

    Public Const OPC_SRV_NAME = "OPC.SimaticNET"

    Public PlanejD As clsPlanejD
    Public Planej As New clsPlanej
    Public serviceHost As New ServiceHost(GetType(clsPlanej))

End Module
