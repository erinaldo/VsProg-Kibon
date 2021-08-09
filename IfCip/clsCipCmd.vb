Public Class clsCipCmd

    Public NPassos As Integer = 21

    'Dados do PLC
    Public CmdSubgrupo As OPCAutomation.OPCItem
    Public CmdTipo As OPCAutomation.OPCItem
    Public TempoProg(NPassos - 1) As OPCAutomation.OPCItem

    Public Function OpcMonta(ByVal Grupo As String, ByVal EndTempos As Integer, ByVal Tipo As Integer) As Boolean

        Dim Hndl As Integer

        OpcGrupoCmd = OpcSrvPoll.OPCGroups.Add("CipCmd")
        OpcGrupoCmd.IsActive = False

        Dim IdxSubgrupo As Integer
        Dim IdxTipo As Integer

        Select Case Grupo
            Case "A"
                IdxSubgrupo = "20"
                IdxTipo = "25"
            Case "B"
                IdxSubgrupo = "21"
                IdxTipo = "26"
            Case "C"
                IdxSubgrupo = "22"
                IdxTipo = "27"
            Case "D"
                IdxSubgrupo = "23"
                IdxTipo = "28"
            Case "E"
                IdxSubgrupo = "24"
                IdxTipo = "29"
        End Select

        Dim AddrTempo As String = ""
        If Tipo = 0 Then
            AddrTempo = "N9:"
        Else
            AddrTempo = "N10:"
        End If


        With OpcGrupoCmd.OPCItems

            CmdSubgrupo = .AddItem(PlcTopico & "N121:" & IdxSubgrupo, Hndl)
            CmdTipo = .AddItem(PlcTopico & "N121:" & IdxTipo, Hndl)

            'Tempos programados para cada passo
            For Conta As Integer = 0 To NPassos - 1
                TempoProg(Conta) = .AddItem(PlcTopico & AddrTempo & (EndTempos + Conta), Hndl)
            Next

        End With

        'Ok
        OpcGrupoCmd.IsActive = True
        OpcGrupoCmd.UpdateRate = 500
        OpcGrupoCmd.IsSubscribed = True
        Return True

    End Function

    Public Function OpcDesmonta() As Boolean

        OpcSrvPoll.OPCGroups.Remove("CipCmd")
        OpcGrupoCmd = Nothing

        Return True

    End Function

End Class
