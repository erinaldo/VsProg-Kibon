Public Class frmCadAlergEdit

    Dim NovoItem As Boolean
    Dim vCodAlerg As Integer = 0

    Sub Abre(Optional pCodAlerg As Integer = 0)

        vCodAlerg = pCodAlerg

        Dim DbAlerg = New Geral.nsReceitas.dcReceitas

        If pCodAlerg = 0 Then

            'Novo item
            NovoItem = True

            txtLetra.Enabled = True
            txtLetra.Text = ""
            txtNome.Text = ""
            txtDescr.Text = ""
            butOp.Text = "Novo"
            txtLetra.Focus()

        Else

            'Edicao de um item existente
            NovoItem = False

            'Busca dados
            Dim dtAllergy = (From It In DbAlerg.Alergenico Where It.CodAlergenico = pCodAlerg).ToList
            If dtAllergy.Count <= 0 Then Return

            With dtAllergy.First

                txtLetra.Text = .Letra
                txtNome.Text = .Nome
                txtDescr.Text = .Descr

            End With

            txtLetra.Enabled = False
            butOp.Text = "Editar"
            txtNome.Focus()

        End If

        ShowDialog()

    End Sub


    Private Sub butOp_Click(sender As Object, e As EventArgs) Handles butOp.Click

        txtLetra.Text = txtLetra.Text.Trim

        If txtLetra.Text.Length <= 0 Then
            MsgBox("Erro: Informe a letra associada ao alergêncio.")
            txtLetra.Focus()
            Return
        End If
        If IsNumeric(txtLetra.Text) Then
            MsgBox("Erro: Informe a letra associada ao alergêncio. Não é permitido utilizar números.")
            txtLetra.Focus()
            Return
        End If

        If IsNumeric(txtLetra.Text) = True Or txtLetra.Text.Length > 2 Then
            MsgBox("Erro: Informe a letra associada ao alergêncio. Não é permitido utilizar mais de 2 letras.")
            txtLetra.Focus()
            Return
        End If

        Dim DbAlerg As New Geral.nsReceitas.dcReceitas

        Dim dtAlerg = (From It In DbAlerg.Alergenico Where It.Letra = txtLetra.Text.ToUpper).ToList

        If NovoItem = True Then

            'Verifica se já existe
            If dtAlerg.Count > 0 Then
                MsgBox("Erro: já existe um alergênico cadastrado com a respectiva letra.")
                Return
            End If

            Dim dtAllergy = (From It In DbAlerg.Alergenico).ToList
            Dim nCodAlerg As Integer = dtAllergy.Last().CodAlergenico + 1

            DbAlerg.Alergenico.InsertOnSubmit(New Geral.nsReceitas.Alergenico With {.CodAlergenico = nCodAlerg, .Nome = txtNome.Text, .Descr = txtDescr.Text, .Letra = txtLetra.Text.ToUpper})

        Else

            If dtAlerg.Count <= 0 Then Return

            'Dim dtAlergRep = (From It In DbAlerg.Alergenico Where It.Letra = txtLetra.Text.ToUpper).ToList
            'If dtAlergRep.Count >= 1 Then
            '    MsgBox("Erro: já existe um alergênico cadastrado com a respectiva letra.")
            '    Return
            'End If

            'dtAlerg.First().Letra = txtLetra.Text.ToUpper
            dtAlerg.First().Nome = txtNome.Text
            dtAlerg.First().Descr = txtDescr.Text

        End If

        DbAlerg.SubmitChanges()

        Close()

    End Sub

    Private Sub butCancelar_Click(sender As Object, e As EventArgs) Handles butCancelar.Click

        Close()

    End Sub

End Class