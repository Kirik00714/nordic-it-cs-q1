using System;

namespace ConsoleApp2
{
    [Flags]
    enum Cask : byte
    {
        oneliter= 0x1,
        fiveliter = 0x1 << 1,
        twentyliters = 0x1 << 2,
    }
    class Program
    {
        
        static void Main(string[] args)
        {
            
            var value = (Cask[])Enum.GetValues(typeof(Cask));

            Console.WriteLine("How match juice is required to pach?");
            var inputValue = double.Parse(Console.ReadLine());
            double[] caskSize = new double[3];

            caskSize[2] = Math.Floor(inputValue / 20);
            
            if (caskSize[2] != 0)
            {
                inputValue -= caskSize[2] * 20;
  
            }
           
            caskSize[1] = Math.Floor(inputValue / 5);

            if (caskSize[1] != 0)
            {
                inputValue -= caskSize[1] * 5;
            }
            
             caskSize[0] = Math.Ceiling(inputValue);
            

            Console.WriteLine("You will need the following containers");
                for (int i = 0; i < value.Length; i++)
                {
                    if( caskSize[i] > 0)
                    {
                    Console.WriteLine($"{value[i]}: {caskSize[i]} piece.");
                    }
                   
                }
            



        }
    }
}
