using System;
using System.Text;
namespace ConsoleApp1
{
	class Program
	{
		static void Main(string[] args)
		{
            /*
			Console.WriteLine("enter two real numbers ti multiply them:");
			var x = double.Parse(Console.ReadLine());
			var y = double.Parse(Console.ReadLine());
			Console.WriteLine(x.ToString() + "*" +  y.ToString() + "=" + x*y);
			Console.WriteLine("{0:##.##} + {1:##.###} = {2:##.###}", x , y , x + y);
			Console.WriteLine($"{x:#.##} - {y:#.##} = {(x - y):#.##}");
			*/
            /*
			string text = "    lorem   ipsum   dolor      sit   amet  ";
			var words = text.Split(' ',StringSplitOptions.RemoveEmptyEntries);
			var result = new string[words.Length];
			for (int i = 0; i < result.Length; i++)
			{
				result[i] = words[i];
				if (i == 1)
				{
					result[i] = words[i].ToUpper();
				}
			}
            Console.WriteLine(string.Join(" ", result));

            var words1 = text.TrimEnd();
            int index = words1.LastIndexOf(' ');
            words1 = words1.Substring(0, index);
            words1 = words1.TrimEnd();
            Console.WriteLine(words1);
            Console.ReadKey();
            */

            
            var text = new StringBuilder ("    lorem   ipsum   dolor      sit   amet  ");
            text.Remove(0, 4);
            text.Remove(5, 2);
            text.Remove(11, 2);
            text.Remove(17, 5);
            text.Remove(21, 2);
            text.Remove(25, 0);
            text.Replace("ipsum", "IPSUM");
            Console.WriteLine(text.ToString());

            var str = text.Remove(21, 7);
            text.Replace("IPSUM", "ipsum");
            Console.WriteLine(str.ToString());
            Console.ReadKey();
			
		}
	}
}
