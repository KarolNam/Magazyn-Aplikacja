using Przyjecia_Magazynowe.Commands;
using Przyjecia_Magazynowe.Stores;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Przyjecia_Magazynowe.ViewModels
{
	public class HomeViewModel : BaseViewModel
	{
		public ICommand NavigateContractorsCommand { get; set; }
		public ICommand NavigateReceiptDocumentsCommand { get; set; }

        public HomeViewModel(NavigationStore navigationStore)
        {
            NavigateContractorsCommand = new NavigateContractorsCommand(navigationStore);
            NavigateReceiptDocumentsCommand = new NavigateReceiptDocumentsCommand(navigationStore);
        }
    }
}
