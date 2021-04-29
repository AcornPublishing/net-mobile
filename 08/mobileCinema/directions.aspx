<%@ Page Language="vb" AutoEventWireup="false" Codebehind="directions.aspx.vb" Inherits="mobileCinema.directions" %>
<%@ Register TagPrefix="mobile" Namespace="System.Web.UI.MobileControls" Assembly="System.Web.Mobile" %>
<meta name="GENERATOR" content="Microsoft Visual Studio.NET 7.0">
<meta name="CODE_LANGUAGE" content="Visual Basic 7.0">
<meta name="vs_targetSchema" content="Mobile Web Page">
<body xmlns:mobile="Mobile Web Form Controls">
	<mobile:Form id="Form1" runat="server">
		<mobile:TextView id="TextView1" runat="server"></mobile:TextView>
		<mobile:Link id="movies" runat="server" NavigateURL="movielist.aspx">Movies</mobile:Link>
		<mobile:Link id="address" runat="server" NavigateURL="address.aspx">Address</mobile:Link>
	</mobile:Form>
</body>
