using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace U3_19
{
    /// <summary>
    /// Container class
    /// </summary>
    class Container
    {    
        public int Count { get; private set; }
        /// <summary>
        /// Array of players
        /// </summary>
        private Player[] players;
        private int Capacity;
        /// <summary>
        /// Declares size of array
        /// </summary>
        public Container()
        {
            this.players = new Player[25];
        }
        /// <summary>
        /// Adds specified player to array
        /// </summary>
        /// <param name="player"> player that is added </param>
        public void Add(Player player)
        {
            if (this.Count == this.Capacity)
            {
                EnsureCapacity(this.Capacity * 2);
            }
            this.players[this.Count++] = player;
        }
        /// <summary>
        /// places specified player in specified position even if occupied
        /// </summary>
        /// <param name="player"> player specified </param>
        /// <param name="index"> desired location for specified player </param>
        public void Put(Player player, int index)                      
        {
            if (this.Count == this.Capacity)
            {
                EnsureCapacity(this.Capacity * 2);
            }
            if (index > this.Count)
            {
                this.players[this.Count++] = player;
            }
            else
            {
                this.players[index] = player;
            }
        }
        /// <summary>
        /// Places a specified player in specified position by moving certain players to make room if needed
        /// </summary>
        /// <param name="player"> player specified </param>
        /// <param name="index"> desired location for specified player </param>
        public void Insert(Player player, int index)
        {
            if (this.Count == this.Capacity)
            {
                EnsureCapacity(this.Capacity * 2);
            }
            if (index > this.Count)
            {
                this.players[this.Count++] = player;
            }
            else
            {
                for (int i = this.Count + 1; i > index; i--)
                {
                    this.players[i] = this.players[i - 1];
                }
                this.players[index] = player;
                this.Count++;
            }
        }
        /// <summary>
        /// removes player inside specified index
        /// </summary>
        /// <param name="index"> index of desired location </param>
        public void RemoveAt(int index)                    
        {
            for (int i = index; i < this.Count - 1; i++)
            {
                this.players[i] = this.players[i + 1];
            }
            this.Count--;
        }
        /// <summary>
        /// Removes specified player
        /// </summary>
        /// <param name="player"> specified player </param>
        public void Remove(Player player)                        
        {

            for (int i = 0; i < this.Count; i++)
            {
                if (this.players[i] == player)
                {
                    for (int j = i; j < this.Count; j++)
                    {
                        this.players[j] = this.players[j + 1];
                    }
                    this.Count--;
                }
            }

        }
        /// <summary>
        /// Takes player by index
        /// </summary>
        /// <param name="index"> specified index </param>
        /// <returns> player with specified index </returns>
        public Player Get(int index)
        {
            return this.players[index];
        }
        /// <summary>
        /// checks for specified player
        /// </summary>
        /// <param name="player"> specified player </param>
        /// <returns> returns either TRUE or FALSE depending on the outcome of method </returns>
        public bool Contains(Player player)
        {
            for (int i = 0; i < this.Count; i++)
            {
                if (this.players[i].Equals(player))
                {
                    return true;
                }
            }
            return false;
        }
        /// <summary>
        /// makes sure size of array is the exact size required
        /// </summary>
        /// <param name="minimumCapacity"> minimum capacity </param>
        private void EnsureCapacity(int minimumCapacity)
        {
            if (minimumCapacity > this.Capacity)
            {
                Player[] temp = new Player[minimumCapacity];
                for (int i = 0; i < this.Count; i++)
                {
                    temp[i] = this.players[i];
                }
                this.Capacity = minimumCapacity;
                this.players = temp;
            }
        }
        /// <summary>
        /// sorts players of register specified
        /// </summary>
        public void Sort()
        {
            bool flag = true;
            while (flag)
            {
                flag = false;
                for (int i = 0; i < this.Count - 1; i++)
                {
                    Player a = this.players[i];
                    Player b = this.players[i + 1];
                    if (a.CompareTo(b) > 0)
                    {
                        this.players[i] = b;
                        this.players[i + 1] = a;
                        flag = true;
                    }
                }
            }
        }
    }
}
