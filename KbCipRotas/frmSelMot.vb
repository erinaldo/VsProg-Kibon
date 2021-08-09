Public Class frmSelMot

    Public myTag As String
    Public myTipo As String
    Public myFlagDadosEdit As Boolean = False

    Private Sub frmSelMot_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        RefreshMot()

        txtFiltro.Text = ""

        myFlagDadosEdit = False

    End Sub

    Private Sub RefreshMot(Optional ByVal Filtro As String = "")

        Dim Banco As New Geral.nsCipRotas.dcCipRotas

        Dim myReg As System.Linq.IOrderedQueryable(Of Geral.nsCipRotas.MotCad)

        If Filtro = "" Then
            myReg = From It In Banco.MotCad Order By It.Tag
        Else
            Dim myFiltro As String = "*" & Filtro & "*"
            myReg = From It In Banco.MotCad Where It.Tag Like myFiltro Order By It.Tag
        End If

        lstMotores.Items.Clear()

        For Each Reg In myReg
            lstMotores.Items.Add(Reg.Tag.ToUpper)
        Next

    End Sub

    Private Sub txtFiltro_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtFiltro.TextChanged
        RefreshMot(txtFiltro.Text)
    End Sub

    Private Sub butCancelar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles butCancelar.Click
        Me.Close()
    End Sub

    Private Sub butOk_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles butOk.Click

        If lstMotores.SelectedItems.Count <= 0 Then Return

        myFlagDadosEdit = True
        myTag = lstMotores.SelectedItem
        myTipo = cmbTipo.Text

        Me.Close()

    End Sub

End Class