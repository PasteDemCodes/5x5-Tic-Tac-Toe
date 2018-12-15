using System;
using System.Windows;
using System.Windows.Controls;

namespace TicTacToe
{
    
    public partial class MainWindow : Window
    {
        // App's Main Colors are stored here
        ColorPallete mColors = new ColorPallete();
        
        // Checks for winning condition
        Checker check = new Checker();

        // Creates AI Instance
        AI mAI = new AI();
        
        public char[,] InitMoves()
        {
            char[,] moves = new char[5, 5];
            for (int i = 0; i < 5; i++)
            {
                for (int j = 0; j < 5; j++)
                {
                    moves[i, j] = ' ';
                }
            }
            return moves;
        }

        // Every move taken is stored here
        char[,] moves = new char[5, 5];

        // Counts total moves taken, used to skip winner checking before first 9 moves
        int moves_taken = 0;

        // Player's Move: False: X, True: O.
        private bool Player;
        private char Player_char = 'X';        

        // Timer to update Player's Info
        System.Windows.Threading.DispatcherTimer updater = new System.Windows.Threading.DispatcherTimer();

        private bool AiEnabled;

        public void ResetButtonBorderColor()
        {
            for (int i=0; i<5; i++)
            {
                for (int j=0; j<5; j++)
                {
                    Button button = (Button)FindName("button_" + i + "_" + j);
                    button.BorderBrush = null;
                }
            }
        }
        
        public void ResetButtonContent()
        {
            for (int i = 0; i < 5; i++)
            {
                for (int j = 0; j < 5; j++)
                {
                    Button button = (Button)FindName("button_" + i + "_" + j);
                    button.Content = "";
                }
            }
        }
        
        // runs when someone wins.
        public void LockButtons(bool locked)
        {
            // If this occurrs someone has won, which means AI must stop playing
            AiEnabled = false;
            CheckBox_AI.IsChecked = false;

            for (int i = 0; i < 5; i++)
            {
                for (int j = 0; j < 5; j++)
                {
                    Button button = (Button)FindName("button_" + i + "_" + j);
                    if (locked)
                    {
                        button.IsEnabled = false;
                    }
                    else
                    {
                        button.IsEnabled = true;
                    }
                }
            }

        }
        
        public MainWindow()
        {
            InitializeComponent();

            // initialize move array to emptyspace
            moves = InitMoves();
            
            updater.Tick += updater_Tick;
            updater.Interval = TimeSpan.FromMilliseconds(1);
            updater.Start();

            // Assigning Colors to assets
            Label_Player.Foreground = mColors.MainTextColor;
            debug.Foreground = mColors.MainTextColor;
            Label_Move.Foreground = mColors.MainTextColor;
            Label_AI.Foreground = mColors.MainTextColor;
            Grid_Main.Background = mColors.MainNavbarColor;

        }

        private void updater_Tick(object sender, EventArgs e)
        {
            // this means draw, stop AI
            if (moves_taken == 25)
            {
                LockButtons(true);
                AiEnabled = false;
                CheckBox_AI.IsChecked = false;
                debug.Content = "Draw";
            }

            if (Player) {
                Label_Player.Content = "Playing: O";
                Player_char = 'O';

                if (AiEnabled)
                {
                    // Just in case something goes wrong
                    try
                    {
                        Button button = (Button)FindName(mAI.MakeMove(moves));
                        button.RaiseEvent(new RoutedEventArgs(Button.ClickEvent));
                    }
                    catch (Exception) { }
                }
            }
            else
            {
                Label_Player.Content = "Playing: X";
                Player_char = 'X';
            }

            Label_Move.Content = "Move: " + moves_taken;           

        }

        private void button_0_0_Click(object sender, RoutedEventArgs e)
        {
            
            if (moves[0, 0] == ' ')
            {
                moves_taken++;
                ResetButtonBorderColor();
                moves[0, 0] = Player_char;
                button_0_0.Content = Player_char;

                if (check.isWin(moves, Player_char, 0, 0, moves_taken))
                {
                    LockButtons(true);
                }
                else
                {                    
                    Player = !Player;
                }
            }
            else
            {
                button_0_0.BorderBrush = mColors.ErrorColor;
            }
            
        }

        private void button_0_1_Click(object sender, RoutedEventArgs e)
        {
            
            if (moves[0, 1] == ' ')
            {
                moves_taken++;
                ResetButtonBorderColor();
                moves[0, 1] = Player_char;
                button_0_1.Content = Player_char;
                if (check.isWin(moves, Player_char, 0, 1, moves_taken))
                {
                    LockButtons(true);
                }
                else
                {                    
                    Player = !Player;
                }
            }
            else
            {
                button_0_1.BorderBrush = mColors.ErrorColor;
            }
        }

        private void button_0_2_Click(object sender, RoutedEventArgs e)
        {
            if (moves[0, 2] == ' ')
            {
                moves_taken++;
                ResetButtonBorderColor();
                moves[0, 2] = Player_char;
                button_0_2.Content = Player_char;
                if (check.isWin(moves, Player_char, 0, 2, moves_taken))
                {
                    LockButtons(true);
                }
                else
                {
                    Player = !Player;
                }
            }
            else
            {
                button_0_2.BorderBrush = mColors.ErrorColor;
            }
        }

        private void button_0_3_Click(object sender, RoutedEventArgs e)
        {
            if (moves[0, 3] == ' ')
            {
                moves_taken++;
                ResetButtonBorderColor();
                moves[0, 3] = Player_char;
                button_0_3.Content = Player_char;
                if (check.isWin(moves, Player_char, 0, 3, moves_taken))
                {
                    LockButtons(true);
                }
                else
                {
                    Player = !Player;
                }
            }
            else
            {
                button_0_3.BorderBrush = mColors.ErrorColor;
            }
        }

        private void button_0_4_Click(object sender, RoutedEventArgs e)
        {
            if (moves[0, 4] == ' ')
            {
                moves_taken++;
                ResetButtonBorderColor();
                moves[0, 4] = Player_char;
                button_0_4.Content = Player_char;
                if (check.isWin(moves, Player_char, 0, 4, moves_taken))
                {
                    LockButtons(true);
                }
                else
                {
                    Player = !Player;
                }
            }
            else
            {
                button_0_4.BorderBrush = mColors.ErrorColor;
            }
        }

        private void button_1_0_Click(object sender, RoutedEventArgs e)
        {
            if (moves[1, 0] == ' ')
            {
                moves_taken++;
                ResetButtonBorderColor();
                moves[1, 0] = Player_char;
                button_1_0.Content = Player_char;

                if (check.isWin(moves, Player_char, 1, 0, moves_taken))
                {
                    LockButtons(true);
                }
                else
                {

                    Player = !Player;
                }
            }
            else
            {
                button_1_0.BorderBrush = mColors.ErrorColor;
            }
        }

        private void button_1_1_Click(object sender, RoutedEventArgs e)
        {
            if (moves[1, 1] == ' ')
            {
                moves_taken++;
                ResetButtonBorderColor();
                moves[1, 1] = Player_char;
                button_1_1.Content = Player_char;

                if (check.isWin(moves, Player_char, 1, 1, moves_taken))
                {
                    LockButtons(true);
                }
                else
                {

                    Player = !Player;
                }
            }
            else
            {
                button_1_1.BorderBrush = mColors.ErrorColor;
            }
        }

        private void button_1_2_Click(object sender, RoutedEventArgs e)
        {
            if (moves[1, 2] == ' ')
            {
                moves_taken++;
                ResetButtonBorderColor();
                moves[1, 2] = Player_char;
                button_1_2.Content = Player_char;

                if (check.isWin(moves, Player_char, 1, 2, moves_taken))
                {
                    LockButtons(true);
                }
                else
                {

                    Player = !Player;
                }
            }
            else
            {
                button_1_2.BorderBrush = mColors.ErrorColor;
            }
        }

        private void button_1_3_Click(object sender, RoutedEventArgs e)
        {
            if (moves[1, 3] == ' ')
            {
                moves_taken++;
                ResetButtonBorderColor();
                moves[1, 3] = Player_char;
                button_1_3.Content = Player_char;

                if (check.isWin(moves, Player_char, 1, 3, moves_taken))
                {
                    LockButtons(true);
                }
                else
                {

                    Player = !Player;
                }
            }
            else
            {
                button_1_3.BorderBrush = mColors.ErrorColor;
            }
        }

        private void button_1_4_Click(object sender, RoutedEventArgs e)
        {
            if (moves[1, 4] == ' ')
            {
                moves_taken++;
                ResetButtonBorderColor();
                moves[1, 4] = Player_char;
                button_1_4.Content = Player_char;

                if (check.isWin(moves, Player_char, 1, 4, moves_taken))
                {
                    LockButtons(true);
                }
                else
                {

                    Player = !Player;
                }
            }
            else
            {
                button_1_4.BorderBrush = mColors.ErrorColor;
            }
        }

        private void button_2_0_Click(object sender, RoutedEventArgs e)
        {
            if (moves[2, 0] == ' ')
            {
                moves_taken++;
                ResetButtonBorderColor();
                moves[2, 0] = Player_char;
                button_2_0.Content = Player_char;

                if (check.isWin(moves, Player_char, 2, 0, moves_taken))
                {
                    LockButtons(true);
                }
                else
                {

                    Player = !Player;
                }
            }
            else
            {
                button_2_0.BorderBrush = mColors.ErrorColor;
            }
        }

        private void button_2_1_Click(object sender, RoutedEventArgs e)
        {
            if (moves[2, 1] == ' ')
            {
                moves_taken++;
                ResetButtonBorderColor();
                moves[2, 1] = Player_char;
                button_2_1.Content = Player_char;

                if (check.isWin(moves, Player_char, 2, 1, moves_taken))
                {
                    LockButtons(true);
                }
                else
                {

                    Player = !Player;
                }
            }
            else
            {
                button_2_1.BorderBrush = mColors.ErrorColor;
            }
        }

        private void button_2_2_Click(object sender, RoutedEventArgs e)
        {
            if (moves[2, 2] == ' ')
            {
                moves_taken++;
                ResetButtonBorderColor();
                moves[2, 2] = Player_char;
                button_2_2.Content = Player_char;

                if (check.isWin(moves, Player_char, 2, 2, moves_taken))
                {
                    LockButtons(true);
                }
                else
                {

                    Player = !Player;
                }
            }
            else
            {
                button_2_2.BorderBrush = mColors.ErrorColor;
            }
        }

        private void button_2_3_Click(object sender, RoutedEventArgs e)
        {
            if (moves[2, 3] == ' ')
            {
                moves_taken++;
                ResetButtonBorderColor();
                moves[2, 3] = Player_char;
                button_2_3.Content = Player_char;

                if (check.isWin(moves, Player_char, 2, 3, moves_taken))
                {
                    LockButtons(true);
                }
                else
                {

                    Player = !Player;
                }
            }
            else
            {
                button_2_3.BorderBrush = mColors.ErrorColor;
            }
        }

        private void button_2_4_Click(object sender, RoutedEventArgs e)
        {
            if (moves[2, 4] == ' ')
            {
                moves_taken++;
                ResetButtonBorderColor();
                moves[2, 4] = Player_char;
                button_2_4.Content = Player_char;

                if (check.isWin(moves, Player_char, 2, 4, moves_taken))
                {
                    LockButtons(true);
                }
                else
                {

                    Player = !Player;
                }
            }
            else
            {
                button_2_4.BorderBrush = mColors.ErrorColor;
            }
        }

        private void button_3_0_Click(object sender, RoutedEventArgs e)
        {
            if (moves[3, 0] == ' ')
            {
                moves_taken++;
                ResetButtonBorderColor();
                moves[3, 0] = Player_char;
                button_3_0.Content = Player_char;

                if (check.isWin(moves, Player_char, 3, 0, moves_taken))
                {
                    LockButtons(true);
                }
                else
                {

                    Player = !Player;
                }
            }
            else
            {
                button_3_0.BorderBrush = mColors.ErrorColor;
            }
        }

        private void button_3_1_Click(object sender, RoutedEventArgs e)
        {
            if (moves[3, 1] == ' ')
            {
                moves_taken++;
                ResetButtonBorderColor();
                moves[3, 1] = Player_char;
                button_3_1.Content = Player_char;

                if (check.isWin(moves, Player_char, 3, 1, moves_taken))
                {
                    LockButtons(true);
                }
                else
                {

                    Player = !Player;
                }
            }
            else
            {
                button_3_1.BorderBrush = mColors.ErrorColor;
            }
        }

        private void button_3_2_Click(object sender, RoutedEventArgs e)
        {
            if (moves[3, 2] == ' ')
            {
                moves_taken++;
                ResetButtonBorderColor();
                moves[3, 2] = Player_char;
                button_3_2.Content = Player_char;

                if (check.isWin(moves, Player_char, 3, 2, moves_taken))
                {
                    LockButtons(true);
                }
                else
                {

                    Player = !Player;
                }
            }
            else
            {
                button_3_2.BorderBrush = mColors.ErrorColor;
            }
        }

        private void button_3_3_Click(object sender, RoutedEventArgs e)
        {
            if (moves[3, 3] == ' ')
            {
                moves_taken++;
                ResetButtonBorderColor();
                moves[3, 3] = Player_char;
                button_3_3.Content = Player_char;

                if (check.isWin(moves, Player_char, 3, 3, moves_taken))
                {
                    LockButtons(true);
                }
                else
                {

                    Player = !Player;
                }
            }
            else
            {
                button_3_3.BorderBrush = mColors.ErrorColor;
            }
        }

        private void button_3_4_Click(object sender, RoutedEventArgs e)
        {
            if (moves[3, 4] == ' ')
            {
                moves_taken++;
                ResetButtonBorderColor();
                moves[3, 4] = Player_char;
                button_3_4.Content = Player_char;

                if (check.isWin(moves, Player_char, 3, 4, moves_taken))
                {
                    LockButtons(true);
                }
                else
                {

                    Player = !Player;
                }
            }
            else
            {
                button_3_4.BorderBrush = mColors.ErrorColor;
            }
        }

        private void button_4_0_Click(object sender, RoutedEventArgs e)
        {
            if (moves[4, 0] == ' ')
            {
                moves_taken++;
                ResetButtonBorderColor();
                moves[4, 0] = Player_char;
                button_4_0.Content = Player_char;

                if (check.isWin(moves, Player_char, 4, 0, moves_taken))
                {
                    LockButtons(true);
                }
                else
                {

                    Player = !Player;
                }
            }
            else
            {
                button_4_0.BorderBrush = mColors.ErrorColor;
            }
        }

        private void button_4_1_Click(object sender, RoutedEventArgs e)
        {
            if (moves[4, 1] == ' ')
            {
                moves_taken++;
                ResetButtonBorderColor();
                moves[4, 1] = Player_char;
                button_4_1.Content = Player_char;

                if (check.isWin(moves, Player_char, 4, 1, moves_taken))
                {
                    LockButtons(true);
                }
                else
                {

                    Player = !Player;
                }
            }
            else
            {
                button_4_1.BorderBrush = mColors.ErrorColor;
            }
        }

        private void button_4_2_Click(object sender, RoutedEventArgs e)
        {
            if (moves[4, 2] == ' ')
            {
                moves_taken++;
                ResetButtonBorderColor();
                moves[4, 2] = Player_char;
                button_4_2.Content = Player_char;

                if (check.isWin(moves, Player_char, 4, 2, moves_taken))
                {
                    LockButtons(true);
                }
                else
                {

                    Player = !Player;
                }
            }
            else
            {
                button_4_2.BorderBrush = mColors.ErrorColor;
            }
        }

        private void button_4_3_Click(object sender, RoutedEventArgs e)
        {
            if (moves[4, 3] == ' ')
            {
                moves_taken++;
                ResetButtonBorderColor();
                moves[4, 3] = Player_char;
                button_4_3.Content = Player_char;

                if (check.isWin(moves, Player_char, 4, 3, moves_taken))
                {
                    LockButtons(true);
                }
                else
                {

                    Player = !Player;
                }
            }
            else
            {
                button_4_3.BorderBrush = mColors.ErrorColor;
            }
        }

        private void button_4_4_Click(object sender, RoutedEventArgs e)
        {
            if (moves[4, 4] == ' ')
            {
                moves_taken++;
                ResetButtonBorderColor();
                moves[4, 4] = Player_char;
                button_4_4.Content = Player_char;

                if (check.isWin(moves, Player_char, 4, 4, moves_taken))
                {
                    LockButtons(true);
                }
                else
                {

                    Player = !Player;
                }
            }
            else
            {
                button_4_4.BorderBrush = mColors.ErrorColor;
            }
        }

        private void Button_Reset_Click(object sender, RoutedEventArgs e)
        {
            updater.Stop();
            Player = false;
            Player_char = 'X';
            ResetButtonBorderColor();
            ResetButtonContent();
            moves_taken = 0;
            moves = InitMoves();
            LockButtons(false);
            debug.Content = "";
            updater.Start();
        }

        private void CheckBox_AI_Checked(object sender, RoutedEventArgs e)
        {
            AiEnabled = true;
        }

        private void CheckBox_AI_Unchecked(object sender, RoutedEventArgs e)
        {
            AiEnabled = false;
        }
    }
}
