﻿using System;

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
        public override void Go()
        {
            Console.WriteLine("{0} tractor started",Color);
        }

        public override void Stop()
        {
            Console.WriteLine("{0} tractor stopped",Color);
        }
    }
}
