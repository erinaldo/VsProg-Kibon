Public Class clsReceita

    Public Area As String
    Public RecNum As Integer
    Public RecNome As String
    Public RecDescr As String
    Public Codigo As String
    Public PesoRefer As Double
    Public Densidade As Double
    Public Pasta As String
    Public Subpasta As String
    Public Pressao01 As Double
    Public Pressao02 As Double
    Public Habilitada As Integer

    Public Blocos As List(Of clsRcBlk)

    Public dtRec As New List(Of Geral.nsReceitas.Rec)
    Public dtRecBlocos As New List(Of Geral.nsReceitas.RecBlocos)
    Public dtRecIngred As New List(Of Geral.nsReceitas.RecIngred)
    Public dtRecIngredMat As New List(Of Geral.nsReceitas.RecIngredMat)

    Public rcBanco As New Geral.nsReceitas.dcReceitas

    'Lista que armazena os IDs das ordens que ja foram atualizadas, para que nao atualize novamente a mesma ordem
    Private listaIDsAtualizados As New List(Of Integer)

    Sub New()
        'declara area de memoria
    End Sub

    Sub New(ByVal MyArea As String, ByVal MyRecNum As Integer)
        Abre(MyArea, MyRecNum)
    End Sub

    Public Function Abre(ByVal Area As String, ByVal RecNum As Integer) As Boolean

        'Dados da receita
        Me.Area = Area
        Me.RecNum = RecNum

        'Carrega cadastro da Area selecionada
        dtRec = (From It In rcBanco.Rec Where It.Area = Area And It.RecNum = RecNum).ToList

        If dtRec.Count <= 0 Then Return False

        RecNome = dtRec(0).RecNome
        RecDescr = dtRec(0).RecDescr
        Codigo = dtRec(0).Codigo
        PesoRefer = dtRec(0).PesoRefer
        Densidade = dtRec(0).Densidade
        Pasta = dtRec(0).Pasta
        Subpasta = dtRec(0).Subpasta
        Pressao01 = dtRec(0).Pressao01
        Pressao02 = dtRec(0).Pressao02
        Habilitada = dtRec(0).Habilita

        'Carrega dados dos blocos
        dtRecBlocos = (From It In rcBanco.RecBlocos Where It.Area = Area And It.RecNum = RecNum).ToList

        Blocos = New List(Of clsRcBlk)

        For Each Reg In dtRecBlocos

            Dim MyBlk As New clsRcBlk(Me, Area, Reg.BlkNum)

            Blocos.Add(MyBlk)

            If MyBlk.Param.Count >= 1 Then MyBlk.Param(0).Valor = Reg.Param01
            If MyBlk.Param.Count >= 2 Then MyBlk.Param(1).Valor = Reg.Param02
            If MyBlk.Param.Count >= 3 Then MyBlk.Param(2).Valor = Reg.Param03
            If MyBlk.Param.Count >= 4 Then MyBlk.Param(3).Valor = Reg.Param04
            If MyBlk.Param.Count >= 5 Then MyBlk.Param(4).Valor = Reg.Param05
            If MyBlk.Param.Count >= 6 Then MyBlk.Param(5).Valor = Reg.Param06
            If MyBlk.Param.Count >= 7 Then MyBlk.Param(6).Valor = Reg.Param07
            If MyBlk.Param.Count >= 8 Then MyBlk.Param(7).Valor = Reg.Param08
            If MyBlk.Param.Count >= 9 Then MyBlk.Param(8).Valor = Reg.Param09

        Next

        'Carrega dados dos Ingredientes e Ingredientes de Maturadores
        dtRecIngred = (From It In rcBanco.RecIngred Where It.Area = Area And It.RecNum = RecNum Order By It.ItemSeq).ToList
        dtRecIngredMat = (From It In rcBanco.RecIngredMat Where It.Area = Area And It.RecNum = RecNum Order By It.ItemSeq).ToList

        Return True

    End Function

    Public Function IncluirBloco(ByVal BlkNum As Integer) As Boolean

        Dim MyBlk As New clsRcBlk(Me, Me.Area, BlkNum)

        If IsNothing(Me.Blocos) = True Then
            Blocos = New List(Of clsRcBlk)
        End If

        Blocos.Add(MyBlk)

        Return True

    End Function

    Public Function ComparaDouble(ByVal Valor As Double) As Boolean

        Dim Precisao As Double = 0.5

        If Valor >= (100 - Precisao) And Valor <= (100 + Precisao) Then

            Return True

        Else

            Return False

        End If


    End Function

    Public Function SomaQtd() As Double

        Dim PorcTotal As Double = 0
        Dim TemParametroDePeso As Boolean = False

        Dim PegaMaturacao As Boolean = False

        If Me.Blocos.Count <= 0 Then Return False

        'Soma todas as porcentagens do parâmetro de quantidade a dosar dos blocos
        For ContaBlk As Integer = 0 To Me.Blocos.Count - 1

            For ContaPrm As Integer = 0 To Me.Blocos(ContaBlk).Param.Count - 1

                With Me.Blocos(ContaBlk).Param(ContaPrm)

                    If .FlagPeso = 1 Then
                        TemParametroDePeso = True
                        PorcTotal = PorcTotal + .Valor

                        If PegaMaturacao = False Then
                            PegaMaturacao = True

                            rcBanco = New Geral.nsReceitas.dcReceitas

                            Dim rec = (Me.Blocos(ContaBlk)).ParentRc.RecNum
                            Dim percMat = (From It In rcBanco.RecIngredMat Where It.RecNum = rec Select It.Peso).ToList.Sum
                            PorcTotal = PorcTotal + percMat

                        End If

                    End If

                End With

            Next
        Next




        'Verfica se tem algum parametro de peso
        If TemParametroDePeso = False Then
            'Nao tem nenhum parametro de peso, nao precisa verificar se a soma deu 100%
            Return 100
        End If

        Return PorcTotal

    End Function

    Public Function Salvar() As Boolean

        'Verifica se o nome da receita é valido
        If RecNome = "" Then Return False

        Dim Ret1 As Boolean = Deletar()

        If Ret1 <> True Then Return False

        Dim Ret2 As Boolean = Duplicar(RecNum, False)

        If Ret2 <> True Then Return False

        listaIDsAtualizados.Clear()
        Return True

    End Function

    Public Function Duplicar(ByVal NewRecNum As Integer, ByVal RecNova As Boolean) As Boolean
        'RecNova = true  --> duplicando dados para nova receita
        'RecNova = false --> salvando dados da receita existente

        rcBanco = New Geral.nsReceitas.dcReceitas

        'Verifica se o nome da receita é valido
        If RecNome = "" Then Return False

        Dim Prm01 As Double
        Dim Prm02 As Double
        Dim Prm03 As Double
        Dim Prm04 As Double
        Dim Prm05 As Double
        Dim Prm06 As Double
        Dim Prm07 As Double
        Dim Prm08 As Double
        Dim Prm09 As Double

        Dim Pesq = (From It In rcBanco.Rec Where It.RecNum = NewRecNum).ToList

        If RecNova = True Then
            If Pesq.Count >= 1 Then
                MsgBox("Atenção: Número de receita já existente no sistema! Escolha outro número.", MsgBoxStyle.Critical, "Editor de Receita")
                Return False
            End If
        End If


        'Escreve novos dados nas tabelas
        Dim RegRec As New Geral.nsReceitas.Rec

        With RegRec

            .Area = Area
            .RecNum = NewRecNum
            .RecNome = Strings.Left(RecNome, 30)
            .RecDescr = RecDescr
            .Codigo = Codigo
            .PesoRefer = Util.UtConvDecimalVigPonto(PesoRefer)
            .Densidade = Util.UtConvDecimalVigPonto(Densidade)
            .Pasta = Pasta
            .Subpasta = Subpasta
            .Pressao01 = Pressao01
            .Pressao02 = Pressao02
            .Habilita = Habilitada

        End With

        rcBanco.Rec.InsertOnSubmit(RegRec)


        'Escreve na tabela RecBlocos
        For Conta As Integer = 0 To Me.Blocos.Count - 1

            Dim RegBlocos As New Geral.nsReceitas.RecBlocos

            Prm01 = 0.0 : Prm02 = 0.0 : Prm03 = 0.0 : Prm04 = 0.0 : Prm05 = 0.0
            Prm06 = 0.0 : Prm07 = 0.0 : Prm08 = 0.0 : Prm09 = 0.0

            With Me.Blocos(Conta)

                If .Param.Count >= 1 Then Prm01 = .Param(0).Valor
                If .Param.Count >= 2 Then Prm02 = .Param(1).Valor
                If .Param.Count >= 3 Then Prm03 = .Param(2).Valor
                If .Param.Count >= 4 Then Prm04 = .Param(3).Valor
                If .Param.Count >= 5 Then Prm05 = .Param(4).Valor
                If .Param.Count >= 6 Then Prm06 = .Param(5).Valor
                If .Param.Count >= 7 Then Prm07 = .Param(6).Valor
                If .Param.Count >= 8 Then Prm08 = .Param(7).Valor
                If .Param.Count >= 9 Then Prm09 = .Param(8).Valor

            End With

            With RegBlocos

                .Area = Area
                .RecNum = Util.UtConvDecimalVigPonto(NewRecNum)
                .ItemSeq = CLng(Conta + 1)
                .BlkNum = Me.Blocos(Conta).BlkNum
                .Param01 = Util.UtConvDecimalVigPonto(Prm01)
                .Param02 = Util.UtConvDecimalVigPonto(Prm02)
                .Param03 = Util.UtConvDecimalVigPonto(Prm03)
                .Param04 = Util.UtConvDecimalVigPonto(Prm04)
                .Param05 = Util.UtConvDecimalVigPonto(Prm05)
                .Param06 = Util.UtConvDecimalVigPonto(Prm06)
                .Param07 = Util.UtConvDecimalVigPonto(Prm07)
                .Param08 = Util.UtConvDecimalVigPonto(Prm08)
                .Param09 = Util.UtConvDecimalVigPonto(Prm09)


            End With


            ''MAURICIO ---- ATUALIZAR TABELA CPI_CadastroPequenosIngredientes o campo CPI_SeqPequenoIngr, toda vez que atualizar uma receita existente na tabela.
            'For Each Reg In dtRecBlocos

            '    If (Reg.BlkNum = 2017 And Reg.Param01 = Prm01 And Reg.Param02 = Prm02 And Reg.Param03 = Prm03 And Reg.Param04 = Prm04 And Reg.Param05 = Prm05 And Reg.Param06 = Prm06 And Reg.Param07 = Prm07 And Reg.Param08 = Prm08 And Reg.Param09 = Prm09) Then


            '        'Query para buscar a ordem na tabela CPI_CadastroPequenosIngr e verificar se o bloco é o mesmo
            '        Dim ordemDesatualizada = (From CPI In rcBanco.tb_CPI_CadastroPequenoIngrediente Where CPI.CPI_SeqPequenoIngr = Reg.ItemSeq And CPI.RecNum = RegBlocos.RecNum
            '                                  Select CPI).ToList()

            '        If ordemDesatualizada IsNot Nothing Then
            '            For Each ordem In ordemDesatualizada
            '                If listaIDsAtualizados.Contains(ordem.CPI_ID) = False Then
            '                    ordem.CPI_SeqPequenoIngr = RegBlocos.ItemSeq
            '                    rcBanco.SubmitChanges()
            '                    listaIDsAtualizados.Add(ordem.CPI_ID)
            '                End If
            '            Next

            '        End If

            '    End If

            'Next

            rcBanco.RecBlocos.InsertOnSubmit(RegBlocos)

        Next


        'Escreve na tabela RecIngred
        For Conta As Integer = 0 To dtRecIngred.Count - 1

            Dim RecIngred As New Geral.nsReceitas.RecIngred

            With RecIngred

                .Area = Area
                .RecNum = Util.UtConvDecimalVigPonto(NewRecNum)
                .ItemSeq = CLng(Conta + 1)
                .IngrCodigo = dtRecIngred(Conta).IngrCodigo
                .Peso = dtRecIngred(Conta).Peso

            End With

            rcBanco.RecIngred.InsertOnSubmit(RecIngred)

        Next

        'Escreve na tabela RecIngredMat
        For Conta As Integer = 0 To dtRecIngredMat.Count - 1

            Dim RecIngredMat As New Geral.nsReceitas.RecIngredMat

            With RecIngredMat

                .Area = Area
                .RecNum = Util.UtConvDecimalVigPonto(NewRecNum)
                .ItemSeq = CLng(Conta + 1)
                .IngrCodigo = dtRecIngredMat(Conta).IngrCodigo
                .Peso = dtRecIngredMat(Conta).Peso

            End With

            rcBanco.RecIngredMat.InsertOnSubmit(RecIngredMat)

        Next

        If NewRecNum <> RecNum Then

            'Escreve na tabela de AlergenciosRec
            Dim dtReceitaAlerg = (From It In rcBanco.AlergenicosRec Where It.Area = Area And It.RecNum = RecNum).ToList
            For Each AlergRec In dtReceitaAlerg
                rcBanco.AlergenicosRec.InsertOnSubmit(New Geral.nsReceitas.AlergenicosRec With {.CodAlergenico = AlergRec.CodAlergenico, .Area = Area, .RecNum = NewRecNum, .CodigoRec = Codigo})
            Next

        End If

        rcBanco.SubmitChanges()

        Return True

    End Function

    Public Function Deletar() As Boolean

        'Verifica se o nome da receita é valido
        If RecNome = "" Then Return False

        'Apaga dados da receita
        Dim DelArea = (From It In rcBanco.Rec Where It.Area = Area And It.RecNum = RecNum).ToList
        rcBanco.Rec.DeleteAllOnSubmit(DelArea)

        Dim DelBlocos = (From It In rcBanco.RecBlocos Where It.Area = Area And It.RecNum = RecNum).ToList
        rcBanco.RecBlocos.DeleteAllOnSubmit(DelBlocos)

        Dim DelIngred = (From It In rcBanco.RecIngred Where It.Area = Area And It.RecNum = RecNum).ToList
        rcBanco.RecIngred.DeleteAllOnSubmit(DelIngred)

        Dim DelIngredMat = (From It In rcBanco.RecIngredMat Where It.Area = Area And It.RecNum = RecNum).ToList
        rcBanco.RecIngredMat.DeleteAllOnSubmit(DelIngredMat)

        'Dim dtReceitaAlerg = (From It In rcBanco.AlergenicosRec Where It.Area = Area And It.RecNum = RecNum).ToList
        'rcBanco.AlergenicosRec.DeleteAllOnSubmit(dtReceitaAlerg)

        rcBanco.SubmitChanges()

        Return True

    End Function

End Class

Public Class clsRcBlk

    Public ParentRc As clsReceita
    Public BlkNum As Integer
    Public BlkDescr As String
    Public Mnemonico As String
    Public Param As New List(Of clsRcBlkPrm)

    Sub New(ByVal MyRc As clsReceita, ByVal MyArea As String, ByVal MyBlkNum As Integer)

        ParentRc = MyRc
        BlkNum = MyBlkNum

        'Busca dados da tabela Blocos
        Dim arBlocos = (From It In ParentRc.rcBanco.Blocos Where It.Area = MyArea And It.BlkNum = MyBlkNum).ToList

        If arBlocos.Count <= 0 Then Return

        BlkDescr = arBlocos(0).BlkDescr
        Mnemonico = arBlocos(0).Mnemonico

        'Busca dados da tabela BlocosItens
        Dim arBlocosItens = (From It In ParentRc.rcBanco.BlocosItens Where It.Area = MyArea And It.BlkNum = MyBlkNum).ToList

        For Conta As Integer = 0 To arBlocosItens.Count - 1

            Dim MyBlk As New clsRcBlkPrm(ParentRc, BlkNum, arBlocosItens(Conta).ItemDescr,
                    arBlocosItens(Conta).UEng, arBlocosItens(Conta).ValorDefault,
                    arBlocosItens(Conta).Multiplic, arBlocosItens(Conta).FlagPeso)

            Param.Add(MyBlk)

        Next

    End Sub

End Class

Public Class clsRcBlkPrm

    Public ParentRc As clsReceita
    Public BlkNum As Integer
    Public ItemDescr As String
    Public UEng As String
    Public ValorDefault As Double
    Public Multiplic As Double
    Public FlagPeso As Integer
    Public Valor As Double

    Sub New(ByVal ParentRc As clsReceita, ByVal BlkNum As Integer,
            ByVal ItemDescr As String, ByVal UEng As String, ByVal ValorDefault As Double,
            ByVal Multiplic As Double, ByVal FlagPeso As Integer)

        Me.ParentRc = ParentRc
        Me.BlkNum = BlkNum
        Me.ItemDescr = ItemDescr
        Me.UEng = UEng
        Me.ValorDefault = ValorDefault
        Me.Multiplic = Multiplic
        Me.FlagPeso = FlagPeso
        Me.Valor = ValorDefault

    End Sub

End Class

