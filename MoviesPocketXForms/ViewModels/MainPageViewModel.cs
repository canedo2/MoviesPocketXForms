namespace MoviesPocketXForms.ViewModels
{
    using Base;
    using System.Collections.ObjectModel;
    using System.Collections.Generic;
    using Models;
    using Providers;
    using Xamarin.Forms;
    using Services;
    using System.Threading.Tasks;
    using System.Windows.Input;
	using System.Linq;


	public class MainPageViewModel: BaseViewModel
    {
        private ObservableCollection<MyMedia> items;
        private IWebApiProvider<MyMedia> webApiProvider;
        private INavigationService navigationService;
        public ICommand ShowCinemasCommand { get; }
        private MyMedia selectedMyMedia;

        public MainPageViewModel()
        {
            items = new ObservableCollection<MyMedia>();
            webApiProvider = DependencyService.Get<IWebApiProvider<MyMedia>>();
            navigationService = DependencyService.Get<INavigationService>();

            ShowCinemasCommand = new Command(async () => await ShowCinemas());
        }

        public async Task Init(){
            IsLoading = true;

            var mediaList = await webApiProvider.GetMediaListAsync();

            foreach (MyMedia m in mediaList){
                m.PosterPath = "https://image.tmdb.org/t/p/w500" + m.PosterPath;
                items.Add(m);

            }

            Items = new ObservableCollection<MyMedia>(mediaList.ToList());              

            /*for (int i = 0; i < 20; i++)
            {
                MyMedia media = new MyMedia();
                media.Overview = "Lorem ipsum dolor sit amet, consectetuer adipiscing elit, sed diam nonummy nibh euismod tincidunt ut laoreet dolore magna aliquam erat volutpat. Ut wisi enim ad minim veniam, quis nostrud exerci tation ullamcorper suscipit lobortis nisl ut aliquip ex ea commodo consequat. Duis autem vel eum iriure dolor in hendrerit in vulputate velit esse molestie consequat, vel illum dolore eu feugiat nulla facilisis at vero eros et accumsan et iusto odio dignissim qui blandit praesent luptatum zzril delenit augue duis dolore te feugait nulla facilisi. Nam liber tempor cum soluta nobis eleifend option congue nihil imperdiet doming id quod mazim placerat facer possim assum. Typi non habent claritatem insitam; est usus legentis in iis qui facit eorum claritatem. Investigationes demonstraverunt lectores legere me lius quod ii legunt saepius. Claritas est etiam processus dynamicus, qui sequitur mutationem consuetudium lectorum. Mirum est notare quam littera gothica, quam nunc putamus parum claram, anteposuerit litterarum formas humanitatis per seacula quarta decima et quinta decima. Eodem modo typi, qui nunc nobis videntur parum clari, fiant sollemnes in futurum.";
                media.Title = "La película de tu vida y la vida de los demás.";
                media.PosterPath = "http://images.animespirit.ru/uploads/posts/2015-04/1429904492_kyoukai.no.kanata.full.1656219.jpg";
                media.VoteAverage = 7.5;
                media.MediaType = "Movie";
                items.Add(media);
            }*/

        }

		public ObservableCollection<MyMedia> Items
		{
			get { return items; }
			set
			{
				items = value;
				RaisePropertyChanged();
			}
		}

        private async Task ShowCinemas(){

            await this.navigationService.NavigateToShowCinemasPage();
        }

        public MyMedia SelectedMyMedia
		{
			get { return selectedMyMedia; }
			set
			{
				selectedMyMedia = value;
				if (selectedMyMedia != null)
				{
                    this.navigationService.NavigateToDetailPage(SelectedMyMedia);
				}
				RaisePropertyChanged();
			}
		}
    }
}
