namespace TicTacToe
{
    class Checker
    {
        public Checker() { }

        public bool isWin(char[,] moves, char player_char, int x, int y, int moves_taken)
        {
            // Avoid checking if moves are less than 8 (4 by each player)
            if (moves_taken > 8)
            {
                // Save calcuations by checking diagonals only when x==y.
                if (x == y)
                {
                    // Diagonal Checking
                    for (int i = 0; i < 5; i++)
                    {
                        if (moves[i, i] != player_char)
                            break;
                        if (i == 4)
                        {
                            ((MainWindow)System.Windows.Application.Current.MainWindow).debug.Content = "Player " + player_char + " wins";
                            return true;
                        }
                    }

                    // Reverse Diagonal
                    for (int i = 0; i < 5; i++)
                    {
                        if (moves[i, 4 - i] != player_char)
                            break;
                        if (i == 4)
                        {
                            ((MainWindow)System.Windows.Application.Current.MainWindow).debug.Content = "Player " + player_char + " wins";
                            return true;
                        }
                    }
                }

                // Column
                for (int i = 0; i < 5; i++)
                {
                    if (moves[x, i] != player_char)
                        break;
                    if (i == 4)
                    {
                        ((MainWindow)System.Windows.Application.Current.MainWindow).debug.Content = "Player " + player_char + " wins";
                        return true;
                    }
                }

                // Row
                for (int i = 0; i < 5; i++)
                {
                    if (moves[i, y] != player_char)
                        break;
                    if (i == 4)
                    {
                        ((MainWindow)System.Windows.Application.Current.MainWindow).debug.Content = "Player " + player_char + " wins";
                        return true;
                    }
                }

            }
            return false;
            
        }
    }
}
