using System.Text;
using Newtonsoft.Json;
using Theatre.Data.Models;
using Theatre.Data.Models.Enums;
using Theatre.DataProcessor.ImportDto;

namespace Theatre.DataProcessor
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.Globalization;
    using Theatre.Data;

    public class Deserializer
    {
        private const string ErrorMessage = "Invalid data!";

        private const string SuccessfulImportPlay
            = "Successfully imported {0} with genre {1} and a rating of {2}!";

        private const string SuccessfulImportActor
            = "Successfully imported actor {0} as a {1} character!";

        private const string SuccessfulImportTheatre
            = "Successfully imported theatre {0} with #{1} tickets!";

        public static string ImportPlays(TheatreContext context, string xmlString)
        {
            XmlHelper xmlHelper = new XmlHelper();
            StringBuilder sb = new StringBuilder();
            List<Play> plays = new List<Play>();

            var playsDto = xmlHelper.Deserializer<ImportPlaysDto[]>(xmlString, "Plays");


            foreach (var dto in playsDto)
            {
                if (!IsValid(dto))
                {
                    sb.AppendLine(ErrorMessage);
                    continue;
                }

                object genre;
                bool isValidGenre = Enum.TryParse(typeof(Genre), dto.Genre, out genre);

                if (!isValidGenre)
                {
                    sb.AppendLine(ErrorMessage);
                    continue;
                }

                TimeSpan minTimeSpan = TimeSpan.ParseExact("01:00:00", "c", CultureInfo.InvariantCulture);
                var currentTime = TimeSpan.ParseExact(dto.Duration, "c", CultureInfo.InvariantCulture);
                if (currentTime < minTimeSpan)
                {
                    sb.AppendLine(ErrorMessage);
                    continue;
                }


                var play = new Play()
                {
                    Title = dto.Title,
                    Duration = currentTime,
                    Rating = dto.Rating,
                    Genre = (Genre)genre,
                    Description = dto.Description,
                    Screenwriter = dto.ScreenWriter
                };

                sb.AppendLine(string.Format(SuccessfulImportPlay, play.Title, play.Genre, play.Rating));
                plays.Add(play);
            }

            context.Plays.AddRange(plays);
            context.SaveChanges();
            return sb.ToString().TrimEnd();
        }

        public static string ImportCasts(TheatreContext context, string xmlString)
        {
            XmlHelper xmlHelper = new XmlHelper();
            List<Cast> casts = new List<Cast>();
            StringBuilder sb = new StringBuilder();

            var castDtos = xmlHelper.Deserializer<ImportCastsDto[]>(xmlString, "Casts");

            foreach (var dto in castDtos)
            {
                if (!IsValid(dto))
                {
                    sb.AppendLine(ErrorMessage);
                    continue;
                }

                var cast = new Cast()
                {
                    FullName = dto.FullName,
                    IsMainCharacter = dto.IsMainCharacter,
                    PhoneNumber = dto.PhoneNumber,
                    PlayId = dto.PlayId
                };

                string role = "";
                if (cast.IsMainCharacter)
                {
                    role = "main";
                }
                else
                {
                    role = "lesser";
                }

                sb.AppendLine(string.Format(SuccessfulImportActor, cast.FullName, role));
                casts.Add(cast);
            }  

            context.Casts.AddRange(casts);
            context.SaveChanges();
            return sb.ToString().TrimEnd();
        }

        public static string ImportTtheatersTickets(TheatreContext context, string jsonString)
        {
            StringBuilder sb = new StringBuilder();
            List<Data.Models.Theatre> theatres = new List<Data.Models.Theatre>();

            var theatresDtos = JsonConvert.DeserializeObject<ImportProjectionsDto[]>(jsonString);

            foreach (var dto in theatresDtos)
            {
                if (!IsValid(dto))
                {
                    sb.AppendLine(ErrorMessage);
                    continue;
                }

                var theater = new Data.Models.Theatre()
                {
                    Name = dto.Name,
                    NumberOfHalls = dto.NumberOfHalls,
                    Director = dto.Director
                };

                List<Ticket> tickets = new List<Ticket>(); 

                foreach (var dtoTickets in dto.Tickets)
                {
                    if (!IsValid(dtoTickets))
                    {
                        sb.AppendLine(ErrorMessage);
                        continue;
                    }

                    var ticket = new Ticket()
                    {
                        Price = dtoTickets.Price,
                        RowNumber = dtoTickets.RowNumber,
                        Theatre = theater,
                        PlayId = dtoTickets.PlayId
                    };

                    tickets.Add(ticket);
                }

                theater.Tickets = tickets;
                sb.AppendLine(string.Format(SuccessfulImportTheatre, theater.Name, theater.Tickets.Count));
                theatres.Add(theater);
            }

            context.Theatres.AddRange(theatres);
            context.SaveChanges();

            return sb.ToString().TrimEnd();
        }


        private static bool IsValid(object obj)
        {
            var validator = new ValidationContext(obj);
            var validationRes = new List<ValidationResult>();

            var result = Validator.TryValidateObject(obj, validator, validationRes, true);
            return result;
        }
    }
}
