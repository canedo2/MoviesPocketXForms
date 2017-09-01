namespace MoviesPocketXForms.ViewModels
{   using Base;
    using Models;

    public class DetailPageViewModel: BaseViewModel
    {   
        private MyMedia myMedia;
        public string Jaja = "Hola";
        public DetailPageViewModel()
        {
            
        }

        public void Init()
        {
            IsLoading = true;
        }

		public MyMedia MyMedia
		{
			get { return myMedia; }
			set
			{
				myMedia = value;
				RaisePropertyChanged();
			}
		}
    }
}
