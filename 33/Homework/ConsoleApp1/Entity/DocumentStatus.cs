using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleApp1
{
    class DocumentStatus
    {
        public DocumentStatus()
        {

        }
        public DocumentStatus(Contractor sender, Contractor receiver, Document document, string status, DateTimeOffset dateTime)
        {
            Sender = sender;
            Receiver = receiver;
            Document = document;
            Status = status;
            DateTime = dateTime;
        }

        public int Id { get; private set; }
        public Contractor Sender { get; private set; }
        public Contractor Receiver { get; private set; }
        public Document Document { get; private set; }
        public string Status { get; private set; }
        public DateTimeOffset DateTime { get; private set; }
    }
}
