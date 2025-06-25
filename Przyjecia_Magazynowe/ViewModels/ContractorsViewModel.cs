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
using System.Windows;
using System.Windows.Data;
using System.Windows.Input;

namespace Przyjecia_Magazynowe.ViewModels
{
	public class ContractorsViewModel : BaseViewModel
	{
		private readonly NavigationStore _navigationStore;
		public ObservableCollection<ContractorModel> Contractors { get; set; }
		private ContractorModel _selectedContractor;
		public ContractorModel SelectedContractor
		{
			get => _selectedContractor;
			set
			{
				_selectedContractor = value;
				OnPropertyChanged(nameof(SelectedContractor));
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
		public ICommand NavigateHomeCommand { get; set; }
		public ICommand NavigateCreateContractorCommand { get; set; }
		public ICommand UpdateContractorCommand { get; set; }
		public ContractorsViewModel(NavigationStore navigationStore)
		{
			_navigationStore = navigationStore;
			NavigateHomeCommand = new NavigateHomeCommand(navigationStore);
			NavigateCreateContractorCommand = new NavigateCreateContractorCommand(navigationStore);
			UpdateContractorCommand = new RelayCommand(UpdateSelectedContractor, CanUpdate);
			GetContractorList();
		}
		private void GetContractorList()
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
		private void UpdateSelectedContractor()
		{
			if (SelectedContractor != null)
			{
				_navigationStore.CurrentViewModel = new UpdateContractorViewModel(SelectedContractor, _navigationStore);
			}
		}
		private bool CanUpdate() => SelectedContractor != null;

		public void OpenContractorReceiptDocuments()
		{
			if (SelectedContractor != null)
			{
				_navigationStore.CurrentViewModel = new ContractorReceiptDocumentsViewModel(_navigationStore, SelectedContractor.Id);
			}
		}
	}
}
