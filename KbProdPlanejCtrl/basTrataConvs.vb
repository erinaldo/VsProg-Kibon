Module basTrataConvs


    Function ConvWordBytes(MyLong As Long, ByRef MyInt1 As Long, ByRef MyInt2 As Long) As Boolean

        If MyLong < 0 Then
            MyLong = 65536 + MyLong
        End If

        MyInt1 = Int(MyLong / &H100)
        MyInt2 = MyLong - MyInt1 * &H100

        Return True

    End Function

    Function ConvBytesWord(ByRef MyLong As Long, ByRef MyInt1 As Integer, ByRef MyInt2 As Integer) As Boolean

        Dim MyLng1 As Long
        Dim MyLng2 As Long

        MyLng1 = MyInt1
        MyLng2 = MyInt2

        If MyInt1 = 0 And MyInt2 = 0 Then

            MyLong = 0
            Return False

        End If

        MyLong = MyLng1 * &H100 + MyLng2
        If MyLong > 32767 Then MyLong = MyLong - (CLng(32767) * 2) - 2

        Return True

    End Function

    Function ConvLongInts(MyLong As Long, ByRef MyInt1 As Long, ByRef MyInt2 As Long) As Boolean

        If MyLong < 0 Then
            MyLong = 4294967296.0# + MyLong
        End If

        MyInt1 = Int(MyLong / &H10000)
        MyInt2 = MyLong - MyInt1 * &H10000

        Return True

    End Function

    Function ConvIntsLong(MyLong As Long, ByRef MyInt1 As Integer, ByRef MyInt2 As Integer) As Boolean

        Dim MyLng1 As Long
        Dim MyLng2 As Long

        MyLng1 = MyInt1
        MyLng2 = MyInt2

        If MyInt1 = 0 And MyInt2 = 0 Then

            MyLong = 0
            Return False

        End If

        MyLong = MyLng1 * &H10000 + MyLng2
        If MyLong > 2147483647 Then MyLong = MyLong - (CLng(2147483647) * 2) - 2

        Return True

    End Function
End Module
