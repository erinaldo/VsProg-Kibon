Imports System
Imports System.Text
Imports System.Collections
Imports System.Security.Cryptography
Imports System.Security
Imports System.IO

Public Module basCrypto

    Public Enum EncMode
        'Conjunto ASCII de caracteres
        ASCII
        'Conjunto Unicode de caracteres ( no projeto em VB.Net: UNICODE_ )
        UNICODE_
        'Conjunto UTF7 de caracteres
        UTF7
        'Conjunto UTF8 de caracteres
        UTF8
    End Enum

    Public Enum HashMode
        'Algoritmo de Hash:MD5
        MD5
        'Algoritmo de Hash:SHA1
        SHA1
        'Algoritmo de Hash:SHA256
        SHA256
        'Algoritmo de Hash:SHA384
        SHA384
        'Algoritmo de Hash:SHA512
        SHA512
    End Enum

    Public Enum AlgList
        'Algoritmo simétrico Rinjdael
        RINJNDAEL
        'Algoritmo simétrico DES
        DES
        'Algoritmo simétrico TripleDES
        TRIPLEDES
        'Algoritmo simétrico RC2
        RC2
    End Enum

    Public Function EncString(ByVal strIn As String, ByVal mMode As EncMode) As Byte()
        ' Escolhemos o Encoder especificado por mMode 
        ' usamos o Encoder para fazer retornar um vetor de Bytes
        Select Case mMode
            Case EncMode.UNICODE_
                'Usa o Encoder para Unicode
                Return System.Text.Encoding.Unicode.GetBytes(strIn)
            Case EncMode.UTF7
                'Usa o Encoder para UTF7
                Return System.Text.Encoding.Unicode.GetBytes(strIn)
            Case EncMode.UTF8
                'Usa o Encoder para UTF8
                Return System.Text.Encoding.UTF8.GetBytes(strIn)
            Case Else
                'Usa o Encoder para ASCII
                Return System.Text.Encoding.ASCII.GetBytes(strIn)
        End Select
    End Function

    Public Function EncString(ByVal strIn As String) As Byte()
        'assumido como default ASCII
        Return EncString(strIn, EncMode.ASCII)
    End Function

    Public Function CalcHashHex(ByVal strIn As String, ByVal mMode As EncMode, ByVal hMode As HashMode) As String
        'Declara um array de bytes e chama EncString para encodar
        'strIn segundo mMode
        Dim arrEnc As Byte() = EncString(strIn, mMode)
        'Usa CalcHashByteArray para calcular o Hash num
        'array de Bytes segundo o algoritmo hMode
        Dim bArrhAlg As Byte() = CalcHashByteArray(arrEnc, hMode)
        'Usamos um StringBuilder para melhorar a performance
        Dim sbHash As StringBuilder = New StringBuilder
        'Agora é só converter o Md5 em uma string de Hexadecimais
        'No VB.Net não dá para usar a mesma estrutura de for do C#.Net
        Dim i As Integer = 0
        'Para cada byte do array
        While i < bArrhAlg.Length
            'Converte seu valor em Hexadecimal de 2 posições
            sbHash.Append(bArrhAlg(i).ToString("X2"))
            i += 1
        End While
        'Retorna o StringBuilder convertido mem string
        Return sbHash.ToString()
    End Function

    Public Function CalcHashHex(ByVal strIn As String, ByVal mMode As EncMode) As String
        'Chama o método principal do overload repassando
        'strIn,mMode e o algoritmo default (HashMode.MD5)
        Return CalcHashHex(strIn, mMode, HashMode.MD5)
    End Function

    Public Function CalcHashHex(ByVal strIn As String, ByVal hMode As HashMode) As String
        'Chama o método principal do overload repassando
        'strIn, EncMode.UTF8 como default e hMode
        Return CalcHashHex(strIn, EncMode.UTF8, hMode)
    End Function

    Public Function CalcHashHex(ByVal strIn As String) As String
        'Chama o método principal do overload repassando
        'strIn, EncMode.UTF8 e HashMode.MD5 como default
        Return CalcHashHex(strIn, EncMode.UTF8, HashMode.MD5)
    End Function

    Public Function CalcHashByteArray(ByVal Dados() As Byte, ByVal hMode As HashMode) As Byte()
        'Declara um HashAlgorithm para abrigar o objeto que vai fazer o cálculo
        Dim hash As HashAlgorithm
        'Verifica qual foi o Algoritmo escolhido e instancia a classe correspondente
        Select Case hMode
            Case HashMode.SHA1
                hash = New SHA1CryptoServiceProvider
            Case HashMode.SHA256
                hash = New SHA256Managed
            Case HashMode.SHA384
                hash = New SHA384Managed
            Case HashMode.SHA512
                hash = New SHA512Managed
            Case Else
                hash = New MD5CryptoServiceProvider
        End Select
        'Faz o calcúlo do Hash retornando um array de bytes
        hash.Initialize()
        Return hash.ComputeHash(Dados)
    End Function

    Public Function CalcHashByteArray(ByVal Dados() As Byte) As Byte()
        'Chama o método principal do overload repassando
        'Dados e o algoritmo Default (HashMode.MD5)
        Return CalcHashByteArray(Dados, HashMode.MD5)
    End Function


End Module
