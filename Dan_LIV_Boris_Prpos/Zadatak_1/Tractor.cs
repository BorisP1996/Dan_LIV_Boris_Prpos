using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Zadatak_1
{
    class Tractor : MotorVecihle
    {
        double TireSize;
        int ShaftSpacing;
        string Drive;

        public Tractor(string col)
        {
            Color = col;
        }
        public override void Go(MotorVecihle tractor)
        {
            Console.WriteLine("{0} tractor started",tractor.Color);
        }

        public override void Stop(MotorVecihle tractor)
        {
            Console.WriteLine("{0} tractor stopped",tractor.Color);
        }
    }
}
