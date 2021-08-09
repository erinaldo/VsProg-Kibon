
Partial Class RelatCipPeriodo
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        If IsPostBack = False Then

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

        End If

        RefreshRelat()

    End Sub

    Sub RefreshRelat()

        Dim DbCr As New nsCipRotas.dcCipRotas
        Dim dtRotaCad = (From It In DbCr.RotaCad).ToList


        Dim DbRc As New nsReceitas.dcReceitas
        Dim dtRec = (From It In DbRc.Rec Where It.Area = "CIP").ToList

        Dim arDataHoraIni() As String = txtDataHoraIni.Text.Split("/"c)
        If arDataHoraIni.Length < 3 Then Return

        Dim arDataHoraFim() As String = txtDataHoraFim.Text.Split("/"c)
        If arDataHoraFim.Length < 3 Then Return

        Session.Add("SelDataIni", txtDataHoraIni.Text)
        Session.Add("SelDataFim", txtDataHoraFim.Text)

        Dim DataIni As Date = New Date(arDataHoraIni(2), arDataHoraIni(1), arDataHoraIni(0), 0, 0, 0)
        Dim DataFim As Date = New Date(arDataHoraFim(2), arDataHoraFim(1), arDataHoraFim(0), 23, 59, 59)

        'Busca dados do CIP
        Dim DbCv As New nsCipValid.dcCipValid
        Dim dtCipHist = (From It In DbCv.CipHist Where It.DataHoraIni >= DataIni And It.DataHoraFim <= DataFim).ToList


        'Carrega o cadastro de operadores
        Dim dtCadUser = (From It In DbCv.CadUser).ToList


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
        dtDados.Columns.Add("OperIni")
        dtDados.Columns.Add("OperFim")
        dtDados.Columns.Add("Sts")
        dtDados.Columns.Add("FlagAtrasado")


        For Conta As Integer = 0 To dtCipHist.Count - 1
            With dtCipHist(Conta)

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

                Dim UserId As Integer = dtCipHist(Conta).UserId
                Dim MyOperIni = (From It In dtCadUser Where It.UserId = UserId).ToList
                Dim OperIni As String = ""
                If MyOperIni.Count > 0 Then
                    OperIni = MyOperIni(0).Nome
                End If

                Dim UserIdValid As Integer = dtCipHist(Conta).UserIdValid
                Dim MyOperValid = (From It In dtCadUser Where It.UserId = UserIdValid).ToList
                Dim OperValid As String = ""
                If MyOperValid.Count > 0 Then
                    OperValid = MyOperValid(0).Nome
                End If

                Dim Sts As Boolean = True
                If dtCipHist(Conta).FlagCancelado = 0 Then Sts = False

                Dim FlagAtrasado As Boolean = True
                If dtCipHist(Conta).FlagAtrasado = 0 Then FlagAtrasado = False


                Dim MyRow As Data.DataRow = dtDados.Rows.Add(dtCipHist(Conta).CipId, .RotaId, RotaDescr, .Circ,
                        .RecNum, RecNome, RecDescr, RecCodigo,
                        Format(dtCipHist(Conta).DataHoraIni, "dd/MM/yyyy HH:mm:ss"),
                        Format(dtCipHist(Conta).DataHoraFim, "dd/MM/yyyy HH:mm:ss"),
                        OperIni, OperValid, Sts, FlagAtrasado)

            End With
        Next

        gvDados.DataSource = dtDados
        gvDados.DataBind()

    End Sub

End Class
