using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

namespace Zadatak_1
{

    class Car : MotorVecihle
    {
        static AutoResetEvent _auto = new AutoResetEvent(false);
        static readonly object locker = new object();
        static Random rnd = new Random();

       public string Registration;
       public int DorNumber;
       public int Reservoir;
       public string TransmisionType;
       public string Manufacturer;
       public  int DriverLicenseNumber;

        public int FuelSpentBySecond;
        public int FuelLeft;

        public Car(string color)
        {
            Color = color;
        }
        public void Paint()
        {
            Color = "New color";
            DriverLicenseNumber = rnd.Next(1000, 10000);
        }

        public override void Go()
        {
            Console.WriteLine("\t\tCar with registration: {0} has started",Registration);
        }

        public override void Stop()
        {
            Console.WriteLine("\t\tCar with registration: {0} has stopped on semaphore",Registration);
        }

        public void ApproachStart()
        {
            if (Color.Equals("Orange"))
            {
                Console.WriteLine("\t\t Car with registration: {0} - (orange golf) approached the start", Registration);
            }
            else
            {
                Console.WriteLine("\t\t Car with registration: {0} approached the start", Registration);
            }
        }

        public void RaceMethod()
        {
            Stopwatch stopwatch1 = new Stopwatch();
            Stopwatch stopwatch2 = new Stopwatch();
            Stopwatch stopwatch3 = new Stopwatch();

            stopwatch1.Start();

            while (stopwatch1.ElapsedMilliseconds<10000)
            {
                if (FuelLeft > 0)
                {
                    Thread.Sleep(1000);
                    Console.WriteLine("Car with registration {0} is going forward", Registration);
                    FuelLeft = FuelLeft - FuelSpentBySecond;
                }
                else
                {
                    Console.WriteLine("\tCar with registration {0} stopped-empty gas tank.",Registration);
                    return;
                }            
            }
            stopwatch1.Stop();

            Stop();

            _auto.WaitOne();

            stopwatch2.Start();
            Go();
            while (stopwatch2.ElapsedMilliseconds<3000)
            {
                Thread.Sleep(1000);
                Console.WriteLine("Car with registration {0} is going forward", Registration);
                FuelLeft = FuelLeft - FuelSpentBySecond;
            }
            stopwatch2.Stop();

            lock (locker)
            {
                if (FuelLeft<15)
                {
                    Console.WriteLine("\tCar with registration {0} stopped for gas",Registration);
                    Console.WriteLine("\tCar with registration {0} is leaving gas station with full gas tank",Registration);
                    FuelLeft = 100;
                }
            }

            stopwatch3.Start();
            while (stopwatch3.ElapsedMilliseconds < 7000)
            {
                if (FuelLeft > 0)
                {
                    Thread.Sleep(1000);
                    Console.WriteLine("Car with regisration {0} is going forward", Registration);
                    FuelLeft = FuelLeft - FuelSpentBySecond;
                }
                else
                {
                    Console.WriteLine("\tCar with registration {0} stopped-empty gas tank.", Registration);
                    return;
                }
            }
            stopwatch3.Stop();

            Console.WriteLine("\n\t Car with registration {0} has finsihed the race!\n", Registration);

        }

        public static void Sempaphore()
        {
            Stopwatch stopwatch4 = new Stopwatch();
            stopwatch4.Start();
            while (stopwatch4.ElapsedMilliseconds<100000)
            {
                if (stopwatch4.ElapsedMilliseconds%2000==0)
                {
                    _auto.Set();
                }
                else
                {
                    _auto.Reset();
                }
            }
        }

        


    

        

        
    }
}
