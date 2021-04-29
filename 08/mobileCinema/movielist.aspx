<%@ Page Language="vb" AutoEventWireup="false" Codebehind="movielist.aspx.vb" Inherits="mobileCinema.movielist" %>
<%@ Register TagPrefix="mobile" Namespace="System.Web.UI.MobileControls" Assembly="System.Web.Mobile" %>
<meta name="GENERATOR" content="Microsoft Visual Studio.NET 7.0">
<meta name="CODE_LANGUAGE" content="Visual Basic 7.0">
<meta name="vs_targetSchema" content="Mobile Web Page">
<body xmlns:mobile="Mobile Web Form Controls">
	<mobile:Form id="Form1" runat="server">
		<mobile:List id="movieList" runat="server" ItemsAsLinks="True"></mobile:List>
	</mobile:Form>
</body>
