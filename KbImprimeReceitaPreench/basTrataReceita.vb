
Module basTrataReceita

    Function RecAbre(Area As String, RecNum As Integer, ByRef MyBlocos As clsBlocos,
                     ByRef RecCod As String, ByRef RecDescr As String, ByRef RecDens As Double) As Boolean

        'Abre o arquivo de receita

        Dim Blk As clsBloco

        'Buscando dados da receita
        Dim DbRc As New Geral.nsReceitas.dcReceitas
        Dim dtRec = (From It In DbRc.Rec Where It.RecNum = RecNum And It.Area = Area).ToList


        RecDescr = dtRec.First.RecDescr
        RecCod = dtRec.First.Codigo
        PesoRefer = TamBatch ' Rec!PesoRefer
        PesoReferImpr = dtRec.First.PesoRefer
        RecDens = dtRec.First.Densidade


        'Le itens da receita
        MyBlocos = New clsBlocos

        Dim dtRecBlocos = (From It In DbRc.RecBlocos Where It.Area = Area And It.RecNum = RecNum Order By It.ItemSeq).ToList

        For Each Rec In dtRecBlocos

            'Novo bloco
            Blk = New clsBloco
            MyBlocos.mCol.Add(Blk)
            Blk.LeModelo(Area, Rec.BlkNum)

            'Le valor de cada parametro
            For ContaParam = 0 To 8

                If ContaParam <= Blk.MyParametros.mCol.Count Then

                    If ContaParam < Blk.MyParametros.mCol.Count Then

                        Dim Valor = BuscaRecBlocosParam(Rec, ContaParam)
                        Blk.MyParametros.mCol(ContaParam).Valor = Valor * PesoRefer / 100.0#
                    End If

                End If
            Next

        Next

        Return True

    End Function

    Function BuscaRecBlocosParam(Rec As Geral.nsReceitas.RecBlocos, Param As Integer) As Double

        Dim Valor As Double = 0.0

        Select Case Param
            Case 0
                Valor = Rec.Param01
            Case 1
                Valor = Rec.Param02
            Case 2
                Valor = Rec.Param03
            Case 3
                Valor = Rec.Param04
            Case 4
                Valor = Rec.Param05
            Case 5
                Valor = Rec.Param06
            Case 6
                Valor = Rec.Param07
            Case 7
                Valor = Rec.Param08
            Case 8
                Valor = Rec.Param09
        End Select

        Return Valor

    End Function

End Module