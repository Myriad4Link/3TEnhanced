using System.Collections.ObjectModel;
using ReactiveUI;
using TTTEnhanced.Models;

namespace TTTEnhanced.ViewModels;

public class GamePanelControlViewModel : ViewModelBase
{
    public string Text
    {
        get => _text;
        set => this.RaiseAndSetIfChanged(ref _text, value);
    }

    private string _text;

    public ObservableCollection<ObservableCollection<char?>> ChessBoard
    {
        get => _chessBoard;
        set => this.RaiseAndSetIfChanged(ref _chessBoard, value);
    }

    private ObservableCollection<ObservableCollection<char?>> _chessBoard;

    private int _turnCount;
    public GamePanelControlViewModel()
    {
        _text = "Welcome to Tic-Tac-Toe!";
        
        _chessBoard = new ObservableCollection<ObservableCollection<char?>>
        {
            new ObservableCollection<char?>() {null, null, null},
            new ObservableCollection<char?>() {null, null, null},
            new ObservableCollection<char?>() {null, null, null}
        };
        
        _turnCount = 0;
    }

    public void OnCellClick(int index)
    {
        _turnCount++;
        if (ChessBoard[index / 3][index % 3] == null) ChessBoard[index / 3][index % 3] = _turnCount % 2 == 0 ? 'O' : 'X';
        char? status = StatusCheckModel.CheckStatus(ChessBoard);
        if (status != null) Text = $@"{status} wins!";
    }
}