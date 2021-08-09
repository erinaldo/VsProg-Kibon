Public Module basLogout

    'Declaracao de Funcoes API
    Private Declare Function SendNotifyMessage Lib "user32" Alias "SendNotifyMessageA" _
        (ByVal hwnd As Integer, ByVal msg As Integer, ByVal wParam As Integer, ByVal lParam As Integer) As Integer

    Private Declare Function FindWindow Lib "user32" Alias "FindWindowA" _
        (ByVal lpClassName As String, ByVal lpWindowName As String) As Integer

    Private Declare Function WindowFromPoint Lib "user32" (ByVal xPoint As Integer, ByVal yPoint As Integer) As Integer

    Private Declare Function GetClassName Lib "user32" Alias "GetClassNameA" _
                        (ByVal hwnd As Integer, ByVal lpClassName As String, ByVal nMaxCount As Integer) As Integer

    'Constantes
    Private Const WM_KEYDOWN = &H100
    Private Const WM_LBUTTONDOWN = &H201
    Private Const WM_LBUTTONUP = &H202

    Function FimLogout(ByVal Prog As String) As Boolean

        Dim Ret As Integer

        Dim localByName As Process() = Process.GetProcessesByName(Prog)

        For Conta As Integer = 0 To localByName.Length - 1
            'Valor 224 é o valor a ser enviado como tecla pressionada e que será lida pelo 
            'evento KeyDown do formulario
            Ret = SendNotifyMessage(localByName(Conta).MainWindowHandle, WM_KEYDOWN, 224, &H0)
        Next

        Return True

    End Function

    Function FimProg(ByVal Prog As String) As Boolean

        Dim localByName As Process() = Process.GetProcessesByName(Prog)

        For Conta As Integer = 0 To localByName.Length - 1
            localByName(Conta).Kill()
        Next

        Return True

    End Function
End Module
