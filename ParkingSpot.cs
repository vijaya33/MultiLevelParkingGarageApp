using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ParkingGarageApplication
{
    public class ParkingSpot
    {
        public Vehicle Vehicle { get; private set; }
        public bool IsOccupied => Vehicle != null;

        public void ParkVehicle(Vehicle vehicle)
        {
            Vehicle = vehicle;
        }

        public Vehicle RetrieveVehicle()
        {
            var tempVehicle = Vehicle;
            Vehicle = null;
            return tempVehicle;
        }
    }
}