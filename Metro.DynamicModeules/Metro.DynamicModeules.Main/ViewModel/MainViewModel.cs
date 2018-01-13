

using GalaSoft.MvvmLight;
using System.Collections.ObjectModel;
using System.Windows.Controls;

namespace Metro.DynamicModeules.Main.ViewModel
{
    /// <summary>
    /// This class contains properties that the main View can data bind to.
    /// <para>
    /// Use the <strong>mvvminpc</strong> snippet to add bindable properties to this ViewModel.
    /// </para>
    /// <para>
    /// You can also use Blend to data bind with the tool's support.
    /// </para>
    /// <para>
    /// See http://www.galasoft.ch/mvvm
    /// </para>
    /// </summary>
    public class MainViewModel: ViewModelBase
    {
        /// <summary>
        /// Initializes a new instance of the MainViewModel class.
        /// </summary>
        public MainViewModel()
        {
            ////if (IsInDesignMode)
            ////{
            ////    // Code runs in Blend --> create design time data.
            ////}
            ////else
            ////{
            ////    // Code runs "for real"
            ////}
        }
        private ObservableCollection<Expander> _rootExpander;
        public ObservableCollection<Expander> RootExpander
        {
            get
            {
                return _rootExpander;
            }
            set
            {
                _rootExpander = value;
                RaisePropertyChanged(() => RootExpander);
            }
        }
    }
}