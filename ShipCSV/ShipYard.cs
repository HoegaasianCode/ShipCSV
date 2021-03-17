using System;
using System.Collections.Generic;
using System.Text;

namespace ShipCSV
{
    public class ShipYard
    {
        public string ShipId { get; set; }
        public string ShipName { get; set; }
        public string ShipOwnerName { get; set; }

        public ShipYard(string[] shipCsv)
        {
            ShipId = shipCsv[0];
            ShipName = shipCsv[1];
            ShipOwnerName = shipCsv[2];
        }

        public ShipYard(string shipId, string shipName, string shipOwnerName)
        {
            ShipId = shipId;
            ShipName = shipName;
            ShipOwnerName = shipOwnerName;
        }

        public Ship CreateShip()
        {
            return new Ship(ShipId, ShipName);
        }

        public Owner CreateOwner(Ship ship)
        {
            return new Owner(ShipOwnerName, ship);
        }
    }
}
