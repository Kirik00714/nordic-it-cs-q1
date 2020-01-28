using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace Reminder.Storage.SqlServer.Ef
{
	public static class DependencyCollectionExtensions
	{
		public static void AddReminderStorage(this IServiceCollection services, string connectionString)
		{
			services.AddDbContext<ReminderStorageContext>(
				options => options.UseSqlServer(connectionString)
			);
			services.AddTransient<IReminderStorage, ReminderStorage>();
		}
	}
}