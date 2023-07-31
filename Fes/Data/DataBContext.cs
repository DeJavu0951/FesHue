using Microsoft.EntityFrameworkCore;

namespace Fes.Data
{
	public class DataBContext : DbContext
	{
		public DataBContext(DbContextOptions options) : base(options) { }

		public DbSet<Event> Events { get; set; }
		public DbSet<Schedule> Schedules { get; set; }
		public DbSet<Ticket> Tickets { get; set; }
	}
}
