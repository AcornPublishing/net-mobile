<%@ Page Language="vb" AutoEventWireup="false" Codebehind="address.aspx.vb" Inherits="mobileCinema.address" %>
<%@ Register TagPrefix="mobile" Namespace="System.Web.UI.MobileControls" Assembly="System.Web.Mobile" %>
<meta name="GENERATOR" content="Microsoft Visual Studio.NET 7.0">
<meta name="CODE_LANGUAGE" content="Visual Basic 7.0">
<meta name="vs_targetSchema" content="Mobile Web Page">
<body xmlns:mobile="Mobile Web Form Controls">
	<mobile:Form id="Form1" runat="server">
		<mobile:TextView id="TextView1" runat="server"></mobile:TextView>
		<mobile:Link id="movies" runat="server" NavigateURL="movielist.aspx">Movies</mobile:Link>
		<mobile:Link id="directions" runat="server" NavigateURL="directions.aspx">Directions</mobile:Link>
	</mobile:Form>
</body>
