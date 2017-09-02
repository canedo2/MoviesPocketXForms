using System.Collections.ObjectModel;
using MoviesPocketXForms.Models;

namespace MoviesPocketXForms.Providers
{
    public interface IStorageProvider
    {
		void PersistFavorite(MyMedia media);
        void DeleteFavoriteIfExists(MyMedia media);
        ObservableCollection<MyMedia> GetFavorites();
    }
}
