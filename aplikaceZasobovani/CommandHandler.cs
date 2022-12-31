using LiteDB;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace aplikaceZasobovani
{
    public class CommandHandler : ICommand
    {
        private Action<object> _action;
        private Func<object, bool> _canExecute;
        public CommandHandler(Action<object> action, Func<object, bool> canExecute)
        {
            if (action == null) throw new ArgumentNullException(nameof(action));
            _action = action;
            _canExecute = canExecute ?? (x => true);
        }
        public CommandHandler(Action<object> action) : this(action, null)
        {
        }

        public event EventHandler CanExecuteChanged
        {
            add { CommandManager.RequerySuggested += value; }
            remove { CommandManager.RequerySuggested -= value; }
        }

        public bool CanExecute(object parameter)
        {
            return _canExecute(parameter);
        }

        public void Execute(object parameter)
        {
            _action(parameter);
        }
        public void Refresh()
        {
            CommandManager.InvalidateRequerySuggested();
        }
    }
}
