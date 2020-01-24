using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleApp1
{
    class Contractor
    {
        public Contractor()
        {

        }
        public Contractor(string fullName, Address addressId, Position positionId)
        {
            AddressId = addressId;
            PositionId = positionId;
            FullName = fullName;

        }

        public int Id { get; private set; }
        public string FullName { get; private set; }
        public Address AddressId { get; private set; }
        public Position PositionId { get; private set; }

        public ICollection<DocumentStatus> DocumentsSender { get; private set; }
        public ICollection<DocumentStatus> DocumentsReceiver { get; private set; }
    }
}
