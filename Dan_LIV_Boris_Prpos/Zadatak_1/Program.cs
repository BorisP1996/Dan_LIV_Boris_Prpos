﻿using System;
using System.Collections.Generic;
using System.Threading;

namespace Zadatak_1
{
    class Program
    {
        static CountdownEvent countDown = new CountdownEvent(6);
        static CountdownEvent countDown_gas_semaphore = new CountdownEvent(1);
        static CountdownEvent raceContinues= new CountdownEvent(1);
        static Random rnd = new Random();

        static readonly object locker = new object();

        static void Main(string[] args)
        {
            //create vecihles
            Car car1 = new Car("Blue");
            Car car2 = new Car("Red");
            car1.Registration = "000-PD-XX";
            car2.Registration = "111-PD-YY";
            Truck truck1 = new Truck("White");
            Truck truck2 = new Truck("Black");
            Tractor tractor1 = new Tractor("Green");
            Tractor tractor2 = new Tractor("Yellow");

            //create collections and add vehicles to them
            List<MotorVecihle> cars = new List<MotorVecihle>();
            List<MotorVecihle> trucks = new List<MotorVecihle>();
            List<MotorVecihle> tractors = new List<MotorVecihle>();

            cars.Add(car1);
            cars.Add(car2);
            trucks.Add(truck1);
            trucks.Add(truck2);
            tractors.Add(tractor1);
            tractors.Add(tractor2);

            //simulate 5 second countdown
            for (int i = 5; i >0; i--)
            {
                Console.WriteLine(i);
                Thread.Sleep(1000);
            }
            //every car from the list approached the start
            foreach (Car item in cars)
            {
                item.ApproachStart();
                //initialize full gas tank and consumption per second
                item.FuelLeft = 100;
                item.FuelSpentBySecond = rnd.Next(4, 10);
            }
            //creating orange golf =>by specification in task text
            Car car3 = new Car("Orange");
            car3.Manufacturer = "Golf";
            car3.Registration = "222-PD-ZZ";
            car3.FuelLeft = 100;
            car3.FuelSpentBySecond = rnd.Next(4, 10);
            car3.ApproachStart();

            //start threads that represent cars racing and start thread that represents semaphore
            Thread t1 = new Thread(() => car1.RaceMethod());
            Thread t2 = new Thread(() => car2.RaceMethod());
            Thread t3 = new Thread(() => car3.RaceMethod());
            Thread Green_Red = new Thread(() => Car.Sempaphore());

            Green_Red.Start();
            t1.Start();
            t2.Start();
            t3.Start();

            Console.ReadLine();

        }
    }
}
