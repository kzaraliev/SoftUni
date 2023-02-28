namespace P02_FootballBetting.Data.Common;
public static class ValidationConstants
{
    //Team
    public const int TeamNameMaxLength = 50;
    public const int TeamLogoUrlMaxLength = 2048;
    public const int TeamInitialsMaxLength = 4;

    //Color
    public const int ColorNameMaxLength = 10;

    //Town
    public const int TownNameMaxLength = 58;

    //Country
    public const int CountryNameMaxLength = 56;

    //Player
    public const int PlayerNameMaxLength = 50;

    //Position
    public const int PositionNameMaxLength = 30;

    //Game
    public const int GameResultMaxLength = 7;

    //User
    public const int UsernameMaxLength = 50;
    public const int UserPasswordLength = 256;
    public const int UserEmailMaxLength = 256;
    public const int NameMaxLength = 50;
}