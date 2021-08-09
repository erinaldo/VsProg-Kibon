Public Class frmCadPtoCrEdit

    Dim Bp As New Geral.nsCipValid.dcCipValid

    Public Pergunta As String = ""

    Sub Abre(ByVal PtoCrLd)

        txtPtoCrLd.Text = PtoCrLd
        txtPergunta.Text = ""

        ShowDialog()

    End Sub

    Sub NovoDadosPtoCr()

        Pergunta = txtPergunta.Text

    End Sub

    Private Sub btnSalva_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSalva.Click

        'Verificação dos campos
        If txtPtoCrLd.Text = "" Then
            MsgBox("Erro: o Nome da área não pode ser nulo.", MsgBoxStyle.Critical)
            Return
        End If

        If txtPergunta.Text = "" Then
            MsgBox("Erro: o Nome da área não pode ser nulo.", MsgBoxStyle.Critical)
            Return
        End If

        NovoDadosPtoCr()

        Close()

    End Sub

    Private Sub btnCancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCancel.Click

        txtPergunta.Text = ""

        Close()

    End Sub
End Class