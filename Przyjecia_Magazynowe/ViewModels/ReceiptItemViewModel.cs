using Przyjecia_Magazynowe.Commands;
using Przyjecia_Magazynowe.Models;
using Przyjecia_Magazynowe.Stores;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Przyjecia_Magazynowe.ViewModels
{
	public class ReceiptItemViewModel : BaseViewModel
	{
		private readonly NavigationStore _navigationStore;
		private readonly int _contractorId;
		public ReceiptItemModel ReceiptItem { get; set; }
		public ICommand NavigateReceiptDocumentCommand { get; set; }
		public ICommand UpdateReceiptItemCommand { get; set; }
		public ReceiptItemViewModel(NavigationStore navigationStore, ReceiptItemModel receiptItem, int contractorId)
		{
			_navigationStore = navigationStore;
			_contractorId = contractorId;
			ReceiptItem = receiptItem;
			NavigateReceiptDocumentCommand = new NavigateReceiptDocumentCommand(navigationStore, receiptItem.ReceiptDocumentId, contractorId);
			UpdateReceiptItemCommand = new RelayCommand(UpdateReceiptItem);
		}
		public ReceiptItemViewModel(NavigationStore navigationStore, ReceiptItemModel receiptItem)
        {
			_navigationStore = navigationStore;
            ReceiptItem = receiptItem;
			NavigateReceiptDocumentCommand = new NavigateReceiptDocumentCommand(navigationStore, receiptItem.ReceiptDocumentId);
			UpdateReceiptItemCommand = new RelayCommand(UpdateReceiptItem);
        }
		private void UpdateReceiptItem()
		{
			if (_contractorId > 0)
				_navigationStore.CurrentViewModel = new UpdateReceiptItemViewModel(_navigationStore, ReceiptItem, _contractorId);
			else
				_navigationStore.CurrentViewModel = new UpdateReceiptItemViewModel(_navigationStore, ReceiptItem);
		}
    }
}
