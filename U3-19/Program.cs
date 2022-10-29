using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace U3_19
{
    internal class Program
    {
        static void Main(string[] args)
        {                    
            Console.InputEncoding = Encoding.GetEncoding(1257);
            Console.OutputEncoding = Encoding.UTF8;
            string Team1C1, Team1C2, Team2C1, Team2C2;          
            Register register1 = InOut.Read("Dalyviai1.csv", out Team1C1, out Team2C1);
            Register register2 = InOut.Read("Dalyviai2.csv", out Team1C2, out Team2C2);

           Player player = new Player("NAME", "LASTNAME", "Based", Position.Jungle, "CHAMPION", 99, 99);

            //  register1.RemoveAt(0);
            // register1.Insert(player,0);
            // register2.Put(player,0);
            // register2.Remove(player);


            Register register3 = register1.Merge(register2);     
            InOut.PrintBestPlayers(register3, Position.Jungle, "Aktyviausi „Jungle“ pozicijoje žaidžiantys žaidėjai:");
            InOut.PrintBestTeams(register1, register2, Team1C1, Team2C1, Team1C2, Team2C2, "Kiekviename rate geriausiai bendradarbiavusios komandos:");      
            string fileName = "Čempionai.csv";
            InOut.PrintChampions(register3.FindChampions(), fileName);
            InOut.PrintAllToTXT(register1, register2);
            InOut.PrintAllToTXT(register1, register2);       
            register3.Sort();     
            InOut.Print(register3, "Pasikeitimai.csv", "Visi zaidejai:");
        }
    }
}
