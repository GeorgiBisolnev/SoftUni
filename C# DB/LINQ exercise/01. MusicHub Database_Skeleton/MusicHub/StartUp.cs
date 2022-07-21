namespace MusicHub
{
    using System;
    using System.Linq;
    using System.Text;
    using Data;
    using Initializer;
    using Microsoft.EntityFrameworkCore;

    public class StartUp
    {
        public static void Main(string[] args)
        {
            MusicHubDbContext context = 
                new MusicHubDbContext();

            //DbInitializer.ResetDatabase(context);

            //Test your solutions here

            //Console.WriteLine(ExportAlbumsInfo(context, 9));


            Console.WriteLine(ExportSongsAboveDuration(context,4));
        }

        public static string ExportAlbumsInfo(MusicHubDbContext context, int producerId)
        {
            StringBuilder output = new StringBuilder();

            var result = context
                .Albums                
                .Where(p => p.ProducerId.Value == producerId)
                .Include(a=>a.Producer)
                .Include(s=>s.Songs)
                .ThenInclude(w=>w.Writer)
                .ToList()
                .Select(a => new
                {
                    ProducerName = a.Producer.Name,
                    AlbumName = a.Name,
                    Releasedate = a.ReleaseDate.ToString("MM/dd/yyyy"),
                    AlbumSongs = a.Songs.Select(s => new
                    {
                        s.Name,
                        s.Price,
                        s.Writer
                    }).ToList()
                    .OrderByDescending(s => s.Name)
                    .ThenBy(s => s.Writer),
                    TotalPrice = a.Price
                })
                .ToList()
                .OrderByDescending(a => a.TotalPrice);
               

            foreach (var album in result)
            {
                int songCount = 0;

                output.AppendLine($"-AlbumName: {album.AlbumName}")
                      .AppendLine($"-ReleaseDate: {album.Releasedate}")
                      .AppendLine($"-ProducerName: {album.ProducerName}")
                      .AppendLine($"-Songs:");
                      
                foreach (var song in album.AlbumSongs)
                {

                    output.AppendLine($"---#{++songCount}")
                          .AppendLine($"---SongName: {song.Name}")
                          .AppendLine($"---Price: {song.Price:F2}")
                          .AppendLine($"---Writer: {song.Writer.Name}");
                }
                output.AppendLine($"-AlbumPrice: {album.TotalPrice:F2}");


                
            }
            return output.ToString().TrimEnd();
        }

        public static string ExportSongsAboveDuration(MusicHubDbContext context, int duration)
        {
            StringBuilder str = new StringBuilder();

            var query = context
                .Songs                
                .Include(a => a.Album)
                .ThenInclude(p => p.Producer)
                .Include(per => per.SongPerformers)
                .ThenInclude(per => per.Performer)
                .Include(w => w.Writer)                
                .ToList()
                .Where(d => d.Duration.TotalSeconds > duration)
                .Select(p => new
                {
                    p.Name,
                    Writer = p.Writer.Name,
                    PerformerFullName = p.SongPerformers.Select(sp => $"{sp.Performer.FirstName} {sp.Performer.LastName}").FirstOrDefault(),
                    AlbumProducer = p.Album.Producer.Name,
                    Duration = p.Duration
                })                               
                .OrderBy(s => s.Name)
                .ThenBy(w => w.Writer)
                .ThenBy(p => p.PerformerFullName);

            int count = 0;

            foreach (var song in query)
            {               
                str
                    .AppendLine($"-Song #{++count}")
                    .AppendLine($"---SongName: {song.Name}")
                    .AppendLine($"---Writer: {song.Writer}")
                    .AppendLine($"---Performer: {song.PerformerFullName}")
                    .AppendLine($"---AlbumProducer: {song.AlbumProducer}")
                    .AppendLine($"---Duration: {song.Duration}");
            }


            return str.ToString().TrimEnd();
        }
    }
}
