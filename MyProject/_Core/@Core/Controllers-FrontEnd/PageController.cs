using MyProject.ViewModels;
using System;
using System.Web.Mvc;

namespace MyProject.Controllers {
	public partial class PageController : Controller {
		[HttpGet]
		public ActionResult Home() {
			return View();
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

		[HttpGet]
		public ActionResult RenderPage( string filename ) {
			return View( "~/Views/Page/" + filename + ".aspx" );
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
