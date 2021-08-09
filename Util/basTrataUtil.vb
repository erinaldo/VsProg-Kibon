Public Module basTrataUtil

    Public DataInvalida As New Date(2000, 1, 1)

    Public Function UtAppPath() As String

        If Right(My.Application.Info.DirectoryPath, 10) = "\bin\Debug" Then
            Return Mid(My.Application.Info.DirectoryPath, 1, Len(My.Application.Info.DirectoryPath) - 10)
            Exit Function
        End If

        Return My.Application.Info.DirectoryPath

    End Function

    Function ChkNulo(ByVal MyCtrl As TextBox) As Boolean

        If MyCtrl.Text = "" Then
            MsgBox("Erro: o campo '" & MyCtrl.Name & "' deve ser preenchido.", MsgBoxStyle.Critical)
            MyCtrl.SelectAll()
            MyCtrl.Focus()
            Return False
        End If

        'Ok
        Return True

    End Function

    Function ChkNumerico(ByVal MyCtrl As TextBox) As Boolean

        If IsNumeric(MyCtrl.Text) = False Then
            MsgBox("Erro: o campo '" & MyCtrl.Name & "' deve ser numérico.", MsgBoxStyle.Critical)
            MyCtrl.SelectAll()
            MyCtrl.Focus()
            Return False
        End If

        'Ok
        Return True

    End Function

    Function ChkData(ByVal MyCtrl As MaskedTextBox) As Boolean

        If IsDate(MyCtrl.Text) = False Then
            MsgBox("Erro: o campo '" & MyCtrl.Name & "' deve ser preenchido com data.")
            MyCtrl.SelectAll()
            MyCtrl.Focus()
            Return False
        End If

        'Ok
        Return True

    End Function

    Function ConvVirgPonto(ByVal Valor As String) As String

        Dim Pos As Integer = Strings.InStr(Valor, ",")
        If Pos = 0 Then Return Valor

        Dim Result As String = ""

        If Pos = 1 Then
            Result = "0"
        Else
            Result = Strings.Left(Valor, Pos - 1)
        End If

        Result = Result & "." & Strings.Right(Valor, Strings.Len(Valor) - Pos)

        Return Result

    End Function

    Function LimpaApostrofe(ByVal Texto As String) As String

        Dim Resp As String = ""
        Dim Letra As String = ""

        For Conta As Integer = 0 To Texto.Length - 1

            Letra = Mid(Texto, Conta + 1, 1)

            If Letra = "'" Then
                Resp = Resp & " "
            Else
                Resp = Resp & Letra
            End If

        Next

        Return Resp

    End Function

    Function FormataCasaDecimal(ByVal Valor As Double, ByVal NCasasDec As Integer) As String

        Dim ValorTxt As String = Format(Valor, "0.00000000000000")

        Dim Pos As Integer = InStr(ValorTxt, ".")
        If Pos <= 0 Then
            Return ValorTxt
        End If

        Dim Txt As String = Left(ValorTxt, Pos + NCasasDec)
        Return Txt

    End Function

    Function BuscaDiaSemTxt(ByVal DiaSem As Integer) As String

        Select Case DiaSem
            Case 1
                Return "Dom"
            Case 2
                Return "Seg"
            Case 3
                Return "Ter"
            Case 4
                Return "Qua"
            Case 5
                Return "Qui"
            Case 6
                Return "Sex"
            Case Else
                Return "Sab"
        End Select

        Return ""

    End Function

    Function BuscaDiaSemId(ByVal Txt As String) As Integer

        Select Case Txt.ToUpper
            Case "DOM"
                Return 1
            Case "SEG"
                Return 2
            Case "TER"
                Return 3
            Case "QUA"
                Return 4
            Case "QUI"
                Return 5
            Case "SEX"
                Return 6
            Case Else
                Return 7
        End Select

        Return ""

    End Function

    Public Function UtConvDhms(ByVal AtrasoSeg As Integer) As String

        Dim TotDia As Double = 24 * 60 * 60
        Dim TotHora As Double = 60 * 60
        Dim TotMin As Double = 60

        Dim Dias As Double
        Dim Horas As Double
        Dim Min As Double
        Dim Seg As Double

        Dim Sobra As Double = AtrasoSeg
        Dim Resto As Double = AtrasoSeg


        Resto = Sobra Mod TotDia
        Dias = (Sobra - Resto) / TotDia
        Sobra = Sobra - Dias * TotDia

        Resto = Sobra Mod TotHora
        Horas = (Sobra - Resto) / TotHora
        Sobra = Sobra - Horas * TotHora

        Resto = Sobra Mod TotMin
        Min = (Sobra - Resto) / TotMin
        Sobra = Sobra - Min * TotMin

        Seg = Sobra

        Dim Dhms As String = ""
        If Dias > 0 Then Dhms = Dias & "d "

        Dhms = Dhms & Microsoft.VisualBasic.Right("00" & Horas, 2) & ":" & _
                    Microsoft.VisualBasic.Right("00" & Min, 2) & ":" & _
                    Microsoft.VisualBasic.Right("00" & Seg, 2)

        Return Dhms

    End Function

    Public Function ConvStrData(ByVal DataTxt As String) As Date

        Dim Str() As String = DataTxt.Split("/"c, " "c, ":")
        If Str.Length < 6 Then Return DataInvalida

        Dim Dh As Date

        Try
            Dh = New Date(Str(2), Str(1), Str(0), Str(3), Str(4), Str(5))
        Catch
            Return DataInvalida
        End Try

        Return Dh

    End Function

    Public Function ChkDataConfReg(ByVal ProgNome As String) As Boolean

        Dim DataCfgNecessaria As String = "d/M/yyyy"

        'Verifica se a configuração regional de data do micro é d/M/yyyy
        Dim DataCfgAtual As String = My.Computer.Registry.CurrentUser.OpenSubKey("Control Panel\International", True).GetValue("sShortDate")
        If DataCfgAtual <> DataCfgNecessaria Then

            'A configiuração do micro está errada
            Dim Ret As MsgBoxResult = MsgBox("ATENÇÃO: Este aplicativo exige que a configuração regional de DATA do " & ControlChars.CrLf & _
                                             "microcomputador seja alterada para [" & DataCfgNecessaria & "]." & ControlChars.CrLf & _
                                             "A configuração atual é [" & DataCfgAtual & "]." & ControlChars.CrLf & _
                                             "Confirma a alteração desta configuração regional?", MsgBoxStyle.OkCancel, ProgNome)
            If Ret = MsgBoxResult.Cancel Then Return False

            My.Computer.Registry.CurrentUser.OpenSubKey("Control Panel\International", True).SetValue("sShortDate", "d/M/yyyy")

        End If


        'Verifica se a configuração regional de separador decimal, agrupamento de dígitos e separador de listas está correto
        Dim sDecimal As String = My.Computer.Registry.CurrentUser.OpenSubKey("Control Panel\International", True).GetValue("sDecimal")
        Dim sThousand As String = My.Computer.Registry.CurrentUser.OpenSubKey("Control Panel\International", True).GetValue("sThousand")
        Dim sList As String = My.Computer.Registry.CurrentUser.OpenSubKey("Control Panel\International", True).GetValue("sList")
        If sDecimal <> "." Or sThousand <> "," Or sList <> "," Then

            'A configiuração do micro está errada
            Dim Ret As MsgBoxResult = MsgBox("ATENÇÃO: Este aplicativo exige que a configuração regional do " & ControlChars.CrLf & _
                                             "microcomputador seja alterada para:" & ControlChars.CrLf & _
                                             "Separador decimal = '.' (Ponto)" & ControlChars.CrLf & _
                                             "Agrupamento de dígitos = ',' (Vírgula)" & ControlChars.CrLf & _
                                             "Separador de listas = ',' (Vírgula)" & ControlChars.CrLf & _
                                             "Confirma a alteração desta configuração regional?", MsgBoxStyle.OkCancel, ProgNome)
            If Ret = MsgBoxResult.Cancel Then Return False

            My.Computer.Registry.CurrentUser.OpenSubKey("Control Panel\International", True).SetValue("sDecimal", ".")
            My.Computer.Registry.CurrentUser.OpenSubKey("Control Panel\International", True).SetValue("sThousand", ",")
            My.Computer.Registry.CurrentUser.OpenSubKey("Control Panel\International", True).SetValue("sList", ",")

        End If

        Return True

    End Function

    Public Function UtConvDecimalVigPonto(ByVal ValorOrig As Double) As String

        'Esta funcao converte a virgula de ponto devimal para ponto 
        Dim ValorTxt As String = ValorOrig

        'Procura posicao da virgula na string
        Dim PosVirgula As Integer = InStr(ValorOrig, ",")

        'Verifica se tem veigula
        If PosVirgula > 0 Then

            'Substitui virgula por ponto na string
            Mid(ValorTxt, PosVirgula, 1) = "."

        End If

        UtConvDecimalVigPonto = ValorTxt

    End Function

    Public Function UtConvDecimalPontoVig(ByVal ValorOrig As String) As String

        'Esta funcao converte a virgula de ponto devimal para ponto 
        Dim ValorTxt As String = ValorOrig

        'Procura posicao da virgula na string
        Dim PosVirgula As Integer = InStr(ValorTxt, ".")

        'Verifica se tem veigula
        If PosVirgula > 0 Then

            'Substitui virgula por ponto na string
            Mid(ValorTxt, PosVirgula, 1) = ","

        End If

        UtConvDecimalPontoVig = ValorTxt

    End Function

    Public Function UtConvYmdData(ByVal Ymd As String) As String

        'Converte data oracle para vb
        'Ex: 20000325235959 -> 25/03/2000 23:59:59

        If Ymd = "" Or Ymd.Length < 14 Then Return ""

        Dim Ano As String = Mid(Ymd, 1, 4)
        Dim Mes As String = Mid(Ymd, 5, 2)
        Dim Dia As String = Mid(Ymd, 7, 2)
        Dim Hora As String = Mid(Ymd, 9, 2)
        Dim Minuto As String = Mid(Ymd, 11, 2)
        Dim Seg As String = Mid(Ymd, 13, 2)

        Dim Txt As String = Dia & "/" & Mes & "/" & Ano & " " & _
                Hora & ":" & Minuto & ":" & Seg

        Return Txt

    End Function

    Public Function UtConvDataYmd(ByVal Data As String) As String

        'Converte data vb para oracle
        'Ex: 25/03/2000 23:59:59 -> 20000325235959

        If Data.Length = 10 Then Data = Data & " 00:00:00"
        If Data = "" Or Data.Length < 19 Then Return ""

        Dim Dia As String = Mid(Data, 1, 2)
        Dim Mes As String = Mid(Data, 4, 2)
        Dim Ano As String = Mid(Data, 7, 4)
        Dim Hora As String = Mid(Data, 12, 2)
        Dim Minuto As String = Mid(Data, 15, 2)
        Dim Seg As String = Mid(Data, 18, 2)

        Dim Txt As String = Ano & Mes & Dia & Hora & Minuto & Seg

        Return Txt

    End Function

    Public Function UtChkSqlString(ByVal ValorOrig As String) As String

        'Esta funcao converte " e ' em _ 
        Dim ValorTxt As String = ValorOrig
        Dim Letra As String

        If ValorOrig Is Nothing Then Return ""

        'Procura posicao da virgula na string
        For Conta As Integer = 0 To ValorTxt.Length - 1

            Letra = Mid(ValorTxt, Conta + 1, 1)
            If Letra = "'" Or Letra = """" Then
                Mid(ValorTxt, Conta + 1, 1) = "_"
            End If

        Next

        UtChkSqlString = ValorTxt

    End Function

    Public Function UtChkNullStr(ByVal ValorOrig) As String

        If ValorOrig Is DBNull.Value Then
            Return ""
        End If

        Return ValorOrig

    End Function

End Module
