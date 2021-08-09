Module basTrataReceita

    Function Receita_Abre(ByVal RecNum As Integer) As Boolean

        'Abre o arquivo de receita

        'Dim Blk As Geral.clsBloco

        ' Dim Banco As New Geral.nsReceitas.dcReceitas

        'Dim tRec = From Reg In Banco.Rec

        'Buscando dados da receita
        'Cmd = "SELECT " & _
        '            "* " & _
        '        "FROM " & _
        '            "Rec " & _
        '        "WHERE " & _
        '            "RecNum = " & RecNum & " " & _
        '        "AND " & _
        '            "Area = '" & AreaDados("Area") & "'"
        'Rec.Open(Cmd, MyDb)

        'frmRecEdit.txtPasta.Text = ""
        'frmRecEdit.txtSubpasta.Text = ""

        'frmRecEdit.txtReceitaNum.Text = RecNum
        'frmRecEdit.txtReceitaNome.Text = Rec!RecNome
        'On Error Resume Next
        'frmRecEdit.txtReceitaDescr.Text = Rec!RecDescr
        'frmRecEdit.txtPasta.Text = Rec!Pasta
        'frmRecEdit.txtSubpasta.Text = Rec!Subpasta
        'On Error GoTo 0
        'frmRecEdit.txtReceitaCod.Text = Rec!Codigo
        'frmRecEdit.txtPesoReferencia = Rec!PesoRefer


        'Rec.Close()


        ''Le itens da receita
        'MyBlocos = New Blocos

        'Cmd = "SELECT " & _
        '            "* " & _
        '        "FROM " & _
        '            "RecBlocos " & _
        '        "WHERE " & _
        '            "RecNum = " & RecNum & " " & _
        '        "AND " & _
        '            "Area = '" & AreaDados("Area") & "' " & _
        '        "ORDER BY " & _
        '            "ItemSeq"
        'Rec.Open(Cmd, MyDb)

        'Do While Rec.EOF = False

        '    'Novo bloco
        '    Blk = MyBlocos.Add
        '    Blk.LeModelo(MyDb, AreaDados("Area"), Rec!BlkNum)

        '    'Le valor de cada parametro
        '    For ContaParam = 1 To 9

        '        If ContaParam <= Blk.MyParametros.Count Then

        '            MyCol = "Param" & Right("00" & ContaParam, 2)
        '            Blk.MyParametros(ContaParam).Valor = Rec(MyCol).Value

        '        End If
        '    Next

        '    Rec.MoveNext()

        'Loop

        Return True

    End Function

    Function RecSalva(ByVal NumeroReceita)

        'Salva arquivo de receita

        'Dim MeuBloco As Bloco
        'Dim MeuParam As Parametro
        'Dim Rec As New Recordset
        'Dim Param() As Double


        ''Apagando dados antigos
        'Cmd = "DELETE FROM " & _
        '            "RecBlocos " & _
        '        "WHERE " & _
        '            "RecNum = " & NumeroReceita & " " & _
        '        "AND " & _
        '            "Area = '" & AreaDados("Area") & "'"
        'MyDb.Execute(Cmd)

        'Cmd = "DELETE FROM " & _
        '            "RecIngred " & _
        '        "WHERE " & _
        '            "RecNum = " & NumeroReceita & " " & _
        '        "AND " & _
        '            "Area = '" & AreaDados("Area") & "'"
        'MyDb.Execute(Cmd)

        'Cmd = "DELETE FROM " & _
        '            "Rec " & _
        '        "WHERE " & _
        '            "RecNum = " & NumeroReceita & " " & _
        '        "AND " & _
        '            "Area = '" & AreaDados("Area") & "'"
        'MyDb.Execute(Cmd)


        ''Salva a receita
        'Cmd = "INSERT INTO " & _
        '            "Rec " & _
        '        "VALUES( " & _
        '            "'" & AreaDados("Area") & "', " & _
        '            NumeroReceita & ", " & _
        '            "'" & Left(frmRecEdit.txtReceitaNome, 50) & "', " & _
        '            "'" & Left(frmRecEdit.txtReceitaDescr, 50) & "', " & _
        '            "'" & Left(frmRecEdit.txtReceitaCod, 6) & "', " & _
        '            Val(frmRecEdit.txtPesoReferencia) & ", " & _
        '             "'" & Left(frmRecEdit.txtPasta, 20) & "', " & _
        '             "'" & Left(frmRecEdit.txtSubpasta, 20) & "')"
        'MyDb.Execute(Cmd)


        ''Salva ingredientes
        'MyIngreds.ListaSalva()


        ''Salva os blocos
        'For Conta = 1 To MyBlocos.Count

        '    'Pega parametros evitando ocorrencia de erro caso o parametro nao exista
        '    On Error Resume Next

        '    'Limpa a lista de parametros
        'ReDim Param(10) As Double

        '    Param(1) = MyBlocos(Conta).MyParametros(1).Valor
        '    Param(2) = MyBlocos(Conta).MyParametros(2).Valor
        '    Param(3) = MyBlocos(Conta).MyParametros(3).Valor
        '    Param(4) = MyBlocos(Conta).MyParametros(4).Valor
        '    Param(5) = MyBlocos(Conta).MyParametros(5).Valor
        '    Param(6) = MyBlocos(Conta).MyParametros(6).Valor
        '    Param(7) = MyBlocos(Conta).MyParametros(7).Valor
        '    Param(8) = MyBlocos(Conta).MyParametros(8).Valor
        '    Param(9) = MyBlocos(Conta).MyParametros(9).Valor

        '    On Error GoTo 0

        '    Cmd = "INSERT INTO " & _
        '                "RecBlocos " & _
        '            "VALUES( " & _
        '                "'" & AreaDados("Area") & "', " & _
        '                NumeroReceita & ", " & _
        '                Conta & ", " & _
        '                MyBlocos(Conta).NumeroDoBloco & ", " & _
        '                Param(1) & ", " & _
        '                Param(2) & ", " & _
        '                Param(3) & ", " & _
        '                Param(4) & ", " & _
        '                Param(5) & ", " & _
        '                Param(6) & ", " & _
        '                Param(7) & ", " & _
        '                Param(8) & ", " & _
        '                Param(9) & ")"
        '    MyDb.Execute(Cmd)

        'Next


        'FlagDadosForamEditados = False

        Return True

    End Function

    Function RecExclui(ByVal NumeroReceita)

        'Apagando dados antigos

        'Cmd = "DELETE FROM " & _
        '            "RecBlocos " & _
        '        "WHERE " & _
        '            "RecNum = " & NumeroReceita & " " & _
        '        "AND " & _
        '            "Area = '" & AreaDados("Area") & "'"
        'MyDb.Execute(Cmd)

        'Cmd = "DELETE FROM " & _
        '            "RecIngred " & _
        '        "WHERE " & _
        '            "RecNum = " & NumeroReceita & " " & _
        '        "AND " & _
        '            "Area = '" & AreaDados("Area") & "'"
        'MyDb.Execute(Cmd)

        'Cmd = "DELETE FROM " & _
        '            "Rec " & _
        '        "WHERE " & _
        '            "RecNum = " & NumeroReceita & " " & _
        '        "AND " & _
        '            "Area = '" & AreaDados("Area") & "'"
        'MyDb.Execute(Cmd)


        'frmRecEdit.txtReceitaNum.Text = ""
        'frmRecEdit.txtReceitaNome.Text = ""
        'frmRecEdit.txtReceitaDescr.Text = ""
        'frmRecEdit.txtReceitaCod.Text = ""
        'frmRecEdit.txtPesoReferencia = ""

        'MyBlocos = New Blocos
        'FlagDadosForamEditados = False

        Return True

    End Function

End Module
