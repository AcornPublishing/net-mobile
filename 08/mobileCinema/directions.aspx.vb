Imports System.Drawing
Imports System.Web.Mobile
Imports System.Web.UI.MobileControls
Imports System.Web.UI.WebControls
Imports System.Web.UI.HtmlControls
Imports mobileCinema.loadTheaterDetails

Public Class directions
    Inherits System.Web.UI.MobileControls.MobilePage
    Protected WithEvents TextView1 As System.Web.UI.MobileControls.TextView
    Protected WithEvents home As System.Web.UI.MobileControls.Link
    Protected WithEvents Form1 As System.Web.UI.MobileControls.Form
    Protected WithEvents movies As System.Web.UI.MobileControls.Link
    Protected WithEvents address As System.Web.UI.MobileControls.Link
    Protected details As New mobileCinema.loadTheaterDetails()

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
      details.loadDetails()
      TextView1.Text = "<b>" & details.getTextNode(1, "name") & "</b><br />" & details.getTextNode(1, "directions")
    End Sub
    
End Class
