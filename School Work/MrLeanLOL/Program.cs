using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MrLeanLOL
{
    internal class Program
    {
        static string SAVEFILE_PLAYERS = "last-one-loses-players.dat";
        static string SAVEFILE_TOPSCORES = "last-one-loses-topscores.dat";
        static string SAVEFILE_STATE = "last-one-loses-gamestate.dat";
        static string SAVEFILE_CURRENT_PLAYER = "last-one-loses-current-player.dat";

        // Represents a single Player record
        struct Player
        {
            public int PlayerNumber;
            public string Name;
            public int Score;
            public bool IsComputer;
        }

        // Represents the current state of an in-progress LOL game.
        struct GameState
        {
            public Player[] Players; // Keeps the information about each player
            public Player[] TopScores; // Maintains the top players

            public Player CurrentPlayer;
            public int NumberOfPlayers;
            public int MatchesRemaining;
            public bool ActiveGame;
        }

        static Random _rng = new Random();

        // Game specific globals
        static GameState _state = new GameState();

        static void Main(string[] args)
        {
            bool playAgain = true;

            do
            {
                _state.ActiveGame = true;
                _state.Players = new Player[3]; // Max of three players
                _state.TopScores = new Player[5]; // Max of five top scores
                _state.MatchesRemaining = 9;

                Console.WriteLine("Welcome to Last-One-Loses!");

                bool isSaveFile = (File.Exists(SAVEFILE_STATE) && File.Exists(SAVEFILE_PLAYERS) && File.Exists(SAVEFILE_TOPSCORES) && File.Exists(SAVEFILE_CURRENT_PLAYER));
                bool isSavedGame = false;
                string strUserInput = "";
                if (isSaveFile)
                {
                    Console.Write("Would you like to load the last auto-saved game [y/n]? : ");
                    strUserInput = Console.ReadLine();

                    if (strUserInput.ToLower() == "y")
                    {
                        isSavedGame = true;
                        LoadGameState();
                    }
                    else
                    {
                        // New game - not loading an existing game
                        _state.NumberOfPlayers = InitialisePlayers();
                    }
                }
                else
                {
                    // New game - not loading an existing game
                    _state.NumberOfPlayers = InitialisePlayers();
                }

                PlayGame(isSavedGame);

                Console.Write("Would you like to play again? [y/n]: ");
                strUserInput = Console.ReadLine();

                if (strUserInput.ToLower() != "y")
                {
                    playAgain = false;
                }


            }
            while (playAgain);
        }

        /// <summary>
        /// Determines and validates a game with a suitable number of players
        /// </summary>
        static int InitialisePlayers()
        {
            int numPlayers = 0;

            do
            {
                Console.Write("How many players? : ");

                if (!int.TryParse(Console.ReadLine(), out numPlayers))
                {
                    Console.Write("You must choose a [1], [2], or [3] player game");
                }

            } while (numPlayers <= 0 || numPlayers > 3);

            for (int i = 0; i < numPlayers; i++)
            {
                Console.Write("Enter the name for player {0}: ", (i + 1));
                _state.Players[i].Name = Console.ReadLine();
                _state.Players[i].PlayerNumber = i;
                _state.Players[i].Score = 0;
                _state.Players[1].IsComputer = false;
            }

            // If it's a 1 player game, we'll make a second player as a computer player.
            if (numPlayers == 1)
            {
                _state.Players[1].Name = "COMPUTER";
                _state.Players[1].PlayerNumber = 1;
                _state.Players[1].Score = 0;
                _state.Players[1].IsComputer = true;

                numPlayers++;
            }

            // Blank player template for default top scores
            Player blankPlayer = new Player();
            blankPlayer.Name = "";
            blankPlayer.PlayerNumber = -1;
            blankPlayer.Score = 0;
            blankPlayer.IsComputer = false;

            // If the third player is not being used, just initialise the values to avoid an error saving/loading a binary file.
            if (numPlayers == 2)
            {
                _state.Players[2] = blankPlayer;
            }

            // Initialise the 5 possible top scores to default values for saving/loading of a binary file
            for (int i = 0; i < 5; i++)
            {
                _state.TopScores[i] = blankPlayer;
            }

            _state.CurrentPlayer = blankPlayer;

            return numPlayers;
        }

        /// <summary>
        /// Tha main subroutine for game logic
        /// </summary>
        static void PlayGame(bool isSavedGame)
        {
            if (!isSavedGame)
            {
                int diceValue = RollDice(_state.NumberOfPlayers);
                _state.CurrentPlayer = _state.Players[diceValue];

                Console.WriteLine("THE DICE HAS ROLLED - {0} YOU'RE GOING FIRST!", _state.CurrentPlayer.Name);
            }

            while (_state.ActiveGame == true)
            {
                DrawMatches();

                Console.WriteLine("Looks like you're up next, {0}!", _state.CurrentPlayer.Name);

                if (!PerformTurn()) // This was a losing move
                {
                    Console.WriteLine("Oh dear {0} - YOU LOSE!", _state.CurrentPlayer.Name);
                    _state.CurrentPlayer.Score = 0;

                    ShowGameScores();

                    _state.ActiveGame = false;
                }
                else // Otherwise it's the next persons turn
                {
                    // This if statement caters for multiple players (i.e. more than 2 if required).
                    if (_state.CurrentPlayer.PlayerNumber == (_state.NumberOfPlayers - 1))
                    {
                        _state.CurrentPlayer = _state.Players[0];
                    }
                    else
                    {
                        _state.CurrentPlayer = _state.Players[_state.CurrentPlayer.PlayerNumber + 1];
                    }
                }
            }
        }

        /// <summary>
        /// Called each time it's a different players turn
        /// Returns FALSE if this is a losing turn
        /// </summary>
        static bool PerformTurn()
        {
            int matchesToRemove = 0;

            if (_state.CurrentPlayer.IsComputer)
            {
                // Computer players have an amazing algorithm of a random amount of matches to remove!
                // Obviously this algorithm could be improved!
                // One way would perhaps be to tactically determine the number to remove based on the number left (like a human does).
                matchesToRemove = RollDice(3);
            }
            else
            {
                do
                {
                    Console.WriteLine("How many matches would you like to remove, {0}?", _state.CurrentPlayer.Name);

                    if (!int.TryParse(Console.ReadLine(), out matchesToRemove))
                    {
                        Console.Write("You can only remove between one and three matches!");
                    }

                } while (matchesToRemove <= 0 || matchesToRemove > 3);
            }

            Console.WriteLine("Removing {0} matches for {1}", matchesToRemove, _state.CurrentPlayer.Name);
            _state.MatchesRemaining -= matchesToRemove;

            if (_state.MatchesRemaining > 0) // This is fine - we'll update the scores
            {
                _state.Players[_state.CurrentPlayer.PlayerNumber].Score += matchesToRemove;
            }

            return (_state.MatchesRemaining > 0); // This returns true if the matches remaining is 0 or higher
        }

        /// <summary>
        /// Draws the correct current number of matches
        /// </summary>
        static void DrawMatches()
        {
            ConsoleColor defaultColour = Console.ForegroundColor;

            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("There are {0} matches remaining", _state.MatchesRemaining);
            Console.WriteLine();

            for (int i = 0; i < _state.MatchesRemaining; i++)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.Write(" 0 "); // Match head
                Console.ForegroundColor = defaultColour;
            }

            Console.WriteLine();

            for (int i = 0; i < 2; i++)
            {
                for (int j = 0; j < _state.MatchesRemaining; j++)
                {
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    Console.Write(" | "); // Match stick part
                    Console.ForegroundColor = defaultColour;
                }

                Console.WriteLine();
            }

            Console.ForegroundColor = defaultColour;
        }

        /// <summary>
        /// Displays the scores and determines if there's a new top score
        /// </summary>
        static void ShowGameScores()
        {
            for (int i = 0; i < _state.NumberOfPlayers - 1; i++)
            {
                Console.WriteLine("{0} you scored {1}", _state.Players[i].Name, _state.Players[i].Score);
                CheckForTopScore(_state.Players[i]);
            }
        }

        /// <summary>
        /// Use a linear search to determine if we have a new top score, if we do, add it in.
        /// </summary>
        private static void CheckForTopScore(Player player)
        {
            for (int i = 0; i < _state.TopScores.Length - 1; i++)
            {
                if (_state.TopScores[i].Score < player.Score)
                {
                    Console.WriteLine("NEW TOP SCORE FOR {0} - Placed at position {1}", player.Name, i + 1);
                    _state.TopScores[i] = player;
                    break;
                }
            }
        }

        /// <summary>
        /// Simulates throwing a coin/dice of specified sides
        /// </summary>
        static int RollDice(int sides)
        {
            return _rng.Next(1, sides);
        }

        /// <summary>
        /// Saves the current state of the game to three binary files
        /// </summary>
        static void SaveGameState()
        {
            BinaryWriter bw = new BinaryWriter(new FileStream(SAVEFILE_STATE, FileMode.Create));
            bw.Write(_state.NumberOfPlayers);
            bw.Write(_state.MatchesRemaining);
            bw.Write(_state.ActiveGame);
            bw.Close();

            // SAVE TOP SCORES ARRAY
            bw = new BinaryWriter(new FileStream(SAVEFILE_TOPSCORES, FileMode.Create));
            for (int i = 0; i < _state.TopScores.Length - 1; i++)
            {
                bw.Write(_state.TopScores[i].PlayerNumber);
                bw.Write(_state.TopScores[i].Name);
                bw.Write(_state.TopScores[i].Score);
                bw.Write(_state.TopScores[i].IsComputer);
            }
            bw.Close();

            // SAVE PLAYERS ARRAY
            bw = new BinaryWriter(new FileStream(SAVEFILE_PLAYERS, FileMode.Create));
            for (int i = 0; i < _state.Players.Length - 1; i++)
            {
                bw.Write(_state.Players[i].PlayerNumber);
                bw.Write(_state.Players[i].Name);
                bw.Write(_state.Players[i].Score);
                bw.Write(_state.Players[i].IsComputer);
            }
            bw.Close();

            // SAVE PLAYERS ARRAY
            bw = new BinaryWriter(new FileStream(SAVEFILE_CURRENT_PLAYER, FileMode.Create));
            for (int i = 0; i < _state.Players.Length - 1; i++)
            {
                bw.Write(_state.CurrentPlayer.PlayerNumber);
                bw.Write(_state.CurrentPlayer.Name);
                bw.Write(_state.CurrentPlayer.Score);
                bw.Write(_state.CurrentPlayer.IsComputer);
            }
            bw.Close();




            Console.WriteLine("THE GAME HAS BEEN SAVED TO {0}", SAVEFILE_STATE);
        }

        /// <summary>
        /// Load the current state of the game from the three binary files
        /// </summary>
        static void LoadGameState()
        {
            // LOAD TOP SCORES ARRAY
            BinaryReader br = new BinaryReader(new FileStream(SAVEFILE_TOPSCORES, FileMode.Open));
            for (int i = 0; i < _state.TopScores.Length - 1; i++)
            {
                _state.TopScores[i].PlayerNumber = br.ReadInt32();
                _state.TopScores[i].Name = br.ReadString();
                _state.TopScores[i].Score = br.ReadInt32();
                _state.TopScores[i].IsComputer = br.ReadBoolean();
            }
            br.Close();

            // LOAD PLAYERS ARRAY
            br = new BinaryReader(new FileStream(SAVEFILE_PLAYERS, FileMode.Open));
            for (int i = 0; i < _state.Players.Length - 1; i++)
            {
                _state.Players[i].PlayerNumber = br.ReadInt32();
                _state.Players[i].Name = br.ReadString();
                _state.Players[i].Score = br.ReadInt32();
                _state.Players[i].IsComputer = br.ReadBoolean();
            }
            br.Close();

            // LOAD THE GAME STATE
            br = new BinaryReader(new FileStream(SAVEFILE_STATE, FileMode.Open));
            _state.NumberOfPlayers = br.ReadInt32();
            _state.MatchesRemaining = br.ReadInt32();
            _state.ActiveGame = br.ReadBoolean();
            br.Close();

            // SAVE PLAYERS ARRAY
            br = new BinaryReader(new FileStream(SAVEFILE_CURRENT_PLAYER, FileMode.Open));
            _state.CurrentPlayer.PlayerNumber = br.ReadInt32();
            _state.CurrentPlayer.Name = br.ReadString();
            _state.CurrentPlayer.Score = br.ReadInt32();
            _state.CurrentPlayer.IsComputer = br.ReadBoolean();
            br.Close();
        }
    }
}
