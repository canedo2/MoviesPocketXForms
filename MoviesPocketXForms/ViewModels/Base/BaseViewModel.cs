namespace MoviesPocketXForms.ViewModels.Base
{
    using System.ComponentModel;
    using System.Runtime.CompilerServices;

    public class BaseViewModel : INotifyPropertyChanged
    {
        private bool isLoading;

        public bool IsLoading
        {
            get { return isLoading; }
            set{
                isLoading = value;
                RaisePropertyChanged();
            }
        }

        public void RaisePropertyChanged([CallerMemberName]string propertyName = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        public event PropertyChangedEventHandler PropertyChanged;
    }
}
