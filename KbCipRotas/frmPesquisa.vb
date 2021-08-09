Public Class frmPesquisa

    Dim PesquisaTipo As Integer
    Dim Banco As New Geral.nsCipRotas.dcCipRotas

    Private Sub RefreshDados()

        gvItens.Rows.Clear()

        Select Case PesquisaTipo
            Case 1
                RefreshValvulas()
            Case 2
                RefreshMotores()
            Case 3
                RefreshSensores()
            Case 4
                RefreshTanques()
        End Select

    End Sub

    Private Sub RefreshValvulas()

        Dim Valvulas As System.Linq.IOrderedQueryable(Of Geral.nsCipRotas.ValvCad)

        If txtFiltro.Text = "" Then

            Valvulas = From It In Banco.ValvCad Order By It.Tag

        Else

            Dim Filtro As String = "*" & txtFiltro.Text & "*"
            Valvulas = From It In Banco.ValvCad Where It.Tag Like Filtro Order By It.Tag

        End If

        For Each Reg In Valvulas
            gvItens.Rows.Add(Reg.Tag.ToUpper)
        Next

    End Sub

    Private Sub RefreshMotores()

        Dim Motores As System.Linq.IOrderedQueryable(Of Geral.nsCipRotas.MotCad)

        If txtFiltro.Text = "" Then

            Motores = From It In Banco.MotCad Order By It.Tag

        Else

            Dim Filtro As String = "*" & txtFiltro.Text & "*"
            Motores = From It In Banco.MotCad Where It.Tag Like Filtro Order By It.Tag

        End If

        For Each Reg In Motores
            gvItens.Rows.Add(Reg.Tag.ToUpper)
        Next

    End Sub

    Private Sub RefreshSensores()

        Dim Sensores As System.Linq.IOrderedQueryable(Of Geral.nsCipRotas.PfCad)

        If txtFiltro.Text = "" Then

            Sensores = From It In Banco.PfCad Order By It.Tag

        Else

            Dim Filtro As String = "*" & txtFiltro.Text & "*"
            Sensores = From It In Banco.PfCad Where It.Tag Like Filtro Order By It.Tag

        End If

        For Each Reg In Sensores
            gvItens.Rows.Add(Reg.Tag.ToUpper)
        Next

    End Sub

    Private Sub RefreshTanques()

        Dim Tanques As System.Linq.IOrderedQueryable(Of Geral.nsCipRotas.TqCad)

        If txtFiltro.Text = "" Then

            Tanques = From It In Banco.TqCad Order By It.Tag

        Else

            Dim Filtro As String = "*" & txtFiltro.Text & "*"
            Tanques = From It In Banco.TqCad Where It.Tag Like Filtro Order By It.Tag

        End If

        For Each Reg In Tanques
            gvItens.Rows.Add(Reg.Tag.ToUpper)
        Next

    End Sub

    Private Sub frmPesquisa_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        PesquisaTipo = System.AppDomain.CurrentDomain.GetData("PesqTipo")

        System.AppDomain.CurrentDomain.SetData("FlagIncluirTags", False)

        txtFiltro.Clear()
        RefreshDados()

    End Sub

    Private Sub butOk_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles butOk.Click

        Dim myTagSelects As String = ""

        If gvItens.SelectedRows.Count <= 0 Then Return

        For Each It In gvItens.SelectedRows

            If myTagSelects = "" Then
                myTagSelects = It.cells(0).value.ToString
            Else
                myTagSelects = myTagSelects & ";" & It.cells(0).value.ToString
            End If
        Next

        System.AppDomain.CurrentDomain.SetData("ItensSelecionados", myTagSelects)
        System.AppDomain.CurrentDomain.SetData("FlagIncluirTags", True)

        Me.Close()

    End Sub

    Private Sub txtFiltro_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtFiltro.TextChanged
        RefreshDados()
    End Sub

End Class