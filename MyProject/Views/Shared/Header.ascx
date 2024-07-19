<%@ Control Language="C#" Inherits="System.Web.Mvc.ViewUserControl<dynamic>" %>
<header class="site-header">
	<div class="main-nav padding-x">
		<a href="/" class="logo">
			<svg><use xlink:href="#i-logo"></use></svg>
		</a>
		<nav class="mobile-nav-contain">
			<ul class="main-nav-list">
				<li><a href="/posts" title="">All Posts</a></li>
				<li><a href="/my-posts" title="">My Posts</a></li>
				<li><a href="/account" title="">Account</a></li>
			</ul>
		</nav>
	</div>
</header>
