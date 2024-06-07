using System;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace MyProject {
	public partial class MvcApplication : HttpApplication {
		public static void RegisterRoutes( RouteCollection routes ) {
			// Ignore the axd routes
			routes.IgnoreRoute( "{resource}.axd/{*pathInfo}" );
			routes.MapRoute( "Find", "find/{controller}/{action}/{id}", new { controller = "", action = "", id = UrlParameter.Optional } );
			// Pages route to handle dynamic page rendering
			routes.MapRoute("Pages", "{*path}", new { controller = "Page", action = "RenderPage" });
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
