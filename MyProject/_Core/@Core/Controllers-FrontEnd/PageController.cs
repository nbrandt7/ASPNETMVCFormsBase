using MyProject.ViewModels;
using System;
using System.Web.Mvc;

namespace MyProject.Controllers {
	public partial class PageController : Controller {
		[HttpGet]
		public ActionResult Home() {
			return View( "~/Views/Page/Home.aspx" );
		}


		[HttpGet]
		public ActionResult FooBar() {
			var model = new DemoModel() {
				Title = "FooBar",
				Heading = "FooBar page",
				Description = "A FooBar demo page with a description",
				Date = DateTime.Now
			};
			return View( "~/Views/Page/FooBar.aspx", model );
		}

		[ChildActionOnly]
		public ActionResult MyChildPartialAction( string description ) {
			var model = new DemoModel() {
				Heading = "Partial action",
				Description = description,
			};
			return PartialView( "~/Views/Page/MyPartial.ascx", model );
		}
	}
}
