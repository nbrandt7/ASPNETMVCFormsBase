using System;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace MyProject {
	public partial class MvcApplication : HttpApplication {
		public static void RegisterRoutes( RouteCollection routes ) {
			// Ignore the axd routes
			routes.IgnoreRoute( "{resource}.axd/{*pathInfo}" );

			// Route for the Home page
			routes.MapRoute(
				name: "Home",
				url: "",
				defaults: new { controller = "Page", action = "Home", id = UrlParameter.Optional }
			);

			// Custom route to handle pages by filename
			routes.MapPageRoute(
				"PagesRoute",
				"{filename}",
				"~/Views/Page/{filename}.aspx"
			);

			// Default route
			routes.MapRoute(
				name: "Default",
				url: "find/{controller}/{action}/{id}",
				defaults: new { controller = "Home", action = "Index", id = UrlParameter.Optional }
			);
		}

		protected void Application_Start() {
			AreaRegistration.RegisterAllAreas();
			RegisterGlobalFilters( GlobalFilters.Filters );
			RegisterRoutes( RouteTable.Routes );
			MvcHandler.DisableMvcResponseHeader = true;
		}

		protected void Application_Error( object sender, EventArgs e ) {
		}

		protected void Application_BeginRequest() {
		}

		protected void Application_PreSendRequestHeaders() {
			Response.Headers.Remove( "Server" );
		}

		protected void Session_Start() {
		}

		public static void RegisterGlobalFilters( GlobalFilterCollection filters ) {
			filters.Add( new HandleErrorAttribute() );
		}
	}
}
