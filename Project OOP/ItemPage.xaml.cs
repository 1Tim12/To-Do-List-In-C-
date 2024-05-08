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
    /// Interaction logic for ItemPage.xaml
    /// </summary>
    public partial class ItemPage : Window
    {
        public ItemPage()
        {
            InitializeComponent();
        }

        private void btnTerug_Click(object sender, RoutedEventArgs e)
        {
            DialogResult = true;
            Close();
        }

        private void LoadJson_Click(object sender, RoutedEventArgs e)
        {
            string jsonFilePath = @"C:\Users\timde\OneDrive\Bureaublad\data4.json"; // Pad naar JSON-bestand

            try
            {
                if (!File.Exists(jsonFilePath))
                {
                    MessageBox.Show($"Het bestand {jsonFilePath} bestaat niet.");
                    return;
                }
                string json = File.ReadAllText(jsonFilePath);

                // Controleer of de JSON-gegevens een array zijn
                if (!json.Trim().StartsWith("["))
                {
                    json = "[" + json + "]";
                }

                // Deserialiseer de JSON naar een lijst van Root-objecten
                List<Root> root = JsonConvert.DeserializeObject<List<Root>>(json);

                // Maak een lijst om de DataItems op te slaan
                List<DataItem> dataItems = new List<DataItem>();

                // Voeg de DataItems toe aan de lijst
                foreach (var rootItem in root)
                {
                    if (rootItem.existingData?.existingData != null)
                    {
                        dataItems.Add(rootItem.existingData.existingData);
                    }
                    if (rootItem.existingData?.NewData != null)
                    {
                        dataItems.Add(rootItem.existingData.NewData);
                    }
                    if (rootItem.NewData != null)
                    {
                        dataItems.Add(rootItem.NewData);
                    }
                }

                // Voeg de gegevens toe aan de ListBox
                ListBoxData.ItemsSource = dataItems;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Er is een fout opgetreden: {ex.Message}");
            }
        }

        private void ListBoxData_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            SharedData.SelectedDataItem = (DataItem)ListBoxData.SelectedItem;

            ItemAanpassen itemAanpassen = new ItemAanpassen();
            itemAanpassen.ShowDialog();
            DialogResult = true;
            Close();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            string jsonFilePath = @"C:\Users\timde\OneDrive\Bureaublad\data4.json"; // Pad naar JSON-bestand

            try
            {
                if (!File.Exists(jsonFilePath))
                {
                    MessageBox.Show($"Het bestand {jsonFilePath} bestaat niet.");
                    return;
                }
                string json = File.ReadAllText(jsonFilePath);

                // Controleer of de JSON-gegevens een array zijn
                if (!json.Trim().StartsWith("["))
                {
                    json = "[" + json + "]";
                }

                // Deserialiseer de JSON naar een lijst van DataItem objecten
                List<DataItem> dataItems = JsonConvert.DeserializeObject<List<DataItem>>(json);

                // Sla de items op in SharedData.DataItems
                SharedData.DataItems = dataItems;

                // Voeg de gegevens toe aan de ListBox
                ListBoxData.ItemsSource = dataItems;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Er is een fout opgetreden: {ex.Message}");
            }
        }
    }
}
