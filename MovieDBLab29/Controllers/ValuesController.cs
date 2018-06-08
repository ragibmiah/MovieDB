using System;
using System.Collections.Generic;
using System.Linq;
using System.Data;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using MovieDBLab29.Models;

namespace MovieDBLab29.Controllers
{
    public class ValuesController : ApiController
    {
        static int hits = 0;
        // GET api/values/5
        public int GetCounter()
        {
            hits++;
            return hits;
        }

        

        public List<MovieList> GetCatalog()
        {
            MovieDBEntities db = new MovieDBEntities();
            List<MovieList> movies = db.MovieLists.ToList();

            return movies;
        }

        public List<MovieList> GetMovieByGenre(string id)
        {
            MovieDBEntities db = new MovieDBEntities();
            List<MovieList> genre = (from p in db.MovieLists
                            where p.Genre.Contains(id)
                            select p).ToList();

            return genre;
        }
        public MovieList GetRandomMovie(int id)
        {
            MovieDBEntities db = new MovieDBEntities();
            Random rand = new Random();
            int random = rand.Next(1, (db.MovieLists.Count() + 1));

            MovieList randMovie = (from p in db.MovieLists
                          where p.ID == random
                          select p).Single();


            return randMovie;
        }

        public MovieList GetRandomMovieFromGenre(string id)
        {
            MovieDBEntities db = new MovieDBEntities();
            List<MovieList> movies = (from p in db.MovieLists
                                 where p.Genre == id
                                 select p).ToList();

            int data  = movies.Count();

            Random rand = new Random();
            int random = rand.Next(1, data);

            return movies[random];
        }

        public List<MovieList> GetRandomMovieList(int id)
        {
            
                MovieDBEntities db = new MovieDBEntities();

                Random rand = new Random();
                int data = 0;

                List<MovieList> movies = new List<MovieList>();
                for (int i = 0; i < id; i++)
                {
                    data = rand.Next(1, (db.MovieLists.Count() + 1));

                    MovieList movie = (from p in db.MovieLists
                                  where p.ID == data
                                  select p).Single();
                    movies.Add(movie);
                }

                return movies;
            }

        //    public List<MovieList> GetMoviesGenres()
        //{
        //    MovieDBEntities db = new MovieDBEntities();
        //    IEnumerable<List<MovieList>> movies = (from p in db.MovieLists.AsEnumerable()
        //                              select p.Field<string>("Genre").ToList());
                                      

        //    return movies;
        //}

        public MovieList GetMovieInfo(string id)
        {
            MovieDBEntities db = new MovieDBEntities();
            MovieList info = (from p in db.MovieLists
                                       where p.Title.Contains(id)
                                       select p).Single();

            return info;
        }

        public List<MovieList> GetMovieByKeyword(string id)
        {
            MovieDBEntities db = new MovieDBEntities();
            List<MovieList> keyword = (from p in db.MovieLists
                                     where p.Title.Contains(id)
                                     select p).ToList();

            return keyword;
        }
    }
}
   
