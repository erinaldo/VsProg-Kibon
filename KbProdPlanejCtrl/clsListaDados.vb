Public Class clsListaDados
    'local variable to hold collection
    Private mCol As Collection

    Public Function Add(ByVal Dado0 As Object, _
              Optional ByVal Dado1 As Object = "", _
              Optional ByVal Dado2 As Object = "", _
              Optional ByVal Dado3 As Object = "", _
              Optional ByVal Dado4 As Object = "", _
              Optional ByVal Dado5 As Object = "", _
              Optional ByVal Dado6 As Object = "", _
              Optional ByVal Dado7 As Object = "", _
              Optional ByVal Dado8 As Object = "", _
              Optional ByVal Dado9 As Object = "", _
              Optional ByVal Dado10 As Object = "", _
              Optional ByVal Dado11 As Object = "", _
              Optional ByVal Dado12 As Object = "", _
              Optional ByVal Dado13 As Object = "", _
              Optional ByVal Dado14 As Object = "", _
              Optional ByVal Dado15 As Object = "", _
              Optional ByVal Dado16 As Object = "", _
              Optional ByVal Dado17 As Object = "", _
              Optional ByVal Dado18 As Object = "", _
              Optional ByVal Dado19 As Object = "", _
              Optional ByVal sKey As String = "") As clsListaDado

        'create a new object
        Dim objNewMember As clsListaDado
        objNewMember = New clsListaDado

        'set the properties passed into the method
        objNewMember.Dado0 = Dado0
        objNewMember.Dado1 = Dado1
        objNewMember.Dado2 = Dado2
        objNewMember.Dado3 = Dado3
        objNewMember.Dado4 = Dado4
        objNewMember.Dado5 = Dado5
        objNewMember.Dado6 = Dado6
        objNewMember.Dado7 = Dado7
        objNewMember.Dado8 = Dado8
        objNewMember.Dado9 = Dado9
        objNewMember.Dado10 = Dado10
        objNewMember.Dado11 = Dado11
        objNewMember.Dado12 = Dado12
        objNewMember.Dado13 = Dado13
        objNewMember.Dado14 = Dado14
        objNewMember.Dado15 = Dado15
        objNewMember.Dado16 = Dado16
        objNewMember.Dado17 = Dado17    'Alergenico
        objNewMember.Dado18 = Dado18    'Pressao Stg 01
        objNewMember.Dado19 = Dado19    'Pressao Stg 02


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

    Default Public ReadOnly Property Item(ByVal vntIndexKey As Object) As clsListaDado

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


    'Public ReadOnly Property NewEnum() As Enumerable
    '    'this property allows you to enumerate
    '    'this collection with the For...Each syntax
    '    Get
    '        NewEnum = mCol.NewEnum
    '    End Get
    '    'Set NewEnum = mCol.[_NewEnum]
    'End Property

    Public Function GetEnumerator() As System.Collections.IEnumerator 'Implements System.ICollection.IEnumerable.Generic

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
