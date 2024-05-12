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
using Newtonsoft.Json;
using System.Globalization;
using System.Xml.Linq;

namespace Project_OOP
{
    /// <summary>
    /// Interaction logic for AddItemWindow.xaml
    /// </summary>
    public partial class AddItemWindow : Window
    {
        public string _Date;
        public string _Name;
        public string _Data;
        public AddItemWindow()
        {
            InitializeComponent();
        }

        private void btnTerug_Click(object sender, RoutedEventArgs e)
        {
            DialogResult = true;
            Close(); // Sluit het huidige venster
        }

        private void btnCreateItem_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                // Maak een nieuw DataItem aan
                DataItem newDataItem = new DataItem();
                newDataItem.Name = tbxName.Text;
                try
                {
                    newDataItem.Date = DateTime.Parse(tbxDate.Text);
                }
                catch (FormatException)
                {
                    MessageBox.Show("Het formaat van de ingevoerde datum is ongeldig. Voer de datum in het juiste formaat in.");
                    return; // Stop hier als de datum ongeldig is
                }

                // Voeg het nieuwe item toe aan de lijst met gegevens
                SharedData.DataItems.Add(newDataItem);

                // Leeg het JSON-bestand
                string jsonFilePath = @"C:\Users\timde\OneDrive\Bureaublad\data4.json"; // Pad naar JSON-bestand
                File.WriteAllText(jsonFilePath, string.Empty);

                // Sla de volledige lijst van items op in het JSON-bestand
                string json = JsonConvert.SerializeObject(SharedData.DataItems, Newtonsoft.Json.Formatting.Indented);
                File.WriteAllText(jsonFilePath, json);

                MessageBox.Show("Item succesvol toegevoegd en opgeslagen.");
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Er is een fout opgetreden: {ex.Message}");
            }
        }
    }
}
