using MovieDatabase.Data;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Text;

namespace MovieDatabase.Models
{

    public class MovieDetailViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        void OnPropertyChanged([CallerMemberName]string propertyName = "") => PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));

        public MovieDetailModel _movie;

        public MovieDetailModel movie
        {
            get { return _movie; }
            set
            {
                _movie = value;
                OnPropertyChanged("MovieList");
            }
        }

        public MovieDetailViewModel(int id)
        {
            RESTService service = new RESTService();
            movie = service.GetMovie(id);
        }
    }



}
