Module Core
    Private ListenOnIP As String = Net.IPAddress.Loopback.ToString()
    Private ListOnPort As Integer = 1337
    Sub Main()
        Dim contr As New Grapevine.Server.RestServer With {.Host = ListenOnIP, .Port = ListOnPort}
        contr.LogToConsole().Start()
    End Sub
End Module
