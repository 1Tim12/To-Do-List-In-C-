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
using System.Windows.Shapes;

namespace Project_OOP
{
    /// <summary>
    /// Interaction logic for ItemAanpassen.xaml
    /// </summary>
    public partial class ItemAanpassen : Window
    {
        public ItemAanpassen()
        {
            InitializeComponent();

            DataItem selectedDataItem = SharedData.SelectedDataItem;
        }

        private void btnSave_Click(object sender, RoutedEventArgs e)
        {

        }

        private void btnDelete_Click(object sender, RoutedEventArgs e)
        {

        }

        public void Window_Loaded(object sender, RoutedEventArgs e)
        {
            try
            {
                if (SharedData.SelectedDataItem != null && SharedData.SelectedDataItem.Name != null && SharedData.SelectedDataItem.Date != null)
                {
                    tbxNameAanpassen.Text = SharedData.SelectedDataItem.Name.ToString();
                    tbxDateAanpassen.Text = SharedData.SelectedDataItem.Date.ToString();
                }
            }

            catch (Exception ex)
            {
                MessageBox.Show($"Er is een fout opgetreden: {ex.Message}");
            }
        }
    }
}
