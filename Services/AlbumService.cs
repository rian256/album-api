using album_api.Models;

namespace album_api.Services
{
    public class AlbumService
    {
        static List<Album> Albums{ get; }

        static int nextId = 11;
        static AlbumService()
        {
            Albums = new List<Album>
            {
            new Album { Id = 1, Artist = "Michael Jackson", Title = "Thriller", Price = 161.99 },
            new Album { Id = 2, Artist = "Michael Jackson", Title = "Invicible", Price = 111.58},
            new Album { Id = 3, Artist = "Nirvana", Title = "Nevermind", Price = 145.00 },
            new Album { Id = 4, Artist = "Nirvana", Title = "In Utero", Price = 148.99},
            new Album { Id = 5, Artist = "Slayer", Title = "Hell Await", Price = 162.99},
            new Album { Id = 6, Artist = "Metallica", Title = "Metallica", Price = 154.42},
            new Album { Id = 7, Artist = "Metallica", Title = "Undisputed Attitude", Price = 199.98},
            new Album { Id = 8, Artist = "Slayer", Title = "Diabolus In Musica", Price = 199.98},
            new Album { Id = 9, Artist = "Sepultura", Title = "Schizophrenia", Price = 140.9},
            new Album { Id = 10, Artist = "Dream Theater", Title = "Octavarium", Price = 42.67}
            };
        }

        public static List<Album> GetAll() => Albums;

        public static Album? Get(int Id) => Albums.FirstOrDefault(a => a.Id == Id);

        public static void Add(Album album)
        {
            album.Id = nextId++;
            Albums.Add(album);
        }

        public static void Delete(int Id)
        {
            var album = Get(Id);
            if (album is null)
            {
                return;
            }

            Albums.Remove(album);
        }

        public static void Update(Album album)
        {
            var index = Albums.FindIndex(p => p.Id == album.Id);
            if (index == -1) {
                return;
            }

            Albums[index] = album;
        }
    }
}
