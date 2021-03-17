using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace ShipCSV
{
    public class Owner
    {
        public string Name;
        public int ShipCount;
        public Ship Ship;
        public Ship SecondShip;
        public static List<Owner> Owners = new List<Owner>();

        public Owner(string ownerName, Ship ship)
        {
            Name = ownerName;
            Ship = ship;
            Owners.Add(this);
            ShipCount = 0;
        }

        public Owner CountShipsPerOwner()
        {
            foreach (var owner in Owners)
            {
                if (owner.Name == Name) ShipCount++;
            }
            return this;
        }

        public void AddOwner()
        {
            Owners.Add(this);
        }

        public void RemoveOwner()
        {
            Owners.Remove(this);
        }

        public Ship AddSecondShip()
        {
            foreach (var owner in Owners)
            {
                if (Name == owner.Name)
                {
                    SecondShip = owner.Ship;
                }
            }
            return SecondShip;
        }
    }
}
