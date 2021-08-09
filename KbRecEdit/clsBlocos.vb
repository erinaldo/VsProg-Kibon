Public Class clsBlocos

    Public Bloco As List(Of clsBloco)
    Public AreaGeral As String

    Public blkBanco As New Geral.nsReceitas.dcReceitas

    Sub New(ByVal myArea As String)

        ' carrega todos os blocos existentes no sistema
        Dim myBlocos = (From It In blkBanco.Blocos Where It.Area = myArea).ToList

        If myBlocos.Count <= 0 Then Return

        Bloco = New List(Of clsBloco)

        For Each Reg In myBlocos

            Dim BlkNum As Integer = Reg.BlkNum

            Dim NewBlk As New clsBloco(Me, Reg.Area, Reg.BlkNum)

            AreaGeral = Reg.Area
            NewBlk.Area = Reg.Area
            NewBlk.BlkNum = Reg.BlkNum
            NewBlk.Descr = Reg.BlkDescr
            NewBlk.Mnemonico = Reg.Mnemonico

            Bloco.Add(NewBlk)

        Next

    End Sub

    Public Function BlocoRemove(ByVal myBlkNum As Integer, ByVal myPosClasse As Integer) As Boolean

        'seleciona parametros do bloco
        Dim Reg1 = (From It In blkBanco.BlocosItens Where It.Area = AreaGeral And It.BlkNum = myBlkNum).ToList

        blkBanco.BlocosItens.DeleteAllOnSubmit(Reg1)

        'seleciona o bloco
        Dim Reg2 = (From It In blkBanco.Blocos Where It.Area = AreaGeral And It.BlkNum = myBlkNum).ToList

        blkBanco.Blocos.DeleteAllOnSubmit(Reg2)

        'remove registros pertinentes do banco de dados
        blkBanco.SubmitChanges()

        'remove bloco da classe
        Me.Bloco.RemoveAt(myPosClasse)

        Return True

    End Function

    Public Function BlocoInsere(ByVal NewBlkNum As Integer, ByVal NewDescr As String, ByVal NewMnemonico As String) As Boolean

        'insere bloco na tabela
        Dim NovoBlk As New Geral.nsReceitas.Blocos

        NovoBlk.Area = AreaGeral
        NovoBlk.BlkNum = NewBlkNum
        NovoBlk.BlkDescr = NewDescr
        NovoBlk.Mnemonico = NewMnemonico

        blkBanco.Blocos.InsertOnSubmit(NovoBlk)

        blkBanco.SubmitChanges()

        'insere bloco na classe
        Dim BlkCls As New clsBloco(Me, AreaGeral, NewBlkNum)

        BlkCls.Descr = NewDescr
        BlkCls.Mnemonico = NewMnemonico

        Bloco.Add(BlkCls)

        Return True

    End Function


    Public Function ItemRemove(ByVal myBlkNum As Integer, ByVal myBlkIdx As Integer, ByVal myItemSeq As Integer, ByVal myItemIdx As Integer) As Boolean

        'seleciona parametros do bloco
        Dim Reg = (From It In blkBanco.BlocosItens Where It.Area = AreaGeral And It.BlkNum = myBlkNum And It.ItemSeq = myItemSeq).ToList

        blkBanco.BlocosItens.DeleteAllOnSubmit(Reg)

        'remove registros pertinentes do banco de dados
        blkBanco.SubmitChanges()

        'remove bloco da classe
        Me.Bloco(myBlkIdx).Itens.RemoveAt(myItemIdx)

        Return True

    End Function

    Public Function ItemInsere(ByVal myBlkNum As Integer, ByVal myItemSeq As Integer, ByVal myItemDescr As String, _
                               ByVal myUEng As String, ByVal myMultiplic As Double, ByVal myFlagPeso As Integer, _
                               ByVal myValorDefault As Double) As Boolean

        'insere item na tabela
        Dim NovoItem As New Geral.nsReceitas.BlocosItens

        NovoItem.Area = AreaGeral
        NovoItem.BlkNum = myBlkNum
        NovoItem.ItemSeq = myItemSeq
        NovoItem.ItemDescr = myItemDescr
        NovoItem.UEng = myUEng
        NovoItem.Multiplic = myMultiplic
        NovoItem.FlagPeso = myFlagPeso
        NovoItem.ValorDefault = myValorDefault

        blkBanco.BlocosItens.InsertOnSubmit(NovoItem)

        blkBanco.SubmitChanges()

        'insere item na classe
        Dim ItemCls As New clsBlkItem(AreaGeral, myBlkNum, myItemSeq, myItemDescr, myUEng, myValorDefault, myMultiplic, myFlagPeso)

        Me.Bloco(myBlkNum).Itens.Add(ItemCls)

        Return True

    End Function

End Class

Public Class clsBloco

    Public ParentBlk As clsBlocos
    Public Area As String
    Public BlkNum As Integer
    Public Descr As String
    Public Mnemonico As String

    Public Itens As List(Of clsBlkItem)

    Sub New(ByVal myParentBlk As clsBlocos, ByVal MyArea As String, ByVal MyBlkNum As Integer)

        ParentBlk = myParentBlk
        Area = MyArea
        BlkNum = MyBlkNum

        'Busca dados da tabela BlocosItens
        Dim myItens = (From It In ParentBlk.blkBanco.BlocosItens Where It.Area = MyArea And It.BlkNum = BlkNum).ToList

        Itens = New List(Of clsBlkItem)

        For Each Reg In myItens

            With Reg

                Dim myBlkItem As New clsBlkItem(.Area, .BlkNum, .ItemSeq, .ItemDescr, .UEng, .ValorDefault, .Multiplic, .FlagPeso)

                Itens.Add(myBlkItem)

            End With

        Next

    End Sub

End Class

Public Class clsBlkItem

    Public Area As String
    Public BlkNum As Integer
    Public ItemSeq As Integer
    Public ItemDescr As String
    Public UEng As String
    Public ValorDefault As Double
    Public Multiplic As Double
    Public FlagPeso As Integer

    Sub New(ByVal Area As String, ByVal BlkNum As Integer, ByVal ItemSeq As Integer, _
            ByVal ItemDescr As String, ByVal UEng As String, ByVal ValorDefault As Double, _
            ByVal Multiplic As Double, ByVal FlagPeso As Integer)

        Me.Area = Area
        Me.BlkNum = BlkNum
        Me.ItemSeq = ItemSeq
        Me.ItemDescr = ItemDescr
        Me.UEng = UEng
        Me.ValorDefault = ValorDefault
        Me.Multiplic = Multiplic
        Me.FlagPeso = FlagPeso

    End Sub


End Class