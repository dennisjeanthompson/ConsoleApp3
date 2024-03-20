using Microsoft.VisualBasic;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics.Contracts;
using System.Security.Cryptography.X509Certificates;

namespace ConsoleApp3
{
    public class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello, World!");

           Customer car = new Customer("Jhon",092);

            Console.WriteLine("${car.Name}");
            
        }
    }


    public class Customer
    {
        private static int s_registratoinNumber = 100;
        public string Name { get; set; }
        public string RegisrationNumber { get; set; }//phone numebr
        public int Phone { get; set; }



        public Customer(string name, int phone)
        {
            Name = name;
            RegisrationNumber += s_registratoinNumber++.ToString();
            Phone = phone;
        }
        public void RentVehicle(Car vehicle)
        {
            vehicle.Rent();
            Console.WriteLine("CAR RENTED" + vehicle.DisplayDetails());
        }

        public void Return(Car car)//vehivle
        {
            car.Rent();
            Console.WriteLine("CAR returned" + car.DisplayDetails());
        }

       private class RentalSystem
        {

         public  List<Car> AvailableCars = new List<Car>();//{ get; set; }//change to vechiclee
          public  List<Car> RentedCars = new List<Car>(); //{ get; set; }//disadvantages if 

         

         public void AddCar(Car car)
            {
                AvailableCars.Add(car);
                RentedCars.Remove(car);
            }
            public void RentCAR(Car Car,Car Customer)
            {
                if(Car.IsAvailable)
                {
                    Customer.Rent();
                    RentedCars.Add(Car);


                }
                else
                {
                    Console.WriteLine(" NOT AVALIBLE");
                }
            }
            public void ReturnCar(Car car,Customer customer)
            {
                if(RentedCars.Contains(car))
                {
                    customer.ReturnCar(car);
                    RentedCars.Add(car);
                    RentedCars.Remove(car);
                    //remove
                    // customer.AvailableCars.Add(car);

                }
                else
                {
                   // Console.//
                }
            }
            public void DislayaVSILANBLE ()  
            {
                foreach(Car car in AvailableCars)
                {
                    Console.WriteLine($"{car.DisplayDetails()}");   
                }
            }
            public void DisplayrentedCARS()
            {
                foreach (Car car in AvailableCars)
                {
                    Console.WriteLine($"{car.DisplayDetails()}");
                }
            }

        }

        public class Car:Vehicle
        {
            public int numberdoors { get; set; }








            public Car(string registrationNumber, string make, string model, int year, double renTalPricepedday, bool ISAVAILABLE):base(registrationNumber,  make, model,  year,  renTalPricepedday, ISAVAILABLE)
            {
               // numberofdoors

              //  RegisrationNumber = registrationNumber;
               // Make = make;
               // Model = model;
               // Year = year;
               // RentalPriceDay = renTalPricepedday;
               // IsAvailable = ISAVAILABLE;
            }
            public override string Displaydetails()
            {return base.Displaydetails()


            }



            public void Rent()
            {
                IsAvailable = false;
            }

            public void Return()
            {
                IsAvailable = true;
            }
            public virtual string DisplayDetails()
            {
                return $"{Make}{Model}{Year}{RegisrationNumber}{RentalPriceDay}";
            }
        }
        public class Truck :Vehicle
        {
            double cargocapacitYTONS{ get; set; }

        }
        public class Vehicle
        {
            public string RegisrationNumber { get; set; }
            public string Make { get; set; }
            public string Model { get; set; }
            public int Year { get; set; }
            public double RentalPriceDay { get; set; }
            public bool IsAvailable { get; set; }

        }
        

    }
}
