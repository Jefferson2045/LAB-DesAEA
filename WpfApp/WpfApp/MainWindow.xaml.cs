using Bussines;
using Data;
using Entity;
using System;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;

namespace WpfApp
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        BInvoice bInvoice = new BInvoice();

        public MainWindow()
        {
            InitializeComponent();
            ListInvoice();
        }

        private void DeleteInvoice(object sender, RoutedEventArgs e)
        {
            int invoiceId = (int)((Button)sender).CommandParameter;
            bInvoice.DeleteInvoice(invoiceId);
            ListInvoice();
        }

        private void ListInvoiceByDate(object sender, RoutedEventArgs e)
        {
            DateTime selectedDate = datepicker.SelectedDate ?? DateTime.Now;
            Console.WriteLine(selectedDate);
            List<Invoice> invoices = bInvoice.GetByDate(selectedDate);
            dataGrid.ItemsSource = invoices;
        }

        private void ListInvoice() {
            List<Invoice> invoices = bInvoice.GetInvoiceActives();
            dataGrid.ItemsSource = invoices;
        }

        private void Listar(object sender, RoutedEventArgs e)
        {
            ListInvoice();
        }
    }
}
