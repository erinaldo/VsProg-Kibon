Public Module basTrataDados

    Public DadosCli As String = ""
    Public DadosServ As String = ""

    Public NomesArt As DataTable = Nothing
    Public InfoMaq As DataTable = Nothing
    Public Senden() As String = Nothing
    Public SendenDados As List(Of ArrayList) = New List(Of ArrayList)
    Public SdDados As List(Of DataTable) = New List(Of DataTable)
    Public HistDados As DataTable = Nothing
    Public ProdDados() As String = Nothing
    Public Prod As List(Of DataTable) = New List(Of DataTable)

    Public IdArt As Integer = 0
    Public NomeArt As String = ""
    Public Dh As DateTime = Date.Now


    Public Sub DLLInit()

        Try
            'Carrega string de conexao do banco de dados a partir do arquivo de configuracao
            Dim Caminho As String = Util.UtAppPath
            Dim Cfg As New Util.clsTrataCfg(Caminho & "\.. \Bin\CfgGeral.xml")

            My.Settings.Item("CsTseToledo") = Cfg.colCfg("csTseCk")

        Catch ex As Exception

        End Try

    End Sub

    Public Function MaqIdNovo() As Integer

        Dim Td As New Geral.dcToledo

        'Busca novo Id
        Dim MaqIdUlt As Integer = 0
        Try
            MaqIdUlt = (From It In Td.DadosMaq Select It.IdMaq).Max
        Catch : End Try

        Return MaqIdUlt

    End Function


    Public Function ArtIdNovo() As Integer

        Dim Td As New Geral.dcToledo

        'Busca novo Id
        Dim ArtIdUlt As Integer = 0
        Try
            ArtIdUlt = (From It In Td.DadosArt Select It.ArtId).Max
        Catch : End Try

        Return ArtIdUlt

    End Function


    Public Function HistIdNovo() As Integer

        Dim Td As New Geral.dcToledo

        'Busca novo Id
        Dim HistIdUlt As Integer = 0
        Try
            HistIdUlt = (From It In Td.DadosHist Select It.IdHist).Max
        Catch : End Try

        Return HistIdUlt

    End Function


    Public Function PlusIdNovo() As Integer

        Dim Td As New Geral.dcToledo

        'Busca novo Id
        Dim PlusIdUlt As Integer = 0
        Try
            PlusIdUlt = (From It In Td.ProdPlus Select It.IdProdPlus).Max
        Catch : End Try

        Return PlusIdUlt

    End Function

    Public Function GutIdNovo() As Integer

        Dim Td As New Geral.dcToledo

        'Busca novo Id
        Dim GutIdUlt As Integer = 0
        Try
            GutIdUlt = (From It In Td.ProdGut Select It.IdProdGut).Max
        Catch : End Try

        Return GutIdUlt

    End Function

    Public Function MinusIdNovo() As Integer

        Dim Td As New Geral.dcToledo

        'Busca novo Id
        Dim MinusIdUlt As Integer = 0
        Try
            MinusIdUlt = (From It In Td.ProdMinus Select It.IdProdMinus).Max
        Catch : End Try

        Return MinusIdUlt

    End Function

    Public Function StatIdNovo() As Integer

        Dim Td As New Geral.dcToledo

        'Busca novo Id
        Dim StatIdUlt As Integer = 0
        Try
            StatIdUlt = (From It In Td.ProdStat Select It.IdProdStat).Max
        Catch : End Try

        Return StatIdUlt

    End Function

    Public Function AktIdNovo() As Integer

        Dim Td As New Geral.dcToledo

        'Busca novo Id
        Dim AktIdUlt As Integer = 0
        Try
            AktIdUlt = (From It In Td.ProdAktInt Select It.IdProdAkt).Max
        Catch : End Try

        Return AktIdUlt

    End Function

    Public Function LastIntIdNovo() As Integer

        Dim Td As New Geral.dcToledo

        'Busca novo Id
        Dim LastIntIdUlt As Integer = 0
        Try
            LastIntIdUlt = (From It In Td.ProdLastInt Select It.IdProdLastInt).Max
        Catch : End Try

        Return LastIntIdUlt

    End Function

    Public Function ChargeIdNovo() As Integer

        Dim Td As New Geral.dcToledo

        'Busca novo Id
        Dim ChargeIdUlt As Integer = 0
        Try
            ChargeIdUlt = (From It In Td.ProdCharge Select It.IdProdCharge).Max
        Catch : End Try

        Return ChargeIdUlt

    End Function

    Public Function LastChrIdNovo() As Integer

        Dim Td As New Geral.dcToledo

        'Busca novo Id
        Dim LastChrIdUlt As Integer = 0
        Try
            LastChrIdUlt = (From It In Td.ProdLastChr Select It.IdProdLastChr).Max
        Catch : End Try

        Return LastChrIdUlt

    End Function


    Public Function GrundIdNovo() As Integer

        Dim Td As New Geral.dcToledo

        'Busca novo Id
        Dim GrundIdUlt As Integer = 0
        Try
            GrundIdUlt = (From It In Td.SdGrund Select It.IdGrund).Max
        Catch : End Try

        Return GrundIdUlt

    End Function

    Public Function DataIdNovo() As Integer

        Dim Td As New Geral.dcToledo

        'Busca novo Id
        Dim DataIdUlt As Integer = 0
        Try
            DataIdUlt = (From It In Td.SdData Select It.IdSdData).Max
        Catch : End Try

        Return DataIdUlt

    End Function

    Public Function GleitIdNovo() As Integer

        Dim Td As New Geral.dcToledo

        'Busca novo Id
        Dim GleitIdUlt As Integer = 0
        Try
            GleitIdUlt = (From It In Td.SdGleit Select It.IdSdGleit).Max
        Catch : End Try

        Return GleitIdUlt

    End Function

    Public Function ZonesIdNovo() As Integer

        Dim Td As New Geral.dcToledo

        'Busca novo Id
        Dim ZonesIdUlt As Integer = 0
        Try
            ZonesIdUlt = (From It In Td.SdZones Select It.IdSdZones).Max
        Catch : End Try

        Return ZonesIdUlt

    End Function

    Public Function SdStatIdNovo() As Integer

        Dim Td As New Geral.dcToledo

        'Busca novo Id
        Dim SdStatIdUlt As Integer = 0
        Try
            SdStatIdUlt = (From It In Td.SdStat Select It.IdSdStat).Max
        Catch : End Try

        Return SdStatIdUlt

    End Function

    Public Function SdStat2IdNovo() As Integer

        Dim Td As New Geral.dcToledo

        'Busca novo Id
        Dim SdStat2IdUlt As Integer = 0
        Try
            SdStat2IdUlt = (From It In Td.SdStat2 Select It.IdSdStat2).Max
        Catch : End Try

        Return SdStat2IdUlt

    End Function

   

End Module
