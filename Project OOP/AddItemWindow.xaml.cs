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

namespace Project_OOP
{
    /// <summary>
    /// Interaction logic for AddItemWindow.xaml
    /// </summary>
    public partial class AddItemWindow : Window
    {
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
            // Controleer of de tekstvakken leeg zijn
            if (string.IsNullOrWhiteSpace(tbxDate.Text) || string.IsNullOrWhiteSpace(tbxName.Text))
            {
                MessageBox.Show("Voer een datum en een naam in.");
                return;
            }

            DataItem dataItem = null; // Declareren buiten het try-blok ander bestaat het zogezegd niet

            try
            {
                DateTime date;
                if (!DateTime.TryParseExact(tbxDate.Text, "d/M/yyyy", CultureInfo.InvariantCulture, DateTimeStyles.None, out date))
                {
                    MessageBox.Show("Ongeldige datum. Voer een datum in het formaat dd/MM/jjjj in.");
                    return;
                }

                // dtatItem gegevens geven binnen try and catch, crash voorkomen
                dataItem = new DataItem
                {
                    Date = date,
                    Name = tbxName.Text
                };
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Er is een fout opgetreden: {ex.Message}");
            }

            // Converteer het object naar JSON
            string json = JsonConvert.SerializeObject(dataItem);

            try
            {
                // Schrijf de JSON naar een bestand
                File.WriteAllText(@"C:\Users\timde\OneDrive\Bureaublad\data2.json", json);
                MessageBox.Show("Gegevens succesvol naar JSON-bestand geschreven.");
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Er is een fout opgetreden bij het schrijven naar het JSON-bestand: {ex.Message}");
            }
        }
    }
}
