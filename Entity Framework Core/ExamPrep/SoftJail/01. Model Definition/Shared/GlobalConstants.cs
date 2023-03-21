namespace Footballers.Shared
{
    public static class GlobalConstants
    {
        //Prisoner
        public const int PrisonerFullNameMinLength = 3;
        public const int PrisonerFullNameMaxLength = 20;
        public const int PrisonerMinAge = 18;
        public const int PrisonerMaxAge = 65;
        public const string NicknameRegex = @"^(The\\s)([A-Z]{1}[a-z]*)$";


        //Officer
        public const int OfficerFullNameMaxLength = 30;

        //Cell
        public const int CellMaxNumber = 1000;

        //Department
        public const int DepartmentNameMaxLength = 25;
    }
}
