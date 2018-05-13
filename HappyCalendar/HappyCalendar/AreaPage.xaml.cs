using HelloWorld.Persistance;
using SQLite;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace HappyCalendar
{

	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class AreaPage : ContentPage
	{
		public AreaPage ()
		{
			InitializeComponent ();
		}

        void Handle_btnAdd(object sender, System.EventArgs e)
        {

        }

        protected override async void OnAppearing()
        {

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