Imports System.Net.Sockets
Imports System.Net
Imports System.Text

Public Class clsTrataDados

    Dim GrundSenden As String = ""
    Dim DataSenden As String = ""
    Dim GleitSenden As String = ""
    Dim ZonesSenden As String = ""
    Dim StatSenden As String = ""
    Dim Stat2Senden As String = ""

    Dim PlusProd As String = ""
    Dim GutProd As String = ""
    Dim MinusProd As String = ""
    Dim StatProd As String = ""
    Dim AktIntProd As String = ""
    Dim LastIntProd As String = ""
    Dim ChargeProd As String = ""
    Dim LastChrProd As String = ""
    Dim HourProd As String = ""
    Dim EndeProd As String = ""

    Public Sub TrataResp()

        If DadosCli <> Nothing Then
            TrataDadosResp()
        Else
            Return
        End If

    End Sub

    Private Sub TrataDadosResp()


        Dim Cmd As String = DadosCli
        Dim ServInfo As String = DadosServ

        Cmd = Cmd.Substring(0, 6)


        Select Case Cmd

            Case "WD_TES"
                'WD_TEST
                TrataTestCom(ServInfo)

            Case "FB_INF"
                'FB_INFO
                TrataMaqInfo(ServInfo)

            Case "FB_ART"
                'FB_ART_NAMES
                TrataArtNames(ServInfo)

            Case "FB_SEN"
                'FB_SENDEN
                TrataFbSenden(ServInfo)

            Case "FB_ABL"
                'FB_ABLAGEN
                TrataHistDados(ServInfo)

            Case "FB_PD "
                'FB_PD*
                TrataProdDados(ServInfo)

        End Select

    End Sub

    Private Sub TrataTestCom(Optional ByVal InfoServ As String = "")



    End Sub

    Private Sub TrataMaqInfo(Optional ByVal InfoServ As String = "")

        'FB_INFO - exibe numero e quais opções de configuração da Checkweigher estão habilitadas

        '"S" - Estatísticas
        '"R" - Feedback do programa de controle
        '"G" - Limites de deslizamento do programa (valor médio)
        '"F" - Programa teste
        '"W" - Monitoramento de valor médio
        '"M" being the metal detector program

        'Lista todos os caracteres
        Dim ListaMaq() As String = InfoServ.Split(New String() {"FB_INF"}, StringSplitOptions.RemoveEmptyEntries)

        Dim dtMaqDados As New DataTable("MaqDados")
        dtMaqDados.Columns.Add("IdMaq", GetType(Integer))
        dtMaqDados.Columns.Add("Maquina", GetType(String))
        dtMaqDados.Columns.Add("DataHora", GetType(DateTime))

        Dim ContaLinha As Integer = 0
        Dim vtTamanho As Integer = 0

        While vtTamanho < ListaMaq.Count

            Dim drLinha As DataRow = dtMaqDados.NewRow

            'drLinha("IdMaq") = ListaArt(ContaLinha)
            'ContaLinha = ContaLinha + 1
            drLinha("Maquina") = ListaMaq(ContaLinha)
            ContaLinha = ContaLinha + 1
            'drLinha("DataHora") = ListaArt(ContaLinha)
            'ContaLinha = ContaLinha + 1

            dtMaqDados.Rows.Add(drLinha)

            ContaLinha = ContaLinha + 1
            vtTamanho = vtTamanho + 1

        End While

        basTrataDados.InfoMaq = dtMaqDados


    End Sub

    Private Sub TrataArtNames(Optional ByVal InfoServ As String = "")

        'XXXXXXXXXX - Representa uma quantidade fixa de caracteres
        'vvvvvvvvvv - Representa uma variavel com quantidade fixa de caracteres
        'FB_ART_NAMES - Solicita o 'nome' dos artigos armazenados na memoria da Checadora

        'Exemplo: "FB_AN¬vvvvvvvvvv(CR)(LF)" ... "FB_AN_ENDE(CR)(LF)"
        '"FB_AN¬" - Identifica o inicio da string
        '"FB_AN_ENDE" - Identifica o fim da string

        'Separa nome dos Artigos
        Dim ArtList As String() = InfoServ.Split(New String() {"FB_AN"}, StringSplitOptions.RemoveEmptyEntries)

        'Exclui identificação de fim-de-mensagem da lista
        Dim Tamanho As Integer = ArtList.Length
        Dim NwTamanho As Integer = Tamanho - 2

        'Nova Lista com os artigos
        Dim ListArt As String() = Nothing
        ListArt = New String(0 To NwTamanho) {}
        Array.Copy(ArtList, 0, ListArt, 0, Tamanho - 1)

        Dim dtNomeArt As New DataTable("NomeArt")
        dtNomeArt.Columns.Add("IdArt", GetType(Integer))
        dtNomeArt.Columns.Add("Nome", GetType(String))
        dtNomeArt.Columns.Add("DataHora", GetType(DateTime))

        Dim ContaLinha As Integer = 0
        Dim vtTamanho As Integer = 0

        While vtTamanho < ListArt.Count

            Dim drLinha As DataRow = dtNomeArt.NewRow

            'drLinha("IdArt") = ListArt(ContaLinha)
            'ContaLinha = ContaLinha + 1
            drLinha("Nome") = ListArt(ContaLinha)
            ContaLinha = ContaLinha + 1
            'drLinha("DataHora") = ListArt(ContaLinha)
            'ContaLinha = ContaLinha + 1

            dtNomeArt.Rows.Add(drLinha)

            'ContaLinha = ContaLinha + 1
            vtTamanho = vtTamanho + 1

        End While


        basTrataDados.NomesArt = dtNomeArt


    End Sub

    Private Sub TrataFbSenden(Optional ByVal InfoServ As String = "")

        'FB_SENDEN - verifica artigo corrente (ativo)

        'FB_GRUND - dados básicos do artigo
        'FB_GLEIT - limites de deslizamento (valor médio na esteira)
        'FB_ZONES - classificação das zonas de rejeito
        'FB_STAT - estatisticas do artigo 
        'FB_STAT2 - estatisticas do artigo (parte 2) 

        Dim SendenList As String() = InfoServ.Split(New String() {"FB_"}, StringSplitOptions.RemoveEmptyEntries)

        'Exclui identificação de fim-de-mensagem da lista
        Dim Tamanho As Integer = SendenList.Length
        Dim NwTamanho As Integer = Tamanho - 2

        'Nova Lista com os dados
        Dim ListSenden As String() = Nothing
        ListSenden = New String(0 To NwTamanho) {}
        Array.Copy(SendenList, 0, ListSenden, 0, Tamanho - 1)

        ListSenden(0) = ListSenden(0).Replace("GRUND", "")
        GrundSenden = ListSenden(0)
        ListSenden(1) = ListSenden(1).Replace("DATA", "")
        DataSenden = ListSenden(1)
        ListSenden(2) = ListSenden(2).Replace("GLEIT", "")
        GleitSenden = ListSenden(2)
        ListSenden(3) = ListSenden(3).Replace("ZONES", "")
        ZonesSenden = ListSenden(3)
        ListSenden(4) = ListSenden(4).Replace("STAT", "")
        StatSenden = ListSenden(4)
        ListSenden(5) = ListSenden(5).Replace("STAT2", "")
        Stat2Senden = ListSenden(5)

        basTrataDados.Senden = SendenList

        'Limpa variavel
        basTrataDados.SdDados.Clear()

        FbGrund(GrundSenden)

        FbDat(DataSenden)

        FbGleit(GleitSenden)

        FbZones(ZonesSenden)

        FbStat(StatSenden)

        FbStat2(Stat2Senden)


    End Sub

    Private Sub TrataHistDados(Optional ByVal InfoServ As String = "")

        'FB_ABLAGEN - Solicita os dados gravados do artigo atual configurado na maquina

        'FB_ABL¬ identificacao do do bloco
        'XX¬ numero do bloco atual int
        'XXXXX¬ hora de inicio char
        'XXXXXXXX¬ data de inicio char
        'XXXXX¬ hora final char
        'XXXXXXXX¬ data final char
        'XXXXXXXX¬ rendimento long
        'XXXXXXXX¬ mean value float
        'XXXXXXXX TU1% (percentage of TU1 infringements) float (only if optional 'statistics')
        '"FB_ABL_ENDE" - Fim da mensagem

        'Monta lista de Historico de Dados
        Dim DadosList As String() = InfoServ.Split(New String() {"FB_ABL"}, StringSplitOptions.RemoveEmptyEntries)
        'Exclui comando da string
        InfoServ = InfoServ.Replace("FB_ABL", "")
        'Lista todos os caracteres
        Dim ListHist() As String = InfoServ.Split(New [Char]() {" "c, "_ENDE"}, StringSplitOptions.RemoveEmptyEntries)

        'Cria nova lista de Historico de Dados excluindo caractere de fim-de-mensagem
        Dim Tamanho As Integer = 0
        Dim NwTamanho As Integer = 0

        Tamanho = DadosList.Length
        NwTamanho = Tamanho - 2
        Dim ListDados As String() = Nothing
        ListDados = New String(0 To NwTamanho) {}
        Array.Copy(DadosList, 0, ListDados, 0, Tamanho - 1)

        Tamanho = DadosList.Length
        NwTamanho = Tamanho - 2
        Dim HistList As String() = Nothing
        HistList = New String(0 To NwTamanho) {}
        Array.Copy(DadosList, 0, HistList, 0, Tamanho - 1)


        'Monta tabela para gravar no banco (posteriormente)
        Dim dtHistDados As New DataTable("HistDados")
        dtHistDados.Columns.Add("NumBlc", GetType(String))
        dtHistDados.Columns.Add("HorIni", GetType(String))
        dtHistDados.Columns.Add("DtIni", GetType(Date))
        dtHistDados.Columns.Add("HorFin", GetType(String))
        dtHistDados.Columns.Add("DtFin", GetType(Date))
        dtHistDados.Columns.Add("Rend", GetType(String))
        dtHistDados.Columns.Add("Media", GetType(String))
        dtHistDados.Columns.Add("Tu1", GetType(String))

        Dim ContaLinha As Integer = 0
        Dim vtTamanho As Integer = 0

        'Escreve na tabela
        While vtTamanho < ListDados.Count

            Dim drLinha As DataRow = dtHistDados.NewRow

            drLinha("NumBlc") = ListHist(ContaLinha)
            ContaLinha = ContaLinha + 1
            drLinha("HorIni") = ListHist(ContaLinha)
            ContaLinha = ContaLinha + 1
            drLinha("DtIni") = ListHist(ContaLinha)
            ContaLinha = ContaLinha + 1
            drLinha("HorFin") = ListHist(ContaLinha)
            ContaLinha = ContaLinha + 1
            drLinha("DtFin") = ListHist(ContaLinha)
            ContaLinha = ContaLinha + 1
            drLinha("Rend") = ListHist(ContaLinha)
            ContaLinha = ContaLinha + 1
            drLinha("Media") = ListHist(ContaLinha)
            ContaLinha = ContaLinha + 1
            drLinha("Tu1") = ListHist(ContaLinha)

            dtHistDados.Rows.Add(drLinha)

            ContaLinha = ContaLinha + 1
            vtTamanho = vtTamanho + 1

        End While

        'Ordena de forma crescente pela DataInicial
        Dim dtView As New DataView(dtHistDados)
        dtView.Sort = "DtIni ASC"
        basTrataDados.HistDados = dtView.ToTable

    End Sub

    Private Sub TrataProdDados(Optional ByVal InfoServ As String = "")

        'FB_PD +* - Solicita os dados de produção do artigo atual

        'Pesquisa cabeçalho e quebra os dados
        Dim ProdList As String() = InfoServ.Split(New String() {"FB_"}, StringSplitOptions.RemoveEmptyEntries)

        'Exclui identificação de fim-de-mensagem da lista
        Dim Tamanho As Integer = ProdList.Length
        Dim NwTamanho As Integer = Tamanho - 2

        'Nova Lista com os dados
        Dim ListProd As String() = Nothing
        ListProd = New String(0 To NwTamanho) {}
        Array.Copy(ProdList, 0, ListProd, 0, Tamanho - 1)

        'Remove comandos da string
        ListProd(0) = ListProd(0).Replace("PD_PLUS", "")
        PlusProd = ListProd(0)
        ListProd(1) = ListProd(1).Replace("PD_GUT", "")
        GutProd = ListProd(1)
        ListProd(2) = ListProd(2).Replace("PD_MINUS", "")
        MinusProd = ListProd(2)
        ListProd(3) = ListProd(3).Replace("PD_STAT", "")
        StatProd = ListProd(3)
        ListProd(4) = ListProd(4).Replace("PD_AKTINT", "")
        AktIntProd = ListProd(4)
        ListProd(5) = ListProd(5).Replace("PD_LASTINT", "")
        LastIntProd = ListProd(5)
        ListProd(6) = ListProd(6).Replace("PD_CHARGE", "")
        ChargeProd = ListProd(6)
        ListProd(7) = ListProd(7).Replace("PD_LASTCHR", "")
        LastChrProd = ListProd(7)

        'Limpa variavel
        basTrataDados.Prod.Clear()

        PdPlus(PlusProd)

        PdGut(GutProd)

        PdMinus(MinusProd)

        PdStat(StatProd)

        PdAkt(AktIntProd)

        PdLastInt(LastIntProd)

        PdCharge(ChargeProd)

        PdLastChr(LastChrProd)


    End Sub


#Region "SendenDados"

    'FB_GRUND
    Private Function FbGrund(Optional ByVal Grund As String = "") As Boolean

        Dim GrundList As ArrayList = New ArrayList()

        GrundList.Add(Grund.Substring(0, 7))
        GrundList.Add(Grund.Substring(7, 20))
        GrundList.Add(Grund.Substring(25, 13))
        GrundList.Add(Grund.Substring(45, 5))

        'Monta tabela
        Dim dtGrund As New DataTable("GrundDados")
        dtGrund.Columns.Add("IdGrund", GetType(String))
        dtGrund.Columns.Add("NumVersao", GetType(String))
        dtGrund.Columns.Add("ArtName", GetType(String))
        dtGrund.Columns.Add("EanCode", GetType(String))
        dtGrund.Columns.Add("UnidPeso", GetType(String))
        dtGrund.Columns.Add("DataHora", GetType(String))

        Dim ContaLinha As Integer = 0

        'Escreve na tabela
        While ContaLinha < GrundList.Count

            Dim drLinha As DataRow = dtGrund.NewRow
            drLinha("NumVersao") = GrundList(ContaLinha)
            ContaLinha = ContaLinha + 1
            drLinha("ArtName") = GrundList(ContaLinha)
            ContaLinha = ContaLinha + 1
            drLinha("EanCode") = GrundList(ContaLinha)
            ContaLinha = ContaLinha + 1
            drLinha("UnidPeso") = GrundList(ContaLinha)
            ContaLinha = ContaLinha + 1

            dtGrund.Rows.Add(drLinha)

            ContaLinha = ContaLinha + 1

        End While

        basTrataDados.SdDados.Add(dtGrund)


        Return True

    End Function

    'FB_DATA
    Private Function FbDat(Optional ByVal Dat As String = "") As Boolean


        Dim DatList As ArrayList = New ArrayList()

        DatList.Add(Dat.Substring(0, 8))
        DatList.Add(Dat.Substring(9, 8))
        DatList.Add(Dat.Substring(17, 5))
        DatList.Add(Dat.Substring(25, 4))
        DatList.Add(Dat.Substring(29, 4))
        DatList.Add(Dat.Substring(34, 4))
        DatList.Add(Dat.Substring(38, 8))
        DatList.Add(Dat.Substring(47, 4))
        DatList.Add(Dat.Substring(52, 8))
        DatList.Add(Dat.Substring(60, 1))

        'Monta tabela
        Dim dtDat As New DataTable("DatDados")
        dtDat.Columns.Add("IdDat", GetType(String))
        dtDat.Columns.Add("PesoNom", GetType(String))
        dtDat.Columns.Add("TaraMedia", GetType(String))
        dtDat.Columns.Add("TamArt", GetType(String))
        dtDat.Columns.Add("NumProdNok", GetType(String))
        dtDat.Columns.Add("Rendimento", GetType(String))
        dtDat.Columns.Add("TempoAfericao", GetType(String))
        dtDat.Columns.Add("FtCorrecao", GetType(String))
        dtDat.Columns.Add("TamMax", GetType(String))
        dtDat.Columns.Add("DensEspec", GetType(String))
        dtDat.Columns.Add("CorrDens", GetType(String))
        dtDat.Columns.Add("DataHora", GetType(String))

        Dim ContaLinha As Integer = 0

        'Escreve na tabela
        While ContaLinha < DatList.Count

            Dim drLinha As DataRow = dtDat.NewRow
            drLinha("PesoNom") = DatList(ContaLinha)
            ContaLinha = ContaLinha + 1
            drLinha("TaraMedia") = DatList(ContaLinha)
            ContaLinha = ContaLinha + 1
            drLinha("TamArt") = DatList(ContaLinha)
            ContaLinha = ContaLinha + 1
            drLinha("NumProdNok") = DatList(ContaLinha)
            ContaLinha = ContaLinha + 1
            drLinha("Rendimento") = DatList(ContaLinha)
            ContaLinha = ContaLinha + 1
            drLinha("TempoAfericao") = DatList(ContaLinha)
            ContaLinha = ContaLinha + 1
            drLinha("FtCorrecao") = DatList(ContaLinha)
            ContaLinha = ContaLinha + 1
            drLinha("TamMax") = DatList(ContaLinha)
            ContaLinha = ContaLinha + 1
            drLinha("DensEspec") = DatList(ContaLinha)
            ContaLinha = ContaLinha + 1
            drLinha("CorrDens") = DatList(ContaLinha)
            ContaLinha = ContaLinha + 1

            dtDat.Rows.Add(drLinha)

            ContaLinha = ContaLinha + 1

        End While

        basTrataDados.SdDados.Add(dtDat)


        Return True

    End Function

    'FB_GLEIT
    Private Function FbGleit(Optional ByVal Gleit As String = "") As Boolean


        Dim GleitList As ArrayList = New ArrayList()

        GleitList.Add(Gleit.Substring(0, 8))
        GleitList.Add(Gleit.Substring(9, 8))
        GleitList.Add(Gleit.Substring(16, 8))
        GleitList.Add(Gleit.Substring(27, 8))
        GleitList.Add(Gleit.Substring(36, 8))
        GleitList.Add(Gleit.Substring(45, 4))
        GleitList.Add(Gleit.Substring(50, 3))
        GleitList.Add(Gleit.Substring(53, 6))

        'Monta tabela
        Dim dtGleit As New DataTable("GleitDados")
        dtGleit.Columns.Add("IdGleit", GetType(String))
        dtGleit.Columns.Add("PesoRef", GetType(String))
        dtGleit.Columns.Add("LimAlto", GetType(String))
        dtGleit.Columns.Add("T1LimPos", GetType(String))
        dtGleit.Columns.Add("T1LimNeg", GetType(String))
        dtGleit.Columns.Add("LimBaixo", GetType(String))
        dtGleit.Columns.Add("VarLim", GetType(String))
        dtGleit.Columns.Add("QtdPcs", GetType(String))
        dtGleit.Columns.Add("RangeTol", GetType(String))
        dtGleit.Columns.Add("DataHora", GetType(String))

        Dim ContaLinha As Integer = 0

        'Escreve na tabela
        While ContaLinha < GleitList.Count

            Dim drLinha As DataRow = dtGleit.NewRow
            drLinha("PesoRef") = GleitList(ContaLinha)
            ContaLinha = ContaLinha + 1
            drLinha("LimAlto") = GleitList(ContaLinha)
            ContaLinha = ContaLinha + 1
            drLinha("T1LimPos") = GleitList(ContaLinha)
            ContaLinha = ContaLinha + 1
            drLinha("T1LimNeg") = GleitList(ContaLinha)
            ContaLinha = ContaLinha + 1
            drLinha("LimBaixo") = GleitList(ContaLinha)
            ContaLinha = ContaLinha + 1
            drLinha("VarLim") = GleitList(ContaLinha)
            ContaLinha = ContaLinha + 1
            drLinha("QtdPcs") = GleitList(ContaLinha)
            ContaLinha = ContaLinha + 1
            drLinha("RangeTol") = GleitList(ContaLinha)
            ContaLinha = ContaLinha + 1

            dtGleit.Rows.Add(drLinha)

            ContaLinha = ContaLinha + 1

        End While

        basTrataDados.SdDados.Add(dtGleit)


        Return True

    End Function

    'FB_ZONES
    Private Function FbZones(Optional ByVal Zones As String = "") As Boolean


        Dim ZonesList As ArrayList = New ArrayList()

        ZonesList.Add(Zones.Substring(1, 1))
        ZonesList.Add(Zones.Substring(3, 1))
        ZonesList.Add(Zones.Substring(5, 8))

        ZonesList.Add(Zones.Substring(14, 1))
        ZonesList.Add(Zones.Substring(16, 1))
        ZonesList.Add(Zones.Substring(18, 8))

        ZonesList.Add(Zones.Substring(27, 1))
        ZonesList.Add(Zones.Substring(29, 1))
        ZonesList.Add(Zones.Substring(31, 8))

        ZonesList.Add(Zones.Substring(40, 1))
        ZonesList.Add(Zones.Substring(42, 1))
        ZonesList.Add(Zones.Substring(44, 8))

        ZonesList.Add(Zones.Substring(53, 1))
        ZonesList.Add(Zones.Substring(55, 1))
        ZonesList.Add(Zones.Substring(57, 5))


        'Monta tabela
        Dim dtZones As New DataTable("ZonesDados")
        dtZones.Columns.Add("IdZones", GetType(String))

        dtZones.Columns.Add("NokZona1", GetType(String))
        dtZones.Columns.Add("OkZona1", GetType(String))
        dtZones.Columns.Add("NomeZ1", GetType(String))

        dtZones.Columns.Add("NokZona2", GetType(String))
        dtZones.Columns.Add("OkZona2", GetType(String))
        dtZones.Columns.Add("NomeZ2", GetType(String))

        dtZones.Columns.Add("NokZona3", GetType(String))
        dtZones.Columns.Add("OkZona3", GetType(String))
        dtZones.Columns.Add("NomeZ3", GetType(String))

        dtZones.Columns.Add("NokZona4", GetType(String))
        dtZones.Columns.Add("OkZona4", GetType(String))
        dtZones.Columns.Add("NomeZ4", GetType(String))

        dtZones.Columns.Add("NokZona5", GetType(String))
        dtZones.Columns.Add("OkZona5", GetType(String))
        dtZones.Columns.Add("NomeZ5", GetType(String))

        dtZones.Columns.Add("DataHora", GetType(String))

        Dim ContaLinha As Integer = 0

        'Escreve na tabela
        While ContaLinha < ZonesList.Count

            Dim drLinha As DataRow = dtZones.NewRow
            drLinha("NokZona1") = ZonesList(ContaLinha)
            ContaLinha = ContaLinha + 1
            drLinha("OkZona1") = ZonesList(ContaLinha)
            ContaLinha = ContaLinha + 1
            drLinha("NomeZ1") = ZonesList(ContaLinha)
            ContaLinha = ContaLinha + 1

            drLinha("NokZona2") = ZonesList(ContaLinha)
            ContaLinha = ContaLinha + 1
            drLinha("OkZona2") = ZonesList(ContaLinha)
            ContaLinha = ContaLinha + 1
            drLinha("NomeZ2") = ZonesList(ContaLinha)
            ContaLinha = ContaLinha + 1

            drLinha("NokZona3") = ZonesList(ContaLinha)
            ContaLinha = ContaLinha + 1
            drLinha("OkZona3") = ZonesList(ContaLinha)
            ContaLinha = ContaLinha + 1
            drLinha("NomeZ3") = ZonesList(ContaLinha)
            ContaLinha = ContaLinha + 1

            drLinha("NokZona4") = ZonesList(ContaLinha)
            ContaLinha = ContaLinha + 1
            drLinha("OkZona4") = ZonesList(ContaLinha)
            ContaLinha = ContaLinha + 1
            drLinha("NomeZ4") = ZonesList(ContaLinha)
            ContaLinha = ContaLinha + 1

            drLinha("NokZona5") = ZonesList(ContaLinha)
            ContaLinha = ContaLinha + 1
            drLinha("OkZona5") = ZonesList(ContaLinha)
            ContaLinha = ContaLinha + 1
            drLinha("NomeZ5") = ZonesList(ContaLinha)
            ContaLinha = ContaLinha + 1

            dtZones.Rows.Add(drLinha)

            ContaLinha = ContaLinha + 1

        End While

        basTrataDados.SdDados.Add(dtZones)


        Return True

    End Function

    'FB_STAT
    Private Function FbStat(Optional ByVal Stat As String = "") As Boolean


        Dim StatList As ArrayList = New ArrayList()

        StatList.Add(Stat.Substring(0, 10))
        StatList.Add(Stat.Substring(12, 8))
        StatList.Add(Stat.Substring(21, 8))
        StatList.Add(Stat.Substring(30, 8))
        StatList.Add(Stat.Substring(39, 8))
        StatList.Add(Stat.Substring(48, 4))
        StatList.Add(Stat.Substring(53, 4))
        StatList.Add(Stat.Substring(58, 4))
        StatList.Add(Stat.Substring(63, 4))
        StatList.Add(Stat.Substring(68, 1))

        'Monta tabela
        Dim dtStat As New DataTable("StatDados")
        dtStat.Columns.Add("IdStat", GetType(String))
        dtStat.Columns.Add("NumBatch", GetType(String))
        dtStat.Columns.Add("LimTo2", GetType(String))
        dtStat.Columns.Add("LimTo1", GetType(String))
        dtStat.Columns.Add("LimTu1", GetType(String))
        dtStat.Columns.Add("LimTu2", GetType(String))
        dtStat.Columns.Add("TolerSys", GetType(String))
        dtStat.Columns.Add("Tu1Perc", GetType(String))
        dtStat.Columns.Add("TipoIntervalo", GetType(String))
        dtStat.Columns.Add("Escopo", GetType(String))
        dtStat.Columns.Add("Estat", GetType(String))
        dtStat.Columns.Add("DataHora", GetType(String))

        Dim ContaLinha As Integer = 0

        'Escreve na tabela
        While ContaLinha < StatList.Count

            Dim drLinha As DataRow = dtStat.NewRow
            drLinha("NumBatch") = StatList(ContaLinha)
            ContaLinha = ContaLinha + 1
            drLinha("LimTo2") = StatList(ContaLinha)
            ContaLinha = ContaLinha + 1
            drLinha("LimTo1") = StatList(ContaLinha)
            ContaLinha = ContaLinha + 1
            drLinha("LimTu1") = StatList(ContaLinha)
            ContaLinha = ContaLinha + 1
            drLinha("LimTu2") = StatList(ContaLinha)
            ContaLinha = ContaLinha + 1
            drLinha("TolerSys") = StatList(ContaLinha)
            ContaLinha = ContaLinha + 1
            drLinha("Tu1Perc") = StatList(ContaLinha)
            ContaLinha = ContaLinha + 1
            drLinha("TipoIntervalo") = StatList(ContaLinha)
            ContaLinha = ContaLinha + 1
            drLinha("Escopo") = StatList(ContaLinha)
            ContaLinha = ContaLinha + 1
            drLinha("Estat") = StatList(ContaLinha)
            ContaLinha = ContaLinha + 1

            dtStat.Rows.Add(drLinha)

            ContaLinha = ContaLinha + 1

        End While

        basTrataDados.SdDados.Add(dtStat)


        Return True

    End Function

    'FB_STAT2
    Private Function FbStat2(Optional ByVal Stat2 As String = "") As Boolean


        Dim Stat2List As ArrayList = New ArrayList()

        Stat2List.Add(Stat2.Substring(0, 8))
        Stat2List.Add(Stat2.Substring(10, 1))
        Stat2List.Add(Stat2.Substring(12, 1))
        Stat2List.Add(Stat2.Substring(14, 1))
        Stat2List.Add(Stat2.Substring(16, 1))
        Stat2List.Add(Stat2.Substring(18, 1))
        Stat2List.Add(Stat2.Substring(20, 1))
        Stat2List.Add(Stat2.Substring(22, 1))


        'Monta tabela
        Dim dtStat2 As New DataTable("Stat2Dados")
        dtStat2.Columns.Add("IdZones", GetType(String))
        dtStat2.Columns.Add("Tu1PercMax", GetType(String))
        dtStat2.Columns.Add("QtdProdNokTu1", GetType(String))
        dtStat2.Columns.Add("QtdProdNokTu2", GetType(String))
        dtStat2.Columns.Add("VlMedioProNok", GetType(String))
        dtStat2.Columns.Add("VlMedioRef", GetType(String))
        dtStat2.Columns.Add("PrintAuto", GetType(String))
        dtStat2.Columns.Add("PrintHora", GetType(String))
        dtStat2.Columns.Add("PrintBatchHora", GetType(String))

        Dim ContaLinha As Integer = 0

        'Escreve na tabela
        While ContaLinha < Stat2List.Count

            Dim drLinha As DataRow = dtStat2.NewRow
            drLinha("Tu1PercMax") = Stat2List(ContaLinha)
            ContaLinha = ContaLinha + 1
            drLinha("QtdProdNokTu1") = Stat2List(ContaLinha)
            ContaLinha = ContaLinha + 1
            drLinha("QtdProdNokTu2") = Stat2List(ContaLinha)
            ContaLinha = ContaLinha + 1
            drLinha("VlMedioProNok") = Stat2List(ContaLinha)
            ContaLinha = ContaLinha + 1
            drLinha("VlMedioRef") = Stat2List(ContaLinha)
            ContaLinha = ContaLinha + 1
            drLinha("PrintAuto") = Stat2List(ContaLinha)
            ContaLinha = ContaLinha + 1
            drLinha("PrintHora") = Stat2List(ContaLinha)
            ContaLinha = ContaLinha + 1
            drLinha("PrintBatchHora") = Stat2List(ContaLinha)
            ContaLinha = ContaLinha + 1

            dtStat2.Rows.Add(drLinha)

            ContaLinha = ContaLinha + 1

        End While


        basTrataDados.SdDados.Add(dtStat2)


        Return True

    End Function

#End Region


#Region "ProdDados"

    'PD_PLUS
    Private Function PdPlus(Optional ByVal Plus As String = "") As Boolean


        Dim PlusList() As String = Plus.Split(New [Char]() {" "c}, StringSplitOptions.RemoveEmptyEntries)

        'Monta tabela
        Dim dtPlus As New DataTable("PlusDados")
        dtPlus.Columns.Add("QtdProdZ3", GetType(String))
        dtPlus.Columns.Add("PesoTotalZ3", GetType(String))
        dtPlus.Columns.Add("VlMedioZ3", GetType(String))
        dtPlus.Columns.Add("QtdProdZ2", GetType(String))
        dtPlus.Columns.Add("PesoTotalZ2", GetType(String))
        dtPlus.Columns.Add("VlMedioZ2", GetType(String))
        dtPlus.Columns.Add("QtdProdZ1", GetType(String))
        dtPlus.Columns.Add("PesoTotalZ1", GetType(String))
        dtPlus.Columns.Add("VlMedioZ1", GetType(String))

        Dim ContaLinha As Integer = 0

        'Escreve na tabela
        While ContaLinha < PlusList.Count

            Dim drLinha As DataRow = dtPlus.NewRow

            drLinha("QtdProdZ3") = PlusList(ContaLinha)
            ContaLinha = ContaLinha + 1
            drLinha("PesoTotalZ3") = PlusList(ContaLinha)
            ContaLinha = ContaLinha + 1
            drLinha("VlMedioZ3") = PlusList(ContaLinha)
            ContaLinha = ContaLinha + 1
            drLinha("QtdProdZ2") = PlusList(ContaLinha)
            ContaLinha = ContaLinha + 1
            drLinha("PesoTotalZ2") = PlusList(ContaLinha)
            ContaLinha = ContaLinha + 1
            drLinha("VlMedioZ2") = PlusList(ContaLinha)
            ContaLinha = ContaLinha + 1
            drLinha("QtdProdZ1") = PlusList(ContaLinha)
            ContaLinha = ContaLinha + 1
            drLinha("PesoTotalZ1") = PlusList(ContaLinha)
            ContaLinha = ContaLinha + 1
            drLinha("VlMedioZ1") = PlusList(ContaLinha)
            ContaLinha = ContaLinha + 1

            dtPlus.Rows.Add(drLinha)

            ContaLinha = ContaLinha + 1

        End While

        basTrataDados.Prod.Add(dtPlus)

        Return True

    End Function

    'PD_GUT
    Private Function PdGut(Optional ByVal Gut As String = "") As Boolean


        Dim GutList() As String = Gut.Split(New [Char]() {" "c}, StringSplitOptions.RemoveEmptyEntries)

        'Monta tabela
        Dim dtGut As New DataTable("GutDados")
        dtGut.Columns.Add("IdGut", GetType(Integer))
        dtGut.Columns.Add("QtdProdOk", GetType(String))
        dtGut.Columns.Add("PesoTotalOk", GetType(String))
        dtGut.Columns.Add("VlMedioOk", GetType(String))
        dtGut.Columns.Add("QtdProdSpecial", GetType(String))
        dtGut.Columns.Add("QtdProdMetalDt", GetType(String))

        Dim ContaLinha As Integer = 0

        'Escreve na tabela
        While ContaLinha < GutList.Count

            Dim drLinha As DataRow = dtGut.NewRow
            drLinha("QtdProdOk") = GutList(ContaLinha)
            ContaLinha = ContaLinha + 1
            drLinha("PesoTotalOk") = GutList(ContaLinha)
            ContaLinha = ContaLinha + 1
            drLinha("VlMedioOk") = GutList(ContaLinha)
            ContaLinha = ContaLinha + 1
            drLinha("QtdProdSpecial") = GutList(ContaLinha)
            ContaLinha = ContaLinha + 1
            drLinha("QtdProdMetalDt") = GutList(ContaLinha)
            ContaLinha = ContaLinha + 1

            dtGut.Rows.Add(drLinha)

            ContaLinha = ContaLinha + 1

        End While

        basTrataDados.Prod.Add(dtGut)

        Return True

    End Function

    'PD_MINUS
    Private Function PdMinus(Optional ByVal Minus As String = "") As Boolean


        Dim MinusList() As String = Minus.Split(New [Char]() {" "c}, StringSplitOptions.RemoveEmptyEntries)

        'Monta tabela
        Dim dtMinus As New DataTable("MinusDados")
        dtMinus.Columns.Add("IdMinus", GetType(Integer))
        dtMinus.Columns.Add("QtdProdZ1", GetType(String))
        dtMinus.Columns.Add("PesoTotalZ1", GetType(String))
        dtMinus.Columns.Add("VlMedioZ1", GetType(String))
        dtMinus.Columns.Add("QtdProdZ2", GetType(String))
        dtMinus.Columns.Add("PesoTotalZ2", GetType(String))
        dtMinus.Columns.Add("VlMedioZ2", GetType(String))
        dtMinus.Columns.Add("QtdProdZ3", GetType(String))
        dtMinus.Columns.Add("PesoTotalZ3", GetType(String))
        dtMinus.Columns.Add("VlMedioZ3", GetType(String))

        Dim ContaLinha As Integer = 0

        'Escreve na tabela
        While ContaLinha < MinusList.Count

            Dim drLinha As DataRow = dtMinus.NewRow
            drLinha("QtdProdZ1") = MinusList(ContaLinha)
            ContaLinha = ContaLinha + 1
            drLinha("PesoTotalZ1") = MinusList(ContaLinha)
            ContaLinha = ContaLinha + 1
            drLinha("VlMedioZ1") = MinusList(ContaLinha)
            ContaLinha = ContaLinha + 1
            drLinha("QtdProdZ2") = MinusList(ContaLinha)
            ContaLinha = ContaLinha + 1
            drLinha("PesoTotalZ2") = MinusList(ContaLinha)
            ContaLinha = ContaLinha + 1
            drLinha("VlMedioZ2") = MinusList(ContaLinha)
            ContaLinha = ContaLinha + 1
            drLinha("QtdProdZ3") = MinusList(ContaLinha)
            ContaLinha = ContaLinha + 1
            drLinha("PesoTotalZ3") = MinusList(ContaLinha)
            ContaLinha = ContaLinha + 1
            drLinha("VlMedioZ3") = MinusList(ContaLinha)
            ContaLinha = ContaLinha + 1

            dtMinus.Rows.Add(drLinha)

            ContaLinha = ContaLinha + 1

        End While

        basTrataDados.Prod.Add(dtMinus)

        Return True

    End Function

    'PD_STAT
    Private Function PdStat(Optional ByVal Stat As String = "") As Boolean


        'Dim StatList() As String = Stat.Split(New [Char]() {" "c}, StringSplitOptions.RemoveEmptyEntries)

        Dim StatList As ArrayList = New ArrayList()
        StatList.Add(Stat.Substring(1, 10))
        StatList.Add(Stat.Substring(12, 5))
        StatList.Add(Stat.Substring(17, 20))
        StatList.Add(Stat.Substring(38, 10))
        StatList.Add(Stat.Substring(49, 8))
        StatList.Add(Stat.Substring(58, 8))
        StatList.Add(Stat.Substring(67, 8))
        StatList.Add(Stat.Substring(76, 8))
        StatList.Add(Stat.Substring(84, 8))
        StatList.Add(Stat.Substring(92, 9))
        StatList.Add(Stat.Substring(102, 8))
        StatList.Add(Stat.Substring(110, 8))
        StatList.Add(Stat.Substring(117, 6))
        StatList.Add(Stat.Substring(122, 6))
        StatList.Add(Stat.Substring(127, 5))


        'Monta tabela
        Dim dtStat As New DataTable("StatDados")
        dtStat.Columns.Add("IdStat", GetType(Integer))
        dtStat.Columns.Add("Data", GetType(String))
        dtStat.Columns.Add("Hora", GetType(String))
        dtStat.Columns.Add("Artigo", GetType(String))
        dtStat.Columns.Add("NumBatch", GetType(String))
        dtStat.Columns.Add("PesoNominal", GetType(String))
        dtStat.Columns.Add("Tara", GetType(String))
        dtStat.Columns.Add("QtdProdOk", GetType(String))
        dtStat.Columns.Add("QtdProdNok", GetType(String))
        dtStat.Columns.Add("ValorMedio", GetType(String))
        dtStat.Columns.Add("DesvioPadrao", GetType(String))
        dtStat.Columns.Add("Tu1Lim", GetType(String))
        dtStat.Columns.Add("QtdProd<Tu1Lim", GetType(String))
        dtStat.Columns.Add("QtdProdPerc", GetType(String))
        dtStat.Columns.Add("Tu2Lim", GetType(String))
        dtStat.Columns.Add("QtdProd<Tu2Lim", GetType(String))

        Dim ContaLinha As Integer = 0

        'Escreve na tabela
        While ContaLinha < StatList.Count

            Dim drLinha As DataRow = dtStat.NewRow
            'drLinha("Data") = Stat.Substring(0, 11)
            drLinha("Data") = StatList(ContaLinha)
            ContaLinha = ContaLinha + 1
            'drLinha("Hora") = Stat.Substring(13, 6)
            drLinha("Hora") = StatList(ContaLinha)
            ContaLinha = ContaLinha + 1
            'drLinha("Artigo") = Stat.Substring(17, 20)
            drLinha("Artigo") = StatList(ContaLinha)
            ContaLinha = ContaLinha + 1
            'drLinha("NumBatch") = Stat.Substring(38, 10)
            drLinha("NumBatch") = StatList(ContaLinha)
            ContaLinha = ContaLinha + 1
            'drLinha("PesoNominal") = Stat.Substring(49, 8)
            drLinha("PesoNominal") = StatList(ContaLinha)
            ContaLinha = ContaLinha + 1
            'drLinha("Tara") = Stat.Substring(58, 8)
            drLinha("Tara") = StatList(ContaLinha)
            ContaLinha = ContaLinha + 1
            'drLinha("QtdProdOk") = Stat.Substring(67, 8)
            drLinha("QtdProdOk") = StatList(ContaLinha)
            ContaLinha = ContaLinha + 1
            'drLinha("QtdProdNok") = Stat.Substring(76, 8)
            drLinha("QtdProdNok") = StatList(ContaLinha)
            ContaLinha = ContaLinha + 1
            'drLinha("ValorMedio") = Stat.Substring(84, 8)
            drLinha("ValorMedio") = StatList(ContaLinha)
            ContaLinha = ContaLinha + 1
            'drLinha("DesvioPadrao") = Stat.Substring(92, 8)
            drLinha("DesvioPadrao") = StatList(ContaLinha)
            ContaLinha = ContaLinha + 1
            'drLinha("Tu1Lim") = Stat.Substring(100, 8)
            drLinha("Tu1Lim") = StatList(ContaLinha)
            ContaLinha = ContaLinha + 1
            'drLinha("QtdProd<Tu1Lim") = Stat.Substring(108, 8)
            drLinha("QtdProd<Tu1Lim") = StatList(ContaLinha)
            ContaLinha = ContaLinha + 1
            'drLinha("QtdProdPerc") = Stat.Substring(116, 6)
            drLinha("QtdProdPerc") = StatList(ContaLinha)
            ContaLinha = ContaLinha + 1
            'drLinha("Tu2Lim") = Stat.Substring(122, 5)
            drLinha("Tu2Lim") = StatList(ContaLinha)
            ContaLinha = ContaLinha + 1
            'drLinha("QtdProd<Tu2Lim") = Stat.Substring(127, 5)
            drLinha("QtdProd<Tu2Lim") = StatList(ContaLinha)
            ContaLinha = ContaLinha + 1

            dtStat.Rows.Add(drLinha)

            ContaLinha = ContaLinha + 1

        End While

        basTrataDados.Prod.Add(dtStat)

        Return True

    End Function

    'PD_AKTINT
    Private Function PdAkt(Optional ByVal AktInt As String = "") As Boolean


        Dim AktIntList() As String = AktInt.Split(New [Char]() {" "c}, StringSplitOptions.RemoveEmptyEntries)

        'Monta tabela
        Dim dtAkt As New DataTable("AktDados")
        dtAkt.Columns.Add("IdAkt", GetType(Integer))
        dtAkt.Columns.Add("Data", GetType(String))
        dtAkt.Columns.Add("Hora", GetType(String))
        dtAkt.Columns.Add("NumPdOk", GetType(String))
        dtAkt.Columns.Add("NumPdNok", GetType(String))
        dtAkt.Columns.Add("VlMedio", GetType(String))
        dtAkt.Columns.Add("DvPadrao", GetType(String))
        dtAkt.Columns.Add("Tu1Lim", GetType(String))
        dtAkt.Columns.Add("NmTu1Lim", GetType(String))
        dtAkt.Columns.Add("Tu1Perc", GetType(String))
        dtAkt.Columns.Add("Tu2Lim", GetType(String))
        dtAkt.Columns.Add("NmTu2Lim", GetType(String))

        Dim ContaLinha As Integer = 0

        'Escreve na tabela
        While ContaLinha < AktIntList.Count

            Dim drLinha As DataRow = dtAkt.NewRow
            drLinha("Data") = AktIntList(ContaLinha)
            ContaLinha = ContaLinha + 1
            drLinha("Hora") = AktIntList(ContaLinha)
            ContaLinha = ContaLinha + 1
            drLinha("NumPdOk") = AktIntList(ContaLinha)
            ContaLinha = ContaLinha + 1
            drLinha("NumPdNok") = AktIntList(ContaLinha)
            ContaLinha = ContaLinha + 1
            drLinha("VlMedio") = AktIntList(ContaLinha)
            ContaLinha = ContaLinha + 1
            drLinha("DvPadrao") = AktIntList(ContaLinha)
            ContaLinha = ContaLinha + 1
            drLinha("Tu1Lim") = AktIntList(ContaLinha)
            ContaLinha = ContaLinha + 1
            drLinha("NmTu1Lim") = AktIntList(ContaLinha)
            ContaLinha = ContaLinha + 1
            drLinha("Tu1Perc") = AktIntList(ContaLinha)
            ContaLinha = ContaLinha + 1
            drLinha("Tu2Lim") = AktIntList(ContaLinha)
            ContaLinha = ContaLinha + 1
            'drLinha("NmTu2Lim") = AktIntList(ContaLinha)
            'ContaLinha = ContaLinha + 1

            dtAkt.Rows.Add(drLinha)

            ContaLinha = ContaLinha + 1

        End While

        basTrataDados.Prod.Add(dtAkt)

        Return True


    End Function

    'PD_LASTINT
    Private Function PdLastInt(Optional ByVal LastInt As String = "") As Boolean


        Dim LastList() As String = LastInt.Split(New [Char]() {" "c}, StringSplitOptions.RemoveEmptyEntries)

        'Monta tabela
        Dim dtLast As New DataTable("LastDados")
        dtLast.Columns.Add("IdLast", GetType(Integer))
        dtLast.Columns.Add("Data", GetType(String))
        dtLast.Columns.Add("Hora", GetType(String))
        dtLast.Columns.Add("NumPdOk", GetType(String))
        dtLast.Columns.Add("NumPdNok", GetType(String))
        dtLast.Columns.Add("VlMedio", GetType(String))
        dtLast.Columns.Add("DvPadrao", GetType(String))
        dtLast.Columns.Add("Tu1Lim", GetType(String))
        dtLast.Columns.Add("NmTu1Lim", GetType(String))
        dtLast.Columns.Add("Tu1Perc", GetType(String))
        dtLast.Columns.Add("Tu2Lim", GetType(String))
        dtLast.Columns.Add("NmTu2Lim", GetType(String))

        Dim ContaLinha As Integer = 0

        'Escreve na tabela
        While ContaLinha < LastList.Count

            Dim drLinha As DataRow = dtLast.NewRow
            drLinha("Data") = LastList(ContaLinha)
            ContaLinha = ContaLinha + 1
            drLinha("Hora") = LastList(ContaLinha)
            ContaLinha = ContaLinha + 1
            drLinha("NumPdOk") = LastList(ContaLinha)
            ContaLinha = ContaLinha + 1
            drLinha("NumPdNok") = LastList(ContaLinha)
            ContaLinha = ContaLinha + 1
            drLinha("VlMedio") = LastList(ContaLinha)
            ContaLinha = ContaLinha + 1
            drLinha("DvPadrao") = LastList(ContaLinha)
            ContaLinha = ContaLinha + 1
            drLinha("Tu1Lim") = LastList(ContaLinha)
            ContaLinha = ContaLinha + 1
            drLinha("NmTu1Lim") = LastList(ContaLinha)
            ContaLinha = ContaLinha + 1
            drLinha("Tu1Perc") = LastList(ContaLinha)
            ContaLinha = ContaLinha + 1
            drLinha("Tu2Lim") = LastList(ContaLinha)
            'ContaLinha = ContaLinha + 1
            'drLinha("NmTu2Lim") = LastList(ContaLinha)
            'ContaLinha = ContaLinha + 1

            dtLast.Rows.Add(drLinha)

            ContaLinha = ContaLinha + 1

        End While

        basTrataDados.Prod.Add(dtLast)

        Return True

    End Function

    'PD_CHARGE
    Private Function PdCharge(Optional ByVal Charge As String = "") As Boolean

        'Dim ChargeList() As String = Charge.Split(New [Char]() {" "c}, StringSplitOptions.RemoveEmptyEntries)

        Dim ChargeList As ArrayList = New ArrayList()
        ChargeList.Add(Charge.Substring(1, 10))
        ChargeList.Add(Charge.Substring(11, 6))
        ChargeList.Add(Charge.Substring(17, 8))
        ChargeList.Add(Charge.Substring(25, 8))
        ChargeList.Add(Charge.Substring(34, 8))
        ChargeList.Add(Charge.Substring(42, 9))
        ChargeList.Add(Charge.Substring(52, 10))
        ChargeList.Add(Charge.Substring(62, 8))
        ChargeList.Add(Charge.Substring(70, 8))
        ChargeList.Add(Charge.Substring(78, 9))
        ChargeList.Add(Charge.Substring(87, 10))
        ChargeList.Add(Charge.Substring(97, 5))


        'Monta tabela
        Dim dtCharge As New DataTable("ChargeDados")
        dtCharge.Columns.Add("IdCharge", GetType(Integer))
        dtCharge.Columns.Add("Data", GetType(String))
        dtCharge.Columns.Add("Hora", GetType(String))
        dtCharge.Columns.Add("NumBatch", GetType(String))
        dtCharge.Columns.Add("QtdProdOk", GetType(String))
        dtCharge.Columns.Add("QtdProdNok", GetType(String))
        dtCharge.Columns.Add("VlMedio", GetType(String))
        dtCharge.Columns.Add("DvPadrao", GetType(String))
        dtCharge.Columns.Add("Tu1Lim", GetType(String))
        dtCharge.Columns.Add("QtdProd<Tu1Lim", GetType(String))
        dtCharge.Columns.Add("Prod<TU1LimPerc", GetType(String))
        dtCharge.Columns.Add("Tu2Lim", GetType(String))
        dtCharge.Columns.Add("QtdProd<Tu2Lim", GetType(String))

        Dim ContaLinha As Integer = 0

        'Escreve na tabela
        While ContaLinha < ChargeList.Count

            Dim drLinha As DataRow = dtCharge.NewRow
            drLinha("Data") = ChargeList(ContaLinha)
            ContaLinha = ContaLinha + 1
            drLinha("Hora") = ChargeList(ContaLinha)
            ContaLinha = ContaLinha + 1
            drLinha("NumBatch") = ChargeList(ContaLinha)
            ContaLinha = ContaLinha + 1
            drLinha("QtdProdOk") = ChargeList(ContaLinha)
            ContaLinha = ContaLinha + 1
            drLinha("QtdProdNok") = ChargeList(ContaLinha)
            ContaLinha = ContaLinha + 1
            drLinha("VlMedio") = ChargeList(ContaLinha)
            ContaLinha = ContaLinha + 1
            drLinha("DvPadrao") = ChargeList(ContaLinha)
            ContaLinha = ContaLinha + 1
            drLinha("Tu1Lim") = ChargeList(ContaLinha)
            ContaLinha = ContaLinha + 1
            drLinha("QtdProd<Tu1Lim") = ChargeList(ContaLinha)
            ContaLinha = ContaLinha + 1
            drLinha("Prod<TU1LimPerc") = ChargeList(ContaLinha)
            ContaLinha = ContaLinha + 1
            drLinha("Tu2Lim") = ChargeList(ContaLinha)
            ContaLinha = ContaLinha + 1
            drLinha("QtdProd<Tu2Lim") = ChargeList(ContaLinha)
            'ContaLinha = ContaLinha + 1

            dtCharge.Rows.Add(drLinha)

            ContaLinha = ContaLinha + 1

        End While

        basTrataDados.Prod.Add(dtCharge)

        Return True


    End Function

    'PD_LastChr
    Private Function PdLastChr(Optional ByVal LastChr As String = "") As Boolean


        Dim DataLastCh As String = LastChr.Substring(0, 10)
        Dim HoraLastCh As String = LastChr.Substring(10, 6)
        Dim NumBatchLastCh As String = LastChr.Substring(16, 11)
        Dim NumPdOkLastCh As String = LastChr.Substring(27, 8)
        Dim NumPdNokLastCh As String = LastChr.Substring(35, 8)
        Dim VlMedioLastCh As String = LastChr.Substring(41, 11)
        Dim DvPadraoLastCh As String = LastChr.Substring(52, 10)
        Dim Tu1LimLastCh As String = LastChr.Substring(62, 8)
        Dim NmTu1LimLastCh As String = LastChr.Substring(70, 8)
        Dim Tu1PercLastCh As String = LastChr.Substring(78, 9)
        Dim Tu2LimLastCh As String = LastChr.Substring(86, 10)
        Dim NmTu2LimLastCh As String = LastChr.Substring(96, 5)

        Dim LastChrList() As String = LastChr.Split(New [Char]() {" "c}, StringSplitOptions.RemoveEmptyEntries)


        'Monta tabela
        Dim dtLast As New DataTable("LastChrDados")
        dtLast.Columns.Add("IdLastChr", GetType(String))
        dtLast.Columns.Add("Data", GetType(String))
        dtLast.Columns.Add("Hora", GetType(String))
        dtLast.Columns.Add("NumBatch", GetType(String))
        dtLast.Columns.Add("QtdPdOk", GetType(String))
        dtLast.Columns.Add("QtdPdNok", GetType(String))
        dtLast.Columns.Add("VlMedio", GetType(String))
        dtLast.Columns.Add("DvPadrao", GetType(String))
        dtLast.Columns.Add("Tu1Lim", GetType(String))
        dtLast.Columns.Add("NmTu1Lim", GetType(String))
        dtLast.Columns.Add("Tu1Perc", GetType(String))
        dtLast.Columns.Add("Tu2Lim", GetType(String))
        dtLast.Columns.Add("NmTu2Lim", GetType(String))


        Dim ContaLinha As Integer = 0

        'Escreve na tabela
        While ContaLinha < LastChrList.Count

            Dim drLinha As DataRow = dtLast.NewRow
            drLinha("Data") = LastChrList(ContaLinha)
            ContaLinha = ContaLinha + 1
            drLinha("Hora") = LastChrList(ContaLinha)
            ContaLinha = ContaLinha + 1
            drLinha("NumBatch") = LastChrList(ContaLinha)
            ContaLinha = ContaLinha + 1
            drLinha("QtdPdOk") = LastChrList(ContaLinha)
            ContaLinha = ContaLinha + 1
            drLinha("QtdPdNok") = LastChrList(ContaLinha)
            ContaLinha = ContaLinha + 1
            drLinha("VlMedio") = LastChrList(ContaLinha)
            ContaLinha = ContaLinha + 1
            drLinha("DvPadrao") = LastChrList(ContaLinha)
            ContaLinha = ContaLinha + 1
            drLinha("Tu1Lim") = LastChrList(ContaLinha)
            ContaLinha = ContaLinha + 1
            drLinha("NmTu1Lim") = LastChrList(ContaLinha)
            ContaLinha = ContaLinha + 1
            drLinha("Tu1Perc") = LastChrList(ContaLinha)
            ContaLinha = ContaLinha + 1
            drLinha("Tu2Lim") = LastChrList(ContaLinha)
            ContaLinha = ContaLinha + 1
            drLinha("NmTu2Lim") = LastChrList(ContaLinha)
            ContaLinha = ContaLinha + 1

            dtLast.Rows.Add(drLinha)

            ContaLinha = ContaLinha + 1

        End While

        basTrataDados.Prod.Add(dtLast)

        Return True

    End Function

#End Region

End Class
