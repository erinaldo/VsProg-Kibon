﻿Public Class frmCipCorr

    Dim dtCadUser As New List(Of Geral.nsCipValid.CadUser)
    Dim dtRotaCad As New List(Of Geral.nsCipRotas.RotaCad)
    Dim dtRec As New List(Of Geral.nsReceitas.Rec)

    Sub RefreshDados()

        'Memoriza o item selecionado
        Dim RowTop As Integer = gvItens.FirstDisplayedScrollingRowIndex
        Dim RowSel As Integer = -1
        Dim CipIdSel As Integer = 0
        If gvItens.SelectedRows.Count > 0 Then CipIdSel = gvItens.SelectedRows(0).Cells(0).Value

        Dim DbCv As New Geral.nsCipValid.dcCipValid
        Dim dtCipHist = (From It In DbCv.CipHist Where It.Status = 1 Order By It.DataHoraIni).ToList

        gvItens.Rows.Clear()

        For Conta As Integer = 0 To dtCipHist.Count - 1
            With dtCipHist(Conta)

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

                Dim UserNome As String = "???", UserId As Integer = dtCipHist(Conta).UserId
                Dim MyUser = (From It In dtCadUser Where It.UserId = UserId).ToList
                If MyUser.Count > 0 Then UserNome = MyUser(0).Nome

                Dim AnormOk As Boolean = TestaAnormOk(dtCipHist(Conta).CipId)
                Dim AnormTxt As String = "Pend."
                If AnormOk = True Then AnormTxt = "Ok"

                Dim PtoCrOk As Boolean = TestaPtoCrOk(dtCipHist(Conta).CipId)
                Dim PtoCrTxt As String = "Pend."
                If PtoCrOk = True Then PtoCrTxt = "Ok"

                gvItens.Rows.Add(.CipId, .RotaId, RotaDescr, RotaCirc, .RecNum, RecNome, RecDescr, RecCodigo,
                                 .DataHoraIni, .DataHoraFim, UserNome, AnormTxt, PtoCrTxt)

                'Procura a linha selecionada
                If .CipId = CipIdSel Then RowSel = Conta

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

    Private Sub frmCipFim_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        Dim DbCv As New Geral.nsCipValid.dcCipValid
        dtCadUser = (From It In DbCv.CadUser).ToList

        Dim DbCr As New Geral.nsCipRotas.dcCipRotas
        dtRotaCad = (From It In DbCr.RotaCad Order By It.Sequencia).ToList

        Dim DbRc As New Geral.nsReceitas.dcReceitas
        dtRec = (From It In DbRc.Rec Where It.Area = "CIP" Order By It.RecNum).ToList

        WindowState = FormWindowState.Maximized
        RefreshDados()

    End Sub

    Private Sub butRefresh_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles butRefresh.Click

        RefreshDados()

    End Sub

    Private Sub butCipHistAnorm_Click(sender As System.Object, e As System.EventArgs) Handles butCipHistAnorm.Click

        If gvItens.SelectedRows.Count <= 0 Then Return

        Dim CipId As Integer = gvItens.SelectedRows(0).Cells(0).Value
        Dim RotaId As Integer = gvItens.SelectedRows(0).Cells(1).Value
        Dim RecNum As Integer = gvItens.SelectedRows(0).Cells(4).Value

        frmAnormVw.Abre(CipId, RotaId, RecNum)

        RefreshDados()

    End Sub
End Class