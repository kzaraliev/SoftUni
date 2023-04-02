using System.Text;
using Boardgames.Data.Models;
using Boardgames.Data.Models.Enums;
using Boardgames.DataProcessor.ImportDto;
using Newtonsoft.Json;

namespace Boardgames.DataProcessor
{
    using System.ComponentModel.DataAnnotations;
    using Boardgames.Data;
   
    public class Deserializer
    {
        private const string ErrorMessage = "Invalid data!";

        private const string SuccessfullyImportedCreator
            = "Successfully imported creator – {0} {1} with {2} boardgames.";

        private const string SuccessfullyImportedSeller
            = "Successfully imported seller - {0} with {1} boardgames.";

        public static string ImportCreators(BoardgamesContext context, string xmlString)
        {
            StringBuilder sb = new StringBuilder();
            XmlHelper xmlHelper = new XmlHelper();
            List<Creator> validCreators = new List<Creator>();

            var creatorsDto = xmlHelper.Deserializer<ImportCreatorsDto[]>(xmlString, "Creators");

            foreach (var dto in creatorsDto)
            {
                if (!IsValid(dto))
                {
                    sb.AppendLine(ErrorMessage);
                    continue;
                }

                var creator = new Creator()
                {
                    FirstName = dto.FirstName,
                    LastName = dto.LastName,
                };

                foreach (var dtoBoardgame in dto.Boardgames)
                {
                    if (!IsValid(dtoBoardgame))
                    {
                        sb.AppendLine(ErrorMessage);
                        continue;
                    }

                    if (string.IsNullOrEmpty(dtoBoardgame.Name))
                    {
                        sb.AppendLine(ErrorMessage);
                        continue;
                    }

                    object categoryType;
                    bool isValidCategory =
                        Enum.TryParse(typeof(CategoryType), dtoBoardgame.CategoryType.ToString(), out categoryType);

                    if (!isValidCategory)
                    {
                        sb.AppendLine(ErrorMessage);
                        continue;
                    }

                    var boardgame = new Boardgame()
                    {
                        Name = dtoBoardgame.Name,
                        Rating = dtoBoardgame.Rating,
                        YearPublished = dtoBoardgame.YearPublished,
                        CategoryType = (CategoryType)categoryType,
                        Mechanics = dtoBoardgame.Mechanics
                    };

                    creator.Boardgames.Add(boardgame);
                }

                sb.AppendLine(string.Format(SuccessfullyImportedCreator, creator.FirstName, creator.LastName,
                    creator.Boardgames.Count));
                validCreators.Add(creator);
            }
            context.Creators.AddRange(validCreators);
            context.SaveChanges();

            return sb.ToString().TrimEnd();
        }

        public static string ImportSellers(BoardgamesContext context, string jsonString)
        {
            StringBuilder sb = new StringBuilder();
            List<Seller> validSellers = new List<Seller>();

            int[] validBoardgamesIds = context.Boardgames.Select(x => x.Id).ToArray();

            var sellersDto = JsonConvert.DeserializeObject<ImportSellersDto[]>(jsonString);

            foreach (var dto in sellersDto)
            {
                if (!IsValid(dto))
                {
                    sb.AppendLine(ErrorMessage);
                    continue;
                }

                if (string.IsNullOrEmpty(dto.Country))
                {
                    sb.AppendLine(ErrorMessage);
                    continue;
                }

                var seller = new Seller()
                {
                    Name = dto.Name,
                    Address = dto.Address,
                    Country = dto.Country,
                    Website = dto.Website
                };

                foreach (var dtoIds in dto.Boardgames.Distinct())
                {
                    if (!validBoardgamesIds.Contains(dtoIds))
                    {
                        sb.AppendLine(ErrorMessage);
                        continue;
                    }

                    var boardgame = new BoardgameSeller()
                    {
                        BoardgameId = dtoIds,
                        Seller = seller
                    };

                    seller.BoardgamesSellers.Add(boardgame);
                }

                sb.AppendLine(string.Format(SuccessfullyImportedSeller, seller.Name, seller.BoardgamesSellers.Count));
                validSellers.Add(seller);
            }
            context.Sellers.AddRange(validSellers);
            context.SaveChanges();

            return sb.ToString().TrimEnd();
        }

        private static bool IsValid(object dto)
        {
            var validationContext = new ValidationContext(dto);
            var validationResult = new List<ValidationResult>();

            return Validator.TryValidateObject(dto, validationContext, validationResult, true);
        }
    }
}
