Public Class frmCadFlip

    Dim ItemNovo As Boolean = False
    Dim EdicaoPermitida As Boolean = True

    Public Sub Abre(Optional ByVal Editar As Boolean = True)

        If Editar = False Then

            EdicaoPermitida = Editar

            EdicaoBloqueio()
            butApagar.Enabled = False
            butEditar.Enabled = False
            butNovo.Enabled = False

            Me.Height = 370

        End If

        RefreshGrid()

        Me.ShowDialog()

    End Sub

    Private Sub RefreshGrid(Optional ByVal sTag As String = "")

        Dim Banco As New Geral.nsCipRotas.dcCipRotas
        'Banco.Log = Console.Out

        Dim myReg As System.Linq.IOrderedQueryable(Of Geral.nsCipRotas.FlipCad)

        myReg = (From It In Banco.FlipCad Order By It.Tipo).ToList

        GridView.Rows.Clear()

        If myReg.Count <= 0 Then Return

        For Each Reg In myReg

            GridView.Rows.Add(Reg.Tipo, Reg.Descr, Reg.Codigo)

        Next

    End Sub

    Private Sub EdicaoHabilita()
        butCancelar.Enabled = True
        butSalvar.Enabled = True

        txtCodigo.Enabled = True
        txtDescr.Enabled = True
    End Sub

    Private Sub EdicaoBloqueio()
        butCancelar.Enabled = False
        butSalvar.Enabled = False
        txtTipo.Enabled = False
        txtCodigo.Enabled = False
        txtDescr.Enabled = False
    End Sub

    Private Sub LimparCampos()
        txtTipo.Text = ""
        txtCodigo.Text = ""
        txtDescr.Text = ""
    End Sub

    Private Sub butSair_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles butSair.Click
        Me.Close()
    End Sub

    Private Sub GridView_SelectionChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles GridView.SelectionChanged

        Dim Pos As Integer = GridView.CurrentRow.Index

        txtTipo.Text = GridView.Rows(Pos).Cells(0).Value
        txtCodigo.Text = GridView.Rows(Pos).Cells(2).Value
        txtDescr.Text = GridView.Rows(Pos).Cells(1).Value

    End Sub

    Private Sub butEditar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles butEditar.Click

        EdicaoHabilita()

    End Sub

    Private Sub butNovo_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles butNovo.Click

        EdicaoHabilita()
        txtTipo.Enabled = True

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
            Dim myReg = (From It In Banco.FlipCad Where It.Tipo.ToUpper = txtTipo.Text.ToUpper).ToList

            For Each Reg In myReg
                Reg.Codigo = CInt(txtCodigo.Text)
                Reg.Descr = txtDescr.Text
            Next

            Banco.SubmitChanges()

        Else
            'Novo - Insert
            Dim myTeste = (From It In Banco.FlipCad Where It.Tipo.ToUpper = txtTipo.Text.ToUpper).ToList

            If myTeste.Count >= 1 Then
                MsgBox("O Tipo a ser cadastrado [ " & txtTipo.Text.ToUpper & " ] já existe neste sistema. Favor utilizar outro!", _
                        MsgBoxStyle.Exclamation, "Atenção")

                ItemNovo = False
                LimparCampos()
                EdicaoBloqueio()

                Exit Sub

            End If

            Dim myRegNovo As New Geral.nsCipRotas.FlipCad

            myRegNovo.Tipo = txtTipo.Text.ToUpper
            myRegNovo.Codigo = txtCodigo.Text.ToUpper
            myRegNovo.Descr = txtDescr.Text

            Banco.FlipCad.InsertOnSubmit(myRegNovo)

            Banco.SubmitChanges()

        End If

        ItemNovo = False

        EdicaoBloqueio()

        RefreshGrid(txtTipo.Text)

    End Sub

    Private Sub butApagar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles butApagar.Click

        Dim Pos As Integer = GridView.CurrentRow.Index

        Dim myTipo As String = GridView.Rows(Pos).Cells(0).Value

        Dim Banco As New Geral.nsCipRotas.dcCipRotas

        Dim myReg = From It In Banco.FlipCad Where It.Tipo.ToUpper = myTipo.ToUpper

        Dim Ret As MsgBoxResult = MsgBox("Deseja realmente apagar o Flip [ " & myTipo.ToUpper & " ]?", _
                                        MsgBoxStyle.Critical + MsgBoxStyle.YesNo, "Atenção")

        If Ret = MsgBoxResult.Yes Then

            Banco.FlipCad.DeleteAllOnSubmit(myReg)

            Banco.SubmitChanges()

            RefreshGrid()

        End If

    End Sub

End Class