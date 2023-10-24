using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Data.SQLite;
using System.Runtime.Remoting.Messaging;

namespace Last_One_Loses_20._10._23
{
    /// <summary>
    /// Class to hold basic information about each player in a gameState Object.
    /// </summary>
    public class Player
    {
        public string name;
        public int score;
        public Player(string name, int score = 0)
        {
            this.name = name;
            this.score = score;
        }
    }
    /// <summary>
    /// Class to store all the information necessary for playing and restoring a game.
    /// </summary>
    public class GameState
    {
        public const string DATABASE_FILE = "database.sqlite";
        public static string CONNECTION_STRING = string.Format("Data Source={0};Version=3;", DATABASE_FILE);

        public bool gameWon;
        public int count;
        public bool twoPlayer;
        public List<Player> players;
        public int maxTaken;
        public Random rng = new Random();
        public GameState(bool twoPlayer, int count, List<Player> players, int maxTaken)
        {
            this.players = players;
            this.twoPlayer = twoPlayer;
            this.count = count;
            this.gameWon = false;
            this.maxTaken = maxTaken;
        }

        /// <summary>
        /// Function to load the top 10 high scores from the database.
        /// </summary>
        /// <returns>An array of strings arranged as [[name,score]...] in descending order.</returns>
        public string[,] LoadScores()
        {
            string sql = "SELECT * FROM highScores ORDER BY SCORE DESC;";
            string[,] scores = new string[10, 2];
            SQLiteConnection sqlConn = new SQLiteConnection(CONNECTION_STRING);
            SQLiteCommand command = new SQLiteCommand(sql, sqlConn);
            sqlConn.Open();
            using (var reader = command.ExecuteReader())
            {
                for (int i = 0; i <= 9; i++)
                {
                    reader.Read();
                    scores[i, 0] = reader["Name"].ToString();
                    scores[i, 1] = reader["Score"].ToString();
                }
            }
            sqlConn.Close();
            return scores;
        }

        /// <summary>
        /// A Subroutine that will increment the score of a given player by 1.
        /// This will occur when a player wins a game.
        /// The scores are stored in a database.
        /// </summary>
        /// <param name="name">Name of the player to increment the score of</param>
        public void IncreaseScore(string name)
        {
            int score = 0;
            string sql = $"SELECT Score FROM highScores WHERE Name = \"${name}\"";
            SQLiteConnection sqlConn = new SQLiteConnection(CONNECTION_STRING);
            SQLiteCommand command = new SQLiteCommand(sql, sqlConn);
            sqlConn.Open();
            using (var reader = command.ExecuteReader())
            {
                score = Convert.ToInt32(reader["Score"]);
            }
            sql = $"UPDATE highScores SET Score = {score + 1} WHERE Name = \"${name}\"";
            using (var update = new SQLiteCommand(sql, sqlConn))
            {
                update.ExecuteNonQuery();
            }
            sqlConn.Close();
        }

        /// <summary>
        /// Method to get AI move for a given gamestate and difficulty.
        /// </summary>
        /// <param name="count"></param>
        /// <param name="diff">Integer that must be greater than 1</param>
        /// <returns>Returns and integer that is the number of matches removed by the AI.</returns>
        public int GetAIMove(int count, int diff)
        {
            switch (diff)
            {
                case 1: // AI chooses best move possible
                    for (int i = 1; i <= this.maxTaken; i++)
                    {
                        if ((count-i) % (this.maxTaken + 1) == 1) { return i;}
                    }
                    return this.rng.Next(1, maxTaken + 1);
                default: // randomly picks between best move and random move based on "diff"
                    int randomChoice = this.rng.Next(0, diff);
                    if (randomChoice != 0)
                    {
                        return this.rng.Next(1, this.maxTaken + 1);
                    }
                    else
                    {
                        for (int i = 1; i <= this.maxTaken; i++)
                        {
                            if ((count - i) % (this.maxTaken + 1) == 1) { return i; }
                        }
                    }
                    break;
            }
            return 0;
        }
    }

    /// <summary>
    /// A class to contain methods for setting up, ending, saving and loading games.
    /// </summary>
    public class GameManager
    {
        public int id;
    }

    /// <summary>
    /// This is a summary
    /// </summary>
    internal class Program
    {
        static void Main(string[] args)
        {

        }
    }
}
