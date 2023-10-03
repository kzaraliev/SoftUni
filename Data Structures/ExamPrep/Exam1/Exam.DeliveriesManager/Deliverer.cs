namespace Exam.DeliveriesManager
{
    public class Deliverer
    {
        public Deliverer(string id, string name)
        {
            Id = id;
            Name = name;
        }

        public string Id { get; set; }

        public string Name { get; set; }
    }
}
