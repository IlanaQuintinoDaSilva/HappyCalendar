using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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

            var names = new List<string>
            {
                "Finanças",
                "Carreira",
                "Vestuário",
                "Amigos",
                "Família"
            };

            lstArea.ItemsSource = names;
		}
	}
}