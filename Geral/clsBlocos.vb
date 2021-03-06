Public Class clsBlocos

    'local variable to hold collection
    Public mCol As Collection

    Public Function Add(Optional ByVal sKey As String = "", Optional ByVal Before As VariantType = Nothing, Optional ByVal After As VariantType = Nothing) As clsBloco

        'create a new object
        Dim objNewMember As New clsBloco

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

    Public ReadOnly Property Item(ByVal vntIndexKey As Object) As clsBloco
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

End Class
