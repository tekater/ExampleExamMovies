using System.Text.Json;

namespace ExampleExam
{
    public class MovieRepository : IMovieRepository 
    {
        private readonly string _filePath = "movies.json";
        private List<Movie> _moviesCache;

        public MovieRepository()
        {
            if (File.Exists(_filePath))
            {
                var json = File.ReadAllText(_filePath);
                _moviesCache = JsonSerializer.Deserialize<List<Movie>>(json) ?? new List<Movie>();
            }
            else
            {
                _moviesCache = new List<Movie>();
            }
        }

        public IEnumerable<Movie> GetAll()
        {
            return _moviesCache;
        }

        public Movie GetById(int id)
        {
            return _moviesCache.FirstOrDefault(m => m.Id == id);
        }

        public void Add(Movie movie)
        {
            movie.Id = _moviesCache.Any() ? _moviesCache.Max(m => m.Id) + 1 : 1;
            _moviesCache.Add(movie);
            SaveChanges(); 
        }

        public void Update(Movie movie)
        {
            var index = _moviesCache.FindIndex(m => m.Id == movie.Id);
            if (index != -1)
            {
                _moviesCache[index] = movie;
                SaveChanges();
            }
        }

        public void Delete(int id)
        {
            var movie = _moviesCache.FirstOrDefault(m => m.Id == id);
            if (movie != null)
            {
                _moviesCache.Remove(movie);
                SaveChanges();
            }
        }

        private void SaveChanges()
        {
            var json = JsonSerializer.Serialize(_moviesCache);
            File.WriteAllText(_filePath, json);
        }
    }
}