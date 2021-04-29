<%@ Register TagPrefix="mobile" Namespace="System.Web.UI.MobileControls" Assembly="System.Web.Mobile" %>
<%@ Page Language="vb" AutoEventWireup="false" Codebehind="purchase1.aspx.vb" Inherits="mobileCinema.purchase1" %>
<meta content="Microsoft Visual Studio.NET 7.0" name="GENERATOR">
<meta content="Visual Basic 7.0" name="CODE_LANGUAGE">
<meta content="Mobile Web Page" name="vs_targetSchema">
<body xmlns:mobile="Mobile Web Form Controls">
	<mobile:form id="Form1" runat="server">
		<mobile:TextView id="TextView1" runat="server"></mobile:TextView>
		<mobile:RequiredFieldValidator id="RequiredFieldValidator1" runat="server" ControlToValidate="login" ErrorMessage="*"></mobile:RequiredFieldValidator>
		<mobile:Label id="Label1" runat="server">Login</mobile:Label>
		<mobile:TextBox id="login" runat="server"></mobile:TextBox>
		<mobile:RegularExpressionValidator id="RegularExpressionValidator1" runat="server" ControlToValidate="login" ErrorMessage="RegularExpressionValidator" ValidationExpression="^.*@.*\..*"></mobile:RegularExpressionValidator>
		<mobile:RequiredFieldValidator id="RequiredFieldValidator2" runat="server" ControlToValidate="login" ErrorMessage="*"></mobile:RequiredFieldValidator>
		<mobile:Label id="Label2" runat="server">Password</mobile:Label>
		<mobile:TextBox id="password" runat="server" Password="True"></mobile:TextBox>
		<mobile:Command id="Command1" runat="server">Submit</mobile:Command>
	</mobile:form>
</body>
