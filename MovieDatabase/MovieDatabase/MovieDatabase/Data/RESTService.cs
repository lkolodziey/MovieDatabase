using System;
using System.Collections.Generic;
using System.Text;
using MovieDatabase.Models;
using System.Net.Http;
using Newtonsoft.Json;
using System.Threading.Tasks;

namespace MovieDatabase.Data
{
    public class RESTService
    {
        private const string BaseURL = "https://api.themoviedb.org/3/";
        private const string APIKey = "1f54bd990f1cdfb230adb312546d765d";

        HttpClient client;

        public RESTService()
        {
            client = new HttpClient();
            client.MaxResponseContentBufferSize = 256000;
        }

        public async Task<MovieModel> GetMovies()
        {
            MovieModel result = new MovieModel();
            try
            {
                string completeURL = string.Format("{0}discover/movie?api_key={1}&language=pt-BR&sort_by=popularity.desc&include_adult=false&include_video=false&page=1", BaseURL, APIKey);
                var uri = new Uri(string.Format(completeURL, string.Empty));
                var response = await client.GetAsync(uri);
                if (response.IsSuccessStatusCode)
                {
                    var message = await response.Content.ReadAsStringAsync();
                    result = JsonConvert.DeserializeObject<MovieModel>(message);
                    result.HasError = false;
                }
            }
            catch (Exception ex)
            {
                result.HasError = true;
                result.ErrorMessage = ex.Message.ToString();
            }

            return result;
        }

        public async Task<MovieDetailViewModel> GetMovieInformation(int id)
        {
            MovieDetailViewModel result = new MovieDetailViewModel();
            try
            {
                string completeURL = string.Format("{0}movie/{1}?api_key={2}&language=pt-BR", BaseURL, id, APIKey);
                var uri = new Uri(string.Format(completeURL, string.Empty));
                var response = await client.GetAsync(uri);
                if (response.IsSuccessStatusCode)
                {
                    var message = await response.Content.ReadAsStringAsync();
                    result = JsonConvert.DeserializeObject<MovieDetailViewModel>(message);
                    result.HasError = false;
                }
            }
            catch (Exception ex)
            {
                result.HasError = true;
                result.ErrorMessage = ex.Message.ToString();
            }
            return result;
        }

        public async Task<GenreModel> GetGenres()
        {
            GenreModel result = new GenreModel();
            try
            {
                string completeURL = string.Format("{0}genre/movie/list?api_key={1}&language=pt-BR", BaseURL, APIKey);
                var uri = new Uri(string.Format(completeURL, string.Empty));
                var response = await client.GetAsync(uri);
                if (response.IsSuccessStatusCode)
                {
                    var message = await response.Content.ReadAsStringAsync();
                    result = JsonConvert.DeserializeObject<GenreModel>(message);
                    //result.HasError = false;
                }
            }
            catch (Exception ex)
            {
                //result.HasError = true;
                //result.ErrorMessage = ex.Message.ToString();
            }
            return result;
        }


    }
}

