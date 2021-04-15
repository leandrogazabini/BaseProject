using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace WptfTestWptfTest.Models
{

	public abstract class BaseCommand : System.Windows.Input.ICommand
	{
		public event EventHandler CanExecuteChanged;

		public virtual bool CanExecute(object parameter) => true;
		public abstract void Execute(object parameter);
		public void RaiseCanExecuteChanged()
		{
			CanExecuteChanged?.Invoke(this, EventArgs.Empty);
		}
	}

	public class SimpleCommand<T> : ICommand
	{
		public event EventHandler CanExecuteChanged;
		private Action<T> _action;

		public SimpleCommand(Action<T> action)
		{
			_action = action;
		}

		public bool CanExecute(object parameter) { return true; }

		public void Execute(object parameter)
		{
			if ((_action != null))
			{
				//var castParameter = (T)Convert.ChangeType(parameter, typeof(T));
				//_action(castParameter);
				var castParameter = (T)Convert.ChangeType(parameter, typeof(T));
				_action(castParameter);
			}
		}
	}

}
