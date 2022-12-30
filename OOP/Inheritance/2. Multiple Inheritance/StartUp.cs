using System;

namespace Farm
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            Puppy puppy = new Puppy();
            puppy.Bark();
            puppy.Eat();
            puppy.Weep();
        }
    }
}
