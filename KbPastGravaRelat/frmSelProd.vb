Public Class frmSelProd

    Public SelHistId As Integer = 0

    Sub Abre()

        SelHistId = 0

        dpDataIni.Value = Now.Date
        dpDataFim.Value = Now.Date

        RefreshItens()

        ShowDialog()

    End Sub

    Function RefreshItens()

        'CarregaCipsHist
        Dim DataTxt As String = Format(dpDataIni.Value, "yyyyMMdd") & "000000"
        Dim DataTxtFim As String = Format(dpDataFim.Value, "yyyyMMdd") & "235959"

        Dim DbPg As New Geral.nsPastGrava.dcPastGrava

        Dim dtPastGravaHist As List(Of Geral.nsPastGrava.PastGravaHist)
        If cmbCirc.Text <> "" And cmbCirc.Text <> "*" Then
            dtPastGravaHist = (From It In DbPg.PastGravaHist Where It.DataHora >= DataTxt And It.DataHora <= DataTxtFim And
                                    It.PastId = cmbCirc.Text Order By It.DataHora).ToList
        Else
            dtPastGravaHist = (From It In DbPg.PastGravaHist Where It.DataHora >= DataTxt And It.DataHora <= DataTxtFim
                                    Order By It.DataHora).ToList
        End If

        grdItens.Rows.Clear()
        For Each Rec In dtPastGravaHist

            Dim DtTxt As String = Util.UtConvYmdData(Rec.DataHora)
            grdItens.Rows.Add(Rec.HistId, DtTxt, Rec.PastId)

        Next

        Return True

    End Function

    Private Sub cmdCancela_Click(sender As System.Object, e As System.EventArgs) Handles cmdCancela.Click
        Close()
    End Sub

    Private Sub butPes_Click(sender As System.Object, e As System.EventArgs) Handles butPes.Click
        RefreshItens()
    End Sub

    Private Sub cmdOk_Click(sender As System.Object, e As System.EventArgs) Handles cmdOk.Click

        If grdItens.SelectedRows.Count <= 0 Then Return
        SelHistId = grdItens.SelectedRows(0).Cells(0).Value

        Close()

    End Sub

    Private Sub grdItens_DoubleClick(sender As System.Object, e As System.EventArgs) Handles grdItens.DoubleClick
        cmdOk_Click(sender, e)
    End Sub
End Class