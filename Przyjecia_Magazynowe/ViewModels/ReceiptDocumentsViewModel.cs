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
	public class ReceiptDocumentsViewModel : BaseViewModel
	{
		private readonly NavigationStore _navigationStore;
		public ObservableCollection<ReceiptDocumentModel> ReceiptDocuments { get; set; }
		private ReceiptDocumentModel _selectedReceiptDocument;
		public ReceiptDocumentModel SelectedReceiptDocument
		{
			get => _selectedReceiptDocument;
			set
			{
				_selectedReceiptDocument = value;
				OnPropertyChanged(nameof(SelectedReceiptDocument));
			}
		}
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
		public ICommand NavigateHomeCommand { get; set; }
		public ICommand NavigateCreateReceiptDocumentCommand { get; set; }
		public ICommand UpdateReceiptDocumentCommand { get; set; }
		public ReceiptDocumentsViewModel(NavigationStore navigationStore)
		{
			_navigationStore = navigationStore;
			NavigateHomeCommand = new NavigateHomeCommand(navigationStore);
			NavigateCreateReceiptDocumentCommand = new NavigateCreateReceiptDocumentCommand(navigationStore);
			UpdateReceiptDocumentCommand = new RelayCommand(UpdateSelectedReceiptDocument, CanUpdate);
			GetReceiptDocumentList();
		}
		private void GetReceiptDocumentList()
		{
			using (HttpClient client = new HttpClient())
			{
				var url = new Uri("https://localhost:7055/api/ReceiptDocuments");
				var result = client.GetAsync(url).Result.Content.ReadAsStringAsync().Result;
				ReceiptDocuments = JsonConvert.DeserializeObject<ObservableCollection<ReceiptDocumentModel>>(result);

				ReceiptDocumentsView = CollectionViewSource.GetDefaultView(ReceiptDocuments);
				ReceiptDocumentsView.Filter = FilterReceiptDocuments;
			}
		}
		private bool FilterReceiptDocuments(object obj)
		{
			if (obj is ReceiptDocumentModel receiptDocument)
			{
				return string.IsNullOrEmpty(FilterText) || receiptDocument.Symbol?.IndexOf(FilterText, StringComparison.OrdinalIgnoreCase) >= 0;
			}
			return false;
		}
		private void UpdateSelectedReceiptDocument()
		{
			if (SelectedReceiptDocument != null)
			{
				_navigationStore.CurrentViewModel = new UpdateReceiptDocumentViewModel(SelectedReceiptDocument, _navigationStore);
			}
		}
		private bool CanUpdate() => SelectedReceiptDocument != null;
		public void OpenReceiptDocument()
		{
			if (SelectedReceiptDocument != null)
			{
				_navigationStore.CurrentViewModel = new ReceiptDocumentViewModel(_navigationStore, SelectedReceiptDocument.Id);
			}
		}
	}
}
