namespace CodeSmells
{
    internal class Car
    {
        public string GetCylinderSize()
        {
            return GetEngine().GetCylinder().GetSize();
        }

        public Engine GetEngine()
        {
            return new Engine();
        }
    }
}
