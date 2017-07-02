namespace MoviesPocketXForms.Services
{
	using Models;
	using System.Threading.Tasks;

	public interface INavigationService
	{
        Task NavigateToDetailPage(Media media);
        Task NavigateToShowCinemasPage();
	}
}
