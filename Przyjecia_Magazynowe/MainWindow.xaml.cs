using Przyjecia_Magazynowe.Commands;
using Przyjecia_Magazynowe.Stores;
using Przyjecia_Magazynowe.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Przyjecia_Magazynowe
{
	public partial class MainWindow : Window
	{
		public MainWindow()
		{
			InitializeComponent();
			NavigationStore navigationStore = new NavigationStore();

			navigationStore.CurrentViewModel = new HomeViewModel(navigationStore);

			DataContext = new MainViewModel(navigationStore);
		}
	}
}
