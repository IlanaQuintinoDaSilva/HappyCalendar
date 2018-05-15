using HappyCalendar.Models;
using HelloWorld.Persistance;
using ModernHttpClient;
using Newtonsoft.Json;
using SQLite;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Runtime.CompilerServices;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace HappyCalendar
{

    public class Post
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Body { get; set; }
    }

    [XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class AreaPage : ContentPage
	{
        private const string Url = "https://jsonplaceholder.typicode.com/posts";
        //private const string Url = "http://localhost/api/happycalendar/GetAreas";
        private HttpClient _client = new HttpClient(new NativeMessageHandler());
        private ObservableCollection<Post> _posts;

        public AreaPage ()
		{
			InitializeComponent ();
		}

        void Handle_btnAdd(object sender, System.EventArgs e)
        {

        }

        protected override async void OnAppearing()
        {
            try
            {
                var content = await _client.GetStringAsync(Url);
                var posts = JsonConvert.DeserializeObject<List<Post>>(content);
                _posts = new ObservableCollection<Post>(posts);
                lstArea.ItemsSource = _posts;
            }
            catch (Exception err)
            {

            }

            base.OnAppearing();
        }

        async void OnAdd(object sender, System.EventArgs e)
        {

        }

        async void OnUpdate(object sender, System.EventArgs e)
        {

        }

        async void OnDelete(object sender, System.EventArgs e)
        {

        }
    }
}