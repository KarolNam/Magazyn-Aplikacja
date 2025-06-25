using Przyjecia_Magazynowe.Commands;
using Przyjecia_Magazynowe.Stores;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using System.Xml.Linq;

namespace Przyjecia_Magazynowe.ViewModels
{
	public class CreateReceiptItemViewModel : BaseViewModel
	{
		private readonly int _contractorId;
		private string _productName;
		public string ProductName
		{
			get => _productName;
			set
			{
				_productName = value;
				OnPropertyChanged(nameof(ProductName));
			}
		}
		private string _unit;
		public string Unit
		{
			get => _unit;
			set
			{
				_unit = value;
				OnPropertyChanged(nameof(Unit));
			}
		}
		private decimal _quantity;
		public decimal Quantity
		{
			get => _quantity;
			set
			{
				_quantity = value;
				OnPropertyChanged(nameof(Quantity));
			}
		}
		public ICommand NavigateReceiptDocumentCommand { get; set; }
		public ICommand CreateReceiptItemCommand { get; set; }
		public CreateReceiptItemViewModel(NavigationStore navigationStore, int receiptDocumentId, int contractorId)
		{
			ProductName = "Nazwa produktu";
			Unit = "Jednostka miary";
			Quantity = 0;
			_contractorId = contractorId;
			NavigateReceiptDocumentCommand = new NavigateReceiptDocumentCommand(navigationStore, receiptDocumentId, contractorId);
			CreateReceiptItemCommand = new RelayCommand(async () => await CreateReceiptItemAsync(navigationStore, receiptDocumentId), CanCreate);
		}
		public CreateReceiptItemViewModel(NavigationStore navigationStore, int receiptDocumentId)
        {
			ProductName = "Nazwa produktu";
			Unit = "Jednostka miary";
			Quantity = 0;
			NavigateReceiptDocumentCommand = new NavigateReceiptDocumentCommand(navigationStore, receiptDocumentId);
			CreateReceiptItemCommand = new RelayCommand(async () => await CreateReceiptItemAsync(navigationStore, receiptDocumentId), CanCreate);
		}
		private async Task CreateReceiptItemAsync(NavigationStore navigationStore, int receiptDocumentId)
		{
			using (HttpClient client = new HttpClient())
			{
				var url = new Uri($"https://localhost:7055/api/ReceiptItems");
				string safeName = ProductName.Replace("\"", "\\\"");
				string safeQuantity = Quantity.ToString().Replace(',', '.');
				var jsonString = "{\"productName\": " + "\"" + safeName + "\"" + ",\"unit\": \"" + Unit + "\"" + ",\"quantity\": " + safeQuantity + ",\"receiptDocumentId\": " + receiptDocumentId + "}";
				var httpContent = new StringContent(jsonString, Encoding.UTF8, "application/json");
				var response = await client.PostAsync(url, httpContent);
				response.EnsureSuccessStatusCode();
				if (_contractorId > 0)
					navigationStore.CurrentViewModel = new ReceiptDocumentViewModel(navigationStore, receiptDocumentId, _contractorId);
				else
					navigationStore.CurrentViewModel = new ReceiptDocumentViewModel(navigationStore, receiptDocumentId);
			}
		}
		private bool CanCreate() => !string.IsNullOrEmpty(ProductName) && ProductName != "Nazwa produktu" && !string.IsNullOrEmpty(Unit) && Unit != "Jednostka miary" && Quantity != 0;
    }
}
