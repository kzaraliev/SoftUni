namespace Theatre.Shared
{
    public static class GlobalConstants
    {
        //Theatre 
        public const int TheatreNameMinLength = 4;
        public const int TheatreNameMaxLength = 30;
        public const int TheatreDirectorMinLength = 4;
        public const int TheatreDirectorMaxLength = 30;

        //Play
        public const int PlayTitleMinLength = 4;
        public const int PlayTitleMaxLength = 50;
        public const int PlayDurationMinLength = 1;
        public const int PlayDescriptionMaxLength = 700;
        public const int PlayScreenWriterMinLength = 4;
        public const int PlayScreenWriterMaxLength = 30;

        //Cast
        public const int CastFullNameMinLength = 4;
        public const int CastFullNameMaxLength = 30;
        public const string CastRegex = @"^\+44-(\d{2})-(\d{3})-(\d{4})$";

    }
}
