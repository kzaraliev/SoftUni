using System.Linq;
using Newtonsoft.Json;
using Theatre.DataProcessor.ExportDto;
using Theatre.DataProcessor.ImportDto;

namespace Theatre.DataProcessor
{
    using System;
    using Theatre.Data;

    public class Serializer
    {
        public static string ExportTheatres(TheatreContext context, int numbersOfHalls)
        {
            var theaters = context.Theatres
                .Where(t => t.NumberOfHalls >= numbersOfHalls && t.Tickets.Count >= 20)
                .ToArray()
                .Select(t => new
                {
                    Name = t.Name,
                    Halls = t.NumberOfHalls,
                    TotalIncome =
                        Math.Round(
                            t.Tickets.Where(tick => tick.RowNumber >= 1 && tick.RowNumber <= 5)
                                .Select(tick => tick.Price).Sum(), 2),
                    Tickets = t.Tickets.Where(tick => tick.RowNumber >= 1 && tick.RowNumber <= 5).Select(t => new
                        {
                            Price = Math.Round(t.Price, 2),
                            RowNumber = t.RowNumber
                        })
                        .OrderByDescending(t => t.Price)
                        .ToArray()
                })
                .OrderByDescending(t => t.Halls)
                .ThenBy(t => t.Name)
                .ToArray();

            return JsonConvert.SerializeObject(theaters, Formatting.Indented);
        }

        public static string ExportPlays(TheatreContext context, double rating)
        {
            XmlHelper xmlHelper = new XmlHelper();

            var plays = context.Plays
                .Where(p => p.Rating <= rating)
                .ToArray()
                .Select(p => new ExportPlays()
                {
                    Title = p.Title,
                    Duration = p.Duration.ToString("c"),
                    Rating = p.Rating == 0 ? "Premier" : p.Rating.ToString(),
                    Genre = p.Genre.ToString(),
                    Actors = p.Casts
                        .Where(c => c.IsMainCharacter)
                        .Select(c => new Actor()
                        {
                            FullName = c.FullName,
                            MainCharacter = $"Plays main character in '{p.Title}'."
                        })
                        .OrderByDescending(c => c.FullName)
                        .ToArray()
                })
                .OrderBy(p => p.Title)
                .ThenByDescending(p => p.Genre)
                .ToArray();

            return xmlHelper.Serializer(plays, "Plays");
        }
    }
}
