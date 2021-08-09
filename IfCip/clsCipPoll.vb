Public Class clsCipPoll

    'Identificacao do Objeto
    Public Grupo As String

    'Dados do CIP atual
    Public CipId As Integer
    Public RotaId As Integer
    Public Status As Integer
    Public Subgrupo As Integer
    Public Tipo As Integer
    Public Descr As String

    'Dados do PLC
    Public Passo As RsiOPCAuto.OPCItem
    Public EmPausa As RsiOPCAuto.OPCItem
    Public TempoPasso As RsiOPCAuto.OPCItem

    Sub New(ByVal Grupo As String)

        Me.Grupo = Grupo

    End Sub

    Public Function BuscaRotaDados() As Boolean

        'Busca a identificacao da rota deste gurpo que esta em execucao
        Dim taCipHist As New Geral.dsxCipValidTableAdapters.taxCipHist
        Dim dtCipHist As New Geral.dsxCipValid.CipHistDataTable
        taCipHist.FillGrupoExec(dtCipHist, Grupo)

        If dtCipHist.Rows.Count <= 0 Then Return False
        Me.RotaId = dtCipHist(0).RotaId
        Me.CipId = dtCipHist(0).CipId
        Me.Subgrupo = dtCipHist(0).Subgrupo


        'Cadastro de rotas
        Dim taCadRotas As New Geral.dsxCipValidTableAdapters.taxCadRotas
        Dim dtCadRotas As New Geral.dsxCipValid.CadRotasDataTable
        taCadRotas.FillRotaId(dtCadRotas, Me.RotaId)

        If dtCadRotas.Rows.Count <= 0 Then Return False
        Me.Descr = dtCadRotas(0).Descricao

    End Function

    Public Function LimpaRotaDados() As Boolean

        'Busca a identificacao da rota deste gurpo que esta em execucao
        Me.RotaId = 0
        Me.CipId = 0
        Me.Subgrupo = 0
        Me.Descr = ""

    End Function

End Class
