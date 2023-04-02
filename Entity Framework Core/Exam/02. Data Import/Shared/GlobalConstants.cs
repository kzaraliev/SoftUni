using System;
using System.Collections.Generic;
using System.Text;

namespace Boardgames.Shared
{
    public class GlobalConstants
    {
        //Boardgame
        public const int BoardgameNameMin = 10;
        public const int BoardgameNameMax = 20;
        public const double BoardgameRatingMin = 1;
        public const double BoardgameRatingMax = 10;
        public const int BoardgameYearPublishedMin = 2018;
        public const int BoardgameYearPublishedMax = 2023;

        //Seller
        public const int SellerNameMin = 5;
        public const int SellerNameMax = 20;
        public const int SellerAddressMin = 2;
        public const int SellerAddressMax = 30;
        public const string SellerWebsiteRegex = @"^www\.[A-Za-z0-9\-]*\.com$";

        //Creator
        public const int CreatorFirstNameMin = 2;
        public const int CreatorFirstNameMax = 7;
        public const int CreatorLastNameMin = 2;
        public const int CreatorLastNameMax = 7;
    }
}
