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

    private void QuoteButton_Click(object? sender, RoutedEventArgs e)
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
        
       
    }
}