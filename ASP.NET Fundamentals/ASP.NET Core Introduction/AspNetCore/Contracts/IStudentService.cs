using AspNetCore.Models;

namespace AspNetCore.Contracts
{
    public interface IStudentService
    {
        Student GetStudent(int id);

        bool UpdateStudent(Student student);
    }
}
