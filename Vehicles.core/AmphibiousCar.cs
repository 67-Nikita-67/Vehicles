namespace Vehicles.Core
{
    public class AmphibiousCar : Car
    {
        public AmphibiousCar(string name) : base(name)
        {
        }

        public override string Move(double distance)
        {
            if (distance < 0)
                return "Distance cannot be negative.";

            Distance += distance;

            return $"{Name} moved {distance} km on land or water. Total distance: {Distance} km.";
        }
    }
}