﻿using System;

namespace ConsoleApp1
{
    class Program
    {
        [Flags]
        enum Color : int
        {
            Black = 1,
            Blue = 2,
            Cyan = 4,
            Grey = 8,
            Green = 16,
            Magenta = 32,
            Red = 64,
            White = 128,
            Yellow = 256
        };
        static void Main(string[] args)
        {
            foreach ( var value in Enum.GetValues(typeof (Color)))
            {
                
                Console.WriteLine("{0,-9}  {1}", ((Color) value) + ":", (int) value);
            }

            Console.WriteLine($"Choose 4 colors to add  to the <Favorites>!");
             Color Favorite = 0;
            for (int i = 0; i < 4; i++)
            {
                Favorite |= (Color)int.Parse(Console.ReadLine());
                Console.WriteLine($"{ i + 1 } Color: {Favorite}");
            }
            Color NoFavorite = 0;
            for (int i = 0; i < 9; i++)
            {
                double num = Math.Pow(2, i);
                if ((Favorite & (Color)num) != (Color)num)
                {
                    NoFavorite |= (Color)num; 
                }
            }



            Console.WriteLine($"Favorite color :{Favorite}");
            Console.WriteLine($"No favorite color :{NoFavorite}");


        }
    }
}
