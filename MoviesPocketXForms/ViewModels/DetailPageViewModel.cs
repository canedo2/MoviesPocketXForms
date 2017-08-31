namespace MoviesPocketXForms.ViewModels
{   using Base;
    using Models;
    public class DetailPageViewModel: BaseViewModel
    {   
        public MyMedia Media
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
