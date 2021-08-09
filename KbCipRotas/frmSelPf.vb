Public Class frmSelPf

    Public myTag As String
    Public myFlagDadosEdit As Boolean = False

    Private Sub frmSelPf_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        RefreshPf()
        
        txtFiltro.Text = ""

        myFlagDadosEdit = False

    End Sub

    Private Sub RefreshPf(Optional ByVal Filtro As String = "")

        Dim Banco As New Geral.nsCipRotas.dcCipRotas

        Dim myReg As System.Linq.IOrderedQueryable(Of Geral.nsCipRotas.PfCad)

        If Filtro = "" Then
            myReg = From It In Banco.PfCad Order By It.Tag
        Else
            Dim myFiltro As String = "*" & Filtro & "*"
            myReg = From It In Banco.PfCad Where It.Tag Like myFiltro Order By It.Tag
        End If

        lstSensores.Items.Clear()

        For Each Reg In myReg
            lstSensores.Items.Add(Reg.Tag.ToUpper)
        Next

    End Sub

    Private Sub txtFiltro_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtFiltro.TextChanged
        RefreshPf(txtFiltro.Text)
    End Sub

    Private Sub butCancelar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles butCancelar.Click
        Me.Close()
    End Sub

    Private Sub butOk_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles butOk.Click

        If lstSensores.SelectedItems.Count <= 0 Then Return

        myFlagDadosEdit = True
        myTag = lstSensores.SelectedItem

        Me.Close()

    End Sub

End Class