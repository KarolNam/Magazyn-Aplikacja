using Newtonsoft.Json;
using Przyjecia_Magazynowe.Commands;
using Przyjecia_Magazynowe.Models;
using Przyjecia_Magazynowe.Stores;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Diagnostics.Contracts;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;
using System.Windows.Input;

namespace Przyjecia_Magazynowe.ViewModels
{
	public class UpdateReceiptDocumentViewModel : BaseViewModel
	{
		public ReceiptDocumentModel ReceiptDocument { get; }
		public ObservableCollection<ContractorModel> Contractors { get; set; }
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
		public ICommand UpdateReceiptDocumentCommand { get; set; }
		public UpdateReceiptDocumentViewModel(ReceiptDocumentModel receiptDocument, NavigationStore navigationStore)
		{
			LoadContractorsAsync();
			ReceiptDocument = receiptDocument;
			NavigateReceiptDocumentsCommand = new NavigateReceiptDocumentsCommand(navigationStore);
			UpdateReceiptDocumentCommand = new RelayCommand(async () => await UpdateReceiptDocumentAsync(receiptDocument, navigationStore));
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
		private async Task UpdateReceiptDocumentAsync(ReceiptDocumentModel receiptDocument, NavigationStore navigationStore)
		{
			using (HttpClient client = new HttpClient())
			{
				var url = new Uri($"https://localhost:7055/api/ReceiptDocuments/{receiptDocument.Id}");
				var date = receiptDocument.Date.ToString("yyyy-MM-ddTHH:mm:ss.fffZ");
				var jsonString = "{\"date\": " + "\"" + date + "\"" + ",\"symbol\": \"" + receiptDocument.Symbol + "\"" + ",\"contractorId\": " + receiptDocument.ContractorId + "}";
				var httpContent = new StringContent(jsonString, Encoding.UTF8, "application/json");
				var response = await client.PutAsync(url, httpContent);
				response.EnsureSuccessStatusCode();
				navigationStore.CurrentViewModel = new ReceiptDocumentsViewModel(navigationStore);
			}
		}

	}
}
