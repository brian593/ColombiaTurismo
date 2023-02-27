using Mapsui;
using Mapsui.Layers;
using Mapsui.Providers;
using Mapsui.Styles;
using Mapsui.UI.Maui;
using static Google.Android.Material.Tabs.TabLayout;

namespace ColombiaTurismo.Pages;

public partial class MapTabPage : ContentPage
{
	public MapTabPage()
	{
		InitializeComponent();



        //var mapView = new Mapsui.UI.Maui.MapControl();


        //    mapView.Map?.Layers.Add(Mapsui.Tiling.OpenStreetMap.CreateTileLayer());


        mapView.Map.Layers.Add(Mapsui.Tiling.OpenStreetMap.CreateTileLayer());

        mapView.MyLocationLayer.UpdateMyLocation(new Mapsui.UI.Maui.Position());

        mapView.IsZoomButtonVisible = true;
        mapView.IsMyLocationButtonVisible = true;
        mapView.IsNorthingButtonVisible = true;

                //    Content = mapControl;


        var Lista = ((App)App.Current).GeneralTouristAttractions;


    }

   
   

}
