using P02.VehicleExtension.Models;
using System;

namespace P02.VehicleExtension
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            string[] carInfo = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries);
            string[] truckInfo = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries);
            string[] busInfo = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries);
            Car car = MakeCar(carInfo);
            Truck truck = MakeTruck(truckInfo);
            Bus bus = MakeBus(busInfo);

            int count = int.Parse(Console.ReadLine());
            for (int i = 0; i < count; i++)
            {
                string[] commandInfo = Console.ReadLine()
                    .Split(" ", StringSplitOptions.RemoveEmptyEntries);
                string command = commandInfo[0];
                string vehicle = commandInfo[1];
                double parameter = double.Parse(commandInfo[2]);
                if (command == "DriveEmpty")
                {
                    try
                    {
                        bus.Drive(parameter);
                    }
                    catch (Exception ex)
                    {

                        Console.WriteLine(ex.Message);
                        continue;
                    }
                }
                else if (command == "Drive")
                {
                    try
                    {
                        if (vehicle == "Car")
                        {
                            car.Drive(parameter);
                        }
                        else if (vehicle == "Truck")
                        {
                            truck.Drive(parameter);
                        }
                        else
                        {
                            bus.DrivePeople(parameter);
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
                    try
                    {
                        if (vehicle == "Car")
                        {
                            car.Refuel(parameter);
                        }
                        else if (vehicle == "Truck")
                        {
                            truck.Refuel(parameter);
                        }
                        else
                        {
                            bus.Refuel(parameter);
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
            Console.WriteLine(bus);
        }

        private static Bus MakeBus(string[] busInfo)
        {
            double quantity = double.Parse(busInfo[1]);
            double consumption = double.Parse(busInfo[2]);
            double tankCapacity = double.Parse(busInfo[3]);
            Bus bus = new Bus(quantity, consumption, tankCapacity);
            return bus;
        }
        private static Truck MakeTruck(string[] truckInfo)
        {
            double quantity = double.Parse(truckInfo[1]);
            double consumption = double.Parse(truckInfo[2]);
            double tankCapacity = double.Parse(truckInfo[3]);
            Truck truck = new Truck(quantity, consumption, tankCapacity);
            return truck;

        }

        private static Car MakeCar(string[] carInfo)
        {
            double quantity = double.Parse(carInfo[1]);
            double consumption = double.Parse(carInfo[2]);
            double tankCapacity = double.Parse(carInfo[3]);
            Car car = new Car(quantity, consumption, tankCapacity);
            return car;
        }
    }
}
