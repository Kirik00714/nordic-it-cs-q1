using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Reminder.Storage.SqlServer.Ef
{
	public class ContactEntityModelConfiguration : IEntityTypeConfiguration<ContactEntity>
	{
		public void Configure(EntityTypeBuilder<ContactEntity> builder)
		{
			builder.ToTable("Contacts");
			builder.Property(_ => _.Id);
			builder.Property(_ => _.Login)
				.IsRequired()
				.HasMaxLength(64)
				.IsUnicode(false);
			builder.HasAlternateKey(_ => _.Login);
		}
	}
}