Module basGlobal

    'Blocos da receita
    'Obs: A classe ListaBlocos e' uma lista de elementos da classe Blocos. _
    '    A classe Blocos contem dados do bloco e um elemento ListaParametros. _
    '    A classe ListaParametros e' uma lista de elementos da classe Parametro. _
    '    A classe Parametro contem dados de um parametro.
    Public MyBlocos As New Geral.clsBlocos

    'Ingredientes usados na receita
    Public MyIngreds As New Geral.clsIngreds

    'Variaveis de diretorio
    Public PathReceitas As String

    'Flag de dados editados nao salvos
    Public FlagDadosEdit As Boolean

    Public Rc As clsReceita

    Public Const CtrlMask As Byte = 8

    Public TrataArea As Geral.clsTrataArea

End Module
