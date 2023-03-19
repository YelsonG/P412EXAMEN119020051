using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace P4EXAMEN119020051.Views
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class PageLisGeo : ContentPage
	{
		public PageLisGeo ()
		{
			InitializeComponent ();
		}

		private void listlocal_SelectionChanged(Object sender, SelectionChangedEventArgs e)
        {
            var Seleccion = (Models.Localizacion)e.CurrentSelection[0];

            var page = new Views.PageMaps();
            page.BindingContext = Seleccion;
            Navigation.PushAsync(page);

        }

        protected async override void OnAppearing()
        {
            base.OnAppearing();

            Listlocal.ItemsSource = await App.Database.GetLisLocalizaciones();
        }
    }
}