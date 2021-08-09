Public Class frmCipSchedProg

    Dim dtRotaCad As New List(Of Geral.nsCipRotas.RotaCad)
    Dim dtRec As New List(Of Geral.nsReceitas.Rec)

    Private Sub UserLogin(ByVal UserId As Integer)

        Dim Nome As String = Geral.BuscaUserLogin(UserId)

        'If Geral.ChkUserSeg(UserId, "Superv") = True  Then

        butAdd.Enabled = True
        butEdita.Enabled = True
        butRemove.Enabled = True
        butEditaData.Enabled = True

        'End If

    End Sub

    Sub RefreshDados()

        'Memoriza o item selecionado
        Dim RowTop As Integer = gvItens.FirstDisplayedScrollingRowIndex
        Dim RowSel As Integer = -1
        Dim ProgIdSel As Integer = 0
        If gvItens.SelectedRows.Count > 0 Then ProgIdSel = gvItens.SelectedRows(0).Cells(0).Value

        Dim DbCv As New Geral.nsCipValid.dcCipValid
        Dim dtCipSchedProg = (From It In DbCv.CipSchedProg Order By It.DataHora).ToList

        gvItens.Rows.Clear()
        For Conta As Integer = 0 To dtCipSchedProg.Count - 1

            With dtCipSchedProg(Conta)

                Dim DataHora As String = Format(.DataHora, "dd/MM/yyyy HH:mm:ss")

                Dim StsTxt As String = "Bloq"
                If .Sts > 0 Then StsTxt = "Hab"

                Dim RotaDescr As String = ""
                Dim MyRota = (From It In dtRotaCad Where It.RotaId = .RotaId).ToList
                If MyRota.Count > 0 Then
                    RotaDescr = MyRota(0).Descr
                End If

                Dim RecNome As String = "", RecDescr As String = "", RecCodigo As String = ""
                Dim MyRec = (From It In dtRec Where It.RecNum = .RecNum).ToList
                If MyRec.Count > 0 Then
                    RecNome = MyRec(0).RecNome
                    RecDescr = MyRec(0).RecDescr
                    RecCodigo = MyRec(0).Codigo
                End If

                If cmbCirc.Text <> "" And cmbCirc.Text <> "*" Then
                    If .Circ <> cmbCirc.Text Then
                        Continue For
                    End If
                End If


                gvItens.Rows.Add(.ProgId, DataHora, .RotaId, RotaDescr, .Circ, .RecNum, RecNome, RecDescr, RecCodigo, StsTxt)

                'Mostra a data em vermelho quando CIP atrasado
                If .DataHora < Now Then
                    gvItens.Rows(gvItens.Rows.Count - 1).Cells(1).Style.BackColor = Color.Red
                    gvItens.Rows(gvItens.Rows.Count - 1).Cells(1).Style.ForeColor = Color.Yellow
                End If

                'Mostra linha em cinza quando desabilitada
                If .Sts <= 0 Then
                    gvItens.Rows(gvItens.Rows.Count - 1).Cells(2).Style.BackColor = Color.LightGray
                    gvItens.Rows(gvItens.Rows.Count - 1).Cells(3).Style.BackColor = Color.LightGray
                    gvItens.Rows(gvItens.Rows.Count - 1).Cells(4).Style.BackColor = Color.LightGray
                    gvItens.Rows(gvItens.Rows.Count - 1).Cells(5).Style.BackColor = Color.LightGray
                    gvItens.Rows(gvItens.Rows.Count - 1).Cells(6).Style.BackColor = Color.LightGray
                    gvItens.Rows(gvItens.Rows.Count - 1).Cells(7).Style.BackColor = Color.LightGray
                    gvItens.Rows(gvItens.Rows.Count - 1).Cells(8).Style.BackColor = Color.LightGray
                    gvItens.Rows(gvItens.Rows.Count - 1).Cells(9).Style.BackColor = Color.LightGray
                End If

                'Procura a linha selecionada
                If .ProgId = ProgIdSel Then RowSel = Conta

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

        butAdd.Enabled = False
        butEdita.Enabled = False
        butRemove.Enabled = False
        butEditaData.Enabled = False

        UserLogin(frmIfCip.lblUser.Tag)

        'Le os dados da tabela
        Dim DbCr As New Geral.nsCipRotas.dcCipRotas
        dtRotaCad = (From It In DbCr.RotaCad Order By It.Sequencia).ToList

        Dim DbRc As New Geral.nsReceitas.dcReceitas
        dtRec = (From It In DbRc.Rec Where It.Area = "CIP" Order By It.RecNum).ToList

        RefreshDados()

    End Sub

    Private Sub butAdd_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles butAdd.Click

        Dim SelRotaId As Integer = 0, SelRecNum As Integer = 0

        If cmbCirc.Text = "" Or cmbCirc.Text = "*" Then

            'O circuito não está selecionado, abre a interface
            Dim MyForm As New Geral.frmSelCip
            MyForm.Abre("CIP", -1, -1)
            If MyForm.SelOk = False Then Return

            SelRotaId = MyForm.SelRotaId
            SelRecNum = MyForm.SelRecNum

        Else

            'O circuito está selecionado, pede a rota e a receita
            Dim FrmRota As New Geral.frmSelRota
            FrmRota.Abre(cmbCirc.Text)
            If FrmRota.SelOk = False Then Return
            SelRotaId = FrmRota.SelRotaId

            Dim FrmRec As New Geral.frmSelRec
            FrmRec.Abre("CIP")
            If FrmRec.SelRecNum <= 0 Then Return
            SelRecNum = FrmRec.SelRecNum

        End If

        Dim ProgIdNew As Integer = Geral.BuscaProgIdNew()
        Dim Dh As Date = DateAdd(DateInterval.Second, 15, Geral.TseNow)

        Dim MyRows = (From It In dtRotaCad Where It.RotaId = SelRotaId).ToList
        If MyRows.Count <= 0 Then Return
        Dim Circ As String = MyRows(0).Circ

        Dim DbCv = New Geral.nsCipValid.dcCipValid
        Dim NwCsp = New Geral.nsCipValid.CipSchedProg With {.ProgId = ProgIdNew, .DataHora = Dh,
                                .RotaId = SelRotaId, .Circ = Circ, .RecNum = SelRecNum,
                                .Sts = 0, .UserId = frmIfCip.lblUser.Tag}
        DbCv.CipSchedProg.InsertOnSubmit(NwCsp)
        DbCv.SubmitChanges()

        RefreshDados()

    End Sub

    Private Sub butEdita_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles butEdita.Click

        If gvItens.SelectedRows.Count <= 0 Then Return
        Dim ProgId As Integer = gvItens.SelectedRows(0).Cells(0).Value
        Dim RotaId As Integer = gvItens.SelectedRows(0).Cells(2).Value
        Dim RecNum As Integer = gvItens.SelectedRows(0).Cells(5).Value

        Dim MyForm As New Geral.frmSelCip
        MyForm.Abre("CIP", RotaId, RecNum)

        If MyForm.SelRotaId <= 0 Then Return

        Dim MyRows = (From It In dtRotaCad Where It.RotaId = MyForm.SelRotaId).ToList
        If MyRows.Count <= 0 Then Return
        Dim Circ As String = MyRows(0).Circ

        Dim DbCv As New Geral.nsCipValid.dcCipValid
        Dim dtCipSchedProg = (From It In DbCv.CipSchedProg Where It.ProgId = ProgId).ToList
        If dtCipSchedProg.Count > 0 Then
            dtCipSchedProg.First.RotaId = MyForm.SelRotaId
            dtCipSchedProg.First.Circ = Circ
            dtCipSchedProg.First.RecNum = MyForm.SelRecNum
            dtCipSchedProg.First.UserId = frmIfCip.lblUser.Tag
        End If

        DbCv.SubmitChanges()

        RefreshDados()

    End Sub

    Private Sub butRemove_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles butRemove.Click

        If gvItens.SelectedRows.Count <= 0 Then Return

        For Conta As Integer = 0 To gvItens.SelectedRows.Count - 1

            Dim ProgId As Integer = gvItens.SelectedRows(Conta).Cells(0).Value

            Dim Ret As MsgBoxResult = MsgBox("O item [" & ProgId & "] será removido. Confirma?", MsgBoxStyle.OkCancel)
            If Ret = MsgBoxResult.Cancel Then Return

            'Removendo o item selecionado
            Dim DbCv As New Geral.nsCipValid.dcCipValid
            Dim dtCipSchedProg = (From It In DbCv.CipSchedProg Where It.ProgId = ProgId).ToList
            DbCv.CipSchedProg.DeleteOnSubmit(dtCipSchedProg.First)
            DbCv.SubmitChanges()

        Next

        RefreshDados()

    End Sub

    Private Sub butEditaData_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles butEditaData.Click

        If gvItens.SelectedRows.Count <= 0 Then Return
        Dim ProgId As Integer = gvItens.SelectedRows(0).Cells(0).Value

        Dim Dh As Date = Util.ConvStrData(gvItens.SelectedRows(0).Cells(1).Value)

        Dim MyForm As New Util.frmSelDataHora
        MyForm.Abre(Dh)

        If MyForm.SelOk = False Then Return

        Dim DbCv As New Geral.nsCipValid.dcCipValid
        Dim dtCipSchedProg = (From It In DbCv.CipSchedProg Where It.ProgId = ProgId).ToList
        If dtCipSchedProg.Count > 0 Then
            dtCipSchedProg.First.DataHora = MyForm.SelDataHora
            dtCipSchedProg.First.UserId = frmIfCip.lblUser.Tag
        End If
        DbCv.SubmitChanges()

        RefreshDados()

    End Sub

    Private Sub gvCipSchedProg_CellDoubleClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles gvItens.CellDoubleClick

        If e.ColumnIndex = 1 Then
            If butEditaData.Enabled = False Then Return
            butEditaData_Click(sender, e)
        ElseIf e.ColumnIndex >= 2 And e.ColumnIndex <= 8 Then
            If butEdita.Enabled = False Then Return
            butEdita_Click(sender, e)
        ElseIf e.ColumnIndex = 9 Then
            If gvItens.Rows(e.RowIndex).Cells(e.ColumnIndex).Value = "Bloq" Then
                If butProgHab.Enabled = False Then Return
                butProgHab_Click(sender, e)
            Else
                If butDesab.Enabled = False Then Return
                butDesab_Click(sender, e)
            End If
        End If

    End Sub

    Private Sub butRefresh_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles butRefresh.Click
        RefreshDados()
    End Sub

    Private Sub butProgHab_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles butProgHab.Click

        If gvItens.SelectedRows.Count <= 0 Then Return

        Dim DbCv As New Geral.nsCipValid.dcCipValid

        For Conta As Integer = 0 To gvItens.SelectedRows.Count - 1

            Dim ProgId As Integer = gvItens.SelectedRows(Conta).Cells(0).Value

            'Habilita
            Dim dtCipSchedProg = (From It In DbCv.CipSchedProg Where It.ProgId = ProgId).ToList
            If dtCipSchedProg.Count > 0 Then
                dtCipSchedProg.First.Sts = 1
                dtCipSchedProg.First.UserId = frmIfCip.lblUser.Tag
            End If

        Next

        DbCv.SubmitChanges()

        RefreshDados()

    End Sub

    Private Sub butDesab_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles butDesab.Click

        If gvItens.SelectedRows.Count <= 0 Then Return

        Dim DbCv As New Geral.nsCipValid.dcCipValid

        For Conta As Integer = 0 To gvItens.SelectedRows.Count - 1

            Dim ProgId As Integer = gvItens.SelectedRows(Conta).Cells(0).Value

            'Desabilita
            Dim dtCipSchedProg = (From It In DbCv.CipSchedProg Where It.ProgId = ProgId).ToList
            If dtCipSchedProg.Count > 0 Then
                dtCipSchedProg.First.Sts = 0
                dtCipSchedProg.First.UserId = frmIfCip.lblUser.Tag
            End If
 
        Next

        DbCv.SubmitChanges()

        RefreshDados()

    End Sub

    Private Sub cmbCirc_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmbCirc.SelectedIndexChanged
        RefreshDados()
    End Sub
End Class