namespace Footballers.Shared
{
    public static class GlobalConstants
    {
        //Prisoner
        public const int PrisonerFullNameMinLength = 3;
        public const int PrisonerFullNameMaxLength = 20;
        public const int PrisonerMinAge = 18;
        public const int PrisonerMaxAge = 65;
        public const string PrisonerNicknameRegex = "^(The\\s)([A-Z]{1}[a-z]*)$";
        public const string PrisonerBailMinValue = "0.0";
        public const string PrisonerBailMaxValue = "79228162514264337593543950335";


        //Officer
        public const int OfficerFullNameMinLength = 3;
        public const int OfficerFullNameMaxLength = 30;
        public const string OfficerSalaryMinValue = "0.0";
        public const string OfficerSalaryMaxValue = "79228162514264337593543950335";

        //Cell
        public const int CellMinLength = 1;
        public const int CellMaxNumber = 1000;

        //Department
        public const int DepartmentNameMinLength = 3;
        public const int DepartmentNameMaxLength = 25;

        //Mail
        public const string MailAddressRegex = "^([A-Za-z0-9\\s]+?)(\\sstr\\.)$";
    }
}
