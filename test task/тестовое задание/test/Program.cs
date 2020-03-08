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
        static readonly List<string> Fred = new List<string>();
        static void Main(string[] args)
        {

            
            Stopwatch watch = new Stopwatch();
            watch.Start();
            
            string text = @"C:\Users\Андрей\Desktop\nordic-it-cs-q1\test task\тестовое задание\текст.txt";
            string[] line = File.ReadAllLines(text);
            
            for (int i = 0; i < line.Length; i++)
            {
                string[] mas = line[i].Split(' ', '.', ',','!','?');
                for (int j = 0; j < mas.Length; j++)
                {
                    string s = mas[j].ToLower();
                    for (int z = 0; z < s.Length - 2; z++)
                    {
                        string ss = s.Substring(z, 3);
                        Fred.Add(ss);
                        
                        
                    }
                }
                
            }
            watch.Stop();
            Console.WriteLine($"Time is {watch.ElapsedMilliseconds} ms");
            Thread myThread = new Thread(new ThreadStart(Order));
            myThread.Start();
            
        }
        public static void Order()
        {
            var res = from n in Fred
                      group n by n into g
                      let count = g.Count()
                      orderby count descending
                      select new
                      {
                          Letter = g.Key,
                          Count = count
                      };
            foreach (var item in res.Take(10))
            {
                
                Console.WriteLine(item);
            }
            
        }
    }
}
