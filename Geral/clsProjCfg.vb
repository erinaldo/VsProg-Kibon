Public Class clsProjCfg

    Public colCfg As Collection

    Sub New()
        CfgLeTabela()
    End Sub

    Public Function CfgLeTabela() As Collection

        Dim DbCv As New nsCipValid.dcCipValid
        Dim dtCadCfg = (From It In DbCv.CadCfg).ToList

        colCfg = New Collection

        For Conta As Integer = 0 To dtCadCfg.Count - 1

            colCfg.Add(dtCadCfg(Conta).Valor, Trim(dtCadCfg(Conta).Cfg))

        Next

        Return colCfg

    End Function

End Class
