using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;

namespace ConsoleApp1
{
    class Program
    {
        static void Main(string[] args)
        {
            var city = new City("Москва");
            var positionSender = new Position("Директор");
            var positionReceiver = new Position("Зам.Ректора");
            var addressSender = new Address(city, "Москва, ул. Б.Пироговская, д.21");
            var addressReceiver = new Address(city, "Москва, ул. Косыгина, д.30");
            var document = new Document("Книга", "Война и Мир т.1 ", 666);
            var contractorSender = new Contractor("Иванов Иван Иванович", addressSender, positionSender);
            var contractorReceiver = new Contractor("Петров Петр Петрович", addressReceiver, positionReceiver);
            var documentStatus = new DocumentStatus(contractorSender, contractorReceiver, document, "Доставлено", DateTimeOffset.UtcNow);
            
            using var context = new OnlineStoreContext();
            context.Database.EnsureCreated();

            context.DocumentStatuss.Add(documentStatus);
            context.SaveChanges();
            Console.WriteLine("Completed");

            var documentStatuss = context.DocumentStatuss
                .Include(_ => _.Receiver)
                .ThenInclude(line => line.DocumentsReceiver)
                .ToList();
            foreach (var item in documentStatuss)
            {
                Console.WriteLine(item);
            }
            
        }
    }
}
