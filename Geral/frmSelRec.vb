Public Class frmSelRec

    Dim dtReceita As New List(Of Geral.nsReceitas.Rec)

    Dim lstPastas As New Collection

    Dim lstSubPastas As New Collection

    Dim Area As String

    Public SelRecNum As Integer

    Public Sub Abre(ByVal sArea As String)

        Area = sArea

        RefreshPastas()
        cmbPasta.Text = "*"

        RefreshSubpastas()
        RefreshReceitas()

        RefreshTree()

        Me.ShowDialog()

    End Sub

    Private Sub RefreshPastas()

        cmbPasta.Items.Clear()

        Dim Banco As New Geral.nsReceitas.dcReceitas

        'O comando abaixo retorna uma lista de strings pois retorna apenas um campo
        Dim myPastas = From It In Banco.Rec Where It.Area = Area Order By It.Pasta Select It.Pasta Distinct

        lstPastas = New Collection

        cmbPasta.Items.Add("*")
        lstPastas.Add("*", "*")

        For Each Pasta In myPastas
            If Pasta <> "" And Pasta <> "*" Then
                cmbPasta.Items.Add(Pasta)
                lstPastas.Add(Pasta, Pasta)
            End If
        Next

    End Sub

    Private Sub RefreshSubpastas()

        cmbSubpasta.Items.Clear()

        cmbSubpasta.Items.Add("*")

        cmbSubpasta.Text = "*"

        Dim Banco As New Geral.nsReceitas.dcReceitas

        'O comando abaixo por retornar 2 campos mantem o nome das mesmas na estrutura
        Dim myReg = From It In Banco.Rec Where It.Area = Area And It.Pasta = cmbPasta.Text Order By It.Subpasta Select It.Subpasta, It.Pasta Distinct

        lstSubPastas = New Collection

        For Each Reg In myReg

            If Reg.Subpasta <> "" And Reg.Subpasta <> "*" Then
                cmbSubpasta.Items.Add(Reg.Subpasta)
                lstSubPastas.Add(Reg.Subpasta)
            End If
        Next

    End Sub

    Private Sub RefreshReceitas()

        Dim Pasta As String = cmbPasta.Text
        Dim Subpasta As String = cmbSubpasta.Text
        Dim Descr As String = ""

        Dim Banco As New Geral.nsReceitas.dcReceitas

        Dim dtReceita = (From It In Banco.Rec Where It.Area = Area Order By It.RecNum).ToList

        'gvReceitas.Visible = False

        gvReceitas.Rows.Clear()

        For Each Reg In dtReceita

            Descr = Reg.RecDescr.ToUpper

            If Pasta = "*" And Subpasta = "*" Then
                'nada foi selecionado ou filtrado
                gvReceitas.Rows.Add(Reg.RecNum, Reg.RecNome, Reg.RecDescr)
            Else
                'pasta selecionada
                If Pasta <> "*" And Pasta = Reg.Pasta Then
                    If Subpasta = "*" Then
                        gvReceitas.Rows.Add(Reg.RecNum, Reg.RecNome, Reg.RecDescr)
                    ElseIf Subpasta <> "*" And Subpasta = Reg.Subpasta Then
                        gvReceitas.Rows.Add(Reg.RecNum, Reg.RecNome, Reg.RecDescr)
                    End If
                End If
            End If

        Next

        gvReceitas.Visible = True

    End Sub

    Private Sub RefreshTree()

        trPastas.Nodes.Clear()

        trPastas.Nodes.Add("Pastas")

        Dim Nodo As TreeNode

        Dim sPasta As String

        Dim Banco As New Geral.nsReceitas.dcReceitas

        For Conta As Integer = 1 To lstPastas.Count

            sPasta = lstPastas.Item(Conta)

            If sPasta <> "" And sPasta <> "*" Then

                Nodo = trPastas.Nodes(0).Nodes.Add(sPasta)

                'O comando abaixo por retornar 2 campos mantem o nome das mesmas na estrutura
                Dim myReg = From It In Banco.Rec Where It.Area = Area And It.Pasta = sPasta _
                            Order By It.Subpasta Select It.Subpasta, It.Pasta Distinct

                For Each Reg In myReg

                    If Reg.Subpasta <> "" And Reg.Subpasta <> "*" Then
                        Nodo.Nodes.Add(Reg.Subpasta)
                    End If
                Next
                
            End If

        Next

        trPastas.ShowLines = True
        trPastas.Nodes(0).Expand()

    End Sub

    Private Sub butCancelar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles butCancelar.Click

        Me.Close()

    End Sub

    Private Sub butOk_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles butOk.Click

        If gvReceitas.SelectedRows.Count <= 0 Then Return

        Dim Pos As Integer = gvReceitas.CurrentRow.Index

        SelRecNum = gvReceitas.Rows(Pos).Cells(0).Value

        Me.Close()

    End Sub

    Private Sub cmbPasta_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmbPasta.SelectedIndexChanged

        RefreshSubpastas()
        RefreshReceitas()

    End Sub

    Private Sub cmbSubpasta_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmbSubpasta.SelectedIndexChanged

        RefreshReceitas()

    End Sub

    Private Sub trPastas_AfterSelect(ByVal sender As System.Object, ByVal e As System.Windows.Forms.TreeViewEventArgs) Handles trPastas.AfterSelect

        Dim Nodo As TreeNode = trPastas.SelectedNode

        Try
            If Nodo.Text.ToUpper = "PASTAS" Then

                cmbPasta.Text = "*"
                cmbSubpasta.Text = "*"

            Else
                Dim Filho As TreeNode = Nothing
                Try
                    Filho = Nodo.FirstNode
                Catch : End Try

                If Not (Filho Is Nothing) Then
                    'Circuito
                    'E pai
                    'Debug.Print "Pai " & trPastas.SelectedItem.Text

                    cmbPasta.Text = trPastas.SelectedNode.Text
                    cmbSubpasta.Text = "*"

                Else
                    'Subpasta
                    'E filho
                    'Debug.Print "Filho " & trPastas.SelectedItem.Parent.Text & "->" & trPastas.SelectedItem.Text

                    cmbPasta.Text = trPastas.SelectedNode.Parent.Text
                    cmbSubpasta.Text = trPastas.SelectedNode.Text

                End If

            End If
        Catch : End Try

        RefreshReceitas()

    End Sub

    Private Sub gvReceitas_CellDoubleClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles gvReceitas.CellDoubleClick
        butOk_Click(sender, e)
    End Sub

End Class