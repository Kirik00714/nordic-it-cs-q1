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
            var liter = double.Parse(Console.ReadLine());
            double[] banka = new double[3];

            banka[2] = Math.Floor(liter / 20);
            
            if (banka[2] != 0)
            {
                liter -= banka[2] * 20;
                if (liter > 5)
                {
                    banka[1] = Math.Floor(liter / 5);

                    if (banka[1] != 0)
                    {
                        liter -= banka[1] * 5;
                        if (banka[0] != 0)
                        {
                            banka[0] = Math.Ceiling(liter);

                            Console.WriteLine("You will need the following containers");
                            for (int i = 0; i < value.Length; i++)
                            {
                                Console.WriteLine($"{value[i]}: {banka[i]} piece.");
                            }
                        }

                    }
                    else
                    {
                        Console.WriteLine("You will need the following containers");
                        Console.WriteLine($"{value[2]}: {banka[2]} piece.");
                        Console.WriteLine($"{value[1]}: {banka[1]} piece.");
                    }
                    
                }
                else
                {
                    banka[0] = Math.Ceiling(liter);
                    Console.WriteLine("You will need the following containers");
                    Console.WriteLine($"{value[2]}: {banka[2]} piece.");
                    Console.WriteLine($"{value[0]}: {banka[0]} piece.");
                }
            }
            else 
            {
                
                Console.WriteLine("You will need the following containers");
                Console.WriteLine($"{value[2]}: {banka[2]} piece."); 
            }
            
            
        }
    }
}
