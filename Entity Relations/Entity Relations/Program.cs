namespace Entity_Relations
{
    internal class Program
    {
        static void Main(string[] args)
        {
            ApplicationContext context = new ApplicationContext();

            context.Database.EnsureDeleted();
            context.Database.EnsureCreated();
        }
    }
}