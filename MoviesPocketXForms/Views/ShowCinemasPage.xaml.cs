namespace MoviesPocketXForms.Views
{
	using Xamarin.Forms;
    using ViewModels;

	public partial class ShowCinemasPage : ContentPage
    {
        public ShowCinemasPage()
        {
            InitializeComponent();
        }

		protected override void OnAppearing()
		{
			base.OnAppearing();

            (this.BindingContext as ShowCinemasPageViewModel).Init();
		}
    }
}
