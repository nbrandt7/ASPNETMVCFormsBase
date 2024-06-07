<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/site.Master" Inherits="System.Web.Mvc.ViewPage<dynamic>" %>

<asp:Content ContentPlaceHolderID="Head" runat="server">
	<title>Home</title>
</asp:Content>

<asp:Content ContentPlaceHolderID="Body" runat="server">
	<h1>Home page</h1>
	<p>Another test page <a href="/find/Page/FooBar">link</a></p>
</asp:Content>
