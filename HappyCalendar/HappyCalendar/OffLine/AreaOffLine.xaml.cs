using HappyCalendar.Models;
using HelloWorld.Persistance;
using SQLite;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace HappyCalendar.OffLine
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class AreaOffLine : ContentPage
	{
        private SQLiteAsyncConnection _connection;
        private ObservableCollection<Area> _areas;

        public AreaOffLine ()
		{
			InitializeComponent ();

            _connection = DependencyService.Get<ISQLiteDb>().GetConnection();
        }

        void Handle_btnAdd(object sender, System.EventArgs e)
        {
            stkAddArea.IsVisible = true;
        }

        protected override async void OnAppearing()
        {
            await _connection.CreateTableAsync<Area>();

            var areas = await _connection.Table<Area>().ToListAsync();
            _areas = new ObservableCollection<Area>(areas);
            lstArea.ItemsSource = _areas;
            base.OnAppearing();
        }

        async void OnAdd(object sender, System.EventArgs e)
        {
            //var area = new Area { Name = "Finanças" + DateTime.Now.Ticks};
            var area = new Area { Name = txtAreaName.Text };
            await _connection.InsertAsync(area);
            _areas.Add(area);
            txtAreaName.Text = "";
            stkAddArea.IsVisible = false;
        }

        async void OnUpdate(object sender, System.EventArgs e)
        {
            var area = _areas[0];
            area.Name += " UPDATED";
            await _connection.UpdateAsync(area);
        }

        async void OnDelete(object sender, System.EventArgs e)
        {
            var area = _areas[0];
            await _connection.DeleteAsync(area);
            _areas.Remove(area);
        }
    }
}