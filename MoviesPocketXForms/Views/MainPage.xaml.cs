namespace MoviesPocketXForms.Views
{
	using Xamarin.Forms;
    using ViewModels;
    using System;

    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();

        }
       

        protected override void OnAppearing()
        {
            base.OnAppearing();
            (this.BindingContext as MainPageViewModel).InitAsync();
        }

        async void Hola(object sender, EventArgs e)
        { 
            System.Diagnostics.Debug.WriteLine("HOLA");
            await DisplayAlert("hola","hola","adios");
            await Navigation.PushAsync(new ShowCinemasPage());
        }
    }
}
