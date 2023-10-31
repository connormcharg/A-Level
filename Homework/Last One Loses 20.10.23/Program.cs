using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Data.SQLite;
using System.Runtime.Remoting.Messaging;
using System.Runtime.Serialization.Formatters.Binary;
using System.Runtime.Serialization;
using System.Xml.Linq;
using System.Threading;

namespace Last_One_Loses_20._10._23
{
    /// <summary>
    /// Class to hold basic information about each player in a gameState Object.
    /// </summary>
    [Serializable()]
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
    [Serializable()]
    public class GameState
    {
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
        /// Method to get AI move for a given gamestate and difficulty.
        /// </summary>
        /// <param name="diff">Integer that must be greater than 1</param>
        /// <returns>Returns and integer that is the number of matches removed by the AI.</returns>
        public int GetAIMove(int diff)
        {
            switch (diff)
            {
                case 1: // AI chooses best move possible
                    for (int i = 1; i <= maxTaken; i++)
                    {
                        if ((count - i) % (maxTaken + 1) == 1) { return i; }
                    }
                    return rng.Next(1, maxTaken + 1);
                default: // randomly picks between best move and random move based on "diff"
                    int randomChoice = rng.Next(0, diff);
                    if (randomChoice != 0)
                    {
                        return rng.Next(1, maxTaken + 1);
                    }
                    else
                    {
                        for (int i = 1; i <= maxTaken; i++)
                        {
                            if ((count - i) % (maxTaken + 1) == 1) { return i; }
                        }
                        return rng.Next(1, maxTaken + 1);
                    }
            }
        }

        /// <summary>
        /// Allows the user to input the move they would like to play, and validates it.
        /// </summary>
        /// <returns>integer representing the player's move</returns>
        public int GetPlayerMove()
        {
            Console.ForegroundColor = ConsoleColor.Gray;
            Console.WriteLine("How many matches do you wish to remove? (Maximum: {0})", maxTaken);
            int move = 0;
            while (!int.TryParse(Console.ReadLine(), out move) || move > maxTaken || move < 1)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Invalid input. Please enter a number between 1 and {0}.", maxTaken);
                Console.ForegroundColor = ConsoleColor.Gray;
            }
            return move;
        }
    }

    /// <summary>
    /// A class to contain methods for setting up, ending, saving and loading games.
    /// </summary>
    public class GameManager
    {
        public GameState gs;
        public Random rng = new Random();
        public const string DATABASE_FILE = "database.sqlite";
        public static string CONNECTION_STRING = string.Format("Data Source={0};Version=3;", DATABASE_FILE);
        public GameManager(GameState gs = null)
        {
            this.gs = gs;
            HandleGame();
        }

        public void HandleGame()
        {
            Console.ForegroundColor = ConsoleColor.Gray;
            bool handle = true;
            int option = 0;
            while (handle)
            {
                Console.Title = "Last One Loses";
                option = Menu();

                switch (option)
                {
                    case 0: // new game ( same players )
                        if (gs == null)
                        {
                            Setup();
                        }
                        else
                        {
                            gs.gameWon = false;
                            gs.count = 12;
                            gs.maxTaken = 3;
                            if (FlipCoin())
                            {
                                gs.players.Reverse();
                            }
                        }
                        PlayGame();
                        break;
                    case 1: // reset game
                        Setup();
                        PlayGame();
                        break;
                    case 2: // view high scores
                        string[,] scores = LoadScores();
                        Console.Clear();
                        Console.ForegroundColor = ConsoleColor.Gray;
                        Console.WriteLine("High Scores:");
                        Console.ForegroundColor = ConsoleColor.Cyan;
                        Console.WriteLine("Name\t\tScore");
                        Console.ForegroundColor = ConsoleColor.Gray;
                        for (int i = 0; i < scores.GetLength(0); i++)
                        {
                            if (scores[i, 0] == null) { break; }
                            Console.WriteLine("{0}\t\t{1}", scores[i, 0], scores[i, 1]);
                        }
                        Console.WriteLine("...");
                        Console.ReadKey();
                        break;
                    case 3: // exit game
                        handle = false;
                        Console.WriteLine("Thank you for playing Last One Loses!");
                        Console.ReadKey();
                        return;
                }

            }
        }

        private int Menu()
        {
            string[] options = new string[] { "New Game (same players)", "Reset Game", "View High Scores", "Exit Game" };
            int option = 0;
            while (true)
            {
                Console.Clear();
                Console.ForegroundColor = ConsoleColor.Gray;
                Console.WriteLine("Main Menu (arrow keys to navigate):");
                for (int i = 0; i < options.Length; i++)
                {
                    if (i == option)
                    {
                        Console.ForegroundColor = ConsoleColor.Green;
                        Console.WriteLine($"[*] - {options[i]}");
                        Console.ForegroundColor = ConsoleColor.Gray;
                    }
                    else
                    {
                        Console.ForegroundColor = ConsoleColor.Gray;
                        Console.WriteLine($"[ ] - {options[i]}");
                    }
                }
                ConsoleKey key = Console.ReadKey().Key;
                switch (key)
                {
                    case ConsoleKey.UpArrow:
                        if (option > 0) { option--; }
                        break;
                    case ConsoleKey.DownArrow:
                        if (option < options.Length - 1) { option++; }
                        break;
                    case ConsoleKey.Enter:
                        return option;
                }
            }
        }

        public void PlayGame()
        {
            Console.Clear();
            Console.Title += " (close this window to save the game at any time)";
            while (!gs.gameWon)
            {
                for (int i = 0; i < gs.players.Count; i++)
                {
                    if (gs.count < gs.maxTaken)
                    {
                        gs.maxTaken = gs.count;
                    }
                    int move = 0;
                    if (gs.players[i].name == "AI")
                    {
                        move = gs.GetAIMove(1); // max difficulty
                        gs.count -= move;
                        Console.WriteLine("The AI removed {0} matches.", move);
                    }
                    else
                    {
                        DisplayMatches();
                        Console.WriteLine("{0}'s turn.", gs.players[i].name);
                        move = gs.GetPlayerMove();
                        gs.count -= move;
                    }
                    if (gs.count <= 0)
                    {
                        gs.gameWon = true;
                        Console.Clear();
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("{0} loses!", gs.players[i].name);
                        string winner = GetWinnerName(gs.players[i].name);
                        Console.ForegroundColor = ConsoleColor.Green;
                        Console.WriteLine("{0} wins!", winner);
                        Console.ForegroundColor = ConsoleColor.Gray;
                        if (winner != "AI")
                        {
                            IncreaseScore(winner);
                        }
                        Console.WriteLine("Press any key to return to the main menu!");
                        Console.ReadKey();
                    }
                    Console.WriteLine("---------------------------------");
                }
                SaveGame(); // saves game after each turn.
            }
            if (CheckForSave()) // deletes save file if game is over.
            {
                File.Delete("save.bin");
            }
        }

        public string GetWinnerName(string loser)
        {
            if (gs.players[0].name == loser)
            {
                return gs.players[1].name;
            }
            else
            {
                return gs.players[0].name;
            }
        }

        private bool FlipCoin()
        {
            int num = rng.Next(0, 2);
            return num == 1;
        }

        public void Setup()
        {
            Console.ForegroundColor = ConsoleColor.Gray;
            Console.WriteLine("Welcome to Last One Loses!");
            if (CheckForSave())
            {
                Console.WriteLine("Would you like to load a saved game? (Y/N)");
                string input = Console.ReadLine().ToLower();
                if (input == "y")
                {
                    LoadGame();
                    Console.WriteLine("The saved game has been successfully loaded.");
                    Console.ReadKey();
                    return;
                }
            }
            // main menu
            Console.Write("Would you like to play a 1 (AI) or 2 player game? (1/2): ");
            string choice = Console.ReadLine();
            while (choice != "1" && choice != "2")
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.Write("Invalid input. Please enter 1 or 2: ");
                Console.ForegroundColor = ConsoleColor.Gray;
                choice = Console.ReadLine();
            }
            bool twoPlayer = choice == "2";
            List<Player> players = new List<Player>();
            if (twoPlayer)
            {
                Console.Write("Please enter the name for player 1 (case sensitive): ");
                string name1 = Console.ReadLine();
                Console.Write("Please enter the name for player 2 (case sensitive): ");
                string name2 = Console.ReadLine();
                if (FlipCoin())
                {
                    players = new List<Player>
                    {
                        new Player(name1),
                        new Player(name2)
                    };
                }
                else
                {
                    players = new List<Player>
                    {
                        new Player(name2),
                        new Player(name1)
                    };
                }
                
            }
            else
            {
                Console.Write("Please enter your name (case sensitive): ");
                string name1 = Console.ReadLine();
                if (FlipCoin())
                {
                    players = new List<Player>
                    {
                        new Player(name1),
                        new Player("AI")
                    };
                }
                else
                {
                    players = new List<Player>
                    {
                        new Player("AI"),
                        new Player(name1)
                    };
                }
            }
            gs = new GameState(twoPlayer, 12, players, 3);
        }

        public void LoadGame()
        {
            if (CheckForSave())
            {
                FileStream fs = File.Open("save.bin", FileMode.Open);
                gs = Deserialize(fs);
                fs.Close();
            }
        }

        public void SaveGame()
        {
            if (CheckForSave())
            {
                File.Delete("save.bin");
            }
            FileStream fs = File.Create("save.bin");
            fs.Close();
            fs = File.Open("save.bin", FileMode.Open);
            Serialize(gs, fs);
            fs.Close();
        }

        private void Serialize(GameState gs, FileStream fs)
        {
            BinaryFormatter bf = new BinaryFormatter();
            try
            {
                bf.Serialize(fs, gs);
                // Console.WriteLine("Serialized successfully.");
            }
            catch (Exception e)
            {
                Console.WriteLine("Failed to serialize. Reason: " + e.Message);
            }
        }

        private GameState Deserialize(FileStream fs)
        {
            BinaryFormatter bf = new BinaryFormatter();
            GameState data = null;
            try
            {
                data = (GameState)bf.Deserialize(fs);
                // Console.WriteLine("Deserialized successfully.");
            }
            catch (Exception e)
            {
                Console.WriteLine("Unable to deserialize. Reason: " + e.Message);
            }
            return data;
        }

        public bool CheckForSave()
        {
            return File.Exists("save.bin");
        }

        /// <summary>
        /// A subroutine to display a given number of matches using the specified formatting.
        /// </summary>
        /// <param name="count"></param>
        public void DisplayMatches(int count = -1)
        {
            if (count == -1) { count = gs.count; }
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("There are {0} Matches remaining.", count);
            Console.WriteLine();
            string l1 = "", l2 = "";
            for (int i = 0; i < count; i++)
            {
                l1 += " O ";
                l2 += " | ";
            }
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine(l1);
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine(l2);
            Console.WriteLine(l2);
            Console.WriteLine(l2);
            Console.WriteLine();
            Console.ForegroundColor = ConsoleColor.Gray;
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
            string sql = $"SELECT Score FROM highScores WHERE Name = '{name}'";
            SQLiteConnection sqlConn = new SQLiteConnection(CONNECTION_STRING);
            SQLiteCommand command = new SQLiteCommand(sql, sqlConn);
            sqlConn.Open();
            using (var reader = command.ExecuteReader())
            {
                if (reader.Read())
                {
                    score = Convert.ToInt32(reader["Score"]);
                }   
                else
                {
                    score = 0;
                }
            }
            sql = $"UPDATE highScores SET Score = {score + 1} WHERE Name = '{name}'";
            if (score == 0)
            {
                sql = $"INSERT INTO highScores (Name, Score) VALUES ('{name}', 1)";
            }
            using (var update = new SQLiteCommand(sql, sqlConn))
            {
                int rowsAffected = update.ExecuteNonQuery();
            }
            sqlConn.Close();
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
                int i = 0;
                while (reader.Read())
                {
                    scores[i, 0] = reader["Name"].ToString();
                    scores[i, 1] = reader["Score"].ToString();
                    i++;
                }   
            }
            sqlConn.Close();
            return scores;
        }
    }

    internal class Program
    {
        static void Main(string[] args)
        {
            //GameState gs = new GameState(false, 0, new List<Player>(), 3);
            
            GameManager gm = new GameManager();

        }
    }
}
