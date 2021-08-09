Public Class frmRecRelat

    Private Sub frmCipRelat_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        Geral.DllInit()


        tmrRelatorio.Enabled = True
        Me.Refresh()

    End Sub


    Private Sub tmrRelatorio_Tick(ByVal sender As Object, ByVal e As System.EventArgs) Handles tmrRelatorio.Tick

        tmrRelatorio.Enabled = False

        If My.Application.CommandLineArgs.Count < 1 Then End
        Dim AreaSel As String = My.Application.CommandLineArgs(0)
        If AreaSel = "" Then End

        'carrega dados
        Dim BdReceitas As New Geral.nsReceitas.dcReceitas
        Dim dtReceita As List(Of Geral.nsReceitas.Rec) = Nothing
        Try
            dtReceita = (From It In BdReceitas.Rec Where It.Area = AreaSel Order By It.RecNum).ToList

        Catch ex As Exception
            MsgBox("Não foi possível conectar ao Banco de Dados do Sistema!" & vbCr & _
                    "Verifique se o servidor está ligado e a rede funcionando.", MsgBoxStyle.Exclamation)

            Me.Close()

        End Try


        'Gera o relatorio
        Dim Ret As Boolean = MontaRelat(AreaSel, dtReceita)
        If Ret = False Then
            MsgBox("Atenção - Erro na montagem do relatório", MsgBoxStyle.Critical)
        End If

        Me.Close()


    End Sub

End Class
