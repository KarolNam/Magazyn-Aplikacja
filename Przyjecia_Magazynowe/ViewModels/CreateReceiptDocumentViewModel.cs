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
	public class CreateReceiptDocumentViewModel : BaseViewModel
	{
		public ObservableCollection<ContractorModel> Contractors { get; set; }
		public ReceiptDocumentModel CreatedReceiptDocument { get; set; }
		private string _symbol;
		public string Symbol
		{
			get => _symbol;
			set
			{
				_symbol = value;
				OnPropertyChanged(nameof(Symbol));
			}
		}
		private int _contractorId;
		public int ContractorId
		{
			get => _contractorId;
			set
			{
				_contractorId = value;
				OnPropertyChanged(nameof(ContractorId));
			}
		}
		private ICollectionView _contractorsView;
		public ICollectionView ContractorsView
		{
			get => _contractorsView;
			set
			{
				_contractorsView = value;
				OnPropertyChanged(nameof(ContractorsView));
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
				ContractorsView.Refresh();
			}
		}
		public ICommand NavigateReceiptDocumentsCommand { get; set; }
		public ICommand CreateReceiptDocumentCommand { get; set; }

		public CreateReceiptDocumentViewModel(NavigationStore navigationStore)
		{
			LoadContractorsAsync();
			Symbol = "Symbol";
			ContractorId = 0;
			NavigateReceiptDocumentsCommand = new NavigateReceiptDocumentsCommand(navigationStore);
			CreateReceiptDocumentCommand = new RelayCommand(async () => await CreateReceiptDocumentAsync(navigationStore), CanCreate);
		}
		private void LoadContractorsAsync()
		{
			using (HttpClient client = new HttpClient())
			{
				var url = new Uri("https://localhost:7055/api/Contractors");
				var response = client.GetAsync(url).Result.Content.ReadAsStringAsync().Result;
				Contractors = JsonConvert.DeserializeObject<ObservableCollection<ContractorModel>>(response);

				ContractorsView = CollectionViewSource.GetDefaultView(Contractors);
				ContractorsView.Filter = FilterContractor;
			}
		}
		private bool FilterContractor(object obj)
		{
			if (obj is ContractorModel contractor)
			{
				return string.IsNullOrEmpty(FilterText) || contractor.Name?.IndexOf(FilterText, StringComparison.OrdinalIgnoreCase) >= 0;
			}
			return false;
		}
		private async Task CreateReceiptDocumentAsync(NavigationStore navigationStore)
		{
			using (HttpClient client = new HttpClient())
			{
				var url = new Uri($"https://localhost:7055/api/ReceiptDocuments");
				var date = DateTime.Now.ToString("yyyy-MM-ddTHH:mm:ss.fffZ");
				var jsonString = "{\"date\": " + "\"" + date + "\"" + ",\"symbol\": \"" + Symbol + "\"" + ",\"contractorId\": " + ContractorId + "}";
				var httpContent = new StringContent(jsonString, Encoding.UTF8, "application/json");
				var response = await client.PostAsync(url, httpContent);
				var responseBody = await response.Content.ReadAsStringAsync();
				CreatedReceiptDocument = JsonConvert.DeserializeObject<ReceiptDocumentModel>(responseBody);
				response.EnsureSuccessStatusCode();
				navigationStore.CurrentViewModel = new ReceiptDocumentViewModel(navigationStore, CreatedReceiptDocument.Id);
			}
		}
		private bool CanCreate() => !string.IsNullOrEmpty(Symbol) && Symbol != "Symbol" && ContractorId != 0;
	}
}
