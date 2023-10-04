using System;
using System.Collections.Generic;
using System.Linq;

namespace Exam.MovieDatabase
{
    public class MovieDatabase : IMovieDatabase
    {
        private Dictionary<string, Actor> actors = new Dictionary<string, Actor>();
        private Dictionary<string, Movie> movies = new Dictionary<string, Movie>();

        public void AddActor(Actor actor)
        {
            actors.Add(actor.Id, actor);
        }

        public void AddMovie(Actor actor, Movie movie)
        {
            if (!actors.ContainsKey(actor.Id))
            {
                throw new ArgumentException();
            }
            actors[actor.Id].Movies.Add(movie);
            movies.Add(movie.Id, movie);
        }

        public bool Contains(Actor actor)
        {
            return actors.ContainsKey(actor.Id);
        }

        public bool Contains(Movie movie)
        {
            return movies.ContainsKey(movie.Id);
        }

        public IEnumerable<Actor> GetActorsOrderedByMaxMovieBudgetThenByMoviesCount()
        {
            return actors
                .Select(a => a.Value)
                .OrderByDescending(a => a.Movies.Select(m => m.Budget).OrderByDescending(m => m).ToList()[0])
                .ThenByDescending(a => a.Movies.Count);
        }

        public IEnumerable<Movie> GetAllMovies()
        {
            return movies.Values;
        }

        public IEnumerable<Movie> GetMoviesInRangeOfBudget(double lower, double upper)
        {
            return movies
                .Select(m => m.Value)
                .Where(m => m.Budget >= lower && m.Budget <= upper)
                .OrderByDescending(m => m.Rating);
        }

        public IEnumerable<Movie> GetMoviesOrderedByBudgetThenByRating()
        {
            return movies
                .Select(m => m.Value)
                .OrderByDescending(m => m.Budget)
                .ThenByDescending(m => m.Rating);
        }

        public IEnumerable<Actor> GetNewbieActors()
        {
            return actors
                .Select(a => a.Value)
                .Where(a => a.Movies.Count == 0);
        }
    }
}
