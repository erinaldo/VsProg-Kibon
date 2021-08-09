Public Class frmCipCmd

    Dim dtRotaCad As New List(Of Geral.nsCipRotas.RotaCad)
    Dim dtRec As New List(Of Geral.nsReceitas.Rec)

    Dim Planej As KbCipPlanejCtrl.clsIPlanej

    Sub RefreshDados()

        Dim PlanejD As KbCipPlanejCtrl.clsPlanejD = Nothing

        Try
            PlanejD = Planej.BuscaDados
        Catch ex As Exception
            Return
        End Try
        If PlanejD Is Nothing Then Return


        Dim RowTop As Integer = gvItens.FirstDisplayedScrollingRowIndex
        Dim RowSel As Integer = -1
        Dim CircNumSel As Integer = 0
        If gvItens.SelectedRows.Count > 0 Then CircNumSel = gvItens.SelectedRows(0).Cells(0).Value


        gvItens.Rows.Clear()
        For Conta As Integer = 0 To PlanejD.Dados.Count - 1
            With PlanejD.Dados(Conta)

                Dim myCircTxt As String = Geral.CircTxt(.CircNum)

                Dim RotaId As Integer = 0
                Dim RotaDescr As String = ""
                If .Sts > 0 Then
                    RotaId = .RotaId
                    Dim MyRota = (From It In dtRotaCad Where It.RotaId = .RotaId).ToList
                    If MyRota.Count > 0 Then
                        RotaDescr = MyRota(0).Descr
                    End If
                End If

                Dim RecNum As Integer = 0
                Dim RecNome As String = "", RecDescr As String = "", RecCodigo As String = ""
                If .Sts > 0 Then
                    RecNum = .RecNum
                    Dim MyRec = (From It In dtRec Where It.RecNum = .RecNum).ToList
                    If MyRec.Count > 0 Then
                        RecNome = MyRec(0).RecNome
                        RecDescr = MyRec(0).RecDescr
                        RecCodigo = MyRec(0).Codigo
                    End If
                End If

                Dim bmpEx As Image = imExec.Images(0)
                If .Exec = True Then bmpEx = imExec.Images(1)

                gvItens.Rows.Add(.CircNum, RotaId, RotaDescr, myCircTxt, RecNum, RecNome, RecDescr, RecCodigo, bmpEx)

                'Procura a linha selecionada
                If .CircNum = CircNumSel Then RowSel = Conta

            End With
        Next

        Try
            If RowSel >= 0 Then
                'Vai para a linha selecionada
                gvItens.FirstDisplayedScrollingRowIndex = RowTop
                gvItens.CurrentCell = gvItens.Rows(RowSel).Cells(1)
            Else
                'Nenhuma linha selecionada vai para o fim
                gvItens.FirstDisplayedScrollingRowIndex = gvItens.Rows.Count - 1
                gvItens.CurrentCell = gvItens.Rows(gvItens.Rows.Count - 1).Cells(1)
            End If
        Catch : End Try

    End Sub

    Private Sub frmCipCmd_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        'Le os dados da tabela
        Dim DbCr As New Geral.nsCipRotas.dcCipRotas
        dtRotaCad = (From It In DbCr.RotaCad Order By It.Sequencia).ToList

        Dim DbRc As New Geral.nsReceitas.dcReceitas
        dtRec = (From It In DbRc.Rec Order By It.RecNum).ToList


        'Comunicação com o serviço servidor
        Dim Caminho As String = Util.UtAppPath
        Dim Cfg As New Util.clsTrataCfg(Caminho & "\..\Bin\cfgGeral.xml")
        Dim ServerIp As String = Cfg.colCfg("ServerIp")

        Dim RpEndPoint As String = "http://" & ServerIp & ":8080/CipPlanejCtrl"
        Planej = New ChannelFactory(Of KbCipPlanejCtrl.clsIPlanej)(New BasicHttpBinding(), New EndpointAddress(RpEndPoint)).CreateChannel()

        WindowState = FormWindowState.Maximized
        tmrPoll.Enabled = True

    End Sub

    Private Sub frmCipCmd_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        Planej = Nothing
    End Sub

    Private Sub tmrPoll_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tmrPoll.Tick

        RefreshDados()

    End Sub

    Private Sub butStart_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles butStart.Click

        If gvItens.SelectedRows.Count <= 0 Then Return

        Dim CircNum As Integer = gvItens.SelectedRows(0).Cells(0).Value

        Try
            Planej.CmdStart(CircNum)
        Catch : End Try

    End Sub

    Private Sub butStop_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles butStop.Click

        If gvItens.SelectedRows.Count <= 0 Then Return

        Dim CircNum As Integer = gvItens.SelectedRows(0).Cells(0).Value

        Try
            Planej.CmdStop(CircNum)
        Catch : End Try

    End Sub

End Class