using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Threading;

namespace test
{
    
    class Program
    {
        static readonly List<string> triplet = new List<string>();
        static void Main(string[] args)
        {
            Stopwatch watch = new Stopwatch();
            watch.Start();
            string text = @"C:\Users\Radmila\Desktop\nordic-it-cs-q1\test task\тестовое задание\текст.txt";
            string[] masText = File.ReadAllLines(text);
            for (int i = 0; i < masText.Length; i++)
            {
                string[] mas = masText[i].Split(' ', '.', ',','!','?');
                for (int j = 0; j < mas.Length; j++)
                {
                    string words = mas[j].ToLower();
                    for (int z = 0; z < words.Length - 2; z++)
                    {
                        string letters = words.Substring(z, 3);
                        if (string.IsNullOrWhiteSpace(letters))
                        {
                            break;
                        }
                        else
                        {
                            triplet.Add(letters);
                        }
                    }
                }
                
            }
            Thread sort = new Thread(new ThreadStart(sortAndOutput));
            sort.Start();
            sort.Join();
            watch.Stop();
            Console.WriteLine($"Time is {watch.ElapsedMilliseconds} ms");
            Console.ReadKey();
        }
        public static void sortAndOutput()
        {
            var result = from n in triplet
                      group n by n into g
                      let count = g.Count()
                      orderby count descending
                      select new
                      {
                          Letter = g.Key,
                          Count = count
                      };
            foreach (var item in result.Take(10))
            {
                Console.WriteLine(item);
                if (Console.KeyAvailable)
                {
                    break;
                }
            }
            
        }
    }
}
