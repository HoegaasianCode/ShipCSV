using System;
using System.Collections.Generic;
using System.Text;

namespace ShipCSV
{
    public class Ship
    {
        public string Id;
        public string Name;
        public Owner Owner;

        public Ship(string shipId, string shipName)
        {
            Id = shipId;
            Name = shipName;
           
        }
    }
}
