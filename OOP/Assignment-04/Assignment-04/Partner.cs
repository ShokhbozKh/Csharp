using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Assignment_04
{

    class Partner
    {
        public Guid IdPartner { get; set; }
        public int EntryPrice { get; set; }
        public string PartnerName { get; set; }
        public int PartnerInterest { get; set; }

        private readonly ICollection<PartnerType> _partnerTypes;

        public ICollection<PartnerType> PartnerTypes => _partnerTypes.ToHashSet();

        #region Constructors
        public Partner(int entryPrice, string partnerName, int partnerInterest)
        {
            IdPartner = Guid.NewGuid();
            EntryPrice = entryPrice;
            PartnerName = partnerName;
            PartnerInterest = partnerInterest;

            _partnerTypes = new List<PartnerType>();
        }

        public Partner(int entryPrice, string partnerName, int partnerInterest, ICollection<PartnerType> partnerTypes)
        {
            IdPartner = Guid.NewGuid();
            EntryPrice = entryPrice;
            PartnerName = partnerName;
            PartnerInterest = partnerInterest;

            _partnerTypes = new List<PartnerType>();

            foreach (PartnerType partnerType in partnerTypes)
                _partnerTypes.Add(partnerType);
        }

        #endregion

        public void AddPartnerType(PartnerType partnerType)
        {
            if (_partnerTypes.Contains(partnerType))
            {
                Console.WriteLine("Existing type cannot be added to the partner!");

                return;
            }

            _partnerTypes.Add(partnerType);
        }

        public void RemovePartnerType(PartnerType partnerType)
        {
            if (_partnerTypes.Contains(partnerType)) _partnerTypes.Remove(partnerType);
            else Console.WriteLine("This partner does not contain given type!");
        }

        public void ShowTypes()
        {
            foreach(PartnerType partnerType in _partnerTypes)
                Console.WriteLine(partnerType);
        }
    }

    enum PartnerType
    {
        PrivatePartner,
        AgencyPartner,
        IndividualPartner
    }
}
