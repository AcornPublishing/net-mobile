<%@ Page Language="vb" AutoEventWireup="false" Codebehind="menu1.aspx.vb" Inherits="mobileCinema.menu1" %>
<%@ Register TagPrefix="mobile" Namespace="System.Web.UI.MobileControls" Assembly="System.Web.Mobile" %>
<meta name="GENERATOR" content="Microsoft Visual Studio.NET 7.0">
<meta name="CODE_LANGUAGE" content="Visual Basic 7.0">
<meta name="vs_targetSchema" content="Mobile Web Page">
<body xmlns:mobile="Mobile Web Form Controls">
	<mobile:Form id="Form1" runat="server">
		<mobile:Link id="Link1" runat="server" NavigateURL="movielist.aspx">Movies</mobile:Link>
		<mobile:Link id="Link2" runat="server" NavigateURL="address.aspx">Address</mobile:Link>
		<mobile:Link id="Link3" runat="server" NavigateURL="directions.aspx">Directions</mobile:Link>
	</mobile:Form>
</body>
