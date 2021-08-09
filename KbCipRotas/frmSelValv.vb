Public Class frmSelValv

    Public myTag As String
    Public myFlip As String
    Public myFlagDadosEdit As Boolean = False

    Public Sub Abre(ByVal Tipo As String)

        rdAc.Enabled = False
        rdFlip.Enabled = False
        rdNac.Enabled = False
        cmbFlip.Enabled = False

        If Tipo = "AC" Then
            rdAc.Checked = True
        ElseIf Tipo = "NAC" Then
            rdNac.Checked = True
        Else
            rdFlip.Checked = True
            cmbFlip.Enabled = True
        End If

        RefreshCmbFlip()
        RefreshValv()

        txtFiltro.Text = ""

        myFlagDadosEdit = False

        Me.ShowDialog()

    End Sub

    Private Sub RefreshCmbFlip()

        Dim Banco As New Geral.nsCipRotas.dcCipRotas

        Dim myReg = From It In Banco.FlipCad

        cmbFlip.Items.Clear()

        For Each Reg In myReg

            cmbFlip.Items.Add(Reg.Tipo)
        Next

        cmbFlip.SelectedIndex = 0

    End Sub

    Private Sub RefreshValv(Optional ByVal Filtro As String = "")

        Dim Banco As New Geral.nsCipRotas.dcCipRotas

        Dim myReg As System.Linq.IOrderedQueryable(Of Geral.nsCipRotas.ValvCad)

        If Filtro = "" Then
            myReg = From It In Banco.ValvCad Order By It.Tag
        Else
            Dim myFiltro As String = "*" & Filtro & "*"
            myReg = From It In Banco.ValvCad Where It.Tag Like myFiltro Order By It.Tag
        End If

        lstValvulas.Items.Clear()

        For Each Reg In myReg
            lstValvulas.Items.Add(Reg.Tag.ToUpper)
        Next

    End Sub

    Private Sub txtFiltro_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtFiltro.TextChanged
        RefreshValv(txtFiltro.Text)
    End Sub

    Private Sub butCancelar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles butCancelar.Click
        Me.Close()
    End Sub

    Private Sub butOk_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles butOk.Click

        If lstValvulas.SelectedItems.Count <= 0 Then Return

        myFlagDadosEdit = True
        myTag = lstValvulas.SelectedItem
        myFlip = cmbFlip.Text

        Me.Close()

    End Sub

End Class