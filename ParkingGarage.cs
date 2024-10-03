using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ParkingGarageApplication
{
    public class ParkingGarage
    {
        public List<ParkingLevel> Levels { get; private set; }
        public decimal HourlyRate { get; private set; }

        public ParkingGarage(int numberOfLevels, int spotsPerLevel, decimal hourlyRate)
        {
            Levels = new List<ParkingLevel>();
            HourlyRate = hourlyRate;
            for (int i = 0; i < numberOfLevels; i++)
            {
                Levels.Add(new ParkingLevel(i + 1, spotsPerLevel));
            }
        }

        public ParkingSpot ParkVehicle(Vehicle vehicle)
        {
            foreach (var level in Levels)
            {
                if (!level.IsFull())
                {
                    return level.ParkVehicle(vehicle);
                }
            }
            return null; // Garage is full
        }

        public Vehicle RetrieveVehicle(string licensePlate)
        {
          //  var vehicle = new Vehicle();

            foreach (var level in Levels)
            {
                var vehicle = level.RetrieveVehicle(licensePlate);
                if (vehicle != null)
                {
                    // Calculate payment
                    TimeSpan parkingDuration = DateTime.Now - vehicle.ParkedTime;
                    decimal payment = (decimal)parkingDuration.TotalHours * HourlyRate;
                    Console.WriteLine($"Vehicle {vehicle.LicensePlate} retrieved. Total payment: ${payment}");
                    return vehicle;

                }
                else
                {

                }

            }
            return null;

        }
    }
}

