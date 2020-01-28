using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleApp1
{
    class City
    {
        public City()
        {

        }

        public City( string name)
        {
            
            
            FullName = name;
        }

        public int Id { get; private set; }
        
        public string FullName { get; private set; }
        public ICollection<Address> Addresss { get; private set; }
    }
}
