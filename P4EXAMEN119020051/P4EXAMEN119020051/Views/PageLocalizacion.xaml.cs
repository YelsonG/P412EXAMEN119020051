using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using Xamarin.Essentials;

namespace P4EXAMEN119020051.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class PageLocalizacion : ContentPage
    {
        Location Location = null;
        public PageLocalizacion()
        {
            InitializeComponent();
        }

        private async void btnguardar_Clicked(object sender, EventArgs e)
        {
            
            try
            {
 

                if (Location != null && 
                    !string.IsNullOrEmpty(descripcion_corta.Text) && 
                    !string.IsNullOrEmpty(descripcion_larga.Text))
                
                {
                    Latitud.Text = Convert.ToString(Location.Latitude);
                    Longitud.Text = Convert.ToString(Location.Longitude);

                    var local = new Models.Localizacion
                    {
                        Latitud = Location.Latitude,
                        Longitud = Location.Longitude,
                        descripcion_corta = descripcion_corta.Text,
                        descripcion_larga = descripcion_larga.Text

                    };
                     
                    if (await App.Database.SaveGeo(local) > 0)
                    {
                        await DisplayAlert("Aviso", "Lozalizacion Guardad", "OK");
                    }
                else
                {
                    if (Location == null)
                    {
                    await DisplayAlert("Error", "Error no esta activo el GPS", "OK");

                    }
                    else if(string.IsNullOrEmpty(descripcion_corta.Text))
                    {
                        await DisplayAlert("Error", "Error Sin descripcion corta", "OK");
                    }
                    else if(string.IsNullOrEmpty(descripcion_larga.Text))
                    {
                        await DisplayAlert("Error", "Error sin descrpcion Larga", "OK");
                    }
                }
                }
            }
            catch (Exception ex)
            {
                if (Location == null)
                {
                    await DisplayAlert("Error", "Error no esta activo el GPS", "OK");

                }

            }
        }
        private async void btnver_Clicked(object sender, EventArgs e)
        {
            var page = new Views.PageLisGeo();
            await Navigation.PushAsync(page);
        }
        protected async override void OnAppearing()
        {
            base.OnAppearing();
            try
            {
                Location = await Geolocation.GetLocationAsync();

                if (Location != null)

                {
                    Latitud.Text = Convert.ToString(Location.Latitude);
                    Longitud.Text = Convert.ToString(Location.Longitude);
                }
            }
            catch(Exception ex)
            {

            }
        }
    }
}
