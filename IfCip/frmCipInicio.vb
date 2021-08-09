Public Class frmCipInicio

    Sub RefreshDados()

        'Carrega rotas em execucao
        Dim taCipHist As New Geral.dsxCipValidTableAdapters.taxCipHist
        Dim dtCipHist As New Geral.dsxCipValid.CipHistDataTable
        taCipHist.FillExec(dtCipHist)

        For Conta As Integer = 0 To dsCipValid.CadRotas.Rows.Count - 1

            With dsCipValid.CadRotas(Conta)

                Dim Idx As Integer = gvCadRotas.Rows.Add(.Grupo, .Subgrupo, .Descricao, .RotaId, .LimRevAtual, .EndTempos)

                'Verifica se está em execucao
                Dim Cmd As String = "Grupo = '" & gvCadRotas.Rows(Conta).Cells(0).Value & "' AND " & _
                                    "Subgrupo = '" & gvCadRotas.Rows(Conta).Cells(1).Value & "'"

                Dim MyRows() As Geral.dsxCipValid.CipHistRow = dtCipHist.Select(Cmd)

                If MyRows.Length > 0 Then
                    'Este Grupo esta em execucao, pinta de verde
                    gvCadRotas.Rows(Conta).Cells(0).Style.BackColor = Color.LightGreen
                    gvCadRotas.Rows(Conta).Cells(1).Style.BackColor = Color.LightGreen
                Else
                    'Este grupo está livre, pinta de branco
                    gvCadRotas.Rows(Conta).Cells(0).Style.BackColor = Color.White
                    gvCadRotas.Rows(Conta).Cells(1).Style.BackColor = Color.White
                End If

            End With

        Next

    End Sub

    Private Sub frmCipInicio_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        Me.WindowState = FormWindowState.Maximized
        taCadRotas.Fill(dsCipValid.CadRotas)

        RefreshDados()

    End Sub

    Private Sub butIniciar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles butIniciar.Click

        If gvCadRotas.SelectedRows.Count <= 0 Then Return

        Dim Grupo As String = gvCadRotas.SelectedRows(0).Cells(0).Value
        Dim Subgrupo As String = gvCadRotas.SelectedRows(0).Cells(1).Value

        Dim CipAntValid As Boolean = TestaCipValidNOK(Grupo, Subgrupo)
        If CipAntValid = True Then
            MsgBox("ATENÇÃO: O CIP selecionado [" & Grupo & Subgrupo & "] possui pendências em sua última validação!" & vbCr & _
                    "Termine de validar este CIP antes de prosseguir.", MsgBoxStyle.Exclamation)
            Return
        End If

        Dim Ret As MsgBoxResult = MsgBox("O CIP " & grupo & subgrupo & " será iniciado. Confirma?", MsgBoxStyle.YesNo + MsgBoxStyle.Question, "ATENÇÃO")
        If Ret = MsgBoxResult.No Then Return


        'Enviar comando de inicio de CIP ao PLC
        Dim RotaId As String = gvCadRotas.SelectedRows(0).Cells(3).Value
        Dim LimRev As Integer = gvCadRotas.SelectedRows(0).Cells(4).Value
        Dim EndTempos As Integer = gvCadRotas.SelectedRows(0).Cells(5).Value

        Dim Tipo As Integer
        If radCipCompleto.Checked = True Then
            Tipo = 0
        Else
            Tipo = 1
        End If

        Dim UserId As Integer = frmIfCip.lblUser.Tag

        Dim RetEnv As Boolean = PlcEnvia(Grupo, Subgrupo, RotaId, LimRev, EndTempos, Tipo, UserId)
        If RetEnv = False Then Return

        Close()

    End Sub

    Private Sub DataGridView1_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles gvCadRotas.DoubleClick
        butIniciar_Click(sender, e)
    End Sub

    Private Sub butFecha_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles butFecha.Click
        Close()
    End Sub
End Class