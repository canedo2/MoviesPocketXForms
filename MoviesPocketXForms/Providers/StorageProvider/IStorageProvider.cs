
namespace MoviesPocketXForms.Providers
{
	using System.Collections.ObjectModel;
	using MoviesPocketXForms.Models;

	public interface IStorageProvider
    {
		void PersistFavorite(MyMedia media);
        void DeleteFavoriteIfExists(MyMedia media);
        ObservableCollection<MyMedia> GetFavorites();
    }
}
