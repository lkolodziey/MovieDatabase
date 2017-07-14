using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using MovieDatabase.Data;
using MovieDatabase.Models;
using System.Collections.ObjectModel;

namespace MovieDatabase
{
    public partial class MainPage : ContentPage
    {
        GenreModel Genres = new GenreModel();

        public MainPage()
        {
            InitializeComponent();
            GetGenresAsync();
            //LoadMoviesAsync();

        }

        private async void OnClick_ReloadAsync(object sender, EventArgs e)
        {
            listaMovies.ItemsSource = null;
            //await GetGenresAsync();
            await LoadMoviesAsync();
        }


        private async Task LoadMoviesAsync()
        {
            Indicator.IsVisible = true;
            Indicator.IsRunning = true;
            RESTService service = new RESTService();
            var list = await service.GetMovies();
            if (!list.HasError)
            {
                List<MovieViewModel> movies = new List<MovieViewModel>();
                foreach (var item in list.results)
                {
                    MovieViewModel movie = new MovieViewModel();
                    movie.Id = item.id;
                    movie.MovieName = item.title;
                    movie.MoviePoster = Helper.ImagePathHelper.GetFullImageURL(item.poster_path);
                    movie.Detail = string.Format("Release Date {0}, {1}", item.release_date.ToString("dd/MM/yyyy"), GetMovieGenre(item.genre_ids));
                    movies.Add(movie);

                }
                listaMovies.ItemsSource = movies;
            }
            else
            {
                await DisplayAlert("Error", string.Format("An error occurred on the server: {0}", list.ErrorMessage), "OK");
            }
            Indicator.IsVisible = false;
            Indicator.IsRunning = false;
        }

        private async Task GetGenresAsync()
        {
            RESTService service = new RESTService();
            StringBuilder result = new StringBuilder();
            Genres = await service.GetGenres();
            //System.Threading.Thread.Sleep(3000);
            Indicator.IsRunning = false;
            Indicator.IsVisible = false;
        }

        private void ShowDetail(object sender, EventArgs e)
        {
            ImageCell cell = (ImageCell)sender;
            var context = (MovieViewModel)cell.BindingContext;
            Navigation.PushAsync(new MovieDetail(context.Id));
        }


        private string GetMovieGenre(int[] genre_ids)
        {
            var query = Genres.genres.Where(i => genre_ids.Contains(i.id));
            StringBuilder result = new StringBuilder();
            foreach (var item in query)
            {
                result.Append(item.name);
                result.Append(Environment.NewLine);
            }

            return result.ToString();
        }

    }
}
