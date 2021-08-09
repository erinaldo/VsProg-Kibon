
Public Class frmCadCfg

    Public Bp As New Geral.nsCipValid.dcCipValid
    Public dtCadCfg As New List(Of Geral.nsCipValid.CadCfg)
    Public FlagDadosEdit As Boolean = False

  
    Sub RefreshDados()

        gvCadCfg.Rows.Clear()

        btnNovo.CheckOnClick = False

        For Conta As Integer = 0 To dtCadCfg.Count - 1

            With dtCadCfg(Conta)

                gvCadCfg.Rows.Add(.Cfg, .Valor)

            End With
        Next

    End Sub

    Private Sub frmCadCfg_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        'carrega dados
        dtCadCfg = (From It In Bp.CadCfg).ToList

        WindowState = FormWindowState.Maximized

        RefreshDados()

    End Sub

    Private Sub frmCadCfg_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        If FlagDadosEdit = True Then

            Dim Ret As MsgBoxResult = MsgBox("ATENÇÃO! Os dados editados serão perdidos. Deseja salvar os dados editados?", MsgBoxStyle.YesNoCancel)

            'Cancelar, continua editando os dados
            If Ret = MsgBoxResult.Cancel Then
                e.Cancel = True
                Return
            End If

            'Não salvar, prosseguir perdendo os dados editados
            If Ret = MsgBoxResult.No Then Return

            'Salva os dados
            btnSalva_Click(sender, e)

        End If
    End Sub

    Private Sub btnSalva_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSalva.Click

        'Salva todas as mudanças feitas na tabela
        Bp.SubmitChanges()
        FlagDadosEdit = False

    End Sub

    Private Sub btnNovo_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnNovo.Click

        btnNovo.CheckOnClick = True
        frmCadCfgEdit.Abre()
        If frmCadCfgEdit.SelCfg = "" Then Return

        Dim Cfg As String = frmCadCfgEdit.SelCfg
        Dim Valor As String = frmCadCfgEdit.SelValor

        'cria novo data table para receber o novo registro inserido
        Dim CadCfgNew As New List(Of Geral.nsCipValid.CadCfg)
        CadCfgNew.Add(New Geral.nsCipValid.CadCfg With {.Cfg = Cfg, .Valor = Valor})

        'insere o novo registro na tabela
        Bp.CadCfg.InsertAllOnSubmit(CadCfgNew)

        'adiciona o novo registo ao data table de escopo geral, para visualizar o novo registro no refresh dados
        dtCadCfg = dtCadCfg.Union(CadCfgNew).ToList

        RefreshDados()
        FlagDadosEdit = True

    End Sub

    Private Sub btnEdita_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnEdita.Click

        btnNovo.CheckOnClick = False

        If gvCadCfg.SelectedRows.Count <= 0 Then Return

        Dim Cfg As String = gvCadCfg.SelectedRows(0).Cells(0).Value
        Dim Valor As String = gvCadCfg.SelectedRows(0).Cells(1).Value

        frmCadCfgEdit.Abre(Cfg, Valor)

        If frmCadCfgEdit.SelCfg = "" Then Return
        If frmCadCfgEdit.SelValor = "" Then Return

        'verifica se a identificação a ser editada realmente existe
        Dim CadCfgEdit = (From It In dtCadCfg Where It.Cfg = Cfg).ToList
        If CadCfgEdit.Count <= 0 Then
            MsgBox("Erro: falha salvando dados (" & frmCadCfgEdit.SelCfg & ")")
            Return
        End If

        CadCfgEdit(0).Valor = frmCadCfgEdit.SelValor

        RefreshDados()
        FlagDadosEdit = True

    End Sub

    Private Sub gvCadCfg_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles gvCadCfg.DoubleClick
        btnEdita_Click(sender, e)
    End Sub

    Private Sub btnDeleta_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnDeleta.Click

        If gvCadCfg.SelectedRows.Count <= 0 Then Return
        Dim Cfg As String = gvCadCfg.SelectedRows(0).Cells(0).Value
        Dim Valor As String = gvCadCfg.SelectedRows(0).Cells(1).Value

        Dim Ret As MsgBoxResult = MsgBox("O item selecionado [" & Cfg & "] será excluido. Confirma?", MsgBoxStyle.OkCancel)
        If Ret = MsgBoxResult.Cancel Then Return

        'Apaga este cadastro
        Dim MyCfgRows = (From It In dtCadCfg Where It.Cfg = Cfg).ToList
        If MyCfgRows.Count < 0 Then Return

        Bp.CadCfg.DeleteAllOnSubmit(MyCfgRows)

        'remove o registro deletado do data table de escopo geral
        dtCadCfg.Remove(MyCfgRows(0))

        RefreshDados()
        FlagDadosEdit = True

    End Sub

    Private Sub btnSair_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSair.Click
        Close()
    End Sub


End Class