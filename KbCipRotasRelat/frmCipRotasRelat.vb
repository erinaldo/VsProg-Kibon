Public Class frmCipRotasRelat

    Public BdRotas As Geral.nsCipRotas.dcCipRotas

    Public dtCipCadRota As New List(Of Geral.nsCipRotas.RotaCad)

    Private Sub frmCipRotasRelat_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        Geral.DllInit()

        Cfg = New Util.clsTrataCfg(Util.UtAppPath & "\..\Bin\cfgGeral.xml")

        tmrRel.Enabled = True

    End Sub

    Private Sub GeraRelatRotas()

        'Gera o relatorio
        Dim Ret As Boolean = MontaRelat
        If Ret = False Then
            MsgBox("Graficos - Erro na geracao do relatorio")
        End If


    End Sub

    Private Sub tmrRel_Tick(sender As System.Object, e As System.EventArgs) Handles tmrRel.Tick

        tmrRel.Enabled = False

        'carrega dados
        BdRotas = New Geral.nsCipRotas.dcCipRotas

        Try
            dtCipCadRota = (From It In BdRotas.RotaCad Order By It.RotaId).ToList

        Catch ex As Exception
            MsgBox("Não foi possível conectar ao Banco de Dados do Sistema!" & vbCr & _
                    "Verifique se o servidor está ligado e a rede funcionando.", MsgBoxStyle.Exclamation)

            Me.Close()

        End Try

        GeraRelatRotas()

        End

    End Sub
End Class
