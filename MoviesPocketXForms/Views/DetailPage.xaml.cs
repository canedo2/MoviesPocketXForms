namespace MoviesPocketXForms.Views
{
    using System;
    using Xamarin.Forms;
    using ViewModels;

    public partial class DetailPage : ContentPage
    {
        public DetailPage()
        {
            InitializeComponent();

        }

		protected override void OnAppearing()
		{
			base.OnAppearing();
            (this.BindingContext as DetailPageViewModel).Init();
		}

		async void StartImageAnimation(object sender, EventArgs e)
        {
            await image.FadeTo(0.2, 300);
            await image.FadeTo(1, 300);
		}
    }
}
