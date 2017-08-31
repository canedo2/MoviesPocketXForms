namespace MoviesPocketXForms.Services
{
	using Models;
	using System.Threading.Tasks;

	public interface INavigationService
	{
        Task NavigateToDetailPage(MyMedia media);
        Task NavigateToShowCinemasPage();
	}
}
