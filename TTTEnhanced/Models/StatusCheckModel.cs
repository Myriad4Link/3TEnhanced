using System.Collections.ObjectModel;

namespace TTTEnhanced.Models;

public class StatusCheckModel
{
    public static char? CheckStatus(ObservableCollection<ObservableCollection<char?>> chessboard)
    {
        for (int i = 0; i < 3; i++)
        {
            int xCount = 0;
            int oCount = 0;
            for (int j = 0; j < 3; j++)
            {
                switch (chessboard[i][j])
                {
                    case null:
                        continue;
                    case 'X':
                        xCount++;
                        break;
                    case 'O':
                        oCount++;
                        break;
                }

                if (xCount == 3) return 'X';
                if (oCount == 3) return 'O';
            }
        }

        for (int j = 0; j < 3; j++)
        {
            int xCount = 0;
            int oCount = 0;
            for (int i = 0; i < 3; i++)
            {
                switch (chessboard[i][j])
                {
                    case null:
                        continue;
                    case 'X':
                        xCount++;
                        break;
                    case 'O':
                        oCount++;
                        break;
                }

                if (xCount == 3) return 'X';
                if (oCount == 3) return 'O';
            }
        }
        
        if (chessboard[0][0] == chessboard[1][1] && chessboard[1][1] == chessboard[2][2]) return chessboard[1][1];
        if (chessboard[0][2] == chessboard[1][1] && chessboard[1][1] == chessboard[2][0]) return chessboard[1][1];
        return null;
    }
}