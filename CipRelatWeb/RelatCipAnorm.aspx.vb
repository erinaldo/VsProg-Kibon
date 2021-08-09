
Partial Class RelatCipAnorm
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

        'Data inicial e final
        Dim arDataHoraIni() As String = txtDataHoraIni.Text.Split("/"c)
        If arDataHoraIni.Length < 3 Then Return

        Dim arDataHoraFim() As String = txtDataHoraFim.Text.Split("/"c)
        If arDataHoraFim.Length < 3 Then Return

        Session.Add("SelDataIni", txtDataHoraIni.Text)
        Session.Add("SelDataFim", txtDataHoraFim.Text)
        Session.Add("SelCirc", ddlCirc.Text)

        Dim DataIni As Date = New Date(arDataHoraIni(2), arDataHoraIni(1), arDataHoraIni(0), 0, 0, 0)
        Dim DataFim As Date = New Date(arDataHoraFim(2), arDataHoraFim(1), arDataHoraFim(0), 23, 59, 59)


        'Busca os CIPs 
        Dim DbCv As New nsCipValid.dcCipValid
        Dim dtCipHist = (From It In DbCv.CipHist Where It.DataHoraIni >= DataIni And It.DataHoraFim <= DataFim).ToList

        Dim dtCipHistAnorm = (From It In DbCv.CipHistAnorm Where It.DataHora >= DataIni And It.DataHora <= DataFim).ToList

        'Busca as anormalidades de cada um dos CIPs
        For Conta As Integer = 0 To dtCipHistAnorm.Count - 1
            With dtCipHistAnorm(Conta)

                If ddlCirc.Text <> "Todos" Then

                    Dim MyCh = (From It In dtCipHist Where It.CipId = .CipId).ToList
                    If MyCh.Count <= 0 Then Continue For

                    If MyCh.First.Circ <> ddlCirc.Text Then Continue For

                End If

                Dim dtAnormTmp = (From It In DbCv.CipHistAnorm Where It.CipId = .CipId).ToList

                'dtAnormTmp.Merge(dtCipHistAnorm)
                dtCipHistAnorm.AddRange(dtAnormTmp)

            End With
        Next

        'Monta o grid
        MontaAnormalidades(dtCipHistAnorm)

    End Sub

    Sub MontaAnormalidades(ByRef dtCipHistAnorm As List(Of nsCipValid.CipHistAnorm))

        'Dados do grid
        Dim MyDados As New Data.DataTable("Dados")
        MyDados.Columns.Add("DataHora")
        MyDados.Columns.Add("Mensagem")
        MyDados.Columns.Add("Obs")
        MyDados.Columns.Add("BlkNum")


        For Conta As Integer = 0 To dtCipHistAnorm.Count - 1
            With dtCipHistAnorm(Conta)

                MyDados.Rows.Add(Format(.DataHora, "dd/MM/yyyy HH:mm:ss"), BuscaAnormEvento(.AnormEquip, .AnormEvnt), .Obs, .BlkNum)

            End With
        Next

        'Envia dados ao grid
        gvAnorm.DataSource = MyDados
        gvAnorm.DataBind()

    End Sub

End Class
