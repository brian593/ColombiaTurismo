using ColombiaTurismo.PagesModels;

namespace ColombiaTurismo.Pages;

public partial class DescriptionPage : ContentPage
{
	public DescriptionPage()
	{
		InitializeComponent();
		BindingContext = new DescriptionPageModel(Navigation);
	}
}
