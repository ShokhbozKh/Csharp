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
        public double PartnerInterest { get; set; }

        private readonly ICollection<PartnerType> _partnerTypes;
        public ICollection<PartnerType> PartnerTypes => _partnerTypes.ToHashSet();

        private readonly ICollection<Driver> _drivers;
        public ICollection<Driver> Drivers 
        {
            get => _drivers;
        }

        #region Constructors
        public Partner(int entryPrice, string partnerName, double partnerInterest)
        {
            IdPartner = Guid.NewGuid();
            EntryPrice = entryPrice;
            PartnerName = partnerName;
            PartnerInterest = partnerInterest;

            _partnerTypes = new List<PartnerType>();
            _drivers = new List<Driver>();
        }

        public Partner(int entryPrice, string partnerName, double partnerInterest, ICollection<PartnerType> partnerTypes)
        {
            IdPartner = Guid.NewGuid();
            EntryPrice = entryPrice;
            PartnerName = partnerName;
            PartnerInterest = partnerInterest;

            _partnerTypes = new List<PartnerType>();
            _drivers = new List<Driver>();

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

        #region subset
        public void AddDriverLink(Driver driver)
        {
            if(driver is null)
            {
                Console.WriteLine("Driver cannot be null!");
                return;
            }

            if(_drivers.Where(s => s.UserId == driver.UserId) == null)
            {
                Console.WriteLine($"{driver} already cooperates with {PartnerName}");
                return;
            }

            _drivers.Add(driver);
            driver.AddPartnerLink(this);
        }

        public void RemoveDriverLink(Driver driver)
        {
            if(driver is null)
            {
                Console.WriteLine("Driver cannot be null!");
                
                return;
            }

            if(_drivers.Where(s => s.UserId == driver.UserId) == null)
            {
                Console.WriteLine($"Partner does not contain the driver: {driver.Login}!");

                return;
            }

            _drivers.Remove(driver);
            driver.RemovePartnerLink(this);
        }
        

        #endregion

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
