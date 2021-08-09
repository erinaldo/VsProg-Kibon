Public Class frmCipSchedPer

    Dim PerIdMax As Integer = 1

    Dim dtRotaCad As New List(Of Geral.nsCipRotas.RotaCad)
    Dim dtRec As New List(Of Geral.nsReceitas.Rec)

    Sub RefreshDados(Optional ByVal SelPerId As Integer = -1)

        'Memoriza o item selecionado
        Dim RowTop As Integer = gvItens.FirstDisplayedScrollingRowIndex
        Dim RowSel As Integer = -1
        Dim PerIdSel As Integer = 0
        If gvItens.SelectedRows.Count > 0 Then PerIdSel = gvItens.SelectedRows(0).Cells(0).Value

        Dim DbCv As New Geral.nsCipValid.dcCipValid
        Dim dtCipSchedPer = (From It In DbCv.CipSchedPer).ToList
 
        gvItens.Rows.Clear()

        For Conta As Integer = 0 To dtCipSchedPer.Count - 1

            With dtCipSchedPer(Conta)

                Dim DataHoraTxt As String = Format(.DataHoraIni, "dd/MM/yyyy HH:mm:ss")

                Dim RotaDescr As String = "", RotaCirc As String = ""
                Dim MyRota = (From It In dtRotaCad Where It.RotaId = .RotaId).ToList
                If MyRota.Count > 0 Then
                    RotaDescr = MyRota(0).Descr
                    RotaCirc = MyRota(0).Circ
                End If

                Dim RecNome As String = "", RecDescr As String = "", RecCodigo As String = ""
                Dim MyRec = (From It In dtRec Where It.RecNum = .RecNum).ToList
                If MyRec.Count > 0 Then
                    RecNome = MyRec(0).RecNome
                    RecDescr = MyRec(0).RecDescr
                    RecCodigo = MyRec(0).Codigo
                End If

                gvItens.Rows.Add(.PerId, .RotaId, RotaDescr, RotaCirc, DataHoraTxt, .PerNHoras, .RecNum, RecNome, RecDescr, RecCodigo)

                'Procura a linha selecionada
                If .PerId = PerIdSel Then RowSel = Conta

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

    Private Sub frmCipSchedProg_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        WindowState = FormWindowState.Maximized

        'Le os dados da tabela
        Dim DbCr As New Geral.nsCipRotas.dcCipRotas
        dtRotaCad = (From It In DbCr.RotaCad Order By It.Sequencia).ToList

        Dim DbRc As New Geral.nsReceitas.dcReceitas
        dtRec = (From It In DbRc.Rec Where It.Area = "CIP" Order By It.RecNum).ToList

        RefreshDados()

    End Sub

    Private Sub butAdd_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles butAdd.Click

       Dim MyForm As New Geral.frmSelCip
        MyForm.Abre("CIP ", -1, -1)

        If MyForm.SelOk = False Then Return

        Dim PerIdNew As Integer = 1
        Dim DbCv As New Geral.nsCipValid.dcCipValid
        Dim dtCipSchedPerMax = (From It In DbCv.CipSchedPer Order By It.PerId Descending).Take(1).ToList
        Try
            PerIdNew = dtCipSchedPerMax(0).PerId + 1
        Catch : End Try

        Dim Dh As Date = Geral.TseNow

        Dim NwCsp As New Geral.nsCipValid.CipSchedPer With {.PerId = PerIdNew, .RotaId = MyForm.SelRotaId,
                                                            .RecNum = MyForm.SelRecNum, .PerNHoras = 0, .DataHoraIni = Dh}
        DbCv.CipSchedPer.InsertOnSubmit(NwCsp)

        DbCv.SubmitChanges()

        RefreshDados()

    End Sub

    Private Sub butEditaRota_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles butEditaRota.Click

        If gvItens.SelectedRows.Count <= 0 Then Return
        Dim PerId As Integer = gvItens.SelectedRows(0).Cells(0).Value
        Dim RotaId As Integer = gvItens.SelectedRows(0).Cells(1).Value
        Dim RecNum As Integer = gvItens.SelectedRows(0).Cells(6).Value

        Dim MyForm As New Geral.frmSelCip
        MyForm.Abre("CIP", RotaId, RecNum)

        If MyForm.SelOk = False Then Return

        'Pega dados do CIP selecionado
        Dim DbCv As New Geral.nsCipValid.dcCipValid
        Dim dtCipSchedPer = (From It In DbCv.CipSchedPer Where It.PerId = PerId).ToList
        If dtCipSchedPer.Count > 0 Then
            dtCipSchedPer.First.RotaId = MyForm.SelRotaId
            dtCipSchedPer.First.RecNum = MyForm.SelRecNum
        End If

        DbCv.SubmitChanges()

        RefreshDados()

    End Sub

    Private Sub butRemove_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles butRemove.Click

        If gvItens.SelectedRows.Count <= 0 Then Return

        Dim PerId As Integer = gvItens.SelectedRows(0).Cells(0).Value

        Dim Ret As MsgBoxResult = MsgBox("O item [" & PerId & "] será removido. Confirma?", MsgBoxStyle.OkCancel)
        If Ret = MsgBoxResult.Cancel Then Return

        'Removendo o item selecionado
        Dim DbCv As New Geral.nsCipValid.dcCipValid
        Dim dtCipSchedPer = (From It In DbCv.CipSchedPer Where It.PerId = PerId).ToList
        DbCv.CipSchedPer.DeleteOnSubmit(dtCipSchedPer.First)

        'Apaga os dias do mes associados a este item
        Dim dtCipSchedPerMes = (From It In DbCv.CipSchedPerMes Where It.PerId = PerId).ToList
        DbCv.CipSchedPerMes.DeleteOnSubmit(dtCipSchedPerMes.First)

        'Apaga os dias da semana associados a este item
        Dim dtCipSchedPerSem = (From It In DbCv.CipSchedPerSem Where It.PerId = PerId).ToList
        DbCv.CipSchedPerSem.DeleteOnSubmit(dtCipSchedPerSem.First)

        DbCv.SubmitChanges()

        RefreshDados()

    End Sub

    Private Sub butEditaData_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles butEditaData.Click

        If gvItens.SelectedRows.Count <= 0 Then Return
        Dim PerId As Integer = gvItens.SelectedRows(0).Cells(0).Value

        Dim Dh As Date = Util.ConvStrData(gvItens.SelectedRows(0).Cells(4).Value)

        Dim MyForm As New Util.frmSelDataHora
        MyForm.Abre(Dh)

        If MyForm.SelOk = False Then Return

        Dim DbCv As New Geral.nsCipValid.dcCipValid
        Dim dtCipSchedPer = (From It In DbCv.CipSchedPer Where It.PerId = PerId).ToList
        If dtCipSchedPer.Count > 0 Then
            dtCipSchedPer.First.DataHoraIni = Dh
        End If

        DbCv.SubmitChanges()

        RefreshDados()

    End Sub

    Private Sub butPerNDias_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles butPerNDias.Click

        If gvItens.SelectedRows.Count <= 0 Then Return
        Dim PerId As Integer = gvItens.SelectedRows(0).Cells(0).Value
        Dim PerNDias As Integer = gvItens.SelectedRows(0).Cells(5).Value

        Dim Ret As String = InputBox("Número de horas entre CIPs (>=24)", "Periodo em horas", PerNDias.ToString)
        If Ret = "" Then Return
        If IsNumeric(Ret) = False Then
            MsgBox("Erro: o valor digitado é inválido")
            Return
        End If

        If Ret < 24 Then
            MsgBox("Erro: o valor digitado é menor uque 24 horas")
            Return
        End If

        Dim DbCv As New Geral.nsCipValid.dcCipValid
        Dim dtCipSchedPer = (From It In DbCv.CipSchedPer Where It.PerId = PerId).ToList
        If dtCipSchedPer.Count > 0 Then
            dtCipSchedPer.First.PerNHoras = Ret
        End If

        DbCv.SubmitChanges()

        RefreshDados()

    End Sub

    Private Sub gvCipSchedProg_CellDoubleClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles gvItens.CellDoubleClick

        butEditaData_Click(sender, e)

    End Sub

    Private Sub butEditaDias_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles butEditaDias.Click

        If gvItens.SelectedRows.Count <= 0 Then Return
        Dim PerId As Integer = gvItens.SelectedRows(0).Cells(0).Value
        Dim Grupo As String = gvItens.SelectedRows(0).Cells(1).Value
        Dim Subgrupo As String = gvItens.SelectedRows(0).Cells(2).Value
        Dim Descr As String = gvItens.SelectedRows(0).Cells(5).Value

        frmCipSchedPerEdita.Abre(PerId)

    End Sub

End Class