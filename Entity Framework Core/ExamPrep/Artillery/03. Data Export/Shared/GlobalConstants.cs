namespace Artillery.Shared
{
    public static class GlobalConstants
    {
        //Country
        public const int CountryNameMin = 4;
        public const int CountryNameMax = 60;
        public const int CountryArmyMin = 50000;
        public const int CountryArmyMax = 10000000;

        //Manufacturer
        public const int ManufacturerNameMin = 4;
        public const int ManufacturerNameMax = 40;
        public const int ManufacturerFoundedMin = 10;
        public const int ManufacturerFoundedMax = 100;

        //Shell
        public const int ShellWeightMin = 2;
        public const int ShellWeightMax = 1680;
        public const int ShellCaliberMin = 4;
        public const int ShellCaliberMax = 30;

        //Gun
        public const int GunWeightMin = 100;
        public const int GunWeightMax = 1350000;
        public const double GunBarrelMin = 2;
        public const double GunBarrelMax = 35;
        public const int GunRangeMin = 1;
        public const int GunRangeMax = 100000;
    }
}
