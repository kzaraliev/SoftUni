using System.Text;
using Microsoft.EntityFrameworkCore;

namespace MusicHub
{
    using System;

    using Data;
    using Initializer;
    using MusicHub.Data.Models;

    public class StartUp
    {
        public static void Main()
        {
            MusicHubDbContext context =
                new MusicHubDbContext();

            DbInitializer.ResetDatabase(context);

            //Test your solutions here
        }

        public static string ExportAlbumsInfo(MusicHubDbContext context, int producerId)
        {
            var albums = context
                .Producers
                .First(p => p.Id == producerId)
                .Albums
                .Select(a => new
                {
                    a.Name,
                    ReleaseDate = a.ReleaseDate.ToString("MM/dd/yyyy"),
                    ProducerName = a.Producer.Name,
                    Songs = a.Songs.Select(s => new
                    {
                        SongWriterName = s.Writer.Name,
                        SongName = s.Name,
                        SongPrice = s.Price
                    }).OrderByDescending(s => s.SongName).ThenBy(s => s.SongWriterName).ToList(),
                    a.Price
                })
                .OrderByDescending(a => a.Price)
                .ToList();

            StringBuilder sb = new StringBuilder();

            foreach (var album in albums)
            {
                sb.AppendLine($"-AlbumName: {album.Name}");
                sb.AppendLine($"-ReleaseDate: {album.ReleaseDate}");
                sb.AppendLine($"-ProducerName: {album.ProducerName}");
                sb.AppendLine("-Songs:");

                int counter = 1;
                foreach (var song in album.Songs)
                {
                    sb.AppendLine($"---#{counter}");
                    sb.AppendLine($"---SongName: {song.SongName}");
                    sb.AppendLine($"---Price: {song.SongPrice:f2}");
                    sb.AppendLine($"---Writer: {song.SongWriterName}");
                    counter++;
                }

                sb.AppendLine($"-AlbumPrice: {album.Price:f2}");
            }

            return sb.ToString().TrimEnd();
        }

        public static string ExportSongsAboveDuration(MusicHubDbContext context, int duration)
        {
            var songs = context.Songs
                .ToList()
                .Where(s => s.Duration.TotalSeconds > duration)
                .Select(s => new
                {
                    Name = s.Name,

                    PerformerFullName = s.SongPerformers
                        .Select(sp => sp.Performer.FirstName + " " + sp.Performer.LastName)
                        .OrderBy(name => name)
                        .ToList(),

                    WriterName = s.Writer.Name,
                    AlbumProducer = s.Album.Producer.Name,
                    Duration = s.Duration
                })
                .OrderBy(x => x.Name)
                .ThenBy(x => x.WriterName)
                .ThenBy(x => x.PerformerFullName)
                .ToList();

            var sb = new StringBuilder();
            int counter = 1;

            foreach (var s in songs)
            {
                sb
                    .AppendLine($"-Song #{counter++}")
                    .AppendLine($"---SongName: {s.Name}")
                    .AppendLine($"---Writer: {s.WriterName}");

                if (s.PerformerFullName.Any())
                {
                    sb.AppendLine(string
                        .Join(Environment.NewLine, s.PerformerFullName
                            .Select(p => $"---Performer: {p}")));
                }

                sb
                    .AppendLine($"---AlbumProducer: {s.AlbumProducer}")
                    .AppendLine($"---Duration: {s.Duration}");
            }

            return sb.ToString().TrimEnd();

        }
    }
}
