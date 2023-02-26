using System;
using System.Collections.ObjectModel;
using System.Windows.Input;
using ColombiaTurismo.Models;
using ColombiaTurismo.Pages;
using ColombiaTurismo.Services;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;

namespace ColombiaTurismo.PagesModels
{
	public class ListTapPageModel:BaseViewModel
	{
		

        #region Variables
        string totalCount;
        string currentState;

        private ObservableCollection<TouristAttraction> touristAttractions;

        static class States
        {
            public const string Loading = nameof(Loading);
            public const string Success = nameof(Success);
            public const string Anything = "StateKey can be anything!";
            public const string ReplaceGrid = nameof(ReplaceGrid);
            public const string NoAnimate = nameof(NoAnimate);
            public const string NotFound = nameof(NotFound);
        }


        #endregion

        #region CONSTRUCTOR
        public ListTapPageModel(INavigation navigation)
        {
            string currentState = States.Loading;

            Navigation = navigation;

            initInfo();
        }
        #endregion

        #region OBJETOS

        public string CurrentState
        {
            get { return currentState; }
            set { SetValue(ref currentState, value); }
        }

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

            CurrentState= States.Loading;

            TouristAttractions = new ObservableCollection<TouristAttraction>
                (await ApiServices.GetListTouristAttraction("https://api-colombia.com/api/v1/TouristicAttraction"));

            TotalCount = $"Total :{TouristAttractions.Count()} Lugares";

            CurrentState = States.Success;
            ((App)App.Current).GeneralTouristAttractions = TouristAttractions.ToList();


        }

       

        public async Task nextPageAsync(object e)
        {
            try
            {
                var item = (e as TouristAttraction);
                ((App)App.Current).IdPlace = item.Id;
                await Navigation.PushAsync(new DescriptionPage());
            }
            catch (Exception ex)
            {
                await DisplayAlert("Colombia Turismo", $"No pudimos navegar tenemos un error: {ex.Message}", "OK");
            }
        }


        #endregion

        #region COMANDOS
        //    public ICommand ShowDescriptionCommand => new Command(async () => await nextPageAsync());
        public ICommand ShowDescriptionCommand => new Command(async (e) => await nextPageAsync(e));
        #endregion
    }
}

