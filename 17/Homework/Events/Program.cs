using System;
using System.IO;

namespace Events
{
    class Program
    {
        static void Main(string[] args)
        {
            var filewriterwithprogress = new FileWriterWithProgress();
            filewriterwithprogress.WritingPerformed += Filewriterwithprogress_WritingPerformed;
            filewriterwithprogress.WritingCompleted += Filewriterwithprogress_WritingCompleted;
            var data = new byte[10];
            new Random().NextBytes(data);
            filewriterwithprogress.WriteBytes("File.txt", data, 0.1f);
            Console.ReadKey();
        }

        private static void Filewriterwithprogress_WritingCompleted(object sender, EventArgs e)
        {
            Console.WriteLine("Generated");
        }

        private static void Filewriterwithprogress_WritingPerformed(object filewriterwithprogress, WorkPerformedEventArgs e)
        {
            Console.WriteLine($"Generate {e.percentage}%");
        }
    }
}
