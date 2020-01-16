namespace Reminder.Storage
{
	public class PageInfo
	{
		public static PageInfo All { get; } =
			new PageInfo();

		public uint Number { get; set; }

		public uint Size { get; set; }

		public PageInfo(
			uint number = 1,
			uint size = int.MaxValue)
		{
			Number = number;
			Size = size;
		}
	}
}
