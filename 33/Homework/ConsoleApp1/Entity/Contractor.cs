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
            AddressName = addressId;
            PositionName = positionId;
            Name = fullName;

        }

        public int Id { get; private set; }
        public string Name { get; private set; }
        public Address AddressName { get; private set; }
        public Position PositionName { get; private set; }

        public ICollection<DocumentStatus> DocumentsSender { get; private set; }
        public ICollection<DocumentStatus> DocumentsReceiver { get; private set; }
    }
}
