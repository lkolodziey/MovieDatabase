using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;

namespace MovieDatabase.Models
{
    public class MovieModel
    {
        public int page { get; set; }
        public int total_results { get; set; }
        public int total_pages { get; set; }
        public ObservableCollection<Movies> results { get; set; }
        public bool HasError { get; set; }
        public string ErrorMessage { get; set; }
    }


    public class Movies
    {
        public int id { get; set; }

        private string _poster_path;
        public string poster_path
        {
            get { return _poster_path; }
            set { _poster_path = Helper.ImagePathHelper.GetFullImageURL(value); }
        }


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
