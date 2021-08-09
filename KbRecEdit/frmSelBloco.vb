Public Class frmSelBloco

    Public BlkSel As Integer

    Public Sub Abre(ByVal Area As String)

        Dim Banco As New Geral.nsReceitas.dcReceitas

        Dim myBlks = (From It In Banco.Blocos Where It.Area = Area Order By It.BlkNum).ToList

        dgBlocos.Rows.Clear()

        For Conta As Integer = 0 To myBlks.Count - 1

            dgBlocos.Rows.Add()
            dgBlocos.Rows(Conta).Cells(0).Value = myBlks(Conta).BlkNum
            dgBlocos.Rows(Conta).Cells(2).Value = myBlks(Conta).BlkDescr

            'Carrega imagem do bloco
            Dim ImagemNome As String = Util.UtAppPath & _
                        "\..\Bin\Bmp\" & TrataArea.AreaDados("Area") & "_Blk" & Microsoft.VisualBasic.Right("000" & myBlks(Conta).BlkNum.ToString, 3) & ".png"

            Try
                'Le imagem do arquivo do bloco Ex: ..\Bmp\Blk001.png
                dgBlocos.Rows(Conta).Cells(1).Value = New Bitmap(ImagemNome)
            Catch
                'Arquivo do bloco nao encontrado, carrega imagem default
                dgBlocos.Rows(Conta).Cells(1).Value = ilBlks.Images(0)
            End Try

        Next
        

        Left = frmRecEdit.Right - 300
        Top = frmRecEdit.Top + 100

        ShowDialog()

    End Sub

    Private Sub butCancela_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles butCancela.Click

        BlkSel = 0
        Me.Close()

    End Sub

    Private Sub butOk_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles butOk.Click

        BlkSel = dgBlocos.SelectedRows(0).Cells("Blk").Value

        If BlkSel <= 0 Then Return

        FlagDadosEdit = True
        Me.Close()

    End Sub

    Private Sub dgBlocos_CellMouseDown(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellMouseEventArgs) Handles dgBlocos.CellMouseDown

        dgBlocos.Rows(e.RowIndex).Selected = True

        Dim Dados As String = dgBlocos.Rows(e.RowIndex).Cells("Blk").Value & ";-1"
        DoDragDrop(Dados, DragDropEffects.Move Or DragDropEffects.Copy)

    End Sub

    Private Sub dgBlocos_DoubleClick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles dgBlocos.DoubleClick
        butOk_Click(sender, e)
    End Sub

End Class