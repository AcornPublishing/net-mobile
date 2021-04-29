Imports System.Drawing
Imports System.Web.Mobile
Imports System.Web.UI.MobileControls
Imports System.Web.UI.WebControls
Imports System.Web.UI.HtmlControls
Imports mobileCinema.dataAccess


Public Class purchase3
    Inherits System.Web.UI.MobileControls.MobilePage
    Protected WithEvents TextView1 As System.Web.UI.MobileControls.TextView
    Protected WithEvents Form1 As System.Web.UI.MobileControls.Form
    Protected WithEvents home As System.Web.UI.MobileControls.Link
    Protected WithEvents TextView2 As System.Web.UI.MobileControls.TextView
    Protected WithEvents TextView3 As System.Web.UI.MobileControls.TextView
    Protected dso As New mobileCinema.dataAccess()
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
        Dim eventid As Int32 = CType(Session("eventid"), Int32)
        Dim customerid As Int32 = CType(Session("customerid"), Int32)
        Dim count As Int32 = CType(Session("count"), Int32)

        Dim transkey As String = dso.buyTickets(eventid, customerid, count)
        TextView1.Text = "Thank you for your purchase!" & "<br /> your transaction key is:<br />"
        TextView2.Font.Bold = BooleanOption.True
        TextView2.Font.Name = "arial"
        TextView2.Text = transkey
        TextView3.Text = "bookmark this page."
    End Sub

End Class
