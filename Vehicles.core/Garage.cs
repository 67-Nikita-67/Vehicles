using System;
using System.Collections.Generic;
using System.Linq;

namespace Vehicles.Core
{
    public class Garage
    {
        private readonly List<Vehicle> vehicles = new();

        public string Name { get; }

        public event Action<string>? LogMessage;

        public Garage(string name)
        {
            Name = name;
        }

        public List<Vehicle> GetVehicles()
        {
            return vehicles.ToList();
        }

        public void AddVehicle(Vehicle vehicle)
        {
            foreach (Vehicle other in vehicles)
            {
                LogMessage?.Invoke(
                    $"[{Name}] {other.Name} honks to welcome {vehicle.Name}!");
            }

            vehicles.Add(vehicle);

            LogMessage?.Invoke(
                $"[{Name}] Added: {vehicle.Name} ({vehicle.GetType().Name})");
        }

        public void RemoveVehicle(Vehicle vehicle)
        {
            if (!vehicles.Remove(vehicle))
                return;

            LogMessage?.Invoke(
                $"[{Name}] Removed: {vehicle.Name}");

            foreach (Vehicle other in vehicles)
            {
                LogMessage?.Invoke(
                    $"[{Name}] {other.Name} flashes its lights!");
            }
        }
    }
}
