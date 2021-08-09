Public Class clsBloco

    Public Rc As New Geral.nsReceitas.dcReceitas

    Public NumeroDoBloco As Integer
    Public Descricao As String
    Public MyParametros As New clsParametros
    Public Mnemonico As String
    

    Public Function LeModelo(ByVal Area As String, ByVal BlkNum As Integer) As Boolean

        'Carrega dados do MyReceita
        Dim dtBlocos = (From It In Rc.Blocos Where It.BlkNum = BlkNum And It.Area = Area).ToList

        If dtBlocos.Count <= 0 Then Return False

        Try
            NumeroDoBloco = BlkNum
        Catch : End Try

        Descricao = dtBlocos(0).BlkDescr
        Mnemonico = dtBlocos(0).Mnemonico

        'Carrega parametros
        Dim dtBlocosItems = (From It In Rc.BlocosItens Where It.BlkNum = BlkNum And It.Area = Area Order By It.ItemSeq).ToList

        For Conta As Integer = 0 To dtBlocosItems.Count - 1

            Dim Param As New clsParametro
            MyParametros.mCol.Add(Param)

            Try

                Param.Descricao = dtBlocosItems(Conta).ItemDescr
                Param.UnidadeEngenharia = dtBlocosItems(Conta).UEng

            Catch ex As Exception
            End Try

            Param.ValorDefault = dtBlocosItems(Conta).ValorDefault
            Param.Valor = dtBlocosItems(Conta).ValorDefault
            Param.Multiplic = dtBlocosItems(Conta).Multiplic
            Param.FlagPeso = dtBlocosItems(Conta).FlagPeso

        Next

        Return True

    End Function

End Class
