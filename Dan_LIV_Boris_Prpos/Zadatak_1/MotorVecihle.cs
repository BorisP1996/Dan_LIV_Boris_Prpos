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

        public abstract void Go();

        public abstract void Stop();
    }
}
