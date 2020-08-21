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
        public override void Go()
        {
            Console.WriteLine("{0} truck started",Color);
        }

        public void Load()
        {

        }

        public override void Stop()
        {
            Console.WriteLine("{0} truck stopped",Color);
        }

        public void Unload()
        {

        }
    }
}
