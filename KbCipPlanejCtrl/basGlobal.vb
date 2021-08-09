Module basGlobal

    Public ServerOpcHist As OPCAutomation.OPCServer

    Public PlanejT() As clsPlanejT
    Public PlanejD As clsPlanejD

    'Indices dos Circuitos
    '0=A / 1=B / 2=C / 3=D ....
    '17=S / 18=T / 19=U / 20=V
    Public Const CIRC_MAX_NUM As Integer = 9
    'Public CIRC_MAX_NUM As Integer = 5

    Public Const OPC_SRV_NAME = "OPC.SimaticNET"
    Public PlcTopicoAs1 As String = "Opc1"
    Public PlcTopicoAs2 As String = "Opc2"

    Public Const REC_MAX_BLOCOS = 20    'Numero maximo de blocos de receita
    Public Const MAX_ITENS_ROTA = 70    'Numero maximo de itens na rota de cip
    Public Const MAX_ITENS_ROTA_PX = 20 'Numero maximo de px a alocar na rota de cip

    'Estados da receita no PLC
    Public Const RECEITA_PARADA = 0
    Public Const RECEITA_DOWNLOAD = 1
    Public Const RECEITA_INICIO = 2
    Public Const RECEITA_FALHA_ALOCACAO = 7
    Public Const RECEITA_EXECUCAO = 14
    Public Const RECEITA_FIM = 30
    Public Const RECEITA_ABORTADO = 31

    Public Planej As New clsPlanej
    Public serviceHost As New ServiceHost(GetType(clsPlanej))

End Module
