﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Przyjecia_Magazynowe.Commands
{
	public class RelayCommand : ICommand
	{
		private readonly Action _execute;
		private readonly Func<bool> _canExecute;

		public RelayCommand(Action execute)
		: this(execute, null)
		{
		}
		public RelayCommand(Action execute, Func<bool> canExecute)
		{
			_execute = execute ?? throw new ArgumentNullException(nameof(execute));
			_canExecute = canExecute;
		}

		public bool CanExecute(object parameter) => _canExecute?.Invoke() ?? true;

		public void Execute(object parameter) => _execute();

		public event EventHandler CanExecuteChanged
		{
			add => CommandManager.RequerySuggested += value;
			remove => CommandManager.RequerySuggested -= value;
		}

		public void RaiseCanExecuteChanged()
		{
			CommandManager.InvalidateRequerySuggested();
		}
	}
}
