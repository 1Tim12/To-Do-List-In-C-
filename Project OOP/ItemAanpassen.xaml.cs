using Newtonsoft.Json;
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
using System.IO;

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
            try
            {
                // Haal de geselecteerde item op
                DataItem selectedDataItem = SharedData.SelectedDataItem;

                // Pas de waarden van de geselecteerde item aan
                selectedDataItem.Name = tbxNameAanpassen.Text;
                try
                {
                    selectedDataItem.Date = DateTime.Parse(tbxDateAanpassen.Text);
                }
                catch (FormatException)
                {
                    MessageBox.Show("Het formaat van de ingevoerde datum is ongeldig. Voer de datum in het juiste formaat in.");
                    return; // Stop hier als de datum ongeldig is
                }

                // Sla de volledige lijst van items op in het JSON-bestand
                string jsonFilePath = @"C:\Users\timde\OneDrive\Bureaublad\data4.json"; // Pad naar JSON-bestand
                string json = JsonConvert.SerializeObject(SharedData.DataItems, Newtonsoft.Json.Formatting.Indented);
                File.WriteAllText(jsonFilePath, json);

                MessageBox.Show("Item succesvol aangepast en opgeslagen.");
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Er is een fout opgetreden: {ex.Message}");
            }
            Close();
        }

        private void btnDelete_Click(object sender, RoutedEventArgs e)
        {
            var Result = MessageBox.Show($"Bent u zeker dat u het item \"{SharedData.SelectedDataItem.Name}\" wilt verwijderen?", "Verwijderen", MessageBoxButton.YesNo, MessageBoxImage.Question);

            if (Result == MessageBoxResult.Yes)
            {
                MessageBox.Show("Het item is verwijderd");
            }
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
