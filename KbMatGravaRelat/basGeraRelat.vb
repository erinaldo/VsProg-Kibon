Module basGeraRelat

    Dim dtRec As List(Of Geral.nsReceitas.Rec)

    Sub MontaPlanilhaRelat(MyXl As OfficeOpenXml.ExcelPackage, DataIniRel As String, DataFimRel As String)

        Dim MyPlan As OfficeOpenXml.ExcelWorksheet
        Dim listDados As clsMatDados = Nothing

        'O Excel suporta no maximo 32000 linhas. Em
        '    DataIni = CDate(ConvDataOrclVb(DataIniRel))
        '
        '    DataIniOrcl = ConvDataVbOrcl(Format(DataIni, "dd/mm/yyyy hh:nn:ss"))

        Dim DbRc As New Geral.nsReceitas.dcReceitas
        dtRec = (From It In DbRc.Rec Where It.Area = "Mistura" Order By It.RecNum).ToList

        'Atualiza planilha Rec0XX
        MyPlan = MyXl.Workbook.Worksheets("Dados")

        'Busca dados hist
        PesquisaDados(DataIniRel, DataFimRel, listDados)

        'Monta planilhas
        MontaPlan(MyPlan, listDados)
        ControlRange(MyPlan)

    End Sub

    Private Function PesquisaDados(DataIniRel As String, DataFimRel As String, ByRef outListaDados As clsMatDados) As Boolean

        Dim Conta As Integer = 0

        Dim DbMt As New Geral.nsMatGrava.dcMatGrava
        Dim dtMatHistDados = (From It In DbMt.MatHistDados Where It.DataHora >= DataIniRel And
                              It.DataHora <= DataFimRel Order By It.DataHora).ToList

        outListaDados = New clsMatDados
        For Each Rec In dtMatHistDados

            Dim NwDd As New clsMatDado With {.DataHora = Rec.DataHora, .Tq = Rec.Tq, .SeqTq = Rec.SeqTq,
                                             .CodProd = Rec.CodProduto, .Temperatura = Rec.Temperatura,
                                             .HrsValidade = Rec.HrsValidade}
            outListaDados.mCol.Add(NwDd)

            Conta = Conta + 1

        Next

        If Conta >= 6000 Then

            MsgBox("Limite de intervalo de data muito grande, tente novamente e não utrapasse 10 dias de intervalo")

            End

        End If

        Return True

    End Function

    Private Function MontaPlan(MyPlan As OfficeOpenXml.ExcelWorksheet, listDados As clsMatDados) As Boolean

        Dim Col As Integer = 3
        Dim RowOffset As Integer = 6

        Dim ContaFim As Integer = (listDados.mCol.Count / 24)

        For Conta = 0 To ContaFim - 1

            Dim TQ6201 As String = BuscaRecCod(listDados.mCol(CalcPos(Conta, 23)).CodProd)
            Dim TQ6202 = BuscaRecCod(listDados.mCol(CalcPos(Conta, 22)).CodProd)
            Dim TQ6203 = BuscaRecCod(listDados.mCol(CalcPos(Conta, 21)).CodProd)
            Dim TQ6204 = BuscaRecCod(listDados.mCol(CalcPos(Conta, 20)).CodProd)
            Dim TQ6205 = BuscaRecCod(listDados.mCol(CalcPos(Conta, 19)).CodProd)
            Dim TQ6206 = BuscaRecCod(listDados.mCol(CalcPos(Conta, 18)).CodProd)
            Dim TQ6207 = BuscaRecCod(listDados.mCol(CalcPos(Conta, 17)).CodProd)
            Dim TQ6208 = BuscaRecCod(listDados.mCol(CalcPos(Conta, 16)).CodProd)
            Dim TQ6209 = BuscaRecCod(listDados.mCol(CalcPos(Conta, 15)).CodProd)
            Dim TQ6210 = BuscaRecCod(listDados.mCol(CalcPos(Conta, 14)).CodProd)
            Dim TQ6211 = BuscaRecCod(listDados.mCol(CalcPos(Conta, 13)).CodProd)
            Dim TQ6212 = BuscaRecCod(listDados.mCol(CalcPos(Conta, 12)).CodProd)
            Dim TQ6213 = BuscaRecCod(listDados.mCol(CalcPos(Conta, 11)).CodProd)
            Dim TQ6214 = BuscaRecCod(listDados.mCol(CalcPos(Conta, 10)).CodProd)
            Dim TQ6215 = BuscaRecCod(listDados.mCol(CalcPos(Conta, 9)).CodProd)
            Dim TQ6216 = BuscaRecCod(listDados.mCol(CalcPos(Conta, 8)).CodProd)
            Dim TQ6217 = BuscaRecCod(listDados.mCol(CalcPos(Conta, 7)).CodProd)
            Dim TQ6218 = BuscaRecCod(listDados.mCol(CalcPos(Conta, 6)).CodProd)
            Dim TQ6255 = BuscaRecCod(listDados.mCol(CalcPos(Conta, 5)).CodProd)
            Dim TQ6256 = BuscaRecCod(listDados.mCol(CalcPos(Conta, 4)).CodProd)
            Dim TQ6257 = BuscaRecCod(listDados.mCol(CalcPos(Conta, 3)).CodProd)
            Dim TQ6258 = BuscaRecCod(listDados.mCol(CalcPos(Conta, 2)).CodProd)
            Dim TQ6259 = BuscaRecCod(listDados.mCol(CalcPos(Conta, 1)).CodProd)
            Dim TQ6260 = BuscaRecCod(listDados.mCol(CalcPos(Conta, 0)).CodProd)

            MyPlan.Cells(RowOffset + 0, Col).Value = "'" & Util.UtConvYmdData(listDados.mCol(CalcPos(Conta, 23)).DataHora)

            If TQ6201 = "" Then
                MyPlan.Cells(RowOffset + 1, Col).Value = "-"
                MyPlan.Cells(RowOffset + 2, Col).Value = listDados.mCol(CalcPos(Conta, 23)).Temperatura
                MyPlan.Cells(RowOffset + 3, Col).Value = "Vazio"
                MyPlan.Cells(RowOffset + 4, Col).Value = "Vazio"
            Else
                MyPlan.Cells(RowOffset + 1, Col).Value = listDados.mCol(CalcPos(Conta, 23)).SeqTq
                MyPlan.Cells(RowOffset + 2, Col).Value = listDados.mCol(CalcPos(Conta, 23)).Temperatura
                If listDados.mCol(CalcPos(Conta, 23)).HrsValidade = 0 Then 'Caso seja um novo carregamento o tempo de validade é zerado
                    MyPlan.Cells(RowOffset + 3, Col).Value = "N/A"
                Else
                    MyPlan.Cells(RowOffset + 3, Col).Value = listDados.mCol(CalcPos(Conta, 23)).HrsValidade
                End If
                MyPlan.Cells(RowOffset + 4, Col).Value = BuscaRecCod(listDados.mCol(CalcPos(Conta, 23)).CodProd)
            End If

            If TQ6202 = "" Then
                MyPlan.Cells(RowOffset + 5, Col).Value = "-"
                MyPlan.Cells(RowOffset + 6, Col).Value = listDados.mCol(CalcPos(Conta, 22)).Temperatura
                MyPlan.Cells(RowOffset + 7, Col).Value = "Vazio"
                MyPlan.Cells(RowOffset + 8, Col).Value = "Vazio"
            Else
                MyPlan.Cells(RowOffset + 5, Col).Value = listDados.mCol(CalcPos(Conta, 22)).SeqTq
                MyPlan.Cells(RowOffset + 6, Col).Value = listDados.mCol(CalcPos(Conta, 22)).Temperatura
                If listDados.mCol(CalcPos(Conta, 22)).HrsValidade = 0 Then 'Caso seja um novo carregamento o tempo de validade é zerado
                    MyPlan.Cells(RowOffset + 7, Col).Value = "N/A"
                Else
                    MyPlan.Cells(RowOffset + 7, Col).Value = listDados.mCol(CalcPos(Conta, 22)).HrsValidade
                End If
                MyPlan.Cells(RowOffset + 8, Col).Value = BuscaRecCod(listDados.mCol(CalcPos(Conta, 22)).CodProd)
            End If

            If TQ6203 = "" Then
                MyPlan.Cells(RowOffset + 9, Col).Value = "-"
                MyPlan.Cells(RowOffset + 10, Col).Value = listDados.mCol(CalcPos(Conta, 21)).Temperatura
                MyPlan.Cells(RowOffset + 11, Col).Value = "Vazio"
                MyPlan.Cells(RowOffset + 12, Col).Value = "Vazio"
            Else
                MyPlan.Cells(RowOffset + 9, Col).Value = listDados.mCol(CalcPos(Conta, 21)).SeqTq
                MyPlan.Cells(RowOffset + 10, Col).Value = listDados.mCol(CalcPos(Conta, 21)).Temperatura
                If listDados.mCol(CalcPos(Conta, 21)).HrsValidade = 0 Then 'Caso seja um novo carregamento o tempo de validade é zerado
                    MyPlan.Cells(RowOffset + 11, Col).Value = "N/A"
                Else
                    MyPlan.Cells(RowOffset + 11, Col).Value = listDados.mCol(CalcPos(Conta, 21)).HrsValidade
                End If
                MyPlan.Cells(RowOffset + 12, Col).Value = BuscaRecCod(listDados.mCol(CalcPos(Conta, 21)).CodProd)
            End If

            If TQ6204 = "" Then
                MyPlan.Cells(RowOffset + 13, Col).Value = "-"
                MyPlan.Cells(RowOffset + 14, Col).Value = listDados.mCol(CalcPos(Conta, 20)).Temperatura
                MyPlan.Cells(RowOffset + 15, Col).Value = "Vazio"
                MyPlan.Cells(RowOffset + 16, Col).Value = "Vazio"
            Else
                MyPlan.Cells(RowOffset + 13, Col).Value = listDados.mCol(CalcPos(Conta, 20)).SeqTq
                MyPlan.Cells(RowOffset + 14, Col).Value = listDados.mCol(CalcPos(Conta, 20)).Temperatura
                If listDados.mCol(CalcPos(Conta, 20)).HrsValidade = 0 Then 'Caso seja um novo carregamento o tempo de validade é zerado
                    MyPlan.Cells(RowOffset + 15, Col).Value = "N/A"
                Else
                    MyPlan.Cells(RowOffset + 15, Col).Value = listDados.mCol(CalcPos(Conta, 20)).HrsValidade
                End If
                MyPlan.Cells(RowOffset + 16, Col).Value = BuscaRecCod(listDados.mCol(CalcPos(Conta, 20)).CodProd)
            End If

            If TQ6205 = "" Then
                MyPlan.Cells(RowOffset + 17, Col).Value = "-"
                MyPlan.Cells(RowOffset + 18, Col).Value = listDados.mCol(CalcPos(Conta, 19)).Temperatura
                MyPlan.Cells(RowOffset + 19, Col).Value = "Vazio"
                MyPlan.Cells(RowOffset + 20, Col).Value = "Vazio"
            Else
                MyPlan.Cells(RowOffset + 17, Col).Value = listDados.mCol(CalcPos(Conta, 19)).SeqTq
                MyPlan.Cells(RowOffset + 18, Col).Value = listDados.mCol(CalcPos(Conta, 19)).Temperatura
                If listDados.mCol(CalcPos(Conta, 19)).HrsValidade = 0 Then 'Caso seja um novo carregamento o tempo de validade é zerado
                    MyPlan.Cells(RowOffset + 19, Col).Value = "N/A"
                Else
                    MyPlan.Cells(RowOffset + 19, Col).Value = listDados.mCol(CalcPos(Conta, 19)).HrsValidade
                End If
                MyPlan.Cells(RowOffset + 20, Col).Value = BuscaRecCod(listDados.mCol(CalcPos(Conta, 19)).CodProd)
            End If

            If TQ6206 = "" Then
                MyPlan.Cells(RowOffset + 21, Col).Value = "-"
                MyPlan.Cells(RowOffset + 22, Col).Value = listDados.mCol(CalcPos(Conta, 18)).Temperatura
                MyPlan.Cells(RowOffset + 23, Col).Value = "Vazio"
                MyPlan.Cells(RowOffset + 24, Col).Value = "Vazio"
            Else
                MyPlan.Cells(RowOffset + 21, Col).Value = listDados.mCol(CalcPos(Conta, 18)).SeqTq
                MyPlan.Cells(RowOffset + 22, Col).Value = listDados.mCol(CalcPos(Conta, 18)).Temperatura
                If listDados.mCol(CalcPos(Conta, 18)).HrsValidade = 0 Then 'Caso seja um novo carregamento o tempo de validade é zerado
                    MyPlan.Cells(RowOffset + 23, Col).Value = "N/A"
                Else
                    MyPlan.Cells(RowOffset + 23, Col).Value = listDados.mCol(CalcPos(Conta, 18)).HrsValidade
                End If
                MyPlan.Cells(RowOffset + 24, Col).Value = BuscaRecCod(listDados.mCol(CalcPos(Conta, 18)).CodProd)
            End If

            If TQ6207 = "" Then
                MyPlan.Cells(RowOffset + 25, Col).Value = "-"
                MyPlan.Cells(RowOffset + 26, Col).Value = listDados.mCol(CalcPos(Conta, 17)).Temperatura
                MyPlan.Cells(RowOffset + 27, Col).Value = "Vazio"
                MyPlan.Cells(RowOffset + 28, Col).Value = "Vazio"
            Else
                MyPlan.Cells(RowOffset + 25, Col).Value = listDados.mCol(CalcPos(Conta, 17)).SeqTq
                MyPlan.Cells(RowOffset + 26, Col).Value = listDados.mCol(CalcPos(Conta, 17)).Temperatura
                If listDados.mCol(CalcPos(Conta, 17)).HrsValidade = 0 Then 'Caso seja um novo carregamento o tempo de validade é zerado
                    MyPlan.Cells(RowOffset + 27, Col).Value = "N/A"
                Else
                    MyPlan.Cells(RowOffset + 27, Col).Value = listDados.mCol(CalcPos(Conta, 17)).HrsValidade
                End If
                MyPlan.Cells(RowOffset + 28, Col).Value = BuscaRecCod(listDados.mCol(CalcPos(Conta, 17)).CodProd)
            End If

            If TQ6208 = "" Then
                MyPlan.Cells(RowOffset + 29, Col).Value = ""
                MyPlan.Cells(RowOffset + 30, Col).Value = listDados.mCol(CalcPos(Conta, 16)).Temperatura
                MyPlan.Cells(RowOffset + 31, Col).Value = "Vazio"
                MyPlan.Cells(RowOffset + 32, Col).Value = "Vazio"
            Else
                MyPlan.Cells(RowOffset + 29, Col).Value = listDados.mCol(CalcPos(Conta, 16)).SeqTq
                MyPlan.Cells(RowOffset + 30, Col).Value = listDados.mCol(CalcPos(Conta, 16)).Temperatura
                If listDados.mCol(CalcPos(Conta, 16)).HrsValidade = 0 Then 'Caso seja um novo carregamento o tempo de validade é zerado
                    MyPlan.Cells(RowOffset + 31, Col).Value = "N/A"
                Else
                    MyPlan.Cells(RowOffset + 31, Col).Value = listDados.mCol(CalcPos(Conta, 16)).HrsValidade
                End If
                MyPlan.Cells(RowOffset + 32, Col).Value = BuscaRecCod(listDados.mCol(CalcPos(Conta, 16)).CodProd)
            End If

            If TQ6209 = "" Then
                MyPlan.Cells(RowOffset + 33, Col).Value = "-"
                MyPlan.Cells(RowOffset + 34, Col).Value = listDados.mCol(CalcPos(Conta, 15)).Temperatura
                MyPlan.Cells(RowOffset + 35, Col).Value = "Vazio"
                MyPlan.Cells(RowOffset + 36, Col).Value = "Vazio"
            Else
                MyPlan.Cells(RowOffset + 33, Col).Value = listDados.mCol(CalcPos(Conta, 15)).SeqTq
                MyPlan.Cells(RowOffset + 34, Col).Value = listDados.mCol(CalcPos(Conta, 15)).Temperatura
                If listDados.mCol(CalcPos(Conta, 15)).HrsValidade = 0 Then 'Caso seja um novo carregamento o tempo de validade é zerado
                    MyPlan.Cells(RowOffset + 35, Col).Value = "N/A"
                Else
                    MyPlan.Cells(RowOffset + 35, Col).Value = listDados.mCol(CalcPos(Conta, 15)).HrsValidade
                End If
                MyPlan.Cells(RowOffset + 36, Col).Value = BuscaRecCod(listDados.mCol(CalcPos(Conta, 15)).CodProd)
            End If

            If TQ6210 = "" Then
                MyPlan.Cells(RowOffset + 37, Col).Value = "-"
                MyPlan.Cells(RowOffset + 38, Col).Value = listDados.mCol(CalcPos(Conta, 14)).Temperatura
                MyPlan.Cells(RowOffset + 39, Col).Value = "Vazio"
                MyPlan.Cells(RowOffset + 40, Col).Value = "Vazio"
            Else
                MyPlan.Cells(RowOffset + 37, Col).Value = listDados.mCol(CalcPos(Conta, 14)).SeqTq
                MyPlan.Cells(RowOffset + 38, Col).Value = listDados.mCol(CalcPos(Conta, 14)).Temperatura
                If listDados.mCol(CalcPos(Conta, 14)).HrsValidade = 0 Then 'Caso seja um novo carregamento o tempo de validade é zerado
                    MyPlan.Cells(RowOffset + 39, Col).Value = "N/A"
                Else
                    MyPlan.Cells(RowOffset + 39, Col).Value = listDados.mCol(CalcPos(Conta, 14)).HrsValidade
                End If
                MyPlan.Cells(RowOffset + 40, Col).Value = BuscaRecCod(listDados.mCol(CalcPos(Conta, 14)).CodProd)
            End If

            If TQ6211 = "" Then
                MyPlan.Cells(RowOffset + 41, Col).Value = "-"
                MyPlan.Cells(RowOffset + 42, Col).Value = listDados.mCol(CalcPos(Conta, 13)).Temperatura
                MyPlan.Cells(RowOffset + 43, Col).Value = "Vazio"
                MyPlan.Cells(RowOffset + 44, Col).Value = "Vazio"
            Else
                MyPlan.Cells(RowOffset + 41, Col).Value = listDados.mCol(CalcPos(Conta, 13)).SeqTq
                MyPlan.Cells(RowOffset + 42, Col).Value = listDados.mCol(CalcPos(Conta, 13)).Temperatura
                If listDados.mCol(CalcPos(Conta, 13)).HrsValidade = 0 Then 'Caso seja um novo carregamento o tempo de validade é zerado
                    MyPlan.Cells(RowOffset + 43, Col).Value = "N/A"
                Else
                    MyPlan.Cells(RowOffset + 43, Col).Value = listDados.mCol(CalcPos(Conta, 13)).HrsValidade
                End If
                MyPlan.Cells(RowOffset + 44, Col).Value = BuscaRecCod(listDados.mCol(CalcPos(Conta, 13)).CodProd)
            End If

            If TQ6212 = "" Then
                MyPlan.Cells(RowOffset + 45, Col).Value = "-"
                MyPlan.Cells(RowOffset + 46, Col).Value = listDados.mCol(CalcPos(Conta, 12)).Temperatura
                MyPlan.Cells(RowOffset + 47, Col).Value = "Vazio"
                MyPlan.Cells(RowOffset + 48, Col).Value = "Vazio"
            Else
                MyPlan.Cells(RowOffset + 45, Col).Value = listDados.mCol(CalcPos(Conta, 12)).SeqTq
                MyPlan.Cells(RowOffset + 46, Col).Value = listDados.mCol(CalcPos(Conta, 12)).Temperatura
                If listDados.mCol(CalcPos(Conta, 12)).HrsValidade = 0 Then 'Caso seja um novo carregamento o tempo de validade é zerado
                    MyPlan.Cells(RowOffset + 47, Col).Value = "N/A"
                Else
                    MyPlan.Cells(RowOffset + 47, Col).Value = listDados.mCol(CalcPos(Conta, 12)).HrsValidade
                End If
                MyPlan.Cells(RowOffset + 48, Col).Value = BuscaRecCod(listDados.mCol(CalcPos(Conta, 12)).CodProd)
            End If
            '
            If TQ6213 = "" Then
                MyPlan.Cells(RowOffset + 49, Col).Value = "-"
                MyPlan.Cells(RowOffset + 50, Col).Value = listDados.mCol(CalcPos(Conta, 11)).Temperatura
                MyPlan.Cells(RowOffset + 51, Col).Value = "Vazio"
                MyPlan.Cells(RowOffset + 52, Col).Value = "Vazio"
            Else
                MyPlan.Cells(RowOffset + 49, Col).Value = listDados.mCol(CalcPos(Conta, 11)).SeqTq
                MyPlan.Cells(RowOffset + 50, Col).Value = listDados.mCol(CalcPos(Conta, 11)).Temperatura
                If listDados.mCol(CalcPos(Conta, 11)).HrsValidade = 0 Then 'Caso seja um novo carregamento o tempo de validade é zerado
                    MyPlan.Cells(RowOffset + 51, Col).Value = "N/A"
                Else
                    MyPlan.Cells(RowOffset + 51, Col).Value = listDados.mCol(CalcPos(Conta, 11)).HrsValidade
                End If
                MyPlan.Cells(RowOffset + 52, Col).Value = BuscaRecCod(listDados.mCol(CalcPos(Conta, 11)).CodProd)
            End If

            If TQ6214 = "" Then
                MyPlan.Cells(RowOffset + 53, Col).Value = "-"
                MyPlan.Cells(RowOffset + 54, Col).Value = listDados.mCol(CalcPos(Conta, 10)).Temperatura
                MyPlan.Cells(RowOffset + 55, Col).Value = "Vazio"
                MyPlan.Cells(RowOffset + 56, Col).Value = "Vazio"
            Else
                MyPlan.Cells(RowOffset + 53, Col).Value = listDados.mCol(CalcPos(Conta, 10)).SeqTq
                MyPlan.Cells(RowOffset + 54, Col).Value = listDados.mCol(CalcPos(Conta, 10)).Temperatura
                If listDados.mCol(CalcPos(Conta, 10)).HrsValidade = 0 Then 'Caso seja um novo carregamento o tempo de validade é zerado
                    MyPlan.Cells(RowOffset + 55, Col).Value = "N/A"
                Else
                    MyPlan.Cells(RowOffset + 55, Col).Value = listDados.mCol(CalcPos(Conta, 10)).HrsValidade
                End If
                MyPlan.Cells(RowOffset + 56, Col).Value = BuscaRecCod(listDados.mCol(CalcPos(Conta, 10)).CodProd)
            End If

            If TQ6215 = "" Then
                MyPlan.Cells(RowOffset + 57, Col).Value = "-"
                MyPlan.Cells(RowOffset + 58, Col).Value = listDados.mCol(CalcPos(Conta, 9)).Temperatura
                MyPlan.Cells(RowOffset + 59, Col).Value = "Vazio"
                MyPlan.Cells(RowOffset + 60, Col).Value = "Vazio"
            Else
                MyPlan.Cells(RowOffset + 57, Col).Value = listDados.mCol(CalcPos(Conta, 9)).SeqTq
                MyPlan.Cells(RowOffset + 58, Col).Value = listDados.mCol(CalcPos(Conta, 9)).Temperatura
                If listDados.mCol(CalcPos(Conta, 9)).HrsValidade = 0 Then 'Caso seja um novo carregamento o tempo de validade é zerado
                    MyPlan.Cells(RowOffset + 59, Col).Value = "N/A"
                Else
                    MyPlan.Cells(RowOffset + 59, Col).Value = listDados.mCol(CalcPos(Conta, 9)).HrsValidade
                End If
                MyPlan.Cells(RowOffset + 60, Col).Value = BuscaRecCod(listDados.mCol(CalcPos(Conta, 9)).CodProd)
            End If

            If TQ6216 = "" Then
                MyPlan.Cells(RowOffset + 61, Col).Value = "-"
                MyPlan.Cells(RowOffset + 62, Col).Value = listDados.mCol(CalcPos(Conta, 8)).Temperatura
                MyPlan.Cells(RowOffset + 63, Col).Value = "Vazio"
                MyPlan.Cells(RowOffset + 64, Col).Value = "Vazio"
            Else
                MyPlan.Cells(RowOffset + 61, Col).Value = listDados.mCol(CalcPos(Conta, 8)).SeqTq
                MyPlan.Cells(RowOffset + 62, Col).Value = listDados.mCol(CalcPos(Conta, 8)).Temperatura
                If listDados.mCol(CalcPos(Conta, 8)).HrsValidade = 0 Then 'Caso seja um novo carregamento o tempo de validade é zerado
                    MyPlan.Cells(RowOffset + 63, Col).Value = "N/A"
                Else
                    MyPlan.Cells(RowOffset + 63, Col).Value = listDados.mCol(CalcPos(Conta, 8)).HrsValidade
                End If
                MyPlan.Cells(RowOffset + 64, Col).Value = BuscaRecCod(listDados.mCol(CalcPos(Conta, 8)).CodProd)
            End If

            '        If TQ6217 = "" Then
            '        MyPlan.Cells(RowOffset + 65, Col).Value = "-"
            '        MyPlan.Cells(RowOffset + 66, Col).Value = listDados.mCol(CalcPos(Conta,  7)).Temperatura
            '        MyPlan.Cells(RowOffset + 67, Col).Value = "Vazio"
            '        MyPlan.Cells(RowOffset + 68, Col).Value = "Vazio"
            '        Else
            '        MyPlan.Cells(RowOffset + 65, Col).Value = listDados.mCol(CalcPos(Conta,  7)).SeqTq
            '        MyPlan.Cells(RowOffset + 66, Col).Value = listDados.mCol(CalcPos(Conta,  7)).Temperatura
            '        If listDados.mCol(CalcPos(Conta,  7)).HrsValidade = 168.6 Then
            '        MyPlan.Cells(RowOffset + 67, Col).Value = "N/A"
            '        Else
            '        MyPlan.Cells(RowOffset + 67, Col).Value = listDados.mCol(CalcPos(Conta,  7)).HrsValidade
            '        End If
            '        MyPlan.Cells(RowOffset + 68, Col).Value = BuscaRecCod(listDados.mCol(CalcPos(Conta,  7)).CodProd)
            '        End If
            '
            '        If TQ6218 = "" Then
            '        MyPlan.Cells(RowOffset + 69, Col).Value = "-"
            '        MyPlan.Cells(RowOffset + 70, Col).Value = listDados.mCol(CalcPos(Conta,  6)).Temperatura
            '        MyPlan.Cells(RowOffset + 71, Col).Value = "Vazio"
            '        MyPlan.Cells(RowOffset + 72, Col).Value = "Vazio"
            '        Else
            '        MyPlan.Cells(RowOffset + 69, Col).Value = listDados.mCol(CalcPos(Conta,  6)).SeqTq
            '        MyPlan.Cells(RowOffset + 70, Col).Value = listDados.mCol(CalcPos(Conta,  6)).Temperatura
            '        If listDados.mCol(CalcPos(Conta,  6)).HrsValidade = 168.6 Then
            '        MyPlan.Cells(RowOffset + 71, Col).Value = "N/A"
            '        Else
            '        MyPlan.Cells(RowOffset + 71, Col).Value = listDados.mCol(CalcPos(Conta,  6)).HrsValidade
            '        End If
            '        MyPlan.Cells(RowOffset + 72, Col).Value = BuscaRecCod(listDados.mCol(CalcPos(Conta,  6)).CodProd)
            '        End If

            If TQ6255 = "" Then
                MyPlan.Cells(RowOffset + 65, Col).Value = "-"
                MyPlan.Cells(RowOffset + 66, Col).Value = listDados.mCol(CalcPos(Conta, 5)).Temperatura
                MyPlan.Cells(RowOffset + 67, Col).Value = "Vazio"
                MyPlan.Cells(RowOffset + 68, Col).Value = "Vazio"
            Else
                MyPlan.Cells(RowOffset + 65, Col).Value = listDados.mCol(CalcPos(Conta, 5)).SeqTq
                MyPlan.Cells(RowOffset + 66, Col).Value = listDados.mCol(CalcPos(Conta, 5)).Temperatura
                If listDados.mCol(CalcPos(Conta, 5)).HrsValidade = 0 Then 'Caso seja um novo carregamento o tempo de validade é zerado
                    MyPlan.Cells(RowOffset + 67, Col).Value = "N/A"
                Else
                    MyPlan.Cells(RowOffset + 67, Col).Value = listDados.mCol(CalcPos(Conta, 5)).HrsValidade
                End If
                MyPlan.Cells(RowOffset + 68, Col).Value = BuscaRecCod(listDados.mCol(CalcPos(Conta, 5)).CodProd)
            End If

            If TQ6256 = "" Then
                MyPlan.Cells(RowOffset + 69, Col).Value = "-"
                MyPlan.Cells(RowOffset + 70, Col).Value = listDados.mCol(CalcPos(Conta, 4)).Temperatura
                MyPlan.Cells(RowOffset + 71, Col).Value = "Vazio"
                MyPlan.Cells(RowOffset + 72, Col).Value = "Vazio"
            Else
                MyPlan.Cells(RowOffset + 69, Col).Value = listDados.mCol(CalcPos(Conta, 4)).SeqTq
                MyPlan.Cells(RowOffset + 70, Col).Value = listDados.mCol(CalcPos(Conta, 4)).Temperatura
                If listDados.mCol(CalcPos(Conta, 4)).HrsValidade = 0 Then 'Caso seja um novo carregamento o tempo de validade é zerado
                    MyPlan.Cells(RowOffset + 71, Col).Value = "N/A"
                Else
                    MyPlan.Cells(RowOffset + 71, Col).Value = listDados.mCol(CalcPos(Conta, 4)).HrsValidade
                End If
                MyPlan.Cells(RowOffset + 72, Col).Value = BuscaRecCod(listDados.mCol(CalcPos(Conta, 4)).CodProd)
            End If

            If TQ6257 = "" Then
                MyPlan.Cells(RowOffset + 73, Col).Value = "-"
                MyPlan.Cells(RowOffset + 74, Col).Value = listDados.mCol(CalcPos(Conta, 3)).Temperatura
                MyPlan.Cells(RowOffset + 75, Col).Value = "Vazio"
                MyPlan.Cells(RowOffset + 76, Col).Value = "Vazio"
            Else
                MyPlan.Cells(RowOffset + 73, Col).Value = listDados.mCol(CalcPos(Conta, 3)).SeqTq
                MyPlan.Cells(RowOffset + 74, Col).Value = listDados.mCol(CalcPos(Conta, 3)).Temperatura
                If listDados.mCol(CalcPos(Conta, 3)).HrsValidade = 0 Then 'Caso seja um novo carregamento o tempo de validade é zerado
                    MyPlan.Cells(RowOffset + 75, Col).Value = "N/A"
                Else
                    MyPlan.Cells(RowOffset + 75, Col).Value = listDados.mCol(CalcPos(Conta, 3)).HrsValidade
                End If
                MyPlan.Cells(RowOffset + 76, Col).Value = BuscaRecCod(listDados.mCol(CalcPos(Conta, 3)).CodProd)
            End If

            If TQ6258 = "" Then
                MyPlan.Cells(RowOffset + 77, Col).Value = "-"
                MyPlan.Cells(RowOffset + 78, Col).Value = listDados.mCol(CalcPos(Conta, 2)).Temperatura
                MyPlan.Cells(RowOffset + 79, Col).Value = "Vazio"
                MyPlan.Cells(RowOffset + 80, Col).Value = "Vazio"
            Else
                MyPlan.Cells(RowOffset + 77, Col).Value = listDados.mCol(CalcPos(Conta, 2)).SeqTq
                MyPlan.Cells(RowOffset + 78, Col).Value = listDados.mCol(CalcPos(Conta, 2)).Temperatura
                If listDados.mCol(CalcPos(Conta, 2)).HrsValidade = 0 Then 'Caso seja um novo carregamento o tempo de validade é zerado
                    MyPlan.Cells(RowOffset + 79, Col).Value = "N/A"
                Else
                    MyPlan.Cells(RowOffset + 79, Col).Value = listDados.mCol(CalcPos(Conta, 2)).HrsValidade
                End If
                MyPlan.Cells(RowOffset + 80, Col).Value = BuscaRecCod(listDados.mCol(CalcPos(Conta, 2)).CodProd)
            End If

            If TQ6259 = "" Then
                MyPlan.Cells(RowOffset + 81, Col).Value = "-"
                MyPlan.Cells(RowOffset + 82, Col).Value = listDados.mCol(CalcPos(Conta, 1)).Temperatura
                MyPlan.Cells(RowOffset + 83, Col).Value = "Vazio"
                MyPlan.Cells(RowOffset + 84, Col).Value = "Vazio"
            Else
                MyPlan.Cells(RowOffset + 81, Col).Value = listDados.mCol(CalcPos(Conta, 1)).SeqTq
                MyPlan.Cells(RowOffset + 82, Col).Value = listDados.mCol(CalcPos(Conta, 1)).Temperatura
                If listDados.mCol(CalcPos(Conta, 1)).HrsValidade = 0 Then 'Caso seja um novo carregamento o tempo de validade é zerado
                    MyPlan.Cells(RowOffset + 83, Col).Value = "N/A"
                Else
                    MyPlan.Cells(RowOffset + 83, Col).Value = listDados.mCol(CalcPos(Conta, 1)).HrsValidade
                End If
                MyPlan.Cells(RowOffset + 84, Col).Value = BuscaRecCod(listDados.mCol(CalcPos(Conta, 1)).CodProd)
            End If

            If TQ6260 = "" Then
                MyPlan.Cells(RowOffset + 85, Col).Value = "-"
                MyPlan.Cells(RowOffset + 86, Col).Value = listDados.mCol(CalcPos(Conta, 0)).Temperatura
                MyPlan.Cells(RowOffset + 87, Col).Value = "Vazio"
                MyPlan.Cells(RowOffset + 88, Col).Value = "Vazio"
            Else
                MyPlan.Cells(RowOffset + 85, Col).Value = listDados.mCol(CalcPos(Conta, 0)).SeqTq
                MyPlan.Cells(RowOffset + 86, Col).Value = listDados.mCol(CalcPos(Conta, 0)).Temperatura
                If listDados.mCol(CalcPos(Conta, 0)).HrsValidade = 0 Then 'Caso seja um novo carregamento o tempo de validade é zerado
                    MyPlan.Cells(RowOffset + 87, Col).Value = "N/A"
                Else
                    MyPlan.Cells(RowOffset + 87, Col).Value = listDados.mCol(CalcPos(Conta, 0)).HrsValidade
                End If
                MyPlan.Cells(RowOffset + 88, Col).Value = BuscaRecCod(listDados.mCol(CalcPos(Conta, 0)).CodProd)
            End If

            Col = Col + 1

        Next

        ''Escreve no excel
        'Dim PosIni As String = "C" & 6
        'Dim PosFim As String = "IV" & 94
        'Dim MyRange As String = PosIni & ":" & PosFim

        'MyPlan.Cells(RowOffset + MyRange).Value = MyPlan.Cells

        Return True

    End Function

    Function CalcPos(Conta As Integer, ColOffset As Integer) As Integer

        Dim Pos As Integer = (Conta + 1) * 24 - ColOffset - 1

        Return Pos

    End Function

    Function BuscaRecCod(RecNum As Integer) As String

        Static RecNumAnt As Integer
        Static CodigoAnt As String

        'Acelerador de busca
        If RecNumAnt = RecNum Then
            BuscaRecCod = CodigoAnt
            Exit Function
        End If


        'Busca
        Dim dtBusca = (From It In dtRec Where It.RecNum = RecNum).ToList
        If dtBusca.Count > 0 Then

            'Encontrado
            RecNumAnt = RecNum
            CodigoAnt = dtBusca.First.Codigo

            Return dtBusca.First.Codigo

        End If

        'Nao encontrado
        RecNumAnt = RecNum
        CodigoAnt = ""

        Return ""

    End Function

    Sub ControlRange(MyPlan As OfficeOpenXml.ExcelWorksheet)

        Dim i As Integer
        Dim MyCell As Double
        Dim MyCell1 As String = ""
        Dim Teste As Double

        i = 0
        MyCell = 0
        Teste = 0

        For i = 3 To 254

            MyCell = MyPlan.Cells(8, i).Value
            If (MyCell > 10) Then
                MyPlan.Cells(8, i).Style.Fill.PatternType = OfficeOpenXml.Style.ExcelFillStyle.Solid
                MyPlan.Cells(8, i).Style.Fill.BackgroundColor.SetColor(Color.Red)
            End If

            MyCell = MyPlan.Cells(12, i).Value
            If (MyCell > 10) Then
                MyPlan.Cells(12, i).Style.Fill.PatternType = OfficeOpenXml.Style.ExcelFillStyle.Solid
                MyPlan.Cells(12, i).Style.Fill.BackgroundColor.SetColor(Color.Red)
            End If

            MyCell = MyPlan.Cells(16, i).Value
            If (MyCell > 10) Then
                MyPlan.Cells(16, i).Style.Fill.PatternType = OfficeOpenXml.Style.ExcelFillStyle.Solid
                MyPlan.Cells(16, i).Style.Fill.BackgroundColor.SetColor(Color.Red)
            End If

            MyCell = MyPlan.Cells(20, i).Value
            If (MyCell > 10) Then
                MyPlan.Cells(20, i).Style.Fill.PatternType = OfficeOpenXml.Style.ExcelFillStyle.Solid
                MyPlan.Cells(20, i).Style.Fill.BackgroundColor.SetColor(Color.Red)
            End If

            MyCell = MyPlan.Cells(24, i).Value
            If (MyCell > 10) Then
                MyPlan.Cells(24, i).Style.Fill.PatternType = OfficeOpenXml.Style.ExcelFillStyle.Solid
                MyPlan.Cells(24, i).Style.Fill.BackgroundColor.SetColor(Color.Red)
            End If

            MyCell = MyPlan.Cells(28, i).Value
            If (MyCell > 10) Then
                MyPlan.Cells(28, i).Style.Fill.PatternType = OfficeOpenXml.Style.ExcelFillStyle.Solid
                MyPlan.Cells(28, i).Style.Fill.BackgroundColor.SetColor(Color.Red)
            End If

            MyCell = MyPlan.Cells(32, i).Value
            If (MyCell > 10) Then
                MyPlan.Cells(32, i).Style.Fill.PatternType = OfficeOpenXml.Style.ExcelFillStyle.Solid
                MyPlan.Cells(32, i).Style.Fill.BackgroundColor.SetColor(Color.Red)
            End If

            MyCell = MyPlan.Cells(36, i).Value
            If (MyCell > 10) Then
                MyPlan.Cells(36, i).Style.Fill.PatternType = OfficeOpenXml.Style.ExcelFillStyle.Solid
                MyPlan.Cells(36, i).Style.Fill.BackgroundColor.SetColor(Color.Red)
            End If

            MyCell = MyPlan.Cells(40, i).Value
            If (MyCell > 10) Then
                MyPlan.Cells(40, i).Style.Fill.PatternType = OfficeOpenXml.Style.ExcelFillStyle.Solid
                MyPlan.Cells(40, i).Style.Fill.BackgroundColor.SetColor(Color.Red)
            End If

            MyCell = MyPlan.Cells(44, i).Value
            If (MyCell > 10) Then
                MyPlan.Cells(44, i).Style.Fill.PatternType = OfficeOpenXml.Style.ExcelFillStyle.Solid
                MyPlan.Cells(44, i).Style.Fill.BackgroundColor.SetColor(Color.Red)
            End If

            MyCell = MyPlan.Cells(48, i).Value
            If (MyCell > 10) Then
                MyPlan.Cells(48, i).Style.Fill.PatternType = OfficeOpenXml.Style.ExcelFillStyle.Solid
                MyPlan.Cells(48, i).Style.Fill.BackgroundColor.SetColor(Color.Red)
            End If

            MyCell = MyPlan.Cells(52, i).Value
            If (MyCell > 10) Then
                MyPlan.Cells(52, i).Style.Fill.PatternType = OfficeOpenXml.Style.ExcelFillStyle.Solid
                MyPlan.Cells(52, i).Style.Fill.BackgroundColor.SetColor(Color.Red)
            End If

            MyCell = MyPlan.Cells(56, i).Value
            If (MyCell > 10) Then
                MyPlan.Cells(56, i).Style.Fill.PatternType = OfficeOpenXml.Style.ExcelFillStyle.Solid
                MyPlan.Cells(56, i).Style.Fill.BackgroundColor.SetColor(Color.Red)
            End If

            MyCell = MyPlan.Cells(60, i).Value
            If (MyCell > 10) Then
                MyPlan.Cells(60, i).Style.Fill.PatternType = OfficeOpenXml.Style.ExcelFillStyle.Solid
                MyPlan.Cells(60, i).Style.Fill.BackgroundColor.SetColor(Color.Red)
            End If

            MyCell = MyPlan.Cells(64, i).Value
            If (MyCell > 10) Then
                MyPlan.Cells(64, i).Style.Fill.PatternType = OfficeOpenXml.Style.ExcelFillStyle.Solid
                MyPlan.Cells(64, i).Style.Fill.BackgroundColor.SetColor(Color.Red)
            End If

            MyCell = MyPlan.Cells(68, i).Value
            If (MyCell > 10) Then
                MyPlan.Cells(68, i).Style.Fill.PatternType = OfficeOpenXml.Style.ExcelFillStyle.Solid
                MyPlan.Cells(68, i).Style.Fill.BackgroundColor.SetColor(Color.Red)
            End If

            MyCell = MyPlan.Cells(72, i).Value
            If (MyCell > 10) Then
                MyPlan.Cells(72, i).Style.Fill.PatternType = OfficeOpenXml.Style.ExcelFillStyle.Solid
                MyPlan.Cells(72, i).Style.Fill.BackgroundColor.SetColor(Color.Red)
            End If

            MyCell = MyPlan.Cells(76, i).Value
            If (MyCell > 10) Then
                MyPlan.Cells(76, i).Style.Fill.PatternType = OfficeOpenXml.Style.ExcelFillStyle.Solid
                MyPlan.Cells(76, i).Style.Fill.BackgroundColor.SetColor(Color.Red)
            End If

            MyCell = MyPlan.Cells(80, i).Value
            If (MyCell > 10) Then
                MyPlan.Cells(80, i).Style.Fill.PatternType = OfficeOpenXml.Style.ExcelFillStyle.Solid
                MyPlan.Cells(80, i).Style.Fill.BackgroundColor.SetColor(Color.Red)
            End If

            MyCell = MyPlan.Cells(84, i).Value
            If (MyCell > 10) Then
                MyPlan.Cells(84, i).Style.Fill.PatternType = OfficeOpenXml.Style.ExcelFillStyle.Solid
                MyPlan.Cells(84, i).Style.Fill.BackgroundColor.SetColor(Color.Red)
            End If

            MyCell = MyPlan.Cells(88, i).Value
            If (MyCell > 10) Then
                MyPlan.Cells(88, i).Style.Fill.PatternType = OfficeOpenXml.Style.ExcelFillStyle.Solid
                MyPlan.Cells(88, i).Style.Fill.BackgroundColor.SetColor(Color.Red)
            End If

            MyCell = MyPlan.Cells(92, i).Value
            If (MyCell > 10) Then
                MyPlan.Cells(92, i).Style.Fill.PatternType = OfficeOpenXml.Style.ExcelFillStyle.Solid
                MyPlan.Cells(92, i).Style.Fill.BackgroundColor.SetColor(Color.Red)
            End If

            MyCell = MyPlan.Cells(96, i).Value
            If (MyCell > 10) Then
                MyPlan.Cells(96, i).Style.Fill.PatternType = OfficeOpenXml.Style.ExcelFillStyle.Solid
                MyPlan.Cells(96, i).Style.Fill.BackgroundColor.SetColor(Color.Red)
            End If

            MyCell = MyPlan.Cells(100, i).Value
            If (MyCell > 10) Then
                MyPlan.Cells(100, i).Style.Fill.PatternType = OfficeOpenXml.Style.ExcelFillStyle.Solid
                MyPlan.Cells(100, i).Style.Fill.BackgroundColor.SetColor(Color.Red)
            End If

        Next i



        For j = 3 To 254

            If MyCell1 = "Vazio" Or MyCell1 = "N/A" Or MyCell1 = "" Then
            Else
                Teste = CInt(MyCell1)
            End If

            MyCell1 = MyPlan.Cells(9, j).Value
            If MyCell1 = "Vazio" Or MyCell1 = "N/A" Or MyCell1 = "" Then
            Else
                Teste = CInt(MyCell1)
            End If
            If (Teste < 0) Then
                MyPlan.Cells(9, j).Style.Fill.PatternType = OfficeOpenXml.Style.ExcelFillStyle.Solid
                MyPlan.Cells(9, j).Style.Fill.BackgroundColor.SetColor(Color.Red)
            End If

            MyCell1 = MyPlan.Cells(13, j).Value
            If MyCell1 = "Vazio" Or MyCell1 = "N/A" Or MyCell1 = "" Then
            Else
                Teste = CInt(MyCell1)
            End If
            If (Teste < 0) Then
                MyPlan.Cells(13, j).Style.Fill.PatternType = OfficeOpenXml.Style.ExcelFillStyle.Solid
                MyPlan.Cells(13, j).Style.Fill.BackgroundColor.SetColor(Color.Red)
            End If


            MyCell1 = MyPlan.Cells(17, j).Value
            If MyCell1 = "Vazio" Or MyCell1 = "N/A" Or MyCell1 = "" Then
            Else
                Teste = CInt(MyCell1)
            End If
            If (Teste < 0) Then
                MyPlan.Cells(17, j).Style.Fill.PatternType = OfficeOpenXml.Style.ExcelFillStyle.Solid
                MyPlan.Cells(17, j).Style.Fill.BackgroundColor.SetColor(Color.Red)
            End If


            MyCell1 = MyPlan.Cells(21, j).Value
            If MyCell1 = "Vazio" Or MyCell1 = "N/A" Or MyCell1 = "" Then
            Else
                Teste = CInt(MyCell1)
            End If
            If (Teste < 0) Then
                MyPlan.Cells(21, j).Style.Fill.PatternType = OfficeOpenXml.Style.ExcelFillStyle.Solid
                MyPlan.Cells(21, j).Style.Fill.BackgroundColor.SetColor(Color.Red)
            End If


            MyCell1 = MyPlan.Cells(25, j).Value
            If MyCell1 = "Vazio" Or MyCell1 = "N/A" Or MyCell1 = "" Then
            Else
                Teste = CInt(MyCell1)
            End If
            If (Teste < 0) Then
                MyPlan.Cells(25, j).Style.Fill.PatternType = OfficeOpenXml.Style.ExcelFillStyle.Solid
                MyPlan.Cells(25, j).Style.Fill.BackgroundColor.SetColor(Color.Red)
            End If


            MyCell1 = MyPlan.Cells(29, j).Value
            If MyCell1 = "Vazio" Or MyCell1 = "N/A" Or MyCell1 = "" Then
            Else
                Teste = CInt(MyCell1)
            End If
            If (Teste < 0) Then
                MyPlan.Cells(29, j).Style.Fill.PatternType = OfficeOpenXml.Style.ExcelFillStyle.Solid
                MyPlan.Cells(29, j).Style.Fill.BackgroundColor.SetColor(Color.Red)
            End If


            MyCell1 = MyPlan.Cells(33, j).Value
            If MyCell1 = "Vazio" Or MyCell1 = "N/A" Or MyCell1 = "" Then
            Else
                Teste = CInt(MyCell1)
            End If
            If (Teste < 0) Then
                MyPlan.Cells(33, j).Style.Fill.PatternType = OfficeOpenXml.Style.ExcelFillStyle.Solid
                MyPlan.Cells(33, j).Style.Fill.BackgroundColor.SetColor(Color.Red)
            End If


            MyCell1 = MyPlan.Cells(37, j).Value
            If MyCell1 = "Vazio" Or MyCell1 = "N/A" Or MyCell1 = "" Then
            Else
                Teste = CInt(MyCell1)
            End If
            If (Teste < 0) Then
                MyPlan.Cells(37, j).Style.Fill.PatternType = OfficeOpenXml.Style.ExcelFillStyle.Solid
                MyPlan.Cells(37, j).Style.Fill.BackgroundColor.SetColor(Color.Red)
            End If


            MyCell1 = MyPlan.Cells(41, j).Value
            If MyCell1 = "Vazio" Or MyCell1 = "N/A" Or MyCell1 = "" Then
            Else
                Teste = CInt(MyCell1)
            End If
            If (Teste < 0) Then
                MyPlan.Cells(41, j).Style.Fill.PatternType = OfficeOpenXml.Style.ExcelFillStyle.Solid
                MyPlan.Cells(41, j).Style.Fill.BackgroundColor.SetColor(Color.Red)
            End If


            MyCell1 = MyPlan.Cells(45, j).Value
            If MyCell1 = "Vazio" Or MyCell1 = "N/A" Or MyCell1 = "" Then
            Else
                Teste = CInt(MyCell1)
            End If
            If (Teste < 0) Then
                MyPlan.Cells(45, j).Style.Fill.PatternType = OfficeOpenXml.Style.ExcelFillStyle.Solid
                MyPlan.Cells(45, j).Style.Fill.BackgroundColor.SetColor(Color.Red)
            End If


            MyCell1 = MyPlan.Cells(49, j).Value
            If MyCell1 = "Vazio" Or MyCell1 = "N/A" Or MyCell1 = "" Then
            Else
                Teste = CInt(MyCell1)
            End If
            If (Teste < 0) Then
                MyPlan.Cells(49, j).Style.Fill.PatternType = OfficeOpenXml.Style.ExcelFillStyle.Solid
                MyPlan.Cells(49, j).Style.Fill.BackgroundColor.SetColor(Color.Red)
            End If

            MyCell1 = MyPlan.Cells(53, j).Value
            If MyCell1 = "Vazio" Or MyCell1 = "N/A" Or MyCell1 = "" Then
            Else
                Teste = CInt(MyCell1)
            End If
            If (Teste < 0) Then
                MyPlan.Cells(53, j).Style.Fill.PatternType = OfficeOpenXml.Style.ExcelFillStyle.Solid
                MyPlan.Cells(53, j).Style.Fill.BackgroundColor.SetColor(Color.Red)
            End If

            MyCell1 = MyPlan.Cells(57, j).Value
            If MyCell1 = "Vazio" Or MyCell1 = "N/A" Or MyCell1 = "" Then
            Else
                Teste = CInt(MyCell1)
            End If
            If (Teste < 0) Then
                MyPlan.Cells(57, j).Style.Fill.PatternType = OfficeOpenXml.Style.ExcelFillStyle.Solid
                MyPlan.Cells(57, j).Style.Fill.BackgroundColor.SetColor(Color.Red)
            End If


            MyCell1 = MyPlan.Cells(61, j).Value
            If MyCell1 = "Vazio" Or MyCell1 = "N/A" Or MyCell1 = "" Then
            Else
                Teste = CInt(MyCell1)
            End If
            If (Teste < 0) Then
                MyPlan.Cells(61, j).Style.Fill.PatternType = OfficeOpenXml.Style.ExcelFillStyle.Solid
                MyPlan.Cells(61, j).Style.Fill.BackgroundColor.SetColor(Color.Red)
            End If

            MyCell1 = MyPlan.Cells(65, j).Value
            If MyCell1 = "Vazio" Or MyCell1 = "N/A" Or MyCell1 = "" Then
            Else
                Teste = CInt(MyCell1)
            End If
            If (Teste < 0) Then
                MyPlan.Cells(65, j).Style.Fill.PatternType = OfficeOpenXml.Style.ExcelFillStyle.Solid
                MyPlan.Cells(65, j).Style.Fill.BackgroundColor.SetColor(Color.Red)
            End If


            MyCell1 = MyPlan.Cells(68, j).Value
            If MyCell1 = "Vazio" Or MyCell1 = "N/A" Or MyCell1 = "" Then
            Else
                Teste = CInt(MyCell1)
            End If
            If (Teste < 0) Then
                MyPlan.Cells(68, j).Style.Fill.PatternType = OfficeOpenXml.Style.ExcelFillStyle.Solid
                MyPlan.Cells(68, j).Style.Fill.BackgroundColor.SetColor(Color.Red)
            End If


            MyCell1 = MyPlan.Cells(73, j).Value
            If MyCell1 = "Vazio" Or MyCell1 = "N/A" Or MyCell1 = "" Then
            Else
                Teste = CInt(MyCell1)
            End If
            If (Teste < 0) Then
                MyPlan.Cells(73, j).Style.Fill.PatternType = OfficeOpenXml.Style.ExcelFillStyle.Solid
                MyPlan.Cells(73, j).Style.Fill.BackgroundColor.SetColor(Color.Red)
            End If


            MyCell1 = MyPlan.Cells(77, j).Value
            If MyCell1 = "Vazio" Or MyCell1 = "N/A" Or MyCell1 = "" Then
            Else
                Teste = CInt(MyCell1)
            End If
            If (Teste < 0) Then
                MyPlan.Cells(77, j).Style.Fill.PatternType = OfficeOpenXml.Style.ExcelFillStyle.Solid
                MyPlan.Cells(77, j).Style.Fill.BackgroundColor.SetColor(Color.Red)
            End If


            MyCell1 = MyPlan.Cells(81, j).Value
            If MyCell1 = "Vazio" Or MyCell1 = "N/A" Or MyCell1 = "" Then
            Else
                Teste = CInt(MyCell1)
            End If
            If (Teste < 0) Then
                MyPlan.Cells(81, j).Style.Fill.PatternType = OfficeOpenXml.Style.ExcelFillStyle.Solid
                MyPlan.Cells(81, j).Style.Fill.BackgroundColor.SetColor(Color.Red)
            End If


            MyCell1 = MyPlan.Cells(85, j).Value
            If MyCell1 = "Vazio" Or MyCell1 = "N/A" Or MyCell1 = "" Then
            Else
                Teste = CInt(MyCell1)
            End If
            If (Teste < 0) Then
                MyPlan.Cells(85, j).Style.Fill.PatternType = OfficeOpenXml.Style.ExcelFillStyle.Solid
                MyPlan.Cells(85, j).Style.Fill.BackgroundColor.SetColor(Color.Red)
            End If


            MyCell1 = MyPlan.Cells(89, j).Value
            If MyCell1 = "Vazio" Or MyCell1 = "N/A" Or MyCell1 = "" Then
            Else
                Teste = CInt(MyCell1)
            End If
            If (Teste < 0) Then
                MyPlan.Cells(89, j).Style.Fill.PatternType = OfficeOpenXml.Style.ExcelFillStyle.Solid
                MyPlan.Cells(89, j).Style.Fill.BackgroundColor.SetColor(Color.Red)
            End If

            MyCell1 = MyPlan.Cells(93, j).Value
            If MyCell1 = "Vazio" Or MyCell1 = "N/A" Or MyCell1 = "" Then
            Else
                Teste = CInt(MyCell1)
            End If
            If (Teste < 0) Then
                MyPlan.Cells(93, j).Style.Fill.PatternType = OfficeOpenXml.Style.ExcelFillStyle.Solid
                MyPlan.Cells(93, j).Style.Fill.BackgroundColor.SetColor(Color.Red)
            End If


            MyCell1 = MyPlan.Cells(97, j).Value
            If MyCell1 = "Vazio" Or MyCell1 = "N/A" Or MyCell1 = "" Then
            Else
                Teste = CInt(MyCell1)
            End If
            If (Teste < 0) Then
                MyPlan.Cells(97, j).Style.Fill.PatternType = OfficeOpenXml.Style.ExcelFillStyle.Solid
                MyPlan.Cells(97, j).Style.Fill.BackgroundColor.SetColor(Color.Red)
            End If


            MyCell1 = MyPlan.Cells(101, j).Value
            If MyCell1 = "Vazio" Or MyCell1 = "N/A" Or MyCell1 = "" Then
            Else
                Teste = CInt(MyCell1)
            End If
            If (Teste < 0) Then
                MyPlan.Cells(101, j).Style.Fill.PatternType = OfficeOpenXml.Style.ExcelFillStyle.Solid
                MyPlan.Cells(101, j).Style.Fill.BackgroundColor.SetColor(Color.Red)
            End If


        Next j

    End Sub

End Module
