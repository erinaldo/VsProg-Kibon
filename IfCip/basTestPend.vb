Module basTestPend

    Public Function TestaAnormOk(ByVal CipId As Integer) As Boolean

        Dim DbCv As New Geral.nsCipValid.dcCipValid
        Dim dtCipHistAnorm = (From It In DbCv.CipHistAnorm Where It.CipId = CipId And It.ObsSts <> 2 Order By It.AnormId).ToList

        For Conta As Integer = 0 To dtCipHistAnorm.Count - 1

            If dtCipHistAnorm(Conta).ObsSts = 0 Then
                Return False
            End If
        Next

        Return True

    End Function

    Public Function TestaPtoCrOk(ByVal CipId As Integer) As Boolean

        'Verifica se todos os pontos criticos foram respondidos
        Dim DbCv As New Geral.nsCipValid.dcCipValid
        Dim dtCipHistPtoCr = (From It In DbCv.CipHistPtoCr Where It.CipId = CipId Order By It.PtoCrId).ToList

        For Conta As Integer = 0 To dtCipHistPtoCr.Count - 1

            If dtCipHistPtoCr(Conta).Resp = 0 Then
                Return False
            End If
        Next

        Return True

    End Function

End Module
