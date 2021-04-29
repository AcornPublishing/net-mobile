Imports System.Data.SqlClient

Public Class DataSetQuickLook
    Inherits System.Web.UI.Page
    Protected WithEvents Label1 As System.Web.UI.WebControls.Label
    Protected WithEvents DDList3 As System.Web.UI.WebControls.ListBox
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

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        Call DataSetQuickLook()
    End Sub

    Private Sub DataSetQuickLook()
        'This creates a new connection object and sets the connection
        Dim oConn As New SqlConnection("Password=;User ID=sa;" & _
                    "Initial Catalog=Northwind;Data Source=(local)")
        'This creates a new command object
        Dim oCmd As New SqlCommand("Select * from customers", oConn)
        Dim oDA As SqlDataAdapter
        Dim oDS As New DataSet()
        Dim iCnt As Int32
        Dim sName As String
        Dim oItem As ListItem
        Dim sKey As String

        'Create the DataAdapter
        oDA = New SqlClient.SqlDataAdapter(oCmd)
        'Fill the DataSet
        oDA.Fill(oDS)
        DDList3.Items.Clear()
        'point to the results stored in the DataTable
        With oDS.Tables(0)
            'Iterate through the rows of the DataSet to fill dropdown
            For iCnt = 0 To .Rows.Count - 1
                sName = .Rows(iCnt).Item("CompanyName").ToString()
                sKey = .Rows(iCnt).Item("CustomerID").ToString
                oItem = New ListItem(sName, sKey)
                DDList3.Items.Add(oItem)
            Next
        End With

    End Sub

End Class
