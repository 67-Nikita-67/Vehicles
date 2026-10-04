namespace Vehicles.Core
{
    public class Car : Vehicle
    {
        public Car(string name) : base(name)
        {
        }

        public override string Move(double distance)
        {
            if (distance < 0)
                return "Distance cannot be negative.";

            Distance += distance;

            return $"{Name} drove {distance} km by road. Total distance: {Distance} km.";
        }
    }
}