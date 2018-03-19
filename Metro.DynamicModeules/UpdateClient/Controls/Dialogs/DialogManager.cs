using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace XHClient.UpdateClient.Controls.Dialogs
{
    public static class DialogManager
    {
        public static Task<string> ShowMessageAsync(this BaseWindow window, string title, string message)
        {
            window.Dispatcher.VerifyAccess();
            //window.Dispatcher.VerifyAccess();
            return Task.Factory.StartNew(() => { return ""; });

            //tcs.SetResult(null);
            //return tcs.Start() ;
        }


    }
}
