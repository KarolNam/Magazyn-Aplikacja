using Przyjecia_Magazynowe.Commands;
using Przyjecia_Magazynowe.Stores;
using System;
using System.Collections.Generic;
using System.Diagnostics.Contracts;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Przyjecia_Magazynowe.ViewModels
{
	public class CreateContractorViewModel : BaseViewModel
	{
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
		private string _name;
		public string Name
		{
			get => _name;
			set
			{
				_name = value;
				OnPropertyChanged(nameof(Name));
			}
		}

		public ICommand NavigateContractorsCommand { get; set; }
		public ICommand CreateContractorCommand { get; set; }

		public CreateContractorViewModel(NavigationStore navigationStore)
		{
			Symbol = "Symbol";
			Name = "Nazwa";
			NavigateContractorsCommand = new NavigateContractorsCommand(navigationStore);
			CreateContractorCommand = new RelayCommand(async () => await CreateContractorAsync(navigationStore), CanCreate);
		}
		private async Task CreateContractorAsync(NavigationStore navigationStore)
		{
			using (HttpClient client = new HttpClient())
			{
				var url = new Uri($"https://localhost:7055/api/Contractors");
				string safeName = Name.Replace("\"", "\\\"");
				var jsonString = "{\"symbol\": " + "\"" + Symbol + "\"" + ",\"name\": \"" + safeName + "\"}";
				var httpContent = new StringContent(jsonString, Encoding.UTF8, "application/json");
				var response = await client.PostAsync(url, httpContent);
				response.EnsureSuccessStatusCode();
				navigationStore.CurrentViewModel = new ContractorsViewModel(navigationStore);
			}
		}

		private bool CanCreate() => !string.IsNullOrEmpty(Symbol) && Symbol != "Symbol" && !string.IsNullOrEmpty(Name) && Name != "Nazwa";

	}
}
