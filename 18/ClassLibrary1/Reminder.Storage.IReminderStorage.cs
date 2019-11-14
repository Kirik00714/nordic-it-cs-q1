using System;
using System.Collections.Generic;

namespace Reminder.Storage
{
	/// <summary>
	/// Определяет основные методы хранилища напоминаний
	/// </summary>
	public interface IReminderStorage
	{
		/// <summary>
		/// Сохраняет новый элемент <see cref="ReminderItem"/>
		/// </summary>
		/// <param name="item">Элемент ReminderItem</param>
		void Create(ReminderItem item);

		/// <summary>
		/// Обновляет данные элемента <see cref="ReminderItem"/>
		/// </summary>
		/// <param name="item">Элемент <see cref="ReminderItem"/></param>
		void Update(ReminderItem item);

		/// <summary>
		/// Реализирует поиск элемента  <see cref="ReminderItem"/> по идентификатору
		/// </summary>
		/// <param name="id">Элемент ReminderItem</param>
		/// <returns>Найденный элемент <see cref="ReminderItem"/></returns>
		ReminderItem FyndById(Guid id);

		/// <summary>
		/// Возвращает все элементы <see cref="ReminderItem"/> не позднее указанной даты
		/// </summary>
		/// <param name="dateTime"></param>
		/// <returns>Коллекция элементов <see cref="ReminderItem"/></returns>
		List<ReminderItem> FyndByDateTime(DateTimeOffset dateTime);
	}
}
