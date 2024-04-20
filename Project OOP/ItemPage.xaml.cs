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
            Close(); // Sluit het huidige venster
        }

        private void LoadJson_Click(object sender, RoutedEventArgs e)
        {
            string jsonFilePath = @"C:\Users\timde\OneDrive\Bureaublad\data2.json"; //Waar het JSON bestant moet staan

            try
            {
                string json = File.ReadAllText(jsonFilePath);
                DataItem dataItem = JsonConvert.DeserializeObject<DataItem>(json); //deserialiseren  van JSON bestand

                // Toon de gegevens in de UI
                tbxDate.Text = $"Datum: {dataItem.Date}";
                tbxName.Text = $"Naam: {dataItem.Name}";
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Er is een fout opgetreden: {ex.Message}");
            }
        }
    }
}
