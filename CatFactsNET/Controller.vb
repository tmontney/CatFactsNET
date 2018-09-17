Public Class Controller
    Private listener As Grapevine.Server.RestServer
    Public Sub New(ByVal ip As String, ByVal port As Integer, Optional ByVal secure As Boolean = False)
        Dim listenerOptions As New Grapevine.Server.ServerSettings With {
            .Host = ip,
            .Port = port,
            .UseHttps = secure
        }

        listener = New Grapevine.Server.RestServer(listenerOptions)
    End Sub

    Public Sub New()
    End Sub

    Public Sub StartListening()
        If listener IsNot Nothing AndAlso listener.IsListening = False Then listener.Start()
    End Sub

    Public Sub StopListening()
        If listener IsNot Nothing AndAlso listener.IsListening Then listener.Stop()
    End Sub
End Class
