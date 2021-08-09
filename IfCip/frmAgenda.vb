Public Class frmAgenda

    Dim dtCadRotas As Geral.dsxCipValid.CadRotasDataTable

    Sub RefreshDados()

        'Carrega rotas em execucao
        Dim taCipHist As New Geral.dsxCipValidTableAdapters.taxCipHist
        Dim dtCipHist As New Geral.dsxCipValid.CipHistDataTable
        taCipHist.FillExec(dtCipHist)


        Dim dtDados As New DataTable

        AgendaMontaColunas(dtDados)
        AgendaBuscaCipSchedProg(dtDados)
        AgendaBuscaCipSchedPer(dtDados)


        'Ordena pela data
        Dim MyRows() As DataRow = dtDados.Select("", "DataHora")

        gvAgenda.Rows.Clear()
        For Conta As Integer = 0 To MyRows.Length - 1

            With MyRows(Conta)

                Dim Modo As String = ""
                If .Item("Modo") = 0 Then
                    Modo = "Prog."
                Else
                    Modo = "Period."
                End If

                Dim DataHora As String = Format(CDate(.Item("DataHora")), "dd/MM/yyyy HH:mm:ss")

                Dim Tipo As String = "Completo"
                If .Item("Tipo") = 1 Then Tipo = "Parcial"

                Dim Descr As String = ""
                Dim LimRev As Integer = 0
                Dim EndTempos As String = ""
                Try
                    Dim MyRow() As Geral.dsxCipValid.CadRotasRow = dtCadRotas.Select("RotaId = " & .Item("RotaId"))
                    Descr = MyRow(0).Descricao
                    LimRev = MyRow(0).LimRevAtual
                    EndTempos = MyRow(0).EndTempos
                Catch : End Try

                Dim Idx As Integer = gvAgenda.Rows.Add(Modo, .Item("Id"), .Item("RotaId"), Trim(.Item("Grupo")), _
                            Trim(.Item("Subgrupo")), DataHora, Tipo, Descr, LimRev, EndTempos)

                If .Item("FlagAtrasado") = 1 Then
                    gvAgenda.Rows(Idx).Cells(5).Style.BackColor = Color.Red
                End If


                'Verifica se está em execucao
                Dim Cmd As String = "Grupo = '" & gvAgenda.Rows(Conta).Cells(3).Value & "' AND " & _
                                    "Subgrupo = '" & gvAgenda.Rows(Conta).Cells(4).Value & "'"

                Dim MyExec() As Geral.dsxCipValid.CipHistRow = dtCipHist.Select(Cmd)

                If MyExec.Length > 0 Then
                    'Este Grupo esta em execucao, pinta de cinza
                    gvAgenda.Rows(Conta).Cells(3).Style.BackColor = Color.LightGreen
                    gvAgenda.Rows(Conta).Cells(4).Style.BackColor = Color.LightGreen
                Else
                    'Este grupo está livre, pinta de branco
                    gvAgenda.Rows(Conta).Cells(3).Style.BackColor = Color.White
                    gvAgenda.Rows(Conta).Cells(4).Style.BackColor = Color.White
                End If


            End With

        Next

    End Sub

    Private Sub frmAgenda_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        WindowState = FormWindowState.Maximized
        Dim taCadRotas As New Geral.dsxCipValidTableAdapters.taxCadRotas
        dtCadRotas = New Geral.dsxCipValid.CadRotasDataTable

        taCadRotas.Fill(dtCadRotas)
        RefreshDados()

        Dim Pos As Integer
        'varre o grid tirando a seleção de todas as linhas
        For Pos = 0 To gvAgenda.Rows.Count - 1
            gvAgenda.Rows(Pos).Selected = False
        Next
        'seleciona a ultima linha do grid
        Pos = gvAgenda.Rows.GetLastRow(DataGridViewElementStates.Displayed)
        gvAgenda.Rows(Pos).Selected = True

    End Sub

    Private Sub butIniciar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles butIniciar.Click

        If gvAgenda.SelectedRows.Count <= 0 Then Return

        Dim Grupo As String = gvAgenda.SelectedRows(0).Cells(3).Value
        Dim Subgrupo As String = gvAgenda.SelectedRows(0).Cells(4).Value

        Dim Ret As MsgBoxResult = MsgBox("O CIP " & Grupo & Subgrupo & " será iniciado. Confirma?", MsgBoxStyle.YesNo + MsgBoxStyle.Question, "ATENÇÃO")
        If Ret = MsgBoxResult.No Then Return

        'Enviar comando de inicio de CIP ao PLC
        Dim Modo As String = gvAgenda.SelectedRows(0).Cells(0).Value
        Dim Id As String = gvAgenda.SelectedRows(0).Cells(1).Value
        Dim RotaId As String = gvAgenda.SelectedRows(0).Cells(2).Value

        Dim Tipo As Integer
        If gvAgenda.SelectedRows(0).Cells(6).Value = "Completo" Then
            Tipo = 0
        Else
            Tipo = 1
        End If

        Dim LimRev As Integer = gvAgenda.SelectedRows(0).Cells(8).Value
        Dim EndTempos As Integer = gvAgenda.SelectedRows(0).Cells(9).Value

        Dim UserId As Integer = frmIfCip.lblUser.Tag

        Dim RetEnv As Boolean = PlcEnvia(Grupo, Subgrupo, RotaId, LimRev, EndTempos, Tipo, UserId)
        If RetEnv = False Then Return


        'Remove do banco cado modo Prog
        If Modo = "Prog." Then

            Dim taCipSchedProg As New Geral.dsxCipValidTableAdapters.taxCipSchedProg
            taCipSchedProg.DeleteQuery(Id)

        End If

        Close()

    End Sub

    Private Sub gvAgenda_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles gvAgenda.DoubleClick
        butIniciar_Click(sender, e)
    End Sub

    Private Sub butFecha_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles butFecha.Click
        Close()
    End Sub
End Class