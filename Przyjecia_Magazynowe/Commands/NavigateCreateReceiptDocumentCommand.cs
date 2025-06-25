using Przyjecia_Magazynowe.Stores;
using Przyjecia_Magazynowe.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Przyjecia_Magazynowe.Commands
{
	public class NavigateCreateReceiptDocumentCommand : CommandBase
	{
		private readonly NavigationStore _navigationStore;

		public NavigateCreateReceiptDocumentCommand(NavigationStore navigationStore)
		{
			_navigationStore = navigationStore;
		}

		public override void Execute(object parameter)
		{
			_navigationStore.CurrentViewModel = new CreateReceiptDocumentViewModel(_navigationStore);
		}
	}
}
