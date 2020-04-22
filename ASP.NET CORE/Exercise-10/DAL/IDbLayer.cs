using Exercise_10.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Exercise_10.DAL
{
    interface IDblayer
    {
        IEnumerable<Player> GetPlayers();
        IEnumerable<Team> GetTeams();
        void AddPlayer(Player playerToAdd);
    }
}
