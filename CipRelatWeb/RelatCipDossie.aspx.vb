
Partial Class RelatCipDossie
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        If IsPostBack = False Then

            'Dim DataIni As Date = DateAdd(DateInterval.Day, -10, Now)
            If Session("SelDataIni") <> "" Then
                txtDataHoraIni.Text = Session("SelDataIni")
            Else
                txtDataHoraIni.Text = Format(Now, "dd/MM/yyyy")
            End If

            If Session("SelDataFim") <> "" Then
                txtDataHoraFim.Text = Session("SelDataFim")
            Else
                txtDataHoraFim.Text = Format(Now, "dd/MM/yyyy")
            End If

            If Session("SelCirc") <> "" Then
                ddlCirc.Text = Session("SelCirc")
            Else
                ddlCirc.Text = "Todos"
            End If

        End If

        RefreshDados()

    End Sub

    Sub RefreshDados()

        Dim DbCr As New nsCipRotas.dcCipRotas
        Dim dtRotaCad = (From It In DbCr.RotaCad Order By It.Sequencia).ToList

        Dim DbRc As New nsReceitas.dcReceitas
        Dim dtRec = (From It In DbRc.Rec Where It.Area = "CIP").ToList

        Dim arDataHoraIni() As String = txtDataHoraIni.Text.Split("/"c)
        If arDataHoraIni.Length < 3 Then Return

        Dim arDataHoraFim() As String = txtDataHoraFim.Text.Split("/"c)
        If arDataHoraFim.Length < 3 Then Return

        Session.Add("SelDataIni", txtDataHoraIni.Text)
        Session.Add("SelDataFim", txtDataHoraFim.Text)
        Session.Add("SelCirc", ddlCirc.Text)

        Dim DataIni As Date = New Date(arDataHoraIni(2), arDataHoraIni(1), arDataHoraIni(0), 0, 0, 0)
        Dim DataFim As Date = New Date(arDataHoraFim(2), arDataHoraFim(1), arDataHoraFim(0), 23, 59, 59)

        'Busca dados do CIP
        Dim DbCv As New nsCipValid.dcCipValid
        Dim dtCipHist = (From It In DbCv.CipHist Where It.DataHoraIni >= DataIni And It.DataHoraFim <= DataFim).ToList


        'Monta o grid de dados
        Dim dtDados As New Data.DataTable
        dtDados.Columns.Add("CipId")
        dtDados.Columns.Add("RotaId")
        dtDados.Columns.Add("RotaDescr")
        dtDados.Columns.Add("Circ")
        dtDados.Columns.Add("RecNum")
        dtDados.Columns.Add("RecNome")
        dtDados.Columns.Add("RecDescr")
        dtDados.Columns.Add("RecCodigo")
        dtDados.Columns.Add("DataHoraIni")
        dtDados.Columns.Add("DataHoraFim")
        dtDados.Columns.Add("Sts")


        For Conta As Integer = 0 To dtCipHist.Count - 1
            With dtCipHist(Conta)

                If ddlCirc.Text <> "Todos" Then
                    If .Circ <> ddlCirc.Text Then Continue For
                End If

                Dim RotaDescr As String = ""
                Dim MyRota = (From It In dtRotaCad Where It.RotaId = .RotaId).ToList
                If MyRota.Count > 0 Then
                    RotaDescr = MyRota(0).Descr
                End If

                Dim RecNome As String = "", RecDescr As String = "", RecCodigo As String = ""
                Dim MyRec = (From It In dtRec Where It.RecNum = .RecNum).ToList
                If MyRec.Count > 0 Then
                    RecNome = MyRec(0).RecNome
                    RecDescr = MyRec(0).RecDescr
                    RecCodigo = MyRec(0).Codigo
                End If

                Dim Sts As String = "Ok"
                If .FlagCancelado = 1 Then Sts = "Canc"

                Dim MyRow As Data.DataRow = dtDados.Rows.Add(.CipId, .RotaId, RotaDescr, .Circ,
                        .RecNum, RecNome, RecDescr, RecCodigo,
                        Format(.DataHoraIni, "dd/MM/yyyy HH:mm:ss"), Format(.DataHoraFim, "dd/MM/yyyy HH:mm:ss"), Sts)

            End With
        Next

        gvDados.DataSource = dtDados
        gvDados.DataBind()

    End Sub

    Sub gvDados_RowCommand(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewCommandEventArgs) Handles gvDados.RowCommand

        Dim Idx As Integer = e.CommandArgument
        Dim MyRow As GridViewRow = gvDados.Rows(Idx)

        Session.Add("SelRotaId", MyRow.Cells(0).Text)

        If e.CommandName = "Html" Then
            Try
                Server.Transfer("RelatCipDossieDados.aspx", False)
            Catch : End Try

        Else
            'Try
            'Gerar o relatorio 
            Dim Rdx As New clsRelatDossieXlsx(MyRow.Cells(0).Text)
            Dim Ret As Boolean = Rdx.GeraRelat()
            If Ret = False Then Return

            Response.Redirect("/CipRelatWeb" & Rdx.ArqDest)
            'Catch : End Try
        End If

    End Sub

End Class
