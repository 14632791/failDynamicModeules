using MahApps.Metro.Controls;
using MahApps.Metro.Controls.Dialogs;
using System;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;

namespace Metro.DynamicModeules.BaseControls.ControlzEx
{
    public class Msg
    {
       
        //public static async Task ShowDialogOutside(MetroWindow owner, MetroDialogSettings metroDialogOptions)
        //{
        //    var dialog = (BaseMetroDialog)owner.Resources["CustomDialogTest"];
        //    dialog.DialogSettings.ColorScheme = metroDialogOptions.ColorScheme;
        //    dialog = dialog.ShowDialogExternally();
        //    await TaskEx.Delay(5000);
        //    await dialog.RequestCloseAsync();
        //}

        public static async Task ShowMessageDialog(MetroWindow owner, MetroDialogSettings metroDialogOptions)
        {
            // This demo runs on .Net 4.0, but we're using the Microsoft.Bcl.Async package so we have async/await support
            // The package is only used by the demo and not a dependency of the library!
            var mySettings = new MetroDialogSettings()
            {
                AffirmativeButtonText = "Hi",
                NegativeButtonText = "Go away!",
                FirstAuxiliaryButtonText = "Cancel",
                ColorScheme = metroDialogOptions.ColorScheme
            };

            MessageDialogResult result = await owner.ShowMessageAsync("Hello!", "Welcome to the world of metro!",
                MessageDialogStyle.AffirmativeAndNegativeAndSingleAuxiliary, mySettings);

            if (result != MessageDialogResult.FirstAuxiliary)
                await owner.ShowMessageAsync("Result", "You said: " + (result == MessageDialogResult.Affirmative ? mySettings.AffirmativeButtonText : mySettings.NegativeButtonText +
                    Environment.NewLine + Environment.NewLine + "This dialog will follow the Use Accent setting."));
        }


        public static async Task ShowLimitedMessageDialog(MetroWindow owner, MetroDialogSettings metroDialogOptions)
        {
            var mySettings = new MetroDialogSettings()
            {
                AffirmativeButtonText = "Hi",
                NegativeButtonText = "Go away!",
                FirstAuxiliaryButtonText = "Cancel",
                MaximumBodyHeight = 100,
                ColorScheme = metroDialogOptions.ColorScheme
            };

            MessageDialogResult result = await owner.ShowMessageAsync("Hello!", "Welcome to the world of metro!" + string.Join(Environment.NewLine, "abc", "def", "ghi", "jkl", "mno", "pqr", "stu", "vwx", "yz"),
                MessageDialogStyle.AffirmativeAndNegativeAndSingleAuxiliary, mySettings);

            if (result != MessageDialogResult.FirstAuxiliary)
                await owner.ShowMessageAsync("Result", "You said: " + (result == MessageDialogResult.Affirmative ? mySettings.AffirmativeButtonText : mySettings.NegativeButtonText +
                    Environment.NewLine + Environment.NewLine + "This dialog will follow the Use Accent setting."));
        }

        //public static async Task ShowCustomDialog(MetroWindow owner)
        //{
        //    var dialog = (BaseMetroDialog)owner.Resources["CustomDialogTest"];
        //    await owner.ShowMetroDialogAsync(dialog);
        //    var textBlock = dialog.FindChild<TextBlock>("MessageTextBlock");
        //    textBlock.Text = "A message box will appear in 3 seconds.";
        //    await System.Threading.Tasks.TaskEx.Delay(3000);
        //    await owner.ShowMessageAsync("Secondary dialog", "This message is shown on top of another.");
        //    textBlock.Text = "The dialog will close in 2 seconds.";
        //    await TaskEx.Delay(2000);
        //    await owner.HideMetroDialogAsync(dialog);
        //}

        //public static async Task ShowAwaitCustomDialog(MetroWindow owner)
        //{
        //    EventHandler<DialogStateChangedEventArgs> dialogManagerOnDialogOpened = null;
        //    dialogManagerOnDialogOpened = (o, args) =>
        //    {
        //        DialogManager.DialogOpened -= dialogManagerOnDialogOpened;
        //        Console.WriteLine("Custom Dialog opened!");
        //    };
        //    DialogManager.DialogOpened += dialogManagerOnDialogOpened;
        //    EventHandler<DialogStateChangedEventArgs> dialogManagerOnDialogClosed = null;
        //    dialogManagerOnDialogClosed = async (o, args) =>
        //    {
        //        DialogManager.DialogClosed -= dialogManagerOnDialogClosed;
        //        Console.WriteLine("Custom Dialog closed!");
        //        await owner.ShowMessageAsync("Dialog gone", "The custom dialog has closed");
        //    };
        //    DialogManager.DialogClosed += dialogManagerOnDialogClosed;
        //    var dialog = (BaseMetroDialog)owner.Resources["CustomCloseDialogTest"];
        //    await owner.ShowMetroDialogAsync(dialog);
        //    await dialog.WaitUntilUnloadedAsync();
        //}

        //public static async Task CloseCustomDialog(MetroWindow owner)
        //{
        //    var dialog = (BaseMetroDialog)owner.Resources["CustomCloseDialogTest"];
        //    await owner.HideMetroDialogAsync(dialog);
        //}

        /// <summary>
        /// 登录密码弹框 
        /// </summary>
        /// <param name="owner"></param>
        /// <param name="metroDialogOptions"></param>
        /// <param name="userName"></param>
        /// <param name="action">录入密码后的回调</param>
        /// <returns></returns>
        public static async Task ShowLoginDialogPasswordPreview(MetroWindow owner, MetroDialogSettings metroDialogOptions,string userName,Action<string,string> action)
        {
            LoginDialogData result = await owner.ShowLoginAsync("Authentication", "请输入你的密码", new LoginDialogSettings { ColorScheme = metroDialogOptions.ColorScheme, InitialUsername = userName, EnablePasswordPreview = true });
            if (result == null)
            {
                //User pressed cancel
            }
            else
            {
                action?.BeginInvoke(result.Username, result.Password,null,null);
               // MessageDialogResult messageResult = await owner.ShowMessageAsync("Authentication Information", String.Format("Username: {0}\nPassword: {1}", result.Username, result.Password));
            }
        }

        public static async Task ShowLoginDialogOnlyPassword(MetroWindow owner, MetroDialogSettings metroDialogOptions,Action<string> action)
        {
            LoginDialogData result = await owner.ShowLoginAsync("Authentication", "Enter your password", new LoginDialogSettings { ColorScheme = metroDialogOptions.ColorScheme, ShouldHideUsername = true });
            if (result == null)
            {
                //User pressed cancel
            }
            else
            {
                action?.BeginInvoke(result.Password,null,null);
                //MessageDialogResult messageResult = await owner.ShowMessageAsync("Authentication Information", String.Format("Password: {0}", result.Password));
            }
        }
        /// <summary>
        /// 带勾选是否保存的密码登录框
        /// </summary>
        /// <param name="owner"></param>
        /// <param name="metroDialogOptions"></param>
        /// <param name="action"></param>
        /// <returns></returns>
        public static async Task ShowLoginDialogWithRememberCheckBox(MetroWindow owner, MetroDialogSettings metroDialogOptions, Action<string, string> action)
        {
            LoginDialogData result = await owner.ShowLoginAsync("Authentication", "Enter your password", new LoginDialogSettings { ColorScheme = metroDialogOptions.ColorScheme, RememberCheckBoxVisibility = Visibility.Visible });
            if (result == null)
            {
                //User pressed cancel
            }
            else
            {
                action?.BeginInvoke(result.Username, result.Password,null,null);
                //MessageDialogResult messageResult = await owner.ShowMessageAsync("Authentication Information", String.Format("Username: {0}\nPassword: {1}\nShouldRemember: {2}", result.Username, result.Password, result.ShouldRemember));
            }
        }
        /// <summary>
        /// 带等待进度的弹窗，时间到了就自动关闭
        /// </summary>
        /// <param name="owner"></param>
        /// <returns></returns>
        public static async Task ShowProgressDialog(MetroWindow owner)
        {
            var mySettings = new MetroDialogSettings()
            {
                NegativeButtonText = "Close now",
                AnimateShow = false,
                AnimateHide = false
            };
            var controller = await owner.ShowProgressAsync("Please wait...", "We are baking some cupcakes!", settings: mySettings);
            controller.SetIndeterminate();
            await TaskEx.Delay(5000);
            controller.SetCancelable(true);
            double i = 0.0;
            while (i < 6.0)
            {
                double val = (i / 100.0) * 20.0;
                controller.SetProgress(val);
                controller.SetMessage("Baking cupcake: " + i + "...");
                if (controller.IsCanceled)
                    break; //canceled progressdialog auto closes.
                i += 1.0;
                await TaskEx.Delay(2000);
            }
            await controller.CloseAsync();
            if (controller.IsCanceled)
            {
                await owner.ShowMessageAsync("No cupcakes!", "You stopped baking!");
            }
            else
            {
                await owner.ShowMessageAsync("Cupcakes!", "Your cupcakes are finished! Enjoy!");
            }
        }

        /// <summary>
        /// 显示录入对话框
        /// </summary>
        /// <param name="owner">window宿主</param>
        /// <param name="title">标题</param>
        /// <param name="content">正文</param>
        /// <param name="action">录入完成后要执行的回调</param>
        /// <returns></returns>
        public static async Task ShowInputDialog(MetroWindow owner,string title,string content,Action<string> action)
        {
            var result = await owner.ShowInputAsync(title, content);
            if (result == null) //user pressed cancel
                return;
            await owner.ShowMessageAsync(title, title+" " + result + "!");
            action?.Invoke(result);
        }

        public static async Task ShowLoginDialog(MetroWindow owner, MetroDialogSettings metroDialogOptions)
        {
            LoginDialogData result = await owner.ShowLoginAsync("Authentication", "Enter your credentials", new LoginDialogSettings { ColorScheme = metroDialogOptions.ColorScheme, InitialUsername = "MahApps" });
            if (result == null)
            {
                //User pressed cancel
            }
            else
            {
                MessageDialogResult messageResult = await owner.ShowMessageAsync("Authentication Information", String.Format("Username: {0}\nPassword: {1}", result.Username, result.Password));
            }
        }

    }
}
