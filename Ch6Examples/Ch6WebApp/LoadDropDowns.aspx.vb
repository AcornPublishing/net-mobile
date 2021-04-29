Imports System.Data.SqlClient

Public Class LoadDropDowns
    Inherits System.Web.UI.Page
    Protected WithEvents DDList1 As System.Web.UI.WebControls.ListBox
    Protected WithEvents DDList2 As System.Web.UI.WebControls.ListBox
    Protected WithEvents Label1 As System.Web.UI.WebControls.Label
    Protected WithEvents Button1 As System.Web.UI.WebControls.Button

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
    End Sub

    Private Sub LoadDropDowns()
        'Datareader example
        Dim oDR1 As SqlDataReader
        Dim oDR2 As SqlDataReader
        'This creates a new connection object and sets the connection
        Dim oConn As New SqlConnection("Password=;User ID=sa;" & _
                    "Initial Catalog=Northwind;Data Source=(local)")
        'This creates a new command object
        Dim oCmd1 As New SqlCommand("Select * from customers", oConn)
        Dim oCmd2 As New SqlCommand("Select * from employees", oConn)
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
                Label1.Text = String.Concat("Execute 1: ", oErr.Message)
            End Try
            'Execute the DataReader Command
            Try
                oDR2 = oCmd2.ExecuteReader(CommandBehavior.SingleResult)
                DDList2.Items.Clear()
                While (oDR2.Read)
                    'For each row we add the employee to the ListBox
                    sName = oDR2.Item("LastName")
                    sName = sName & ", " & oDR2.Item("FirstName")
                    sName = sName & oDR2.Item("FirstName")
                    sKey = oDR2.Item("employeeID").ToString
                    oItem = New ListItem(sName, sKey)
                    DDList2.Items.Add(oItem)
                End While
                oDR2.Close()
            Catch oErr As System.Exception
                Label1.Text = String.Concat("Execute 2: ", oErr.Message)
            End Try
        Catch oErr As System.Exception
            Label1.Text = String.Concat("SQL Open: ", oErr.Message)
        End Try

        'Check on Connection Object, Close it
        If oConn.State = oConn.State.Open Then
            oConn.Close()
        End If

    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        Call LoadDropDowns()
    End Sub
End Class
