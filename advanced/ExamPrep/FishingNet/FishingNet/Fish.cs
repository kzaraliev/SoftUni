namespace FishingNet
{
    public class Fish
    {
        public Fish(string fishType, double length, double weight)
        {
            FishType = fishType;
            Lenght = length;
            Weight = weight;
        }
        private string fishType;

        public string FishType
        {
            get { return fishType; }
            set { fishType = value; }
        }

        private double lenght;

        public double Lenght
        {
            get { return lenght; }
            set { lenght = value; }
        }

        private double weight;

        public double Weight
        {
            get { return weight; }
            set { weight = value; }
        }

        public override string ToString()
        {
            return $"There is a {FishType}, {Lenght} cm. long, and {Weight} gr. in weight.";
        }
    }
}
