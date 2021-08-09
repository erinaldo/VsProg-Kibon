Public Class clsBloco

    Public NumeroDoBloco As Integer
    Public Descricao As String
    Public MyParametros As New clsParametros
    Public Mnemonico As String

    Public Function LeModelo(Area As String, BlkNum As Integer) As Boolean

        Dim Param As clsParametro

        Dim DbRc As New Geral.nsReceitas.dcReceitas
        Dim dtBlocos = (From It In DbRc.Blocos Where It.BlkNum = BlkNum And It.Area = Area).ToList
        Dim Rec = dtBlocos.First

        'On Error Resume Next // Ivan ... 2018.04.02 Removido para adequação .Net
        Try
            NumeroDoBloco = BlkNum
            Descricao = Rec.BlkDescr
            Mnemonico = Rec.Mnemonico
        Catch

        End Try

        'Carrega parametros
        Dim dtBlocosItens = (From It In DbRc.BlocosItens Where It.BlkNum = BlkNum And It.Area = Area Order By It.ItemSeq).ToList

        For Each Bi In dtBlocosItens

            Param = New clsParametro
            MyParametros.mCol.Add(Param)

            'On Error Resume Next // Ivan ... 2018.04.02 Removido para adequação .Net
            Try
                Param.Descricao = Bi.ItemDescr
                Param.UnidadeEngenharia = Bi.UEng


                Param.VlDefault = Bi.ValorDefault
                Param.Valor = Bi.ValorDefault
                Param.Multiplic = Bi.Multiplic
                Param.FlagPeso = Bi.FlagPeso
            Catch

            End Try
        Next

        Return True

    End Function

End Class
