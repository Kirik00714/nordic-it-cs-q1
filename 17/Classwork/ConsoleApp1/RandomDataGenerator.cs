using System;

namespace ConsoleApp1
{
	class RandomDataGenerator
	{
		
		public event EventHandler<RDG> RandomDataGenerating;
		public event EventHandler RandomDataGenerated;

		public byte[] GetRandomData (int dataSize, int byteDoneToRaiseEvent)
		{
			var rdm = new Random();
				int value = rdm.Next();
			if (dataSize < 0)
			{
				throw new ArgumentOutOfRangeException(nameof(dataSize));
			}

			if (byteDoneToRaiseEvent < 0)
			{
				throw new ArgumentOutOfRangeException(nameof(byteDoneToRaiseEvent));
			}

			var array = new byte[dataSize];
			for (int i = 0; i < array.Length; i++)
			{
				array[i] = (byte)rdm.Next();
				if (i % byteDoneToRaiseEvent == 0)
				{
					RandomDataGenerating?.Invoke(this, new RDG(i +1,dataSize));
				}

				
			}
			RandomDataGenerated?.Invoke(this, null);
			return array;
		}

	}
}
