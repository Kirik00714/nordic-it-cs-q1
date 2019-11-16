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
            var rdm = new Random();
            var data = new byte[10];
            for (int i = 0; i < data.Length; i++)
            {
                data[i] = (byte)rdm.Next();
                File.AppendAllText("File.txt", data[i].ToString());
            }
            filewriterwithprogress.WriteBytes("File.txt", data, 0.25f);
            Console.ReadKey();
        }

        private static void Filewriterwithprogress_WritingCompleted(object sender, EventArgs e)
        {
            Console.WriteLine("generated");
        }

        private static void Filewriterwithprogress_WritingPerformed(object filewriterwithprogress, FWWP e)
        {
            Console.WriteLine($"Generate {e.pTFE}%");
        }
    }
}
