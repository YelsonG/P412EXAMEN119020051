using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Maps;
using Xamarin.Forms.Xaml;

namespace P4EXAMEN119020051.Views
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class PageMaps : ContentPage
	{
		public PageMaps ()
		{
			InitializeComponent ();
		}
        protected override void OnAppearing()
        {
            base.OnAppearing();
			var Seleccion = (Models.Localizacion) this.BindingContext;

			var centromap = new Xamarin.Forms.Maps.Position(Seleccion.Latitud, Seleccion.Longitud);
			mapa.MoveToRegion(new Xamarin.Forms.Maps.MapSpan(centromap, 1, 1));

			Pin ubicacion = new Pin();
			ubicacion.Label = Seleccion.descripcion_corta;
			ubicacion.Address = Seleccion.descripcion_larga;
			ubicacion.Position = new Xamarin.Forms.Maps.Position(Seleccion.Latitud, Seleccion.Longitud);
			mapa.Pins.Add(ubicacion);
        }

    }
}