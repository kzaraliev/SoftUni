namespace Entity_Relations.Models;

public class Address
{
    public int Id { get; set; }
    public string Name { get; set; }

    public int StudentId { get; set; }
    public Student Student { get; set; }
}