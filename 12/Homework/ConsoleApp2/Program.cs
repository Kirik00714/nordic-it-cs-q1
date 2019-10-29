using System;

namespace ConsoleApp2
{
    class Program
    {
        static void Main(string[] args)
        {
            var Documents = new BaseDocument[3];
            Documents[0] = new BaseDocument("Pass", "489-589-65-68",new DateTime(2019, 10, 29, 9, 00, 00));
            Documents[1] = new Passport("USA", "Kirill",new DateTime(2012, 03, 15, 10, 30, 00), "489-563");
            Documents[2] = new Passport("Norway", "Mark", new DateTime(2015, 06, 28, 14, 26, 00), "064-088");

            for (int i = 0; i < Documents.Length; i++)
            {
                if (Documents[i] is Passport passport)
                {
                    passport.ChangeIssueDate(DateTime.Now);
                    Documents[i].IssueDate = passport.IssueDate;
                }
                Documents[i].WriteToConsole();
                Console.WriteLine("");
            }
            Console.WriteLine("Press any key to exit...");
            Console.ReadKey();
        }
    }
}
