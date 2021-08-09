Public Class frmCadValv

    Dim ItemNovo As Boolean = False

    Private Sub RefreshGrid(Optional ByVal sTag As String = "")

        Dim Banco As New Geral.nsCipRotas.dcCipRotas
        'Banco.Log = Console.Out

        Dim myReg As System.Linq.IOrderedQueryable(Of Geral.nsCipRotas.ValvCad)

        Dim myFiltro As String

        If txtFiltro.Text = "" Then

            If cmbTipo.SelectedIndex = 0 Then
                myReg = From It In Banco.ValvCad Order By It.Tag
            Else
                myReg = From It In Banco.ValvCad Order By It.PlcNum, It.PlcIdx
            End If

        Else
            myFiltro = "*" & txtFiltro.Text & "*"

            If cmbTipo.SelectedIndex = 0 Then
                myReg = From It In Banco.ValvCad Where It.Tag Like myFiltro Order By It.Tag
            Else
                myReg = From It In Banco.ValvCad Where It.Tag Like myFiltro Order By It.PlcNum, It.PlcIdx
            End If

        End If

        GridView.Rows.Clear()

        If myReg.Count <= 0 Then Return

        For Each Reg In myReg

            GridView.Rows.Add(Reg.Tag, Reg.PlcNum, Reg.PlcIdx, Reg.Descr)

        Next

        'If sTag <> "" Then
        '    Dim Pos As Integer = 0
        '    For Conta As Integer = 0 To GridView.RowCount - 1

        '        If GridView.Rows(Conta).Cells(0).Value.ToString.ToUpper = sTag.ToUpper Then
        '            Pos = Conta
        '            Exit For
        '        End If

        '    Next

        '    GridView.Rows.

        'End If

    End Sub

    Private Sub EdicaoHabilita()
        butCancelar.Enabled = True
        butSalvar.Enabled = True

        txtPlc.Enabled = True
        txtIndice.Enabled = True
        txtDescr.Enabled = True
    End Sub

    Private Sub EdicaoBloqueio()
        butCancelar.Enabled = False
        butSalvar.Enabled = False
        txtTag.Enabled = False
        txtPlc.Enabled = False
        txtIndice.Enabled = False
        txtDescr.Enabled = False
    End Sub

    Private Sub frmCadValv_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        cmbTipo.SelectedIndex = 0

        RefreshGrid()

    End Sub

    Private Sub butSair_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles butSair.Click
        Me.Close()
    End Sub

    Private Sub cmbTipo_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmbTipo.SelectedIndexChanged
        RefreshGrid()
    End Sub

    Private Sub txtFiltro_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtFiltro.TextChanged
        RefreshGrid()
    End Sub

    Private Sub GridView_SelectionChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles GridView.SelectionChanged

        Dim Pos As Integer = GridView.CurrentRow.Index

        txtTag.Text = GridView.Rows(Pos).Cells(0).Value
        txtPlc.Text = GridView.Rows(Pos).Cells(1).Value
        txtIndice.Text = GridView.Rows(Pos).Cells(2).Value
        txtDescr.Text = GridView.Rows(Pos).Cells(3).Value

    End Sub

    Private Sub butEditar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles butEditar.Click

        EdicaoHabilita()

    End Sub

    Private Sub LimparCampos()
        txtTag.Text = ""
        txtIndice.Text = ""
        txtPlc.Text = ""
        txtDescr.Text = ""
    End Sub

    Private Sub butNovo_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles butNovo.Click

        EdicaoHabilita()
        txtTag.Enabled = True

        ItemNovo = True

        LimparCampos()

    End Sub

    Private Sub butCancelar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles butCancelar.Click

        EdicaoBloqueio()

    End Sub

    Private Sub butSalvar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles butSalvar.Click

        Dim Banco As New Geral.nsCipRotas.dcCipRotas

        If ItemNovo = False Then
            'Atualizacao - Update
            Dim myReg = From It In Banco.ValvCad Where It.Tag.ToUpper = txtTag.Text.ToUpper

            For Each Reg In myReg
                Reg.PlcNum = CInt(txtPlc.Text)
                Reg.PlcIdx = CInt(txtIndice.Text)
                Reg.Descr = txtDescr.Text
            Next

            Banco.SubmitChanges()

        Else
            'Novo - Insert
            Dim myTeste = From It In Banco.ValvCad Where It.Tag.ToUpper = txtTag.Text.ToUpper

            If myTeste.Count >= 1 Then
                MsgBox("O Tag a ser cadastrado [ " & txtTag.Text.ToUpper & " ] já existe neste sistema. Favor utilizar outro Tag!", _
                        MsgBoxStyle.Exclamation, "Atenção")

                ItemNovo = False
                LimparCampos()
                EdicaoBloqueio()

                Exit Sub

            End If

            Dim myRegNovo As New Geral.nsCipRotas.ValvCad

            myRegNovo.Tag = txtTag.Text.ToUpper
            myRegNovo.PlcNum = CInt(txtPlc.Text)
            myRegNovo.PlcIdx = CInt(txtIndice.Text)
            myRegNovo.Descr = txtDescr.Text

            Banco.ValvCad.InsertOnSubmit(myRegNovo)

            Banco.SubmitChanges()

        End If

        ItemNovo = False

        EdicaoBloqueio()

        RefreshGrid(txtTag.Text)

    End Sub

    Private Sub butApagar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles butApagar.Click

        Dim Pos As Integer = GridView.CurrentRow.Index

        Dim myTag As String = GridView.Rows(Pos).Cells(0).Value

        Dim Banco As New Geral.nsCipRotas.dcCipRotas

        Dim myReg = From It In Banco.ValvCad Where It.Tag.ToUpper = myTag.ToUpper

        Dim Ret As MsgBoxResult = MsgBox("Deseja realmente apagar a Válvula [ " & myTag.ToUpper & " ]?", _
                                        MsgBoxStyle.Critical + MsgBoxStyle.YesNo, "Atenção")

        If Ret = MsgBoxResult.Yes Then

            Banco.ValvCad.DeleteAllOnSubmit(myReg)

            Banco.SubmitChanges()

            RefreshGrid()

        End If

    End Sub

End Class