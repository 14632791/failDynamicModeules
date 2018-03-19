
namespace UpdateClient.ViewModels
{
    public class DownloadPageViewModels : ModelBase
    {
        private static DownloadPageViewModels _instance;
        public static DownloadPageViewModels Instance
        {
            get
            {
                return _instance ?? (_instance = new DownloadPageViewModels());
            }
        }
        /// <summary>
        /// 退出时回调
        /// </summary>
       // public Action CompleteAction { get; set; }

        private string _downloadMsg = "正在更新...";
        public string DownloadMsg
        {
            get
            {
                return _downloadMsg;
            }
            set
            {
                _downloadMsg = value;
                OnPropertyChanged("DownloadMsg");
            }
        }
        private double _propgressValue = 0;
        public double PropgressValue
        {
            get
            {
                return _propgressValue;
            }
            set
            {
                _propgressValue = value;
                OnPropertyChanged("PropgressValue");
            }
        }
        
    }
}
