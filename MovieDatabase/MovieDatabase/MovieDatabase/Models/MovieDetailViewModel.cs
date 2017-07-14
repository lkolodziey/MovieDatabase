using System;
using System.Collections.Generic;
using System.Text;

namespace MovieDatabase.Models
{
    public class MovieDetailViewModel
    {
        public List<Genre> genres { get; set; }
        public string original_language { get; set; }
        public string original_title { get; set; }
        public string overview { get; set; }
        public string poster_path { get; set; }
        public DateTime release_date { get; set; }
        public List<spoken_language> spoken_languages { get; set; }
        public string title { get; set; }
        public bool HasError { get; set; }
        public string ErrorMessage { get; set; }
    }


    public class spoken_language
    {
        public string name { get; set; }
        public string iso_639_1 { get; set; }
    }
}
