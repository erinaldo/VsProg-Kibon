Option Strict Off
Option Explicit On
Friend Class clsBloco


    Public NumeroDoBloco As Integer
    Public Descricao As String
    Public MyParametros As New clsParametros
    Public Mnemonico As String

    Public Function LeModelo(Area As String, BlkNum As Integer) As Boolean

        Dim Param As clsParametro


        'Carrega dados do MyReceita
        Dim DbRc As New Geral.nsReceitas.dcReceitas
        Dim dtBlocos = (From It In DbRc.Blocos Where It.Area = Area And It.BlkNum = BlkNum).ToList
        'Dim dtBlocos = (From It In DbRc.Blocos Where It.BlkNum = BlkNum).ToList

        NumeroDoBloco = BlkNum
        Descricao = dtBlocos.First.BlkDescr
        Mnemonico = dtBlocos.First.Mnemonico


        'Carrega parametros
        Dim dtBlocosItens = (From It In DbRc.BlocosItens Where It.Area = Area And It.BlkNum = BlkNum Order By It.ItemSeq).ToList

        For Each Rec In dtBlocosItens

            Param = New clsParametro
            MyParametros.mCol.Add(Param)

            Param.Descricao = Rec.ItemDescr
            Param.UnidadeEngenharia = Rec.UEng

            Param.Valor = Rec.ValorDefault
            Param.Multiplic = Rec.Multiplic
            Param.FlagPeso = Rec.FlagPeso

        Next

        Return True

    End Function


End Class