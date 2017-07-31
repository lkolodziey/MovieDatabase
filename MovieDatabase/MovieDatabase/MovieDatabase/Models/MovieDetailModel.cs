using System;
using System.Collections.Generic;
using System.Text;

namespace MovieDatabase.Models
{
    public class MovieDetailModel
    {
        //public int id { get; set; }
        public string original_language { get; set; }
        public string original_title { get; set; }
        public string overview { get; set; }

        private string _poster_path;
        public string poster_path
        {
            get { return _poster_path; }
            set { _poster_path = Helper.ImagePathHelper.GetFullImageURL(value); }
        }

        public DateTime release_date { get; set; }

        public string spoken_languages_list
        {
            get { return Helper.LangagesHelper.GetLanguages(spoken_languages); }
        }
        public string genres_list
        {
            get { return Helper.GenreHelper.GetRenges(genres); }
        }
        public string title { get; set; }
        public bool HasError { get; set; }
        public string ErrorMessage { get; set; }


        public List<Genre> genres { get; set; }
        public List<spoken_language> spoken_languages { get; set; }
    }

    public class spoken_language
    {
        public string name { get; set; }
        public string iso_639_1 { get; set; }
    }
}
