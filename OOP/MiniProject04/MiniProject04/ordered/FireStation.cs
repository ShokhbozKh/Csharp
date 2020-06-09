using System.Collections.Generic;
using System.Linq;

namespace MiniProject04.ordered
{
    public class FireStation
    {
        public int FireStationId { get; set; }
        public string Address { get; set; }

        private ICollection<Accident> _pendingAccidents = new HashSet<Accident>();

        public ICollection<Accident> PendingAccidents
        {
            get
            {
                var result = _pendingAccidents.ToList();
                result.Sort();
                return result;
            }
        }

        public void AddAccident(Accident accident)
        {
            if (accident == null || _pendingAccidents.Contains(accident))
            {
                return;
            }
            
            _pendingAccidents.Add(accident);
            accident.AssignedFireStation = this;
        }

        public void RemoveAccident(Accident accident)
        {
            if (accident == null || !_pendingAccidents.Contains(accident))
            {
                return;
            }

            _pendingAccidents.Remove(accident);
            accident.AssignedFireStation = this;
        }
    }
}