using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Zadatak_1
{
    class Truck : MotorVecihle
    {
        double LoadCapacity;
        double Height;
        int SeatNumber;

        public Truck(string color)
        {
            Color = color;
        }
        public override void Go(MotorVecihle Truck)
        {
            Console.WriteLine("{0} truck started",Truck.Color);
        }

        public void Load()
        {

        }

        public override void Stop(MotorVecihle Truck)
        {
            Console.WriteLine("{0} truck stopped",Truck.Color);
        }

        public void Unload()
        {

        }
    }
}
