# To-Do-list-in-C#

## Waarom een To-Do list?

Het was een zeer leerijke en leuke opgave om een To-Do list te maken. Ik heb veel bijgeleerd inverband met json files in lezen en naar toe schrijven. 
Ook was het een nieuwe ervaring om met verschillende WPF windows en code behinds te werken, er voor zorgen dat alles beschikbaar was in de benodigde code behinds was soms een pittige taak.

## Hoe werkt de code?

Als je het project opstart wordt je verwelkomt door een WPF. Hier kan je kiezen om een item toe te voegen of om gewoon door te gaan. 
Aan de hand van welke optie die je hebt gekozen komt er een nieuwe WPF te voorschijn.

## Wat kun je allemaal doen?

### Items toevoegen

Als je er voor hebt gekozen om een item toe te voegen zal je een WPF te zien krijgen waar je een naam en een datum kan ingeven.
Als je een verkeerde datum ineeft komt er een MessageBox die aangeeft dat je een foutive datum hebt ingegeven, hier kan je ook de juiste format zien van de datum.

### Items bekijken

Als je er voor hebt gekozen om door te gaan zal je een listbox te zien krijgen met daar in al je items.
ALs je nog meer dan 3 maar minder dan 5 dagen over hebt zal je item een oranje achtergrond krijgen.
Als je nog maar 3 dagen of minder over hebt zal dit item een rode achtergrond krijgen.
Dit deel van de code was een grote opgave aangzien je een class moet koppelen in je xaml,
``` YML
  <ListBox Name="ListBoxData" FontSize="25" SelectionChanged="ListBoxData_SelectionChanged" Margin="5">
    <ListBox.ItemContainerStyle>
        <Style TargetType="ListBoxItem">
            <Setter Property="Background" Value="{Binding Date, Converter={StaticResource DaysRemainingColorConverter}}"/>
        </Style>
    </ListBox.ItemContainerStyle>
    <!-- ListBox-items hier -->
    <ListBox.ItemTemplate>
        <!-- DataTemplate voor het opmaken van elk item in de ListBox -->
        <DataTemplate>
            <!-- TextBlock voor het weergeven van de tekst van elk item -->
            <TextBlock Text="{Binding}"/>
        </DataTemplate>
    </ListBox.ItemTemplate>
</ListBox>
```

### Item aanpassen

Als je een item uit de listbox hebt geselecteerd krijg je een nieuwe WPF te zien, deze geeft je de mogelijkheid om de naam en of de datum aan te passen.
Ook kan je hier het item verwijderen geen paniek als je hebt misklikt je krijgt eerst een MessageBox te zien en het item wordt pas verwijderd na de druk op "Ja".

![Opgelet](https://i.imgur.com/p6XRxhx.png) 
# Opgelet eens het item is verwijderd is dit permanent!
Wijzegingen aan de naam en of datum worden pas opgeslaan na de druk op "Opslaan".

### Gegevens schrijven naar json

Dit was een leuk en crusiaal onderdeel van de code. 
Eerst had ik problemen dat de listbox op een gegeven moment de data niet meer kon lezen omdat de data niet goed werd opgedeeld in het josn bestand.
De oplosing was simple, eerst de bestaande data opslaan dan het bestand leeg maken en dan als laatste als alle wijzegingen in orde waren de data volledig herschrijven naar het json bestand.
``` YML
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
```

