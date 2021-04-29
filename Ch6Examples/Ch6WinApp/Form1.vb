Imports System.Data.SqlClient
Imports System.Xml
Imports System.Xml.Xsl

Public Class Form1
    Inherits System.Windows.Forms.Form
    Private m_oDS As New DataSet()
#Region " Windows Form Designer generated code "

    Public Sub New()
        MyBase.New()

        'This call is required by the Windows Form Designer.
        InitializeComponent()

        'Add any initialization after the InitializeComponent() call

    End Sub

    'Form overrides dispose to clean up the component list.
    Protected Overloads Overrides Sub Dispose(ByVal disposing As Boolean)
        If disposing Then
            If Not (components Is Nothing) Then
                components.Dispose()
            End If
        End If
        MyBase.Dispose(disposing)
    End Sub
    Friend WithEvents DataGrid1 As System.Windows.Forms.DataGrid
    Friend WithEvents Button1 As System.Windows.Forms.Button
    Friend WithEvents ListBox1 As System.Windows.Forms.ListBox
    Friend WithEvents ListBox2 As System.Windows.Forms.ListBox
    Friend WithEvents ListBox3 As System.Windows.Forms.ListBox
    Friend WithEvents Button2 As System.Windows.Forms.Button
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Me.DataGrid1 = New System.Windows.Forms.DataGrid()
        Me.Button1 = New System.Windows.Forms.Button()
        Me.ListBox1 = New System.Windows.Forms.ListBox()
        Me.ListBox2 = New System.Windows.Forms.ListBox()
        Me.ListBox3 = New System.Windows.Forms.ListBox()
        Me.Button2 = New System.Windows.Forms.Button()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        CType(Me.DataGrid1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'DataGrid1
        '
        Me.DataGrid1.DataMember = ""
        Me.DataGrid1.HeaderForeColor = System.Drawing.SystemColors.ControlText
        Me.DataGrid1.Location = New System.Drawing.Point(16, 16)
        Me.DataGrid1.Name = "DataGrid1"
        Me.DataGrid1.Size = New System.Drawing.Size(536, 224)
        Me.DataGrid1.TabIndex = 0
        '
        'Button1
        '
        Me.Button1.Location = New System.Drawing.Point(248, 248)
        Me.Button1.Name = "Button1"
        Me.Button1.TabIndex = 1
        Me.Button1.Text = "Load"
        '
        'ListBox1
        '
        Me.ListBox1.Location = New System.Drawing.Point(16, 312)
        Me.ListBox1.Name = "ListBox1"
        Me.ListBox1.Size = New System.Drawing.Size(168, 147)
        Me.ListBox1.TabIndex = 2
        '
        'ListBox2
        '
        Me.ListBox2.Location = New System.Drawing.Point(192, 312)
        Me.ListBox2.Name = "ListBox2"
        Me.ListBox2.Size = New System.Drawing.Size(168, 147)
        Me.ListBox2.TabIndex = 3
        '
        'ListBox3
        '
        Me.ListBox3.Location = New System.Drawing.Point(368, 312)
        Me.ListBox3.Name = "ListBox3"
        Me.ListBox3.Size = New System.Drawing.Size(168, 147)
        Me.ListBox3.TabIndex = 4
        '
        'Button2
        '
        Me.Button2.Location = New System.Drawing.Point(240, 480)
        Me.Button2.Name = "Button2"
        Me.Button2.TabIndex = 5
        Me.Button2.Text = "Load"
        '
        'Label1
        '
        Me.Label1.Location = New System.Drawing.Point(16, 288)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(160, 23)
        Me.Label1.TabIndex = 6
        Me.Label1.Text = "Label1"
        '
        'Label2
        '
        Me.Label2.Location = New System.Drawing.Point(192, 288)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(168, 23)
        Me.Label2.TabIndex = 7
        Me.Label2.Text = "Label2"
        '
        'Label3
        '
        Me.Label3.Location = New System.Drawing.Point(368, 288)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(168, 23)
        Me.Label3.TabIndex = 8
        Me.Label3.Text = "Label3"
        '
        'Form1
        '
        Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
        Me.ClientSize = New System.Drawing.Size(560, 510)
        Me.Controls.AddRange(New System.Windows.Forms.Control() {Me.Label3, Me.Label2, Me.Label1, Me.Button2, Me.ListBox3, Me.ListBox2, Me.ListBox1, Me.Button1, Me.DataGrid1})
        Me.Name = "Form1"
        Me.Text = "Form1"
        CType(Me.DataGrid1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

#End Region

    Private Sub Form1_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

    End Sub

    Private Shared Sub OnColumnChanged(ByVal sender As Object, _
                                ByVal args As DataColumnChangeEventArgs)
        MessageBox.Show((args.Column.ColumnName & _
                " changed to '" & args.ProposedValue.ToString() & "'"))
    End Sub

    Private Shared Sub OnRowChanged(ByVal sender As Object, _
                            ByVal args As DataRowChangeEventArgs)
        If args.Action <> DataRowAction.Nothing Then
            'some code here does something
        End If
    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        Dim oWS As New localhost.NorthwindData()

        m_oDS = oWS.GetCustomerList
        DataGrid1.DataSource = m_oDS

        AddHandler m_oDS.Tables(0).ColumnChanged, _
                New DataColumnChangeEventHandler(AddressOf OnColumnChanged)
        AddHandler m_oDS.Tables(0).RowChanged, _
                New DataRowChangeEventHandler(AddressOf OnRowChanged)


    End Sub

    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click
        Dim oConn As New SqlConnection("Password=;User ID=sa;" & _
            "Initial Catalog=Northwind;Data Source=(local)")
        Dim oCmd As New SqlCommand("Select * from customers", oConn)
        Dim oDA As SqlDataAdapter
        Dim oDS As New DataSet()
        Dim xmlDoc As XmlDataDocument
        Dim oRootNode As XmlNode
        Dim oCustNode As XmlNode
        Dim oNode As XmlNode
        Dim iCnt As Int32
        Dim oDT As DataTable
        Dim oTempNode As XmlNode
        Dim oWriter As XmlTextWriter
        Dim xslTran As XslTransform

        'load up the dataset with data and schema
        oDA = New SqlDataAdapter(oCmd)
        'set the select command to fill dataset
        oDA.Fill(oDS, "Customers")
        oDA.FillSchema(oDS, SchemaType.Mapped, "Customers")

        'synchronize XmpDataDocument with the dataset
        xmlDoc = New XmlDataDocument(oDS)

        'look at what in dataset exposed by xmldataddocument
        With xmlDoc.DataSet.Tables(0)
            Label1.Text = "Count: " & .Rows.Count.ToString
            For iCnt = 0 To (.Rows.Count - 1)
                'display customer id in list box
                ListBox1.Items.Add(.Rows(iCnt).Item(0).ToString)
            Next
        End With

        'point to the root node
        oRootNode = xmlDoc.FirstChild

        xmlDoc.DataSet.EnforceConstraints = False

        'remove a node
        oTempNode = oRootNode.FirstChild
        oRootNode.RemoveChild(oTempNode)

        'display rows using dataset
        'get the "Customers" DataTable
        With xmlDoc.DataSet
            oDT = .Tables(0).GetChanges(DataRowState.Unchanged)
        End With

        With oDT
            Label2.Text = "Count: " & .Rows.Count.ToString
            For iCnt = 0 To (.Rows.Count - 1)
                'display customer id in list box
                ListBox2.Items.Add(.Rows(iCnt).Item(0).ToString)
            Next
        End With

        'reject the changes
        xmlDoc.DataSet.RejectChanges()

        'display rows using xmldatadocument
        Label3.Text = "Count: " & _
                    xmlDoc.DataSet.Tables(0).Rows.Count.ToString
        For Each oCustNode In oRootNode.ChildNodes
            For Each oNode In oCustNode.ChildNodes
                If oNode.Name = "CustomerID" Then
                    ListBox3.Items.Add(oNode.InnerText.ToString)
                    Exit For
                End If
            Next
        Next

        'use xsl to create a new xml
        xslTran = New XslTransform()
        xslTran.Load("c:\CustomersTransform.xsl")
        oWriter = New XmlTextWriter("c:\xslt_output.xml", _
                                System.Text.Encoding.UTF8)
        oWriter.WriteStartDocument()
        xslTran.Transform(xmlDoc, Nothing, oWriter)
        oWriter.WriteEndDocument()
        oWriter.Close()

    End Sub
End Class
