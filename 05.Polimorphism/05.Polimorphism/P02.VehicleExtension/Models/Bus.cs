namespace P02.VehicleExtension.Models
{
    public class Bus : Vehicle
    {
        public Bus(double fuelQuantity, double fuelConsumption, double tankCapacity) 
            : base(fuelQuantity, fuelConsumption, tankCapacity)
        {

        }

        public void DrivePeople(double kilometers)
        {
            double originalConsumption = this.FuelConsumption;
            this.FuelConsumption += 1.4;
            Drive(kilometers);
            this.FuelConsumption = originalConsumption;
        }
    }
}
