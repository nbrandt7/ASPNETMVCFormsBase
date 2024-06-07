using System;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace MyProject {
	public partial class MvcApplication : HttpApplication {
		public static void RegisterRoutes( RouteCollection routes ) {
			routes.MapRoute( "Home", "", new { controller = "Page", action = "Home", id = UrlParameter.Optional } );
			routes.MapRoute( "Default", "find/{controller}/{action}/{id}", new { controller = "", action = "", id = UrlParameter.Optional } );
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
