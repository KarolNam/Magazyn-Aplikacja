using Newtonsoft.Json;
using Przyjecia_Magazynowe.Commands;
using Przyjecia_Magazynowe.Models;
using Przyjecia_Magazynowe.Stores;
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
	public class UpdateReceiptItemViewModel : BaseViewModel
	{
		public ReceiptItemModel ReceiptItem { get; }
		private readonly int _contractorId;
		private ICollectionView _receiptDocumentsView;
		public ICollectionView ReceiptDocumentsView
		{
			get => _receiptDocumentsView;
			set
			{
				_receiptDocumentsView = value;
				OnPropertyChanged(nameof(ReceiptDocumentsView));
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
				ReceiptDocumentsView.Refresh();
			}
		}
		public ObservableCollection<ReceiptDocumentModel> ReceiptDocuments { get; set; }
		public ICommand NavigateReceiptDocumentCommand { get; set; }
		public ICommand UpdateReceiptItemCommand { get; set; }
		public UpdateReceiptItemViewModel(NavigationStore navigationStore, ReceiptItemModel receiptItem, int contractorId)
		{
			LoadReceiptDocuments();
			ReceiptItem = receiptItem;
			_contractorId = contractorId;
			NavigateReceiptDocumentCommand = new NavigateReceiptDocumentCommand(navigationStore, receiptItem.ReceiptDocumentId, contractorId);
			UpdateReceiptItemCommand = new RelayCommand(async () => await UpdateReceiptItemAsync(navigationStore, receiptItem));
		}
		public UpdateReceiptItemViewModel(NavigationStore navigationStore, ReceiptItemModel receiptItem)
        {
			LoadReceiptDocuments();
            ReceiptItem = receiptItem;
			NavigateReceiptDocumentCommand = new NavigateReceiptDocumentCommand(navigationStore, receiptItem.ReceiptDocumentId);
			UpdateReceiptItemCommand = new RelayCommand(async () => await UpdateReceiptItemAsync(navigationStore, receiptItem));
        }
		private void LoadReceiptDocuments()
		{
			using (HttpClient client = new HttpClient())
			{
				var url = new Uri("https://localhost:7055/api/ReceiptDocuments");
				var response = client.GetAsync(url).Result.Content.ReadAsStringAsync().Result;
				ReceiptDocuments = JsonConvert.DeserializeObject<ObservableCollection<ReceiptDocumentModel>>(response);

				ReceiptDocumentsView = CollectionViewSource.GetDefaultView(ReceiptDocuments);
				ReceiptDocumentsView.Filter = FilterReceiptDocument;
			}
		}
		private bool FilterReceiptDocument(object obj)
		{
			if (obj is ReceiptDocumentModel receiptDocument)
			{
				return string.IsNullOrEmpty(FilterText) || receiptDocument.Symbol?.IndexOf(FilterText, StringComparison.OrdinalIgnoreCase) >= 0;
			}
			return false;
		}
		private async Task UpdateReceiptItemAsync(NavigationStore navigationStore, ReceiptItemModel receiptItem)
		{
			using (HttpClient client = new HttpClient())
			{
				var url = new Uri($"https://localhost:7055/api/ReceiptItems/{receiptItem.Id}");
				string safeName = receiptItem.ProductName.Replace("\"", "\\\"");
				string safeQuantity = receiptItem.Quantity.ToString().Replace(',', '.');
				var jsonString = "{\"productName\": " + "\"" + safeName + "\"" + ",\"unit\": \"" + receiptItem.Unit + "\"" + ",\"quantity\": " + safeQuantity + ",\"receiptDocumentId\": " + receiptItem.ReceiptDocumentId + "}";
				var httpContent = new StringContent(jsonString, Encoding.UTF8, "application/json");
				var response = await client.PutAsync(url, httpContent);
				response.EnsureSuccessStatusCode();
				if (_contractorId > 0)
					navigationStore.CurrentViewModel = new ReceiptDocumentViewModel(navigationStore, receiptItem.ReceiptDocumentId, _contractorId);
				else
					navigationStore.CurrentViewModel = new ReceiptDocumentViewModel(navigationStore, receiptItem.ReceiptDocumentId);
			}
		}
    }
}
