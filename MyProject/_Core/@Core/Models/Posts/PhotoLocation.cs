using System.Collections.Generic;
using System.Data.Entity;

namespace MyProject.Models
{
	public class PhotoLocation
	{
		public int Id { get; set; }
		public byte[] Photo { get; set; }
		public string Description { get; set; }
		public double Latitude { get; set; }
		public double Longitude { get; set; }
	}

	public class ApplicationDbContext : DbContext
	{
		public DbSet<PhotoLocation> PhotoLocations { get; set; }

		public ApplicationDbContext() : base("DefaultConnection") { }
	}
}
