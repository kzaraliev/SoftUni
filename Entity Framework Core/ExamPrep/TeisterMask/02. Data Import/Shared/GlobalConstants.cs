namespace Theatre.Shared
{
    public static class GlobalConstants
    {
        //Employee
        public const int EmployeeUsernameMin = 3;
        public const int EmployeeUsernameMax = 40;
        public const string EmployeeUsernameRegex = @"^[A-Za-z0-9]{3,}$";
        public const string EmployeePhoneRegex = @"^[0-9]{3}\-[0-9]{3}\-[0-9]{4}$";

        //Project
        public const int ProjectNameMin = 2;
        public const int ProjectNameMax = 40;

        //Task
        public const int TaskNameMin = 2;
        public const int TaskNameMax = 40;
    }
}
