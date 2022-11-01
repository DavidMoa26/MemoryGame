using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exceptions
{
    internal class Garage : IGarage
    {
       string[]? carTypes;
       public Car[]? cars;

        public Garage(string[] carTypes)
        {
            this.carTypes = carTypes;
            cars = null;
        }

        public void AddCar(Car car)
        {
            if (cars == null)
            {
                cars = new Car[1];
                cars[0] = car;
            }
            else
            {
                CheckIfCarExists(car);
                CheckIfCarNull(car);
                CheckIfCarTotalLost(car);
                CheckIfCarInCarTypes(car);
                if (!CarNeedRepair(car))
                    throw new RepairMismatchException();
                AddNewCar(car);
            }

        }
        public void TakeOutCar(Car car)
        {
            CheckIfCarNull(car);
            CheckIfCarInGarage(car);
            if (CarNeedRepair(car))
                throw new CarNotReadyException();
            DeleteCar(car);
        }
        public void FixCar(Car car)
        {
            CheckIfCarNull(car);
            CheckIfCarInGarage(car);
            if (!CarNeedRepair(car))
                throw new RepairMismatchException();
            car.NeedsRepair = false;
        }



        public void CheckIfCarNull(Car car)
        {
            if (car == null)
                throw new CarNullException();
        }
        public void CheckIfCarTotalLost(Car car)
        {
            if (car.TotalLost == true)
                throw new WeDoNotFixTotalLostException();
        }
        public void CheckIfCarExists(Car car)
        {
            for (int i = 0; i < cars.Length; i++)
            {
                if (cars[i].Brand == car.Brand)
                    throw new CarAlreadyHereException();
            }
        }
        public void CheckIfCarInCarTypes(Car car)
        {
            int counter = 0;
            for (int i = 0; i < cars.Length; i++)
            {
                if (car.Brand != carTypes[i])
                    counter++;
                if (counter == cars.Length-1)
                    throw new WrongGarageException();

            }
        }
        public bool CarNeedRepair(Car car)
        {
            return car.NeedsRepair;
        }
        public void AddNewCar(Car car)
        {
            int size = cars.Length;
            Car[] help = new Car[++size];
            for (int i = 0; i < size - 1; i++)
            {
                help[i] = cars[i];
                help[size - 1] = car;
            }
            cars = help;
        }
        public void CheckIfCarInGarage(Car car)
        {
            int counter = 0;
            for (int i = 0; i < cars.Length; i++)
            {
                if (car.Brand != cars[i].Brand)
                    counter++;
            }
            if (counter == cars.Length)
                throw new CarNotInGarageException();
        }
        public void DeleteCar(Car car)
        {
            int size = cars.Length;
            Car[] help = new Car[--size];
            for (int i = 0,j=0; i < cars.Length; i++)
            {
                if (car.Brand != cars[i].Brand)
                {
                    help[j] = cars[i];
                    j++;
                }
            }
            cars = help;
        }
        public void PrintGarageCars()
        {
            for (int i = 0; i < cars.Length; i++)
            {
                Console.WriteLine(cars[i].Brand);
            }
        }
    }
}
