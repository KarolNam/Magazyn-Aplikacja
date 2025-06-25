using Przyjecia_Magazynowe.Stores;
using Przyjecia_Magazynowe.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Przyjecia_Magazynowe.Commands
{
	public class NavigateCreateReceiptItemCommand : CommandBase
	{
		private readonly NavigationStore _navigationStore;
		private int _receiptDocumentId;
		private int _contractorId;

		public NavigateCreateReceiptItemCommand(NavigationStore navigationStore, int receiptDocumentId, int contractorId)
		{
			_navigationStore = navigationStore;
			_receiptDocumentId = receiptDocumentId;
			_contractorId = contractorId;
		}
		public NavigateCreateReceiptItemCommand(NavigationStore navigationStore, int receiptDocumentId)
		{
			_navigationStore = navigationStore;
			_receiptDocumentId = receiptDocumentId;
		}

		public override void Execute(object parameter)
		{
			if (_contractorId > 0)
				_navigationStore.CurrentViewModel = new CreateReceiptItemViewModel(_navigationStore, _receiptDocumentId, _contractorId);
			else
				_navigationStore.CurrentViewModel = new CreateReceiptItemViewModel(_navigationStore, _receiptDocumentId);
		}
	}
}
