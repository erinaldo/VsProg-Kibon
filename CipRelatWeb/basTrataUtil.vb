Imports Microsoft.VisualBasic

Public module basTrataUtil

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

End Module
