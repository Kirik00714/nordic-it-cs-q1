﻿using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleApp1
{
    class Address
    {
        public Address()
        {

        }

        public Address(City cityId, string addressName)
        {
            CityName = cityId;
            AddressName = addressName;
            
        }

        public int Id { get; private set; }
        public City CityName { get; private set; }
        public string AddressName { get; private set; }
        
        public ICollection<Contractor> Contractors { get; private set; }
    }
}
