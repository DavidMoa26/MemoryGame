using System;

namespace Exceptions
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string[] carsTypes = { "Suzuki", "Kia", "B.M.W", "Toyota" };
            Car c1 = new Car("Suzuki", false, true);
            Car c2 = new Car("Kia", false, true);
            Car c3 = new Car("B.M.W", false, true);
            Car c4 = new Car("Toyota", false, true);

            Garage G = new Garage(carsTypes);
            G.AddCar(c1);
            G.AddCar(c2);
            G.PrintGarageCars();
            G.FixCar(c1);
            G.TakeOutCar(c1);
            G.PrintGarageCars();
            




        }
    }
}