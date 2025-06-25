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
	public class ContractorReceiptDocumentsViewModel : BaseViewModel
	{
		private readonly NavigationStore _navigationStore;
		private readonly int _contractorId;
        public ObservableCollection<ContractorReceiptDocumentsModel> ReceiptDocuments { get; set; }
		private ICollectionView _contractorReceiptDocumentsView;
		public ICollectionView ContractorReceiptDocumentsView
		{
			get => _contractorReceiptDocumentsView;
			set
			{
				_contractorReceiptDocumentsView = value;
				OnPropertyChanged(nameof(ContractorReceiptDocumentsView));
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
				ContractorReceiptDocumentsView.Refresh();
			}
		}
		public ContractorReceiptDocumentsModel SelectedReceiptDocument { get; set; }
		public ICommand NavigateContractorsCommand { get; set; }
        public ContractorReceiptDocumentsViewModel(NavigationStore navigationStore, int contractorId)
        {
			_navigationStore = navigationStore;
			_contractorId = contractorId;
			NavigateContractorsCommand = new NavigateContractorsCommand(navigationStore);
            GetReceiptDocumentList(contractorId);
        }
		private void GetReceiptDocumentList(int contractorId)
		{
			using (HttpClient client = new HttpClient())
			{
				var url = new Uri($"https://localhost:7055/api/ReceiptDocuments/ContractorDocuments{contractorId}");
				var response = client.GetAsync(url).Result.Content.ReadAsStringAsync().Result;
				ReceiptDocuments = JsonConvert.DeserializeObject<ObservableCollection<ContractorReceiptDocumentsModel>>(response);

				ContractorReceiptDocumentsView = CollectionViewSource.GetDefaultView(ReceiptDocuments);
				ContractorReceiptDocumentsView.Filter = FilterContractorReceiptDocuments;
			}
		}
		private bool FilterContractorReceiptDocuments(object obj)
		{
			if (obj is ContractorReceiptDocumentsModel contractorReceiptDocument)
			{
				return string.IsNullOrEmpty(FilterText) || contractorReceiptDocument.Symbol?.IndexOf(FilterText, StringComparison.OrdinalIgnoreCase) >= 0;
			}
			return false;
		}
		public void OpenReceiptDocument()
		{
			if (SelectedReceiptDocument != null)
			{
				_navigationStore.CurrentViewModel = new ReceiptDocumentViewModel(_navigationStore, SelectedReceiptDocument.Id, _contractorId);
			}
		}
	}
}
