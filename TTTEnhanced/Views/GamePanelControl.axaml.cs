using Avalonia;
using Avalonia.Controls;
using Avalonia.Markup.Xaml;
using TTTEnhanced.ViewModels;

namespace TTTEnhanced.Views;

public partial class GamePanelControl : UserControl
{
    public GamePanelControl()
    {
        InitializeComponent();
        DataContext = new GamePanelControlViewModel();
    }
}