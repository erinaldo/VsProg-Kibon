
Public Module basTrataOpc

    Public Const OpcSrvName = "RSLinx OPC Server"

    Public Function OpcGrupoLe(ByVal MyOpcGroup As RsiOPCAuto.OPCGroup, _
                               ByRef Values As Object) As Boolean

        Dim lNumitems As Integer
        Dim arHandles() As Integer = Nothing
        Dim arValues As Array = Nothing
        Dim arErrors As Array = Nothing


        'Monta lista de Handles
        lNumitems = MyOpcGroup.OPCItems.Count
        If lNumitems <= 0 Then
            OpcGrupoLe = False
            Exit Function
        End If

        ReDim arHandles(0 To lNumitems)

        For Conta As Integer = 1 To lNumitems
            arHandles(Conta) = MyOpcGroup.OPCItems.Item(Conta).ServerHandle
        Next

        'Le do PLC
        'On Error Resume Next
        Dim arQualities = Nothing
        Dim arTimeStamp = Nothing
        MyOpcGroup.SyncRead(RsiOPCAuto.OPCDataSource.OPCDevice, lNumitems, _
                    arHandles, arValues, arErrors, arQualities, arTimeStamp)
        On Error GoTo 0


        'Verifica se houve erro
        If arQualities Is Nothing Then
            OpcGrupoLe = False
            Exit Function
        End If

        For Conta As Integer = 0 To UBound(arQualities) - 1
            If arQualities(Conta + 1) <> 192 Then Return False
        Next


        'Ok
        Values = arValues
        Return True

    End Function

    Public Function OpcGrupoEscreve(ByVal MyOpcGroup As RsiOPCAuto.OPCGroup, _
                             ByVal Values As Object) As Boolean

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
            arValues(Conta) = Values(Conta)
        Next


        'Le do PLC
        'On Error Resume Next
        MyOpcGroup.SyncWrite(lNumitems, arHandles, arValues, arErrors)
        'On Error GoTo 0

        'Debug.Print MyOpcGroup.Parent.GetErrorString(arErrors(83))

        'Verifica se houve erro
        For Conta As Integer = 1 To UBound(arErrors)
            If arErrors(Conta) <> 0 Then
                OpcGrupoEscreve = False
                Exit Function
            End If
        Next


        'Ok
        OpcGrupoEscreve = True

    End Function

    Function OpcTagMonta(ByVal Topico As String, ByVal Tag As String, _
                Optional ByVal Linhas As Integer = -1, Optional ByVal Colunas As Integer = -1)

        'Monta tag ex: [Plc1]TT.MyStr,L20,C20

        Dim Txt As String = "[" & Topico & "]" & Tag

        If Linhas > 0 Then
            Txt = Txt & ",L" & Linhas
        End If

        If Colunas > 0 Then
            Txt = Txt & ",C" & Colunas
        End If

        OpcTagMonta = Txt

    End Function

    Public Function OpcConvTxtBytes(ByVal Txt, ByVal NBytes) As Short()

        Dim MyBytes() As Short
        Dim Letra As String

        'Converte um String em um array de bytes
        ReDim MyBytes(NBytes - 1)

        Txt = Left(Txt, NBytes)

        On Error Resume Next
        For Conta As Integer = 0 To NBytes - 1

            Letra = Mid(Txt, Conta + 1, 1)
            MyBytes(Conta) = Asc(Letra)

        Next

        Return MyBytes

    End Function

    Public Function OpcConvBytesTxt(ByVal MyBytes) As String

        Dim Txt As String = ""

        'Converte um array de bytes em String
        For Conta As Integer = LBound(MyBytes) To UBound(MyBytes)

            Txt = Txt & Chr(MyBytes(Conta))

        Next

        Return Txt

    End Function

End Module

