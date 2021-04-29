Imports System.Drawing
Imports System.Web.Mobile
Imports System.Web.UI.MobileControls
Imports System.Web.UI.WebControls
Imports System.Web.UI.HtmlControls
Imports mobileCinema.mockLogin
Imports System.Web

Public Class purchase1
    Inherits System.Web.UI.MobileControls.MobilePage
    Protected WithEvents Label1 As System.Web.UI.MobileControls.Label
    Protected WithEvents login As System.Web.UI.MobileControls.TextBox
    Protected WithEvents Command1 As System.Web.UI.MobileControls.Command
    Protected WithEvents password As System.Web.UI.MobileControls.TextBox
    Protected WithEvents Label2 As System.Web.UI.MobileControls.Label
    Protected WithEvents hiddenMovieId As System.Web.UI.MobileControls.Label
    Protected WithEvents TextView1 As System.Web.UI.MobileControls.TextView
    Protected WithEvents Form1 As System.Web.UI.MobileControls.Form
    Protected WithEvents RequiredFieldValidator1 As System.Web.UI.MobileControls.RequiredFieldValidator
    Protected WithEvents RequiredFieldValidator2 As System.Web.UI.MobileControls.RequiredFieldValidator
    Protected WithEvents RegularExpressionValidator1 As System.Web.UI.MobileControls.RegularExpressionValidator
    Private logUser As New mobileCinema.mockLogin()
   
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
        TextView1.Text = "<b>Buy tickets</b>"
        If Not IsPostBack Then
            Session("eventID") = Request.QueryString("eventid")
            Session("movietitle") = HttpUtility.UrlDecode(Request.QueryString("title"))
            Session("starttime") = Request.QueryString("time")
        End If
    End Sub

    Private Sub Command1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Command1.Click
        Session("customerID") = logUser.authenticateUser(login.Text, password.Text)
        'TextView1.Text = Session("customerID")
        Response.Redirect("purchase2.aspx")
    End Sub
End Class
