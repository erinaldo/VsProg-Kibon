Public Class frmCadBlocos

    Dim ItemNovo As Boolean = False

    Dim CadBlocos As clsBlocos

    Private Sub RefreshDados()

        RefreshBlocos()

        RefreshPrm()

    End Sub

    Private Sub RefreshBlocos()

        gvBlocos.Rows.Clear()

        If CadBlocos.Bloco.Count <= 0 Then Return

        For Each Reg In CadBlocos.Bloco

            With Reg
                gvBlocos.Rows.Add(.BlkNum, .Descr, .Mnemonico)
            End With

        Next
    End Sub

    Private Sub RefreshPrm(Optional ByVal Idx As Integer = 0)

        gvParam.Rows.Clear()

        If CadBlocos.Bloco(Idx).Itens.Count <= 0 Then Return

        For Each Reg In CadBlocos.Bloco(Idx).Itens

            With Reg
                gvParam.Rows.Add(.ItemSeq, .ItemDescr, .ValorDefault, .UEng, .FlagPeso)
            End With
        Next
    End Sub

    Private Sub frmCadBlocos_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        CadBlocos = New clsBlocos(TrataArea.AreaDados("Area"))

        RefreshDados()

    End Sub

    Private Sub gvBlocos_RowStateChanged(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewRowStateChangedEventArgs) Handles gvBlocos.RowStateChanged

        'Trata somente a row selecionada
        If e.Row.Selected = False Then Return

        RefreshPrm(e.Row.Index)

    End Sub

    Private Sub butFechar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles butFechar.Click
        Me.Close()
    End Sub

    Private Sub butBlkApagar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles butBlkApagar.Click

        If gvBlocos.SelectedRows.Count <= 0 Then Return

        Dim BlkNum As Integer = gvBlocos.SelectedRows(0).Cells(0).Value
        Dim Area As String = CadBlocos.Bloco(0).Area
        Dim PosClasse As Integer = gvBlocos.SelectedRows(0).Index

        Dim Ret As MsgBoxResult = MsgBox("Deseja realmente apagar o Bloco [" & BlkNum & "] da área [" & Area.ToUpper & "] ?", _
                                         MsgBoxStyle.Question + MsgBoxStyle.YesNo, "Cadastro de Blocos")

        If Ret = MsgBoxResult.No Then Return

        CadBlocos.BlocoRemove(BlkNum, PosClasse)

        RefreshDados()

    End Sub

    Private Sub butBlkNovo_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles butBlkNovo.Click

        'Pergunta o numero do novo bloco
        Dim Ret As Integer = InputBox("Digite o número do novo bloco.", "Novo Bloco")
        If IsNumeric(Ret) = False And Ret <= 0 Then Return

        Dim PesqExiste = (From It In CadBlocos.blkBanco.Blocos Where It.Area = CadBlocos.AreaGeral And It.BlkNum = Ret).ToList

        If PesqExiste.Count >= 1 Then
            'numero de bloco já existe
            MsgBox("O número de bloco [" & Ret & "] já existe no sistema. Favor digitar outro número!", MsgBoxStyle.Exclamation, "Atenção")
            Return
        End If

        Dim Descr As String = InputBox("Escreva a Descrição deste novo bloco.", "Novo Bloco")

        Dim Mnemo As String = InputBox("Escreva o Mnemonico deste novo bloco.", "Novo Bloco")

        CadBlocos.BlocoInsere(Ret, Descr, Mnemo)

        RefreshDados()

    End Sub

    Private Sub butBlkEditar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles butBlkEditar.Click

        If gvBlocos.SelectedRows.Count <= 0 Then Return

        Dim BlkNum As Integer = gvBlocos.SelectedRows(0).Cells(0).Value
        Dim Pos As Integer = gvBlocos.SelectedRows(0).Index

        Dim Descr As String = CadBlocos.Bloco(Pos).Descr
        Dim Mnemo As String = CadBlocos.Bloco(Pos).Mnemonico



        Dim NewDescr As String = InputBox("Escreva a Nova Descrição do bloco [" & BlkNum & "]", "Edição de Bloco", Descr)

        Dim NewMnemo As String = InputBox("Escreva o Novo Mnemonico do bloco [" & BlkNum & "]", "Edição de Bloco", Mnemo)

        CadBlocos.BlocoRemove(BlkNum, Pos)

        CadBlocos.BlocoInsere(BlkNum, NewDescr, NewMnemo)

        RefreshDados()

    End Sub


    Private Sub butPrmApagar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles butPrmApagar.Click

        If gvParam.SelectedRows.Count <= 0 Then Return

        Dim BlkNum As Integer = gvBlocos.SelectedRows(0).Cells(0).Value
        Dim BlkPos As Integer = gvBlocos.SelectedRows(0).Index

        Dim ItemNum As Integer = gvParam.SelectedRows(0).Cells(0).Value
        Dim ItemPos As Integer = gvParam.SelectedRows(0).Index

        Dim Ret As MsgBoxResult = MsgBox("Deseja realmente apagar o Item [" & ItemNum & "] ?", _
                                         MsgBoxStyle.Question + MsgBoxStyle.YesNo, "Cadastro de Itens")

        If Ret = MsgBoxResult.No Then Return

        CadBlocos.ItemRemove(BlkNum, BlkPos, ItemNum, ItemPos)

        RefreshDados()

    End Sub

    Private Sub butPrmEditar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles butPrmEditar.Click



    End Sub
End Class