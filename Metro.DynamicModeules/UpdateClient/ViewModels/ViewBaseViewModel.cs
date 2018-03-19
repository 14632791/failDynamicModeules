

namespace UpdateClient.ViewModels
{
    public class ViewBaseViewModel : ModelBase
    {
        private ViewBaseViewModel()
        {

        }
        private static ViewBaseViewModel _instance;
        public static ViewBaseViewModel Instance
        {
            get
            {
                return _instance ?? (_instance = new ViewBaseViewModel());
            }
        }
        private string _title;
        public string Title
        {
            get
            {
                return _title;
            }

            set
            {
                _title = value;
                OnPropertyChanged("Title");
            }
        }
    }
}
