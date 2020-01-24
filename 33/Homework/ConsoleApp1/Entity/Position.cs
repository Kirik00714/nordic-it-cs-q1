using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleApp1
{
    class Position
    {
        public Position()
        {

        }

        public Position(string name)
        {
            
            Name = name;
        }

        public int Id { get; private set; }
        public string Name { get; private set; }
        public ICollection<Contractor> Contractors { get; private set; }
    }
}
