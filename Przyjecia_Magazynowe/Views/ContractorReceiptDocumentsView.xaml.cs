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

namespace Przyjecia_Magazynowe.Views
{
	/// <summary>
	/// Logika interakcji dla klasy ContractorReceiptDocumentsView.xaml
	/// </summary>
	public partial class ContractorReceiptDocumentsView : UserControl
	{
		public ContractorReceiptDocumentsView()
		{
			InitializeComponent();
		}
		private void OpenReceiptDocument(object sender, MouseButtonEventArgs e)
		{
			if (DataContext is ContractorReceiptDocumentsViewModel contractorReceiptDocumentsViewModel && contractorReceiptDocumentsViewModel.SelectedReceiptDocument != null)
			{
				contractorReceiptDocumentsViewModel.OpenReceiptDocument();
			}
		}
	}
}
