using P01.Vehicles.Models;
using System;

namespace P01.Vehicles
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            string[] carInfo = Console.ReadLine().Split();
            Car car = MakeCar(carInfo);

            string[] truckInfo = Console.ReadLine().Split();
            Truck truck = MakeTruck(truckInfo);

            int count = int.Parse(Console.ReadLine());

            for (int i = 0; i < count; i++)
            {
                string[] commandInfo = Console.ReadLine().Split();
                string command = commandInfo[0];
                string vehicle = commandInfo[1];
                if (command.ToLower() == "drive")
                {
                    double kilometers = double.Parse(commandInfo[2]);
                    try
                    {
                        if (vehicle.ToLower() == "car")
                        {
                            car.Drive(kilometers);
                        }
                        else
                        {
                            truck.Drive(kilometers);
                        }

                    }
                    catch (Exception ex)
                    {

                        Console.WriteLine(ex.Message);
                        continue;
                    }
                }
                else
                {
                    double ammount = double.Parse(commandInfo[2]);
                    try
                    {
                        if (vehicle.ToLower() == "car")
                        {
                            car.Refuel(ammount);
                        }
                        else
                        {
                            truck.Refuel(ammount);
                        }
                    }
                    catch (Exception ex)
                    {

                        Console.WriteLine(ex.Message);
                        continue;
                    }

                }

            }

            Console.WriteLine(car);
            Console.WriteLine(truck);
        }

        private static Truck MakeTruck(string[] truckInfo)
        {
            double quantity = double.Parse(truckInfo[1]);
            double consumption = double.Parse(truckInfo[2]);
            Truck truck = new Truck(quantity, consumption);
            return truck;

        }

        private static Car MakeCar(string[] carInfo)
        {
            double quantity = double.Parse(carInfo[1]);
            double consumption = double.Parse(carInfo[2]);
            Car car = new Car(quantity, consumption);
            return car;
        }
    }
}
