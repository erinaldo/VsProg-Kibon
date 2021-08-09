Public Class frmCadAlergRec

    Dim Area As String = String.Empty
    Dim RecNum As Integer = 0
    Dim RecCodigo As String = String.Empty

    Sub Abre(Area As String, RecNum As Integer, RecCodigo As String)

        Me.Area = Area
        Me.RecNum = RecNum
        Me.RecCodigo = RecCodigo

        RefreshDados()
        ShowDialog()

    End Sub

    Sub RefreshDados()

        Dim DbAlerg = New Geral.nsReceitas.dcReceitas

        Dim dtAlerg = (From It In DbAlerg.Alergenico Order By It.Letra).ToList
        Dim dtAlergRec = (From It In DbAlerg.AlergenicosRec Where It.Area = Area And It.RecNum = RecNum).ToList

        gvAlergRec.Rows.Clear()

        'CARREGA ALERGÊNICOS
        For Each Alerg In dtAlerg
            gvAlergRec.Rows.Add(False, ImageListAlerg.Images(0), Alerg.CodAlergenico, Alerg.Nome, Alerg.Letra)
        Next

        'CARREGA ALERGÊNICOS POR RECEITA
        For Each AlergRec In dtAlergRec

            For Each row As DataGridViewRow In gvAlergRec.Rows

                If AlergRec.CodAlergenico = row.Cells(2).Value Then
                    row.Cells(0).Value = True
                End If

            Next

        Next

    End Sub

    Private Sub chkClearAll_Click(sender As Object, e As EventArgs) Handles chkClearAll.Click

        If chkClearAll.CheckState = 1 Then

            For Each row As DataGridViewRow In gvAlergRec.Rows

                CType(row.Cells(0), DataGridViewCheckBoxCell).Value = False

            Next

        End If

        chkClearAll.Checked = False

    End Sub

    Private Sub butOk_Click(sender As Object, e As EventArgs) Handles butOk.Click

        Dim Contador As Integer = 0

        Dim DbRc = New Geral.nsReceitas.dcReceitas

        Dim dtReceitaAlerg = (From It In DbRc.AlergenicosRec Where It.Area = Area And It.RecNum = RecNum).ToList

        'EXCLUI REGISTROS
        DbRc.AlergenicosRec.DeleteAllOnSubmit(dtReceitaAlerg)
        DbRc.SubmitChanges()

        'INSERE NOSOVS REGISTROS

        For Each row As DataGridViewRow In gvAlergRec.Rows

            If row.Cells(0).Value = True Or row.Cells(0).Value = 1 Then

                DbRc.AlergenicosRec.InsertOnSubmit(New Geral.nsReceitas.AlergenicosRec With {.CodAlergenico = row.Cells(2).Value, .Area = Area, .RecNum = RecNum, .CodigoRec = RecCodigo})
                Contador = Contador + 1

            End If

        Next

        If Contador > 0 Then
            DbRc.SubmitChanges()
        End If

        Close()

    End Sub

    Private Sub butCancel_Click(sender As Object, e As EventArgs) Handles butCancel.Click

        Close()

    End Sub

End Class