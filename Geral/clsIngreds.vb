Public Class clsIngreds

    'local variable to hold collection
    Public mCol As Collection

    Public Function Add(ByVal Codigo As String, ByVal Nome As String, ByVal Peso As Double, _
                        Optional ByVal sKey As String = "", Optional ByVal Before As VariantType = Nothing, _
                        Optional ByVal After As VariantType = Nothing) As clsIngred

        'create a new object
        Dim objNewMember As New clsIngred

        'set the properties passed into the method
        objNewMember.Codigo = Codigo
        objNewMember.Nome = Nome
        objNewMember.Peso = Peso

        'set the properties passed into the method
        If Len(sKey) = 0 Then
            mCol.Add(objNewMember)
        Else
            mCol.Add(objNewMember, sKey, Before, After)
        End If

        'return the object created
        Add = objNewMember
        objNewMember = Nothing


    End Function

    Public ReadOnly Property Item(ByVal vntIndexKey As Object) As clsIngred
        'used when referencing an element in the collection
        'vntIndexKey contains either the Index or Key to the collection,
        'this is why it is declared as a Variant
        'Syntax: Set foo = x.Item(xyz) or Set foo = x.Item(5)
        Get
            Item = mCol(vntIndexKey)
        End Get

    End Property

    Public ReadOnly Property Count() As Long
        'used when retrieving the number of elements in the
        'collection. Syntax: Debug.Print x.Count
        Get
            Count = mCol.Count
        End Get

    End Property

    Public Sub Remove(ByVal vntIndexKey As Object)
        'used when removing an element from the collection
        'vntIndexKey contains either the Index or Key, which is why
        'it is declared as a Variant
        'Syntax: x.Remove(xyz)

        If vntIndexKey > 0 Then

            mCol.Remove(vntIndexKey)

        End If

    End Sub

    'Public Property Get NewEnum() As IUnknown
    '        'this property allows you to enumerate
    '        'this collection with the For...Each syntax
    '    Set NewEnum = mCol.[_NewEnum]
    'End Property

    Public Function GetEnumerator() As System.Collections.IEnumerator

        GetEnumerator = mCol.GetEnumerator

    End Function

    Public Sub New()

        MyBase.New()

        'creates the collection when this class is created
        mCol = New Collection

    End Sub

    Protected Overrides Sub Finalize()

        'destroys collection when this class is terminated
        mCol = Nothing

        MyBase.Finalize()

    End Sub

    'Public Function ListaCarrega(ByVal ReceitaNum As Integer) As Boolean

    '    Dim BD As New Geral.dcReceita

    '    'Reseta a lista de ingredientes da receita
    '    Dim myIngreds = New clsIngreds

    '    Dim myArea As String = "CIP"

    '    'Dim myRegs = From tRecIngred In BD.RecIngred, tIngred In BD.Ingred Where tRecIngred.RecNum = ReceitaNum And _
    '    '              tRecIngred.IngrCodigo = tIngred.IngrCodigo And tRecIngred.Area = "CIP" Order By tRecIngred.ItemSeq

    '    Dim myRegs = From tRecIngred In BD.RecIngred Where tRecIngred.RecNum = ReceitaNum And tRecIngred.Area = "CIP" Order By tRecIngred.ItemSeq

    '    For Each Reg In myRegs

    '        myIngreds.Add(Trim(Reg.IngrCodigo), Reg.IngrCodigo, Reg.Peso, Trim(Reg.IngrCodigo))

    '    Next

    '    Return True

    'End Function

    'Public Function ListaSalva(ByVal ReceitaNum As Integer) As Boolean

    '    'Dim myArea As String = AreaDados("Area")

    '    Dim BD As New Geral.dcReceita

    '    'carrega registros antigos que serão apagados
    '    'Dim myLista = (From It In BD.RecIngred Where It.RecNum = ReceitaNum And It.Area = myArea).ToList

    '    'apaga registros
    '    'BD.RecIngred.DeleteAllOnSubmit(myLista)

    '    'Insere registros atualizados
    '    Dim myRegNovo As New Geral.RecIngred

    '    'myRegNovo.Area = myArea
    '    myRegNovo.RecNum = ReceitaNum
    '    'myRegNovo.ItemSeq = itemseq
    '    'myRegNovo.IngrCodigo = codigo
    '    'myRegNovo.Peso = peso

    '    BD.RecIngred.InsertOnSubmit(myRegNovo)

    '    BD.SubmitChanges()

    '    Return True

    'End Function

End Class
