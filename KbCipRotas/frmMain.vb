Public Class frmMain

    Public Login As Integer = 0
    Public Edita As Boolean = False

#Region "Funcoes"

    Public Sub UsrLogin(Optional ByVal UsrId As Integer = 0, Optional ByVal UsrNome As String = "")

        butLogin.Text = "Logout"

        butValvula.Enabled = True
        butMotor.Enabled = True
        butPlaca.Enabled = True
        butTanque.Enabled = True
        butRotasLim.Enabled = True
        butRotaPtoCrit.Enabled = True
        butCadPtoCrit.Enabled = True

        butNovaRota.Enabled = True
        butEditar.Enabled = True
        butUp.Enabled = True
        butDown.Enabled = True
        butExcluir.Enabled = True
        butDuplicar.Enabled = True

        mnuCadValvulas.Enabled = True
        mnuCadMotores.Enabled = True
        mnuCadSensores.Enabled = True
        mnuCadTanques.Enabled = True
        mnuCadFlip.Enabled = True

        Login = 1


    End Sub

    Public Sub UsrLogout()

        butLogin.Text = "Login"

        butValvula.Enabled = False
        butMotor.Enabled = False
        butPlaca.Enabled = False
        butTanque.Enabled = False
        butRotasLim.Enabled = False
        butRotaPtoCrit.Enabled = False
        butCadPtoCrit.Enabled = False

        butNovaRota.Enabled = False
        butEditar.Enabled = False
        butUp.Enabled = False
        butDown.Enabled = False
        butExcluir.Enabled = False
        butDuplicar.Enabled = False

        mnuCadValvulas.Enabled = False
        mnuCadMotores.Enabled = False
        mnuCadSensores.Enabled = False
        mnuCadTanques.Enabled = False
        mnuCadFlip.Enabled = False

        Login = 0

    End Sub

    Private Sub RefreshGrid()

        Dim Banco As New Geral.nsCipRotas.dcCipRotas

        Dim myRotas As System.Linq.IOrderedQueryable(Of Geral.nsCipRotas.RotaCad)

        If cmbCircuito.Text = "" Or cmbCircuito.Text = "*" Then

            myRotas = From It In Banco.RotaCad Where It.RotaId > 1000 Order By It.Sequencia

        Else

            myRotas = From It In Banco.RotaCad Where It.RotaId > 1000 And It.Circ = cmbCircuito.Text Order By It.Sequencia

        End If

        If myRotas.Count <= 0 Then Return

        gvRotas.Rows.Clear()

        Status1.Text = " Total de rotas = " & myRotas.Count

        For Each Reg In myRotas

            With gvRotas
                .Rows.Add(Reg.RotaId, Reg.Descr, Reg.Circ, Reg.Tipo, Reg.Tq1, Reg.Tq2, Reg.Tq3, Reg.Sequencia)
            End With
        Next

    End Sub

    Private Sub RefreshCmbCircuitos()

        Dim Banco As New Geral.nsCipRotas.dcCipRotas

        Dim myCircuitos = (From It In Banco.RotaCad Where It.RotaId > 1000 Select It.Circ Distinct Order By Circ).ToList

        If myCircuitos.Count <= 0 Then

            MsgBox("Nenhum Circuito encontrado no sistema", MsgBoxStyle.Critical)
            Exit Sub

        End If

        cmbCircuito.Items.Clear()

        cmbCircuito.Items.Add("*")
        For Each Circ In myCircuitos

            cmbCircuito.Items.Add(Circ)

        Next

        cmbCircuito.Text = "*"

    End Sub

#End Region

#Region "Form"

    Private Sub frmMain_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        'Verifica se a data das configurações regionais está configurada como d/M/yyyy
        Dim RetDataConf As Boolean = Util.ChkDataConfReg(Me.Text)
        If RetDataConf = False Then End

        Geral.DllInit()

        UsrLogout()
        If Command() <> "" Then
            UsrLogin(1, "Tse")
        End If

        RefreshGrid()

        RefreshCmbCircuitos()

        tmrPula.Enabled = True

        stsVersao.Text = "Ver.:2011.05"

    End Sub

#End Region

#Region "Botoes"

    Private Sub butSair_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles butSair.Click
        Me.Close()
    End Sub

    Private Sub butDown_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles butDown.Click

        If gvRotas.SelectedRows.Count <= 0 Then Return

        Dim Pos As Integer = gvRotas.CurrentRow.Index

        Dim Seq1 As Integer = gvRotas.Rows(Pos).Cells("colSeq").Value

        Dim UltimaLinha As Integer = gvRotas.Rows.Count - 1

        If Seq1 >= UltimaLinha Then Return

        Dim RotaId1 As Integer = gvRotas.Rows(Pos).Cells("colRotaId").Value
        Dim RotaId2 As Integer = gvRotas.Rows(Pos + 1).Cells("colRotaId").Value
        Dim Seq2 As Integer = gvRotas.Rows(Pos + 1).Cells("colSeq").Value

        Dim Banco As New Geral.nsCipRotas.dcCipRotas

        Dim myRota = From It In Banco.RotaCad

        For Each Reg In myRota

            If Reg.RotaId = RotaId1 Then
                Reg.Sequencia = Seq2
            End If

            If Reg.RotaId = RotaId2 Then
                Reg.Sequencia = Seq1
            End If

        Next

        Banco.SubmitChanges()

        RefreshGrid()

    End Sub

    Private Sub butUp_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles butUp.Click

        If gvRotas.SelectedRows.Count <= 0 Then Return

        Dim Pos As Integer = gvRotas.CurrentRow.Index

        Dim Seq1 As Integer = gvRotas.Rows(Pos).Cells("colSeq").Value

        If Seq1 <= 0 Then Return

        Dim RotaId1 As Integer = gvRotas.Rows(Pos).Cells("colRotaId").Value
        Dim RotaId2 As Integer = gvRotas.Rows(Pos - 1).Cells("colRotaId").Value
        Dim Seq2 As Integer = gvRotas.Rows(Pos - 1).Cells("colSeq").Value

        Dim Banco As New Geral.nsCipRotas.dcCipRotas

        Dim myRota = From It In Banco.RotaCad

        For Each Reg In myRota

            If Reg.RotaId = RotaId1 Then
                Reg.Sequencia = Seq2
            End If

            If Reg.RotaId = RotaId2 Then
                Reg.Sequencia = Seq1
            End If

        Next

        Banco.SubmitChanges()

        RefreshGrid()

    End Sub

    Private Sub butValvula_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles butValvula.Click

        mnuCadValvulas_Click(sender, e)

    End Sub

    Private Sub butMotor_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles butMotor.Click

        mnuCadMotores_Click(sender, e)

    End Sub

    Private Sub butTanque_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles butTanque.Click

        mnuCadTanques_Click(sender, e)

    End Sub

    Private Sub butPlaca_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles butPlaca.Click

        mnuCadSensores_Click(sender, e)

    End Sub

    Private Sub butNovaRota_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles butNovaRota.Click

        'cria novo RotaId
        Dim myRotaId As Integer = 1

        Dim Bd As New Geral.nsCipRotas.dcCipRotas

        Dim myMax = (From It In Bd.RotaCad Select It.RotaId).Max

        Try
            myRotaId = myMax + 1
        Catch : End Try

        Edita = False

        frmRotaEdita.Abre(myRotaId, Login, True)

        RefreshGrid()

    End Sub

    Private Sub butEditar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles butEditar.Click

        If gvRotas.SelectedRows.Count <= 0 Then Return

        Dim Pos As Integer = gvRotas.CurrentRow.Index

        Dim RotaId As Integer = gvRotas.Rows(Pos).Cells(0).Value

        Edita = True

        frmRotaEdita.Abre(RotaId, Login)

        RefreshGrid()

    End Sub

    Private Sub butExcluir_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles butExcluir.Click

        Dim Bp As New Geral.nsCipRotas.dcCipRotas

        If gvRotas.SelectedRows.Count <= 0 Then Return

        Dim Pos As Integer = gvRotas.CurrentRow.Index

        Dim myRota As String = gvRotas.Rows(Pos).Cells(0).Value

        Dim Ret As MsgBoxResult = MsgBox("Deseja realmente excluir a Rota [ " & myRota.ToUpper & " ] do Sistema?", _
                                        MsgBoxStyle.Question + MsgBoxStyle.YesNo, "Atenção")

        If Ret = MsgBoxResult.Yes Then

            Dim Bd As New Geral.nsCipRotas.dcCipRotas

            'verifica se realmente existe a rota
            Dim CipCadRotaEdit = (From It In Bd.RotaCad Where It.RotaId = myRota).ToList
            If CipCadRotaEdit.Count <= 0 Then
                MsgBox("Erro! Rota não encontrada: " & myRota.ToUpper)
                Return
            End If

            'apaga registro
            Bd.RotaCad.DeleteAllOnSubmit(CipCadRotaEdit)

            'apaga valvulas da rota
            Dim CipRotaValvEdit = (From It In Bd.RotaValv Where It.RotaId = myRota).ToList
            Bd.RotaValv.DeleteAllOnSubmit(CipRotaValvEdit)

            'apaga motores da rota
            Dim CipRotaMotEdit = (From It In Bd.RotaMot Where It.RotaId = myRota).ToList
            Bd.RotaMot.DeleteAllOnSubmit(CipRotaMotEdit)

            'apaga sensores da rota
            Dim CipRotaPfEdit = (From It In Bd.RotaPf Where It.RotaId = myRota).ToList
            Bd.RotaPf.DeleteAllOnSubmit(CipRotaPfEdit)

            'apaga dependencias da rota
            Dim CipRotaDepEdit = (From It In Bd.RotaDepend Where It.RotaId = myRota).ToList
            Bd.RotaDepend.DeleteAllOnSubmit(CipRotaDepEdit)

            Bd.SubmitChanges()

            RefreshGrid()

        End If


    End Sub

    Private Sub butDuplicar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles butDuplicar.Click

        If gvRotas.SelectedRows.Count <= 0 Then Return

        Dim Bd As New Geral.nsCipRotas.dcCipRotas

        'Busca novo Id para rota duplicada
        Dim myRotaIdNew As Integer = 1

        'Dim myMax = (From It In Bd.RotaCad Select It.RotaId).Max

        'Try
        '    myRotaIdNew = myMax + 1
        'Catch : End Try
        Try
            myRotaIdNew = InputBox("Informe o número da rota.:", "Rota de Cip")
        Catch ex As Exception
            MessageBox.Show("Informe um  número de rota válido.", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1)
            Return
        End Try


        If myRotaIdNew = 0 Then
            MessageBox.Show("Informe um  número de rota válido.", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1)
            Return
        End If

        'Busca Id da rota a ser copiada
        Dim Pos As Integer = gvRotas.CurrentRow.Index

        Dim myRota As Integer = gvRotas.Rows(Pos).Cells(0).Value

        'Copia rota
        Dim myReg = From It In Bd.RotaCad Where It.RotaId = myRota

        Dim myRegNovo As New Geral.nsCipRotas.RotaCad

        For Each Reg In myReg
            myRegNovo = New Geral.nsCipRotas.RotaCad

            myRegNovo.RotaId = myRotaIdNew
            myRegNovo.Circ = Reg.Circ
            myRegNovo.Tipo = Reg.Tipo
            myRegNovo.Descr = Reg.Descr
            myRegNovo.Tq1 = Reg.Tq1
            myRegNovo.Tq2 = Reg.Tq2
            myRegNovo.Tq3 = Reg.Tq3
            myRegNovo.BbaCipFw = Reg.BbaCipFw

        Next

        Bd.RotaCad.InsertOnSubmit(myRegNovo)

        Bd.SubmitChanges()

        'Copia valvulas
        Dim myValv = From It In Bd.RotaValv Where It.RotaId = myRota

        If myValv.Count >= 1 Then
            For Each Valv In myValv
                Dim myValvNovo = New Geral.nsCipRotas.RotaValv
                myValvNovo.RotaId = myRotaIdNew
                myValvNovo.Tag = Valv.Tag
                myValvNovo.Tipo = Valv.Tipo
                Bd.RotaValv.InsertOnSubmit(myValvNovo)
            Next
        End If

        'Copia motores
        Dim myMot = From It In Bd.RotaMot Where It.RotaId = myRota

        If myMot.Count >= 1 Then
            For Each Mot In myMot
                Dim myMotNovo As New Geral.nsCipRotas.RotaMot
                myMotNovo.RotaId = myRotaIdNew
                myMotNovo.Tag = Mot.Tag
                myMotNovo.Tipo = Mot.Tipo
                Bd.RotaMot.InsertOnSubmit(myMotNovo)
            Next
        End If

        'Copia sensores
        Dim myPf = From It In Bd.RotaPf Where It.RotaId = myRota

        If myPf.Count >= 1 Then
            For Each Pf In myPf
                Dim myPfNovo As New Geral.nsCipRotas.RotaPf
                myPfNovo.RotaId = myRotaIdNew
                myPfNovo.Tag = Pf.Tag
                myPfNovo.Tipo = Pf.Tipo
                Bd.RotaPf.InsertOnSubmit(myPfNovo)
            Next
        End If

        'Copia dependencia
        Dim myDep = From It In Bd.RotaDepend Where It.RotaId = myRota

        If myDep.Count >= 1 Then
            For Each Dep In myDep
                Dim myDepNovo As New Geral.nsCipRotas.RotaDepend
                myDepNovo.RotaId = myRotaIdNew
                myDepNovo.Tag = Dep.Tag
                myDepNovo.Tipo = Dep.Tipo
                Bd.RotaDepend.InsertOnSubmit(myDepNovo)
            Next
        End If

        Bd.SubmitChanges()

        RefreshGrid()

    End Sub

    Private Sub butRelatorio_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles butRelatorio.Click
        '
    End Sub

    Private Sub butLogin_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles butLogin.Click

        If butLogin.Text = "Logout" Then
            UsrLogout()
            Login = 0
            Return
        End If

        'Login
        Dim MyForm As New Geral.frmLogin
        MyForm.ShowDialog()
        If MyForm.SelUsrId = 0 Then Exit Sub

        UsrLogin(MyForm.SelUsrId, MyForm.SelUsrNome)

        Login = 1

    End Sub


#End Region

#Region "Menus"

    Private Sub mnuCadValvulas_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuCadValvulas.Click
        frmCadValv.ShowDialog()
    End Sub

    Private Sub mnuCadMotores_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuCadMotores.Click
        frmCadMotor.ShowDialog()
    End Sub

    Private Sub mnuCadSensores_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuCadSensores.Click
        frmCadPf.ShowDialog()
    End Sub

    Private Sub mnuCadTanques_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuCadTanques.Click
        frmCadTq.ShowDialog()
    End Sub

    Private Sub mnuCadFlip_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuCadFlip.Click
        frmCadFlip.Abre()
    End Sub
#End Region

#Region "Timer"

    Private Sub tmrPula_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tmrPula.Tick

        tmrPula.Enabled = False

        Me.WindowState = FormWindowState.Minimized
        Me.WindowState = FormWindowState.Normal

    End Sub

#End Region

    Private Sub GerarRelatórioToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles GerarRelatórioToolStripMenuItem.Click
        butRelatorio_Click(sender, e)
    End Sub

    Private Sub cmbCircuito_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmbCircuito.SelectedIndexChanged
        RefreshGrid()
    End Sub

    Private Sub gvRotas_MouseDoubleClick(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles gvRotas.MouseDoubleClick
        butEditar_Click(sender, e)
    End Sub

    Private Sub butRotasLim_Click(sender As System.Object, e As System.EventArgs) Handles butRotasLim.Click

        If gvRotas.SelectedRows.Count <= 0 Then Return
        Dim RotaId As Integer = gvRotas.SelectedRows(0).Cells(0).Value
        Dim RotaDescr As String = gvRotas.SelectedRows(0).Cells(1).Value

        frmCadRotasLim.Abre(RotaId, RotaDescr)

    End Sub

    Private Sub butRotaPtoCrit_Click(sender As System.Object, e As System.EventArgs) Handles butRotaPtoCrit.Click

        If gvRotas.SelectedRows.Count <= 0 Then Return
        Dim RotaId As Integer = gvRotas.SelectedRows(0).Cells(0).Value
        Dim RotaDescr As String = gvRotas.SelectedRows(0).Cells(1).Value

        frmCadRotasPtoCr.Abre(RotaId, RotaDescr)

    End Sub

    Private Sub butCadPtoCrit_Click(sender As System.Object, e As System.EventArgs) Handles butCadPtoCrit.Click

        frmCadPtoCr.Abre()

    End Sub

End Class
