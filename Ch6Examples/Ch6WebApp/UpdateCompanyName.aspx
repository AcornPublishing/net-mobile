<%@ Page Language="vb" AutoEventWireup="false" Codebehind="UpdateCompanyName.aspx.vb" Inherits="Ch6WebApp.UpdateCompanyName"%>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN">
<HTML>
	<HEAD>
		<title>UpdateCompanyName</title>
		<meta name="GENERATOR" content="Microsoft Visual Studio.NET 7.0">
		<meta name="CODE_LANGUAGE" content="Visual Basic 7.0">
		<meta name="vs_defaultClientScript" content="JavaScript">
		<meta name="vs_targetSchema" content="http://schemas.microsoft.com/intellisense/ie5">
	</HEAD>
	<body MS_POSITIONING="GridLayout">
		<form id="Form1" method="post" runat="server">
			<asp:Label id="Label1" style="Z-INDEX: 101; LEFT: 67px; POSITION: absolute; TOP: 422px" runat="server" Width="208px" Height="78px"></asp:Label>
			<asp:ListBox id="DDList1" style="Z-INDEX: 102; LEFT: 58px; POSITION: absolute; TOP: 76px" runat="server" Width="223px" Height="185px"></asp:ListBox>
			<asp:TextBox id="txtCompanyName" style="Z-INDEX: 103; LEFT: 60px; POSITION: absolute; TOP: 297px" runat="server" Width="218px"></asp:TextBox>
			<asp:Button id="Button1" style="Z-INDEX: 104; LEFT: 65px; POSITION: absolute; TOP: 333px" runat="server" Text="Update"></asp:Button>
			<asp:Label id="Label2" style="Z-INDEX: 105; LEFT: 60px; POSITION: absolute; TOP: 272px" runat="server" Width="209px" Font-Bold="True">Enter New Company Name:</asp:Label>
			<asp:Label id="Label3" style="Z-INDEX: 106; LEFT: 58px; POSITION: absolute; TOP: 48px" runat="server" Width="210px" Font-Bold="True">Select Company Name:</asp:Label>
			<asp:Label id="Label4" style="Z-INDEX: 107; LEFT: 58px; POSITION: absolute; TOP: 14px" runat="server" Width="214px" Font-Bold="True" Font-Size="Large">ADO.NET Example</asp:Label>
			<asp:RequiredFieldValidator id="RequiredFieldValidator1" style="Z-INDEX: 108; LEFT: 68px; POSITION: absolute; TOP: 374px" runat="server" ErrorMessage="Please enter a new Company Name." ControlToValidate="txtCompanyName"></asp:RequiredFieldValidator>
		</form>
	</body>
</HTML>
