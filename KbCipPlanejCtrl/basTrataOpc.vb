Public Module basTrataOpc

    Public Enum OpcTagMontaTipo As Integer
        Word = 0
        Real = 1
    End Enum

    Public Enum OpcTagVl As Integer
        Vazao = 0
        Temp = 1
        Cond = 2
        BlkNum = 3
        BlkPasso = 4
        Pausa = 5
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
        Dim z = UBound(arErrors)
        For Conta As Integer = 1 To UBound(arErrors)
            If arErrors(Conta) <> 0 Then
                Return False
            End If
        Next

        'Ok
        Return True

    End Function

    Public Function OpcTagMonta(ByVal TopicoPlc As String, ByVal DbNum As Integer, ByVal Tipo As OpcTagMontaTipo,
                                ByVal Pos As Integer) As String

        Dim TipoTxt As String = "WORD"
        If Tipo = OpcTagMontaTipo.Real Then TipoTxt = "REAL"

        'Monta tag ex: "S7:[Opc6]DB200,WORD400,1"
        'Dim Txt As String = "S7:[" & TopicoPlc & "]DB" & DbNum & "," & TipoTxt & Pos & ",1"
        Dim Txt As String = "S7:[" & TopicoPlc & "]DB" & DbNum & "," & TipoTxt & Pos

        Return Txt

    End Function

    Public Function OpcCipDbCtrl(ByVal CircNum As Integer) As Integer

        Dim DbNum As Integer = 0

        Select Case CircNum

            Case 0
                'Cip A
                DbNum = 200
            Case 1
                'Cip B
                DbNum = 201
            Case 2
                'Cip C
                DbNum = 202
            Case 3
                'Cip D
                DbNum = 205
            Case 4
                'Cip E
                DbNum = 206
            Case 5
                'Cip CA
                DbNum = 300
            Case 6
                'Cip CB
                DbNum = 301
            Case 7
                'Cip CC
                DbNum = 302
            Case 8
                'Cip CD
                DbNum = 303
            Case 9
                'Cip CE
                DbNum = 304

        End Select

        Return DbNum

    End Function

    Public Function OpcCipDbVlPos(ByVal CircNum As Integer, ByVal Vl As OpcTagVl) As Integer

        Dim Pos As Integer = 0

        'Dados de histórico de CIP, veja DB240 no AS6
        If CircNum = 0 Then

            'Cip A
            If Vl = OpcTagVl.Vazao Then
                Pos = 0
            ElseIf Vl = OpcTagVl.Temp Then
                Pos = 28
            ElseIf Vl = OpcTagVl.Cond Then
                Pos = 56
            ElseIf Vl = OpcTagVl.BlkNum Then
                Pos = 84
            ElseIf Vl = OpcTagVl.BlkPasso Then
                Pos = 98
            ElseIf Vl = OpcTagVl.Pausa Then
                Pos = 112
            End If

        ElseIf CircNum = 1 Then

            'Cip B
            If Vl = OpcTagVl.Vazao Then
                Pos = 4
            ElseIf Vl = OpcTagVl.Temp Then
                Pos = 32
            ElseIf Vl = OpcTagVl.Cond Then
                Pos = 60
            ElseIf Vl = OpcTagVl.BlkNum Then
                Pos = 86
            ElseIf Vl = OpcTagVl.BlkPasso Then
                Pos = 100
            ElseIf Vl = OpcTagVl.Pausa Then
                Pos = 114
            End If

        ElseIf CircNum = 2 Then

            'Cip C
            If Vl = OpcTagVl.Vazao Then
                Pos = 8
            ElseIf Vl = OpcTagVl.Temp Then
                Pos = 36
            ElseIf Vl = OpcTagVl.Cond Then
                Pos = 64
            ElseIf Vl = OpcTagVl.BlkNum Then
                Pos = 88
            ElseIf Vl = OpcTagVl.BlkPasso Then
                Pos = 102
            ElseIf Vl = OpcTagVl.Pausa Then
                Pos = 116
            End If

        ElseIf CircNum = 3 Then

            'Cip D
            If Vl = OpcTagVl.Vazao Then
                Pos = 12
            ElseIf Vl = OpcTagVl.Temp Then
                Pos = 40
            ElseIf Vl = OpcTagVl.Cond Then
                Pos = 68
            ElseIf Vl = OpcTagVl.BlkNum Then
                Pos = 90
            ElseIf Vl = OpcTagVl.BlkPasso Then
                Pos = 104
            ElseIf Vl = OpcTagVl.Pausa Then
                Pos = 118
            End If

        ElseIf CircNum = 4 Then

            'Cip E
            If Vl = OpcTagVl.Vazao Then
                Pos = 16
            ElseIf Vl = OpcTagVl.Temp Then
                Pos = 44
            ElseIf Vl = OpcTagVl.Cond Then
                Pos = 72
            ElseIf Vl = OpcTagVl.BlkNum Then
                Pos = 92
            ElseIf Vl = OpcTagVl.BlkPasso Then
                Pos = 106
            ElseIf Vl = OpcTagVl.Pausa Then
                Pos = 120
            End If

        ElseIf CircNum = 5 Then

            'Cip CA
            If Vl = OpcTagVl.Vazao Then
                Pos = 0
            ElseIf Vl = OpcTagVl.Temp Then
                Pos = 28
            ElseIf Vl = OpcTagVl.Cond Then
                Pos = 56
            ElseIf Vl = OpcTagVl.BlkNum Then
                Pos = 84
            ElseIf Vl = OpcTagVl.BlkPasso Then
                Pos = 98
            ElseIf Vl = OpcTagVl.Pausa Then
                Pos = 112
            End If

        ElseIf CircNum = 6 Then

            'Cip CB
            If Vl = OpcTagVl.Vazao Then
                Pos = 4
            ElseIf Vl = OpcTagVl.Temp Then
                Pos = 32
            ElseIf Vl = OpcTagVl.Cond Then
                Pos = 60
            ElseIf Vl = OpcTagVl.BlkNum Then
                Pos = 86
            ElseIf Vl = OpcTagVl.BlkPasso Then
                Pos = 100
            ElseIf Vl = OpcTagVl.Pausa Then
                Pos = 114
            End If

        ElseIf CircNum = 7 Then

            'Cip CC
            If Vl = OpcTagVl.Vazao Then
                Pos = 8
            ElseIf Vl = OpcTagVl.Temp Then
                Pos = 36
            ElseIf Vl = OpcTagVl.Cond Then
                Pos = 64
            ElseIf Vl = OpcTagVl.BlkNum Then
                Pos = 88
            ElseIf Vl = OpcTagVl.BlkPasso Then
                Pos = 102
            ElseIf Vl = OpcTagVl.Pausa Then
                Pos = 116
            End If

        ElseIf CircNum = 8 Then

            'Cip CD
            If Vl = OpcTagVl.Vazao Then
                Pos = 12
            ElseIf Vl = OpcTagVl.Temp Then
                Pos = 40
            ElseIf Vl = OpcTagVl.Cond Then
                Pos = 68
            ElseIf Vl = OpcTagVl.BlkNum Then
                Pos = 90
            ElseIf Vl = OpcTagVl.BlkPasso Then
                Pos = 104
            ElseIf Vl = OpcTagVl.Pausa Then
                Pos = 118
            End If

        ElseIf CircNum = 9 Then

            'Cip CE
            If Vl = OpcTagVl.Vazao Then
                Pos = 16
            ElseIf Vl = OpcTagVl.Temp Then
                Pos = 44
            ElseIf Vl = OpcTagVl.Cond Then
                Pos = 72
            ElseIf Vl = OpcTagVl.BlkNum Then
                Pos = 92
            ElseIf Vl = OpcTagVl.BlkPasso Then
                Pos = 106
            ElseIf Vl = OpcTagVl.Pausa Then
                Pos = 120
            End If

        End If

        Return Pos

    End Function

End Module
