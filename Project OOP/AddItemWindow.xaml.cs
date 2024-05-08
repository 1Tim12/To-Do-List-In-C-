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
            // Bestandsnaam en pad waar de JSON naar toe geschreven moet worden
            string jsonFilePath = @"C:\Users\timde\OneDrive\Bureaublad\data4.json";

            // Te schrijven data
            var newData = new
            {
                Name = tbxName.Text,
                Date = tbxDate.Text
            };

            try
            {
                // Controleren of het bestand bestaat
                if (File.Exists(jsonFilePath))
                {
                    // JSON-bestand lezen en bestaande gegevens ophalen
                    var existingData = JsonConvert.DeserializeObject<dynamic>(File.ReadAllText(jsonFilePath));

                    // Controleer of er al gegevens zijn
                    if (existingData != null)
                    {
                        // Voeg de nieuwe data toe aan de bestaande data
                        var mergedData = new
                        {
                            ExistingData = existingData,
                            NewData = newData
                        };

                        if (tbxDate.Text != string.Empty && tbxName.Text != string.Empty)
                        {
                            // Serializeer de gecombineerde data naar JSON
                            string json = JsonConvert.SerializeObject(mergedData, Newtonsoft.Json.Formatting.Indented);

                            // Schrijf de JSON naar het bestand
                            File.WriteAllText(jsonFilePath, json);
                        }

                        else
                            MessageBox.Show("Geef een naam en een datum");

                        MessageBox.Show("Gegevens geschreven");
                    }
                }
                else
                {
                    // Als het bestand niet bestaat, schrijf de nieuwe data naar een nieuw bestand
                    string json = JsonConvert.SerializeObject(newData, Newtonsoft.Json.Formatting.Indented);
                    File.WriteAllText(jsonFilePath, json);

                    MessageBox.Show("JSON-bestand aangemaakt met de nieuwe gegevens.");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Er is een fout opgetreden: {ex.Message}");
            }
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            //string jsonFilePath = @"C:\Users\timde\OneDrive\Bureaublad\data4.json"; //Waar het JSON bestant moet staan

            //try
            //{
            //    string json = File.ReadAllText(jsonFilePath);
            //    DataItem dataItem = JsonConvert.DeserializeObject<DataItem>(json); //deserialiseren  van JSON bestand

            //    // Toon de gegevens in de UI
            //    _Date = $"Datum: {dataItem.Date}";
            //    _Name = $"Naam: {dataItem.Name}";
            //}
            //catch (Exception ex)
            //{
            //    MessageBox.Show($"Er is een fout opgetreden: {ex.Message}");
            //}
        }
    }
}
