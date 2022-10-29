using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace U3_19
{
    /// <summary>
    /// For storing player data
    /// </summary>
    class Player
    {
        public string Name { get; set; }
        public string LastName { get; set; }
        public string Team { get; set; }
        public Position Position { get; set; }
        public string Champion { get; set; }
        public int Kills { get; set; }
        public int Assists { get; set; }
        /// <summary>
        /// Constructor for player
        /// </summary>
        /// <param name="name"> Name of player </param>
        /// <param name="lastName"> Surname of player </param>
        /// <param name="team"> Team of player </param>
        /// <param name="position"> Position of player </param>
        /// <param name="champion"> Champion of player </param>
        /// <param name="kills"> Kills of player </param>
        /// <param name="assists"> Assists of player </param>
        public Player(string name, string lastName, string team, Position position, string champion, int kills, int assists)
        {
            this.Name = name;
            this.LastName = lastName;
            this.Team = team;
            this.Position = position;
            this.Champion = champion;
            this.Kills = kills;
            this.Assists = assists;
        }
        /// <summary>
        /// Compares players
        /// </summary>
        /// <param name="other"> player that is compared </param>
        /// <returns> comparison </returns>
        public int CompareTo(Player other)
        {
            if (this.Team.CompareTo(other.Team) == 0)
            {
                if(this.LastName.CompareTo(other.LastName)==0)
                {
                   return this.Name.CompareTo(other.Name);
                }
                else
                {
                   return this.LastName.CompareTo(other.LastName);
                }
            }
            else
            {
                return this.Team.CompareTo(other.Team);
            }        
        }
        /// <summary>
        /// Checks to see if objects are equal
        /// </summary>
        /// <param name="obj"> object that is checked </param>
        /// <returns> TRUE or FALSE depending on the outcome of function </returns>
        public override bool Equals(object obj)
        {
            return obj is Player player &&
                   Name == player.Name &&
                   LastName == player.LastName &&
                   Team == player.Team &&
                   Champion == player.Champion;
        }
        /// <summary>
        /// prevents null reference errors and such
        /// </summary>
        /// <returns> the hash code </returns>
        public override int GetHashCode()
        {
            int hashCode = 1288566522;
            hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(Name);
            hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(LastName);
            hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(Team);
            hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(Champion);
            return hashCode;
        }
        /// <summary>
        /// formats writeline of player information
        /// </summary>
        /// <returns> formatted line variable </returns>
        public override string ToString()
        {
            string line;
            line = string.Format("|{0,-15}|{1,-15}|{2,-15}|{3,-10}|{4,-15}|{5,5}|{6,5}|", this.Name, this.LastName, this.Team, this.Position, this.Champion, this.Kills, this.Assists);
            return line;
        }
    }
}

