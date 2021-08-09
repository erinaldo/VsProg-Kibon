Public Class frmKbImprimeRecPreench

    Private Sub frmProdPlanej_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load

        Geral.DllInit()

        tmrRel.Enabled = True

    End Sub

    Private Sub tmrRel_Tick(sender As System.Object, e As System.EventArgs) Handles tmrRel.Tick

        tmrRel.Enabled = False

        Dim CmdParam() As String = Command.Split
        Dim RecAtual As Integer = CmdParam(0)
        TamBatch = CmdParam(1)
        NomeDoTqDestino = CmdParam(2)
        IdBatch = CmdParam(3)

        Dim DbRc As New Geral.nsReceitas.dcReceitas
        Dim dtAreas = (From It In DbRc.DestTqs Where It.TqNome = NomeDoTqDestino).ToList
        If dtAreas.Count <= 0 Then End

        If dtAreas.First.Area = "CIP" Then TamBatch = 100
        Dim Area As String = dtAreas.First.Area

        Dim dtRec = (From It In DbRc.Rec Where It.Area = Area And It.RecNum = RecAtual).ToList
        If dtRec.Count <= 0 Then End

        Dim NumRecTxt As String = RecAtual
        Dim NomeRecTxt As String = dtRec.First.RecNome

        RecDados.Nome = Trim(NomeRecTxt)
        RecDados.Num = Val(NumRecTxt)
        RecDados.NomeArq = Trim("")


        If Area = "Mistura" Then
            NomeDaAreaAtual = "Tanques de mistura"
        Else
            NomeDaAreaAtual = "Bredo de diluição"
        End If


        GeraRelat(Area, RecAtual, NomeRecTxt, IdBatch)

        End

    End Sub
End Class