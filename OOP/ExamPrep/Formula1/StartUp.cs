namespace Formula1
{
    using Formula1.Core;
    using Formula1.Core.Contracts;
    using Formula1.Models;

    public class StartUp
    {
        public static void Main()
        {
            IEngine engine = new Engine();
            engine.Run();
        }
    }
}
