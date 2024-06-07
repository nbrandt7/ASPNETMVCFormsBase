<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/site.Master" Inherits="System.Web.Mvc.ViewPage<MyProject.ViewModels.DemoModel>" %>

<asp:Content ContentPlaceHolderID="Head" runat="server">
	<title><%: Model.Title %></title>
</asp:Content>

<asp:Content ContentPlaceHolderID="Body" runat="server">
	<h1><%: Model.Heading %></h1>
	<div><%: Model.Description %></div>
	<div><%: Model.Date.ToString("d") %></div>
	<div><a href="/">Home</a></div>
	<div>
		<% Html.RenderAction( "MyChildPartialAction", "Page", new { description = "This is rendered by a partial action" } ); %>
	</div>
</asp:Content>
