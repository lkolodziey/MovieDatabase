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
            LoadMovieInformationAsync(id);
        }

        private async Task LoadMovieInformationAsync(int id)
        {
            Indicator.IsVisible = true;
            Indicator.IsRunning = true;
            RESTService service = new RESTService();
            var list = await service.GetMovieInformation(id);
            if (!list.HasError)
            {
                ImagePosterPath.Source = Helper.ImagePathHelper.GetFullImageURL(list.poster_path);
                lblMovieTitle.Text = list.title;
                lblOriginalTitle.Text = list.original_title;
                lblOriginalLanguage.Text = list.original_language;
                lblReleaseDate.Text = list.release_date.ToString("dd/MM/yyyy");
                lblOverview.Text = list.overview;


                StringBuilder strList = new StringBuilder();
                foreach (var item in list.genres)
                {
                    strList.Append(item.name);
                    strList.Append(Environment.NewLine);
                }
                lblGenres.Text = strList.ToString();
                strList.Clear();
                foreach (var item in list.spoken_languages)
                {
                    strList.Append(item.name);
                    strList.Append(Environment.NewLine);
                }

                lblSpokenLanguages.Text = strList.ToString();


            }
            else
            {
                await DisplayAlert("Error", string.Format("An error occurred on the server: {0}", list.ErrorMessage), "OK");
                await Navigation.PopAsync();
            }

            Indicator.IsRunning = false;
            Indicator.IsVisible = false;
        }
    }
}