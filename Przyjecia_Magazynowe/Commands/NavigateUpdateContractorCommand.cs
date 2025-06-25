using Przyjecia_Magazynowe.Models;
using Przyjecia_Magazynowe.Stores;
using Przyjecia_Magazynowe.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Przyjecia_Magazynowe.Commands
{
	public class NavigateUpdateContractorCommand : CommandBase
	{
		private readonly NavigationStore _navigationStore;
		private readonly ContractorModel _contractor;

		public NavigateUpdateContractorCommand(NavigationStore navigationStore, ContractorModel contractor)
		{
			_contractor = contractor;
			_navigationStore = navigationStore;
		}

		public override void Execute(object parameter)
		{
			_navigationStore.CurrentViewModel = new UpdateContractorViewModel(_contractor, _navigationStore);
		}
	}
}
