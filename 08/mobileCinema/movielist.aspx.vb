Imports System.Drawing
Imports System.Web.Mobile
Imports System.Web.UI.MobileControls
Imports System.Web.UI.WebControls
Imports System.Web.UI.HtmlControls
Imports System.Web ' needed for UrlEncode

Public Class movielist
    Inherits System.Web.UI.MobileControls.MobilePage
    Protected WithEvents movieList As System.Web.UI.MobileControls.List
    Protected WithEvents Form1 As System.Web.UI.MobileControls.Form
    Public dso As dataAccess = New dataAccess()
    Protected WithEvents ObjectList1 As System.Web.UI.MobileControls.ObjectList
    Public DS As DataSet

#Region " Web Forms Designer Generated Code "

    'CODEGEN: This procedure is required by the Web Form Designer
    'Do not modify it using the code editor.
    Private Sub InitializeComponent()

    End Sub

    Private Sub Page_Init(ByVal Sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Init
        'CODEGEN: This method call is required by the Web Form Designer
        'Do not modify it using the code editor.
        InitializeComponent()
    End Sub

#End Region

    Private Sub Page_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        dso.ConnectionString = "Persist Security Info=False;User ID=[userID]; password=[password];Initial Catalog=[database name];Data Source=[server name]"
        DS = dso.loadMovies()
        movieList.DataSource = DS.Tables(0)
        movieList.DataTextField = "MovieTitle"
        movieList.DataValueField = "MovieID" ' generates links of the form: href="1"
        movieList.Font.Name = "arial"
        movieList.DataBind()

        'update href attributes so they are of the form: href="purchase1.aspx?movieid=1&title=Cast%20Away"
        Dim i As Int32
        Dim title As String
        For i = 0 To movieList.Items.Count - 1
            title = HttpUtility.UrlEncode(movieList.Items(i).Text)
            movieList.Items(i).Value = "showtimes.aspx?movieid=" & movieList.Items(i).Value & "&title=" & title
        Next

    End Sub

End Class
