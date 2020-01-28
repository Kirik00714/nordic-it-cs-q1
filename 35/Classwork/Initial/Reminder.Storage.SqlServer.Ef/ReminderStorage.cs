using System;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Reminder.Storage.Exceptions;

namespace Reminder.Storage.SqlServer.Ef
{
	public class ReminderStorage : IReminderStorage
	{
		private readonly IServiceProvider _provider;

		public ReminderStorage(IServiceProvider provider)
		{
			_provider = provider;
		}
		public ReminderItem FindById(Guid id)
		{
			using var context = CreateContext();

			var item = context.Reminders
				.Include(_ => _.Contact)
				.SingleOrDefault(_ => _.Id == id);
			if (item is null)
			{
				throw new ReminderItemNotFoundException(id);
			}

			return new ReminderItem(
				item.Id,
				item.Contact.Login,
				item.Message,
				item.DatetimeUtc,
				item.Status
			);
		}
		public PagedResult FindBy(ReminderItemFilter filter)
		{
			using var context = CreateContext();

			var result = context.Reminders
				.Include(_ => _.Contact)
				.AsQueryable();

			if (filter.ByStatus)
			{
				result = result.Where(_ => _.Status == filter.Status);
			}

			if (filter.ByDatetime)
			{
				result = result.Where(_ => _.DatetimeUtc < filter.DatetimeUtc);
			}

			var items = result
				.OrderBy(_ => _.DatetimeUtc)
				.Skip(filter.Page.Offset)
				.Take(filter.Page.Limit);

			return new PagedResult(
				result.Count(),
				filter.Page,
				items.Select(_ =>
					new ReminderItem(_.Id, _.Contact.Login, _.Message, _.DatetimeUtc, _.Status)
				)
			);
		}
		public void Add(ReminderItem item)
		{
			using var context = CreateContext();

			var duplicate = context.Reminders.Find(item.Id);
			if (duplicate != null)
			{
				throw new ReminderItemDuplicateException(item.Id);
			}
			var contact = context.Contacts.FirstOrDefault(_ => _.Login == item.ContactId) ?? 
						  new ContactEntity(item.ContactId);

			context.Reminders.Add(
				new ReminderItemEntity(item, contact)
			);
			context.SaveChanges();
		}
		public void Update(ReminderItem item)
		{
			using var context = CreateContext();

			var entity = context.Reminders.Find(item.Id);
			if (entity is null)
			{
				throw new ReminderItemNotFoundException(item.Id);
			}

			entity.Message = item.Message;
			entity.DatetimeUtc = item.DatetimeUtc;
			entity.Status = item.Status;

			context.SaveChanges();
		}
		public void Delete(Guid id)
		{
			using var context = CreateContext();

			var entity = context.Reminders.Find(id);
			if (entity is null)
			{
				throw new ReminderItemNotFoundException(id);
			}

			context.Reminders.Remove(entity);
			context.SaveChanges();
		}
		public void Clear()
		{
			using var context = CreateContext();

			context.Database.ExecuteSqlRaw("TRUNCATE TABLE [Reminders];");
		}
		private ReminderStorageContext CreateContext()
		{
			// return (ReminderStorageContext) _provider.GetService(typeof(ReminderStorageContext));
			return _provider.GetService<ReminderStorageContext>();;
		}
	}
}