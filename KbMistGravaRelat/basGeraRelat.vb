Module basGeraRelat

    Dim dtRec As List(Of Geral.nsReceitas.Rec)

    Sub MontaPlanilhaRelat(MyPlan As OfficeOpenXml.ExcelWorksheet, DataIniRel As String, DataFimRel As String)



        'O Excel suporta no maximo 32000 linhas. Em
        '    DataIni = CDate(ConvDataOrclVb(DataIniRel))
        '
        '    DataIniOrcl = ConvDataVbOrcl(Format(DataIni, "dd/mm/yyyy hh:nn:ss"))

        Dim DbRc As New Geral.nsReceitas.dcReceitas
        dtRec = (From It In DbRc.Rec Where It.Area = "Mistura" Order By It.RecNum).ToList

        'Atualiza planilha Rec0XX
        MontaPlanCabecalho(MyPlan, DataIniRel, DataFimRel)

        MontaDados(MyPlan, DataIniRel, DataFimRel)

    End Sub

    Function MontaPlanCabecalho(MyPlan As OfficeOpenXml.ExcelWorksheet, DataIniRel As String, DataFimRel As String) As Boolean

        Dim InDataIni As String = Util.UtConvDataYmd(DataIniRel)
        Dim InDataFim As String = Util.UtConvDataYmd(DataFimRel)

        Dim DataIni As String = "'" & Format(InDataIni, "dd/MM/yy")
        Dim HoraIni As String = "'" & Format(InDataIni, "HH:mm")

        Dim DataFim As String = "'" & Format(InDataFim, "dd/MM/yy")
        Dim HoraFim As String = "'" & Format(InDataFim, "HH:mm")

        'Dados do intervalo de relatório
        MyPlan.Cells("B3").Value = DataIni
        MyPlan.Cells("B4").Value = HoraIni
        MyPlan.Cells("B5").Value = DataFim
        MyPlan.Cells("B6").Value = HoraFim

        'Data da impressão
        Dim DataTxt As String = "'" & Format(Now, "dd/MM/yyyy")
        MyPlan.Cells("h5").Value = DataTxt

        'hora da impressão
        Dim HorasTxt As String = "'" & Format(Now, "HH:mm:ss")
        MyPlan.Cells("h6").Value = HorasTxt

        Return True

    End Function

    Function MontaDados(MyPlan As OfficeOpenXml.ExcelWorksheet, DataIniRel As String, DataFimRel As String)

        Dim ColOffset As Integer = 1

        'Obtem intervalo da pesquisa
        Dim DbMi As New Geral.nsMistGrava.dcMistGrava
        Dim dtProdMist = (From It In DbMi.ProdMist Where It.DataHoraMist >= DataIniRel And It.DataHoraMist <= DataFimRel
                          Order By It.DataHoraMist).ToList


        'Escreve dados no excel
        If dtProdMist.Count <= 0 Then Return False

        Dim Linha As Integer = 9

        For Each Rec In dtProdMist

            Dim RecNum As Integer = Rec.RecNum
            Dim MyRec = (From It In dtRec Where It.RecNum = RecNum).ToList

            'Arquiva na matriz os dados da pesquisa
            Dim DataTxtMist As String = Util.UtConvYmdData(Rec.DataHoraMist)
            Dim DataTxtTransf As String = Util.UtConvYmdData(Rec.DataHoraTransf)

            MyPlan.Cells(Linha, ColOffset + 0).Value = Left(DataTxtMist, 10)
            MyPlan.Cells(Linha, ColOffset + 1).Value = Mid(DataTxtMist, 12, 5)

            'On Error Resume Next // Ivan ... 2018.04.02 Removido para adequação .Net
            Try
                MyPlan.Cells(Linha, ColOffset + 2).Value = MyRec.First.Codigo              'Codigo da receita
                MyPlan.Cells(Linha, ColOffset + 3).Value = MyRec.First.RecDescr            'Descricao da receita
                MyPlan.Cells(Linha, ColOffset + 4).Value = Rec.Peso
                MyPlan.Cells(Linha, ColOffset + 5).Value = "TQ611" & Rec.TqOrigem
                If Rec.RecRej = 1 Then
                    'Rejeitado
                    MyPlan.Cells(Linha, ColOffset + 6).Value = "REJ"
                Else
                    'Ok
                    MyPlan.Cells(Linha, ColOffset + 6).Value = "TQ" & Rec.Dest
                End If
                MyPlan.Cells(Linha, ColOffset + 7).Value = Mid(DataTxtTransf, 12, 5)
                MyPlan.Cells(Linha, ColOffset + 8).Value = Rec.Past
            Catch

            End Try

            'Proxima linha
            '        conta_linha = conta_linha + 2

            Linha = Linha + 1

        Next


        'Escreve no excel
        'Dim PosIni As String = "A" & 9
        'Dim PosFim As String = "I" & 9 + Linha - 1
        'Dim MyRange As String = PosIni & ":" & PosFim

        'MyPlan.Cells(MyRange).Value = MyPlan.Cells

        Return True

    End Function

End Module
