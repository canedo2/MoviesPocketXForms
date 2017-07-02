namespace MoviesPocketXForms.Views
{
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
    }
}
