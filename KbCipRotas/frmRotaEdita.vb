Public Class frmRotaEdita

    Dim FlagDadosIdx As Integer = 0
    Dim FlagDadosObj As String = ""
    Dim FlagDadosEdit As Boolean = False

    Dim TelaAberta As Boolean = False

    Public Banco As New Geral.nsCipRotas.dcCipRotas

    Public dtCipCadRota As New List(Of Geral.nsCipRotas.RotaCad)

    Public dtCipRotaValv As New List(Of Geral.nsCipRotas.RotaValv)
    Public dtCipRotaMot As New List(Of Geral.nsCipRotas.RotaMot)
    Public dtCipRotaPf As New List(Of Geral.nsCipRotas.RotaPf)
    Public dtCipRotaDepend As New List(Of Geral.nsCipRotas.RotaDepend)

    Public Sub Abre(ByVal RotaId As Integer, ByVal Login As Integer, Optional ByVal NovoReg As Boolean = False)

        If Login = 0 Then
            'Valvulas
            butValvAcIncluir.Enabled = False
            butValvAcExcluir.Enabled = False
            butValvAcPesq.Enabled = False
            butValvNacIncluir.Enabled = False
            butValvNacExcluir.Enabled = False
            butValvNacPesq.Enabled = False
            butValvFlipIncluir.Enabled = False
            butValvFlipExcluir.Enabled = False
            butValvFlipHelp.Enabled = False
            butValvFlipPesq.Enabled = False
            gvValvFlip.Enabled = False
            gvMotores.Enabled = False
            'Outros
            butDepIncluir.Enabled = False
            butDepExcluir.Enabled = False
            butDepPesq.Enabled = False
            butSensorIncluir.Enabled = False
            butSensorExcluir.Enabled = False
            butSensorPesq.Enabled = False
            butMotIncluir.Enabled = False
            butMotExcluir.Enabled = False
            butMotPesq.Enabled = False
            butSalvar.Enabled = False
            'Textos
            txtRotaId.Enabled = False
            cmbCirc.Enabled = False
            rdLinha.Enabled = False
            rdTanque.Enabled = False
            cmbTq1.Enabled = False
            cmbTq2.Enabled = False
            cmbTq3.Enabled = False
            txtDescr.Enabled = False

        Else

            'Valvulas
            butValvAcIncluir.Enabled = True
            butValvAcExcluir.Enabled = True
            butValvAcPesq.Enabled = True
            butValvNacIncluir.Enabled = True
            butValvNacExcluir.Enabled = True
            butValvNacPesq.Enabled = True
            butValvFlipIncluir.Enabled = True
            butValvFlipExcluir.Enabled = True
            butValvFlipHelp.Enabled = True
            butValvFlipPesq.Enabled = True
            gvValvFlip.Enabled = True
            gvMotores.Enabled = True
            'Outros
            butDepIncluir.Enabled = True
            butDepExcluir.Enabled = True
            butDepPesq.Enabled = True
            butSensorIncluir.Enabled = True
            butSensorExcluir.Enabled = True
            butSensorPesq.Enabled = True
            butMotIncluir.Enabled = True
            butMotExcluir.Enabled = True
            butMotPesq.Enabled = True
            butSalvar.Enabled = True
            'Textos
            txtRotaId.Enabled = True
            cmbCirc.Enabled = True
            rdLinha.Enabled = True
            rdTanque.Enabled = True
            cmbTq1.Enabled = True
            cmbTq2.Enabled = True
            cmbTq3.Enabled = True
            txtDescr.Enabled = True

        End If

        txtRotaId.Text = RotaId

        RefreshCmbTq()

        'carrega dados
        Banco = New Geral.nsCipRotas.dcCipRotas

        dtCipCadRota = (From It In Banco.RotaCad Where It.RotaId = RotaId).ToList

        If NovoReg = False Then
            Try
                With dtCipCadRota(0)
                    txtDescr.Text = .Descr
                    cmbCirc.Text = .Circ
                    cmbTq1.Text = .Tq1
                    cmbTq2.Text = .Tq2
                    cmbTq3.Text = .Tq3

                    If .Tipo.ToUpper = "T" Then
                        rdTanque.Checked = True
                    Else
                        rdLinha.Checked = True
                    End If

                    txtVazao.Text = .BbaCipFw

                End With
            Catch : End Try

        Else

            Dim myRegNovo As New Geral.nsCipRotas.RotaCad

            Dim myMaxSeq = (From It In Banco.RotaCad Select It.Sequencia).Max + 1

            myRegNovo.RotaId = RotaId
            myRegNovo.Circ = cmbCirc.Text

            myRegNovo.Tipo = "L"
            If rdTanque.Checked = True Then myRegNovo.Tipo = "T"

            myRegNovo.Descr = txtDescr.Text
            myRegNovo.Tq1 = cmbTq1.Text
            myRegNovo.Tq2 = cmbTq2.Text
            myRegNovo.Tq3 = cmbTq3.Text
            myRegNovo.Sequencia = myMaxSeq
            myRegNovo.RotaTipo = 0
            myRegNovo.BbaCipFw = 0

            'If txtVazao.Text = String.Empty Or txtVazao.Text < 0 Or txtVazao.Text > 50 Then  // Alterado por Ivan 17.11.2017 vi que o programa não permitia criar uma rota do zero
            '    myRegNovo.BbaCipFw = 0
            'ElseIf IsNumeric(txtVazao.Text) = False Then
            '    myRegNovo.BbaCipFw = 0
            'Else
            '    myRegNovo.BbaCipFw = txtVazao.Text
            'End If

            Banco.RotaCad.InsertOnSubmit(myRegNovo)

            Banco.SubmitChanges()

            dtCipCadRota = (From It In Banco.RotaCad Where It.RotaId = RotaId).ToList

        End If

        dtCipRotaValv = (From It In Banco.RotaValv Where It.RotaId = RotaId).ToList
        dtCipRotaMot = (From It In Banco.RotaMot Where It.RotaId = RotaId).ToList
        dtCipRotaPf = (From It In Banco.RotaPf Where It.RotaId = RotaId).ToList
        dtCipRotaDepend = (From It In Banco.RotaDepend Where It.RotaId = RotaId).ToList

        RefreshValv()
        RefreshMotor()
        RefreshSensor()
        RefreshDependencia()

        tcDados.SelectTab(0)

        FlagDadosEdit = False

        TelaAberta = True

        Me.ShowDialog()

    End Sub

    Private Sub RefreshCmbTq()

        cmbTq1.Enabled = False
        cmbTq2.Enabled = False
        cmbTq3.Enabled = False

        Dim myRegs = From It In Banco.TqCad Order By It.Tag

        cmbTq1.Items.Clear()
        cmbTq2.Items.Clear()
        cmbTq3.Items.Clear()

        For Each Reg In myRegs

            cmbTq1.Items.Add(Reg.Tag.ToUpper)
            cmbTq2.Items.Add(Reg.Tag.ToUpper)
            cmbTq3.Items.Add(Reg.Tag.ToUpper)

        Next

    End Sub

    Private Sub RefreshValv()

        'Carrega Tipos de Flip
        Dim Bd As New Geral.nsCipRotas.dcCipRotas

        Dim myReg = From It In Bd.FlipCad Order By It.Tipo

        cmbValvFlipTipo.Items.Clear()

        For Each Reg In myReg

            cmbValvFlipTipo.Items.Add(Reg.Tipo)
        Next

        'Carrega valvulas
        gvValvAc.Rows.Clear()
        gvValvNac.Rows.Clear()
        gvValvFlip.Rows.Clear()

        For Conta As Integer = 0 To dtCipRotaValv.Count - 1

            With dtCipRotaValv(Conta)

                'Valvula Acionada
                If .Tipo.ToUpper = "A" Then
                    gvValvAc.Rows.Add(.Tag.ToUpper)
                End If

                'Valvula Não Acionada
                If .Tipo.ToUpper = "N" Then
                    gvValvNac.Rows.Add(.Tag.ToUpper)
                End If

                'Valvula Flip
                If (.Tipo.ToUpper <> "A") And (.Tipo.ToUpper <> "N") Then
                    gvValvFlip.Rows.Add(.Tag.ToUpper, .Tipo.ToUpper)
                End If

            End With
        Next

        txtValvAc.Text = gvValvAc.Rows.Count
        txtValvNac.Text = gvValvNac.Rows.Count
        txtValvFlip.Text = gvValvFlip.Rows.Count

    End Sub

    Private Sub RefreshSensor()

        gvSensores.Rows.Clear()

        For Conta As Integer = 0 To dtCipRotaPf.Count - 1

            With dtCipRotaPf(Conta)
                gvSensores.Rows.Add(.Tag.ToUpper)
            End With

        Next

    End Sub

    Private Sub RefreshDependencia()

        gvDependencias.Rows.Clear()

        For Conta As Integer = 0 To dtCipRotaDepend.Count - 1

            With dtCipRotaDepend(Conta)
                gvDependencias.Rows.Add(.Tag.ToUpper, .Tipo)
            End With

        Next

    End Sub

    Private Sub RefreshMotor()

        'cmbMotTipo.Items.Clear()

        'For Conta As Integer = 0 To dtCipCadMotTipo.Count - 1

        '    With dtCipCadMotTipo(Conta)
        '        cmbMotTipo.Items.Add(.TipoId)
        '    End With

        'Next

        gvMotores.Rows.Clear()

        For Conta As Integer = 0 To dtCipRotaMot.Count - 1

            With dtCipRotaMot(Conta)
                gvMotores.Rows.Add(.Tag.ToUpper, .Tipo)
            End With

        Next

    End Sub

    Private Sub frmRotaEdita_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing

        If FlagDadosEdit = True And butSalvar.Enabled = True Then

            Dim Ret As MsgBoxResult = MsgBox("ATENÇÃO! Os dados editados serão perdidos. Deseja salvar os dados editados?", _
                                                MsgBoxStyle.YesNoCancel + MsgBoxStyle.Question)

            'Cancelar, continua editando os dados
            If Ret = MsgBoxResult.Cancel Then
                e.Cancel = True
                Return
            End If

            'Não salvar, prosseguir perdendo os dados editados
            If Ret = MsgBoxResult.No Then Return

            'Salva os dados
            butSalvar_Click(sender, e)

        End If

        TelaAberta = False

    End Sub

    Private Sub butCancelar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles butCancelar.Click
        Me.Close()
    End Sub

    Private Sub butSalvar_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles butSalvar.Click

        FlagDadosEdit = False

        'Salva todas as mudanças feitas na tabela
        Banco.SubmitChanges()

        Me.Close()

    End Sub

    Private Sub gvValvAc_CellMouseClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellMouseEventArgs) Handles gvValvAc.CellMouseClick

        If butSalvar.Enabled = False Then Return

        mnuSuspAcionada.Enabled = False
        FlagDadosIdx = e.RowIndex
        FlagDadosObj = "AC"

        If e.Button = Windows.Forms.MouseButtons.Right Then
            mnuValvulas.Show(MousePosition.X, MousePosition.Y)
        End If

    End Sub

    Private Sub gvValvFlip_CellEndEdit(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles gvValvFlip.CellEndEdit

        If butSalvar.Enabled = False Then Return

        If e.ColumnIndex = 1 Then

            Dim myTag As String = gvValvFlip.Rows(e.RowIndex).Cells(0).Value

            'verifica se a valvula realmente existe
            Dim CipRotaValvEdit = (From It In dtCipRotaValv Where It.Tag = myTag).ToList
            If CipRotaValvEdit.Count <= 0 Then
                MsgBox("Erro! Válvula não encontrada: " & myTag.ToUpper)
                Return
            End If

            'altera o tipo da valvula
            CipRotaValvEdit(0).Tipo = gvValvFlip.Rows(e.RowIndex).Cells(1).Value

            FlagDadosEdit = True

        End If

    End Sub

    Private Sub gvValvFlip_CellMouseClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellMouseEventArgs) Handles gvValvFlip.CellMouseClick

        If butSalvar.Enabled = False Then Return

        MnuSuspFlip.Enabled = False
        FlagDadosIdx = e.RowIndex
        FlagDadosObj = "FLIP"

        If e.Button = Windows.Forms.MouseButtons.Right Then
            mnuValvulas.Show(MousePosition.X, MousePosition.Y)
        End If

    End Sub

    Private Sub gvValvNac_CellMouseClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellMouseEventArgs) Handles gvValvNac.CellMouseClick

        If butSalvar.Enabled = False Then Return

        MnuSuspNaoAc.Enabled = False
        FlagDadosIdx = e.RowIndex
        FlagDadosObj = "NAC"

        If e.Button = Windows.Forms.MouseButtons.Right Then
            mnuValvulas.Show(MousePosition.X, MousePosition.Y)
        End If

    End Sub

    Private Sub gvMotores_CellEndEdit(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles gvMotores.CellEndEdit

        If e.ColumnIndex = 1 Then

            Dim myTag As String = gvMotores.Rows(e.RowIndex).Cells(0).Value

            'verifica se a valvula realmente existe
            Dim CipRotaMotEdit = (From It In dtCipRotaMot Where It.Tag = myTag).ToList
            If CipRotaMotEdit.Count <= 0 Then
                MsgBox("Erro! Motor não encontrado: " & myTag.ToUpper)
                Return
            End If

            'altera o tipo da valvula
            CipRotaMotEdit(0).Tipo = gvMotores.Rows(e.RowIndex).Cells(1).Value

            FlagDadosEdit = True

        End If

    End Sub

    Private Sub mnuValvulas_Closed(ByVal sender As Object, ByVal e As System.Windows.Forms.ToolStripDropDownClosedEventArgs) Handles mnuValvulas.Closed

        MnuSuspFlip.Enabled = True
        MnuSuspNaoAc.Enabled = True
        mnuSuspAcionada.Enabled = True

    End Sub

    Private Sub mnuSuspAcionada_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuSuspAcionada.Click

        Dim myTag As String = ""

        If FlagDadosObj = "NAC" Then
            myTag = gvValvNac.Rows(FlagDadosIdx).Cells(0).Value
        End If

        If FlagDadosObj = "FLIP" Then
            myTag = gvValvFlip.Rows(FlagDadosIdx).Cells(0).Value
        End If

        'verifica se a valvula realmente existe
        Dim CipRotaValvEdit = (From It In dtCipRotaValv Where It.Tag = myTag).ToList
        If CipRotaValvEdit.Count <= 0 Then
            MsgBox("Erro! Válvula não encontrada: " & myTag.ToUpper)
            Return
        End If

        'altera o tipo da valvula
        CipRotaValvEdit(0).Tipo = "A"

        FlagDadosEdit = True

        RefreshValv()

    End Sub

    Private Sub MnuSuspNaoAc_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles MnuSuspNaoAc.Click

        Dim myTag As String = ""

        If FlagDadosObj = "AC" Then
            myTag = gvValvAc.Rows(FlagDadosIdx).Cells(0).Value
        End If

        If FlagDadosObj = "FLIP" Then
            myTag = gvValvFlip.Rows(FlagDadosIdx).Cells(0).Value
        End If

        'verifica se a valvula realmente existe
        Dim CipRotaValvEdit = (From It In dtCipRotaValv Where It.Tag = myTag).ToList
        If CipRotaValvEdit.Count <= 0 Then
            MsgBox("Erro! Válvula não encontrada: " & myTag.ToUpper)
            Return
        End If

        'altera o tipo da valvula
        CipRotaValvEdit(0).Tipo = "N"

        FlagDadosEdit = True

        RefreshValv()

    End Sub

    Private Sub MnuSuspFlip_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles MnuSuspFlip.Click

        Dim myTag As String = ""

        If FlagDadosObj = "AC" Then
            myTag = gvValvAc.Rows(FlagDadosIdx).Cells(0).Value
        End If

        If FlagDadosObj = "NAC" Then
            myTag = gvValvNac.Rows(FlagDadosIdx).Cells(0).Value
        End If

        'verifica se a valvula realmente existe
        Dim CipRotaValvEdit = (From It In dtCipRotaValv Where It.Tag = myTag).ToList
        If CipRotaValvEdit.Count <= 0 Then
            MsgBox("Erro! Válvula não encontrada: " & myTag.ToUpper)
            Return
        End If

        'altera o tipo da valvula
        CipRotaValvEdit(0).Tipo = "F01"

        FlagDadosEdit = True

        RefreshValv()

    End Sub

    Private Sub butValvAcExcluir_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles butValvAcExcluir.Click

        If gvValvAc.SelectedRows.Count <= 0 Then Return

        Dim Pos As Integer = gvValvAc.CurrentRow.Index

        Dim myTag As String = gvValvAc.Rows(Pos).Cells(0).Value

        Dim Ret As MsgBoxResult = MsgBox("Deseja realmente retirar a Válvula [ " & myTag.ToUpper & " ] da lista de Válvulas Acionadas?", _
                                        MsgBoxStyle.Critical + MsgBoxStyle.YesNo, "Atenção")

        If Ret = MsgBoxResult.Yes Then

            'verifica se a valvula realmente existe
            Dim CipRotaValvEdit = (From It In dtCipRotaValv Where It.Tag = myTag).ToList
            If CipRotaValvEdit.Count <= 0 Then
                MsgBox("Erro! Válvula não encontrada: " & myTag.ToUpper)
                Return
            End If

            'apaga registro
            Banco.RotaValv.DeleteAllOnSubmit(CipRotaValvEdit)

            'remove o registro deletado do data table de escopo geral
            dtCipRotaValv.Remove(CipRotaValvEdit(0))

            FlagDadosEdit = True

            RefreshValv()

        End If

    End Sub

    Private Sub butValvNacExcluir_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles butValvNacExcluir.Click

        If gvValvNac.SelectedRows.Count <= 0 Then Return

        Dim Pos As Integer = gvValvNac.CurrentRow.Index

        Dim myTag As String = gvValvNac.Rows(Pos).Cells(0).Value

        Dim Ret As MsgBoxResult = MsgBox("Deseja realmente retirar a Válvula [ " & myTag.ToUpper & " ] da lista de Válvulas Não Acionadas?", _
                                        MsgBoxStyle.Critical + MsgBoxStyle.YesNo, "Atenção")

        If Ret = MsgBoxResult.Yes Then

            'verifica se a valvula realmente existe
            Dim CipRotaValvEdit = (From It In dtCipRotaValv Where It.Tag = myTag).ToList
            If CipRotaValvEdit.Count <= 0 Then
                MsgBox("Erro! Válvula não encontrada: " & myTag.ToUpper)
                Return
            End If

            'apaga registro
            Banco.RotaValv.DeleteAllOnSubmit(CipRotaValvEdit)

            'remove o registro deletado do data table de escopo geral
            dtCipRotaValv.Remove(CipRotaValvEdit(0))

            FlagDadosEdit = True

            RefreshValv()

        End If

    End Sub

    Private Sub butValvFlipExcluir_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles butValvFlipExcluir.Click

        If gvValvFlip.SelectedRows.Count <= 0 Then Return

        Dim Pos As Integer = gvValvFlip.CurrentRow.Index

        Dim myTag As String = gvValvFlip.Rows(Pos).Cells(0).Value

        Dim Ret As MsgBoxResult = MsgBox("Deseja realmente retirar a Válvula [ " & myTag.ToUpper & " ] da lista de Válvulas com Flip?", _
                                        MsgBoxStyle.Critical + MsgBoxStyle.YesNo, "Atenção")

        If Ret = MsgBoxResult.Yes Then

            'verifica se a valvula realmente existe
            Dim CipRotaValvEdit = (From It In dtCipRotaValv Where It.Tag = myTag).ToList
            If CipRotaValvEdit.Count <= 0 Then
                MsgBox("Erro! Válvula não encontrada: " & myTag.ToUpper)
                Return
            End If

            'apaga registro
            Banco.RotaValv.DeleteAllOnSubmit(CipRotaValvEdit)

            'remove o registro deletado do data table de escopo geral
            dtCipRotaValv.Remove(CipRotaValvEdit(0))

            FlagDadosEdit = True

            RefreshValv()

        End If

    End Sub

    Private Sub butDepExcluir_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles butDepExcluir.Click

        If gvDependencias.SelectedRows.Count <= 0 Then Return

        Dim Pos As Integer = gvDependencias.CurrentRow.Index

        Dim myTag As String = gvDependencias.Rows(Pos).Cells(0).Value

        Dim Ret As MsgBoxResult = MsgBox("Deseja realmente retirar a Dependência [ " & myTag.ToUpper & " ] da lista?", _
                                        MsgBoxStyle.Critical + MsgBoxStyle.YesNo, "Atenção")

        If Ret = MsgBoxResult.Yes Then

            'verifica se realmente existe
            Dim CipRotaDepEdit = (From It In dtCipRotaDepend Where It.Tag = myTag).ToList
            If CipRotaDepEdit.Count <= 0 Then
                MsgBox("Erro! Dependência não encontrada: " & myTag.ToUpper)
                Return
            End If

            'apaga registro
            Banco.RotaDepend.DeleteAllOnSubmit(CipRotaDepEdit)

            'remove o registro deletado do data table de escopo geral
            dtCipRotaDepend.Remove(CipRotaDepEdit(0))

            FlagDadosEdit = True

            RefreshDependencia()

        End If

    End Sub

    Private Sub butSensorExcluir_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles butSensorExcluir.Click

        If gvSensores.SelectedRows.Count <= 0 Then Return

        Dim Pos As Integer = gvSensores.CurrentRow.Index

        Dim myTag As String = gvSensores.Rows(Pos).Cells(0).Value

        Dim Ret As MsgBoxResult = MsgBox("Deseja realmente retirar o Sensor [ " & myTag.ToUpper & " ] da lista?", _
                                        MsgBoxStyle.Critical + MsgBoxStyle.YesNo, "Atenção")

        If Ret = MsgBoxResult.Yes Then

            'verifica se realmente existe
            Dim CipRotaPfEdit = (From It In dtCipRotaPf Where It.Tag = myTag).ToList
            If CipRotaPfEdit.Count <= 0 Then
                MsgBox("Erro! Dependência não encontrada: " & myTag.ToUpper)
                Return
            End If

            'apaga registro
            Banco.RotaPf.DeleteAllOnSubmit(CipRotaPfEdit)

            'remove o registro deletado do data table de escopo geral
            dtCipRotaPf.Remove(CipRotaPfEdit(0))

            FlagDadosEdit = True

            RefreshSensor()

        End If

    End Sub

    Private Sub butMotExcluir_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles butMotExcluir.Click

        If gvMotores.SelectedRows.Count <= 0 Then Return

        Dim Pos As Integer = gvMotores.CurrentRow.Index

        Dim myTag As String = gvMotores.Rows(Pos).Cells(0).Value

        Dim Ret As MsgBoxResult = MsgBox("Deseja realmente retirar o Motor [ " & myTag.ToUpper & " ] da lista?", _
                                        MsgBoxStyle.Critical + MsgBoxStyle.YesNo, "Atenção")

        If Ret = MsgBoxResult.Yes Then

            'verifica se realmente existe
            Dim CipRotaMotEdit = (From It In dtCipRotaMot Where It.Tag = myTag).ToList
            If CipRotaMotEdit.Count <= 0 Then
                MsgBox("Erro! Dependência não encontrada: " & myTag.ToUpper)
                Return
            End If

            'apaga registro
            Banco.RotaMot.DeleteAllOnSubmit(CipRotaMotEdit)

            'remove o registro deletado do data table de escopo geral
            dtCipRotaMot.Remove(CipRotaMotEdit(0))

            FlagDadosEdit = True

            RefreshMotor()

        End If

    End Sub

    Private Sub butValvAcIncluir_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles butValvAcIncluir.Click

        frmSelValv.Abre("AC")

        'verifica se realmente foi pedido a inclusao
        If frmSelValv.myFlagDadosEdit = False Then Return

        'obtem o tag selecionado
        Dim myTag As String = frmSelValv.myTag

        'verifica se valvula já cadastrada
        Dim CipRotaValvEdit = (From It In dtCipRotaValv Where It.Tag = myTag).ToList
        If CipRotaValvEdit.Count >= 1 Then
            MsgBox("Erro! Válvula: " & myTag.ToUpper & " já cadastrada!", MsgBoxStyle.Exclamation)
            Return
        End If

        'cria novo registro
        Dim CipRotaValvNew As New List(Of Geral.nsCipRotas.RotaValv)
        CipRotaValvNew.Add(New Geral.nsCipRotas.RotaValv With {.RotaId = txtRotaId.Text, .Tag = myTag, .Tipo = "A"})

        'insere o novo registro na tabela
        Banco.RotaValv.InsertAllOnSubmit(CipRotaValvNew)

        'adiciona o novo registro ao data table de escopo geral, para visualizar o novo registro no refresh dados
        dtCipRotaValv = dtCipRotaValv.Union(CipRotaValvNew).ToList

        FlagDadosEdit = True

        RefreshValv()

    End Sub

    Private Sub butValvNacIncluir_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles butValvNacIncluir.Click

        frmSelValv.Abre("NAC")

        'verifica se realmente foi pedido a inclusao
        If frmSelValv.myFlagDadosEdit = False Then Return

        'obtem o tag selecionado
        Dim myTag As String = frmSelValv.myTag

        'verifica se valvula já cadastrada
        Dim CipRotaValvEdit = (From It In dtCipRotaValv Where It.Tag = myTag).ToList
        If CipRotaValvEdit.Count >= 1 Then
            MsgBox("Erro! Válvula: " & myTag.ToUpper & " já cadastrada!", MsgBoxStyle.Exclamation)
            Return
        End If

        'cria novo registro
        Dim CipRotaValvNew As New List(Of Geral.nsCipRotas.RotaValv)
        CipRotaValvNew.Add(New Geral.nsCipRotas.RotaValv With {.RotaId = txtRotaId.Text, .Tag = myTag, .Tipo = "N"})

        'insere o novo registro na tabela
        Banco.RotaValv.InsertAllOnSubmit(CipRotaValvNew)

        'adiciona o novo registo ao data table de escopo geral, para visualizar o novo registro no refresh dados
        dtCipRotaValv = dtCipRotaValv.Union(CipRotaValvNew).ToList

        FlagDadosEdit = True

        RefreshValv()

    End Sub

    Private Sub butValvFlipIncluir_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles butValvFlipIncluir.Click

        frmSelValv.Abre("FLIP")

        'verifica se realmente foi pedido a inclusao
        If frmSelValv.myFlagDadosEdit = False Then Return

        'obtem o tag selecionado
        Dim myTag As String = frmSelValv.myTag
        Dim myFlip As String = frmSelValv.myFlip

        'verifica se valvula já cadastrada
        Dim CipRotaValvEdit = (From It In dtCipRotaValv Where It.Tag = myTag).ToList
        If CipRotaValvEdit.Count >= 1 Then
            MsgBox("Erro! Válvula: " & myTag.ToUpper & " já cadastrada!", MsgBoxStyle.Exclamation)
            Return
        End If

        'cria novo registro
        Dim CipRotaValvNew As New List(Of Geral.nsCipRotas.RotaValv)
        CipRotaValvNew.Add(New Geral.nsCipRotas.RotaValv With {.RotaId = txtRotaId.Text, .Tag = myTag, .Tipo = myFlip})

        'insere o novo registro na tabela
        Banco.RotaValv.InsertAllOnSubmit(CipRotaValvNew)

        'adiciona o novo registo ao data table de escopo geral, para visualizar o novo registro no refresh dados
        dtCipRotaValv = dtCipRotaValv.Union(CipRotaValvNew).ToList

        FlagDadosEdit = True

        RefreshValv()

    End Sub

    Private Sub butMotIncluir_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles butMotIncluir.Click

        frmSelMot.ShowDialog()

        'verifica se realmente foi pedido a inclusao
        If frmSelMot.myFlagDadosEdit = False Then Return

        'obtem o tag selecionado
        Dim myTag As String = frmSelMot.myTag
        Dim myTipo As String = frmSelMot.myTipo

        'verifica se já cadastrado
        Dim CipRotaMotEdit = (From It In dtCipRotaMot Where It.Tag = myTag).ToList
        If CipRotaMotEdit.Count >= 1 Then
            MsgBox("Erro! Motor: " & myTag.ToUpper & " já cadastrado!", MsgBoxStyle.Exclamation)
            Return
        End If

        'cria novo registro
        Dim CipRotaMotNew As New List(Of Geral.nsCipRotas.RotaMot)
        CipRotaMotNew.Add(New Geral.nsCipRotas.RotaMot With {.RotaId = txtRotaId.Text, .Tag = myTag, .Tipo = myTipo})

        'insere o novo registro na tabela
        Banco.RotaMot.InsertAllOnSubmit(CipRotaMotNew)

        'adiciona o novo registo ao data table de escopo geral, para visualizar o novo registro no refresh dados
        dtCipRotaMot = dtCipRotaMot.Union(CipRotaMotNew).ToList

        FlagDadosEdit = True

        RefreshMotor()

    End Sub

    Private Sub butSensorIncluir_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles butSensorIncluir.Click

        frmSelPf.ShowDialog()

        'verifica se realmente foi pedido a inclusao
        If frmSelPf.myFlagDadosEdit = False Then Return

        'obtem o tag selecionado
        Dim myTag As String = frmSelPf.myTag

        'verifica se já cadastrado
        Dim CipRotaPfEdit = (From It In dtCipRotaPf Where It.Tag = myTag).ToList
        If CipRotaPfEdit.Count >= 1 Then
            MsgBox("Erro! Sensor: " & myTag.ToUpper & " já cadastrado!", MsgBoxStyle.Exclamation)
            Return
        End If

        'cria novo registro
        Dim CipRotaPfNew As New List(Of Geral.nsCipRotas.RotaPf)
        CipRotaPfNew.Add(New Geral.nsCipRotas.RotaPf With {.RotaId = txtRotaId.Text, .Tag = myTag, .Tipo = ""})

        'insere o novo registro na tabela
        Banco.RotaPf.InsertAllOnSubmit(CipRotaPfNew)

        'adiciona o novo registo ao data table de escopo geral, para visualizar o novo registro no refresh dados
        dtCipRotaPf = dtCipRotaPf.Union(CipRotaPfNew).ToList

        FlagDadosEdit = True

        RefreshSensor()

    End Sub

    Private Sub butDepIncluir_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles butDepIncluir.Click

        frmSelDep.ShowDialog()

        'verifica se realmente foi pedido a inclusao
        If frmSelDep.myFlagDadosEdit = False Then Return

        'obtem o tag selecionado
        Dim myTag As String = frmSelDep.myTag

        'verifica se já cadastrado
        Dim CipRotaDepEdit = (From It In dtCipRotaDepend Where It.Tag = myTag).ToList
        If CipRotaDepEdit.Count >= 1 Then
            MsgBox("Erro! Tanque: " & myTag.ToUpper & " já cadastrado!", MsgBoxStyle.Exclamation)
            Return
        End If

        'cria novo registro
        Dim CipRotaDepNew As New List(Of Geral.nsCipRotas.RotaDepend)
        CipRotaDepNew.Add(New Geral.nsCipRotas.RotaDepend With {.RotaId = txtRotaId.Text, .Tag = myTag, .Tipo = ""})

        'insere o novo registro na tabela
        Banco.RotaDepend.InsertAllOnSubmit(CipRotaDepNew)

        'adiciona o novo registo ao data table de escopo geral, para visualizar o novo registro no refresh dados
        dtCipRotaDepend = dtCipRotaDepend.Union(CipRotaDepNew).ToList

        FlagDadosEdit = True

        RefreshDependencia()

    End Sub

    Private Sub butValvFlipHelp_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles butValvFlipHelp.Click

        frmCadFlip.Abre(False)

    End Sub

    Private Sub rdTanque_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles rdTanque.CheckedChanged

        If TelaAberta = False Then Return

        cmbTq1.Enabled = True
        cmbTq2.Enabled = True
        cmbTq3.Enabled = True

        Dim CipCadRotaEdit = (From It In dtCipCadRota Where It.RotaId = txtRotaId.Text).ToList
        If CipCadRotaEdit.Count <= 0 Then
            MsgBox("Erro! Rota não encontrada: " & txtRotaId.Text.ToUpper)
            Return
        End If

        'altera o campo
        CipCadRotaEdit(0).Tipo = "T"

        FlagDadosEdit = True

        RefreshValv()

    End Sub

    Private Sub rdLinha_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles rdLinha.CheckedChanged

        If TelaAberta = False Then Return

        cmbTq1.Enabled = False
        cmbTq2.Enabled = False
        cmbTq3.Enabled = False

        Dim CipCadRotaEdit = (From It In dtCipCadRota Where It.RotaId = txtRotaId.Text).ToList
        If CipCadRotaEdit.Count <= 0 Then
            MsgBox("Erro! Rota não encontrada: " & txtRotaId.Text.ToUpper)
            Return
        End If

        'altera o campo
        CipCadRotaEdit(0).Tipo = "L"
        CipCadRotaEdit(0).Tq1 = ""
        CipCadRotaEdit(0).Tq2 = ""
        CipCadRotaEdit(0).Tq3 = ""

        FlagDadosEdit = True

        RefreshValv()

    End Sub

    Private Sub cmbCirc_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmbCirc.SelectedIndexChanged

        'If frmMain.Edita = True Then

        If TelaAberta = False Then Return

        Dim CipCadRotaEdit = (From It In dtCipCadRota Where It.RotaId = txtRotaId.Text).ToList
        If CipCadRotaEdit.Count <= 0 Then
            MsgBox("Erro! Rota não encontrada: " & txtRotaId.Text.ToUpper)
            Return
        End If

        'altera o campo
        CipCadRotaEdit(0).Circ = cmbCirc.SelectedItem

        FlagDadosEdit = True

        RefreshValv()
        'Else
        '    RefreshValv()
        'End If

    End Sub

    Private Sub txtDescr_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtDescr.TextChanged

        If TelaAberta = False Then Return

        Dim CipCadRotaEdit = (From It In dtCipCadRota Where It.RotaId = txtRotaId.Text).ToList
        If CipCadRotaEdit.Count <= 0 Then
            MsgBox("Erro! Rota não encontrada: " & txtRotaId.Text.ToUpper)
            Return
        End If

        'altera o campo
        CipCadRotaEdit(0).Descr = txtDescr.Text

        FlagDadosEdit = True

        RefreshValv()

    End Sub

    Private Sub cmbTq1_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmbTq1.SelectedIndexChanged

        If TelaAberta = False Then Return

        Dim CipCadRotaEdit = (From It In dtCipCadRota Where It.RotaId = txtRotaId.Text).ToList
        If CipCadRotaEdit.Count <= 0 Then
            MsgBox("Erro! Rota não encontrada: " & txtRotaId.Text.ToUpper)
            Return
        End If

        'altera o campo
        CipCadRotaEdit(0).Tq1 = cmbTq1.SelectedItem

        FlagDadosEdit = True

        RefreshValv()

    End Sub

    Private Sub cmbTq2_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmbTq2.SelectedIndexChanged

        If TelaAberta = False Then Return

        Dim CipCadRotaEdit = (From It In dtCipCadRota Where It.RotaId = txtRotaId.Text).ToList
        If CipCadRotaEdit.Count <= 0 Then
            MsgBox("Erro! Rota não encontrada: " & txtRotaId.Text.ToUpper)
            Return
        End If

        'altera o campo
        CipCadRotaEdit(0).Tq2 = cmbTq2.SelectedItem

        FlagDadosEdit = True

        RefreshValv()

    End Sub

    Private Sub cmbTq3_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmbTq3.SelectedIndexChanged

        If TelaAberta = False Then Return

        Dim CipCadRotaEdit = (From It In dtCipCadRota Where It.RotaId = txtRotaId.Text).ToList
        If CipCadRotaEdit.Count <= 0 Then
            MsgBox("Erro! Rota não encontrada: " & txtRotaId.Text.ToUpper)
            Return
        End If

        'altera o campo
        CipCadRotaEdit(0).Tq3 = cmbTq3.SelectedItem

        FlagDadosEdit = True

        RefreshValv()

    End Sub

    Private Sub butValvAcPesq_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles butValvAcPesq.Click
        'Comunicação entre forms. Aqui é setado uma variavel chamada PesqTipo que é lida no outro form
        '1=Valvulas
        '2=Motores
        '3=Sensores
        '4=Tanques
        System.AppDomain.CurrentDomain.SetData("PesqTipo", 1)

        'Abre janela de pesquisa multipla
        frmPesquisa.ShowDialog()

        'verifica se realmente foi pedido a inclusao
        If System.AppDomain.CurrentDomain.GetData("FlagIncluirTags") = False Then Return

        'Le dados selecionados no form frmPesquisa
        Dim Txt As String = System.AppDomain.CurrentDomain.GetData("ItensSelecionados")

        'separa seleção em Tags distintos
        Dim TagValvulas() As String = Txt.Split(";")

        'Varre a lista de Tags recebida e inclui na rota
        Dim myTag As String
        For Each myTag In TagValvulas

            'verifica se valvula já cadastrada
            Dim CipRotaValvEdit = (From It In dtCipRotaValv Where It.Tag = myTag).ToList
            If CipRotaValvEdit.Count >= 1 Then

                MsgBox("Erro! Válvula: " & myTag.ToUpper & " já cadastrada!", MsgBoxStyle.Exclamation)

            Else

                'cria novo registro
                Dim CipRotaValvNew As New List(Of Geral.nsCipRotas.RotaValv)
                CipRotaValvNew.Add(New Geral.nsCipRotas.RotaValv With {.RotaId = txtRotaId.Text, .Tag = myTag, .Tipo = "A"})

                'insere o novo registro na tabela
                Banco.RotaValv.InsertAllOnSubmit(CipRotaValvNew)

                'adiciona o novo registro ao data table de escopo geral, para visualizar o novo registro no refresh dados
                dtCipRotaValv = dtCipRotaValv.Union(CipRotaValvNew).ToList

            End If

        Next

        FlagDadosEdit = True

        RefreshValv()

    End Sub

    Private Sub butValvNacPesq_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles butValvNacPesq.Click

        'Comunicação entre forms. Aqui é setado uma variavel chamada PesqTipo que é lida no outro form
        '1=Valvulas
        '2=Motores
        '3=Sensores
        '4=Tanques
        System.AppDomain.CurrentDomain.SetData("PesqTipo", 1)

        'Abre janela de pesquisa multipla
        frmPesquisa.ShowDialog()

        'verifica se realmente foi pedido a inclusao
        If System.AppDomain.CurrentDomain.GetData("FlagIncluirTags") = False Then Return

        'Le dados selecionados no form frmPesquisa
        Dim Txt As String = System.AppDomain.CurrentDomain.GetData("ItensSelecionados")

        'separa seleção em Tags distintos
        Dim TagValvulas() As String = Txt.Split(";")

        'Varre a lista de Tags recebida e inclui na rota
        Dim myTag As String
        For Each myTag In TagValvulas

            'verifica se valvula já cadastrada
            Dim CipRotaValvEdit = (From It In dtCipRotaValv Where It.Tag = myTag).ToList
            If CipRotaValvEdit.Count >= 1 Then

                MsgBox("Erro! Válvula: " & myTag.ToUpper & " já cadastrada!", MsgBoxStyle.Exclamation)

            Else

                'cria novo registro
                Dim CipRotaValvNew As New List(Of Geral.nsCipRotas.RotaValv)
                CipRotaValvNew.Add(New Geral.nsCipRotas.RotaValv With {.RotaId = txtRotaId.Text, .Tag = myTag, .Tipo = "N"})

                'insere o novo registro na tabela
                Banco.RotaValv.InsertAllOnSubmit(CipRotaValvNew)

                'adiciona o novo registro ao data table de escopo geral, para visualizar o novo registro no refresh dados
                dtCipRotaValv = dtCipRotaValv.Union(CipRotaValvNew).ToList

            End If

        Next

        FlagDadosEdit = True

        RefreshValv()
    End Sub

    Private Sub butValvFlipPesq_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles butValvFlipPesq.Click

        'Comunicação entre forms. Aqui é setado uma variavel chamada PesqTipo que é lida no outro form
        '1=Valvulas
        '2=Motores
        '3=Sensores
        '4=Tanques
        System.AppDomain.CurrentDomain.SetData("PesqTipo", 1)

        'Abre janela de pesquisa multipla
        frmPesquisa.ShowDialog()

        'verifica se realmente foi pedido a inclusao
        If System.AppDomain.CurrentDomain.GetData("FlagIncluirTags") = False Then Return

        'Le dados selecionados no form frmPesquisa
        Dim Txt As String = System.AppDomain.CurrentDomain.GetData("ItensSelecionados")

        'separa seleção em Tags distintos
        Dim TagValvulas() As String = Txt.Split(";")

        'Varre a lista de Tags recebida e inclui na rota
        Dim myTag As String
        For Each myTag In TagValvulas

            'verifica se valvula já cadastrada
            Dim CipRotaValvEdit = (From It In dtCipRotaValv Where It.Tag = myTag).ToList
            If CipRotaValvEdit.Count >= 1 Then

                MsgBox("Erro! Válvula: " & myTag.ToUpper & " já cadastrada!", MsgBoxStyle.Exclamation)

            Else

                'cria novo registro
                Dim CipRotaValvNew As New List(Of Geral.nsCipRotas.RotaValv)
                CipRotaValvNew.Add(New Geral.nsCipRotas.RotaValv With {.RotaId = txtRotaId.Text, .Tag = myTag, .Tipo = ""})

                'insere o novo registro na tabela
                Banco.RotaValv.InsertAllOnSubmit(CipRotaValvNew)

                'adiciona o novo registro ao data table de escopo geral, para visualizar o novo registro no refresh dados
                dtCipRotaValv = dtCipRotaValv.Union(CipRotaValvNew).ToList

            End If

        Next

        FlagDadosEdit = True

        RefreshValv()

    End Sub

    Private Sub butMotPesq_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles butMotPesq.Click

        'Comunicação entre forms. Aqui é setado uma variavel chamada PesqTipo que é lida no outro form
        '1=Valvulas
        '2=Motores
        '3=Sensores
        '4=Tanques
        System.AppDomain.CurrentDomain.SetData("PesqTipo", 2)

        'Abre janela de pesquisa multipla
        frmPesquisa.ShowDialog()

        'verifica se realmente foi pedido a inclusao
        If System.AppDomain.CurrentDomain.GetData("FlagIncluirTags") = False Then Return

        'Le dados selecionados no form frmPesquisa
        Dim Txt As String = System.AppDomain.CurrentDomain.GetData("ItensSelecionados")

        'separa seleção em Tags distintos
        Dim TagMotores() As String = Txt.Split(";")

        'Varre a lista de Tags recebida e inclui na rota
        Dim myTag As String
        For Each myTag In TagMotores

            Dim CipRotaMotEdit = (From It In dtCipRotaMot Where It.Tag = myTag).ToList
            If CipRotaMotEdit.Count >= 1 Then

                MsgBox("Erro! Motor: " & myTag.ToUpper & " já cadastrado!", MsgBoxStyle.Exclamation)

            Else

                'cria novo registro
                Dim CipRotaMotNew As New List(Of Geral.nsCipRotas.RotaMot)
                CipRotaMotNew.Add(New Geral.nsCipRotas.RotaMot With {.RotaId = txtRotaId.Text, .Tag = myTag, .Tipo = ""})

                'insere o novo registro na tabela
                Banco.RotaMot.InsertAllOnSubmit(CipRotaMotNew)

                'adiciona o novo registo ao data table de escopo geral, para visualizar o novo registro no refresh dados
                dtCipRotaMot = dtCipRotaMot.Union(CipRotaMotNew).ToList

            End If

        Next

        FlagDadosEdit = True

        RefreshMotor()

    End Sub

    Private Sub butSensorPesq_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles butSensorPesq.Click

        'Comunicação entre forms. Aqui é setado uma variavel chamada PesqTipo que é lida no outro form
        '1=Valvulas
        '2=Motores
        '3=Sensores
        '4=Tanques
        System.AppDomain.CurrentDomain.SetData("PesqTipo", 3)

        'Abre janela de pesquisa multipla
        frmPesquisa.ShowDialog()

        'verifica se realmente foi pedido a inclusao
        If System.AppDomain.CurrentDomain.GetData("FlagIncluirTags") = False Then Return

        'Le dados selecionados no form frmPesquisa
        Dim Txt As String = System.AppDomain.CurrentDomain.GetData("ItensSelecionados")

        'separa seleção em Tags distintos
        Dim TagMotores() As String = Txt.Split(";")

        'Varre a lista de Tags recebida e inclui na rota
        Dim myTag As String
        For Each myTag In TagMotores

            'verifica se já cadastrado
            Dim CipRotaPfEdit = (From It In dtCipRotaPf Where It.Tag = myTag).ToList
            If CipRotaPfEdit.Count >= 1 Then

                MsgBox("Erro! Sensor: " & myTag.ToUpper & " já cadastrado!", MsgBoxStyle.Exclamation)

            Else

                'cria novo registro
                Dim CipRotaPfNew As New List(Of Geral.nsCipRotas.RotaPf)
                CipRotaPfNew.Add(New Geral.nsCipRotas.RotaPf With {.RotaId = txtRotaId.Text, .Tag = myTag, .Tipo = ""})

                'insere o novo registro na tabela
                Banco.RotaPf.InsertAllOnSubmit(CipRotaPfNew)

                'adiciona o novo registo ao data table de escopo geral, para visualizar o novo registro no refresh dados
                dtCipRotaPf = dtCipRotaPf.Union(CipRotaPfNew).ToList

            End If

        Next

        FlagDadosEdit = True

        RefreshSensor()

    End Sub

    Private Sub butDepPesq_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles butDepPesq.Click

        'Comunicação entre forms. Aqui é setado uma variavel chamada PesqTipo que é lida no outro form
        '1=Valvulas
        '2=Motores
        '3=Sensores
        '4=Tanques
        System.AppDomain.CurrentDomain.SetData("PesqTipo", 4)

        'Abre janela de pesquisa multipla
        frmPesquisa.ShowDialog()

        'verifica se realmente foi pedido a inclusao
        If System.AppDomain.CurrentDomain.GetData("FlagIncluirTags") = False Then Return

        'Le dados selecionados no form frmPesquisa
        Dim Txt As String = System.AppDomain.CurrentDomain.GetData("ItensSelecionados")

        'separa seleção em Tags distintos
        Dim TagMotores() As String = Txt.Split(";")

        'Varre a lista de Tags recebida e inclui na rota
        Dim myTag As String
        For Each myTag In TagMotores

            'verifica se já cadastrado
            Dim CipRotaDepEdit = (From It In dtCipRotaDepend Where It.Tag = myTag).ToList
            If CipRotaDepEdit.Count >= 1 Then

                MsgBox("Erro! Tanque: " & myTag.ToUpper & " já cadastrado!", MsgBoxStyle.Exclamation)

            Else

                'cria novo registro
                Dim CipRotaDepNew As New List(Of Geral.nsCipRotas.RotaDepend)
                CipRotaDepNew.Add(New Geral.nsCipRotas.RotaDepend With {.RotaId = txtRotaId.Text, .Tag = myTag, .Tipo = ""})

                'insere o novo registro na tabela
                Banco.RotaDepend.InsertAllOnSubmit(CipRotaDepNew)

                'adiciona o novo registo ao data table de escopo geral, para visualizar o novo registro no refresh dados
                dtCipRotaDepend = dtCipRotaDepend.Union(CipRotaDepNew).ToList

            End If

        Next

        FlagDadosEdit = True

        RefreshDependencia()

    End Sub

    Private Sub txtVazao_TextChanged(sender As Object, e As EventArgs) Handles txtVazao.TextChanged

        If TelaAberta = False Then Return

        Dim CipCadRotaEdit = (From It In dtCipCadRota Where It.RotaId = txtRotaId.Text).ToList
        If CipCadRotaEdit.Count <= 0 Then
            MsgBox("Erro! Rota não encontrada: " & txtRotaId.Text.ToUpper)
            Return
        End If

        If txtVazao.Text = String.Empty Then

            CipCadRotaEdit(0).BbaCipFw = 0

        ElseIf IsNumeric(txtVazao.Text) = False Then

            CipCadRotaEdit(0).BbaCipFw = 0

        ElseIf txtVazao.Text < 0 Or txtVazao.Text > 50 Then

            CipCadRotaEdit(0).BbaCipFw = 0

        Else
            'altera o campo
            CipCadRotaEdit(0).BbaCipFw = txtVazao.Text
        End If

        FlagDadosEdit = True

        RefreshValv()

    End Sub

End Class