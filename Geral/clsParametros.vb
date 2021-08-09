Public Class clsParametros

    'local variable to hold collection
    Private mCol As Collection

    Public Function Add(Optional ByVal sKey As String = "") As clsParametro
        'create a new object
        Dim objNewMember As clsParametro
        objNewMember = New clsParametro


        'set the properties passed into the method
        If Len(sKey) = 0 Then
            mCol.Add(objNewMember)
        Else
            mCol.Add(objNewMember, sKey)
        End If


        'return the object created
        Add = objNewMember
        objNewMember = Nothing


    End Function

    Default Public ReadOnly Property Item(ByVal vntIndexKey As Object) As clsParametro
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


        mCol.Remove(vntIndexKey)
    End Sub

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
