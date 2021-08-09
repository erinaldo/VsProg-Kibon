Public Class frmIfRelat

    Private Sub frmIfRelat_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        Geral.DLLInit()

    End Sub


    Private Sub butRelat_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)

        frmRelat.Abre()

    End Sub



    Private Sub butDescr_Click(sender As System.Object, e As System.EventArgs) Handles butDescr.Click

        frmMaq.MdiParent = Me
        frmMaq.Abre()

    End Sub

    Private Sub butProd2_Click(sender As System.Object, e As System.EventArgs) Handles butProd2.Click

        frmArtigos.MdiParent = Me
        frmArtigos.Abre()

    End Sub

    Private Sub butDados_Click(sender As System.Object, e As System.EventArgs) Handles butDados.Click

        frmDadosArt.MdiParent = Me
        frmDadosArt.Abre()

    End Sub

    Private Sub butDadosBas_Click_1(sender As System.Object, e As System.EventArgs) Handles butDadosBas.Click

        frmDadosArtAtv.MdiParent = Me
        frmDadosArtAtv.Abre()

    End Sub



    Private Sub butContZonPlus_Click(sender As System.Object, e As System.EventArgs) Handles butContZonPlus.Click

        frmContPlus.MdiParent = Me
        frmContPlus.Abre()

    End Sub

    Private Sub butContZonGood_Click(sender As System.Object, e As System.EventArgs) Handles butContZonGood.Click

        frmContGood.MdiParent = Me
        frmContGood.Abre()

    End Sub

    Private Sub butContZonMinus_Click(sender As System.Object, e As System.EventArgs) Handles butContZonMinus.Click

        frmContMinus.MdiParent = Me
        frmContMinus.Abre()

    End Sub

    Private Sub butConfClass_Click(sender As System.Object, e As System.EventArgs) Handles butConfClass.Click

        frmZonClass.MdiParent = Me
        frmZonClass.Abre()

    End Sub

    Private Sub butConfDesl_Click(sender As System.Object, e As System.EventArgs) Handles butConfDesl.Click

        frmLimDesl.MdiParent = Me
        frmLimDesl.Abre()

    End Sub

   

    Private Sub butEstatInterAtu_Click(sender As System.Object, e As System.EventArgs) Handles butEstatInterAtu.Click

        frmEstatInt.MdiParent = Me
        frmEstatInt.Abre()

    End Sub

    Private Sub butEstatUltInter_Click(sender As System.Object, e As System.EventArgs) Handles butEstatUltInter.Click

        frmEstatUltInter.MdiParent = Me
        frmEstatUltInter.Abre()


    End Sub

    Private Sub butEstatBatchAtu_Click(sender As System.Object, e As System.EventArgs) Handles butEstatBatchAtu.Click

        frmEstatBatchAtu.MdiParent = Me
        frmEstatBatchAtu.Abre()

    End Sub

    Private Sub butEstatUltBatch_Click(sender As System.Object, e As System.EventArgs) Handles butEstatUltBatch.Click

        frmEstatUltBatch.MdiParent = Me
        frmEstatUltBatch.Abre()

    End Sub

    Private Sub butEstatTot_Click(sender As System.Object, e As System.EventArgs) Handles butEstatTot.Click

        frmEstatTot.MdiParent = Me
        frmEstatTot.Abre()

    End Sub



    Private Sub butHistor_Click(sender As System.Object, e As System.EventArgs) Handles butHistor.Click

        frmHist.MdiParent = Me
        frmHist.Abre()

    End Sub

   
    Private Sub butRelatFinal_Click(sender As System.Object, e As System.EventArgs) Handles butRelatFinal.Click

        frmRelat.MdiParent = Me
        frmRelat.Abre()

    End Sub
End Class
