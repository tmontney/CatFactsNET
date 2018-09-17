Public Class Routes
    <Grapevine.Server.Attributes.RestResource>
    Public Class Actions
        <Grapevine.Server.Attributes.RestRoute(HttpMethod:=Grapevine.Shared.HttpMethod.GET, PathInfo:=Paths.CATFACT)>
        Public Function CatFact(ByVal Context As Grapevine.Interfaces.Server.IHttpContext) As Grapevine.Interfaces.Server.IHttpContext
            Dim serializer As New Web.Script.Serialization.JavaScriptSerializer
            Dim CatFactsData As Object() = serializer.DeserializeObject(My.Resources.CatFacts)

            Dim r As New Random()
            Dim Index As Integer = r.Next(0, CatFactsData.Length - 1)

            Context.Response.StatusCode = Grapevine.Shared.HttpStatusCode.Ok
            Context.Response.SendResponse(Text.ASCIIEncoding.ASCII.GetBytes(CatFactsData(Index)))
            Console.WriteLine("Generated random fact: " & CatFactsData(Index))
            Return Context
        End Function
    End Class
    Public Class Paths
        Public Const CATFACT As String = "/API/CATFACT"
    End Class
End Class
