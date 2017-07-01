namespace MoviesPocketXForms
{
    using Xamarin.Forms;
    using Views;
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();

            Page firstPage = new MainPage();
            MainPage = new NavigationPage(firstPage);
        }

        protected override void OnStart()
        {
            // Handle when your app starts
        }

        protected override void OnSleep()
        {
            // Handle when your app sleeps
        }

        protected override void OnResume()
        {
            // Handle when your app resumes
        }
    }
}
