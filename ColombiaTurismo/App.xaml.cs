using System.Collections.ObjectModel;
using ColombiaTurismo.Models;

namespace ColombiaTurismo;

public partial class App : Application
{
	public App()
	{
		InitializeComponent();

		MainPage = new AppShell();

	}
    public List<TouristAttraction> GeneralTouristAttractions { get; set; }
    public int IdPlace { get; set; }
}

