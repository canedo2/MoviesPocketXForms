[assembly: Xamarin.Forms.Dependency(typeof(MoviesPocketXForms.Providers.MyStorageProvider))]
namespace MoviesPocketXForms.Providers
{
    using System.Collections.ObjectModel;
    using MoviesPocketXForms.Models;
	using Plugin.Settings;
	using Plugin.Settings.Abstractions;
    using Newtonsoft.Json;


    public class MyStorageProvider : IStorageProvider
    {
		private static ISettings AppSettings => CrossSettings.Current;

        public MyStorageProvider()
        {
            if (CrossSettings.IsSupported) {
                System.Diagnostics.Debug.WriteLine("CrossSettings is supported");
            }
            else {

				System.Diagnostics.Debug.WriteLine("CrossSettings is not supported");
			}
        }

        public void PersistFavorite(MyMedia media){
            var favoritesArray = this.GetFavorites();

            favoritesArray.Add(media);
            var favoritesJson = Newtonsoft.Json.JsonConvert.SerializeObject(favoritesArray);
            favorites = favoritesJson;
            
        }

        public void DeleteFavoriteIfExists(MyMedia media){
            var favoritesArray = this.GetFavorites();
            var resultArray = new ObservableCollection<MyMedia>();
            foreach (var item in favoritesArray){
                if (!(item.Title == media.Title && item.Overview == media.Overview)){
                    resultArray.Add(item);
                }

            }
            var favoritesJson = Newtonsoft.Json.JsonConvert.SerializeObject(resultArray);
			favorites = favoritesJson;
        }

        public ObservableCollection<MyMedia> GetFavorites(){
			return Newtonsoft.Json.JsonConvert.DeserializeObject<ObservableCollection<MyMedia>>(favorites);
        }

        private static string favorites
		{
            get => AppSettings.GetValueOrDefault(nameof(favorites), Newtonsoft.Json.JsonConvert.SerializeObject(new ObservableCollection<MyMedia>()));
            set => AppSettings.AddOrUpdateValue(nameof(favorites), value);
		}
    }
}
