Public Module basTrataOpc

    Public Enum OpcTagMontaTipo As Integer
        Word = 0
        Real = 1
        Int = 2
    End Enum

    Public Function OpcGrupoLe(ByVal MyOpcGroup As OPCAutomation.OPCGroup, ByRef Valores As Object) As Boolean

        Dim lNumitems As Integer
        Dim arHandles() As Integer = Nothing
        Dim arValues As Object = Nothing
        Dim arErrors As System.Array = Nothing
        Dim arQualities = Nothing
        Dim arTimeStamp = Nothing

        'Monta lista de Handles
        lNumitems = MyOpcGroup.OPCItems.Count
        If lNumitems <= 0 Then
            Return False
        End If

        ReDim arHandles(0 To lNumitems)

        For Conta As Integer = 1 To lNumitems
            arHandles(Conta) = MyOpcGroup.OPCItems.Item(Conta).ServerHandle
        Next

        'Le do PLC
        On Error Resume Next
        MyOpcGroup.SyncRead(OPCAutomation.OPCDataSource.OPCDevice, lNumitems, arHandles, arValues, arErrors, arQualities, arTimeStamp)
        On Error GoTo 0

        'Verifica se houve erro
        If arQualities Is Nothing Then
            Return False
        End If

        Dim MaxQualities As Integer = UBound(arQualities)

        For Conta As Integer = 0 To (MaxQualities - 2)
            If arQualities(Conta + 1) <> 192 Then
                Return False
            End If
        Next

        'Ok
        Valores = arValues(1)
        Return True

    End Function

    Public Function OpcGrupoEscreve(ByVal MyOpcGroup As OPCAutomation.OPCGroup, ByVal Valores As Object) As Boolean

        Dim lNumitems As Long
        Dim arHandles() As Integer
        Dim arValues() As Object
        Dim arErrors As Array = Nothing


        'Monta lista de Handles
        lNumitems = MyOpcGroup.OPCItems.Count
        ReDim arHandles(0 To lNumitems)
        ReDim arValues(0 To lNumitems)

        For Conta As Integer = 1 To lNumitems
            arHandles(Conta) = MyOpcGroup.OPCItems.Item(Conta).ServerHandle
            arValues(Conta) = Valores
        Next


        'Escreve do PLC
        On Error Resume Next
        MyOpcGroup.SyncWrite(lNumitems, arHandles, arValues, arErrors)
        On Error GoTo 0

        'Debug.Print MyOpcGroup.Parent.GetErrorString(arErrors(83))

        'Verifica se houve erro
        For Conta As Integer = 1 To UBound(arErrors)
            If arErrors(Conta) <> 0 Then
                Return False
            End If
        Next


        'Ok
        Return True

    End Function

    Public Function OpcTagMonta(ByVal TopicoPlc As String, ByVal DbNum As Integer, ByVal Tipo As OpcTagMontaTipo,
                                ByVal Pos As Integer, Qtd As Integer) As String

        Dim TipoTxt As String = "WORD"
        If Tipo = OpcTagMontaTipo.Real Then TipoTxt = "REAL"
        If Tipo = OpcTagMontaTipo.Int Then TipoTxt = "INT"

        'Monta tag ex: "S7:[Opc6]DB200,WORD400,1"
        ' Dim Txt As String = "S7:[" & TopicoPlc & "]DB" & DbNum & "," & TipoTxt & Pos * ",1"
        Dim Txt As String = "S7:[" & TopicoPlc & "]DB" & DbNum & "," & TipoTxt & Pos & "," & Qtd

        Return Txt

    End Function

End Module
