namespace TTTEnhanced.ViewModels;

public class MainWindowViewModel : ViewModelBase
{
    public GamePanelControlViewModel GamePanelControlViewModel { get; set; }
    public MainWindowViewModel()
    {
        GamePanelControlViewModel = new GamePanelControlViewModel(); 
    }
}