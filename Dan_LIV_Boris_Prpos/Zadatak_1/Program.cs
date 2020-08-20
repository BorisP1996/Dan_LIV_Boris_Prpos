using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Zadatak_1
{
    class Program
    {
        static CountdownEvent countDown= new CountdownEvent(6);

        static void Main(string[] args)
        {
            Car car1 = new Car("Blue");
            Car car2 = new Car("Red");
            Truck truck1 = new Truck("White");
            Truck truck2 = new Truck("Black");
            Tractor tractor1 = new Tractor("Green");
            Tractor tractor2 = new Tractor("Yellow");

            List<MotorVecihle> cars = new List<MotorVecihle>();
            List<MotorVecihle> trucks = new List<MotorVecihle>();
            List<MotorVecihle> tractors = new List<MotorVecihle>();

            cars.Add(car1);
            cars.Add(car2);
            trucks.Add(truck1);
            trucks.Add(truck2);
            tractors.Add(tractor1);
            tractors.Add(tractor2);

            Console.WriteLine("5 second countdown starts...\n");

            //System.Timers.Timer aTimer = new System.Timers.Timer();
            //aTimer.Interval = 5000;
            //aTimer.Elapsed += OnTimedEvent;
            //aTimer.Enabled = true;
            //aTimer.AutoReset = false;

            int count = 5;
            while (count != 0)
            {
                Console.WriteLine(count);
                count--;
                Thread.Sleep(1000);
            }


            Console.WriteLine("All cars are ready to go!");
            Console.WriteLine("\nWaiting for orange golf to join...\n");
            Thread.Sleep(1000);

            for (int i = 0; i < cars.Count; i++)
            {
                int temp = i;
                Thread t = new Thread(() => cars[temp].Go(cars[temp]));
                t.Start();
                countDown.Signal();
            }
            for (int i = 0; i < trucks.Count; i++)
            {
                int temp = i;
                Thread t = new Thread(() => trucks[temp].Go(trucks[temp]));
                t.Start();
                countDown.Signal();
            }
            for (int i = 0; i < tractors.Count; i++)
            {
                int temp = i;
                Thread t = new Thread(() => tractors[temp].Go(tractors[temp]));
                t.Start();
                countDown.Signal();
            }      

            if (countDown.IsSet)
            {
                Thread.Sleep(100);
                
                System.Timers.Timer golfTimer = new System.Timers.Timer();
                golfTimer.Interval = 100;
                golfTimer.Elapsed += OrangeGolf;
                golfTimer.Enabled = true;
                golfTimer.AutoReset = false;
            }


            

            Console.ReadKey();

        }

        private static void OnTimedEvent(Object source,System.Timers.ElapsedEventArgs e)
        {
            Console.WriteLine("\nRace started!");
        }

        private static void OrangeGolf(Object source,System.Timers.ElapsedEventArgs e)
        {
            Car OrangeGolf = new Car("Orange golf joined and");
            Thread orange = new Thread(() => OrangeGolf.Go(OrangeGolf));
            orange.Start();
        }
    }
}
