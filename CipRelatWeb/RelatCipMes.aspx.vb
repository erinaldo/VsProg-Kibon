
Partial Class RelatCipMes
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        If IsPostBack = False Then

            txtDataHoraIni.Text = Format(Now, "MM/yyyy")
 
        End If

        RefreshRelat()

    End Sub

    Sub RefreshRelat()

        Dim DbCr As New nsCipRotas.dcCipRotas
        Dim dtRotaCad = (From It In DbCr.RotaCad).ToList

        'Monta data de inicio e fim
        Dim arDataHoraIni() As String = txtDataHoraIni.Text.Split("/"c)
        If arDataHoraIni.Length < 2 Then Return

        Dim DataIni As Date = New Date(arDataHoraIni(1), arDataHoraIni(0), 1, 0, 0, 0)
        Dim MesUltimoDia As Integer = Date.DaysInMonth(arDataHoraIni(1), arDataHoraIni(0))
        Dim DataFim As Date = New Date(arDataHoraIni(1), arDataHoraIni(0), MesUltimoDia, 23, 59, 59)


        'Busca dados do CIP
        Dim DbCv As New nsCipValid.dcCipValid
        Dim dtCipHist = (From It In DbCv.CipHist Where It.DataHoraIni >= DataIni And It.DataHoraFim <= DataFim).ToList

        'Monta o grid de dados
        Dim dtDados As New Data.DataTable
        dtDados.Columns.Add("RotaId")
        dtDados.Columns.Add("RotaDescr")
        dtDados.Columns.Add("Circ")
        For Conta As Integer = 1 To 31
            dtDados.Columns.Add("D" & Strings.Right("00" & Conta, 2))
        Next
        dtDados.Columns.Add("Grupo")


        'Cria um Row para cada CIP 
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

                Dim Dia As Integer = Format(.DataHoraIni, "dd")
                InsereCip(dtDados, .RotaId, RotaDescr, .Circ, Dia)

            End With
        Next


        gvDados.DataSource = dtDados
        gvDados.DataBind()

    End Sub

    Sub InsereCip(ByRef dtDados As Data.DataTable, ByVal RotaId As Integer, ByVal RotaDescr As String, ByVal Circ As String, ByVal Dia As Integer)

        'Verifica se este item ja esta na lista e soma um, caso contrario insere na lista
        For Conta As Integer = 0 To dtDados.Rows.Count - 1

            If dtDados.Rows(Conta).Item(0) = RotaId Then

                'Este item já existe, soma um no contador deste dia
                dtDados.Rows(Conta).Item(Dia) = dtDados.Rows(Conta).Item(Dia) + 1
                Return

            End If

        Next


        'Este Cip ainda não está na lista, insere agora
        Dim MyRow As Data.DataRow = dtDados.Rows.Add()

        MyRow(0) = RotaId
        MyRow(1) = RotaDescr
        MyRow(2) = Circ

        For Conta As Integer = 1 To 31
            MyRow(Conta + 2) = 0
        Next
        MyRow(Dia) = 1

    End Sub

End Class
