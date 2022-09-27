using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectPhase2
{
    class OneDayTeam: Player, ITeam
    {
        public static List<Player> oneDayTeam = new List<Player>();
        public OneDayTeam()
        {
            oneDayTeam.Capacity = 11;
        }
        public void Add(Player player)
        {
         oneDayTeam.Add(player);
        }
        public void Remove(int playerId)
        {
            Player p = null;

            foreach (var i in oneDayTeam)
            {
                if (i.PlayerId == playerId)
                {
                    Console.WriteLine("Player{0} details is removed successfully", i.PlayerId);
                    p = i;
                }
            }
            oneDayTeam.Remove(p);
        }
        public Player GetPlayerById(int playerId)
        {
            Player p = null;

            foreach (var i in oneDayTeam)
            {
                if (i.PlayerId == playerId)
                {
                    p = i;
                    break;
                }
            }
            return p;
        }
        public Player GetPlayerByName(string playerName)
        {
            Player p = null;

            foreach (var i in oneDayTeam)
            {
                if (i.PlayerName == playerName)
                {
                    p = i;
                    break;
                }
            }
            return p;
        }

        public List<Player> GetAllPlayers()
        {
            return oneDayTeam;
        }
    }
}
