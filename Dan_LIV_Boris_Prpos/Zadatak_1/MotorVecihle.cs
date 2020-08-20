using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Zadatak_1
{
    public abstract class MotorVecihle
    {
        public double MotorVolume;
        public int Weight;
        public string Category;
        public string EngineType;
        public string Color;
        public int EngineNumber;

        public abstract void Go(MotorVecihle mv);

        public abstract void Stop(MotorVecihle mv);
    }
}
