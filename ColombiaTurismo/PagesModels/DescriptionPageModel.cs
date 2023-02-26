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
        public async Task nextPageAsync()
        {
        }
        #endregion

        #region COMANDOS
        public ICommand Proceso => new Command(async () => await nextPageAsync());
        #endregion
    }
}

