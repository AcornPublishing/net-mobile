Imports System.Drawing
Imports System.Web.Mobile
Imports System.Web.UI.MobileControls
Imports System.Web.UI.WebControls
Imports System.Web.UI.HtmlControls
Imports System.Web
Imports mobileCinema.dataAccess

Public Class showTimes
    Inherits System.Web.UI.MobileControls.MobilePage
    Protected WithEvents Form1 As System.Web.UI.MobileControls.Form
    Private dso As New dataAccess()
    Public title As String
    Protected WithEvents movieTitle As System.Web.UI.MobileControls.TextView
    Protected WithEvents startTimes As System.Web.UI.MobileControls.List
    Public movieID As Int32
  
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
        movieID = CType(Request.QueryString("movieid"), Int32)
        title = Request.QueryString("title")
        movieTitle.Text = "Buy tickets for:<br /><b>" & title & "</b>"
        startTimes.DataSource = dso.getTimes(movieID).Tables(0)
        startTimes.DataTextField = "start-time"
        startTimes.DataValueField = "id"
        startTimes.ItemsAsLinks = True
        startTimes.DataBind()

        Dim i As Int32
        Dim time As String
        For i = 0 To startTimes.Items.Count - 1
            title = HttpUtility.UrlEncode(title)
            time = HttpUtility.UrlEncode(startTimes.Items(i).Text)
            startTimes.Items(i).Value = "purchase1.aspx?eventid=" & startTimes.Items(i).Value & "&title=" & title & "&time=" & time
        Next

    End Sub
    
End Class
