Public Class frmCadRotasLim

    Dim dtBlocos As List(Of Geral.nsReceitas.Blocos)

    Sub Abre(ByVal RotaId As Integer, ByVal Descr As String)

        txtRotaId.Text = RotaId
        txtDescr.Text = Descr

        butAdd.Enabled = True
        butEdita.Enabled = False

        Dim DbRc As New Geral.nsReceitas.dcReceitas
        dtBlocos = (From It In DbRc.Blocos Where It.Area = "CIP" Order By It.BlkNum).ToList

        BuscaLimRev(RotaId)

        RefreshDados()
        ShowDialog()

    End Sub

    Function BuscaLimRev(RotaId As Integer) As Boolean

        Dim DbCv As New Geral.nsCipValid.dcCipValid
        Dim dtCadRotasVl = (From It In DbCv.CadRotasVl Where It.RotaId = RotaId).ToList
        If dtCadRotasVl.Count > 0 Then

            'Revisão encontrada
            txtLimRev.Text = dtCadRotasVl.First.LimRevAtual
            txtPrcTempoMax.Text = dtCadRotasVl.First.PrcTempoMax

            BlocosChk()

        Else

            'Esta rota não tem nenhuma revisão ainda
            txtLimRev.Text = 0
            txtPrcTempoMax.Text = 0
 
        End If

        RefreshDados()

        Return True

    End Function

    Function BlocosChk() As Boolean

        'Verifica se todos os blocos de receita de cip constam nessa revisão, caso contário cria o bloco
        Dim DbCv As New Geral.nsCipValid.dcCipValid
        Dim dtCadRotasLim = (From It In DbCv.CadRotasLim Where It.RotaId = txtRotaId.Text And It.LimRev = txtLimRev.Text Order By It.BlkNum).ToList

        For Each Bloco In dtBlocos

            Dim BlkNum As Integer = Bloco.BlkNum
            Dim MyCrl = (From It In dtCadRotasLim Where It.BlkNum = BlkNum).ToList

            If MyCrl.Count > 0 Then Continue For

            'O bloco não existe, criar agora
            Dim NwCrl As New Geral.nsCipValid.CadRotasLim With {.RotaId = txtRotaId.Text, .LimRev = txtLimRev.Text, .BlkNum = BlkNum,
                                                                .TempMax = 999, .TempMin = 0, .CondMax = 999, .CondMin = 0,
                                                                .VazaoMax = 35, .VazaoMin = 3, .TempoAjuste = 10}
            DbCv.CadRotasLim.InsertOnSubmit(NwCrl)

        Next

        DbCv.SubmitChanges()

        Return True

    End Function

    Sub RefreshDados()

        Dim DbCv As New Geral.nsCipValid.dcCipValid
        Dim dtCadRotasLim = (From It In DbCv.CadRotasLim Where It.RotaId = txtRotaId.Text And It.LimRev = txtLimRev.Text Order By It.BlkNum).ToList

        gvItens.Rows.Clear()

        For Each Crl In dtCadRotasLim

            Dim Descr As String = ""
            Dim BlkNum As Integer = Crl.BlkNum
            Dim MyBloco = (From It In dtBlocos Where It.BlkNum = BlkNum).ToList
            If MyBloco.Count > 0 Then Descr = MyBloco.First.BlkDescr

            gvItens.Rows.Add(Crl.BlkNum, Descr, Crl.TempMax, Crl.TempMin, Crl.CondMax, Crl.CondMin, Crl.VazaoMax, Crl.VazaoMin, Crl.TempoAjuste)

        Next

    End Sub

    Private Sub butAdd_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles butAdd.Click

        'Duplicar a revisão atual para edição
        Dim Ret As MsgBoxResult = MsgBox("Será criada uma nova versão de limites para esta rota. Confirma?", MsgBoxStyle.OkCancel)
        If Ret = MsgBoxResult.Cancel Then Return


        Dim DbCv As New Geral.nsCipValid.dcCipValid

        If txtLimRev.Text <= 0 Then

            'Cria a revisão 1
            txtLimRev.Text = 1
            Dim NwCrv As New Geral.nsCipValid.CadRotasVl With {.RotaId = txtRotaId.Text, .LimRevAtual = 1, .PrcTempoMax = 0}
            DbCv.CadRotasVl.InsertOnSubmit(NwCrv)
            DbCv.SubmitChanges()

            BlocosChk()
            RefreshDados()

            butAdd.Enabled = False
            butEdita.Enabled = True

            Return

        End If


        'Duplica a revisão atual
        Dim NwLimRev As Integer = txtLimRev.Text + 1
        Dim dtCadRotasVl = (From It In DbCv.CadRotasVl Where It.RotaId = txtRotaId.Text).ToList
        If dtCadRotasVl.Count <= 0 Then Return

        dtCadRotasVl.First.LimRevAtual = NwLimRev


        Dim dtCadRotasLim = (From It In DbCv.CadRotasLim Where It.RotaId = txtRotaId.Text And It.LimRev = txtLimRev.Text Order By It.BlkNum).ToList

        For Each Crl In dtCadRotasLim

            Dim BlkNum As Integer = Crl.BlkNum
            Dim NwCrl As New Geral.nsCipValid.CadRotasLim With {.RotaId = txtRotaId.Text, .LimRev = NwLimRev, .BlkNum = BlkNum,
                                                                .TempMax = Crl.TempMax, .TempMin = Crl.TempMin, .CondMax = Crl.CondMax, .CondMin = Crl.CondMin,
                                                                .VazaoMax = Crl.VazaoMax, .VazaoMin = Crl.VazaoMin, .TempoAjuste = Crl.TempoAjuste}
            DbCv.CadRotasLim.InsertOnSubmit(NwCrl)

        Next

        DbCv.SubmitChanges()
        txtLimRev.Text = NwLimRev

        butAdd.Enabled = False
        butEdita.Enabled = True

        RefreshDados()

    End Sub

    Private Sub butFecha_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles butFecha.Click
        Close()
    End Sub

    Private Sub txtPrcTempoMax_Click(sender As Object, e As System.EventArgs) Handles txtPrcTempoMax.Click

        'Edita o percentual de tempo máximo
        Dim Ret As String = InputBox("Digite o percentual de tempo máximo", "Tempo Máximo %", txtPrcTempoMax.Text)
        If IsNumeric(Ret) = False Then Return

        Dim DbCv As New Geral.nsCipValid.dcCipValid
        Dim dtCadRotasVl = (From It In DbCv.CadRotasVl Where It.RotaId = txtRotaId.Text And It.LimRevAtual = txtLimRev.Text).ToList
        If dtCadRotasVl.Count <= 0 Then Return

        txtPrcTempoMax.Text = Ret
        dtCadRotasVl.First.PrcTempoMax = txtPrcTempoMax.Text
        DbCv.SubmitChanges()

    End Sub

    Private Sub butEdita_Click(sender As System.Object, e As System.EventArgs) Handles butEdita.Click

        If gvItens.SelectedRows.Count <= 0 Then Return

        Dim BlkNum As Integer = gvItens.SelectedRows(0).Cells(0).Value

        frmCadRotasLimEdit.Abre(txtRotaId.Text, txtLimRev.Text, BlkNum)

        RefreshDados()

    End Sub

    Private Sub gvItens_DoubleClick(sender As System.Object, e As System.EventArgs) Handles gvItens.DoubleClick

        If butEdita.Enabled = False Then Return

        butEdita_Click(sender, e)

    End Sub

End Class