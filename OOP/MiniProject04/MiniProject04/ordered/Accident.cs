using System;

namespace MiniProject04.ordered
{
    public enum AccidentSeverity
    {
        Yellow = 3, 
        Orange = 2,
        Red = 1,
        Black = 0
    }

    public class Accident : IComparable<Accident>
    {
        public int AccidentId { get; set; }
        public string Address { get; set; }
        public DateTime CallDateTime { get; set; }
        public AccidentSeverity Severity { get; set; }

        private FireStation _assignedFireStation;

        public FireStation AssignedFireStation
        {
            get => _assignedFireStation;
            set
            {
                if (_assignedFireStation == null && value != null)
                {
                    _assignedFireStation = value;
                    _assignedFireStation.AddAccident(this);
                }
                else if (_assignedFireStation != null && value != null)
                {
                    _assignedFireStation.RemoveAccident(this);
                    _assignedFireStation = value;
                    _assignedFireStation.AddAccident(this);
                } 
                else if (_assignedFireStation != null && value == null)
                {
                    _assignedFireStation.RemoveAccident(this);
                    _assignedFireStation = null;
                }
            }
        }

        public int CompareTo(Accident other)
        {
            var result = Severity - other.Severity;

            return result == 0 ? CallDateTime.CompareTo(other.CallDateTime) : result;
        }
    }
}