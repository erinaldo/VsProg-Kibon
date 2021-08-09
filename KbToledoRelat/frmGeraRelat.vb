Imports System.IO
Imports OfficeOpenXml
Imports OfficeOpenXml.Style

Public Class frmGeraRelat

    Public Sub Abre()

        Show()

    End Sub

    Private Sub butCancela_Click(sender As System.Object, e As System.EventArgs) Handles butCancela.Click

        Close()

    End Sub


    Private Sub butCriaRelat_Click(sender As System.Object, e As System.EventArgs) Handles butCriaRelat.Click

        CriaRelat()

    End Sub

    Private Function CriaRelat() As Boolean

        Dim Ck As New Geral.dcToledo

        'Pesquisa
        Dim Id As Integer = Val(frmRelat.cbxMaq.Text)
        Dim Maq As String = frmRelat.cbxMaq.Text

        Dim dtArt = (From It In Ck.DadosArt Where It.Sts = 1 And It.IdMaq = Id).ToList
        If dtArt.Count <= 0 Then Return False
        Dim ArtAtv = dtArt.First.ArtId

        'Pesquisa no FB_PD_STAT pelo nome do produto, peso nominal e peso tara
        Dim DtPdStat = (From It In Ck.ProdStat Where It.IdArt = ArtAtv).ToList
        If DtPdStat.Count <= 0 Then Return False

        Dim NomeProd As String = DtPdStat.First.Artigo
        Dim PesoNom As String = DtPdStat.First.PesoNominal
        Dim PesoTara As String = DtPdStat.First.Tara

        'Ativa barra de progresso 
        pbStMax(10)

        'Cria o relatório
        Dim RelatPath = Util.basTrataUtil.UtAppPath & "\"
        Dim PathnameRel As String = RelatPath & "NewRelat\CkRelat_" & Geral.TseNow & ".xlsx"

        'Cria arquivo
        Dim RetCria As Boolean = CopiaModelo(PathnameRel)
        If RetCria <> True Then
            MsgBox("Falha na criacao do arquivo " & PathnameRel)
            Return False
        End If

        'Edita o relatório criado anteriormente
        Dim MyXl As New FileInfo(PathnameRel)
        Dim Myplan As New OfficeOpenXml.ExcelPackage(MyXl)

        'Edita Tabela
        Dim MyCel As OfficeOpenXml.ExcelWorksheet = Myplan.Workbook.Worksheets("Dados")

        PbSet(2)

        Try
            MyCel.Cells("C5").Value = Maq

            MyCel.Cells("C9").Value = DtPdStat.First.Artigo
            MyCel.Cells("C10").Value = DtPdStat.First.PesoNominal
            MyCel.Cells("C11").Value = DtPdStat.First.Tara

            Myplan.Save()

            PbSet(99999)

        Catch ex As Exception
            MsgBox("Erro ao tentar criar o relatório" & Chr(13) & "Tente novamente")
            Return False
        End Try
        
        Return True

    End Function

    'Barra de status do processo
    Private Sub PbSet(ByVal Valor As Integer)

        If Valor > pbRelat.Maximum Then
            Valor = pbRelat.Maximum
        End If

        pbRelat.Value = Valor
        pbRelat.Refresh()

    End Sub

    Private Sub pbStMax(ByVal Valor As Integer)

        pbRelat.Maximum = Valor
        pbRelat.Refresh()

    End Sub

    'Copia planilha modelo para a inserção dos dados
    Function CopiaModelo(ByVal PathnameRel As String) As Boolean

        Try
            Kill(PathnameRel)
        Catch : End Try

        Dim RelatPath = Util.basTrataUtil.UtAppPath & "\"
        Dim PathnameModelo As String = RelatPath & "RelatModelos\CkRelatMod.xlsx"

        'Copia arqivo modelo para geracao de relatorio
        Try
            FileCopy(PathnameModelo, PathnameRel)
        Catch ex As Exception
            Debug.Print("Erro: " & ex.Message)
            CopiaModelo = False
            Return False
        End Try

        Return True

    End Function

End Class