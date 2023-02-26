namespace ColombiaTurismo.Pages;

public partial class MapTabPage : ContentPage
{
	public MapTabPage()
	{
		InitializeComponent();
        var mapControl = new Mapsui.UI.Maui.MapControl();
        mapControl.Map?.Layers.Add(Mapsui.Tiling.OpenStreetMap.CreateTileLayer());
        Content = mapControl;
    }
}
