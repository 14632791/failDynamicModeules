using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Input;

namespace UpdateClient.Common
{
    public class RelayCommand : ICommand
    {
        private readonly Action<object> _execute;
        private readonly Action _exeNoPara;

        private readonly Predicate<object> _canExecute;

        public RelayCommand(Action<object> execute)
        {
            _execute = execute;
        }

        public RelayCommand(Action execute)
        {
            this._exeNoPara = execute;
        }

        public RelayCommand(Action<object> execute, Predicate<object> canExecute)
        {
            if (execute == null)
            {
                throw new ArgumentNullException("execute");
            }
            _execute = execute;
            _canExecute = canExecute;
        }

        public bool CanExecute(object parameter)
        {
            //return true;//默认都可以执行
            if (this._canExecute != null)
                return this._canExecute(parameter);
            return true;
        }
        //命令能不能执行的状态发生改变时，通知命令的调用者
        public event EventHandler CanExecuteChanged
        {
            add
            {
                CommandManager.RequerySuggested += value;
            }
            remove
            {
                CommandManager.RequerySuggested -= value;
            }
        }
        //当命令执行是执行的方法
        public void Execute(object parameter)
        {
            if (this._execute != null)
                this._execute(parameter);
            if (this._exeNoPara != null)
                this._exeNoPara();
        }
    }
}
