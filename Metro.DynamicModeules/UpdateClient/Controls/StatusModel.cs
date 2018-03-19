using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;

namespace XHClient.UpdateClient.Controls
{
    public class StatusModel
    {
        public string ShowInfo { get; set; }

        public LinearGradientBrush LinearColor { get; set; }

        public byte Status { get; set; }
    }
}
