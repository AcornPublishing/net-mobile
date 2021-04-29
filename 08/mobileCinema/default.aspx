<%@ Register TagPrefix="mobile" Namespace="System.Web.UI.MobileControls" Assembly="System.Web.Mobile" %>
<%@ Page Language="vb" AutoEventWireup="false" Codebehind="default.aspx.vb" Inherits="mobileCinema.home" %>
<meta content="Microsoft Visual Studio.NET 7.0" name="GENERATOR">
<meta content="Visual Basic 7.0" name="CODE_LANGUAGE">
<meta content="Mobile Web Page" name="vs_targetSchema">
<body xmlns:mobile="Mobile Web Form Controls">
	<mobile:form id="Form1" runat="server">
		<mobile:TextView id="Title" runat="server" Font-Bold="True"></mobile:TextView>
		<mobile:Link id="theater" runat="server" NavigateURL="menu1.aspx"></mobile:Link>
		<mobile:Call id="callTheater" runat="server"></mobile:Call>
	</mobile:form>
</body>
