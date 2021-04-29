Imports System.Data.SqlClient

Public Class UpdateCompanyName
    Inherits System.Web.UI.Page
    Protected WithEvents Label1 As System.Web.UI.WebControls.Label
    Protected WithEvents DDList1 As System.Web.UI.WebControls.ListBox
    Protected WithEvents Button1 As System.Web.UI.WebControls.Button
    Protected WithEvents Label2 As System.Web.UI.WebControls.Label
    Protected WithEvents txtCompanyName As System.Web.UI.WebControls.TextBox
    Protected WithEvents Label4 As System.Web.UI.WebControls.Label
    Protected WithEvents RequiredFieldValidator1 As System.Web.UI.WebControls.RequiredFieldValidator
    Protected WithEvents Label3 As System.Web.UI.WebControls.Label

#Region " Web Form Designer Generated Code "

    'This call is required by the Web Form Designer.
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()

    End Sub

    Private Sub Page_Init(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Init
        'CODEGEN: This method call is required by the Web Form Designer
        'Do not modify it using the code editor.
        InitializeComponent()
    End Sub

#End Region

    Private Sub Page_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        'Put user code to initialize the page here
        If Not IsPostBack Then
            Call LoadDropDowns()
        End If
    End Sub

    Private Sub LoadDropDowns()
        'Datareader example
        Dim oDR1 As SqlDataReader
        'This creates a new connection object and sets the connection
        Dim oConn As New SqlConnection("Password=;User ID=sa;" & _
                    "Initial Catalog=Northwind;Data Source=(local)")
        'This creates a new command object
        Dim oCmd1 As New SqlCommand("Select * from customers", oConn)
        Dim sName As String
        Dim oItem As ListItem
        Dim sKey As String

        Try
            'Open the Connection to the Database
            oConn.Open()
            Try
                'Execute the DataReader Command
                oDR1 = oCmd1.ExecuteReader(CommandBehavior.SingleResult)
                DDList1.Items.Clear()
                While (oDR1.Read)
                    sName = oDR1.Item("companyname")
                    sKey = oDR1.Item("customerid").ToString
                    'For each row we add the CompanyName to the ListBox
                    oItem = New ListItem(sName, sKey)
                    DDList1.Items.Add(oItem)
                End While
                oDR1.Close()
            Catch oErr As System.Exception
                Label1.Text = "Execute 1: " & oErr.Message
            End Try
        Catch oErr As System.Exception
            Label1.Text = "SQL Open: " & oErr.Message
        End Try

        'Check on Connection Object, Close it
        If oConn.State = oConn.State.Open Then
            oConn.Close()
        End If

    End Sub

    Private Sub UpdateCompanyName()
        'This creates a new connection object and sets the connection
        Dim oConn As New SqlConnection("Password=;User ID=sa;" & _
                    "Initial Catalog=Northwind;Data Source=(local)")
        'This creates a new command object
        Dim oCmd1 As New SqlCommand()
        Dim sSQL As String

        sSQL = "Update Customers "
        sSQL = String.Concat(sSQL, "Set CompanyName = '")
        sSQL = String.Concat(sSQL, txtCompanyName.Text.Trim, "' ")
        sSQL = String.Concat(sSQL, "Where CustomerID = '")
        sSQL = String.Concat(sSQL, DDList1.SelectedItem.Value, "'")

        Try
            oConn.Open()
            Label1.Text = sSQL
            With oCmd1
                .CommandType = CommandType.Text
                .CommandText = sSQL
                .Connection = oConn
                .ExecuteNonQuery()
            End With
        Catch oErr As System.Exception
            Label1.Text = "ExecuteNonQuery: " & oErr.Message
        End Try

        'Check on Connection Object, Close it
        If oConn.State = oConn.State.Open Then
            oConn.Close()
        End If

    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        If Page.IsValid Then
            If DDList1.SelectedIndex > -1 Then
                Call UpdateCompanyName()
                Call LoadDropDowns()
            Else
                Label1.Text = "No Company Name from List was selected."
            End If
        End If
    End Sub

End Class
