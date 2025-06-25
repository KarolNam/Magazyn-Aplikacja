using Przyjecia_Magazynowe.Stores;
using Przyjecia_Magazynowe.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Przyjecia_Magazynowe.Commands
{
	public class NavigateContractorReceiptDocumentsCommand : CommandBase
	{
		private readonly NavigationStore _navigationStore;
		private readonly int _contractorId;

		public NavigateContractorReceiptDocumentsCommand(NavigationStore navigationStore, int contractorId)
		{
			_navigationStore = navigationStore;
			_contractorId = contractorId;
		}

		public override void Execute(object parameter)
		{
			_navigationStore.CurrentViewModel = new ContractorReceiptDocumentsViewModel(_navigationStore, _contractorId);
		}
	}
}
