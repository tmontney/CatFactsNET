Public Class cfnet
    Private contrl As New CatFactsNET.Controller
    Protected Overrides Sub OnStart(ByVal args() As String)
        args = Environment.GetCommandLineArgs()
        Dim err As String = String.Empty
        If StartupArgCheck(args, err) Then
            contrl = New CatFactsNET.Controller(args(1), args(2))
            contrl.StartListening()
        Else
            MyBase.EventLog.WriteEntry(err, EventLogEntryType.Error, 0)
            MyBase.Stop()
        End If
    End Sub

    Protected Overrides Sub OnStop()
        contrl.StopListening()
    End Sub

    Private Function StartupArgCheck(ByVal args() As String, ByRef msg As String) As Boolean
        If args.Count <> 3 Then
            msg = "Incorrect number of arguments."
        Else
            If Net.IPAddress.TryParse(args(1), Nothing) = False Then
                msg = "Argument 1 is the IP address the service listens on. It must be an IPv4 or IPv6 address."
            ElseIf Integer.TryParse(args(2), Nothing) = False Then
                msg = "Argument 2 is the port the service listens on. It must be a whole number."
            End If
        End If

        If msg <> String.Empty Then Return False Else Return True
    End Function
End Class
