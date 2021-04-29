Imports System.Drawing
Imports System.Web.Mobile
Imports System.Web.UI.MobileControls
Imports System.Web.UI.WebControls
Imports System.Web.UI.HtmlControls
Imports System.Xml
Imports System.IO
Imports System.Data
Imports mobileCinema.loadTheaterDetails

Public Class home
    Inherits System.Web.UI.MobileControls.MobilePage
    Protected WithEvents Title As System.Web.UI.MobileControls.TextView
    Protected WithEvents theater As System.Web.UI.MobileControls.Link
    Protected WithEvents callTheater As System.Web.UI.MobileControls.Call
    Protected WithEvents Form2 As System.Web.UI.MobileControls.Form
    Protected WithEvents Form1 As System.Web.UI.MobileControls.Form

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
      Dim xData As New loadTheaterDetails()
      Dim result As String = xData.loadDetails()
      If result = "success" Then
         Title.Text = "<br />Theater"
         theater.Text = xData.getTextNode(1, "name")
         callTheater.Text = "Info Line"
         callTheater.PhoneNumber = xData.getTextNode(1, "phone")
         callTheater.AlternateFormat = "{0} at {1}"
      Else
         Title.Text = result ' show error message
      End If
    End Sub



End Class
