[assembly: Xamarin.Forms.Dependency(typeof(MoviesPocketXForms.Services.NavigationService))]
namespace MoviesPocketXForms.Services
{
    using System.Threading.Tasks;
    using Models;
    using Views;
    using ViewModels;
    using System;

    public class NavigationService : INavigationService
    {
        public async Task NavigateToDetailPage(MyMedia media)
		{
            DetailPage detailPage = new DetailPage();
			var vmPage = (detailPage.BindingContext as DetailPageViewModel);
			vmPage.Media = media;

			await App.Current.MainPage.Navigation.PushAsync(detailPage);
		}

        public async Task NavigateToShowCinemasPage(){
            
            await App.Current.MainPage.Navigation.PushAsync(new ShowCinemasPage());
        }
	}
}
