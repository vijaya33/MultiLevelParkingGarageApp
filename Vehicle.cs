using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ParkingGarageApplication
{
    public class Vehicle
    {
        public string LicensePlate { get; private set; }
        public DateTime ParkedTime { get; private set; }

        public Vehicle(string licensePlate)
        {
            LicensePlate = licensePlate;
            ParkedTime = DateTime.Now; // Initializes the parked time to now
        }

        public void SetParkedTime(DateTime time)
        {
            ParkedTime = time;
        }
    }
}