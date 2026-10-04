namespace Vehicles.Core
{
    public class Vehicle
    {
        public string Name { get; set; }
        public double Distance { get; protected set; }

        public Vehicle(string name)
        {
            if (string.IsNullOrWhiteSpace(name))
                throw new ArgumentException("Name cannot be empty.");

            Name = name;
            Distance = 0;
        }

        public virtual string Move(double distance)
        {
            if (distance < 0)
                return "Distance cannot be negative.";

            Distance += distance;

            return $"{Name} moved {distance} km. Total distance: {Distance} km.";
        }
    }
}