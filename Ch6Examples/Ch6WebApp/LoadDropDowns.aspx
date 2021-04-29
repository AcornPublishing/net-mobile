<%@ Page Language="vb" AutoEventWireup="false" Codebehind="LoadDropDowns.aspx.vb" Inherits="Ch6WebApp.LoadDropDowns"%>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN">
<HTML>
	<HEAD>
		<title>LoadDropDowns</title>
		<meta name="GENERATOR" content="Microsoft Visual Studio.NET 7.0">
		<meta name="CODE_LANGUAGE" content="Visual Basic 7.0">
		<meta name="vs_defaultClientScript" content="JavaScript">
		<meta name="vs_targetSchema" content="http://schemas.microsoft.com/intellisense/ie5">
	</HEAD>
	<body MS_POSITIONING="GridLayout">
		<form id="Form1" method="post" runat="server">
			<asp:ListBox id="DDList1" style="Z-INDEX: 101; LEFT: 46px; POSITION: absolute; TOP: 102px" runat="server" Width="195px" Height="207px"></asp:ListBox>
			<asp:ListBox id="DDList2" style="Z-INDEX: 102; LEFT: 256px; POSITION: absolute; TOP: 101px" runat="server" Width="200px" Height="204px"></asp:ListBox>
			<asp:Label id="Label1" style="Z-INDEX: 103; LEFT: 47px; POSITION: absolute; TOP: 46px" runat="server" Width="265px" Font-Bold="True" Font-Size="Large">DataReader Example</asp:Label>
			<asp:Button id="Button1" style="Z-INDEX: 104; LEFT: 191px; POSITION: absolute; TOP: 332px" runat="server" Text="Load DropDowns"></asp:Button>
		</form>
	</body>
</HTML>
