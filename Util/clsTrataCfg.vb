Public Class clsTrataCfg

    Public colCfg As Collection
    Private colItem As Collection

    Sub New()
    End Sub

    Sub New(ByVal strFilePath As String)
        CfgLeXml(strFilePath)
    End Sub

    Public Function CfgLeXml(ByVal strFilePath As String) As Collection

        Dim dsXml As New Data.DataSet

        colCfg = New Collection
        colItem = New Collection

        Try
            dsXml.ReadXml(strFilePath)
        Catch Ex As Exception
            Return colCfg
        End Try

        For Conta As Integer = 0 To dsXml.Tables("CfgGeral").Rows.Count - 1
            'Adiciona dados da configuracao na colecao
            colCfg.Add(dsXml.Tables("CfgGeral").Rows(Conta).Item("Valor"), dsXml.Tables("CfgGeral").Rows(Conta).Item("Item"))

            'Adiciona o nome dos Itens na colecao Itens
            colItem.Add(dsXml.Tables("CfgGeral").Rows(Conta).Item("Item"), dsXml.Tables("CfgGeral").Rows(Conta).Item("Item"))
        Next

        Return colCfg

    End Function


    Public Function CfgGravaXml(ByRef colCfg As Collection, ByVal strFilePath As String, _
                                ByVal strItem As String, ByVal strValor As String) As Boolean

        'apaga o Item da colecao que sera alterado
        Try
            colCfg.Remove(strItem)
            colItem.Remove(strItem)
        Catch ex As Exception
        End Try

        'Adiciona o novo Item na colecao
        colCfg.Add(strValor, strItem)
        'Adiciona o nome do Item na colecao interna (private)
        colItem.Add(strItem, strItem)

        'Apaga arquivo xml de configuracao 
        System.IO.File.Delete(strFilePath)

        'Monta DataSet da colecao 
        Dim dtDados As New DataTable("CfgGeral")
        Dim myRow As DataRow

        dtDados.Columns.Add("Item")
        dtDados.Columns.Add("Valor")

        For Conta As Integer = 1 To colCfg.Count

            myRow = dtDados.NewRow
            myRow("Item") = colItem(Conta).ToString
            myRow("Valor") = colCfg(Conta).ToString
            dtDados.Rows.Add(myRow)

        Next

        'Grava novo arquivo XML de configuracao com o novo Valor passado
        Dim xmlFile As System.IO.StreamWriter = New System.IO.StreamWriter(strFilePath)
        dtDados.WriteXml(xmlFile, XmlWriteMode.IgnoreSchema)
        xmlFile.Close()

        Return True

    End Function

End Class
