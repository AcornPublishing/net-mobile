Imports System.Data.SqlClient
Imports System.Web.Services

<WebService(Namespace := "http://tempuri.org/")> _
Public Class NorthwindData
    Inherits System.Web.Services.WebService

#Region " Web Services Designer Generated Code "

    Public Sub New()
        MyBase.New()

        'This call is required by the Web Services Designer.
        InitializeComponent()

        'Add your own initialization code after the InitializeComponent() call

    End Sub

    'Required by the Web Services Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Web Services Designer
    'It can be modified using the Web Services Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        components = New System.ComponentModel.Container()
    End Sub

    Protected Overloads Overrides Sub Dispose(ByVal disposing As Boolean)
        'CODEGEN: This procedure is required by the Web Services Designer
        'Do not modify it using the code editor.
        If disposing Then
            If Not (components Is Nothing) Then
                components.Dispose()
            End If
        End If
        MyBase.Dispose(disposing)
    End Sub

#End Region

    <WebMethod()> Public Function GetCustomerList() As DataSet
        Dim oConn As New SqlConnection("Password=;User ID=sa;" & _
                    "Initial Catalog=Northwind;Data Source=(local)")
        'This creates a new command object
        Dim oCmd As New SqlCommand("Select * from customers", oConn)
        Dim oDA As SqlDataAdapter
        Dim oDS As New DataSet()

        'Create the DataAdapter
        oDA = New SqlClient.SqlDataAdapter(oCmd)
        'Fill the DataSet
        oDA.Fill(oDS, "Customers")
        oDA.FillSchema(oDS.Tables("Customers"), SchemaType.Mapped)

        Return oDS

    End Function

    <WebMethod()> Public Function GetCustomerListString() As String
        Dim oConn As New SqlConnection("Password=;User ID=sa;" & _
                    "Initial Catalog=Northwind;Data Source=(local)")
        'This creates a new command object
        Dim oCmd As New SqlCommand("Select * from customers", oConn)
        Dim oDA As SqlDataAdapter
        Dim oDS As New DataSet()

        'Create the DataAdapter
        oDA = New SqlClient.SqlDataAdapter(oCmd)
        'Fill the DataSet
        oDA.Fill(oDS)

        Return oDS.GetXml

    End Function

    <WebMethod()> Public Function GetCustomerOrders() As DataSet
        Dim oConn As New SqlConnection("Password=;User ID=sa;" & _
                    "Initial Catalog=Northwind;Data Source=(local)")
        'This creates a new command object
        Dim oDA1 As New SqlDataAdapter("Select * from customers", oConn)
        Dim oDA2 As New SqlDataAdapter("Select * from orders", oConn)
        Dim oDS As New DataSet("CustomerOrders")

        oConn.Open()
        'setup a datatable in dataset with Customers
        oDA1.Fill(oDS, "Customers")
        'setup a datatable in dataset with Customers
        oDA2.Fill(oDS, "Orders")

        'setup relationship between the datatables
        With oDS
            .Relations.Add("CustOrders", _
                .Tables("Customers").Columns("CustomerID"), _
                .Tables("Orders").Columns("CustomerID")).Nested = True
        End With

        'Check on Connection Object, Close it
        If oConn.State = oConn.State.Open Then
            oConn.Close()
        End If

        Return oDS

    End Function

    <WebMethod()> Public Sub UpdateCustomerOrders(ByVal oDS As DataSet)

        'update the Customer DataTable of the DataSet
        Call UpdateCustomerDT(oDS)
        'update the Order DataTable of the DataSet
        Call UpdateOrdersDT(oDS)
        'Check on Connection Object, Close it

    End Sub

    <WebMethod()> Public Sub UpdateCustomerList(ByVal oDS As DataSet)
        Dim oConn As New SqlConnection("Password=;User ID=sa;" & _
                    "Initial Catalog=Northwind;Data Source=(local)")
        'This creates a new command object
        Dim oCmdSelect As New SqlCommand()
        Dim oCmdInsert As New SqlCommand()
        Dim oCmdUpdate As New SqlCommand()
        Dim oCmdDelete As New SqlCommand()
        Dim oDA As SqlDataAdapter
        Dim oTran As SqlTransaction

        oConn.Open()
        oTran = oConn.BeginTransaction()

        'Create the DataAdapter
        oDA = New SqlClient.SqlDataAdapter()
        With oDA
            .SelectCommand = oCmdSelect
            .InsertCommand = oCmdInsert
            .UpdateCommand = oCmdUpdate
            .DeleteCommand = oCmdDelete
        End With

        '
        'oCmdSelect
        '
        With oCmdSelect
            .CommandText = "SELECT CustomerID, CompanyName, ContactName," & _
            " ContactTitle, Address, City, Region," & _
            " PostalCode, Country, Phone, Fax FROM Customers"
            .Connection = oConn
        End With
        '
        'oCmdInsert
        '
        With oCmdInsert
            .CommandType = CommandType.Text
            .CommandText = "INSERT INTO Customers(CustomerID, CompanyName," & _
            " ContactName, ContactTitle, Address, City, Region, PostalCode," & _
            " Country, Phone, Fax) VALUES (@CustomerID, @CompanyName," & _
            " @ContactName, @ContactTitle, @Address, @City, @Region," & _
            " @PostalCode, @Country, @Phone, @Fax)"
            .Connection = oConn
            .Parameters.Add(New SqlParameter("@CustomerID", _
                        System.Data.SqlDbType.NChar, 5, _
                        System.Data.ParameterDirection.Input, False, _
                        CType(0, Byte), CType(0, Byte), "CustomerID", _
                        System.Data.DataRowVersion.Current, Nothing))
            .Parameters.Add(New SqlParameter("@CompanyName", _
                        System.Data.SqlDbType.NVarChar, 40, _
                        System.Data.ParameterDirection.Input, False, _
                        CType(0, Byte), CType(0, Byte), "CompanyName", _
                        System.Data.DataRowVersion.Current, Nothing))
            .Parameters.Add(New SqlParameter("@ContactName", _
                        System.Data.SqlDbType.NVarChar, 30, _
                        System.Data.ParameterDirection.Input, True, _
                        CType(0, Byte), CType(0, Byte), "ContactName", _
                        System.Data.DataRowVersion.Current, Nothing))
            .Parameters.Add(New SqlParameter("@ContactTitle", _
                        System.Data.SqlDbType.NVarChar, 30, _
                        System.Data.ParameterDirection.Input, True, _
                        CType(0, Byte), CType(0, Byte), "ContactTitle", _
                        System.Data.DataRowVersion.Current, Nothing))
            .Parameters.Add(New SqlParameter("@Address", _
                        System.Data.SqlDbType.NVarChar, 60, _
                        System.Data.ParameterDirection.Input, True, _
                        CType(0, Byte), CType(0, Byte), "Address", _
                        System.Data.DataRowVersion.Current, Nothing))
            .Parameters.Add(New SqlParameter("@City", _
                        System.Data.SqlDbType.NVarChar, 15, _
                        System.Data.ParameterDirection.Input, True, _
                        CType(0, Byte), CType(0, Byte), "City", _
                        System.Data.DataRowVersion.Current, Nothing))
            .Parameters.Add(New SqlParameter("@Region", _
                        System.Data.SqlDbType.NVarChar, 15, _
                        System.Data.ParameterDirection.Input, True, _
                        CType(0, Byte), CType(0, Byte), "Region", _
                        System.Data.DataRowVersion.Current, Nothing))
            .Parameters.Add(New SqlParameter("@PostalCode", _
                        System.Data.SqlDbType.NVarChar, 10, _
                        System.Data.ParameterDirection.Input, True, _
                        CType(0, Byte), CType(0, Byte), "PostalCode", _
                        System.Data.DataRowVersion.Current, Nothing))
            .Parameters.Add(New SqlParameter("@Country", _
                        System.Data.SqlDbType.NVarChar, 15, _
                        System.Data.ParameterDirection.Input, True, _
                        CType(0, Byte), CType(0, Byte), "Country", _
                        System.Data.DataRowVersion.Current, Nothing))
            .Parameters.Add(New SqlParameter("@Phone", _
                        System.Data.SqlDbType.NVarChar, 24, _
                        System.Data.ParameterDirection.Input, True, _
                        CType(0, Byte), CType(0, Byte), "Phone", _
                        System.Data.DataRowVersion.Current, Nothing))
            .Parameters.Add(New SqlParameter("@Fax", _
                        System.Data.SqlDbType.NVarChar, 24, _
                        System.Data.ParameterDirection.Input, True, _
                        CType(0, Byte), CType(0, Byte), "Fax", _
                        System.Data.DataRowVersion.Current, Nothing))
            .Transaction = oTran
        End With
        '
        'oCmdUpdate
        '
        With oCmdUpdate
            .CommandType = CommandType.Text
            .CommandText = "UPDATE Customers SET CustomerID = @CustomerID," & _
            " CompanyName = @CompanyName, ContactName = @ContactName," & _
            " ContactTitle = @ContactTitle, Address = @Address, City = @City," & _
            " Region = @Region, PostalCode = @PostalCode, Country = @Country," & _
            " Phone = @Phone, Fax = @Fax WHERE (CustomerID = @Original_CustomerID)"
            .Connection = oConn
            .Parameters.Add(New SqlParameter("@CustomerID", _
                        System.Data.SqlDbType.NChar, 5, _
                        System.Data.ParameterDirection.Input, False, _
                        CType(0, Byte), CType(0, Byte), "CustomerID", _
                        System.Data.DataRowVersion.Current, Nothing))
            .Parameters.Add(New SqlParameter("@CompanyName", _
                    System.Data.SqlDbType.NVarChar, 40, _
                    System.Data.ParameterDirection.Input, False, _
                    CType(0, Byte), CType(0, Byte), "CompanyName", _
                    System.Data.DataRowVersion.Current, Nothing))
            .Parameters.Add(New SqlParameter("@ContactName", _
                    System.Data.SqlDbType.NVarChar, 30, _
                    System.Data.ParameterDirection.Input, True, _
                    CType(0, Byte), CType(0, Byte), "ContactName", _
                    System.Data.DataRowVersion.Current, Nothing))
            .Parameters.Add(New SqlParameter("@ContactTitle", _
                    System.Data.SqlDbType.NVarChar, 30, _
                    System.Data.ParameterDirection.Input, True, _
                    CType(0, Byte), CType(0, Byte), "ContactTitle", _
                    System.Data.DataRowVersion.Current, Nothing))
            .Parameters.Add(New SqlParameter("@Address", _
                    System.Data.SqlDbType.NVarChar, 60, _
                    System.Data.ParameterDirection.Input, True, _
                    CType(0, Byte), CType(0, Byte), "Address", _
                    System.Data.DataRowVersion.Current, Nothing))
            .Parameters.Add(New SqlParameter("@City", _
                    System.Data.SqlDbType.NVarChar, 15, _
                    System.Data.ParameterDirection.Input, True, _
                    CType(0, Byte), CType(0, Byte), "City", _
                    System.Data.DataRowVersion.Current, Nothing))
            .Parameters.Add(New SqlParameter("@Region", _
                    System.Data.SqlDbType.NVarChar, 15, _
                    System.Data.ParameterDirection.Input, True, _
                    CType(0, Byte), CType(0, Byte), "Region", _
                    System.Data.DataRowVersion.Current, Nothing))
            .Parameters.Add(New SqlParameter("@PostalCode", _
                    System.Data.SqlDbType.NVarChar, 10, _
                    System.Data.ParameterDirection.Input, True, _
                    CType(0, Byte), CType(0, Byte), "PostalCode", _
                    System.Data.DataRowVersion.Current, Nothing))
            .Parameters.Add(New SqlParameter("@Country", _
                    System.Data.SqlDbType.NVarChar, 15, _
                    System.Data.ParameterDirection.Input, True, _
                    CType(0, Byte), CType(0, Byte), "Country", _
                    System.Data.DataRowVersion.Current, Nothing))
            .Parameters.Add(New SqlParameter("@Phone", _
                    System.Data.SqlDbType.NVarChar, 24, _
                    System.Data.ParameterDirection.Input, True, _
                    CType(0, Byte), CType(0, Byte), "Phone", _
                    System.Data.DataRowVersion.Current, Nothing))
            .Parameters.Add(New SqlParameter("@Fax", _
                    System.Data.SqlDbType.NVarChar, 24, _
                    System.Data.ParameterDirection.Input, True, _
                    CType(0, Byte), CType(0, Byte), "Fax", _
                    System.Data.DataRowVersion.Current, Nothing))
            .Parameters.Add(New SqlParameter("@Original_CustomerID", _
                    System.Data.SqlDbType.NChar, 5, _
                    System.Data.ParameterDirection.Input, False, _
                    CType(0, Byte), CType(0, Byte), "CustomerID", _
                    System.Data.DataRowVersion.Original, Nothing))
            .Transaction = oTran
        End With
        'With oCmdUpdate
        '    .CommandType = CommandType.Text
        '    .CommandText = "UPDATE Customers SET CustomerID = @CustomerID," & _
        '    " CompanyName = @CompanyName, ContactName = @ContactName," & _
        '    " ContactTitle = @ContactTitle, Address = @Address, City = @City," & _
        '    " Region = @Region, PostalCode = @PostalCode, Country = @Country," & _
        '    " Phone = @Phone, Fax = @Fax WHERE (CustomerID = @Original_CustomerID) AND (Address = @Origi" & _
        '    "nal_Address OR @Original_Address1 IS NULL AND Address IS NULL) AND (City = @Orig" & _
        '    "inal_City OR @Original_City1 IS NULL AND City IS NULL) AND (CompanyName = @Origi" & _
        '    "nal_CompanyName) AND (ContactName = @Original_ContactName OR @Original_ContactNa" & _
        '    "me1 IS NULL AND ContactName IS NULL) AND (ContactTitle = @Original_ContactTitle " & _
        '    "OR @Original_ContactTitle1 IS NULL AND ContactTitle IS NULL) AND (Country = @Ori" & _
        '    "ginal_Country OR @Original_Country1 IS NULL AND Country IS NULL) AND (Fax = @Ori" & _
        '    "ginal_Fax OR @Original_Fax1 IS NULL AND Fax IS NULL) AND (Phone = @Original_Phon" & _
        '    "e OR @Original_Phone1 IS NULL AND Phone IS NULL) AND (PostalCode = @Original_Pos" & _
        '    "talCode OR @Original_PostalCode1 IS NULL AND PostalCode IS NULL) AND (Region = @" & _
        '    "Original_Region OR @Original_Region1 IS NULL AND Region IS NULL)" & _
        '    '"; SELECT Custome" & _
        '    '"rID, CompanyName, ContactName, ContactTitle, Address, City, Region, PostalCode, " & _
        '    '"Country, Phone, Fax FROM Customers WHERE (CustomerID = @Select_CustomerID)"
        '    .Connection = oConn
        '    .Parameters.Add(New SqlParameter("@CustomerID", System.Data.SqlDbType.NChar, 5, System.Data.ParameterDirection.Input, False, CType(0, Byte), CType(0, Byte), "CustomerID", System.Data.DataRowVersion.Current, Nothing))
        '    .Parameters.Add(New SqlParameter("@CompanyName", System.Data.SqlDbType.NVarChar, 40, System.Data.ParameterDirection.Input, False, CType(0, Byte), CType(0, Byte), "CompanyName", System.Data.DataRowVersion.Current, Nothing))
        '    .Parameters.Add(New SqlParameter("@ContactName", System.Data.SqlDbType.NVarChar, 30, System.Data.ParameterDirection.Input, True, CType(0, Byte), CType(0, Byte), "ContactName", System.Data.DataRowVersion.Current, Nothing))
        '    .Parameters.Add(New SqlParameter("@ContactTitle", System.Data.SqlDbType.NVarChar, 30, System.Data.ParameterDirection.Input, True, CType(0, Byte), CType(0, Byte), "ContactTitle", System.Data.DataRowVersion.Current, Nothing))
        '    .Parameters.Add(New SqlParameter("@Address", System.Data.SqlDbType.NVarChar, 60, System.Data.ParameterDirection.Input, True, CType(0, Byte), CType(0, Byte), "Address", System.Data.DataRowVersion.Current, Nothing))
        '    .Parameters.Add(New SqlParameter("@City", System.Data.SqlDbType.NVarChar, 15, System.Data.ParameterDirection.Input, True, CType(0, Byte), CType(0, Byte), "City", System.Data.DataRowVersion.Current, Nothing))
        '    .Parameters.Add(New SqlParameter("@Region", System.Data.SqlDbType.NVarChar, 15, System.Data.ParameterDirection.Input, True, CType(0, Byte), CType(0, Byte), "Region", System.Data.DataRowVersion.Current, Nothing))
        '    .Parameters.Add(New SqlParameter("@PostalCode", System.Data.SqlDbType.NVarChar, 10, System.Data.ParameterDirection.Input, True, CType(0, Byte), CType(0, Byte), "PostalCode", System.Data.DataRowVersion.Current, Nothing))
        '    .Parameters.Add(New SqlParameter("@Country", System.Data.SqlDbType.NVarChar, 15, System.Data.ParameterDirection.Input, True, CType(0, Byte), CType(0, Byte), "Country", System.Data.DataRowVersion.Current, Nothing))
        '    .Parameters.Add(New SqlParameter("@Phone", System.Data.SqlDbType.NVarChar, 24, System.Data.ParameterDirection.Input, True, CType(0, Byte), CType(0, Byte), "Phone", System.Data.DataRowVersion.Current, Nothing))
        '    .Parameters.Add(New SqlParameter("@Fax", System.Data.SqlDbType.NVarChar, 24, System.Data.ParameterDirection.Input, True, CType(0, Byte), CType(0, Byte), "Fax", System.Data.DataRowVersion.Current, Nothing))
        '    .Parameters.Add(New SqlParameter("@Original_CustomerID", System.Data.SqlDbType.NChar, 5, System.Data.ParameterDirection.Input, False, CType(0, Byte), CType(0, Byte), "CustomerID", System.Data.DataRowVersion.Original, Nothing))
        '    .Parameters.Add(New SqlParameter("@Original_Address", System.Data.SqlDbType.NVarChar, 60, System.Data.ParameterDirection.Input, True, CType(0, Byte), CType(0, Byte), "Address", System.Data.DataRowVersion.Original, Nothing))
        '    .Parameters.Add(New SqlParameter("@Original_Address1", System.Data.SqlDbType.NVarChar, 60, System.Data.ParameterDirection.Input, True, CType(0, Byte), CType(0, Byte), "Address", System.Data.DataRowVersion.Original, Nothing))
        '    .Parameters.Add(New SqlParameter("@Original_City", System.Data.SqlDbType.NVarChar, 15, System.Data.ParameterDirection.Input, True, CType(0, Byte), CType(0, Byte), "City", System.Data.DataRowVersion.Original, Nothing))
        '    .Parameters.Add(New SqlParameter("@Original_City1", System.Data.SqlDbType.NVarChar, 15, System.Data.ParameterDirection.Input, True, CType(0, Byte), CType(0, Byte), "City", System.Data.DataRowVersion.Original, Nothing))
        '    .Parameters.Add(New SqlParameter("@Original_CompanyName", System.Data.SqlDbType.NVarChar, 40, System.Data.ParameterDirection.Input, False, CType(0, Byte), CType(0, Byte), "CompanyName", System.Data.DataRowVersion.Original, Nothing))
        '    .Parameters.Add(New SqlParameter("@Original_ContactName", System.Data.SqlDbType.NVarChar, 30, System.Data.ParameterDirection.Input, True, CType(0, Byte), CType(0, Byte), "ContactName", System.Data.DataRowVersion.Original, Nothing))
        '    .Parameters.Add(New SqlParameter("@Original_ContactName1", System.Data.SqlDbType.NVarChar, 30, System.Data.ParameterDirection.Input, True, CType(0, Byte), CType(0, Byte), "ContactName", System.Data.DataRowVersion.Original, Nothing))
        '    .Parameters.Add(New SqlParameter("@Original_ContactTitle", System.Data.SqlDbType.NVarChar, 30, System.Data.ParameterDirection.Input, True, CType(0, Byte), CType(0, Byte), "ContactTitle", System.Data.DataRowVersion.Original, Nothing))
        '    .Parameters.Add(New SqlParameter("@Original_ContactTitle1", System.Data.SqlDbType.NVarChar, 30, System.Data.ParameterDirection.Input, True, CType(0, Byte), CType(0, Byte), "ContactTitle", System.Data.DataRowVersion.Original, Nothing))
        '    .Parameters.Add(New SqlParameter("@Original_Country", System.Data.SqlDbType.NVarChar, 15, System.Data.ParameterDirection.Input, True, CType(0, Byte), CType(0, Byte), "Country", System.Data.DataRowVersion.Original, Nothing))
        '    .Parameters.Add(New SqlParameter("@Original_Country1", System.Data.SqlDbType.NVarChar, 15, System.Data.ParameterDirection.Input, True, CType(0, Byte), CType(0, Byte), "Country", System.Data.DataRowVersion.Original, Nothing))
        '    .Parameters.Add(New SqlParameter("@Original_Fax", System.Data.SqlDbType.NVarChar, 24, System.Data.ParameterDirection.Input, True, CType(0, Byte), CType(0, Byte), "Fax", System.Data.DataRowVersion.Original, Nothing))
        '    .Parameters.Add(New SqlParameter("@Original_Fax1", System.Data.SqlDbType.NVarChar, 24, System.Data.ParameterDirection.Input, True, CType(0, Byte), CType(0, Byte), "Fax", System.Data.DataRowVersion.Original, Nothing))
        '    .Parameters.Add(New SqlParameter("@Original_Phone", System.Data.SqlDbType.NVarChar, 24, System.Data.ParameterDirection.Input, True, CType(0, Byte), CType(0, Byte), "Phone", System.Data.DataRowVersion.Original, Nothing))
        '    .Parameters.Add(New SqlParameter("@Original_Phone1", System.Data.SqlDbType.NVarChar, 24, System.Data.ParameterDirection.Input, True, CType(0, Byte), CType(0, Byte), "Phone", System.Data.DataRowVersion.Original, Nothing))
        '    .Parameters.Add(New SqlParameter("@Original_PostalCode", System.Data.SqlDbType.NVarChar, 10, System.Data.ParameterDirection.Input, True, CType(0, Byte), CType(0, Byte), "PostalCode", System.Data.DataRowVersion.Original, Nothing))
        '    .Parameters.Add(New SqlParameter("@Original_PostalCode1", System.Data.SqlDbType.NVarChar, 10, System.Data.ParameterDirection.Input, True, CType(0, Byte), CType(0, Byte), "PostalCode", System.Data.DataRowVersion.Original, Nothing))
        '    .Parameters.Add(New SqlParameter("@Original_Region", System.Data.SqlDbType.NVarChar, 15, System.Data.ParameterDirection.Input, True, CType(0, Byte), CType(0, Byte), "Region", System.Data.DataRowVersion.Original, Nothing))
        '    .Parameters.Add(New SqlParameter("@Original_Region1", System.Data.SqlDbType.NVarChar, 15, System.Data.ParameterDirection.Input, True, CType(0, Byte), CType(0, Byte), "Region", System.Data.DataRowVersion.Original, Nothing))
        '    '.Parameters.Add(New SqlParameter("@Select_CustomerID", System.Data.SqlDbType.NChar, 5, System.Data.ParameterDirection.Input, False, CType(0, Byte), CType(0, Byte), "CustomerID", System.Data.DataRowVersion.Current, Nothing))
        'End With
        '
        'SqlDeleteCommand1
        '
        With oCmdDelete
            .CommandType = CommandType.Text
            .CommandText = "DELETE FROM Customers WHERE (CustomerID = @CustomerID) AND (Address = @Address OR" & _
            " @Address1 IS NULL AND Address IS NULL) AND (City = @City OR @City1 IS NULL AND " & _
            "City IS NULL) AND (CompanyName = @CompanyName) AND (ContactName = @ContactName O" & _
            "R @ContactName1 IS NULL AND ContactName IS NULL) AND (ContactTitle = @ContactTit" & _
            "le OR @ContactTitle1 IS NULL AND ContactTitle IS NULL) AND (Country = @Country O" & _
            "R @Country1 IS NULL AND Country IS NULL) AND (Fax = @Fax OR @Fax1 IS NULL AND Fa" & _
            "x IS NULL) AND (Phone = @Phone OR @Phone1 IS NULL AND Phone IS NULL) AND (Postal" & _
            "Code = @PostalCode OR @PostalCode1 IS NULL AND PostalCode IS NULL) AND (Region =" & _
            " @Region OR @Region1 IS NULL AND Region IS NULL)"
            .Connection = oConn
            .Parameters.Add(New SqlParameter("@CustomerID", System.Data.SqlDbType.NChar, 5, System.Data.ParameterDirection.Input, False, CType(0, Byte), CType(0, Byte), "CustomerID", System.Data.DataRowVersion.Original, Nothing))
            .Parameters.Add(New SqlParameter("@Address", System.Data.SqlDbType.NVarChar, 60, System.Data.ParameterDirection.Input, True, CType(0, Byte), CType(0, Byte), "Address", System.Data.DataRowVersion.Original, Nothing))
            .Parameters.Add(New SqlParameter("@Address1", System.Data.SqlDbType.NVarChar, 60, System.Data.ParameterDirection.Input, True, CType(0, Byte), CType(0, Byte), "Address", System.Data.DataRowVersion.Original, Nothing))
            .Parameters.Add(New SqlParameter("@City", System.Data.SqlDbType.NVarChar, 15, System.Data.ParameterDirection.Input, True, CType(0, Byte), CType(0, Byte), "City", System.Data.DataRowVersion.Original, Nothing))
            .Parameters.Add(New SqlParameter("@City1", System.Data.SqlDbType.NVarChar, 15, System.Data.ParameterDirection.Input, True, CType(0, Byte), CType(0, Byte), "City", System.Data.DataRowVersion.Original, Nothing))
            .Parameters.Add(New SqlParameter("@CompanyName", System.Data.SqlDbType.NVarChar, 40, System.Data.ParameterDirection.Input, False, CType(0, Byte), CType(0, Byte), "CompanyName", System.Data.DataRowVersion.Original, Nothing))
            .Parameters.Add(New SqlParameter("@ContactName", System.Data.SqlDbType.NVarChar, 30, System.Data.ParameterDirection.Input, True, CType(0, Byte), CType(0, Byte), "ContactName", System.Data.DataRowVersion.Original, Nothing))
            .Parameters.Add(New SqlParameter("@ContactName1", System.Data.SqlDbType.NVarChar, 30, System.Data.ParameterDirection.Input, True, CType(0, Byte), CType(0, Byte), "ContactName", System.Data.DataRowVersion.Original, Nothing))
            .Parameters.Add(New SqlParameter("@ContactTitle", System.Data.SqlDbType.NVarChar, 30, System.Data.ParameterDirection.Input, True, CType(0, Byte), CType(0, Byte), "ContactTitle", System.Data.DataRowVersion.Original, Nothing))
            .Parameters.Add(New SqlParameter("@ContactTitle1", System.Data.SqlDbType.NVarChar, 30, System.Data.ParameterDirection.Input, True, CType(0, Byte), CType(0, Byte), "ContactTitle", System.Data.DataRowVersion.Original, Nothing))
            .Parameters.Add(New SqlParameter("@Country", System.Data.SqlDbType.NVarChar, 15, System.Data.ParameterDirection.Input, True, CType(0, Byte), CType(0, Byte), "Country", System.Data.DataRowVersion.Original, Nothing))
            .Parameters.Add(New SqlParameter("@Country1", System.Data.SqlDbType.NVarChar, 15, System.Data.ParameterDirection.Input, True, CType(0, Byte), CType(0, Byte), "Country", System.Data.DataRowVersion.Original, Nothing))
            .Parameters.Add(New SqlParameter("@Fax", System.Data.SqlDbType.NVarChar, 24, System.Data.ParameterDirection.Input, True, CType(0, Byte), CType(0, Byte), "Fax", System.Data.DataRowVersion.Original, Nothing))
            .Parameters.Add(New SqlParameter("@Fax1", System.Data.SqlDbType.NVarChar, 24, System.Data.ParameterDirection.Input, True, CType(0, Byte), CType(0, Byte), "Fax", System.Data.DataRowVersion.Original, Nothing))
            .Parameters.Add(New SqlParameter("@Phone", System.Data.SqlDbType.NVarChar, 24, System.Data.ParameterDirection.Input, True, CType(0, Byte), CType(0, Byte), "Phone", System.Data.DataRowVersion.Original, Nothing))
            .Parameters.Add(New SqlParameter("@Phone1", System.Data.SqlDbType.NVarChar, 24, System.Data.ParameterDirection.Input, True, CType(0, Byte), CType(0, Byte), "Phone", System.Data.DataRowVersion.Original, Nothing))
            .Parameters.Add(New SqlParameter("@PostalCode", System.Data.SqlDbType.NVarChar, 10, System.Data.ParameterDirection.Input, True, CType(0, Byte), CType(0, Byte), "PostalCode", System.Data.DataRowVersion.Original, Nothing))
            .Parameters.Add(New SqlParameter("@PostalCode1", System.Data.SqlDbType.NVarChar, 10, System.Data.ParameterDirection.Input, True, CType(0, Byte), CType(0, Byte), "PostalCode", System.Data.DataRowVersion.Original, Nothing))
            .Parameters.Add(New SqlParameter("@Region", System.Data.SqlDbType.NVarChar, 15, System.Data.ParameterDirection.Input, True, CType(0, Byte), CType(0, Byte), "Region", System.Data.DataRowVersion.Original, Nothing))
            .Parameters.Add(New SqlParameter("@Region1", System.Data.SqlDbType.NVarChar, 15, System.Data.ParameterDirection.Input, True, CType(0, Byte), CType(0, Byte), "Region", System.Data.DataRowVersion.Original, Nothing))
            .Transaction = oTran
        End With

        Try
            oDA.Update(oDS)
            oTran.Commit()
        Catch oErr As Exception
            oTran.Rollback()
        End Try

    End Sub

    <WebMethod()> Public Function GetOrderList() As DataSet
        Dim oConn As New SqlConnection("Password=;User ID=sa;" & _
                    "Initial Catalog=Northwind;Data Source=(local)")
        'This creates a new command object
        Dim oCmd As New SqlCommand("Select * from orders", oConn)
        Dim oDA As SqlDataAdapter
        Dim oDS As New DataSet()

        'Create the DataAdapter
        oDA = New SqlClient.SqlDataAdapter(oCmd)
        'Fill the DataSet
        oDA.Fill(oDS)

        Return oDS

    End Function

    <WebMethod()> Public Sub UpdateOrderList(ByVal oDS As DataSet)
        Dim oConn As New SqlConnection("Password=;User ID=sa;" & _
                    "Initial Catalog=Northwind;Data Source=(local)")
        'This creates a new command object
        Dim oCmdSelect As New SqlCommand()
        Dim oCmdInsert As New SqlCommand()
        Dim oCmdUpdate As New SqlCommand()
        Dim oCmdDelete As New SqlCommand()
        Dim oDA As SqlDataAdapter

        'Create the DataAdapter
        oDA = New SqlClient.SqlDataAdapter()
        With oDA
            .SelectCommand = oCmdSelect
            .InsertCommand = oCmdInsert
            .UpdateCommand = oCmdUpdate
            .DeleteCommand = oCmdDelete
        End With

        '
        'oCmdSelect
        '
        With oCmdSelect
            .CommandText = "SELECT OrderID, CustomerID, EmployeeID, OrderDate, RequiredDate, ShippedDate, Shi" & _
            "pVia, Freight, ShipName, ShipAddress, ShipCity, ShipRegion, ShipPostalCode, Ship" & _
            "Country FROM Orders"
            .Connection = oConn
        End With
        '
        'oCmdInsert
        '
        With oCmdInsert
            .CommandText = "INSERT INTO Orders(CustomerID, EmployeeID, OrderDate, RequiredDate, ShippedDate, " & _
            "ShipVia, Freight, ShipName, ShipAddress, ShipCity, ShipRegion, ShipPostalCode, S" & _
            "hipCountry) VALUES (@CustomerID, @EmployeeID, @OrderDate, @RequiredDate, @Shippe" & _
            "dDate, @ShipVia, @Freight, @ShipName, @ShipAddress, @ShipCity, @ShipRegion, @Shi" & _
            "pPostalCode, @ShipCountry)"
            .Connection = oConn
            .Parameters.Add(New SqlParameter("@CustomerID", System.Data.SqlDbType.NChar, 5, System.Data.ParameterDirection.Input, True, CType(0, Byte), CType(0, Byte), "CustomerID", System.Data.DataRowVersion.Current, Nothing))
            .Parameters.Add(New SqlParameter("@EmployeeID", System.Data.SqlDbType.Int, 4, System.Data.ParameterDirection.Input, True, CType(0, Byte), CType(0, Byte), "EmployeeID", System.Data.DataRowVersion.Current, Nothing))
            .Parameters.Add(New SqlParameter("@OrderDate", System.Data.SqlDbType.DateTime, 8, System.Data.ParameterDirection.Input, True, CType(0, Byte), CType(0, Byte), "OrderDate", System.Data.DataRowVersion.Current, Nothing))
            .Parameters.Add(New SqlParameter("@RequiredDate", System.Data.SqlDbType.DateTime, 8, System.Data.ParameterDirection.Input, True, CType(0, Byte), CType(0, Byte), "RequiredDate", System.Data.DataRowVersion.Current, Nothing))
            .Parameters.Add(New SqlParameter("@ShippedDate", System.Data.SqlDbType.DateTime, 8, System.Data.ParameterDirection.Input, True, CType(0, Byte), CType(0, Byte), "ShippedDate", System.Data.DataRowVersion.Current, Nothing))
            .Parameters.Add(New SqlParameter("@ShipVia", System.Data.SqlDbType.Int, 4, System.Data.ParameterDirection.Input, True, CType(0, Byte), CType(0, Byte), "ShipVia", System.Data.DataRowVersion.Current, Nothing))
            .Parameters.Add(New SqlParameter("@Freight", System.Data.SqlDbType.Money, 8, System.Data.ParameterDirection.Input, True, CType(0, Byte), CType(0, Byte), "Freight", System.Data.DataRowVersion.Current, Nothing))
            .Parameters.Add(New SqlParameter("@ShipName", System.Data.SqlDbType.NVarChar, 40, System.Data.ParameterDirection.Input, True, CType(0, Byte), CType(0, Byte), "ShipName", System.Data.DataRowVersion.Current, Nothing))
            .Parameters.Add(New SqlParameter("@ShipAddress", System.Data.SqlDbType.NVarChar, 60, System.Data.ParameterDirection.Input, True, CType(0, Byte), CType(0, Byte), "ShipAddress", System.Data.DataRowVersion.Current, Nothing))
            .Parameters.Add(New SqlParameter("@ShipCity", System.Data.SqlDbType.NVarChar, 15, System.Data.ParameterDirection.Input, True, CType(0, Byte), CType(0, Byte), "ShipCity", System.Data.DataRowVersion.Current, Nothing))
            .Parameters.Add(New SqlParameter("@ShipRegion", System.Data.SqlDbType.NVarChar, 15, System.Data.ParameterDirection.Input, True, CType(0, Byte), CType(0, Byte), "ShipRegion", System.Data.DataRowVersion.Current, Nothing))
            .Parameters.Add(New SqlParameter("@ShipPostalCode", System.Data.SqlDbType.NVarChar, 10, System.Data.ParameterDirection.Input, True, CType(0, Byte), CType(0, Byte), "ShipPostalCode", System.Data.DataRowVersion.Current, Nothing))
            .Parameters.Add(New SqlParameter("@ShipCountry", System.Data.SqlDbType.NVarChar, 15, System.Data.ParameterDirection.Input, True, CType(0, Byte), CType(0, Byte), "ShipCountry", System.Data.DataRowVersion.Current, Nothing))
        End With
        '
        'oCmdUpdate
        '
        With oCmdUpdate
            .CommandText = "UPDATE Orders SET CustomerID = @CustomerID, EmployeeID = @EmployeeID, OrderDate =" & _
            " @OrderDate, RequiredDate = @RequiredDate, ShippedDate = @ShippedDate, ShipVia =" & _
            " @ShipVia, Freight = @Freight, ShipName = @ShipName, ShipAddress = @ShipAddress," & _
            " ShipCity = @ShipCity, ShipRegion = @ShipRegion, ShipPostalCode = @ShipPostalCod" & _
            "e, ShipCountry = @ShipCountry WHERE (OrderID = @Original_OrderID) AND (CustomerI" & _
            "D = @Original_CustomerID OR @Original_CustomerID1 IS NULL AND CustomerID IS NULL" & _
            ") AND (EmployeeID = @Original_EmployeeID OR @Original_EmployeeID1 IS NULL AND Em" & _
            "ployeeID IS NULL) AND (Freight = @Original_Freight OR @Original_Freight1 IS NULL" & _
            " AND Freight IS NULL) AND (OrderDate = @Original_OrderDate OR @Original_OrderDat" & _
            "e1 IS NULL AND OrderDate IS NULL) AND (RequiredDate = @Original_RequiredDate OR " & _
            "@Original_RequiredDate1 IS NULL AND RequiredDate IS NULL) AND (ShipAddress = @Or" & _
            "iginal_ShipAddress OR @Original_ShipAddress1 IS NULL AND ShipAddress IS NULL) AN" & _
            "D (ShipCity = @Original_ShipCity OR @Original_ShipCity1 IS NULL AND ShipCity IS " & _
            "NULL) AND (ShipCountry = @Original_ShipCountry OR @Original_ShipCountry1 IS NULL" & _
            " AND ShipCountry IS NULL) AND (ShipName = @Original_ShipName OR @Original_ShipNa" & _
            "me1 IS NULL AND ShipName IS NULL) AND (ShipPostalCode = @Original_ShipPostalCode" & _
            " OR @Original_ShipPostalCode1 IS NULL AND ShipPostalCode IS NULL) AND (ShipRegio" & _
            "n = @Original_ShipRegion OR @Original_ShipRegion1 IS NULL AND ShipRegion IS NULL" & _
            ") AND (ShipVia = @Original_ShipVia OR @Original_ShipVia1 IS NULL AND ShipVia IS " & _
            "NULL) AND (ShippedDate = @Original_ShippedDate OR @Original_ShippedDate1 IS NULL" & _
            " AND ShippedDate IS NULL)"
            .Connection = oConn
            .Parameters.Add(New SqlParameter("@CustomerID", System.Data.SqlDbType.NChar, 5, System.Data.ParameterDirection.Input, True, CType(0, Byte), CType(0, Byte), "CustomerID", System.Data.DataRowVersion.Current, Nothing))
            .Parameters.Add(New SqlParameter("@EmployeeID", System.Data.SqlDbType.Int, 4, System.Data.ParameterDirection.Input, True, CType(0, Byte), CType(0, Byte), "EmployeeID", System.Data.DataRowVersion.Current, Nothing))
            .Parameters.Add(New SqlParameter("@OrderDate", System.Data.SqlDbType.DateTime, 8, System.Data.ParameterDirection.Input, True, CType(0, Byte), CType(0, Byte), "OrderDate", System.Data.DataRowVersion.Current, Nothing))
            .Parameters.Add(New SqlParameter("@RequiredDate", System.Data.SqlDbType.DateTime, 8, System.Data.ParameterDirection.Input, True, CType(0, Byte), CType(0, Byte), "RequiredDate", System.Data.DataRowVersion.Current, Nothing))
            .Parameters.Add(New SqlParameter("@ShippedDate", System.Data.SqlDbType.DateTime, 8, System.Data.ParameterDirection.Input, True, CType(0, Byte), CType(0, Byte), "ShippedDate", System.Data.DataRowVersion.Current, Nothing))
            .Parameters.Add(New SqlParameter("@ShipVia", System.Data.SqlDbType.Int, 4, System.Data.ParameterDirection.Input, True, CType(0, Byte), CType(0, Byte), "ShipVia", System.Data.DataRowVersion.Current, Nothing))
            .Parameters.Add(New SqlParameter("@Freight", System.Data.SqlDbType.Money, 8, System.Data.ParameterDirection.Input, True, CType(0, Byte), CType(0, Byte), "Freight", System.Data.DataRowVersion.Current, Nothing))
            .Parameters.Add(New SqlParameter("@ShipName", System.Data.SqlDbType.NVarChar, 40, System.Data.ParameterDirection.Input, True, CType(0, Byte), CType(0, Byte), "ShipName", System.Data.DataRowVersion.Current, Nothing))
            .Parameters.Add(New SqlParameter("@ShipAddress", System.Data.SqlDbType.NVarChar, 60, System.Data.ParameterDirection.Input, True, CType(0, Byte), CType(0, Byte), "ShipAddress", System.Data.DataRowVersion.Current, Nothing))
            .Parameters.Add(New SqlParameter("@ShipCity", System.Data.SqlDbType.NVarChar, 15, System.Data.ParameterDirection.Input, True, CType(0, Byte), CType(0, Byte), "ShipCity", System.Data.DataRowVersion.Current, Nothing))
            .Parameters.Add(New SqlParameter("@ShipRegion", System.Data.SqlDbType.NVarChar, 15, System.Data.ParameterDirection.Input, True, CType(0, Byte), CType(0, Byte), "ShipRegion", System.Data.DataRowVersion.Current, Nothing))
            .Parameters.Add(New SqlParameter("@ShipPostalCode", System.Data.SqlDbType.NVarChar, 10, System.Data.ParameterDirection.Input, True, CType(0, Byte), CType(0, Byte), "ShipPostalCode", System.Data.DataRowVersion.Current, Nothing))
            .Parameters.Add(New SqlParameter("@ShipCountry", System.Data.SqlDbType.NVarChar, 15, System.Data.ParameterDirection.Input, True, CType(0, Byte), CType(0, Byte), "ShipCountry", System.Data.DataRowVersion.Current, Nothing))
            .Parameters.Add(New SqlParameter("@Original_OrderID", System.Data.SqlDbType.Int, 4, System.Data.ParameterDirection.Input, False, CType(0, Byte), CType(0, Byte), "OrderID", System.Data.DataRowVersion.Original, Nothing))
            .Parameters.Add(New SqlParameter("@Original_CustomerID", System.Data.SqlDbType.NChar, 5, System.Data.ParameterDirection.Input, True, CType(0, Byte), CType(0, Byte), "CustomerID", System.Data.DataRowVersion.Original, Nothing))
            .Parameters.Add(New SqlParameter("@Original_CustomerID1", System.Data.SqlDbType.NChar, 5, System.Data.ParameterDirection.Input, True, CType(0, Byte), CType(0, Byte), "CustomerID", System.Data.DataRowVersion.Original, Nothing))
            .Parameters.Add(New SqlParameter("@Original_EmployeeID", System.Data.SqlDbType.Int, 4, System.Data.ParameterDirection.Input, True, CType(0, Byte), CType(0, Byte), "EmployeeID", System.Data.DataRowVersion.Original, Nothing))
            .Parameters.Add(New SqlParameter("@Original_EmployeeID1", System.Data.SqlDbType.Int, 4, System.Data.ParameterDirection.Input, True, CType(0, Byte), CType(0, Byte), "EmployeeID", System.Data.DataRowVersion.Original, Nothing))
            .Parameters.Add(New SqlParameter("@Original_Freight", System.Data.SqlDbType.Money, 8, System.Data.ParameterDirection.Input, True, CType(0, Byte), CType(0, Byte), "Freight", System.Data.DataRowVersion.Original, Nothing))
            .Parameters.Add(New SqlParameter("@Original_Freight1", System.Data.SqlDbType.Money, 8, System.Data.ParameterDirection.Input, True, CType(0, Byte), CType(0, Byte), "Freight", System.Data.DataRowVersion.Original, Nothing))
            .Parameters.Add(New SqlParameter("@Original_OrderDate", System.Data.SqlDbType.DateTime, 8, System.Data.ParameterDirection.Input, True, CType(0, Byte), CType(0, Byte), "OrderDate", System.Data.DataRowVersion.Original, Nothing))
            .Parameters.Add(New SqlParameter("@Original_OrderDate1", System.Data.SqlDbType.DateTime, 8, System.Data.ParameterDirection.Input, True, CType(0, Byte), CType(0, Byte), "OrderDate", System.Data.DataRowVersion.Original, Nothing))
            .Parameters.Add(New SqlParameter("@Original_RequiredDate", System.Data.SqlDbType.DateTime, 8, System.Data.ParameterDirection.Input, True, CType(0, Byte), CType(0, Byte), "RequiredDate", System.Data.DataRowVersion.Original, Nothing))
            .Parameters.Add(New SqlParameter("@Original_RequiredDate1", System.Data.SqlDbType.DateTime, 8, System.Data.ParameterDirection.Input, True, CType(0, Byte), CType(0, Byte), "RequiredDate", System.Data.DataRowVersion.Original, Nothing))
            .Parameters.Add(New SqlParameter("@Original_ShipAddress", System.Data.SqlDbType.NVarChar, 60, System.Data.ParameterDirection.Input, True, CType(0, Byte), CType(0, Byte), "ShipAddress", System.Data.DataRowVersion.Original, Nothing))
            .Parameters.Add(New SqlParameter("@Original_ShipAddress1", System.Data.SqlDbType.NVarChar, 60, System.Data.ParameterDirection.Input, True, CType(0, Byte), CType(0, Byte), "ShipAddress", System.Data.DataRowVersion.Original, Nothing))
            .Parameters.Add(New SqlParameter("@Original_ShipCity", System.Data.SqlDbType.NVarChar, 15, System.Data.ParameterDirection.Input, True, CType(0, Byte), CType(0, Byte), "ShipCity", System.Data.DataRowVersion.Original, Nothing))
            .Parameters.Add(New SqlParameter("@Original_ShipCity1", System.Data.SqlDbType.NVarChar, 15, System.Data.ParameterDirection.Input, True, CType(0, Byte), CType(0, Byte), "ShipCity", System.Data.DataRowVersion.Original, Nothing))
            .Parameters.Add(New SqlParameter("@Original_ShipCountry", System.Data.SqlDbType.NVarChar, 15, System.Data.ParameterDirection.Input, True, CType(0, Byte), CType(0, Byte), "ShipCountry", System.Data.DataRowVersion.Original, Nothing))
            .Parameters.Add(New SqlParameter("@Original_ShipCountry1", System.Data.SqlDbType.NVarChar, 15, System.Data.ParameterDirection.Input, True, CType(0, Byte), CType(0, Byte), "ShipCountry", System.Data.DataRowVersion.Original, Nothing))
            .Parameters.Add(New SqlParameter("@Original_ShipName", System.Data.SqlDbType.NVarChar, 40, System.Data.ParameterDirection.Input, True, CType(0, Byte), CType(0, Byte), "ShipName", System.Data.DataRowVersion.Original, Nothing))
            .Parameters.Add(New SqlParameter("@Original_ShipName1", System.Data.SqlDbType.NVarChar, 40, System.Data.ParameterDirection.Input, True, CType(0, Byte), CType(0, Byte), "ShipName", System.Data.DataRowVersion.Original, Nothing))
            .Parameters.Add(New SqlParameter("@Original_ShipPostalCode", System.Data.SqlDbType.NVarChar, 10, System.Data.ParameterDirection.Input, True, CType(0, Byte), CType(0, Byte), "ShipPostalCode", System.Data.DataRowVersion.Original, Nothing))
            .Parameters.Add(New SqlParameter("@Original_ShipPostalCode1", System.Data.SqlDbType.NVarChar, 10, System.Data.ParameterDirection.Input, True, CType(0, Byte), CType(0, Byte), "ShipPostalCode", System.Data.DataRowVersion.Original, Nothing))
            .Parameters.Add(New SqlParameter("@Original_ShipRegion", System.Data.SqlDbType.NVarChar, 15, System.Data.ParameterDirection.Input, True, CType(0, Byte), CType(0, Byte), "ShipRegion", System.Data.DataRowVersion.Original, Nothing))
            .Parameters.Add(New SqlParameter("@Original_ShipRegion1", System.Data.SqlDbType.NVarChar, 15, System.Data.ParameterDirection.Input, True, CType(0, Byte), CType(0, Byte), "ShipRegion", System.Data.DataRowVersion.Original, Nothing))
            .Parameters.Add(New SqlParameter("@Original_ShipVia", System.Data.SqlDbType.Int, 4, System.Data.ParameterDirection.Input, True, CType(0, Byte), CType(0, Byte), "ShipVia", System.Data.DataRowVersion.Original, Nothing))
            .Parameters.Add(New SqlParameter("@Original_ShipVia1", System.Data.SqlDbType.Int, 4, System.Data.ParameterDirection.Input, True, CType(0, Byte), CType(0, Byte), "ShipVia", System.Data.DataRowVersion.Original, Nothing))
            .Parameters.Add(New SqlParameter("@Original_ShippedDate", System.Data.SqlDbType.DateTime, 8, System.Data.ParameterDirection.Input, True, CType(0, Byte), CType(0, Byte), "ShippedDate", System.Data.DataRowVersion.Original, Nothing))
            .Parameters.Add(New SqlParameter("@Original_ShippedDate1", System.Data.SqlDbType.DateTime, 8, System.Data.ParameterDirection.Input, True, CType(0, Byte), CType(0, Byte), "ShippedDate", System.Data.DataRowVersion.Original, Nothing))
        End With
        '
        'oCmdDelete
        '
        With oCmdDelete
            .CommandText = "DELETE FROM Orders WHERE (OrderID = @OrderID) AND (CustomerID = @CustomerID OR @C" & _
            "ustomerID1 IS NULL AND CustomerID IS NULL) AND (EmployeeID = @EmployeeID OR @Emp" & _
            "loyeeID1 IS NULL AND EmployeeID IS NULL) AND (Freight = @Freight OR @Freight1 IS" & _
            " NULL AND Freight IS NULL) AND (OrderDate = @OrderDate OR @OrderDate1 IS NULL AN" & _
            "D OrderDate IS NULL) AND (RequiredDate = @RequiredDate OR @RequiredDate1 IS NULL" & _
            " AND RequiredDate IS NULL) AND (ShipAddress = @ShipAddress OR @ShipAddress1 IS N" & _
            "ULL AND ShipAddress IS NULL) AND (ShipCity = @ShipCity OR @ShipCity1 IS NULL AND" & _
            " ShipCity IS NULL) AND (ShipCountry = @ShipCountry OR @ShipCountry1 IS NULL AND " & _
            "ShipCountry IS NULL) AND (ShipName = @ShipName OR @ShipName1 IS NULL AND ShipNam" & _
            "e IS NULL) AND (ShipPostalCode = @ShipPostalCode OR @ShipPostalCode1 IS NULL AND" & _
            " ShipPostalCode IS NULL) AND (ShipRegion = @ShipRegion OR @ShipRegion1 IS NULL A" & _
            "ND ShipRegion IS NULL) AND (ShipVia = @ShipVia OR @ShipVia1 IS NULL AND ShipVia " & _
            "IS NULL) AND (ShippedDate = @ShippedDate OR @ShippedDate1 IS NULL AND ShippedDat" & _
            "e IS NULL)"
            .Connection = oConn
            .Parameters.Add(New SqlParameter("@OrderID", System.Data.SqlDbType.Int, 4, System.Data.ParameterDirection.Input, False, CType(0, Byte), CType(0, Byte), "OrderID", System.Data.DataRowVersion.Original, Nothing))
            .Parameters.Add(New SqlParameter("@CustomerID", System.Data.SqlDbType.NChar, 5, System.Data.ParameterDirection.Input, True, CType(0, Byte), CType(0, Byte), "CustomerID", System.Data.DataRowVersion.Original, Nothing))
            .Parameters.Add(New SqlParameter("@CustomerID1", System.Data.SqlDbType.NChar, 5, System.Data.ParameterDirection.Input, True, CType(0, Byte), CType(0, Byte), "CustomerID", System.Data.DataRowVersion.Original, Nothing))
            .Parameters.Add(New SqlParameter("@EmployeeID", System.Data.SqlDbType.Int, 4, System.Data.ParameterDirection.Input, True, CType(0, Byte), CType(0, Byte), "EmployeeID", System.Data.DataRowVersion.Original, Nothing))
            .Parameters.Add(New SqlParameter("@EmployeeID1", System.Data.SqlDbType.Int, 4, System.Data.ParameterDirection.Input, True, CType(0, Byte), CType(0, Byte), "EmployeeID", System.Data.DataRowVersion.Original, Nothing))
            .Parameters.Add(New SqlParameter("@Freight", System.Data.SqlDbType.Money, 8, System.Data.ParameterDirection.Input, True, CType(0, Byte), CType(0, Byte), "Freight", System.Data.DataRowVersion.Original, Nothing))
            .Parameters.Add(New SqlParameter("@Freight1", System.Data.SqlDbType.Money, 8, System.Data.ParameterDirection.Input, True, CType(0, Byte), CType(0, Byte), "Freight", System.Data.DataRowVersion.Original, Nothing))
            .Parameters.Add(New SqlParameter("@OrderDate", System.Data.SqlDbType.DateTime, 8, System.Data.ParameterDirection.Input, True, CType(0, Byte), CType(0, Byte), "OrderDate", System.Data.DataRowVersion.Original, Nothing))
            .Parameters.Add(New SqlParameter("@OrderDate1", System.Data.SqlDbType.DateTime, 8, System.Data.ParameterDirection.Input, True, CType(0, Byte), CType(0, Byte), "OrderDate", System.Data.DataRowVersion.Original, Nothing))
            .Parameters.Add(New SqlParameter("@RequiredDate", System.Data.SqlDbType.DateTime, 8, System.Data.ParameterDirection.Input, True, CType(0, Byte), CType(0, Byte), "RequiredDate", System.Data.DataRowVersion.Original, Nothing))
            .Parameters.Add(New SqlParameter("@RequiredDate1", System.Data.SqlDbType.DateTime, 8, System.Data.ParameterDirection.Input, True, CType(0, Byte), CType(0, Byte), "RequiredDate", System.Data.DataRowVersion.Original, Nothing))
            .Parameters.Add(New SqlParameter("@ShipAddress", System.Data.SqlDbType.NVarChar, 60, System.Data.ParameterDirection.Input, True, CType(0, Byte), CType(0, Byte), "ShipAddress", System.Data.DataRowVersion.Original, Nothing))
            .Parameters.Add(New SqlParameter("@ShipAddress1", System.Data.SqlDbType.NVarChar, 60, System.Data.ParameterDirection.Input, True, CType(0, Byte), CType(0, Byte), "ShipAddress", System.Data.DataRowVersion.Original, Nothing))
            .Parameters.Add(New SqlParameter("@ShipCity", System.Data.SqlDbType.NVarChar, 15, System.Data.ParameterDirection.Input, True, CType(0, Byte), CType(0, Byte), "ShipCity", System.Data.DataRowVersion.Original, Nothing))
            .Parameters.Add(New SqlParameter("@ShipCity1", System.Data.SqlDbType.NVarChar, 15, System.Data.ParameterDirection.Input, True, CType(0, Byte), CType(0, Byte), "ShipCity", System.Data.DataRowVersion.Original, Nothing))
            .Parameters.Add(New SqlParameter("@ShipCountry", System.Data.SqlDbType.NVarChar, 15, System.Data.ParameterDirection.Input, True, CType(0, Byte), CType(0, Byte), "ShipCountry", System.Data.DataRowVersion.Original, Nothing))
            .Parameters.Add(New SqlParameter("@ShipCountry1", System.Data.SqlDbType.NVarChar, 15, System.Data.ParameterDirection.Input, True, CType(0, Byte), CType(0, Byte), "ShipCountry", System.Data.DataRowVersion.Original, Nothing))
            .Parameters.Add(New SqlParameter("@ShipName", System.Data.SqlDbType.NVarChar, 40, System.Data.ParameterDirection.Input, True, CType(0, Byte), CType(0, Byte), "ShipName", System.Data.DataRowVersion.Original, Nothing))
            .Parameters.Add(New SqlParameter("@ShipName1", System.Data.SqlDbType.NVarChar, 40, System.Data.ParameterDirection.Input, True, CType(0, Byte), CType(0, Byte), "ShipName", System.Data.DataRowVersion.Original, Nothing))
            .Parameters.Add(New SqlParameter("@ShipPostalCode", System.Data.SqlDbType.NVarChar, 10, System.Data.ParameterDirection.Input, True, CType(0, Byte), CType(0, Byte), "ShipPostalCode", System.Data.DataRowVersion.Original, Nothing))
            .Parameters.Add(New SqlParameter("@ShipPostalCode1", System.Data.SqlDbType.NVarChar, 10, System.Data.ParameterDirection.Input, True, CType(0, Byte), CType(0, Byte), "ShipPostalCode", System.Data.DataRowVersion.Original, Nothing))
            .Parameters.Add(New SqlParameter("@ShipRegion", System.Data.SqlDbType.NVarChar, 15, System.Data.ParameterDirection.Input, True, CType(0, Byte), CType(0, Byte), "ShipRegion", System.Data.DataRowVersion.Original, Nothing))
            .Parameters.Add(New SqlParameter("@ShipRegion1", System.Data.SqlDbType.NVarChar, 15, System.Data.ParameterDirection.Input, True, CType(0, Byte), CType(0, Byte), "ShipRegion", System.Data.DataRowVersion.Original, Nothing))
            .Parameters.Add(New SqlParameter("@ShipVia", System.Data.SqlDbType.Int, 4, System.Data.ParameterDirection.Input, True, CType(0, Byte), CType(0, Byte), "ShipVia", System.Data.DataRowVersion.Original, Nothing))
            .Parameters.Add(New SqlParameter("@ShipVia1", System.Data.SqlDbType.Int, 4, System.Data.ParameterDirection.Input, True, CType(0, Byte), CType(0, Byte), "ShipVia", System.Data.DataRowVersion.Original, Nothing))
            .Parameters.Add(New SqlParameter("@ShippedDate", System.Data.SqlDbType.DateTime, 8, System.Data.ParameterDirection.Input, True, CType(0, Byte), CType(0, Byte), "ShippedDate", System.Data.DataRowVersion.Original, Nothing))
            .Parameters.Add(New SqlParameter("@ShippedDate1", System.Data.SqlDbType.DateTime, 8, System.Data.ParameterDirection.Input, True, CType(0, Byte), CType(0, Byte), "ShippedDate", System.Data.DataRowVersion.Original, Nothing))
        End With

        oDA.Update(oDS)

    End Sub

    <WebMethod()> Public Sub UpdateCustomerListTrans(ByVal oDS As DataSet)
        Dim oConn As New SqlConnection("Password=;User ID=sa;" & _
                    "Initial Catalog=Northwind;Data Source=(local)")
        'This creates a new command object
        Dim oCmdSelect As New SqlCommand()
        Dim oCmdInsert As New SqlCommand()
        Dim oCmdUpdate As New SqlCommand()
        Dim oCmdDelete As New SqlCommand()
        Dim oDA As SqlDataAdapter
        Dim oTran As SqlTransaction

        oConn.Open()
        oTran = oConn.BeginTransaction()

        'Create the DataAdapter
        oDA = New SqlClient.SqlDataAdapter()
        With oDA
            .SelectCommand = oCmdSelect
            .InsertCommand = oCmdInsert
            .UpdateCommand = oCmdUpdate
            .DeleteCommand = oCmdDelete
        End With

        With oCmdSelect
            .CommandText = "SELECT CustomerID, CompanyName, ContactName," & _
            " ContactTitle, Address, City, Region," & _
            " PostalCode, Country, Phone, Fax FROM Customers"
            .Connection = oConn
        End With

        With oCmdInsert
            'configure command object for Inserting records
            .Transaction = oTran
        End With

        With oCmdUpdate
            'configure command object for Updating reocrds
            .Transaction = oTran
        End With

        With oCmdDelete
            'configure command object for Deleting records
            .Transaction = oTran
        End With

        Try
            oDA.Update(oDS)
            oTran.Commit()
        Catch oErr As Exception
            oTran.Rollback()
        End Try

        'Check on Connection Object, Close it
        If oConn.State = oConn.State.Open Then
            oConn.Close()
        End If

    End Sub

    Private Sub UpdateCustomerDT(ByVal oDS As DataSet)
        Dim oConn As New SqlConnection("Password=;User ID=sa;" & _
            "Initial Catalog=Northwind;Data Source=(local)")
        'This creates a new command object
        Dim oCmdSelect As New SqlCommand()
        Dim oCmdInsert As New SqlCommand()
        Dim oCmdUpdate As New SqlCommand()
        Dim oCmdDelete As New SqlCommand()
        Dim oDA As SqlDataAdapter
        Dim oTran As SqlTransaction

        'Create the DataAdapter
        oDA = New SqlClient.SqlDataAdapter()
        With oDA
            .SelectCommand = oCmdSelect
            .InsertCommand = oCmdInsert
            .UpdateCommand = oCmdUpdate
            .DeleteCommand = oCmdDelete
        End With

        '
        'oCmdSelect
        '
        With oCmdSelect
            'configure command object for Selecting records
        End With
        '
        'oCmdInsert
        '
        With oCmdInsert
            'configure command object for Inserting records
        End With
        '
        'oCmdUpdate
        '
        With oCmdUpdate
            'configure command object for Updating records
        End With
        '
        'oCmdDelete
        '
        With oCmdDelete
            'configure command object for Deleting records
        End With

        oDA.Update(oDS, "Customers")

    End Sub

    Private Sub UpdateOrdersDT(ByVal oDS As DataSet)
        Dim oConn As New SqlConnection("Password=;User ID=sa;" & _
                    "Initial Catalog=Northwind;Data Source=(local)")
        'This creates a new command object
        Dim oCmdSelect As New SqlCommand()
        Dim oCmdInsert As New SqlCommand()
        Dim oCmdUpdate As New SqlCommand()
        Dim oCmdDelete As New SqlCommand()
        Dim oDA As SqlDataAdapter
        Dim iRowsUpdCnt As Integer

        'Create the DataAdapter
        oDA = New SqlClient.SqlDataAdapter()
        With oDA
            .SelectCommand = oCmdSelect
            .InsertCommand = oCmdInsert
            .UpdateCommand = oCmdUpdate
            .DeleteCommand = oCmdDelete
        End With

        '
        'oCmdSelect
        '
        With oCmdSelect
            'configure command object for Selecting records
        End With
        '
        'oCmdInsert
        '
        With oCmdInsert
            'configure command object for Inserting records
        End With
        '
        'oCmdUpdate
        '
        With oCmdUpdate
            'configure command object for Updating records
        End With
        '
        'oCmdDelete
        '
        With oCmdDelete
            'configure command object for Deleting records
        End With

        iRowsUpdCnt = oDA.Update(oDS, "Orders")

    End Sub

End Class
