using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace ColombiaTurismo.PagesModels
{
    public class PatronVM:BaseViewModel
    {
        #region Variables
        string txtSample;
        #endregion

        #region CONSTRUCTOR
        public PatronVM(INavigation navigation)
        {
            Navigation = navigation;
        }
        #endregion

        #region OBJETOS


        public string TxtSample
        {
            get { return txtSample; }
            set { SetValue(ref txtSample, value); }
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
