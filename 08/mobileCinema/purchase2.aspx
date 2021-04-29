<%@ Register TagPrefix="mobile" Namespace="System.Web.UI.MobileControls" Assembly="System.Web.Mobile" %>
<%@ Page Language="vb" AutoEventWireup="false" Codebehind="purchase2.aspx.vb" Inherits="mobileCinema.purchase2" %>
<meta name="GENERATOR" content="Microsoft Visual Studio.NET 7.0">
<meta name="CODE_LANGUAGE" content="Visual Basic 7.0">
<meta name="vs_targetSchema" content="Mobile Web Page">
<body xmlns:mobile="Mobile Web Form Controls">
	<mobile:Form id="Form1" runat="server">
		<mobile:TextView id="recap" runat="server"></mobile:TextView>
		<mobile:TextView id="TextView1" runat="server"># of Tickets</mobile:TextView>
		<mobile:TextBox id="ticketCount" runat="server"></mobile:TextBox>
		<mobile:Command id="Command1" runat="server">submit</mobile:Command>
	</mobile:Form>
</body>
