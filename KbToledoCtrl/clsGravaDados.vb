Public Class clsGravaDados

    Public Sub GravaDados()

        Dim Cmd As String = DadosCli

        Dim DadosInfo As DataTable = basTrataDados.InfoMaq
        Dim DadosArt As DataTable = basTrataDados.NomesArt
        Dim DadosSenden() As String = basTrataDados.Senden
        Dim DadosHist As DataTable = basTrataDados.HistDados
        Dim DadosProd As List(Of DataTable) = basTrataDados.Prod
        Dim DadosSd As List(Of DataTable) = basTrataDados.SdDados

        Cmd = Cmd.Substring(0, 6)

        Select Case Cmd

            Case "WD_TES"
                'WD_TEST
                'TrataTestCom(ServInfo)

            Case "FB_INF"
                'FB_INFO
                GravaMaqInfo(DadosInfo)

            Case "FB_ART"
                'FB_ART_NAMES
                GravaArtNames(DadosArt)

            Case "FB_SEN"
                'FB_SENDEN
                GravaFbSenden(DadosSenden, DadosSd)

            Case "FB_ABL"
                'FB_ABLAGEN
                GravaHistDados(DadosHist)

            Case "FB_PD "
                'FB_PD*
                GravaProdDados(DadosProd)

        End Select

    End Sub

    Public Function GravaMaqInfo(Optional ByVal DadosInfo As DataTable = Nothing) As Boolean

        Dim Td As New Geral.dcToledo
        Dim MaqNw As New List(Of Geral.DadosMaq)

        Dim MaqId As Integer = 0
        Dim NomeMaq As String = ""
        Dim Dh As DateTime = Nothing
        Dim StsMaq As Integer = 0

        'Verifica se o dado ja existe, para atualizar
        NomeMaq = DadosInfo.Rows(0)("Maquina")
        Dim dtMaq = (From It In Td.DadosMaq Where It.Maquina = NomeMaq).ToList

        'Se for <= zero, insere novo dado
        If dtMaq.Count <= 0 Then

            MaqId = MaqIdNovo()
            For Conta As Integer = 0 To DadosInfo.Rows.Count - 1

                MaqId = MaqId + 1
                NomeMaq = DadosInfo.Rows(Conta)("Maquina")
                Dh = Date.Now
                StsMaq = 1

                MaqNw.Add(New Geral.DadosMaq With {.IdMaq = MaqId, _
                                                  .Maquina = NomeMaq, _
                                                  .DataHora = Dh, _
                                                  .Sts = StsMaq})

                Td.DadosMaq.InsertAllOnSubmit(MaqNw)

                'Salva os dados
                Td.SubmitChanges()

                'Configura o status
                Dim TL As New Geral.dcToledo
                Dim dtMaqInfo = (From It In TL.DadosMaq Where It.IdMaq <> MaqId).ToList
                If dtMaqInfo.Count <= 0 Then Return False

                For ContaNw As Integer = 0 To dtMaqInfo.Count - 1
                    dtMaqInfo(ContaNw).Sts = 0
                Next

            Next

        Else
            'Se for diferente de zero, atualiza o dado
            dtMaq.First.Maquina = NomeMaq
            dtMaq.First.DataHora = DateTime.Now
            dtMaq.First.Sts = 1

            Td.SubmitChanges()

        End If

        Return True

    End Function

    Public Function GravaArtNames(Optional ByVal DadosArt As DataTable = Nothing) As Boolean

        Dim Td As New Geral.dcToledo
        Dim ArtNw As New List(Of Geral.DadosArt)

        Dim IdArt As Integer = 0
        Dim Nome As String = ""
        Dim Dh As DateTime = Nothing
        Dim Sts As Integer = 0

        'Pesquisa Id da maquina
        Dim MaqId As Integer = 0
        Dim dtIdMaq = (From It In Td.DadosMaq Where It.Sts = 1).ToList
        If dtIdMaq.Count > 0 Then
            MaqId = dtIdMaq.First.IdMaq
        End If

        'Verifica se o dado ja existe
        For Conta As Integer = 0 To DadosArt.Rows.Count - 1
            Dim NomeArt = DadosArt.Rows(Conta)("Nome")
            Dim dtArtigo = (From It In Td.DadosArt Where It.Nome = NomeArt.ToString And It.IdMaq = MaqId).ToList
            If dtArtigo.Count <= 0 Then
               
                'Se nao existir, insere novo dado
                IdArt = ArtIdNovo()
                IdArt = IdArt + 1
                Dh = Date.Now
                ArtNw.Add(New Geral.DadosArt With {.IdMaq = MaqId, _
                                                     .ArtId = IdArt, _
                                                     .Nome = DadosArt.Rows(Conta)("Nome"), _
                                                     .DataHora = Dh, _
                                                     .Sts = Sts})

                Td.DadosArt.InsertAllOnSubmit(ArtNw)

                Td.SubmitChanges()


            End If

        Next

        Td.SubmitChanges()

        Return True

    End Function

    Public Function GravaFbSenden(Optional ByVal DadosSenden() As String = Nothing, _
                                  Optional ByVal DadosSd As List(Of DataTable) = Nothing) As Boolean

        'Consulta nome do artigo ativo no array
        Dim ArtAct() As String = Array.FindAll(DadosSenden, Function(s) s.Contains("GRUND"))
        Dim ArtAtivo As String = ArtAct.First.Substring(11, 20)

        Dim dtArtNome As List(Of Geral.DadosArt)
        Dim Ck As New Geral.dcToledo

        'Busca pelo nome do artigo no BD
        dtArtNome = (From It In Ck.DadosArt Where It.Nome = ArtAtivo).ToList
        If dtArtNome.Count <= 0 Then Return False
        Dim IdArt As Integer = dtArtNome.First.ArtId

        'Configura Artigo da tabela como "Artigo-Ativo"
        dtArtNome = (From it In Ck.DadosArt Where it.ArtId = IdArt).ToList
        If dtArtNome.Count <= 0 Then Return False
        dtArtNome.First.Sts = 1
        dtArtNome.First.DataHora = Date.Now

        'Configura os outros Artigos da tabela como "Artigo-Não-Ativo"
        dtArtNome = (From it In Ck.DadosArt Where it.ArtId <> IdArt).ToList
        If dtArtNome.Count <= 0 Then Return False

        For Conta As Integer = 0 To dtArtNome.Count - 1

            dtArtNome(Conta).Sts = 0
            dtArtNome(Conta).DataHora = Date.Now
        Next

        'Aplica alteracao
        Ck.SubmitChanges()

        'Pesquisa Id do "Artigo-Ativo"
        Dim dtIdArt = (From It In Ck.DadosArt Where It.Sts = 1).ToList
        If dtIdArt.Count <= 0 Then Return False
        Dim ArtId As Integer = dtIdArt.First.IdMaq

        GravaSdGrund(ArtId, DadosSd)

        GravaSdData(ArtId, DadosSd)

        GravaSdGleit(ArtId, DadosSd)

        GravaSdZones(ArtId, DadosSd)

        GravaSdStat(ArtId, DadosSd)

        GravaSdStat2(ArtId, DadosSd)


        Return True

    End Function

    Public Function GravaHistDados(Optional ByVal DadosHist As DataTable = Nothing) As Boolean

        Dim HistId As Integer = 0

        Dim Td As New Geral.dcToledo
        Dim HistNw As New List(Of Geral.DadosHist)

        'Pesquisa Id da "Maquina-Ativa"
        Dim dtMaqId = (From It In Td.DadosMaq Where It.Sts = 1).ToList
        If dtMaqId.Count <= 0 Then Return False
        Dim MaqId As Integer = dtMaqId.First.IdMaq

        'Pesquisa Id do "Artigo-Ativo"
        Dim dtIdArt = (From It In Td.DadosArt Where It.Sts = 1).ToList
        If dtIdArt.Count <= 0 Then Return False
        Dim ArtId As Integer = dtIdArt.First.IdMaq


        'Verifica se o dado ja existe
        For Conta As Integer = 0 To DadosHist.Rows.Count - 1
            Dim IniHor = DadosHist.Rows(Conta)("HorIni")
            Dim IniDt = DadosHist.Rows(Conta)("DtIni")
            Dim FinHor = DadosHist.Rows(Conta)("HorFin")
            Dim FinDt = DadosHist.Rows(Conta)("DtFin")
            Dim Rend = DadosHist.Rows(Conta)("Rend")
            Dim Media = DadosHist.Rows(Conta)("Media")
            Dim Tu1 = DadosHist.Rows(Conta)("Tu1")
            Dim dtHist = (From It In Td.DadosHist Where
                          It.IdMaq = MaqId And
                          It.IdArt = ArtId And
                          It.HorIni = IniHor.ToString And
                          It.DataIni = IniDt.ToString And
                          It.Horfin = FinHor.ToString And
                          It.DataFin = FinDt.ToString And
                          It.Rendimento = Rend.ToString And
                          It.TU1Infrac = Tu1.ToString).ToList

            If dtHist.Count <= 0 Then
                'Se nao existir, insere novo dado
                HistId = HistIdNovo()
                HistId = HistId + 1
                HistNw.Add(New Geral.DadosHist With {.IdMaq = MaqId, _
                                                        .IdArt = ArtId, _
                                                        .IdHist = HistId, _
                                                        .HorIni = DadosHist.Rows(Conta)("HorIni"), _
                                                        .DataIni = DadosHist.Rows(Conta)("DtIni"), _
                                                        .Horfin = DadosHist.Rows(Conta)("Horfin"), _
                                                        .DataFin = DadosHist.Rows(Conta)("DtFin"), _
                                                        .Rendimento = DadosHist.Rows(Conta)("Rend"), _
                                                        .ValorMedio = DadosHist.Rows(Conta)("Media"), _
                                                        .TU1Infrac = DadosHist.Rows(Conta)("Tu1")})

                Td.DadosHist.InsertAllOnSubmit(HistNw)
                Td.SubmitChanges()

            End If

        Next

        Return True

    End Function

    Public Function GravaProdDados(Optional ByVal DadosProd As List(Of DataTable) = Nothing) As Boolean

        Dim Ck As New Geral.dcToledo

        'Pesquisa Id do "Artigo-Ativo"
        Dim dtIdArt = (From It In Ck.DadosArt Where It.Sts = 1).ToList
        If dtIdArt.Count <= 0 Then Return False
        Dim ArtId As Integer = dtIdArt.First.IdMaq

        GravaPdPlus(ArtId, DadosProd)

        GravaPdGut(ArtId, DadosProd)

        GravaPdMinus(ArtId, DadosProd)

        GravaPdStat(ArtId, DadosProd)

        GravaPdAktInt(ArtId, DadosProd)

        GravaPdLastInt(ArtId, DadosProd)

        GravaPdCharge(ArtId, DadosProd)

        GravaPdLastChr(ArtId, DadosProd)


        Return True

    End Function

#Region "GravaSendenDados"

    'FB_GRUND
    Public Function GravaSdGrund(Optional ByVal IdArt As Integer = 0, _
                                 Optional ByVal SdDados As List(Of DataTable) = Nothing) As Boolean

        Dim Td As New Geral.dcToledo

        'Pesquisa o DataTable no ListOf
        Dim SdGrundList = (From It In SdDados Where It.TableName = "GrundDados").ToList
        If SdGrundList.Count <= 0 Then Return False

        Dim dtSendGrund As DataTable = New DataTable
        dtSendGrund = SdGrundList.First

        Dim SdGrundId As Integer = 0
        SdGrundId = GrundIdNovo()

        'Verifica se o dado ja existe
        For Conta As Integer = 0 To dtSendGrund.Rows.Count - 1
            Dim NumVer = dtSendGrund.Rows(Conta)("NumVersao")
            Dim NomeArtigo = dtSendGrund.Rows(Conta)("ArtName")
            Dim CodigoEAN = dtSendGrund.Rows(Conta)("EanCode")
            Dim UniPeso = dtSendGrund.Rows(Conta)("UnidPeso")
            Dim dtGrund = (From It In Td.SdGrund Where
                           It.NumVersion = NumVer.ToString And
                           It.NomeArt = NomeArtigo.ToString And
                           It.CodEAN = CodigoEAN.ToString And
                           It.UnidPeso = UniPeso.ToString).ToList
            If dtGrund.Count <= 0 Then
                'Se nao existir, insere novo dado
                SdGrundId = SdGrundId + 1
                Dim GrundNw As New Geral.SdGrund With {.IdArt = IdArt, _
                                                       .IdGrund = SdGrundId, _
                                                       .NumVersion = dtSendGrund.Rows(Conta)("NumVersao"), _
                                                       .NomeArt = dtSendGrund.Rows(Conta)("ArtName"), _
                                                       .CodEAN = dtSendGrund.Rows(Conta)("EanCode"), _
                                                       .UnidPeso = dtSendGrund.Rows(Conta)("UnidPeso"), _
                                                       .DataHora = DateTime.Now}
                Td.SdGrund.InsertOnSubmit(GrundNw)

            Else
                'Se existir, atualiza o dado
                Dim Id As Integer = dtGrund.First.IdGrund
                Dim dtGrundEdit = (From It In Td.SdGrund Where It.IdGrund = Id).ToList
                If dtGrundEdit.Count <= 0 Then Return False

                dtGrundEdit.First.DataHora = DateTime.Now

            End If

            Td.SubmitChanges()

        Next

        Return True

    End Function

    'FB_DATA
    Public Function GravaSdData(Optional ByVal IdArt As Integer = 0, _
                                Optional ByVal SdDados As List(Of DataTable) = Nothing) As Boolean

        Dim Td As New Geral.dcToledo

        'Pesquisa o DataTable no ListOf
        Dim SdDataList = (From It In SdDados Where It.TableName = "DatDados").ToList
        If SdDataList.Count <= 0 Then Return False

        Dim dtSdData As DataTable = New DataTable
        dtSdData = SdDataList.First

        Dim SdDataId As Integer = 0
        SdDataId = DataIdNovo()

        'Verifica se o dado ja existe
        For Conta As Integer = 0 To dtSdData.Rows.Count - 1
            Dim PsNominal = dtSdData.Rows(Conta)("PesoNom")
            Dim MediaTara = dtSdData.Rows(Conta)("TaraMedia")
            Dim TamArtigo = dtSdData.Rows(Conta)("TamArt")
            Dim NumPrNok = dtSdData.Rows(Conta)("NumProdNok")
            Dim Rendimento = dtSdData.Rows(Conta)("Rendimento")
            Dim TpAfericao = dtSdData.Rows(Conta)("TempoAfericao")
            Dim FtCorr = dtSdData.Rows(Conta)("FtCorrecao")
            Dim TmMax = dtSdData.Rows(Conta)("TamMax")
            Dim DsEspec = dtSdData.Rows(Conta)("DensEspec")
            Dim CorrDs = dtSdData.Rows(Conta)("CorrDens")
            Dim dtData = (From It In Td.SdData Where
                          It.PesoNom = PsNominal.ToString And
                          It.TaraMedia = MediaTara.ToString And
                          It.TamArt = TamArtigo.ToString And
                          It.NumProdNok = NumPrNok.ToString And
                          It.RendAlvo = Rendimento.ToString And
                          It.TempoAfericao = TpAfericao.ToString And
                          It.FtCorrecao = FtCorr.ToString And
                          It.TamMax = TmMax.ToString And
                          It.DensEspec = DsEspec.ToString And
                          It.CorrDens = CorrDs.ToString).ToList
            If dtData.Count <= 0 Then
                'Se nao existir, insere novo dado
                SdDataId = SdDataId + 1
                Dim DataNw As New Geral.SdData With {.IdArt = IdArt, _
                                                      .IdSdData = SdDataId, _
                                                      .PesoNom = dtSdData.Rows(Conta)("PesoNom"), _
                                                      .TaraMedia = dtSdData.Rows(Conta)("TaraMedia"), _
                                                      .TamArt = dtSdData.Rows(Conta)("TamArt"), _
                                                      .NumProdNok = dtSdData.Rows(Conta)("NumProdNok"), _
                                                      .RendAlvo = dtSdData.Rows(Conta)("Rendimento"), _
                                                      .TempoAfericao = dtSdData.Rows(Conta)("TempoAfericao"), _
                                                      .FtCorrecao = dtSdData.Rows(Conta)("FtCorrecao"), _
                                                      .TamMax = dtSdData.Rows(Conta)("TamMax"), _
                                                      .DensEspec = dtSdData.Rows(Conta)("DensEspec"), _
                                                      .CorrDens = dtSdData.Rows(Conta)("CorrDens"), _
                                                      .DataHora = DateTime.Now}

                Td.SdData.InsertOnSubmit(DataNw)

            Else
                'Se existir, atualiza o dado
                Dim Id As Integer = dtData.First.IdSdData
                Dim dtDataEdit = (From it In Td.SdData Where it.IdSdData = Id).ToList
                If dtDataEdit.Count <= 0 Then Return False

                dtDataEdit.First.DataHora = DateTime.Now

            End If

            Td.SubmitChanges()

        Next

        Return True

    End Function

    'FB_GLEIT
    Public Function GravaSdGleit(Optional ByVal IdArt As Integer = 0, _
                                 Optional ByVal SdDados As List(Of DataTable) = Nothing) As Boolean

        Dim Td As New Geral.dcToledo

        'Pesquisa o DataTable no ListOf
        Dim SdGleitList = (From It In SdDados Where It.TableName = "GleitDados").ToList
        If SdGleitList.Count <= 0 Then Return False

        Dim dtSdGleit As DataTable = New DataTable
        dtSdGleit = SdGleitList.First

        Dim SdGleitId As Integer = 0
        SdGleitId = GleitIdNovo()

        'Verifica se o dado ja existe
        For Conta As Integer = 0 To dtSdGleit.Rows.Count - 1
            Dim PsRef = dtSdGleit.Rows(Conta)("PesoRef")
            Dim LimAlto = dtSdGleit.Rows(Conta)("LimAlto")
            Dim T1LimPos = dtSdGleit.Rows(Conta)("T1LimPos")
            Dim T1LimNeg = dtSdGleit.Rows(Conta)("T1LimNeg")
            Dim LimBaixo = dtSdGleit.Rows(Conta)("LimBaixo")
            Dim VarLim = dtSdGleit.Rows(Conta)("VarLim")
            Dim QtdPcs = dtSdGleit.Rows(Conta)("QtdPcs")
            Dim RgTol = dtSdGleit.Rows(Conta)("RangeTol")
            Dim dtGleit = (From It In Td.SdGleit Where
                           It.PesoRef = PsRef.ToString And
                           It.LimAlto = LimAlto.ToString And
                           It.T1LimPos = T1LimPos.ToString And
                           It.T1LimNeg = T1LimNeg.ToString And
                           It.LimBaixo = LimBaixo.ToString And
                           It.VarLim = VarLim.ToString And
                           It.QtdPcs = QtdPcs.ToString And
                           It.RangeTol = RgTol.ToString).ToList
            If dtGleit.Count <= 0 Then
                'Se nao existir, insere novo dado
                SdGleitId = SdGleitId + 1
                Dim GleitNw As New Geral.SdGleit With {.IdArt = IdArt, _
                                                        .IdSdGleit = SdGleitId, _
                                                        .PesoRef = dtSdGleit.Rows(Conta)("PesoRef"), _
                                                        .LimAlto = dtSdGleit.Rows(Conta)("LimAlto"), _
                                                        .T1LimPos = dtSdGleit.Rows(Conta)("T1LimPos"), _
                                                        .T1LimNeg = dtSdGleit.Rows(Conta)("T1LimNeg"), _
                                                        .LimBaixo = dtSdGleit.Rows(Conta)("LimBaixo"), _
                                                        .VarLim = dtSdGleit.Rows(Conta)("VarLim"), _
                                                        .QtdPcs = dtSdGleit.Rows(Conta)("QtdPcs"), _
                                                        .RangeTol = dtSdGleit.Rows(Conta)("RangeTol"), _
                                                        .DataHora = DateTime.Now}
                Td.SdGleit.InsertOnSubmit(GleitNw)

            Else
                'Se existir, atualiza o dado
                Dim Id As Integer = dtGleit.First.IdSdGleit
                Dim dtGleitEdit = (From It In Td.SdGrund Where It.IdGrund = Id).ToList
                If dtGleitEdit.Count <= 0 Then Return False

                dtGleitEdit.First.DataHora = DateTime.Now

            End If

            Td.SubmitChanges()

        Next

        Return True

    End Function

    'FB_ZONES
    Public Function GravaSdZones(Optional ByVal IdArt As Integer = 0, _
                                 Optional ByVal SdDados As List(Of DataTable) = Nothing) As Boolean

        Dim Td As New Geral.dcToledo

        'Pesquisa o DataTable no ListOf
        Dim SdZoneList = (From It In SdDados Where It.TableName = "ZonesDados").ToList
        If SdZoneList.Count <= 0 Then Return False

        Dim dtSdZone As DataTable = New DataTable
        dtSdZone = SdZoneList.First

        Dim SdZonesId As Integer = 0
        SdZonesId = ZonesIdNovo()

        'Verifica se o dado ja existe
        For Conta As Integer = 0 To dtSdZone.Rows.Count - 1
            Dim NokZona1 = dtSdZone.Rows(Conta)("NokZona1")
            Dim OkZona1 = dtSdZone.Rows(Conta)("OkZona1")
            Dim NomeZ1 = dtSdZone.Rows(Conta)("NomeZ1")

            Dim NokZona2 = dtSdZone.Rows(Conta)("NokZona2")
            Dim OkZona2 = dtSdZone.Rows(Conta)("OkZona2")
            Dim NomeZ2 = dtSdZone.Rows(Conta)("NomeZ2")

            Dim NokZona3 = dtSdZone.Rows(Conta)("NokZona3")
            Dim OkZona3 = dtSdZone.Rows(Conta)("OkZona3")
            Dim NomeZ3 = dtSdZone.Rows(Conta)("NomeZ3")

            Dim NokZona4 = dtSdZone.Rows(Conta)("NokZona4")
            Dim OkZona4 = dtSdZone.Rows(Conta)("OkZona4")
            Dim NomeZ4 = dtSdZone.Rows(Conta)("NomeZ4")

            Dim NokZona5 = dtSdZone.Rows(Conta)("NokZona5")
            Dim OkZona5 = dtSdZone.Rows(Conta)("OkZona5")
            Dim NomeZ5 = dtSdZone.Rows(Conta)("NomeZ5")
            Dim dtZones = (From It In Td.SdZones Where
                          It.NokZona1 = NokZona1.ToString And
                          It.OkZona1 = OkZona1.ToString And
                          It.NomeZ1 = NomeZ1.ToString And
                          It.NokZona2 = NokZona2.ToString And
                          It.OkZona2 = OkZona2.ToString And
                          It.NomeZ2 = NomeZ2.ToString And
                          It.NokZona3 = NokZona3.ToString And
                          It.OkZona3 = OkZona3.ToString And
                          It.NomeZ3 = NomeZ3.ToString And
                          It.NokZona4 = NokZona4.ToString And
                          It.OkZona4 = OkZona4.ToString And
                          It.NomeZ4 = NomeZ4.ToString And
                          It.NokZona5 = NokZona5.ToString And
                          It.OkZona5 = OkZona5.ToString And
                          It.NomeZ5 = NomeZ5.ToString).ToList
            If dtZones.Count <= 0 Then
                'Se nao existir, insere novo dado
                SdZonesId = SdZonesId + 1
                Dim ZonesNw As New Geral.SdZones With {.IdArt = IdArt, _
                                                         .IdSdZones = SdZonesId, _
                                                         .NokZona1 = dtSdZone.Rows(Conta)("NokZona1"), _
                                                         .OkZona1 = dtSdZone.Rows(Conta)("OkZona1"), _
                                                         .NomeZ1 = dtSdZone.Rows(Conta)("NomeZ1"), _
                                                         .NokZona2 = dtSdZone.Rows(Conta)("NokZona2"), _
                                                         .OkZona2 = dtSdZone.Rows(Conta)("OkZona2"), _
                                                         .NomeZ2 = dtSdZone.Rows(Conta)("NomeZ2"), _
                                                         .NokZona3 = dtSdZone.Rows(Conta)("NokZona3"), _
                                                         .OkZona3 = dtSdZone.Rows(Conta)("OkZona3"), _
                                                         .NomeZ3 = dtSdZone.Rows(Conta)("NomeZ3"), _
                                                         .NokZona4 = dtSdZone.Rows(Conta)("NokZona4"), _
                                                         .OkZona4 = dtSdZone.Rows(Conta)("OkZona4"), _
                                                         .NomeZ4 = dtSdZone.Rows(Conta)("NomeZ4"), _
                                                         .NokZona5 = dtSdZone.Rows(Conta)("NokZona5"), _
                                                         .OkZona5 = dtSdZone.Rows(Conta)("OkZona5"), _
                                                         .NomeZ5 = dtSdZone.Rows(Conta)("NomeZ5"), _
                                                         .DataHora = DateTime.Now}

                Td.SdZones.InsertOnSubmit(ZonesNw)

            Else
                'Se existir, atualiza o dado
                Dim Id As Integer = dtZones.First.IdSdZones
                Dim dtZonesEdit = (From It In Td.SdZones Where It.IdSdZones = Id).ToList
                If dtZonesEdit.Count <= 0 Then Return False

                dtZonesEdit.First.DataHora = DateTime.Now

            End If

            Td.SubmitChanges()

        Next

        Return True

    End Function

    'FB_STAT
    Public Function GravaSdStat(Optional ByVal IdArt As Integer = 0, _
                                Optional ByVal SdDados As List(Of DataTable) = Nothing) As Boolean

        Dim Td As New Geral.dcToledo

        'Pesquisa o DataTable no ListOf
        Dim SdStatList = (From It In SdDados Where It.TableName = "StatDados").ToList
        If SdStatList.Count <= 0 Then Return False

        Dim dtSdStat = New DataTable
        dtSdStat = SdStatList.First

        Dim SdStatId As Integer = 0
        SdStatId = SdStatIdNovo()

        'Verifica se o dado ja existe
        For Conta As Integer = 0 To dtSdStat.Rows.Count - 1
            Dim NumBatch = dtSdStat.Rows(Conta)("NumBatch")
            Dim LimTo2 = dtSdStat.Rows(Conta)("LimTo2")
            Dim LimTo1 = dtSdStat.Rows(Conta)("LimTo1")
            Dim LimTu1 = dtSdStat.Rows(Conta)("LimTu1")
            Dim LimTu2 = dtSdStat.Rows(Conta)("LimTu2")
            Dim TolerSys = dtSdStat.Rows(Conta)("TolerSys")
            Dim Tu1Perc = dtSdStat.Rows(Conta)("Tu1Perc")
            Dim TipoInter = dtSdStat.Rows(Conta)("TipoIntervalo")
            Dim Escopo = dtSdStat.Rows(Conta)("Escopo")
            Dim Estat = dtSdStat.Rows(Conta)("Estat")
            Dim dtStat = (From It In Td.SdStat Where
                          It.NumBatch = NumBatch.ToString And
                          It.LimTo2 = LimTo2.ToString And
                          It.LimTo1 = LimTo1.ToString And
                          It.LimTu1 = LimTu1.ToString And
                          It.LimTu2 = LimTu2.ToString And
                          It.TolerSys = TolerSys.ToString And
                          It.Tu1Perc = Tu1Perc.ToString And
                          It.TipoIntervalo = TipoInter.ToString And
                          It.Escopo = Escopo.ToString And
                          It.Estat = Estat.ToString).ToList
            If dtStat.Count <= 0 Then
                'Se nao existir, insere novo dado
                SdStatId = SdStatId + 1
                Dim StatNw As New Geral.SdStat With {.IdArt = IdArt, _
                                                      .IdSdStat = SdStatId, _
                                                      .NumBatch = dtSdStat.Rows(Conta)("NumBatch"), _
                                                      .LimTo2 = dtSdStat.Rows(Conta)("LimTo2"), _
                                                      .LimTo1 = dtSdStat.Rows(Conta)("LimTo1"), _
                                                      .LimTu1 = dtSdStat.Rows(Conta)("LimTu1"), _
                                                      .LimTu2 = dtSdStat.Rows(Conta)("LimTu2"), _
                                                      .TolerSys = dtSdStat.Rows(Conta)("TolerSys"), _
                                                      .Tu1Perc = dtSdStat.Rows(Conta)("Tu1Perc"), _
                                                      .TipoIntervalo = dtSdStat.Rows(Conta)("TipoIntervalo"), _
                                                      .Escopo = dtSdStat.Rows(Conta)("Escopo"), _
                                                      .Estat = dtSdStat.Rows(Conta)("Estat"), _
                                                      .DataHora = DateTime.Now}

                Td.SdStat.InsertOnSubmit(StatNw)
            Else
                'Se existir, atualiza o dado
                Dim Id As Integer = dtStat.First.IdSdStat
                Dim dtStatEdit = (From It In Td.SdStat Where It.IdSdStat = Id).ToList
                If dtStatEdit.Count <= 0 Then Return False

                dtStatEdit.First.DataHora = DateTime.Now

            End If

            Td.SubmitChanges()

        Next

        Return True

    End Function

    'FB_STAT2
    Public Function GravaSdStat2(Optional ByVal IdArt As Integer = 0, _
                                 Optional ByVal SdDados As List(Of DataTable) = Nothing) As Boolean

        Dim Td As New Geral.dcToledo

        'Pesquisa o DataTable no ListOf
        Dim SdStat2List = (From It In SdDados Where It.TableName = "Stat2Dados").ToList
        If SdStat2List.Count <= 0 Then Return False

        Dim dtSdStat2 = New DataTable
        dtSdStat2 = SdStat2List.First

        Dim SdStat2Id As Integer = 0
        SdStat2Id = SdStat2IdNovo()

        'Verifica se o dado ja existe
        For Conta As Integer = 0 To dtSdStat2.Rows.Count - 1
            Dim Tu1PercMax = dtSdStat2.Rows(Conta)("Tu1PercMax")
            Dim QtdProdNokTu1 = dtSdStat2.Rows(Conta)("QtdProdNokTu1")
            Dim QtdProdNokTu2 = dtSdStat2.Rows(Conta)("QtdProdNokTu2")
            Dim VlMedioProNok = dtSdStat2.Rows(Conta)("VlMedioProNok")
            Dim VlMedioRef = dtSdStat2.Rows(Conta)("VlMedioRef")
            Dim PrintAuto = dtSdStat2.Rows(Conta)("PrintAuto")
            Dim PrintHora = dtSdStat2.Rows(Conta)("PrintHora")
            Dim PrintBatchHora = dtSdStat2.Rows(Conta)("PrintBatchHora")
            Dim dtStat2 = (From It In Td.SdStat2 Where
                           It.Tu1PercMax = Tu1PercMax.ToString And
                           It.QtdProdNokTu1 = QtdProdNokTu1.ToString And
                           It.QtdProdNokTu2 = QtdProdNokTu2.ToString And
                           It.VlMedioProNok = VlMedioProNok.ToString And
                           It.VlMedioRef = VlMedioRef.ToString And
                           It.PrintAuto = PrintAuto.ToString And
                           It.PrintBatchHora = PrintBatchHora.ToString).ToList
            If dtStat2.Count <= 0 Then
                'Se nao existir, insere novo dado
                SdStat2Id = SdStat2Id + 1
                Dim Stat2Nw As New Geral.SdStat2 With {.IdArt = IdArt, _
                                                        .IdSdStat2 = SdStat2Id, _
                                                        .Tu1PercMax = dtSdStat2.Rows(Conta)("Tu1PercMax"), _
                                                        .QtdProdNokTu1 = dtSdStat2.Rows(Conta)("QtdProdNokTu1"), _
                                                        .QtdProdNokTu2 = dtSdStat2.Rows(Conta)("QtdProdNokTu2"), _
                                                        .VlMedioProNok = dtSdStat2.Rows(Conta)("VlMedioProNok"), _
                                                        .VlMedioRef = dtSdStat2.Rows(Conta)("VlMedioRef"), _
                                                        .PrintAuto = dtSdStat2.Rows(Conta)("PrintHora"), _
                                                        .PrintBatchHora = dtSdStat2.Rows(Conta)("PrintBatchHora"), _
                                                        .DataHora = DateTime.Now}
                Td.SdStat2.InsertOnSubmit(Stat2Nw)

            Else
                'Se existir, atualiza o dado
                Dim Id As Integer = dtStat2.First.IdSdStat2
                Dim dtStat2Edit = (From it In Td.SdStat2 Where it.IdSdStat2 = Id).ToList
                If dtStat2Edit.Count <= 0 Then Return False

                dtStat2Edit.First.DataHora = DateTime.Now

            End If

            Td.SubmitChanges()

        Next

        Return True

    End Function

#End Region


#Region "GravaProdDados"

    'PD_PLUS
    Public Function GravaPdPlus(Optional ByVal IdArt As Integer = 0, _
                                Optional ByVal ProdDados As List(Of DataTable) = Nothing) As Boolean

        Dim Td As New Geral.dcToledo

        'Pesquisa o DataTable no ListOf
        Dim ProdPlusList = (From it In ProdDados Where it.TableName = "PlusDados").ToList
        If ProdPlusList.Count <= 0 Then Return False

        Dim dtProdPlus As DataTable = New DataTable
        dtProdPlus = ProdPlusList.First

        Dim ProdPlusId As Integer = 0
        ProdPlusId = PlusIdNovo()

        'Verifica se o dado ja existe
        For Conta As Integer = 0 To dtProdPlus.Rows.Count - 1
            Dim QtdPrZ3 = dtProdPlus.Rows(Conta)("QtdProdZ3")
            Dim PesoTtZ3 = dtProdPlus.Rows(Conta)("PesoTotalZ3")
            Dim VlMedioZ3 = dtProdPlus.Rows(Conta)("VlMedioZ3")
            Dim QtdPrZ2 = dtProdPlus.Rows(Conta)("QtdProdZ2")
            Dim PesoTtZ2 = dtProdPlus.Rows(Conta)("PesoTotalZ2")
            Dim VlMedioZ2 = dtProdPlus.Rows(Conta)("VlMedioZ2")
            Dim QtdPrZ1 = dtProdPlus.Rows(Conta)("QtdProdZ1")
            Dim PesoTtZ1 = dtProdPlus.Rows(Conta)("PesoTotalZ1")
            Dim VlMedioZ1 = dtProdPlus.Rows(Conta)("VlMedioZ1")
            Dim dtPlus = (From It In Td.ProdPlus Where
                          It.QtdProdPlusZ3 = QtdPrZ3.ToString And
                          It.PesoTotalPlusZ3 = PesoTtZ3.ToString And
                          It.VlMedioPlusZ3 = VlMedioZ3.ToString And
                          It.QtdProdPlusZ2 = QtdPrZ2.ToString And
                          It.PesoTotalPlusZ2 = PesoTtZ2.ToString And
                          It.VlMedioPlusZ2 = VlMedioZ2.ToString And
                          It.QtdProdPlusZ1 = QtdPrZ1.ToString And
                          It.PesoTotalPlusZ1 = PesoTtZ1.ToString And
                          It.VlMedioPlusZ1 = VlMedioZ1.ToString).ToList
            If dtPlus.Count <= 0 Then
                'Se nao existir, insere novo dado
                ProdPlusId = ProdPlusId + 1
                Dim PlusNw As New Geral.ProdPlus With {.IdArt = IdArt, _
                                                        .IdProdPlus = ProdPlusId, _
                                                        .QtdProdPlusZ3 = dtProdPlus.Rows(Conta)("QtdProdZ3"), _
                                                        .PesoTotalPlusZ3 = dtProdPlus.Rows(Conta)("PesoTotalZ3"), _
                                                        .VlMedioPlusZ3 = dtProdPlus.Rows(Conta)("VlMedioZ3"), _
                                                        .QtdProdPlusZ2 = dtProdPlus.Rows(Conta)("QtdProdZ2"), _
                                                        .PesoTotalPlusZ2 = dtProdPlus.Rows(Conta)("PesoTotalZ2"), _
                                                        .VlMedioPlusZ2 = dtProdPlus.Rows(Conta)("VlMedioZ2"), _
                                                        .QtdProdPlusZ1 = dtProdPlus.Rows(Conta)("QtdProdZ1"), _
                                                        .PesoTotalPlusZ1 = dtProdPlus.Rows(Conta)("PesoTotalZ1"), _
                                                        .VlMedioPlusZ1 = dtProdPlus.Rows(Conta)("VlMedioZ1"), _
                                                        .DataHora = DateTime.Now}

                Td.ProdPlus.InsertOnSubmit(PlusNw)
            Else
                'Se existir, atualiza o dado
                Dim Id As Integer = dtPlus.First.IdProdPlus
                Dim dtPlusEdit = (From It In Td.ProdPlus Where It.IdProdPlus = Id).ToList
                If dtPlusEdit.Count <= 0 Then Return False

                dtPlusEdit.First.DataHora = DateTime.Now

            End If

            Td.SubmitChanges()

        Next

        Return True

    End Function

    'PD_GUT
    Public Function GravaPdGut(Optional ByVal IdArt As Integer = 0, _
                               Optional ByVal ProdDados As List(Of DataTable) = Nothing) As Boolean

        Dim Td As New Geral.dcToledo

        'Pesquisa o DataTable no ListOf
        Dim ProdGutList = (From It In ProdDados Where It.TableName = "GutDados").ToList
        If ProdGutList.Count <= 0 Then Return False

        Dim dtProdGut As DataTable = New DataTable
        dtProdGut = ProdGutList.First

        Dim ProdGutId As Integer = 0
        ProdGutId = GutIdNovo()

        'Verifica se o dado ja existe
        For Conta As Integer = 0 To dtProdGut.Rows.Count - 1
            Dim QtdPrOk = dtProdGut.Rows(Conta)("QtdProdOk")
            Dim PesoTtOk = dtProdGut.Rows(Conta)("PesoTotalOk")
            Dim VlMedioOk = dtProdGut.Rows(Conta)("VlMedioOk")
            Dim QtdProdSpec = dtProdGut.Rows(Conta)("QtdProdSpecial")
            Dim QtdProdMtDt = dtProdGut.Rows(Conta)("QtdProdMetalDt")
            Dim dtGut = (From It In Td.ProdGut Where
                         It.QtdProdGutOk = QtdPrOk.ToString And
                         It.PesoTotalGutOk = PesoTtOk.ToString And
                         It.VlMedioGutOk = VlMedioOk.ToString And
                         It.QtdProdSpecial = QtdProdMtDt.ToString And
                         It.QtdProdMetalDt = QtdProdMtDt.ToString).ToList
            If dtGut.Count - 1 Then
                'Se nao existir, insere novo dado
                ProdGutId = ProdGutId + 1
                Dim GutNw As New Geral.ProdGut With {.IdArt = IdArt, _
                                                     .IdProdGut = ProdGutId, _
                                                     .QtdProdGutOk = dtProdGut.Rows(Conta)("QtdProdOk"), _
                                                     .PesoTotalGutOk = dtProdGut.Rows(Conta)("PesoTotalOk"), _
                                                     .VlMedioGutOk = dtProdGut.Rows(Conta)("VlMedioOk"), _
                                                     .QtdProdSpecial = dtProdGut.Rows(Conta)("QtdProdSpecial"), _
                                                     .QtdProdMetalDt = dtProdGut.Rows(Conta)("QtdProdMetalDt"), _
                                                     .DataHora = DateTime.Now}
                Td.ProdGut.InsertOnSubmit(GutNw)
            Else
                'Se existir, atualiza o dado
                Dim Id As Integer = dtGut.First.IdProdGut
                Dim dtGutEdit = (From it In Td.ProdGut Where it.IdProdGut = Id).ToList
                If dtGutEdit.Count <= 0 Then Return False

                dtGutEdit.First.DataHora = DateTime.Now

            End If

            Td.SubmitChanges()

        Next

        Return True

    End Function

    'PD_MINUS
    Public Function GravaPdMinus(Optional ByVal IdArt As Integer = 0, _
                                 Optional ByVal ProdDados As List(Of DataTable) = Nothing) As Boolean

        Dim Td As New Geral.dcToledo

        'Pesquisa o DataTable no ListOf
        Dim ProdMinusList = (From It In ProdDados Where It.TableName = "MinusDados").ToList
        If ProdMinusList.Count <= 0 Then Return False

        Dim dtProdMinus As DataTable = New DataTable
        dtProdMinus = ProdMinusList.First

        Dim ProdMinusId As Integer = 0
        ProdMinusId = MinusIdNovo()

        'Verifica se o dado ja existe
        For Conta As Integer = 0 To dtProdMinus.Rows.Count - 1
            Dim QtdPrZ1 = dtProdMinus.Rows(Conta)("QtdProdZ1")
            Dim PesoTtZ1 = dtProdMinus.Rows(Conta)("PesoTotalZ1")
            Dim VlMedioZ1 = dtProdMinus.Rows(Conta)("VlMedioZ1")
            Dim QtdPrZ2 = dtProdMinus.Rows(Conta)("QtdProdZ2")
            Dim PesoTtZ2 = dtProdMinus.Rows(Conta)("PesoTotalZ2")
            Dim VlMedioZ2 = dtProdMinus.Rows(Conta)("VlMedioZ2")
            Dim QtdPrZ3 = dtProdMinus.Rows(Conta)("QtdProdZ3")
            Dim PesoTtZ3 = dtProdMinus.Rows(Conta)("PesoTotalZ3")
            Dim VlMedioZ3 = dtProdMinus.Rows(Conta)("VlMedioZ3")
            Dim dtMinus = (From It In Td.ProdMinus Where
                           It.QtdProdMinusZ1 = QtdPrZ1.ToString And
                           It.PesoTotalMinusZ1 = PesoTtZ1.ToString And
                           It.VlMedioMinusZ1 = VlMedioZ1.ToString And
                           It.QtdProdMinusZ2 = QtdPrZ2.ToString And
                           It.PesoTotalMinusZ2 = PesoTtZ2.ToString And
                           It.VlMedioMinusZ2 = VlMedioZ2.ToString And
                           It.QtdProdMinusZ3 = QtdPrZ3.ToString And
                           It.PesoTotalMinusZ3 = PesoTtZ3.ToString And
                           It.VlMedioMinusZ3 = VlMedioZ3.ToString).ToList
            If dtMinus.Count <= 0 Then
                'Se nao existir, insere novo dado
                ProdMinusId = ProdMinusId + 1
                Dim MinusNw As New Geral.ProdMinus With {.IdArt = IdArt, _
                                                          .IdProdMinus = ProdMinusId, _
                                                          .QtdProdMinusZ1 = dtProdMinus.Rows(Conta)("QtdProdZ1"), _
                                                          .PesoTotalMinusZ1 = dtProdMinus.Rows(Conta)("PesoTotalZ1"), _
                                                          .VlMedioMinusZ1 = dtProdMinus.Rows(Conta)("VlMedioZ1"), _
                                                          .QtdProdMinusZ2 = dtProdMinus.Rows(Conta)("QtdProdZ2"), _
                                                          .PesoTotalMinusZ2 = dtProdMinus.Rows(Conta)("PesoTotalZ2"), _
                                                          .VlMedioMinusZ2 = dtProdMinus.Rows(Conta)("VlMedioZ2"), _
                                                          .QtdProdMinusZ3 = dtProdMinus.Rows(Conta)("QtdProdZ3"), _
                                                          .PesoTotalMinusZ3 = dtProdMinus.Rows(Conta)("PesoTotalZ3"), _
                                                          .VlMedioMinusZ3 = dtProdMinus.Rows(Conta)("VlMedioZ3"), _
                                                          .DataHora = DateTime.Now}

                Td.ProdMinus.InsertOnSubmit(MinusNw)
            Else
                'Se existir, atualiza o dado
                Dim Id As Integer = dtMinus.First.IdProdMinus
                Dim dtMinusEdit = (From It In Td.ProdMinus Where It.IdProdMinus = Id).ToList
                If dtMinusEdit.Count <= 0 Then Return False

                dtMinusEdit.First.DataHora = DateTime.Now

            End If

            Td.SubmitChanges()

        Next


        Return True

    End Function

    'PD_STAT
    Public Function GravaPdStat(Optional ByVal IdArt As Integer = 0, _
                                Optional ByVal ProdDados As List(Of DataTable) = Nothing) As Boolean

        Dim Td As New Geral.dcToledo

        'Pesquisa o DataTable no ListOf
        Dim ProdStatList = (From It In ProdDados Where It.TableName = "StatDados").ToList
        If ProdStatList.Count <= 0 Then Return False

        Dim dtProdStat As DataTable = New DataTable
        dtProdStat = ProdStatList.First

        Dim ProdStatId As Integer = 0
        ProdStatId = StatIdNovo()

        'Verifica se o dado ja existe
        For Conta As Integer = 0 To dtProdStat.Rows.Count - 1
            Dim Dt = dtProdStat.Rows(Conta)("Data")
            Dim Hor = dtProdStat.Rows(Conta)("Hora")
            Dim Art = dtProdStat.Rows(Conta)("Artigo")
            Dim BatchNum = dtProdStat.Rows(Conta)("NumBatch")
            Dim PesoNom = dtProdStat.Rows(Conta)("PesoNominal")
            Dim Tara = dtProdStat.Rows(Conta)("Tara")
            Dim QtdProdOk = dtProdStat.Rows(Conta)("QtdProdOk")
            Dim QtdProdNok = dtProdStat.Rows(Conta)("QtdProdNok")
            Dim VlMedio = dtProdStat.Rows(Conta)("ValorMedio")
            Dim DvPadrao = dtProdStat.Rows(Conta)("DesvioPadrao")
            Dim Tu1Lim = dtProdStat.Rows(Conta)("Tu1Lim")
            Dim QtdProdTu1Lim = dtProdStat.Rows(Conta)("QtdProd<Tu1Lim")
            Dim QtdProdPerc = dtProdStat.Rows(Conta)("QtdProdPerc")
            Dim Tu2Lim = dtProdStat.Rows(Conta)("Tu2Lim")
            Dim QtdProdTu2Lim = dtProdStat.Rows(Conta)("QtdProd<Tu2Lim")
            Dim dtStat = (From It In Td.ProdStat Where
                          It.Data = Dt.ToString And
                          It.Hora = Hor.ToString And
                          It.Artigo = Art.ToString And
                          It.NumBatch = BatchNum.ToString And
                          It.PesoNominal = PesoNom.ToString And
                          It.QtdProdOk = QtdProdOk.ToString And
                          It.QtdProdNok = QtdProdNok.ToString And
                          It.VlMedio = VlMedio.ToString And
                          It.DesvioPadrao = DvPadrao.ToString And
                          It.Tu1Lim = Tu1Lim.ToString And
                          It.QtdProdTu1Lim = QtdProdTu1Lim.ToString And
                          It.QtdProdPerc = QtdProdPerc.ToString And
                          It.Tu2Lim = Tu2Lim.ToString And
                          It.QtdProdTu2Lim = QtdProdTu2Lim.ToString).ToList

            If dtStat.Count <= 0 Then
                'Se nao existir, insere novo dado
                ProdStatId = ProdStatId + 1
                Dim StatNw As New Geral.ProdStat With {.IdArt = IdArt, _
                                                         .IdProdStat = ProdStatId, _
                                                         .Data = dtProdStat.Rows(Conta)("Data"), _
                                                         .Hora = dtProdStat.Rows(Conta)("Hora"), _
                                                         .Artigo = dtProdStat.Rows(Conta)("Artigo"), _
                                                         .NumBatch = dtProdStat.Rows(Conta)("NumBatch"), _
                                                         .PesoNominal = dtProdStat.Rows(Conta)("PesoNominal"), _
                                                         .Tara = dtProdStat.Rows(Conta)("Tara"), _
                                                         .QtdProdOk = dtProdStat.Rows(Conta)("QtdProdOk"), _
                                                         .QtdProdNok = dtProdStat.Rows(Conta)("QtdProdNok"), _
                                                         .VlMedio = dtProdStat.Rows(Conta)("ValorMedio"), _
                                                         .DesvioPadrao = dtProdStat.Rows(Conta)("DesvioPadrao"), _
                                                         .Tu1Lim = dtProdStat.Rows(Conta)("Tu1Lim"), _
                                                         .QtdProdTu1Lim = dtProdStat.Rows(Conta)("QtdProd<Tu1Lim"), _
                                                         .QtdProdPerc = dtProdStat.Rows(Conta)("QtdProdPerc"), _
                                                         .Tu2Lim = dtProdStat.Rows(Conta)("Tu2Lim"), _
                                                         .QtdProdTu2Lim = dtProdStat.Rows(Conta)("QtdProd<Tu2Lim"), _
                                                         .DataHora = DateTime.Now}

                Td.ProdStat.InsertOnSubmit(StatNw)

            Else
                'Se existir, atualiza o dado
                Dim Id As Integer = dtStat.First.IdProdStat
                Dim dtStatEdit = (From It In Td.ProdStat Where It.IdProdStat = Id).ToList
                If dtStatEdit.Count <= 0 Then Return False

                dtStatEdit.First.DataHora = DateTime.Now

            End If

            Td.SubmitChanges()

        Next

        Return True

    End Function

    'PD_AKTINT
    Public Function GravaPdAktInt(Optional ByVal IdArt As Integer = 0, _
                                  Optional ByVal ProdDados As List(Of DataTable) = Nothing) As Boolean

        Dim Td As New Geral.dcToledo

        'Pesquisa o DataTable no ListOf
        Dim ProdAktList = (From It In ProdDados Where It.TableName = "AktDados").ToList
        If ProdAktList.Count <= 0 Then Return False

        Dim dtProdAkt As DataTable = New DataTable
        dtProdAkt = ProdAktList.First

        Dim ProdAktId As Integer = 0
        ProdAktId = AktIdNovo()

        'Verifica se o dado ja existe
        For Conta As Integer = 0 To dtProdAkt.Rows.Count - 1
            Dim Dt = dtProdAkt.Rows(Conta)("Data")
            Dim Hor = dtProdAkt.Rows(Conta)("Hora")
            Dim NumPdOk = dtProdAkt.Rows(Conta)("NumPdOk")
            Dim NumPdNok = dtProdAkt.Rows(Conta)("NumPdNok")
            Dim VlMedio = dtProdAkt.Rows(Conta)("VlMedio")
            Dim DvPadrao = dtProdAkt.Rows(Conta)("DvPadrao")
            Dim Tu1Lim = dtProdAkt.Rows(Conta)("Tu1Lim")
            Dim NmTu1Lim = dtProdAkt.Rows(Conta)("NmTu1Lim")
            Dim Tu1Perc = dtProdAkt.Rows(Conta)("Tu1Perc")
            Dim Tu2Lim = dtProdAkt.Rows(Conta)("Tu2Lim")
            'Dim NmTu2Lim = dtProdAkt.Rows(Conta)("NmTu2Lim")
            Dim dtAkt = (From It In Td.ProdAktInt Where
                         It.Data = Dt.ToString And
                         It.Hora = Hor.ToString And
                         It.QtdProdOk = NumPdOk.ToString And
                         It.QtdProdNok = NumPdNok.ToString And
                         It.VlMedio = VlMedio.ToString And
                         It.DesvioPadrao = DvPadrao.ToString And
                         It.TuLim = Tu1Lim.ToString And
                         It.QtdProdTU1Lim = NmTu1Lim.ToString And
                         It.ProdTU1LimPerc = Tu1Perc.ToString And
                         It.Tu2Lim = Tu2Lim.ToString).ToList
            If dtAkt.Count - 1 Then
                'Se nao existir, insere novo dado
                ProdAktId = ProdAktId + 1
                Dim AktNw As New Geral.ProdAktInt With {.IdArt = IdArt, _
                                                       .IdProdAkt = ProdAktId, _
                                                       .Data = dtProdAkt.Rows(Conta)("Data"), _
                                                       .Hora = dtProdAkt.Rows(Conta)("Hora"), _
                                                       .QtdProdOk = dtProdAkt.Rows(Conta)("NumPdOk"), _
                                                       .QtdProdNok = dtProdAkt.Rows(Conta)("NumPdNok"), _
                                                       .VlMedio = dtProdAkt.Rows(Conta)("VlMedio"), _
                                                       .DesvioPadrao = dtProdAkt.Rows(Conta)("DvPadrao"), _
                                                       .TuLim = dtProdAkt.Rows(Conta)("Tu1Lim"), _
                                                       .QtdProdTU1Lim = dtProdAkt.Rows(Conta)("NmTu1Lim"), _
                                                       .ProdTU1LimPerc = dtProdAkt.Rows(Conta)("Tu1Perc"), _
                                                       .Tu2Lim = dtProdAkt.Rows(Conta)("Tu2Lim"), _
                                                       .DataHora = DateTime.Now}

                Td.ProdAktInt.InsertOnSubmit(AktNw)
            Else
                'Se existir, atualiza o dado
                Dim Id As Integer = dtAkt.First.IdProdAkt
                Dim dtAktEdit = (From It In Td.ProdAktInt Where It.IdProdAkt = Id).ToList
                If dtAktEdit.Count <= 0 Then Return False

                dtAktEdit.First.DataHora = DateTime.Now

            End If

            Td.SubmitChanges()

        Next

        Return True

    End Function

    'PD_LASTINT
    Public Function GravaPdLastInt(Optional ByVal IdArt As Integer = 0, _
                                   Optional ByVal ProdDados As List(Of DataTable) = Nothing) As Boolean

        Dim Td As New Geral.dcToledo

        'Pesquisa o DataTable no ListOf
        Dim ProdLastIntList = (From It In ProdDados Where It.TableName = "LastDados").ToList
        If ProdLastIntList.Count <= 0 Then Return False

        Dim dtProdLastInt As DataTable = New DataTable
        dtProdLastInt = ProdLastIntList.First

        Dim ProdLastIntId As Integer = 0
        ProdLastIntId = LastIntIdNovo()

        'Verifica se o dado ja existe
        For Conta As Integer = 0 To dtProdLastInt.Rows.Count - 1
            Dim Dt = dtProdLastInt.Rows(Conta)("Data")
            Dim Hor = dtProdLastInt.Rows(Conta)("Hora")
            Dim NumPdOk = dtProdLastInt.Rows(Conta)("NumPdOk")
            Dim NumPdNok = dtProdLastInt.Rows(Conta)("NumPdNok")
            Dim VlMedio = dtProdLastInt.Rows(Conta)("VlMedio")
            Dim DvPadrao = dtProdLastInt.Rows(Conta)("DvPadrao")
            Dim Tu1Lim = dtProdLastInt.Rows(Conta)("Tu1Lim")
            Dim NmTu1Lim = dtProdLastInt.Rows(Conta)("NmTu1Lim")
            Dim Tu1Perc = dtProdLastInt.Rows(Conta)("Tu1Perc")
            Dim Tu2Lim = dtProdLastInt.Rows(Conta)("Tu2Lim")
            'Dim NmTu2Lim = dtProdLastInt.Rows(Conta)("NmTu2Lim")
            Dim dtLtInd = (From It In Td.ProdLastInt Where
                           It.Data = Dt.ToString And
                           It.Hora = Hor.ToString And
                           It.QtdProdOk = NumPdOk.ToString And
                           It.QtdProdNok = NumPdNok.ToString And
                           It.VlMedio = VlMedio.ToString And
                           It.DesvioPadrao = DvPadrao.ToString And
                           It.TuLim = Tu1Lim.ToString And
                           It.QtdProdTU1Lim = NmTu1Lim.ToString And
                           It.ProdTU1LimPerc = Tu1Perc.ToString And
                           It.Tu2Lim = Tu2Lim.ToString).ToList
            If dtLtInd.Count <= 0 Then
                'Se nao existir, insere novo dado
                ProdLastIntId = ProdLastIntId + 1
                Dim LastIntNw As New Geral.ProdLastInt With {.IdArt = IdArt, _
                                                              .IdProdLastInt = ProdLastIntId, _
                                                              .Data = dtProdLastInt.Rows(Conta)("Data"), _
                                                              .Hora = dtProdLastInt.Rows(Conta)("Hora"), _
                                                              .QtdProdOk = dtProdLastInt.Rows(Conta)("NumPdOk"), _
                                                              .QtdProdNok = dtProdLastInt.Rows(Conta)("NumPdNok"), _
                                                              .VlMedio = dtProdLastInt.Rows(Conta)("VlMedio"), _
                                                              .DesvioPadrao = dtProdLastInt.Rows(Conta)("DvPadrao"), _
                                                              .TuLim = dtProdLastInt.Rows(Conta)("Tu1Lim"), _
                                                              .QtdProdTU1Lim = dtProdLastInt.Rows(Conta)("NmTu1Lim"), _
                                                              .ProdTU1LimPerc = dtProdLastInt.Rows(Conta)("Tu1Perc"), _
                                                              .Tu2Lim = dtProdLastInt.Rows(Conta)("Tu2Lim"), _
                                                              .DataHora = DateTime.Now}

                Td.ProdLastInt.InsertOnSubmit(LastIntNw)

            Else
                'Se existir, atualiza o dado
                Dim Id As Integer = dtLtInd.First.IdProdLastInt
                Dim dtLtIntEdit = (From It In Td.ProdLastInt Where It.IdProdLastInt = Id).ToList
                If dtLtIntEdit.Count <= 0 Then Return False

                dtLtIntEdit.First.DataHora = DateTime.Now

            End If

            Td.SubmitChanges()

        Next

        Return True

    End Function

    'PD_CHARGE
    Public Function GravaPdCharge(Optional ByVal IdArt As Integer = 0, _
                                  Optional ByVal ProdDados As List(Of DataTable) = Nothing) As Boolean

        Dim Td As New Geral.dcToledo

        'Pesquisa o DataTable no ListOf
        Dim ProdChargeList = (From It In ProdDados Where It.TableName = "ChargeDados").ToList
        If ProdChargeList.Count <= 0 Then Return False

        Dim dtProdCharge As DataTable = New DataTable
        dtProdCharge = ProdChargeList.First

        Dim ProdChargeId As Integer = 0
        ProdChargeId = ChargeIdNovo()

        'Verifica se o dado ja existe
        For Conta As Integer = 0 To dtProdCharge.Rows.Count - 1
            Dim Dt = dtProdCharge.Rows(Conta)("Data")
            Dim Hor = dtProdCharge.Rows(Conta)("Hora")
            Dim NumBatch = dtProdCharge.Rows(Conta)("NumBatch")
            Dim QtdPdOk = dtProdCharge.Rows(Conta)("QtdProdOk")
            Dim QtdPdNok = dtProdCharge.Rows(Conta)("QtdProdNok")
            Dim VlMedio = dtProdCharge.Rows(Conta)("VlMedio")
            Dim DvPadrao = dtProdCharge.Rows(Conta)("DvPadrao")
            Dim Tu1Lim = dtProdCharge.Rows(Conta)("Tu1Lim")
            Dim NmTu1Lim = dtProdCharge.Rows(Conta)("QtdProd<Tu1Lim")
            Dim Tu1Perc = dtProdCharge.Rows(Conta)("Prod<TU1LimPerc")
            Dim Tu2Lim = dtProdCharge.Rows(Conta)("Tu2Lim")
            Dim NmTu2Lim = dtProdCharge.Rows(Conta)("QtdProd<Tu2Lim")
            Dim dtCharge = (From It In Td.ProdCharge Where
                        It.Data = Dt.ToString And
                        It.Hora = Hor.ToString And
                        It.NumBatch = NumBatch.ToString And
                        It.QtdProdOk = QtdPdOk.ToString And
                        It.QtdProdNok = QtdPdNok.ToString And
                        It.VlMedio = VlMedio.ToString And
                        It.DesvioPadrao = DvPadrao.ToString And
                        It.Tu1Lim = Tu1Lim.ToString And
                        It.QtdProdTu1Lim = NmTu1Lim.ToString And
                        It.ProdTU1LimPerc = Tu1Perc.ToString And
                        It.Tu2Lim = Tu2Lim.ToString And
                        It.QtdProdTu2Lim = NmTu2Lim.ToString).ToList
            If dtCharge.Count <= 0 Then
                'Se nao existir, insere novo dado
                ProdChargeId = ProdChargeId + 1
                Dim ChargeNw As New Geral.ProdCharge With {.IdArt = IdArt, _
                                                           .IdProdCharge = ProdChargeId, _
                                                                  .Data = dtProdCharge.Rows(Conta)("Data"), _
                                                                  .Hora = dtProdCharge.Rows(Conta)("Hora"), _
                                                                  .NumBatch = dtProdCharge.Rows(Conta)("NumBatch"), _
                                                                  .QtdProdOk = dtProdCharge.Rows(Conta)("QtdProdOk"), _
                                                                  .QtdProdNok = dtProdCharge.Rows(Conta)("QtdProdNok"), _
                                                                  .VlMedio = dtProdCharge.Rows(Conta)("VlMedio"), _
                                                                  .DesvioPadrao = dtProdCharge.Rows(Conta)("DvPadrao"), _
                                                                  .Tu1Lim = dtProdCharge.Rows(Conta)("Tu1Lim"), _
                                                                  .QtdProdTu1Lim = dtProdCharge.Rows(Conta)("QtdProd<Tu1Lim"), _
                                                                  .ProdTU1LimPerc = dtProdCharge.Rows(Conta)("Prod<TU1LimPerc"), _
                                                                  .Tu2Lim = dtProdCharge.Rows(Conta)("Tu2Lim"), _
                                                                  .QtdProdTu2Lim = dtProdCharge.Rows(Conta)("QtdProd<Tu2Lim"), _
                                                                  .DataHora = DateTime.Now}
                Td.ProdCharge.InsertOnSubmit(ChargeNw)

            Else
                'Se existir, atualiza o dado
                Dim Id As Integer = dtCharge.First.IdProdCharge
                Dim dtChargeEdit = (From It In Td.ProdCharge Where It.IdProdCharge = Id).ToList
                If dtChargeEdit.Count <= 0 Then Return False

                dtChargeEdit.First.DataHora = DateTime.Now

            End If

            Td.SubmitChanges()

        Next

        Return True

    End Function

    'PD_LastChr
    Public Function GravaPdLastChr(Optional ByVal IdArt As Integer = 0, _
                                   Optional ByVal ProdDados As List(Of DataTable) = Nothing) As Boolean

        Dim Td As New Geral.dcToledo

        'Pesquisa o DataTable no ListOf
        Dim ProdLastChrList = (From It In ProdDados Where It.TableName = "LastChrDados").ToList
        If ProdLastChrList.Count <= 0 Then Return False

        Dim dtProdLastChr As DataTable = New DataTable
        dtProdLastChr = ProdLastChrList.First

        Dim ProdLastChrId As Integer = 0
        ProdLastChrId = LastChrIdNovo()

        'Verifica se o dado ja existe
        For Conta As Integer = 0 To dtProdLastChr.Rows.Count - 1
            Dim Dt = dtProdLastChr.Rows(Conta)("Data")
            Dim Hor = dtProdLastChr.Rows(Conta)("Hora")
            Dim NumBatch = dtProdLastChr.Rows(Conta)("NumBatch")
            Dim QtdPdOk = dtProdLastChr.Rows(Conta)("QtdPdOk")
            Dim QtdPdNok = dtProdLastChr.Rows(Conta)("QtdPdNok")
            Dim VlMedio = dtProdLastChr.Rows(Conta)("VlMedio")
            Dim DvPadrao = dtProdLastChr.Rows(Conta)("DvPadrao")
            Dim Tu1Lim = dtProdLastChr.Rows(Conta)("Tu1Lim")
            Dim NmTu1Lim = dtProdLastChr.Rows(Conta)("NmTu1Lim")
            Dim Tu1Perc = dtProdLastChr.Rows(Conta)("Tu1Perc")
            Dim Tu2Lim = dtProdLastChr.Rows(Conta)("Tu2Lim")
            Dim NmTu2Lim = dtProdLastChr.Rows(Conta)("NmTu2Lim")
            Dim dtLastChr = (From It In Td.ProdLastChr Where
                            It.Data = Dt.ToString And
                            It.Hora = Hor.ToString And
                            It.NumBatch = NumBatch.ToString And
                            It.QtdProdOk = QtdPdOk.ToString And
                            It.QtdProdNok = QtdPdNok.ToString And
                            It.VlMedio = VlMedio.ToString And
                            It.DesvioPadrao = DvPadrao.ToString And
                            It.Tu1Lim = Tu1Lim.ToString And
                            It.QtdProdTu1Lim = NmTu1Lim.ToString And
                            It.ProdTU1LimPerc = Tu1Perc.ToString And
                            It.Tu2Lim = Tu2Lim.ToString And
                            It.QtdProdTu2Lim = NmTu2Lim.ToString).ToList
            If dtLastChr.Count <= 0 Then
                'Se nao existir, insere novo dado
                ProdLastChrId = ProdLastChrId + 1
                Dim ChargeNw As New Geral.ProdLastChr With {.IdArt = IdArt, _
                                                        .IdProdLastChr = ProdLastChrId, _
                                                                .Data = dtProdLastChr.Rows(Conta)("Data"), _
                                                                .Hora = dtProdLastChr.Rows(Conta)("Hora"), _
                                                                .NumBatch = dtProdLastChr.Rows(Conta)("NumBatch"), _
                                                                .QtdProdOk = dtProdLastChr.Rows(Conta)("QtdPdOk"), _
                                                                .QtdProdNok = dtProdLastChr.Rows(Conta)("QtdPdNok"), _
                                                                .VlMedio = dtProdLastChr.Rows(Conta)("VlMedio"), _
                                                                .DesvioPadrao = dtProdLastChr.Rows(Conta)("DvPadrao"), _
                                                                .Tu1Lim = dtProdLastChr.Rows(Conta)("Tu1Lim"), _
                                                                .QtdProdTu1Lim = dtProdLastChr.Rows(Conta)("NmTu1Lim"), _
                                                                .ProdTU1LimPerc = dtProdLastChr.Rows(Conta)("Tu1Perc"), _
                                                                .Tu2Lim = dtProdLastChr.Rows(Conta)("Tu2Lim"), _
                                                                .QtdProdTu2Lim = dtProdLastChr.Rows(Conta)("NmTu2Lim"), _
                                                                .DataHora = DateTime.Now}

                Td.ProdLastChr.InsertOnSubmit(ChargeNw)

            Else
                'Se existir, atualiza o dado
                Dim Id As Integer = dtLastChr.First.IdProdLastChr
                Dim dtLastChrEdit = (From It In Td.ProdLastChr Where It.IdProdLastChr = Id).ToList
                If dtLastChrEdit.Count <= 0 Then Return False

                dtLastChrEdit.First.DataHora = DateTime.Now

            End If

            Td.SubmitChanges()

        Next

        Return True

    End Function

#End Region


End Class
