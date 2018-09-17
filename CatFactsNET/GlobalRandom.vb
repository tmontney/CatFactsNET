Public Class GlobalRandom : Inherits Random
    Public Shared rnd As GlobalRandom = New GlobalRandom

    Public Sub New()
        MyBase.New()
    End Sub
End Class
