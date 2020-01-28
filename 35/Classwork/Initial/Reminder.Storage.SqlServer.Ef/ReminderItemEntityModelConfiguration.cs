using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Reminder.Storage.SqlServer.Ef
{
	public class ReminderItemEntityModelConfiguration : IEntityTypeConfiguration<ReminderItemEntity>
	{
		public void Configure(EntityTypeBuilder<ReminderItemEntity> builder)
		{
			builder.ToTable("Reminders");
			builder.Property(_ => _.Id);
			builder.Property(_ => _.Message)
				.IsRequired()
				.HasMaxLength(2048);
			builder.Property(_ => _.DatetimeUtc);
			builder.Property(_ => _.Status);
			builder.Property(_ => _.CreatedDatetimeUtc)
				.ValueGeneratedOnAdd()
				.HasDefaultValueSql("SYSDATETIMEOFFSET()");
			builder.Property(_ => _.ModifiedDatetimeUtc)
				.ValueGeneratedOnUpdate()
				.HasDefaultValueSql("SYSDATETIMEOFFSET()");
			builder.HasOne(_ => _.Contact)
				.WithMany(_ => _.Reminders)
				.IsRequired();
		}
	}
}