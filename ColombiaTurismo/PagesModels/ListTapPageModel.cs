using System;
using System.Collections.ObjectModel;
using System.Windows.Input;
using ColombiaTurismo.Models;
using ColombiaTurismo.Services;

namespace ColombiaTurismo.PagesModels
{
	public class ListTapPageModel:BaseViewModel
	{
		

        #region Variables
        string totalCount;

        private ObservableCollection<TouristAttraction> touristAttractions;

        #endregion

        #region CONSTRUCTOR
        public ListTapPageModel(INavigation navigation)
        {
            Navigation = navigation;
            initInfo();
        }
        #endregion

        #region OBJETOS

        public ObservableCollection<TouristAttraction> TouristAttractions
        {
            get { return touristAttractions; }
            set { SetValue(ref touristAttractions, value); }
        }

        public string TotalCount
        {
            get { return totalCount; }
            set { SetValue(ref totalCount, value); }
        }

        #endregion

        #region PROCESOS

        public async Task initInfo()
        {
            TouristAttractions = new ObservableCollection<TouristAttraction>
                (await ApiServices.GetListTouristAttraction("https://api-colombia.com/api/v1/TouristicAttraction"));

            TotalCount = $"Total :{TouristAttractions.Count()} Lugares";
        }

        public async Task nextPageAsync()
        {
        }
        #endregion

        #region COMANDOS
        public ICommand Proceso => new Command(async () => await nextPageAsync());
        #endregion
    }
}

