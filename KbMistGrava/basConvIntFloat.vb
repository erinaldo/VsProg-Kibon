Module basConvIntFloat

    Function TwoSIntToFloat(Wd1 As Long, Wd2 As Long) As Single

        'Converte para Hex
        Dim hexValue As String = Strings.Right("0000" & Hex(Wd2), 4) & Strings.Right("0000" & Hex(Wd1), 4)

        Dim Valor As Single = ConvertHexToSingle(hexValue)

        Return Valor

    End Function

    Private Function ConvertHexToSingle(ByVal hexValue As String) As Single

        Try

            Dim iInputIndex As Integer = 0

            Dim iOutputIndex As Integer = 0

            Dim bArray(3) As Byte



            For iInputIndex = 0 To hexValue.Length - 1 Step 2

                bArray(iOutputIndex) = Byte.Parse(hexValue.Chars(iInputIndex) & hexValue.Chars(iInputIndex + 1), Globalization.NumberStyles.HexNumber)

                iOutputIndex += 1

            Next



            Array.Reverse(bArray)



            Return BitConverter.ToSingle(bArray, 0)

        Catch ex As Exception

            Throw New FormatException("The supplied hex value is either empty or in an incorrect format. Use the following format: 00000000", ex)

        End Try



    End Function

End Module
