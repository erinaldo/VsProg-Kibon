Public Class frmRelatOld

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


        Activate()
        Show()

    End Sub

    Private Sub butPesProd_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles butPesqProd.Click

        PesqProd()

    End Sub

    Private Sub PesqProd()

        Dim Ck As New Geral.dcToledo

        'Carrega lista com id e nome do produto conforme artigo ativo no BD
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

        txtNomeProd.Text = NomeProd
        txtPsNom.Text = PesoNom
        txtPsTara.Text = PesoTara

    End Sub

    'Pesquisar total de produtos verificados com esse Id

    Private Sub butGeraRelat_Click(sender As System.Object, e As System.EventArgs) Handles butGeraRelat.Click

        frmGeraRelat.Abre()

    End Sub


End Class