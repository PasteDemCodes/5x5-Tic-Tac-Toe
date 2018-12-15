using System;
using System.Collections.Generic;

namespace TicTacToe
{
    class AI
    {
        // Avalaible moves are stored here
        private List<int> X = new List<int>();
        private List<int> Y = new List<int>();

        Random rand = new Random();
        
        private int random_index = 0;
        private string final_move;

        public int RandomIntGenerator()
        {
            Random random = new Random();
            return random.Next(0, 5); 
        }

        public string MakeMove(char[,] moves)
        {
            for (int i = 0; i < 5; i++)
            {
                for (int j = 0; j < 5; j++)
                {
                    if (moves[i, j] == ' ')
                    {
                        X.Add(i);
                        Y.Add(j);
                    }                    
                }
            }

            random_index = rand.Next(0, X.Count);
            final_move = "button_" + X[random_index] + "_" + Y[random_index];
            return final_move;
        }
    }
}
