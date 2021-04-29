Imports System.Drawing
Imports System.Web.Mobile
Imports System.Web.UI.MobileControls
Imports System.Web.UI.WebControls
Imports System.Web.UI.HtmlControls

Public Class purchase2
    Inherits System.Web.UI.MobileControls.MobilePage
    Protected WithEvents TextView1 As System.Web.UI.MobileControls.TextView
    Protected WithEvents ticketCount As System.Web.UI.MobileControls.TextBox
    Protected WithEvents subtotal As System.Web.UI.MobileControls.TextView
    Protected WithEvents recap As System.Web.UI.MobileControls.TextView
    Protected WithEvents Command1 As System.Web.UI.MobileControls.Command
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
      Dim eventid As Int32 = CType(Session("eventID"), Int32)
      Dim movietitle As String = Session("movietitle")
      Dim starttime As String = Session("starttime")
      Dim customerid As String = Session("customerID")
      recap.Text = "<b>" & movietitle & "</b> [" & starttime & "]"
    End Sub

    
    Private Sub Command1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Command1.Click
      'the openwave 5.0 phone emulator has a problem with 
      'characters being appended to this field
      Dim result As String = ticketCount.Text
      Dim index As Int32 = result.IndexOfAny("abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ")
      If index > 0 Then
         result = result.Substring(0, index)
      End If

      Session("count") = result
      Response.Redirect("recap.aspx")
   End Sub
End Class
