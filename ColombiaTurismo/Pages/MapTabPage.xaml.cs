using Mapsui;
using Mapsui.Layers;
using Mapsui.Providers;
using Mapsui.Styles;
using Mapsui.UI.Maui;
using Microsoft.Maui.Graphics;

using Color = Microsoft.Maui.Graphics.Color;
using KnownColor = Mapsui.UI.Maui.KnownColor;

using static Google.Android.Material.Tabs.TabLayout;

namespace ColombiaTurismo.Pages;

public partial class MapTabPage : ContentPage
{

	public MapTabPage()
	{

        InitializeComponent();
         Random rnd = new Random(1);

        var Lista = ((App)App.Current).GeneralTouristAttractions;


        foreach (var item in Lista)
        {
            var pin = new Pin(mapView)
            {
                Label = $"Nombre: {item.Name}",
                Position = new Position(double.Parse(item.Latitude), double.Parse(item.Longitude)),
                Type = PinType.Pin,
                Color = new Color(rnd.Next(0, 256) / 256.0f, rnd.Next(0, 256) / 256.0f, rnd.Next(0, 256) / 256.0f),
                Transparency = 0.5f,
                Scale = rnd.Next(50, 130) / 100f,
            };

            pin.Callout.Anchor = new Point(0, pin.Height * pin.Scale);
            pin.Callout.RectRadius = rnd.Next(0, 30);
            pin.Callout.ArrowHeight = rnd.Next(0, 20);
            pin.Callout.ArrowWidth = rnd.Next(0, 20);
            pin.Callout.ArrowAlignment = (ArrowAlignment)rnd.Next(0, 4);
            pin.Callout.ArrowPosition = rnd.Next(0, 100) / 100;
            pin.Callout.BackgroundColor = KnownColor.White;
            pin.Callout.Color = pin.Color;

            if (rnd.Next(0, 3) < 2)
            {
                pin.Callout.Type = CalloutType.Detail;
                pin.Callout.TitleFontSize = rnd.Next(15, 30);
                pin.Callout.SubtitleFontSize = pin.Callout.TitleFontSize - 5;
                pin.Callout.TitleFontColor = new Color(rnd.Next(0, 256) / 256.0f, rnd.Next(0, 256) / 256.0f, rnd.Next(0, 256) / 256.0f);
                pin.Callout.SubtitleFontColor = pin.Color;
            }
            else
            {
                pin.Callout.Type = CalloutType.Detail;
                pin.Callout.Content = 1;
            }
            mapView.Pins.Add(pin);
            pin.ShowCallout();
        }
        
        mapView.Map.Layers.Add(Mapsui.Tiling.OpenStreetMap.CreateTileLayer());
        mapView.MyLocationLayer.UpdateMyLocation(new Mapsui.UI.Maui.Position());
        mapView.IsZoomButtonVisible = true;
        mapView.IsMyLocationButtonVisible = true;
        mapView.IsNorthingButtonVisible = true;

        





    }

   
   

}
