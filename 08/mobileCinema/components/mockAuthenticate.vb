Imports System

Public Class mockLogin

    Public Function authenticateUser(ByVal login As String, ByVal password As String) As String
        'login authentication logic or method call goes here.
        'could use a standard DB, possibly passport or a similar service
        'this is some dummy logic to generate a customerID
        Dim customerid As String
        Dim temp As Array = login.Split(".")
        Dim logLen As Int32 = Len(login)
        Dim passLen As Int32 = Len(password)
        customerid = logLen & passLen & (passLen * passLen)
        authenticateUser = customerid
    End Function

End Class
