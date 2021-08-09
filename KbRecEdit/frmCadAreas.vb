Public Class frmCadAreas

    Dim ItemNovo As Boolean = False

    Dim CadAreas As clsAreas

    Private Sub RefreshGrid(Optional ByVal sArea As String = "")

        GridView.Rows.Clear()

        If CadAreas.Area.Count <= 0 Then Return

        For Each Reg In CadAreas.Area

            With Reg
                GridView.Rows.Add(.Area, .Descr, .UsaPlanejBrix, .UsaIngredMan, .UsaPesoRef, .RsLinxTopic)
            End With

        Next

    End Sub

    Private Sub EdicaoHabilita()

        butCancelar.Enabled = True
        butSalvar.Enabled = True

        txtArea.Enabled = False
        txtLinx.Enabled = True
        txtDescr.Enabled = True

        chkBrix.Enabled = True
        chkIngred.Enabled = True
        chkPeso.Enabled = True

    End Sub

    Private Sub EdicaoBloqueio()

        butCancelar.Enabled = False
        butSalvar.Enabled = False

        txtArea.Enabled = False
        txtLinx.Enabled = False
        txtDescr.Enabled = False

        chkBrix.Enabled = False
        chkIngred.Enabled = False
        chkPeso.Enabled = False

    End Sub

    Private Sub frmCadValv_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        CadAreas = New clsAreas

        RefreshGrid()

    End Sub

    Private Sub butSair_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles butSair.Click
        Me.Close()
    End Sub

    Private Sub GridView_MouseClick(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles GridView.MouseClick
        EdicaoBloqueio()
    End Sub

    Private Sub GridView_MouseDoubleClick(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles GridView.MouseDoubleClick
        EdicaoHabilita()
    End Sub

    Private Sub GridView_SelectionChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles GridView.SelectionChanged

        Dim Pos As Integer = GridView.CurrentRow.Index

        With GridView.Rows(Pos)

            txtArea.Text = .Cells(0).Value
            txtLinx.Text = .Cells(5).Value
            txtDescr.Text = .Cells(1).Value

            If .Cells(2).Value = 1 Then
                chkBrix.Checked = True
            Else
                chkBrix.Checked = False
            End If

            If .Cells(3).Value = 1 Then
                chkIngred.Checked = True
            Else
                chkIngred.Checked = False
            End If

            If .Cells(4).Value = 1 Then
                chkPeso.Checked = True
            Else
                chkPeso.Checked = False
            End If

        End With

    End Sub

    Private Sub butEditar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles butEditar.Click

        EdicaoHabilita()

    End Sub

    Private Sub LimparCampos()

        txtArea.Text = ""
        txtLinx.Text = ""
        txtDescr.Text = ""

        chkBrix.Checked = False
        chkIngred.Checked = False
        chkPeso.Checked = False

    End Sub

    Private Sub butNovo_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles butNovo.Click

        EdicaoHabilita()
        txtArea.Enabled = True

        ItemNovo = True

        LimparCampos()

    End Sub

    Private Sub butCancelar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles butCancelar.Click

        EdicaoBloqueio()

        Dim Pos As Integer = GridView.CurrentRow.Index

        With GridView.Rows(Pos)

            txtArea.Text = .Cells(0).Value
            txtLinx.Text = .Cells(5).Value
            txtDescr.Text = .Cells(1).Value

            If .Cells(2).Value = 1 Then
                chkBrix.Checked = True
            Else
                chkBrix.Checked = False
            End If

            If .Cells(3).Value = 1 Then
                chkIngred.Checked = True
            Else
                chkIngred.Checked = False
            End If

            If .Cells(4).Value = 1 Then
                chkPeso.Checked = True
            Else
                chkPeso.Checked = False
            End If

        End With

    End Sub

    Private Sub butSalvar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles butSalvar.Click

        Dim myArea As String = txtArea.Text
        Dim myLinx As String = txtLinx.Text
        Dim myDesc As String = txtDescr.Text

        Dim Brix As Integer
        If chkBrix.Checked = True Then
            Brix = 1
        Else
            Brix = 0
        End If

        Dim Peso As Integer
        If chkPeso.Checked = True Then
            Peso = 1
        Else
            Peso = 0
        End If

        Dim Ingred As Integer
        If chkIngred.Checked = True Then
            Ingred = 1
        Else
            Ingred = 0
        End If

        If ItemNovo = False Then
            'Atualizacao - Update
            
            CadAreas.AreaAtualiza(myArea, myDesc, myLinx, Brix, Ingred, Peso)

        Else
            'Novo - Insert
            Dim myTeste = From It In CadAreas.Area Where It.Area.ToUpper = myArea.ToUpper

            If myTeste.Count >= 1 Then
                MsgBox("A Área a ser cadastrada [" & myArea.ToUpper & "] já existe neste sistema. Favor utilizar outro nome para a Área!", _
                        MsgBoxStyle.Exclamation, "Atenção")

                ItemNovo = False
                LimparCampos()
                EdicaoBloqueio()

                Exit Sub

            End If

            CadAreas.AreaNova(myArea, myDesc, Ingred, Peso, Brix, myLinx)

        End If

        ItemNovo = False

        EdicaoBloqueio()

        RefreshGrid()

    End Sub

    Private Sub butApagar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles butApagar.Click

        Dim Pos As Integer = GridView.CurrentRow.Index

        Dim myArea As String = GridView.Rows(Pos).Cells(0).Value

        Dim Ret As MsgBoxResult = MsgBox("Deseja realmente apagar o registro da Área [ " & myArea.ToUpper & " ]?", _
                                        MsgBoxStyle.Question + MsgBoxStyle.YesNo, "Atenção")

        If Ret = MsgBoxResult.Yes Then

            CadAreas.AreaRemove(myArea)

            RefreshGrid()

        End If

    End Sub

End Class