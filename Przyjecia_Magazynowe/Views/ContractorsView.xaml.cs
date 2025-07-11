﻿using Przyjecia_Magazynowe.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
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
	/// Logika interakcji dla klasy ContractorsView.xaml
	/// </summary>
	public partial class ContractorsView : UserControl
	{
		public ContractorsView()
		{
			InitializeComponent();
		}
		private void OpenContractorReceiptDocuments(object sender, MouseButtonEventArgs e)
		{
			if (DataContext is ContractorsViewModel contractorsViewModel && contractorsViewModel.SelectedContractor != null)
			{
				contractorsViewModel.OpenContractorReceiptDocuments();
			}
		}
	}
}
