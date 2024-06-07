using MyProject.ViewModels;
using System;
using System.IO;
using System.Web.Mvc;

namespace MyProject.Controllers {
	public partial class PageController : Controller {

		[HttpGet]
		public ActionResult FooBar() {
			var model = new DemoModel() {
				Title = "FooBar",
				Heading = "FooBar page",
				Description = "A FooBar demo page with a description",
				Date = DateTime.Now
			};
			return RedirectToAction( "RenderPage", "Page", new { path = "FooBar/Index", model = model } );
		}

		[HttpGet]
		public ActionResult RenderPage( string path, DemoModel model = null ) {
			// Clean up the path and replace slashes with underscores if necessary
			string viewPath = string.IsNullOrEmpty(path) ? $"~/Views/Page/Index.aspx" : $"~/Views/Page/{ParsePath(path)}/Index.aspx";

			// Attempt to render the view corresponding to the URL
			if (ViewExists( viewPath )) {
				return View( viewPath, model );
			} else {
				// If the view does not exist, return a 404 page
				return HttpNotFound();
			}
		}

		// Method to parse the path and handle placeholders dynamically
		private string ParsePath( string path ) {
			// Check if the path contains placeholders within square brackets
			if (path.Contains( "[" ) && path.Contains( "]" )) {
				// Split the path into segments
				string[] segments = path.Split( '/' );
				for (int i = 0; i < segments.Length; i++) {
					// Check if the segment contains a placeholder within square brackets
					if (segments[i].StartsWith( "[" ) && segments[i].EndsWith( "]" )) {
						// Attempt to resolve the placeholder dynamically
						string resolvedValue = ResolvePlaceholder( segments[i] );
						if (!string.IsNullOrEmpty( resolvedValue )) {
							segments[i] = resolvedValue;
						} else {
							// If placeholder cannot be resolved, return original path
							return path;
						}
					}
				}
				// Join the segments back into a path string
				return string.Join( "/", segments );
			}
			// If no placeholders are found, return the original path
			return path;
		}

		// Method to resolve the placeholder dynamically
		private string ResolvePlaceholder( string placeholder ) {
			// Extract the placeholder without the square brackets
			string placeholderName = placeholder.Substring( 1, placeholder.Length - 2 );
			// Check if there exists a folder with the name of the placeholder
			string folderPath = System.Web.Hosting.HostingEnvironment.MapPath( $"~/Views/Page/{placeholderName}" );
			if (Directory.Exists( folderPath )) {
				return placeholderName; // Return the placeholder as the resolved value
			}
			return null; // Placeholder not resolved
		}


		private bool ViewExists( string name ) {
			ViewEngineResult result = ViewEngines.Engines.FindView( ControllerContext, name, null );
			return ( result.View != null );
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
