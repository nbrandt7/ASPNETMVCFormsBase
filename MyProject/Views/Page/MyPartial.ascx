<%@ Control Language="C#" Inherits="System.Web.Mvc.ViewUserControl<MyProject.ViewModels.DemoModel>" %>
<h1><%: Model.Heading %></h1>
<div><%: Model.Description %></div>
<div>
	<svg xmlns="http://www.w3.org/2000/svg"><use xmlns:xlink="http://www.w3.org/1999/xlink" xlink:href="#i-star-filled"></use></svg>
	<svg xmlns="http://www.w3.org/2000/svg"><use xmlns:xlink="http://www.w3.org/1999/xlink" xlink:href="#i-star-filled"></use></svg>
	<svg xmlns="http://www.w3.org/2000/svg"><use xmlns:xlink="http://www.w3.org/1999/xlink" xlink:href="#i-star-filled"></use></svg>
	<svg xmlns="http://www.w3.org/2000/svg"><use xmlns:xlink="http://www.w3.org/1999/xlink" xlink:href="#i-star-filled"></use></svg>
	<svg xmlns="http://www.w3.org/2000/svg"><use xmlns:xlink="http://www.w3.org/1999/xlink" xlink:href="#i-star-outline"></use></svg>
</div>
