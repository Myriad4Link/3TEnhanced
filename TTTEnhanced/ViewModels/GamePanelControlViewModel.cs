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
        if (ChessBoard[index / 3][index % 3] != null) return;
        _turnCount++;
        char next = (_turnCount + 1) % 2 == 0 ? 'O' : 'X';
        ChessBoard[index / 3][index % 3] = _turnCount % 2 == 0 ? 'O' : 'X';
        char? status = StatusCheckModel.CheckStatus(ChessBoard);
        if (status != null)
        {
            Text = $"{status} wins!";
            return;
        }

        if (_turnCount == 9)
        {
            Text = "Draw!";
            return;
        }
            
        Text = $"Next turn: {next}";
    }

    public void OnRestart()
    {
        for (int i = 0; i < 3; i++)
        {
            for (int j = 0; j < 3; j++) ChessBoard[i][j] = null;
        }

        Text = "Restarted! Welcome to Tic Tac Toe!";
        _turnCount = 0;
    }
}