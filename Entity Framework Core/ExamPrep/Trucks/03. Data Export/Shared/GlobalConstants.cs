namespace Theatre.Shared
{
    public static class GlobalConstants
    {
        //Truck
        public const int RegistrationNumberLength = 8;
        public const int VinNumberLength = 17;
        public const int TankCapacityMin = 950;
        public const int TankCapacityMax = 1420;
        public const int CargoCapacityMin = 5000;
        public const int CargoCapacityMax = 29000;
        public const string regex = @"[A-Z]{2}[0-9]{4}[A-Z]{2}$";

        //Client
        public const int ClientNameMin = 3;
        public const int ClientNameMax = 40;
        public const int ClientNationalityMin = 2;
        public const int ClientNationalityMax = 40;

        //Despatcher
        public const int DespatcherNameMin = 2;
        public const int DespatcherNameMax = 40;
    }
}
