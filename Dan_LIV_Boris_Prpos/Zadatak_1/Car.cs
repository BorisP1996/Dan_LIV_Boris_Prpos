using System;
using System.Diagnostics;
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
        /// <summary>
        /// Method that describes whole race
        /// </summary>
        public void RaceMethod()
        {
            Stopwatch stopwatch1 = new Stopwatch();
            Stopwatch stopwatch2 = new Stopwatch();
            Stopwatch stopwatch3 = new Stopwatch();

            //stopwatch for first 10 seconds
            stopwatch1.Start();

            while (stopwatch1.ElapsedMilliseconds<10000)
            {
                //if car has fuel left
                if (FuelLeft > 0)
                {
                    Thread.Sleep(1000);
                    Console.WriteLine("Car with registration {0} is going forward", Registration);
                    //fuel is decremented by consumption per second
                    FuelLeft = FuelLeft - FuelSpentBySecond;
                }
                //if car does not have anymore fuel it stops the race
                else
                {
                    Console.WriteLine("\tCar with registration {0} stopped-empty gas tank.",Registration);
                    return;
                }            
            }
            stopwatch1.Stop();

            Stop();
            //auto reset event = waiting on sempahore=>Look at Semaphore method
            _auto.WaitOne();

            //after semaphore race continues for 3 more seconds
            stopwatch2.Start();
            Go();
            while (stopwatch2.ElapsedMilliseconds<3000)
            {
                Thread.Sleep(1000);
                Console.WriteLine("Car with registration {0} is going forward", Registration);
                FuelLeft = FuelLeft - FuelSpentBySecond;
            }
            stopwatch2.Stop();

            //cars arive at the gas station=>they can only go one by one
            lock (locker)
            {
                if (FuelLeft<15)
                {
                    Console.WriteLine("\tCar with registration {0} stopped for gas",Registration);
                    Console.WriteLine("\tCar with registration {0} is leaving gas station with full gas tank",Registration);
                    FuelLeft = 100;
                }
            }


            //after gas station, race continues for 7 more seconds (if car has any fuel)
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
        /// <summary>
        /// For every 2 seconds light changes
        /// </summary>
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
