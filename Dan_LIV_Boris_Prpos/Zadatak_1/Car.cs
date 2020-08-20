using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Zadatak_1
{
    class Car : MotorVecihle
    {
        string Registration;
        int DorNumber;
        int Reservoir;
        string TransmisionType;
        string Manufacturer;
        int DriverLicenseNumber;

        public Car(string color)
        {
            Color = color;
        }
        public void Paint()
        {

        }

        public override void Go(MotorVecihle car)
        {
            Console.WriteLine("{0} car started",car.Color);
        }

        public override void Stop(MotorVecihle car)
        {
            Console.WriteLine("{0} car stopped",car.Color);
        }
    }
}
