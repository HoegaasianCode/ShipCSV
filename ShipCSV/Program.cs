using System;
using System.IO;    
using System.Linq;
using System.Collections.Generic;

namespace ShipCSV
{
    public class Program
    {
        /// <summary>
        /// This assignment involves dynamically reading and handling data from a file, in order to sort out which of the owners
        /// own more than one ship, including the names of these ships. See ShipTest1.txt for more info.
        /// A part of the challenge is avoiding LINQ-expressions (Groupby would be suitable here), and practicing 
        /// the formulation of a sorting algorithm. I formulated the algorithm from my own head, and as this was my first doing so..
        /// I suspect it can be improved quite a bit.
        /// </summary>
        /// <param name="args"></param>
        public static void Main(string[] args)
        {
            var ships = new List<Ship>();
            using (var sr = new StreamReader("ShipTest1.txt"))
            {
                while (true)
                {
                    var line = sr.ReadLine();
                    if (line == null) break;
                    var row = line.Split(',');
                    var shipYard = new ShipYard(row);
                    var ship = shipYard.CreateShip();
                    var owner = shipYard.CreateOwner(ship);
                    var countedOwner = owner.CountShipsPerOwner();
                    ship.Owner = countedOwner; //two-way object reference set for print/WriteLine
                    if (countedOwner.ShipCount == 2) // when there're two instances in Owners:
                    {
                        ships.Add(countedOwner.Ship); //add current/first ship instance
                        countedOwner.RemoveOwner(); //remove to isolate remaining instance
                        var secondShip = countedOwner.AddSecondShip();
                        ships.Add(secondShip); //adds remaining ship
                        countedOwner.AddOwner(); //re-adds owner to maintain count/algorithm
                    }
                    if (countedOwner.ShipCount > 2) ships.Add(countedOwner.Ship);
                    // more than two instances means the owner has been treated, and can be added directly,
                    // bypassing the steps above which are designed for handling the first occurance of serial-ownership
                }
            }

            foreach (var ship in ships)
            {
                //if (ship == null) continue;
                Console.WriteLine($"{ship.Id } {ship.Name} {ship.Owner.Name} {ship.Owner.ShipCount}");
            }
        }
    }
}
