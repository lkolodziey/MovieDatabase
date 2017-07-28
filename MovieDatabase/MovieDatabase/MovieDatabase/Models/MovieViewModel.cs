using MovieDatabase.Data;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace MovieDatabase.Models
{
    public class MovieViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        void OnPropertyChanged([CallerMemberName]string propertyName = "") => PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));

        private ObservableCollection<Movies> _movieList;
        public ObservableCollection<Movies> MovieList
        {
            get { return _movieList; }
            set
            {
                _movieList = value;
                OnPropertyChanged("MovieList");
            }
        }

        //public List<Movies> MovieList { get; set; }


        public MovieViewModel()
        {
            RESTService service = new RESTService();
            var movieModel = service.GetMovies();

            ObservableCollection<Movies> list = movieModel.results;
            foreach (var item in list)
            {
                item.poster_path = Helper.ImagePathHelper.GetFullImageURL(item.poster_path);
            }

            MovieList = list;
        }

    }
}
