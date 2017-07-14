using System;
using System.Collections.Generic;
using System.Text;

namespace MovieDatabase.Models
{
    public class MovieModel
    {
        public int page { get; set; }
        public int total_results { get; set; }
        public int total_pages { get; set; }
        public List<MovieResult> results { get; set; }
        public bool HasError { get; set; }
        public string ErrorMessage { get; set; }
    }


    public class MovieResult
    {
        public int id { get; set; }
        public string poster_path { get; set; }
        public bool adult { get; set; }
        public string overview { get; set; }
        public DateTime release_date { get; set; }
        public int[] genre_ids { get; set; }
        public string original_title { get; set; }
        public string original_language { get; set; }
        public string title { get; set; }
        public string backdrop_path { get; set; }
        public string popularity { get; set; }
        public int vote_count { get; set; }
        public bool video { get; set; }
        public decimal vote_average { get; set; }

    }

}
