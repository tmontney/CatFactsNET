Imports Grapevine.Interfaces.Server
Public Class Routes
    <Grapevine.Server.Attributes.RestResource>
    Public Class Actions
        <Grapevine.Server.Attributes.RestRoute(HttpMethod:=Grapevine.Shared.HttpMethod.GET, PathInfo:=Paths.CATFACT)>
        Public Function CatFact(ByVal Context As IHttpContext) As IHttpContext
            Dim serializer As New Web.Script.Serialization.JavaScriptSerializer
            Dim CatFactsData As Object() = serializer.DeserializeObject(My.Resources.CatFacts)

            Dim Index As Integer = GlobalRandom.rnd.Next(0, CatFactsData.Length - 1)
            Dim CatFactStr As String = CatFactsData(Index)

            Context.Response.StatusCode = Grapevine.Shared.HttpStatusCode.Ok
            Context.Response.SendResponse(Text.ASCIIEncoding.ASCII.GetBytes(CatFactStr))
            Console.WriteLine("Generated random fact: " & CatFactStr)
            Return Context
        End Function
    End Class

    <Grapevine.Server.Attributes.RestRoute(HttpMethod:=Grapevine.Shared.HttpMethod.OPTIONS, PathInfo:=Paths.CATFACT)>
    Public Function CatFactOpt(ByVal Context As IHttpContext) As IHttpContext
        'Recommended to change this from wildcard to your domain name
        Context.Response.AddHeader("Access-Control-Allow-Origin", "*")
        Context.Response.AddHeader("Access-Control-Allow-Methods", "GET,OPTIONS")

        Context.Response.SendResponse(Text.ASCIIEncoding.ASCII.GetBytes(String.Empty))
        Context.Response.StatusCode = Grapevine.Shared.HttpStatusCode.Ok
        Return Context
    End Function
    Public Class Paths
        Public Const CATFACT As String = "/API/CATFACT"
    End Class
End Class
