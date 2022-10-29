using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace U3_19
{
    /// <summary>
    /// Class for reading and printing into files
    /// </summary>
    static class InOut
    {     
        /// <summary>
        /// reads data from file
        /// </summary>
        /// <param name="fileName"> name of file the information if read from </param>
        /// <param name="Team1"> name of first team </param>
        /// <param name="Team2"> name of second team </param>
        /// <returns> register of players </returns>
        public static Register Read(string fileName, out string Team1, out string Team2)
        {
            Team1 = "";
            Team2 = "";
            Container container = new Container();
            Register register = new Register();
            string[] Lines = File.ReadAllLines(fileName);
            register.Cycle = int.Parse(Lines[0]);
            register.CycleDate = DateTime.Parse(Lines[1]);

            foreach (string line in Lines.Skip(2))
            {
                string[] Values = line.Split(';');
                string name = Values[0];
                string lastName = Values[1];
                string team = Values[2];
                if (Team1 == "")
                {
                    Team1 = team;
                }
                else if (Team1 != team && Team2 == "")
                {
                    Team2 = team;
                }
                Position position;
                Enum.TryParse(Values[3], out position);

                string champion = Values[4];
                int kills = int.Parse(Values[5]);
                int assists = int.Parse(Values[6]);
                Player player = new Player(name, lastName, team, position, champion, kills, assists);
                container.Add(player);
                register.Add(player);
            }
            return register;
        }
        /// <summary>
        /// Prints all players into specified file
        /// </summary>
        /// <param name="register"> players register </param>
        /// <param name="fileName"> name of file </param>
        /// <param name="header"> describes contents of table </param>
        public static void Print(Register register, string fileName, string header)
        {
            if (File.Exists(fileName))
            {
                File.Delete(fileName);
            }
            string[] Lines = new string[register.Count() + 5];
            Lines[0] = header;
            Lines[1] = String.Format("");
            Lines[2] = String.Format("{0};{1};{2};{3};{4};{5};{6}", "Vardas","Pavarde","Komanda","Pozicija","Cempionas","K","A", Encoding.UTF8);
            Lines[3] = String.Format("");
            for (int i = 0; i < register.Count(); i++)
            {
                Player player = register.Get(i);
                Lines[i + 4] = String.Format("{0};{1};{2};{3};{4};{5};{6}", player.Name, player.LastName, player.Team, player.Position, player.Champion, player.Kills, player.Assists);
            }
            File.AppendAllLines(fileName, Lines);
        }
        /// <summary>
        /// Compares and prints out team with most assists
        /// </summary>
        /// <param name="players"> register of players </param>
        /// <param name="Team1"> first team </param>
        /// <param name="Team2"> second team </param>
        public static void PrintBestTeam(Register players, string Team1, string Team2)
        {
            int team1 = players.FindTeamAssists(Team1);
            int team2 = players.FindTeamAssists(Team2);
            if (team1 > team2)
            {
                Console.WriteLine("|{0,6}|{1,-10}|", players.Cycle, Team1);
            }
            else if (team2 > team1)
            {
                Console.WriteLine("|{0,6}|{1,-10}|", players.Cycle, Team2);
            }
            else
            {
                Console.WriteLine("|{0,6}|{1,-10}|", players.Cycle, Team1);
                Console.WriteLine("|{0,6}|{1,-10}|", players.Cycle, Team2);
            }
        }
        /// <summary>
        /// Prints out teams with most assists
        /// </summary>
        /// <param name="register1"> register of first cycle </param>
        /// <param name="register2"> register of second cycle </param>
        /// <param name="T1C1"> team 1 cycle 1</param>
        /// <param name="T2C1"> team 2 cycle 1</param>
        /// <param name="T1C2"> team 1 cycle 2</param>
        /// <param name="T2C2"> team 2 cycle 2</param>
        /// <param name="header"> describes contents of table </param>
        public static void PrintBestTeams(Register register1, Register register2, string T1C1, string T2C1, string T1C2, string T2C2, string header)
        {
            Console.WriteLine(header);
            Console.WriteLine(new string('-', 19));
            Console.WriteLine("|{0, 6}|{1, -10}|", "Ciklas", "Komanda");
            Console.WriteLine(new string('-', 19));
            PrintBestTeam(register1, T1C1, T2C1);
            PrintBestTeam(register2, T1C2, T2C2);
            Console.WriteLine(new string('-', 19));
        }
        /// <summary>
        /// Prints best player
        /// </summary>
        /// <param name="register3"> register containing data from both cycles </param>
        /// <param name="position"> position of players to sort </param>
        public static void PrintBestPlayer(Register register3, Position position)
        {
            int count = register3.FindBiggestKA(position);         
            Console.WriteLine(new String('-', 56));
            Console.WriteLine("|{0, -10}|{1, -10}|{2, -10}|{3, -10}|{4, -10}|", "Vardas", "Pavardė", "Komanda", "Pozicija", "Čempionas");
            Console.WriteLine(new String('-', 56));
            for (int i = 0; i < register3.Count(); i++)
            {
                if (register3.GetKA(i) == count)
                {
                    Player player = register3.Get(i);
                    Console.WriteLine("|{0,-10}|{1,-10}|{2,-10}|{3,-10}|{4,-10}|", player.Name, player.LastName, player.Team, player.Position, player.Champion);
                }
            }
            Console.WriteLine(new String('-', 56));
        }
        /// <summary>
        /// Prints list of all champions participating
        /// </summary>
        /// <param name="champions"> list of champions </param>
        /// <param name="fileName"> name of file to print into </param>
        public static void PrintChampions(List<string> champions, string fileName)
        {
            string[] lines = new string[champions.Count];

            for (int i = 0; i < champions.Count; i++)
            {
                lines[i] = champions[i] + ';';
            }
            if (File.Exists(fileName))
            {
                File.Delete(fileName);
            }
            File.WriteAllLines(fileName, lines, Encoding.UTF8);
        }
        /// <summary>
        /// Prints data of specified cycle to .txt file
        /// </summary>
        /// <param name="players"> register of players </param>
        public static void PrintTXT(Register players)
        {
            string[] Lines = new string[players.Count() + 12];
            Lines[0] = String.Format("Rato numeris: {0}", players.Cycle);
            Lines[1] = String.Format("Data: {0:yyyy-MM-dd}", players.CycleDate);
            Lines[2] = String.Format("");
            Lines[3] = String.Format(new string('-', 87));
            Lines[4] = String.Format("|{0, -15}|{1, -15}|{2, -15}|{3, -10}|{4, -15}|{5, -5}|{6, -5}|", "Vardas", "Pavardė", "Komanda", "Pozicija", "Čempionas", "K", "A");
            Lines[5] = String.Format(new string('-', 87));
            for (int i = 0; i < players.Count(); i++)
            {
                Player player = players.Get(i);
                Lines[i + 6] = String.Format(player.ToString());
            }
            Lines[players.Count() + 6] = String.Format(new string('-', 87));

            File.AppendAllLines("Žaidėjai.txt", Lines);
        }
        /// <summary>
        /// Prints data of both cycles into txt
        /// </summary>
        /// <param name="register1"> register of first cycle </param>
        /// <param name="register2"> register of second cycle </param>
        public static void PrintAllToTXT(Register register1, Register register2)
        {
            if (File.Exists("Žaidėjai.txt"))
            {
                File.Delete("Žaidėjai.txt");
            }
            PrintTXT(register1);
            PrintTXT(register2);
        }
        /// <summary>
        /// Prints best players
        /// </summary>
        /// <param name="register"> register with cycle data </param>
        /// <param name="position"> position of player </param>
        /// <param name="header"> describes contents printed </param>
        public static void PrintBestPlayers(Register register, Position position, string header)
        {
            int count = register.FindBiggestKA(position);
            Console.WriteLine(header);
            Console.WriteLine(new string('-', 88));
            Console.WriteLine("|{0,-15}|{1,-15}|{2,-15}|{3,-10}|{4,-15}|{5,-5}|{6,-5}|", "Vardas", "Pavardė", "Komanda", "Pozicija", "Čempionas", "K", "A");
            Console.WriteLine(new string('-', 88));
            for(int i=0;i<register.Count();i++)
            {
                Player player = register.Get(i);
                if (count == player.Kills + player.Assists && player.Position.Equals(position))
                {
                    Console.WriteLine("|{0,-15}|{1,-15}|{2,-15}|{3,-10}|{4,-15}|{5,5}|{6,5}|", player.Name, player.LastName, player.Team, player.Position, player.Champion, player.Kills, player.Assists);
                }
            }
            Console.WriteLine(new string('-', 88));
            Console.WriteLine();
        }

    }
}

    

