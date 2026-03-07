using Avalonia.Controls;
using Avalonia.Interactivity;

namespace RapidPack;

public partial class MainWindow : Window
{
    private readonly ParcelCalculator _parcelCalculator = new ParcelCalculator();

    public MainWindow()
    {
        InitializeComponent();
    }

    private void QuoteButtonClick(object? sender, RoutedEventArgs e)
    {

        if (!int.TryParse(HeightTextBox.Text, out int height))
        {
            OutputTextBlock.Text = "Wysokość musi być dodatmia.";
            return;
        }

        if (!int.TryParse(WidthTextBox.Text, out int width))
        {
            OutputTextBlock.Text = "Pole Szerokość musi być dodatnia.";
            return;
        }

        if (!int.TryParse(DepthTextBox.Text, out int depth))
        {
            OutputTextBlock.Text = "Pole Głębokość musi być dodatnia.";
            return;
        }
        
        int weight = (int)WeightTextBox.Value;

        var selectedItem = ComboBox.SelectedItem as ComboBoxItem;
        string shipmentType = selectedItem?.Content?.ToString() ?? "Standardowa";
        bool express = ExpressCheckBox.IsChecked == true;

        OutputTextBlock.Text = _parcelCalculator.CalculatePrice(height, width, depth, weight, express, shipmentType);
    }
}