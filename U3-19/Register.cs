
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;

namespace U3_19
{
    /// <summary>
    /// Register class
    /// </summary>
    class Register
    {
        public int Cycle { get; set; }
        public DateTime CycleDate { get; set; }
        /// <summary>
        /// Container for storing certain information
        /// </summary>
        private Container AllPlayers = new Container();     
        /// <summary>
        /// Adds specified player to AllPlayers
        /// </summary>
        /// <param name="player"> specified player </param>
        /// <returns> AllPlayers container with specified player added </returns>
        public Container Add(Player player)
        {
            if (!AllPlayers.Contains(player))
            {
                this.AllPlayers.Add(player);
            }
            return AllPlayers;
        }
        /// <summary>
        /// Count method
        /// </summary>
        /// <returns> Count of AllPlayers container </returns>
        public int Count()
        {
            return AllPlayers.Count;
        }
        /// <summary>
        /// Takes player by index
        /// </summary>
        /// <param name="index"> specified index </param>
        /// <returns> player inside index slot </returns>
        public Player Get(int index)
        {
            return AllPlayers.Get(index);
        }
        /// <summary>
        /// Finds team assists
        /// </summary>
        /// <param name="team"> specified team </param>
        /// <returns> assists of specifed team </returns>
        public int FindTeamAssists(string team)
        {
            int count = 0;
            for (int i = 0; i < Count(); i++)
            {
                Player player = this.Get(i);
                if (player.Team.Equals(team))
                {
                    count += player.Assists;
                }
            }
            return count;
        }
        /// <summary>
        /// Finds biggest kill assist ratio
        /// </summary>
        /// <param name="position"> specified position </param>
        /// <returns> the largest kill assist ratio of specified position </returns>
        public int FindBiggestKA(Position position)
        {
            int count = 0;
            for (int i = 0; i < Count(); i++)
            {
                Player player = this.Get(i);
                if (position == player.Position)
                {
                    if (player.Kills + player.Assists > count)
                    {
                        count = player.Kills + player.Assists;
                    }
                }
            }
            return count;
        }
        /// <summary>
        /// Merges specified register
        /// </summary>
        /// <param name="register"> specified register </param>
        /// <returns> register containing both registers </returns>
        public Register Merge(Register register)
        {
            Register r3 = new Register();
            for (int i = 0; i < this.Count(); i++)
            {
                r3.Add(register.Get(i));
                r3.Add(this.Get(i));
            }
            return r3;
        }
        /// <summary>
        /// Places a specified player in specified position by moving certain players to make room if needed
        /// </summary>
        /// <param name="player"> specified player </param>
        /// <param name="index"> specified index </param>
        public void Insert(Player player, int index)
        {
            AllPlayers.Insert(player, index);
        }
        /// <summary>
        /// places specified player in specified position even if occupied
        /// </summary>
        /// <param name="player"> specified player </param>
        /// <param name="index"> specified index </param>
        public void Put(Player player, int index)
        {
            AllPlayers.Put(player, index);
        }
        /// <summary>
        /// Removes specified player
        /// </summary>
        /// <param name="player"> specified player </param>
        public void Remove(Player player)
        {
            AllPlayers.Remove(player);
        }
        /// <summary>
        /// removes player inside specified index
        /// </summary>
        /// <param name="index"> specified index</param>
        public void RemoveAt(int index)
        {
            AllPlayers.RemoveAt(index);
        }
        /// <summary>
        /// Gets sum of kills and assists
        /// </summary>
        /// <param name="index"> specified index </param>
        /// <returns> sum of kills and assists </returns>
        public int GetKA(int index)
        {
            return AllPlayers.Get(index).Assists + AllPlayers.Get(index).Kills;
        }
        /// <summary>
        /// Finds all champions
        /// </summary>
        /// <returns> list of all champions </returns>
        public List<string> FindChampions()
        {
            List<string> Champions = new List<string>();
            for (int i = 0; i < Count(); i++)
            {
                Player player = this.Get(i);
                string champion = player.Champion;
                if (!Champions.Contains(champion))
                {
                    Champions.Add(champion);
                }
            }
            return Champions;
        }    
        /// <summary>
        /// calls out sort method from container
        /// </summary>
        public void Sort()
        {
            AllPlayers.Sort();
        }     
    }
}

