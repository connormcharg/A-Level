namespace FileHandling
{
    internal class Program
    {
        static void Main(string[] args)
        {
            /*var reader = new StreamReader("topScores.txt");
            var lines = new List<Line>();

            List<string>? l;

            while ((l = reader.ReadLine()?.Split(',').ToList()) != null)
            {
                lines.Add(new Line
                {
                    Name = l[0],
                    Character = l[1],
                    Score = int.Parse(l[2])
                });
            }

            reader.Close();

            lines.Sort((x, y) => y.Score.CompareTo(x.Score));

            foreach (Line line in lines)
            {
                Console.WriteLine($"{line.Name} {line.Character} {line.Score}");
            }*/

            while (true)
            {
                Console.WriteLine("Would you like to create, list, or quit? (c/l/q)");
                string? input = Console.ReadLine();
                if (input == "c")
                {
                    Console.WriteLine("Enter a name:");
                    string? name = Console.ReadLine();

                    Console.WriteLine("Enter a score:");
                    string? score = Console.ReadLine();

                    Create(name, score);
                }
                else if (input == "l")
                {
                    List();
                }
                else if (input == "q")
                {
                    return;
                }
            }
        }

        /*struct Line
        {
            public string Name;
            public string Character;
            public int Score;
        }*/
        struct Line
        {
            public string Name;
            public int Score;
        }

        static void Create(string? name, string? score)
        {
            if (name == null || score == null)
            {
                Console.WriteLine("Name or score cannot be null.");
                return;
            }

            using (var writer = new BinaryWriter(new FileStream("topScores.bin", FileMode.Append, FileAccess.Write)))
            {
                writer.Write(name);
                writer.Write(int.Parse(score));
            }

            Console.WriteLine("Score saved.");
        }

        static void List()
        {
            using (var reader = new BinaryReader(new FileStream("topScores.bin", FileMode.Open, FileAccess.Read)))
            {
                var lines = new List<Line>();
                while (reader.BaseStream.Position != reader.BaseStream.Length)
                {
                    string name = reader.ReadString();
                    int score = reader.ReadInt32();
                    lines.Add(new Line
                    {
                        Name = name,
                        Score = score
                    });
                }
                lines.Sort((x, y) => y.Score.CompareTo(x.Score));
                foreach (Line line in lines)
                {
                    Console.WriteLine($"{line.Name} {line.Score}");
                }
            }
        }
    }
}
