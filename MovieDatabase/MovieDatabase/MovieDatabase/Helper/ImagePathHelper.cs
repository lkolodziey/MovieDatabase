using System;
using System.Collections.Generic;
using System.Text;

namespace MovieDatabase.Helper
{

    
    public class ImagePathHelper
    {
        private const string ImageURLPath = "https://image.tmdb.org/t/p/w500";

        public static string GetFullImageURL(string imageURL)
        {
            return ImageURLPath + imageURL;
        }

    }
}
