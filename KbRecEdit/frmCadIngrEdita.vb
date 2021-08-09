Public Class frmCadIngrEdita

    Dim Area As String = ""
    Dim NovoItem As Boolean

    Sub Abre(Area As String, IngrCodigo As String)

        Me.Area = Area
        Dim DbRc As New Geral.nsReceitas.dcReceitas

        If IngrCodigo = "" Then

            'Novo item
            NovoItem = True

            txtIngrCodigo.Text = ""
            txtIngrCodigo.ReadOnly = False

            txtIngrNome.Text = ""

        Else

            'Edicao de um item existente
            NovoItem = False

            txtIngrCodigo.Text = IngrCodigo
            txtIngrCodigo.ReadOnly = True

            'Busca dados
            Dim dtIngr = (From It In DbRc.Ingred Where It.Area = Area And It.IngrCodigo = IngrCodigo).ToList
            If dtIngr.Count <= 0 Then Return

            With dtIngr.First

                txtIngrNome.Text = .IngrNome

            End With

        End If

        ShowDialog()

    End Sub

    Private Sub butCancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles butCancela.Click
        Close()
    End Sub

    Private Sub butOk_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles butOk.Click

        txtIngrCodigo.Text = txtIngrCodigo.Text.Trim

        If txtIngrCodigo.Text.Count <= 0 Then
            MsgBox("Erro: o código não pode ser vazio.")
            Return
        End If


        Dim DbRc As New Geral.nsReceitas.dcReceitas
        Dim dtIngr = (From It In DbRc.Ingred Where It.Area = Area And It.IngrCodigo = txtIngrCodigo.Text).ToList

        If NovoItem = True Then

            'Verifica se já existe
            If dtIngr.Count > 0 Then
                MsgBox("Erro: já existe um ingrediente cadastrado com este código.")
                Return
            End If

            DbRc.Ingred.InsertOnSubmit(New Geral.nsReceitas.Ingred With {.Area = Area,
                                    .IngrCodigo = txtIngrCodigo.Text, .IngrNome = txtIngrNome.Text})

        Else

            If dtIngr.Count <= 0 Then Return
            dtIngr.First.IngrNome = txtIngrNome.Text
 
        End If

        DbRc.SubmitChanges()
        Close()

    End Sub

End Class