using System;
using System.Collections.Generic;
using System.Text;

namespace MovieDatabase.Models
{
    public class MovieViewModel
    {
        public int Id { get; set; }
        public string MovieName { get; set; }
        public string MoviePoster { get; set; }
        public string Detail { get; set; }
    }
}
