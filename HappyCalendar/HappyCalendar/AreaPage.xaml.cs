using HelloWorld.Persistance;
using SQLite;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace HappyCalendar
{
    public class Area
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }

        [MaxLength(100)]
        public string Name { get; set; }
    }

	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class AreaPage : ContentPage
	{
        private SQLiteAsyncConnection _connection;
        private ObservableCollection<Area> _areas;

		public AreaPage ()
		{
			InitializeComponent ();

            _connection = DependencyService.Get<ISQLiteDb>().GetConnection();

            /*var names = new List<string>
            {
                "Finanças",
                "Carreira",
                "Vestuário",
                "Amigos",
                "Família"
            };

            lstArea.ItemsSource = names;*/
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
            var area = new Area { Name = "Finanças" + DateTime.Now.Ticks};
            await _connection.InsertAsync(area);
            _areas.Add(area);
        }
    }
}