using Przyjecia_Magazynowe.Commands;
using Przyjecia_Magazynowe.Models;
using Przyjecia_Magazynowe.Stores;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Przyjecia_Magazynowe.ViewModels
{
	public class UpdateContractorViewModel : BaseViewModel
	{
		public ContractorModel Contractor { get; }
		public ICommand UpdateContractorCommand { get; }
		public ICommand NavigateContractorsCommand { get; set; }

		public UpdateContractorViewModel(ContractorModel contractor, NavigationStore navigationStore)
		{
			Contractor = contractor;
			NavigateContractorsCommand = new NavigateContractorsCommand(navigationStore);
			UpdateContractorCommand = new RelayCommand(async () => await UpdateContractorAsync(contractor, navigationStore));
		}

		private async Task UpdateContractorAsync(ContractorModel contractor, NavigationStore navigationStore)
		{
			using (HttpClient client = new HttpClient())
			{
				var url = new Uri($"https://localhost:7055/api/Contractors/{contractor.Id}");
				string safeName = contractor.Name.Replace("\"", "\\\"");
				var jsonString = "{\"symbol\": " + "\"" + contractor.Symbol + "\"" + ",\"name\": \"" + safeName + "\"}";
				var httpContent = new StringContent(jsonString, Encoding.UTF8, "application/json");
				var response = await client.PutAsync(url, httpContent);
				response.EnsureSuccessStatusCode();
				navigationStore.CurrentViewModel = new ContractorsViewModel(navigationStore);
			}
		}
	}
}
