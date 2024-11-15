namespace Adapter
{
    public class Teenager
    {
        public int Age { get; }

        public Teenager(int age)
        {
            Age = age;
        }

        public bool IsTeenager()
        {
            return Age < 18;
        }
    }
}
