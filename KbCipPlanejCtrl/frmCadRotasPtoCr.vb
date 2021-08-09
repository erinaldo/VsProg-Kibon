Public Class frmCadRotasPtoCr

    Dim dsCipValid As Geral.dsxCipValid

    Sub Abre(ByVal RotaId As Integer, ByVal Grupo As String, ByVal Subgrupo As String, _
            ByVal Descr As String, ByVal LimRev As Integer, ByRef outDsCipValid As Geral.dsxCipValid)

        'Me.WindowState = FormWindowState.Maximized

        dsCipValid = outDsCipValid
        txtRotaId.Text = RotaId
        txtGrupo.Text = Grupo
        txtSubgrupo.Text = Subgrupo
        txtDescr.Text = Descr
        txtLimRev.Text = LimRev

        taCadPtoCr.Fill(dsCipValid.CadPtoCr)
        bsCadPtoCr.DataSource = dsCipValid.CadPtoCr

        RefreshDados()
        ShowDialog()

    End Sub

    Sub RefreshDados()

        Dim dtDados As New DataTable()

        dtDados.Columns.Add("Seq")
        dtDados.Columns.Add("PtoCrId")
        dtDados.Columns.Add("Pergunta")

        Dim Cmd As String = "RotaId = " & txtRotaId.Text
        Dim MyRows() As Geral.dsxCipValid.CadRotaPtoCrRow = dsCipValid.CadRotaPtoCr.Select(Cmd, "Seq")

        For Conta As Integer = 0 To MyRows.Length - 1

            Dim MyDado As DataRow = dtDados.Rows.Add

            MyDado.Item(0) = MyRows(Conta).Seq
            MyDado.Item(1) = MyRows(Conta).PtoCrId
            MyDado.Item(2) = BuscaPergunta(MyRows(Conta).PtoCrId)

        Next

        gvCadRotasPtoCr.DataSource = dtDados

    End Sub

    Function BuscaPergunta(ByVal PtoCrId) As String

        Dim Cmd As String = "PtoCrId = " & PtoCrId
        Dim MyPerguntas() As Geral.dsxCipValid.CadPtoCrRow = dsCipValid.CadPtoCr.Select(Cmd)

        If MyPerguntas.Length <= 0 Then Return ""

        Return MyPerguntas(0).Pergunta

    End Function

    Private Sub butInsere_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles butInsere.Click

        'PtoCrId a ser inserido
        If gvCadPtoCr.SelectedRows.Count <= 0 Then Return
        Dim PtoCrId As Integer = gvCadPtoCr.SelectedRows(0).Cells(0).Value


        'Seq nova
        Dim SeqNova As Integer = 1
        For Conta As Integer = 0 To gvCadRotasPtoCr.RowCount - 1
            If SeqNova <= gvCadRotasPtoCr.Rows(Conta).Cells(0).Value Then
                SeqNova = gvCadRotasPtoCr.Rows(Conta).Cells(0).Value + 1
            End If
        Next


        'Insere o item
        Dim MyRow As Geral.dsxCipValid.CadRotaPtoCrRow = dsCipValid.CadRotaPtoCr.NewCadRotaPtoCrRow
        MyRow.RotaId = txtRotaId.Text
        MyRow.PtoCrId = PtoCrId
        MyRow.Seq = SeqNova

        Try
            dsCipValid.CadRotaPtoCr.Rows.Add(MyRow)
        Catch : End Try

        RefreshDados()

    End Sub

    Private Sub butExclui_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles butExclui.Click

        'Remove o item da tabela de dados
        If gvCadRotasPtoCr.SelectedRows.Count <= 0 Then Return
        Dim PtoCrId As Integer = gvCadRotasPtoCr.SelectedRows(0).Cells(1).Value

        Dim Cmd As String = "RotaId = " & txtRotaId.Text & " AND PtoCrId = " & PtoCrId
        Dim MyRows() As Geral.dsxCipValid.CadRotaPtoCrRow = dsCipValid.CadRotaPtoCr.Select(Cmd)

        If MyRows.Length <= 0 Then Return

        MyRows(0).Delete()

        RefreshDados()

    End Sub

    Private Sub gvCadPtoCr_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles gvCadPtoCr.DoubleClick
        butInsere_Click(sender, e)
    End Sub

    Private Sub gvCadRotasPtoCr_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles gvCadRotasPtoCr.DoubleClick
        butExclui_Click(sender, e)
    End Sub

End Class