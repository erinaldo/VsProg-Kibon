Public Class clsAreas

    Public Area As List(Of clsArea)

    Dim arBanco As New Geral.nsReceitas.dcReceitas

    Sub New()
        ' carrega todas as areas existentes no sistema

        Dim myAreas = (From It In arBanco.Areas).ToList

        If myAreas.Count <= 0 Then Return

        Area = New List(Of clsArea)

        For Each Reg In myAreas

            Dim NewArea As New clsArea

            NewArea.Area = Reg.Area
            NewArea.Descr = Reg.Descr
            NewArea.UsaIngredMan = Reg.UsaIngredMan
            NewArea.UsaPesoRef = Reg.UsaPesoRef
            NewArea.UsaPlanejBrix = Reg.UsaPlanejBrix
            NewArea.RsLinxTopic = Reg.RsLinxTopic

            Area.Add(NewArea)

        Next
    End Sub

    Public Function AreaNova(ByVal myArea As String, ByVal myDescr As String, ByVal myIngreMan As Integer, _
                        ByVal myPesoRef As Integer, ByVal myPlanejBrix As Integer, ByVal myLinxTopic As String) As Boolean

        'insere novo registro na classe
        Dim NewArea As New clsArea

        NewArea.Area = myArea
        NewArea.Descr = myDescr
        NewArea.UsaIngredMan = myIngreMan
        NewArea.UsaPesoRef = myPesoRef
        NewArea.UsaPlanejBrix = myPlanejBrix
        NewArea.RsLinxTopic = myLinxTopic

        Area.Add(NewArea)

        'insere novo registro no banco de dados
        Dim Reg As New Geral.nsReceitas.Areas

        Reg.Area = myArea
        Reg.Descr = myDescr
        Reg.RsLinxTopic = myLinxTopic
        Reg.UsaPlanejBrix = myPlanejBrix
        Reg.UsaIngredMan = myIngreMan
        Reg.UsaPesoRef = myPesoRef

        arBanco.Areas.InsertOnSubmit(Reg)

        arBanco.SubmitChanges()

        Return True

    End Function

    Public Function AreaRemove(ByVal myArea As String) As Boolean

        Dim Reg = (From It In arBanco.Areas Where It.Area = myArea).ToList

        arBanco.Areas.DeleteAllOnSubmit(Reg)

        arBanco.SubmitChanges()

        For Conta As Integer = 0 To Me.Area.Count - 1

            If Me.Area(Conta).Area.ToUpper = myArea.ToUpper Then

                Me.Area.RemoveAt(Conta)
                Exit For
            End If
        Next

        Return True

    End Function

    Public Function AreaAtualiza(ByVal myArea As String, ByVal myDesc As String, ByVal myLinx As String, _
                                 ByVal myBrix As Integer, ByVal myIngred As Integer, ByVal myPeso As Integer) As Boolean

        'atualiza registro na tabela do banco de dados
        Dim myReg = From It In arBanco.Areas Where It.Area = myArea

        For Each Reg In myReg

            Reg.Descr = myDesc
            Reg.RsLinxTopic = myLinx
            Reg.UsaPlanejBrix = myBrix
            Reg.UsaIngredMan = myIngred
            Reg.UsaPesoRef = myPeso

        Next

        arBanco.SubmitChanges()

        'pesquisa e atualiza registro na classe
        For Conta As Integer = 0 To Me.Area.Count - 1

            If Me.Area(Conta).Area.ToUpper = myArea.ToUpper Then

                With Me.Area(Conta)
                    .Descr = myDesc
                    .RsLinxTopic = myLinx
                    .UsaIngredMan = myIngred
                    .UsaPesoRef = myPeso
                    .UsaPlanejBrix = myBrix
                End With

                Exit For

            End If
        Next

        Return True

    End Function

End Class

Public Class clsArea

    Public Area As String
    Public Descr As String
    Public UsaPlanejBrix As Integer
    Public UsaIngredMan As Integer
    Public UsaPesoRef As Integer
    Public RsLinxTopic As String

End Class