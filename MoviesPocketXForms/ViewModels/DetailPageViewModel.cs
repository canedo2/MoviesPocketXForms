namespace MoviesPocketXForms.ViewModels
{   using Base;
    using Models;
    public class DetailPageViewModel: BaseViewModel
    {   
        public Media Media
        {
            get;
            set;
        }

        public DetailPageViewModel()
        {
            
        }

        public void Init()
        {
            IsLoading = true;
        }


    }
}
