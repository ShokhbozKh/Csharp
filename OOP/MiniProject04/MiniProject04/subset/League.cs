using System;
using System.Collections.Generic;
using System.Collections.Immutable;

namespace MiniProject04
{
    public class League
    {
        public int IdLeague { get; set; }
        public string Name { get; set; }

        private ICollection<Team> _members;

        public ICollection<Team> Members => _members.ToImmutableHashSet();

        private Team _champion;

        public Team Champion
        {
            get => _champion;
            set
            {
                if (value != null && !_members.Contains(value))
                {
                    throw new Exception($"Team #{value.IdTeam} is not a member of League #{IdLeague}");
                }
                
                if (_champion == null && value != null)
                {
                    _champion = value;
                    _champion.MakeChampion(this);
                }
                else if (_champion != null && value != null && _champion != value)
                {
                    _champion.MakeNotChampion(this);
                    _champion = value;
                    _champion.MakeChampion(this);
                }
                else if (_champion != null && value == null)
                {
                    _champion.MakeNotChampion(this);
                    _champion = null;
                }
            }
        }

        public League(int idLeague, string name)
        {
            IdLeague = idLeague;
            Name = name;

            _members = new HashSet<Team>();
        }

        public void AddMember(Team member)
        {
            if (member == null || _members.Contains(member))
            {
                return;
            }

            _members.Add(member);
            member.AddLeagueMembership(this);
        }

        public void RemoveMember(Team member)
        {
            if (member == null || !_members.Contains(member))
            {
                return;
            }

            _members.Remove(member);
            member.RemoveLeagueMembership(this);
        }
    }
}