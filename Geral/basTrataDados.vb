Public Module basTrataDados

    Public FlagHabSrvChk As Boolean = True

    Public Sub DllInit()

        'Carrega string de conexao do banco de dados a partir do arquivo de configuração
        Dim Caminho As String = Util.UtAppPath
        Dim Cfg As New Util.clsTrataCfg(Caminho & "\..\Bin\cfgGeral.xml")

        My.Settings.Item("csCipGrava") = Cfg.colCfg("csCipGrava")
        My.Settings.Item("csCipPlanej") = Cfg.colCfg("csCipPlanej")
        My.Settings.Item("csCipRotas") = Cfg.colCfg("csCipRotas")
        My.Settings.Item("csCipValid") = Cfg.colCfg("csCipValid")
        My.Settings.Item("csMatGrava") = Cfg.colCfg("csMatGrava")
        My.Settings.Item("csMistGrava") = Cfg.colCfg("csMistGrava")
        My.Settings.Item("csPastGrava") = Cfg.colCfg("csPastGrava")
        My.Settings.Item("csRanges") = Cfg.colCfg("csRanges")
        My.Settings.Item("csReceitas") = Cfg.colCfg("csReceitas")
        My.Settings.Item("csToledo") = Cfg.colCfg("csToledo")

    End Sub

    Function BuscaUserLogin(ByVal UserId As Integer) As String

        Dim DbCv As New nsCipValid.dcCipValid
        Dim dtCadUser = (From It In DbCv.CadUser Where It.UserId = UserId).ToList

        If dtCadUser.Count <= 0 Then Return ""

        'Ok
        Return dtCadUser(0).Login

    End Function

    Function ChkUserSeg(ByVal UserId As Integer, ByVal SegNome As String) As Boolean

        'Busca a identificacao da area de seguranca
        Dim DbCv As New nsCipValid.dcCipValid
        Dim dtCadUserSeg = (From It In DbCv.CadUserSeg Where It.Nome = SegNome).ToList

        If dtCadUserSeg.Count <= 0 Then Return False
        Dim SegId As Integer = dtCadUserSeg(0).SegId

        'Verifica se o usuario tem acesso a esta area
        Dim dtCadUserHab = (From It In DbCv.CadUserHab Where It.UserId = UserId And It.SegId = SegId).ToList
        If dtCadUserHab.Count <= 0 Then Return False

        'Ok
        Return True

    End Function

    Function BuscaAnormEvento(ByVal AnormEquip As Integer, ByVal AnormEvnt As Integer) As String

        Dim Evento As String = ""

        If AnormEquip = 1 Then
            Evento = "Temperatura "
        ElseIf AnormEquip = 2 Then
            Evento = "Concentração "
        ElseIf AnormEquip = 3 Then
            Evento = "Vazão "
        ElseIf AnormEquip = 4 Then
            Evento = "CIP atrasado"
        ElseIf AnormEquip = 5 Then
            Evento = "CIP cancelado"
        ElseIf AnormEquip = 6 Then
            Evento = "CIP em pausa"
        ElseIf AnormEquip = 7 Then
            Evento = "Demorou a finalizar"
        Else
            Evento = "??? "
        End If

        If AnormEquip >= 1 And AnormEquip <= 3 Then
            If AnormEvnt = 1 Then
                Evento = Evento & "Alta"
            Else
                Evento = Evento & "Baixa"
            End If
        End If

        Return Evento

    End Function

    Function BuscaAnormObsSts(ByVal ObsSts As Integer) As String

        Dim Sts As String
        If ObsSts = 0 Then
            Sts = "Pend"
        Else
            Sts = "Ok"
        End If

        Return Sts

    End Function

    Function BuscaPtoCriticoResp(ByVal Resp As Integer) As String

        Dim Txt As String = ""

        If Resp = 0 Then
            Txt = "Pend"
        ElseIf Resp = 1 Then
            Txt = "Sim"
        Else
            Txt = "Não"
        End If

        Return Txt

    End Function

    Function BuscaProgIdNew() As Integer

        Dim ProgIdNew As Integer = 1

        Dim DbCv As New nsCipValid.dcCipValid
        Dim dtCipSchedProgMax = (From It In DbCv.CipSchedProg Order By It.ProgId Descending).Take(1).ToList

        Try
            ProgIdNew = dtCipSchedProgMax.First.ProgId + 1
        Catch : End Try

        Return ProgIdNew

    End Function

    Function BuscaCipIdNew() As Integer

        Dim CipIdNew As Integer = 1

        Dim DbCv As New nsCipValid.dcCipValid
        Dim dtCipHistMax = (From It In DbCv.CipHist Order By It.CipId Descending).Take(1).ToList

        Try
            CipIdNew = dtCipHistMax.First.CipId + 1
        Catch : End Try

        Return CipIdNew

    End Function

    Function BuscaAnormIdNew(ByVal CipId As Integer) As Integer

        'Busca novo AnormId
        Dim DbCv As New nsCipValid.dcCipValid
        Dim dtCipHistAnormMax = (From It In DbCv.CipHistAnorm Order By It.AnormId Descending).Take(1).ToList

        Dim AnormIdNovo As Integer = 1
        Try
            AnormIdNovo = dtCipHistAnormMax.First.AnormId + 1
        Catch : End Try

        Return AnormIdNovo

    End Function

    Function BuscaAnormIdNew() As Integer

        'Busca novo AnormId
        Dim DbCv As New nsCipValid.dcCipValid
        Dim dtCadPtoCr = (From It In DbCv.CadPtoCr Order By It.PtoCrId Descending).Take(1).ToList

        Dim PtoCrIdNovo As Integer = 1
        Try
            PtoCrIdNovo = dtCadPtoCr.First.PtoCrId + 1
        Catch : End Try

        Return PtoCrIdNovo

    End Function

    Function TseNow() As Date

        'Data e hora sem milisegundos
        Dim Dh As Date = New Date(Now.Year, Now.Month, Now.Day, Now.Hour, Now.Minute, Now.Second)
        Return Dh

    End Function

    Function ChkSchedPer() As Boolean

        'Verifica a programação periódica de CIPs
        Dim DbCv As New nsCipValid.dcCipValid
        Dim dtCipSchedPer = (From It In DbCv.CipSchedPer).ToList


        'Loop para cada CIP periódico
        For Conta As Integer = 0 To dtCipSchedPer.Count - 1

            With dtCipSchedPer(Conta)

                'Verifica se a data programada é até hoje no fim do dia
                Dim DhHoje24H As New Date(Now.Year, Now.Month, Now.Day, 23, 59, 59)
                If .DataHoraIni > DhHoje24H Then Continue For

                If .PerNHoras > 0 Then

                    'Reperição por n horas
                    ChkSchedPerNHoras(.PerId, .RotaId, .RecNum, .PerNHoras, .DataHoraIni)

                Else

                    'Repetição em dias definidos
                    ChkSchedPerMesSem(.PerId, .RotaId, .RecNum, .PerNHoras, .DataHoraIni)

                End If

            End With
        Next


        Return True

    End Function

    Function ChkSchedPerNHoras(ByVal PerId As Integer, ByVal RotaId As Integer, ByVal RecNum As Integer,
                             ByVal PerNHoras As Integer, ByVal DataHoraIni As Date) As Boolean

        Dim DbCv As New nsCipValid.dcCipValid

        'Programa a execução deste CIP para hoje e adianta a data da próxima verificação
        DbCv.CipSchedProg.InsertOnSubmit(New nsCipValid.CipSchedProg With {.ProgId = BuscaProgIdNew(), .DataHora = DataHoraIni,
                                                                .RotaId = RotaId, .Circ = BuscaCipCirc(RotaId),
                                                                .RecNum = RecNum, .Sts = 0, .UserId = 0})

        Dim DhProx As Date = DateAdd(DateInterval.Hour, PerNHoras, DataHoraIni)

        'Caso a próxima data ainda caia no dia de hoje, porque a programação é antiga, adia o CIP para amanhã no mesmo horário
        '   para evitar que ele se repita continuamente até atingir uma data poterior a hoje
        '   Isto só acontecerá se o banco de dados for restaurado com datas antigas, pois a execução diária 
        '   deste programa evitaria o problema
        Dim DhHoje24H As New Date(Now.Year, Now.Month, Now.Day, 23, 59, 59)
        If DhProx < DhHoje24H Then
            Dim DhAmanha As Date = DateAdd(DateInterval.Day, 1, Now)
            DhProx = New Date(DhAmanha.Year, DhAmanha.Month, DhAmanha.Day, DataHoraIni.Hour, DataHoraIni.Minute, DataHoraIni.Second)
        End If

        Dim dtCipSchedPer = (From It In DbCv.CipSchedPer Where It.PerId = PerId).ToList
        dtCipSchedPer.First.DataHoraIni = DhProx

        DbCv.SubmitChanges()

        Return False

    End Function

    Function ChkSchedPerMesSem(ByVal PerId As Integer, ByVal RotaId As Integer, ByVal RecNum As Integer,
                         ByVal PerNHoras As Integer, ByVal DataHoraIni As Date) As Boolean

        Dim DbCv As New nsCipValid.dcCipValid

        'Verifica se hoje é um dia do mês programado para este CIP
        Dim dtCipSchedPerMes = (From It In DbCv.CipSchedPerMes Where It.PerId = PerId Order By It.DiaDoMes).ToList

        For Conta As Integer = 0 To dtCipSchedPerMes.Count - 1
            With dtCipSchedPerMes(Conta)

                If .DiaDoMes = Now.Day Then

                    'Programa a execução deste CIP para hoje e adianta a data da próxima verificação
                    Dim DhPg As New Date(Now.Year, Now.Month, Now.Day, DataHoraIni.Hour, DataHoraIni.Minute, DataHoraIni.Second)
                    DbCv.CipSchedProg.InsertOnSubmit(New nsCipValid.CipSchedProg With {.ProgId = Geral.BuscaProgIdNew(), .DataHora = DhPg,
                                                                            .RotaId = RotaId, .Circ = BuscaCipCirc(RotaId),
                                                                            .RecNum = RecNum, .Sts = 0, .UserId = 0})

                    Dim DhAmanha As Date = DateAdd(DateInterval.Day, 1, Now)
                    Dim Dh As New Date(DhAmanha.Year, DhAmanha.Month, DhAmanha.Day, DataHoraIni.Hour, DataHoraIni.Minute, DataHoraIni.Second)
                    Dim dtCipSchedPer = (From It In DbCv.CipSchedPer Where It.PerId = PerId).ToList
                    dtCipSchedPer.first.DataHoraIni = Dh

                    Return True

                End If
            End With
        Next


        'Verifica se hoje é um dia da semana programado para este CIP
        Dim dtCipSchedPerSem = (From It In DbCv.CipSchedPerSem Where It.PerId = PerId Order By It.DiaDaSemana).ToList

        For Conta As Integer = 0 To dtCipSchedPerSem.Count - 1
            With dtCipSchedPerSem(Conta)

                If .DiaDaSemana = Now.DayOfWeek Then

                    'Programa a execução deste CIP para hoje e adianta a data da próxima verificação
                    Dim DhPg As New Date(Now.Year, Now.Month, Now.Day, DataHoraIni.Hour, DataHoraIni.Minute, DataHoraIni.Second)
                    DbCv.CipSchedProg.InsertOnSubmit(New nsCipValid.CipSchedProg With {.ProgId = Geral.BuscaProgIdNew(), .DataHora = DhPg,
                                                                            .RotaId = RotaId, .Circ = BuscaCipCirc(RotaId),
                                                                            .RecNum = RecNum, .Sts = 0, .UserId = 0})

                    Dim DhAmanha As Date = DateAdd(DateInterval.Day, 1, Now)
                    Dim Dh As New Date(DhAmanha.Year, DhAmanha.Month, DhAmanha.Day, DataHoraIni.Hour, DataHoraIni.Minute, DataHoraIni.Second)
                    Dim dtCipSchedPer = (From It In DbCv.CipSchedPer Where It.PerId = PerId).ToList
                    dtCipSchedPer.first.DataHoraIni = Dh

                    Return True

                End If
            End With
        Next

        DbCv.SubmitChanges()

        Return False

    End Function

    Public Function CircNum(ByVal CircTxt As String) As Integer

        Dim Num As Integer

        'Retorna o numero do circuito correspondente a letra (A=0;B=1,etc)
        Select Case CircTxt.ToUpper

            Case "A"
                Num = 0
            Case "B"
                Num = 1
            Case "C"
                Num = 2
            Case "D"
                Num = 3
            Case "E"
                Num = 4
            Case "CA"
                Num = 5
            Case "CB"
                Num = 6
            Case "CC"
                Num = 7
            Case "CD"
                Num = 8
            Case "CE"
                Num = 9
            Case "L"
                Num = 10
            Case "M"
                Num = 11
            Case "N"
                Num = 12
            Case "O"
                Num = 13
            Case "P"
                Num = 14
            Case "Q"
                Num = 15
            Case "R"
                Num = 16
            Case "S"
                Num = 17
            Case "T"
                Num = 18
            Case "U"
                Num = 19
            Case "V"
                Num = 20
            Case "X"
                Num = 21
            Case "Z"
                Num = 22

                'Case "A"
                '    Num = 0
                'Case "B"
                '    Num = 1
                'Case "C"
                '    Num = 2
                'Case "D"
                '    Num = 3
                'Case "E"
                '    Num = 4
                'Case "F"
                '    Num = 5
                'Case "G"
                '    Num = 6
                'Case "H"
                '    Num = 7
                'Case "I"
                '    Num = 8
                'Case "J"
                '    Num = 9
                'Case "L"
                '    Num = 10
                'Case "M"
                '    Num = 11
                'Case "N"
                '    Num = 12
                'Case "O"
                '    Num = 13
                'Case "P"
                '    Num = 14
                'Case "Q"
                '    Num = 15
                'Case "R"
                '    Num = 16
                'Case "S"
                '    Num = 17
                'Case "T"
                '    Num = 18
                'Case "U"
                '    Num = 19
                'Case "V"
                '    Num = 20
                'Case "X"
                '    Num = 21
                'Case "Z"
                '    Num = 22

            Case Else
                Num = 0

        End Select

        Return Num

    End Function

    Public Function CircTxt(ByVal CircNum As Integer) As String

        Dim Txt As String

        'Retorna o texto do circuito correspondente ao numero (0=A;1=B,etc)
        Select Case CircNum

            Case 0
                Txt = "A"
            Case 1
                Txt = "B"
            Case 2
                Txt = "C"
            Case 3
                Txt = "D"
            Case 4
                Txt = "E"
            Case 5
                Txt = "CA"
            Case 6
                Txt = "CB"
            Case 7
                Txt = "CC"
            Case 8
                Txt = "CD"
            Case 9
                Txt = "CE"
            Case 10
                Txt = "L"
            Case 11
                Txt = "M"
            Case 12
                Txt = "N"
            Case 13
                Txt = "O"
            Case 14
                Txt = "P"
            Case 15
                Txt = "Q"
            Case 16
                Txt = "R"
            Case 17
                Txt = "S"
            Case 18
                Txt = "T"
            Case 19
                Txt = "U"
            Case 20
                Txt = "V"
            Case 21
                Txt = "X"
            Case 22
                Txt = "Z"

                'Case 0
                '    Txt = "A"
                'Case 1
                '    Txt = "B"
                'Case 2
                '    Txt = "C"
                'Case 3
                '    Txt = "D"
                'Case 4
                '    Txt = "E"
                'Case 5
                '    Txt = "F"
                'Case 6
                '    Txt = "G"
                'Case 7
                '    Txt = "H"
                'Case 8
                '    Txt = "I"
                'Case 9
                '    Txt = "J"
                'Case 10
                '    Txt = "L"
                'Case 11
                '    Txt = "M"
                'Case 12
                '    Txt = "N"
                'Case 13
                '    Txt = "O"
                'Case 14
                '    Txt = "P"
                'Case 15
                '    Txt = "Q"
                'Case 16
                '    Txt = "R"
                'Case 17
                '    Txt = "S"
                'Case 18
                '    Txt = "T"
                'Case 19
                '    Txt = "U"
                'Case 20
                '    Txt = "V"
                'Case 21
                '    Txt = "X"
                'Case 22
                '    Txt = "Z"

            Case Else
                Txt = "?"
        End Select

        Return Txt

    End Function

    Function BuscaCipCirc(ByVal RotaId As Integer) As String

        Dim Circ As String = "."

        Dim DbCr As New nsCipRotas.dcCipRotas
        Dim dtRotaCad = (From It In DbCr.RotaCad Where It.RotaId = RotaId).ToList
        If dtRotaCad.Count > 0 Then Circ = dtRotaCad(0).Circ

        Return Circ

    End Function

    Public Function AbreXlsx(ByVal ArqNome As String) As Boolean

        ' Busca registro com o caminho do executavel do Excel
        Dim pRegKeyExcel As Microsoft.Win32.RegistryKey = Microsoft.Win32.Registry.ClassesRoot
        pRegKeyExcel = pRegKeyExcel.OpenSubKey("Excel.Workspace\shell\Open\command")

        ' Busca registro com o caminho do executavel do Libre Office
        Dim pRegKeyLibreOffice As Microsoft.Win32.RegistryKey = Microsoft.Win32.Registry.ClassesRoot
        pRegKeyLibreOffice = pRegKeyLibreOffice.OpenSubKey("LibreOffice.CalcDocument.1\shell\open\command")

        Dim pRegKeyOpenDocument As Microsoft.Win32.RegistryKey = Microsoft.Win32.Registry.ClassesRoot
        pRegKeyOpenDocument = pRegKeyOpenDocument.OpenSubKey("OpenOffice.org.Xlsx\shell\open\command")

        Dim Cmd As String = ""
        If (pRegKeyExcel Is Nothing) = False Then

            'Excel
            Cmd = pRegKeyExcel.GetValue("")

        ElseIf (pRegKeyLibreOffice Is Nothing) = False Then

            'Libre Office
            Dim Keys() As String = pRegKeyLibreOffice.GetValue("").ToString.Split(""""c)
            Cmd = Keys(1)

        ElseIf (pRegKeyOpenDocument Is Nothing) = False Then

            'Libre Office
            Dim Keys() As String = pRegKeyOpenDocument.GetValue("").ToString.Split(""""c)
            Cmd = Keys(1)

        Else

            'Não tem Excel nem Libre Office Calc
            Return False

        End If

        'Dim RetSel As MsgBoxResult = MsgBox("O relatório foi criado." & ControlChars.CrLf & "[" & ArqNome & "]" & ControlChars.CrLf &
        '        "Selecione Ok para abrir o arquivo.", vbOKCancel, "Relatório criado.")

        'If RetSel <> MsgBoxResult.Ok Then Return False

        Try
            Cmd = Cmd & " " & ArqNome
            Shell(Cmd, AppWinStyle.NormalFocus)
        Catch : End Try

        Return True

    End Function

    Public Sub AbreCipRelatWeb()

        'Fecha o Internet Explorer
        Dim localByName As Process() = Process.GetProcessesByName("iexplore")
        For Each Pr In localByName
            Try
                Pr.Kill()
            Catch : End Try
        Next

        'Relatorios Aspx
        Try

            'Dim Ff As String = My.Computer.Registry.GetValue("HKEY_CLASSES_ROOT\FirefoxURL\shell\open\command", "",
            '                                                  """C:\Program Files (x86)\Mozilla Firefox\firefox.exe"" -osint -url ""%1""")
            'Dim Cmd As String = Ff.Replace("%1", Url)
            'Shell(Cmd, AppWinStyle.NormalFocus)


            Dim Caminho As String = Util.UtAppPath
            Dim Cfg As New Util.clsTrataCfg(Caminho & "\..\Bin\cfgGeral.xml")
            Dim ServerIp As String = Cfg.colCfg("ServerIp")

            Dim Url As String = "http://" & ServerIp & "/CipRelatWeb/Default.aspx"

            Dim Browser As Object = CreateObject("InternetExplorer.Application")
            Browser.Navigate2(Url)
            Browser.Visible = True


        Catch : End Try


    End Sub

    Public Function SrvChkGrava(Item As String, ContaD As Integer) As Boolean

        ' Caso a verificacao nao esteja habilitada evita a gravacao
        If FlagHabSrvChk = False Then Return True

        'Grava o contador de comunicação no banco de dados Ranges
        Dim DbRn = New nsRanges.dcRanges
        Dim dtSc = (From It In DbRn.SrvChk Where It.Item = Item).ToList
        If dtSc.Count <= 0 Then

            'Insert
            Dim NwSc As New nsRanges.SrvChk With {.Item = Item, .ContaD = ContaD}
            DbRn.SrvChk.InsertOnSubmit(NwSc)

        Else

            'Update
            dtSc.First.ContaD = ContaD

        End If

        DbRn.SubmitChanges()

        Return True

    End Function

End Module
