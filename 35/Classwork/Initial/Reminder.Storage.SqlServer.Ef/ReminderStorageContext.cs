using Microsoft.EntityFrameworkCore;

namespace Reminder.Storage.SqlServer.Ef
{
	// POCO
	// Plain
	// Old
	// C#
	// Object

	public class ReminderStorageContext : DbContext
	{
		public DbSet<ContactEntity> Contacts { get; set; }
		public DbSet<ReminderItemEntity> Reminders { get; set; }

		public ReminderStorageContext(DbContextOptions<ReminderStorageContext> options) :
			base(options)
		{
		}

		protected override void OnModelCreating(ModelBuilder modelBuilder)
		{
			// modelBuilder.ApplyConfigurationsFromAssembly(
			// 	typeof(ReminderStorageContext).Assembly
			// );
			modelBuilder.ApplyConfiguration(new ContactEntityModelConfiguration());
			modelBuilder.ApplyConfiguration(new ReminderItemEntityModelConfiguration());
		}
	}
}