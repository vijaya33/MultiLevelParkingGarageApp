using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ParkingGarageApplication
{
    public class ParkingLevel
    {
        public int LevelNumber { get; }
        public List<ParkingSpot> Spots { get; private set; }

        public ParkingLevel(int levelNumber, int numberOfSpots)
        {
            LevelNumber = levelNumber;
            Spots = new List<ParkingSpot>();
            for (int i = 0; i < numberOfSpots; i++)
            {
                Spots.Add(new ParkingSpot());
            }
        }

        public ParkingSpot ParkVehicle(Vehicle vehicle)
        {
            foreach (var spot in Spots)
            {
                if (!spot.IsOccupied)
                {
                    spot.ParkVehicle(vehicle);
                    return spot;
                }
            }
            return null; // No available spots
        }

        public Vehicle RetrieveVehicle(string licensePlate)
        {
            foreach (var spot in Spots)
            {
                if (spot.IsOccupied && spot.Vehicle.LicensePlate == licensePlate)
                {
                    return spot.RetrieveVehicle();
                }
            }
            return null; // Vehicle not found
        }

        public int GetAvailableSpotsCount()
        {
            int count = 0;
            foreach (var spot in Spots)
            {
                if (!spot.IsOccupied)
                {
                    count++;
                }
            }
            return count;
        }

        public bool IsFull()
        {
            foreach (var spot in Spots)
            {
                if (!spot.IsOccupied)
                {
                    return false;
                }
            }
            return true;
        }

        public void DisplayAvailableSpots()
        {
            Console.WriteLine($"Level {LevelNumber} has {GetAvailableSpotsCount()} available spots.");
        }
    }

}