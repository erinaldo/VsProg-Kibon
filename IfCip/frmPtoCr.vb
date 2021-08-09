Public Class frmPtoCr

    Dim dtCadPtoCr As New List(Of Geral.nsCipValid.CadPtoCr)
   
    Public Sub Abre(ByVal CipId As Integer, ByVal RotaId As Integer, ByVal RecNum As Integer)

        txtCipId.Text = CipId
        txtRotaId.Text = RotaId
        txtRecNum.Text = RecNum

        Dim DbCr As New Geral.nsCipRotas.dcCipRotas
        Dim dtCadRotas = (From It In DbCr.RotaCad Where It.RotaId = RotaId).ToList
 
        If dtCadRotas.Count > 0 Then
            txtRotaDescr.Text = dtCadRotas(0).Descr
            txtRotaCirc.Text = dtCadRotas(0).Circ
        End If

        Dim DbRc As New Geral.nsReceitas.dcReceitas
        Dim dtRec = (From It In DbRc.Rec Where It.Area = "CIP" And It.RecNum = RecNum).ToList

        If dtCadRotas.Count > 0 Then
            txtRecNome.Text = dtRec(0).RecNome & " - " & dtRec(0).RecDescr
            txtRecCodigo.Text = dtRec(0).Codigo
        End If

        Dim DbCv As New Geral.nsCipValid.dcCipValid
        Dim taCadPtoCr = (From It In DbCv.CadPtoCr).ToList

        RefreshDados()

        ShowDialog()

    End Sub

    Sub RefreshDados()

        'Memoriza o item selecionado
        Dim RowTop As Integer = gvItens.FirstDisplayedScrollingRowIndex
        Dim RowSel As Integer = -1
        Dim PtoCrIdSel As Integer = 0
        If gvItens.SelectedRows.Count > 0 Then PtoCrIdSel = gvItens.SelectedRows(0).Cells(0).Value

        Dim DbCv As New Geral.nsCipValid.dcCipValid
        Dim dtCipHistPtoCr = (From It In DbCv.CipHistPtoCr Where It.CipId = txtCipId.Text Order By It.PtoCrId).ToList

        gvItens.Rows.Clear()

        For Conta As Integer = 0 To dtCipHistPtoCr.Count - 1
            With dtCipHistPtoCr(Conta)

                Dim Pergunta As String = ""
                Dim PtoCrId As Integer = dtCipHistPtoCr(Conta).PtoCrId
                Dim MyPerg = (From It In dtCadPtoCr Where It.PtoCrId = PtoCrId).ToList
                If MyPerg.Count > 0 Then Pergunta = MyPerg(0).Pergunta

                Dim RespTxt As String = "."
                If .Resp = 0 Then
                    RespTxt = "Pend"
                ElseIf .Resp = 1 Then
                    RespTxt = "Sim"
                Else
                    RespTxt = "Não"
                End If

                gvItens.Rows.Add(.PtoCrId, Pergunta, RespTxt)

                'Procura a linha selecionada
                If .PtoCrId = PtoCrIdSel Then RowSel = Conta

            End With
        Next

        Try
            If RowSel >= 0 Then
                'Vai para a linha selecionada
                gvItens.FirstDisplayedScrollingRowIndex = RowTop
                gvItens.CurrentCell = gvItens.Rows(RowSel).Cells(1)
            Else
                'Nenhuma linha selecionada vai para o fim
                gvItens.FirstDisplayedScrollingRowIndex = gvItens.Rows.Count - 1
                gvItens.CurrentCell = gvItens.Rows(gvItens.Rows.Count - 1).Cells(1)
            End If
        Catch : End Try

    End Sub

    Private Sub butFecha_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles butFecha.Click
        Close()
    End Sub

    Private Sub gvCipHistPtoCr_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles gvItens.Click

  
        If gvItens.SelectedRows.Count <= 0 Then Return

        Dim PtoCrId As Integer = gvItens.SelectedRows(0).Cells(0).Value

        Dim Resp As String = 1
        If gvItens.SelectedRows(0).Cells(2).Value = "Sim" Then Resp = 2

        Dim DbCv As New Geral.nsCipValid.dcCipValid
        Dim dtCipHistPtoCr = (From It In DbCv.CipHistPtoCr Where It.CipId = txtCipId.Text And It.PtoCrId = PtoCrId).ToList
        If dtCipHistPtoCr.Count > 0 Then
            dtCipHistPtoCr.First.Resp = Resp
        End If

        DbCv.SubmitChanges()

        RefreshDados()

    End Sub

End Class