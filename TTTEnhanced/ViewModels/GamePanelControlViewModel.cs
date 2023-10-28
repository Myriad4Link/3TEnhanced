using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Reactive.Linq;
using Avalonia;
using Avalonia.Controls;
using Avalonia.Controls.Primitives;
using Avalonia.Interactivity;
using Avalonia.Layout;
using ReactiveUI;

namespace TTTEnhanced.ViewModels
{

    public class GamePanelControlViewModel : ViewModelBase
    {
        public string Text
        {
            get => _text;
            set => this.RaiseAndSetIfChanged(ref _text, value);
        }

        private string _text = "Welcome to Tic-Tac-Toe!";

        public ObservableCollection<ObservableCollection<Border>> Borders
        {
            get => _borders;
            set => this.RaiseAndSetIfChanged(ref _borders, value);
        }

        private ObservableCollection<ObservableCollection<Border>> _borders;

        public GamePanelControlViewModel()
        {
            _borders = new ObservableCollection<ObservableCollection<Border>>()
            {
                new() { new Border(), new Border(), new Border() },
                new() { new Border(), new Border(), new Border() },
                new() { new Border(), new Border(), new Border() }
            };
        }

        public void OnCellClick()
        {
            Text = "Okay...";
        }
    }
}