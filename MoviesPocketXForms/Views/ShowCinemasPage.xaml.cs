namespace MoviesPocketXForms.Views
{
	using Xamarin.Forms;
    using Xamarin.Forms.Maps;
    using ViewModels;
    using Plugin.Geolocator;
    using System;
    using System.Threading.Tasks;

    public partial class ShowCinemasPage : ContentPage
    {
        public Command updateRegion;
        public CrossGeolocator locator;

        public ShowCinemasPage()
        {
            InitializeComponent();
            updateRegion = new Command(async () => await moveMapToUserLocationAsync());
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();
			
            (this.BindingContext as ShowCinemasPageViewModel).Init();
			var locator = CrossGeolocator.Current;
			System.Diagnostics.Debug.WriteLine("\n\n" + locator + "\n\n");

            //updateRegion.Execute(null);

        }

        public async Task moveMapToUserLocationAsync()
        {
            
            /*locator.DesiredAccuracy = 50;
            var position = await locator.GetPositionAsync(TimeSpan.FromSeconds(10));
            if (position != null)
            {
                MyMap.MoveToRegion(MapSpan.FromCenterAndRadius(new Position(position.Latitude, position.Longitude), Distance.FromMiles(1)).WithZoom(20));
            }*/
        }
    }


}
