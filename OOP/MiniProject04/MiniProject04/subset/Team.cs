using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.Immutable;

namespace MiniProject04
{
    public class Team
    {
        public int IdTeam { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }

        private ICollection<League> _membersips;
        public ICollection<League> Memberships => _membersips.ToImmutableHashSet();

        private ICollection<League> _championships;
        public ICollection<League> Chapmionships => _championships.ToImmutableHashSet();

        public Team(int idTeam, string name, string description)
        {
            IdTeam = idTeam;
            Name = name;
            Description = description;

            _membersips = new HashSet<League>();
            _championships = new HashSet<League>();
        }

        public void AddLeagueMembership(League league)
        {
            if (league == null || _membersips.Contains(league))
            {
                return;
            }

            _membersips.Add(league);
            league.AddMember(this);
        }

        public void RemoveLeagueMembership(League league)
        {
            if (league == null || !_membersips.Contains(league))
            {
                return;
            }

            if (_championships.Contains(league))
            {
                MakeNotChampion(league);
            }

            _membersips.Remove(league);
            league.RemoveMember(this);
        }

        public void MakeChampion(League league)
        {
            if (league == null || _championships.Contains(league))
            {
                return;
            }

            if (!_membersips.Contains(league))
            {
                throw new Exception($"Team #{IdTeam} is not a member of League #{league.IdLeague}");
            }

            _championships.Add(league);
            league.Champion = this;
        }

        public void MakeNotChampion(League league)
        {
            if (league == null || !_championships.Contains(league))
            {
                return;
            }
            
            if (!_membersips.Contains(league))
            {
                throw new Exception($"Team #{IdTeam} is not a member of League #{league.IdLeague}");
            }

            _championships.Remove(league);
            league.Champion = null;
        }
    }
}