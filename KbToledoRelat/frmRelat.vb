Imports System.Globalization

Public Class frmRelat

    Public Sub Abre()

        Dim Ck As New Geral.dcToledo

        'Carregar DataHora no campo
        txtDtHor.Text = DateTime.Now

        'Carregar lista com nome e id da maquina
        Dim dtMaq = (From It In Ck.DadosMaq Order By It.IdMaq).ToList


        cbxMaq.Items.Clear()

        For Each Maq In dtMaq

            Dim MaqTxt As String = Maq.IdMaq & " - " & Maq.Maquina
            cbxMaq.Items.Add(MaqTxt)

        Next

        If cbxMaq.Items.Count > 0 Then cbxMaq.SelectedIndex = 0

        'Carregar lista com artigos (produtos)
        Dim dtArt = (From It In Ck.DadosArt Order By It.ArtId).ToList

        cbxNomeProd.Items.Clear()

        For Each Prod In dtArt

            Dim ProdTxt As String = Prod.ArtId & " - " & Prod.Nome
            cbxNomeProd.Items.Add(ProdTxt)

        Next

        'If cbxNomeProd.Items.Count > 0 Then cbxNomeProd.SelectedIndex = 0

        Activate()
        Show()

    End Sub

    Private Sub butPesProd_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)

        PesqProd()

    End Sub

    Private Sub PesqProd()

        Dim Ck As New Geral.dcToledo

        'Carrega lista com Id e nome do produto conforme artigo ativo no BD
        Dim MaqId As Integer = Val(cbxMaq.Text)
        Dim dtArt = (From It In Ck.DadosArt Where It.Sts = 1 And It.IdMaq = MaqId).ToList
        If dtArt.Count <= 0 Then Return
        Dim ArtAtv = dtArt.First.ArtId

        'Pesquisa no FB_PD_STAT pelo nome do produto, peso nominal e peso tara
        Dim DtPdStat = (From It In Ck.ProdStat Where It.IdArt = ArtAtv).ToList
        If DtPdStat.Count <= 0 Then Return

        Dim NomeProd As String = DtPdStat.First.Artigo
        Dim PesoNom As String = DtPdStat.First.PesoNominal
        Dim PesoTara As String = DtPdStat.First.Tara

        cbxNomeProd.Text = NomeProd
        txtPsNom.Text = PesoNom
        txtPsTara.Text = PesoTara

    End Sub

    Private Sub cbxNomeProd_SelectedIndexChanged(sender As System.Object, e As System.EventArgs) Handles cbxNomeProd.SelectedIndexChanged

        txtPsNom.Text = ""
        txtPsTara.Text = ""

        Dim Ck As New Geral.dcToledo

        Dim MaqId As Integer = Val(cbxMaq.Text)
        Dim dtArt = (From It In Ck.DadosArt Where It.IdMaq = MaqId).ToList
        If dtArt.Count <= 0 Then Return

        Dim ArtId As Integer = Val(cbxNomeProd.Text)
        Dim DtProdStat = (From It In Ck.ProdStat Where It.IdArt = ArtId).ToList
        If DtProdStat.Count <= 0 Then Return

        Dim PesoNom As String = DtProdStat.First.PesoNominal
        Dim PesoTara As String = DtProdStat.First.Tara

        txtPsNom.Text = PesoNom
        txtPsTara.Text = PesoTara

    End Sub

    Private Sub butPesqEstat_Click(sender As System.Object, e As System.EventArgs) Handles butPesqEstat.Click


        Dim DataIni As DateTime = dpDataIni.Value
        Dim DataFin As DateTime = dpDataFin.Value

        Dim Ck As New Geral.dcToledo

        'Pega Id do Artigo selecionado
        Dim Prod As String = Val(cbxNomeProd.Text)
        Dim dtProd = (From It In Ck.DadosArt Where It.ArtId = Prod).ToList
        If dtProd.Count <= 0 Then Return

        'Pesquisa estatisticas do Artigo 
        Dim IdProd = dtProd.First.ArtId
        Dim dtProdStat = (From It In Ck.ProdStat Where It.IdArt = IdProd).ToList
        If dtProdStat.Count <= 0 Then Return

        'Configura a Data
        Dim Data As String = dtProdStat.First.Data
        Dim NovaData As Date = Convert.ToDateTime(Data)

        'Configura a Hora
        Dim Hora As String = dtProdStat.First.Hora
        Dim HoraNova As DateTime = Convert.ToDateTime(Hora)
        Dim NwHora As String = HoraNova.ToString("HH:mm")

        'Monta DataHora
        Dim DtHor As DateTime = Data & " " & NwHora
        dtProdStat.First.Data = DtHor

        'Filtra dados do Artigo de acordo com o intervalo de tempo
        Dim dtStat = (From It In Ck.ProdStat Where It.DataHora >= DataIni And It.DataHora <= DataFin).ToList
        If dtStat.Count <= 0 Then Return

        gvEstatTot.Rows.Clear()

        For Conta As Integer = 0 To dtStat.Count - 1
            With dtStat(Conta)

                gvEstatTot.Rows.Add(.Data, .DataHora, .QtdProdOk, .Tu1Lim, .QtdProdPerc, .Tu2Lim, .VlMedio, .DesvioPadrao, _
                                       .QtdProdNok, .QtdProdTu1Lim, .QtdProdTu2Lim)

            End With

        Next

        Dim dtStat2 = (From It In Ck.SdStat2 Where It.DataHora >= DataIni And It.DataHora.ToString <= DataFin).ToList
        If dtStat.Count <= 0 Then Return

        gvEstatCont.Rows.Clear()

        For Conta As Integer = 0 To dtStat2.Count - 1
            With dtStat2(Conta)



            End With
        Next


    End Sub

    Private Sub RefreshDados()



    End Sub

    'Pesquisar total de produtos verificados com esse Id

    Private Sub butGeraRelat_Click(sender As System.Object, e As System.EventArgs) Handles butGeraRelat.Click

        frmGeraRelat.Abre()

    End Sub

End Class