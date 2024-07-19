using MyProject.Models;
using System;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MyProject.Controllers {
	public partial class MapController : Controller
	{
		private readonly ApplicationDbContext _context = new ApplicationDbContext();

		[HttpGet]
		public ActionResult GetAllLocations()
		{
			var photoLocations = _context.PhotoLocations.ToList();
			var locations = photoLocations.Select(pl => new {
				pl.Latitude,
				pl.Longitude,
				pl.Description,
				Photo = Convert.ToBase64String(pl.Photo)
			}).ToList();
			return Json(locations, JsonRequestBehavior.AllowGet);
		}

		[HttpPost]
		public ActionResult UploadPhoto(HttpPostedFileBase photo, string description, double latitude, double longitude)
		{
			if (photo != null && photo.ContentLength > 0)
			{
				try
				{
					byte[] photoBytes;
					using (var binaryReader = new BinaryReader(photo.InputStream))
					{
						photoBytes = binaryReader.ReadBytes(photo.ContentLength);
					}

					// Create a new PhotoLocation object
					var newLocation = new PhotoLocation
					{
						Photo = photoBytes,
						Description = description,
						Latitude = latitude,
						Longitude = longitude
					};

					// Add the new location to the database
					_context.PhotoLocations.Add(newLocation);
					_context.SaveChanges();

					TempData["Message"] = "Photo uploaded successfully!";
				}
				catch (Exception ex)
				{
					TempData["ErrorMessage"] = $"An error occurred: {ex.Message}";
				}
			}
			else
			{
				TempData["ErrorMessage"] = "No file uploaded!";
			}

			// Redirect to a view (e.g., the same page or a different page)
			return View("~/Views/Page/Index.aspx"); // Redirect to the homepage or another appropriate view
		}
	}
}
