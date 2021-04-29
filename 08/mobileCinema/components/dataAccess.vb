Imports System.Data
Imports System.Data.SqlClient

Public Class dataAccess

    Private conStr As String = "Persist Security Info=False;User ID=[userID]; password=[password];Initial Catalog=[database name];Data Source=[server name]"
    '= "server=(local);database=mobileWeb;Trusted_Connection=yes" 'default value
    Private Conn As SqlConnection = New SqlConnection()
    Private Cmd As SqlCommand = New SqlCommand()
    Private ds As DataSet = New DataSet()

    Public Property ConnectionString() As String
        Get
            Return conStr
        End Get
        Set(ByVal Value As String)
            conStr = Value
        End Set
    End Property

    Private Sub initializeProcedure(ByVal CommandText As String)
        Conn.ConnectionString = conStr
        Cmd.Connection = Conn
        Cmd.CommandType = CommandType.StoredProcedure
        Cmd.CommandText = CommandText
    End Sub

    Public Function loadMovies() As DataSet
        initializeProcedure("returnAllMovies")
        Dim da As SqlDataAdapter = New SqlDataAdapter(Cmd)
        Conn.Open()
        da.Fill(ds, "movie")
        Conn.Close()
        loadMovies = ds
    End Function

    Public Function getTimes(ByVal MovieId As Integer) As DataSet
        initializeProcedure("getTimeofMovie")
        Cmd.Parameters.Add(New SqlParameter("@MovieID", SqlDbType.Int, 4))
        Cmd.Parameters("@MovieID").Value = MovieId

        Dim da As SqlDataAdapter = New SqlDataAdapter(Cmd)
        Conn.Open()
        da.Fill(ds, "event")
        Conn.Close()
        getTimes = ds
    End Function

    Public Function buyTickets(ByVal EventID As Integer, ByVal CustomerID As String, ByVal Tickets As Integer) As String
        initializeProcedure("buyTickets")
        Cmd.Parameters.Add(New SqlParameter("@EventID", SqlDbType.Int, 4))
        Cmd.Parameters("@EventID").Value = EventID

        Cmd.Parameters.Add(New SqlParameter("@CustomerID", SqlDbType.Int, 4))
        Cmd.Parameters("@CustomerID").Value = CustomerID

        Cmd.Parameters.Add(New SqlParameter("@Tickets", SqlDbType.Int, 4))
        Cmd.Parameters("@Tickets").Value = Tickets

        Dim results As String
        Cmd.Connection.Open()
        Dim sdr As SqlDataReader = Cmd.ExecuteReader(CommandBehavior.CloseConnection)
        While sdr.Read()
            results = sdr.GetString(0)
        End While
        sdr.Close()
        Conn.Close()
        If Len(results) > 0 Then
            buyTickets = results
        Else
            buyTickets = "Transaction not processed"
        End If
    End Function

End Class
