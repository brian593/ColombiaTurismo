using System;
using System.Windows.Input;
using ColombiaTurismo.Models;

namespace ColombiaTurismo.PagesModels
{
	public class DescriptionPageModel:BaseViewModel
	{
	

        #region Variables
        string image;
        TouristAttraction touristAttraction;
        #endregion

        #region CONSTRUCTOR
        public DescriptionPageModel(INavigation navigation)
        {
            Navigation = navigation;

            var Lista = ((App)App.Current).GeneralTouristAttractions;
            MyTouristAttraction = Lista.Find(x => x.Id == ((App)App.Current).IdPlace);

            Image = MyTouristAttraction.Images[0];

        }
        #endregion

        #region OBJETOS
        public TouristAttraction MyTouristAttraction
        {
            get { return touristAttraction; }
            set { SetValue(ref touristAttraction, value); }
        }

        public string Image
        {
            get { return image; }
            set { SetValue(ref image, value); }
        }

        #endregion

        #region PROCESOS
        public async Task goToMapAsync()
        {
            string latitude = MyTouristAttraction.Latitude; // coordenadas de latitud
            string longitude = MyTouristAttraction.Longitude; // coordenadas de longitud
            string label = MyTouristAttraction.Name; // etiqueta de ubicación

            string url = $"https://www.google.com/maps/search/?api=1&query={latitude},{longitude}&query_place_id={label}";

            await Browser.Default.OpenAsync(new Uri(url), BrowserLaunchMode.SystemPreferred);


            //  Device.OpenUri(new Uri(url));
        }
        #endregion

        #region COMANDOS
        public ICommand GoToMapCmd => new Command(async () => await goToMapAsync());
        #endregion
    }
}

