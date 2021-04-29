Imports System.Drawing
Imports System.Web.Mobile
Imports System.Web.UI.MobileControls
Imports System.Web.UI.WebControls
Imports System.Web.UI.HtmlControls


Public Class recap_
   Inherits System.Web.UI.MobileControls.MobilePage
   Protected WithEvents recap As System.Web.UI.MobileControls.TextView
   Protected WithEvents Form1 As System.Web.UI.MobileControls.Form
   Protected WithEvents subValue As System.Web.UI.MobileControls.Label
   Protected WithEvents TaxValue As System.Web.UI.MobileControls.Label
   Protected WithEvents totalValue As System.Web.UI.MobileControls.Label
   Protected WithEvents Link1 As System.Web.UI.MobileControls.Link
   ' hard coded for simplicity
   Public ticketprice As Double = 7.25
   Public taxRate As Double = 0.08
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
      Dim movietitle As String = Session("movietitle")
      Dim starttime As String = Session("starttime")
      Dim count As Int32 = CType(Session("count"), Int32)
      Dim subtotal As Double = count * ticketprice
      Dim total As Double = subtotal * (1 + taxRate)

      recap.Text = count & " for <br /><b>" & movietitle & "</b> [" & starttime & "]<br />"
      subValue.Text = FormatNumber(subtotal, 2) & " sub "
      TaxValue.Text = FormatNumber(taxRate * subtotal, 2) & "  tax "
      totalValue.Text = "$ " & FormatNumber(total, 2) & "  tot "
   End Sub


End Class
