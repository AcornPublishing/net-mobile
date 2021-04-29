<%@ Register TagPrefix="mobile" Namespace="System.Web.UI.MobileControls" Assembly="System.Web.Mobile" %>
<%@ Page Language="vb" AutoEventWireup="false" Codebehind="recap.aspx.vb" Inherits="mobileCinema.recap_" %>
<meta name="GENERATOR" content="Microsoft Visual Studio.NET 7.0">
<meta name="CODE_LANGUAGE" content="Visual Basic 7.0">
<meta name="vs_targetSchema" content="Mobile Web Page">
<body xmlns:mobile="Mobile Web Form Controls">
	<mobile:Form id="Form1" runat="server">
		<mobile:TextView id="recap" runat="server">TextView</mobile:TextView>
		<mobile:Label id="subValue" runat="server" Alignment="Right"></mobile:Label>
		<mobile:Label id="TaxValue" runat="server" Alignment="Right"></mobile:Label>
		<mobile:Label id="totalValue" runat="server" Alignment="Right"></mobile:Label>
		<mobile:Link id="Link1" runat="server" NavigateURL="purchase3.aspx">buy</mobile:Link>
	</mobile:Form>
</body>
