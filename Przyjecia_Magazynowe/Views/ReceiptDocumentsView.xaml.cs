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

namespace Przyjecia_Magazynowe.Views
{
	/// <summary>
	/// Logika interakcji dla klasy ReceiptDocumentsView.xaml
	/// </summary>
	public partial class ReceiptDocumentsView : UserControl
	{
		public ReceiptDocumentsView()
		{
			InitializeComponent();
		}
		private void OpenReceiptDocument(object sender, MouseButtonEventArgs e)
		{
			if (DataContext is ReceiptDocumentsViewModel receiptDocumentsViewModel && receiptDocumentsViewModel.SelectedReceiptDocument != null)
			{
				receiptDocumentsViewModel.OpenReceiptDocument();
			}
		}
	}
}
