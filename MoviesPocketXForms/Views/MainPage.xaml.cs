

namespace MoviesPocketXForms.Views
{
	using Xamarin.Forms;
    using ViewModels;

    public partial class MainPage : ContentPage
	{
        public MainPage()
		{
			InitializeComponent();

		}

        protected override void OnAppearing()
        {
            base.OnAppearing();
            (this.BindingContext as MainPageViewModel).Init();
        }
	}
}
