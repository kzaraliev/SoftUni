using P01_StudentSystem.Data;

namespace P01_StudentSystem;
public class StartUp
{
    static void Main(string[] args)
    {
        StudentSystemContext context = new StudentSystemContext();

        context.Database.EnsureDeleted();
        context.Database.EnsureCreated();
    }
}