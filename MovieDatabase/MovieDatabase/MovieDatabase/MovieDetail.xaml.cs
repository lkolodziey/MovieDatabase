using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using MovieDatabase.Data;
using MovieDatabase.Models;


namespace MovieDatabase
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class MovieDetail : ContentPage
    {
        public MovieDetail(int id)
        {
            InitializeComponent();
            BindingContext = new MovieDetailViewModel(id);
        }
    }
}