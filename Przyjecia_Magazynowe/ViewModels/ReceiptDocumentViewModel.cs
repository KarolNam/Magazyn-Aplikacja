using Newtonsoft.Json;
using Przyjecia_Magazynowe.Commands;
using Przyjecia_Magazynowe.Models;
using Przyjecia_Magazynowe.Stores;
using Przyjecia_Magazynowe.Views;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;
using System.Windows.Input;

namespace Przyjecia_Magazynowe.ViewModels
{
	public class ReceiptDocumentViewModel : BaseViewModel
	{
		private readonly NavigationStore _navigationStore;
		private readonly int _contractorId;
		public ObservableCollection<ReceiptItemModel> ReceiptItems { get; set; }
		private ReceiptItemModel _selectedReceiptItem;
		public ReceiptItemModel SelectedReceiptItem
		{
			get => _selectedReceiptItem;
			set
			{
				_selectedReceiptItem = value;
				OnPropertyChanged(nameof(SelectedReceiptItem));
			}
		}
		private ICollectionView _receiptItemsView;
		public ICollectionView ReceiptItemsView
		{
			get => _receiptItemsView;
			set
			{
				_receiptItemsView = value;
				OnPropertyChanged(nameof(ReceiptItemsView));
			}
		}
		private string _filterText;
		public string FilterText
		{
			get => _filterText;
			set
			{
				_filterText = value;
				OnPropertyChanged(nameof(FilterText));
				ReceiptItemsView.Refresh();
			}
		}
		public ICommand NavigateReceiptDocumentsCommand { get; set; }
		public ICommand NavigateCreateReceiptItemCommand { get; set; }
		public ICommand UpdateReceiptItemCommand { get; set; }
		public ReceiptDocumentViewModel(NavigationStore navigationStore, int receiptDocumentId, int contractorId)
		{
			_navigationStore = navigationStore;
			_contractorId = contractorId;
			NavigateReceiptDocumentsCommand = new NavigateContractorReceiptDocumentsCommand(navigationStore, contractorId);
			NavigateCreateReceiptItemCommand = new NavigateCreateReceiptItemCommand(navigationStore, receiptDocumentId, contractorId);
			UpdateReceiptItemCommand = new RelayCommand(UpdateSelectedReceiptItem, CanUpdate);
			GetReceiptItemList(receiptDocumentId);
		}
		public ReceiptDocumentViewModel(NavigationStore navigationStore, int receiptDocumentId)
		{
			_navigationStore = navigationStore;
			NavigateReceiptDocumentsCommand = new NavigateReceiptDocumentsCommand(navigationStore);
			NavigateCreateReceiptItemCommand = new NavigateCreateReceiptItemCommand(navigationStore, receiptDocumentId);
			UpdateReceiptItemCommand = new RelayCommand(UpdateSelectedReceiptItem, CanUpdate);
			GetReceiptItemList(receiptDocumentId);
		}
		private void GetReceiptItemList(int receiptDocumentId)
		{
			using (HttpClient client = new HttpClient())
			{
				var url = new Uri($"https://localhost:7055/api/ReceiptItems/ReceiptDocument{receiptDocumentId}");
				var response = client.GetAsync(url).Result.Content.ReadAsStringAsync().Result;
				ReceiptItems = JsonConvert.DeserializeObject<ObservableCollection<ReceiptItemModel>>(response);

				ReceiptItemsView = CollectionViewSource.GetDefaultView(ReceiptItems);
				ReceiptItemsView.Filter = FilterReceiptItems;
			}
		}
		private bool FilterReceiptItems(object obj)
		{
			if (obj is ReceiptItemModel receiptItem)
			{
				return string.IsNullOrEmpty(FilterText) || receiptItem.ProductName?.IndexOf(FilterText, StringComparison.OrdinalIgnoreCase) >= 0;
			}
			return false;
		}
		private void UpdateSelectedReceiptItem()
		{
			if (SelectedReceiptItem != null)
			{
				if (_contractorId > 0)
					_navigationStore.CurrentViewModel = new UpdateReceiptItemViewModel(_navigationStore, SelectedReceiptItem, _contractorId);
				else
					_navigationStore.CurrentViewModel = new UpdateReceiptItemViewModel(_navigationStore, SelectedReceiptItem);
			}
		}
		private bool CanUpdate() => SelectedReceiptItem != null;
		public void OpenReceiptItem()
		{
			if (SelectedReceiptItem != null)
			{
				if (_contractorId > 0)
					_navigationStore.CurrentViewModel = new ReceiptItemViewModel(_navigationStore, SelectedReceiptItem, _contractorId);
				else
					_navigationStore.CurrentViewModel = new ReceiptItemViewModel(_navigationStore, SelectedReceiptItem);
			}
		}
	}
}
