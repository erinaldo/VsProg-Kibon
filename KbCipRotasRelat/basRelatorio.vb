Module basRelatorio

    Dim myEpplus As OfficeOpenXml.ExcelPackage
    Dim mySheet As OfficeOpenXml.ExcelWorksheet

    Dim ContaLinha As Integer

    Public Function MontaRelat() As Boolean

        Dim ArquivoCriado As String = ""
        CopiaModelo(ArquivoCriado)

        Dim myFile As New System.IO.FileInfo(ArquivoCriado)

        myEpplus = New OfficeOpenXml.ExcelPackage(myFile)

        mySheet = myEpplus.Workbook.Worksheets("Rotas")

        MontaIndice()

        CriaPlans()

        MontaRotas()

        mySheet.Protection.SetPassword(Geral.SENHA_PROTEGE_PLAN)

        myEpplus.Save()
        myEpplus = Nothing


        Dim Resp As MsgBoxResult = MsgBox("Deseja visualizar o relatório ?", MsgBoxStyle.Question + MsgBoxStyle.YesNo)

        If Resp = MsgBoxResult.Yes Then

            Geral.AbreXlsx(ArquivoCriado)

        End If

        Return True

    End Function

    Private Function MontaIndice() As Boolean

        'escreve data no cabeçalho
        mySheet.Cells(3, 9).Value = Format(Now, "dd/MM/yyyy")

        ContaLinha = 5

        For Each Reg In frmCipRotasRelat.dtCipCadRota


            mySheet.Cells(ContaLinha, 2).Value = Reg.RotaId

            mySheet.Cells(ContaLinha, 3).Value = Reg.Circ

            mySheet.Cells(ContaLinha, 4).Value = Reg.Descr

            mySheet.Cells(ContaLinha, 5).Value = Reg.Tipo

            mySheet.Cells(ContaLinha, 6).Value = Reg.Tq1

            mySheet.Cells(ContaLinha, 7).Value = Reg.Tq2

            mySheet.Cells(ContaLinha, 8).Value = Reg.Tq3

            ContaLinha = ContaLinha + 1

        Next

        Return True

    End Function

    Private Function MontaRotas() As Boolean

        For Conta As Integer = 0 To frmCipRotasRelat.dtCipCadRota.Count - 1
            
            ContaLinha = 10

            Dim Planilha As String = NomePlanilha(Conta)

            mySheet = myEpplus.Workbook.Worksheets(Planilha)

            With frmCipRotasRelat.dtCipCadRota.Item(Conta)

                MontaRotaCabecalho(.RotaId, .Descr, .Circ, .Tipo, .Tq1, .Tq2, .Tq3)

                MontaRotaValv(.RotaId, 1)       'valvulas acionadas
                MontaRotaValv(.RotaId, 2)       'valvulas desacionadas
                MontaRotaValv(.RotaId, 3)       'valvulas flip

                MontaRotaMot(.RotaId)

                MontaRotaDepend(.RotaId)

            End With

        Next

        Return True

    End Function

    Private Function NomePlanilha(ByVal Idx As Integer) As String

        Dim RotaId As Integer
        Try
            RotaId = frmCipRotasRelat.dtCipCadRota.Item(Idx).RotaId
        Catch
            RotaId = 0
        End Try

        Return "Rota" & Format(RotaId, "000")

    End Function

    Private Sub CriaPlans()

        'Cria uma planilha para cada rota copiando a planilha 2 "Rota001"
        For Conta As Integer = 0 To frmCipRotasRelat.dtCipCadRota.Count - 1

            Dim NovaPlan As String = NomePlanilha(Conta)

            'Copia planilha modelo para a segunda receita em diante
            Try : myEpplus.Workbook.Worksheets.Copy("Rota001", NovaPlan) : Catch : End Try

        Next

    End Sub

    Private Sub MontaRotaCabecalho(ByVal RotaId As String, ByVal Descr As String, ByVal Circ As String, _
                                   ByVal Tipo As String, ByVal Tq1 As String, ByVal Tq2 As String, ByVal Tq3 As String)


        'Data
        mySheet.Cells(7, 7).Value = Format(Now, "dd/MM/yyyy")

        'Dados da receita
        mySheet.Cells(3, 3).Value = RotaId
        mySheet.Cells(4, 3).Value = Descr
        mySheet.Cells(5, 3).Value = Circ
        mySheet.Cells(6, 3).Value = Tipo
        mySheet.Cells(7, 3).Value = Tq1
        mySheet.Cells(7, 4).Value = Tq2
        mySheet.Cells(7, 5).Value = Tq3

    End Sub

    Private Sub MontaRotaValv(ByVal RotaId As Integer, ByVal TipoValvula As Integer)

        Dim myRotaValv As New List(Of Geral.nsCipRotas.RotaValv)

        Select Case TipoValvula
            Case 1
                myRotaValv = (From itRota In frmCipRotasRelat.BdRotas.RotaValv _
                          Where itRota.RotaId = RotaId And itRota.Tipo = "A" Order By itRota.Tag).ToList

            Case 2
                myRotaValv = (From It In frmCipRotasRelat.BdRotas.RotaValv _
                          Where It.RotaId = RotaId And It.Tipo = "N" Order By It.Tag).ToList

            Case 3
                myRotaValv = (From It In frmCipRotasRelat.BdRotas.RotaValv _
                          Where It.RotaId = RotaId And It.Tipo Like "F*" Order By It.Tag).ToList

        End Select

        Select Case TipoValvula
            Case 1
                mySheet.Cells(ContaLinha, 1).Value = "Valvulas Acionadas"
            Case 2
                mySheet.Cells(ContaLinha, 1).Value = "Valvulas Não Acionadas"
            Case 3
                mySheet.Cells(ContaLinha, 1).Value = "Valvulas com Flip"
        End Select
        ContaLinha = ContaLinha + 1

        Dim PlcNum As Integer
        Dim PlcIdx As Integer
        Dim Descr As String = ""

        For Each Valvula In myRotaValv

            BuscaValvula(Valvula.Tag, PlcNum, PlcIdx, Descr)

            mySheet.Cells(ContaLinha, 2).Value = Valvula.Tag

            mySheet.Cells(ContaLinha, 3).Value = ""

            mySheet.Cells(ContaLinha, 4).Value = PlcNum
            mySheet.Cells(ContaLinha, 4).Style.Numberformat.Format = "0"

            mySheet.Cells(ContaLinha, 5).Value = PlcIdx
            mySheet.Cells(ContaLinha, 5).Style.Numberformat.Format = "0"

            mySheet.Cells(ContaLinha, 6).Value = Descr

            ContaLinha = ContaLinha + 1

        Next

        ContaLinha = ContaLinha + 2

    End Sub

    Private Sub MontaRotaMot(ByVal RotaId As Integer)

        Dim myRotaMot As New List(Of Geral.nsCipRotas.RotaMot)

        
        myRotaMot = (From itRota In frmCipRotasRelat.BdRotas.RotaMot _
                      Where itRota.RotaId = RotaId Order By itRota.Tag).ToList

           
        mySheet.Cells(ContaLinha, 1).Value = "Motores"
        ContaLinha = ContaLinha + 1

        Dim PlcNum As Integer
        Dim PlcIdx As Integer
        Dim Descr As String = ""

        For Each Motor In myRotaMot

            BuscaMotor(Motor.Tag, PlcNum, PlcIdx, Descr)

            mySheet.Cells(ContaLinha, 2).Value = Motor.Tag

            mySheet.Cells(ContaLinha, 3).Value = Motor.Tipo

            mySheet.Cells(ContaLinha, 4).Value = PlcNum
            mySheet.Cells(ContaLinha, 4).Style.Numberformat.Format = "0"

            mySheet.Cells(ContaLinha, 5).Value = PlcIdx
            mySheet.Cells(ContaLinha, 5).Style.Numberformat.Format = "0"

            mySheet.Cells(ContaLinha, 6).Value = Descr

            ContaLinha = ContaLinha + 1

        Next

        ContaLinha = ContaLinha + 2

    End Sub

    Private Sub MontaRotaDepend(ByVal RotaId As Integer)

        Dim myRotaDep As New List(Of Geral.nsCipRotas.RotaDepend)


        myRotaDep = (From itRota In frmCipRotasRelat.BdRotas.RotaDepend _
                      Where itRota.RotaId = RotaId Order By itRota.Tag).ToList


        mySheet.Cells(ContaLinha, 1).Value = "Dependencia de tanques e linhas"
        ContaLinha = ContaLinha + 1

        Dim PlcNum As Integer
        Dim PlcIdx As Integer
        Dim Descr As String = ""

        For Each Dep In myRotaDep

            BuscaDependencia(Dep.Tag, PlcNum, PlcIdx, Descr)

            mySheet.Cells(ContaLinha, 2).Value = Dep.Tag

            mySheet.Cells(ContaLinha, 3).Value = Dep.Tipo

            mySheet.Cells(ContaLinha, 4).Value = PlcNum
            mySheet.Cells(ContaLinha, 4).Style.Numberformat.Format = "0"

            mySheet.Cells(ContaLinha, 5).Value = PlcIdx
            mySheet.Cells(ContaLinha, 5).Style.Numberformat.Format = "0"

            mySheet.Cells(ContaLinha, 6).Value = Descr

            ContaLinha = ContaLinha + 1

        Next

        ContaLinha = ContaLinha + 2

    End Sub

    Private Function BuscaValvula(ByVal sTag As String, ByRef iPlcNum As Integer, ByRef iPlcIdx As Integer, ByRef sDescr As String) As Boolean

        Dim myCadValv = (From It In frmCipRotasRelat.BdRotas.ValvCad Where It.Tag = sTag).ToList

        Try
            iPlcIdx = myCadValv(0).PlcIdx.Value
            iPlcNum = myCadValv(0).PlcNum.Value
            sDescr = myCadValv(0).Descr
        Catch
            iPlcIdx = 0
            iPlcNum = 0
            sDescr = 0
        End Try

        Return True

    End Function

    Private Function BuscaMotor(ByVal sTag As String, ByRef iPlcNum As Integer, ByRef iPlcIdx As Integer, ByRef sDescr As String) As Boolean

        Dim myCadMot = (From It In frmCipRotasRelat.BdRotas.MotCad Where It.Tag = sTag).ToList

        Try
            iPlcIdx = myCadMot(0).PlcIdx.Value
            iPlcNum = myCadMot(0).PlcNum.Value
            sDescr = myCadMot(0).Descr
        Catch
            iPlcIdx = 0
            iPlcNum = 0
            sDescr = 0
        End Try

        Return True

    End Function

    Private Function BuscaDependencia(ByVal sTag As String, ByRef iPlcNum As Integer, ByRef iPlcIdx As Integer, ByRef sDescr As String) As Boolean

        Dim myCadTq = (From It In frmCipRotasRelat.BdRotas.TqCad Where It.Tag = sTag).ToList

        Try
            iPlcIdx = myCadTq(0).PlcIdx.Value
            iPlcNum = myCadTq(0).PlcNum.Value
            sDescr = myCadTq(0).Descr
        Catch
            iPlcIdx = 0
            iPlcNum = 0
            sDescr = 0
        End Try

        Return True

    End Function

End Module
