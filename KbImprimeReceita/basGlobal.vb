Option Strict Off
Option Explicit On
Module basGlobal
	
    Public MyIngreds As clsIngreds
    Public MyIngredsMat As clsIngredsMat
	
	'Variaveis de diretorio
	Public PathReceitas As String
	Public PathRecAtual As String
	Public IngredManuais As Boolean
	Public NomeDaAreaAtual As String
	Public NomeDoTqDestino As String
	
	Public SeparadorDecimal As String
	
	'Variaveis globais
    Public RecDados As New clsRcp
    Public recLista As New clsRcps
	
	Public PesoRefer As Object
	Public PesoReferImpr As Object
    Public TamBatch As Object

End Module