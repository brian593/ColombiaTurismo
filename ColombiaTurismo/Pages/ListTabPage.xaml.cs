using ColombiaTurismo.PagesModels;
namespace ColombiaTurismo.Pages;

public partial class ListTabPage : ContentPage
{
	public ListTabPage()
	{
		InitializeComponent();
        BindingContext = new ListTapPageModel(Navigation);

    }
}
