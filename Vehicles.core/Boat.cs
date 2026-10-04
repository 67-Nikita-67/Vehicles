namespace Vehicles.Core
{
    public class Boat : Vehicle
    {
        public Boat(string name) : base(name)
        {
        }

        public override string Move(double distance)
        {
            if (distance < 0)
                return "Distance cannot be negative.";

            Distance += distance;

            return $"{Name} sailed {distance} km on water. Total distance: {Distance} km.";
        }
    }
}