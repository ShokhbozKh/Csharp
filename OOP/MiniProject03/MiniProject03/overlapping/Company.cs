using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using MiniProject01;

namespace MiniProject03.overlapping
{
    public abstract class Company
    {
        public int IdCompany { get; set; }
        public string Name { get; set; }

        private ICollection<CompanyType> _companyTypes;

        public ICollection<CompanyType> CompanyTypes => _companyTypes.ToHashSet();

        private ICollection<AdvertisementType> _advertisementTypesOfInterest;

        public ICollection<AdvertisementType> AdvertisementTypesOfInterest
        {
            get
            {
                if (!_companyTypes.Contains(CompanyType.Advertiser))
                {
                    return null;
                }

                return _advertisementTypesOfInterest.ToHashSet();
            }
            private set
            {
                if (!_companyTypes.Contains(CompanyType.Advertiser))
                {
                    throw new Exception("The company is not an advertiser");
                }

                _advertisementTypesOfInterest = value.ToHashSet() ?? throw new ArgumentNullException();
            }
        }

        private ICollection<Album> _albums;

        public ICollection<Album> Albums
        {
            get
            {
                if (!_companyTypes.Contains(CompanyType.RecordLabel))
                {
                    return null;
                }

                return _albums.ToHashSet();
            }
            set
            {
                if (!_companyTypes.Contains(CompanyType.RecordLabel))
                {
                    throw new Exception("The company is not a record label");
                }

                _albums = value.ToHashSet() ?? throw new ArgumentNullException();
            }
        }

        public Company(int idCompany, string name, ICollection<AdvertisementType> advertisementTypesOfInterest,
            ICollection<Album> albums, ICollection<CompanyType> companyTypes)
        {
            IdCompany = idCompany;
            Name = name;
            foreach (var type in companyTypes)
            {
                _companyTypes.Add(type);
                
                if (type == CompanyType.Advertiser)
                {
                    AdvertisementTypesOfInterest = advertisementTypesOfInterest;
                }
                else if (type == CompanyType.RecordLabel)
                {
                    Albums = albums;
                }
                else
                {
                    throw new InvalidEnumArgumentException();
                }
            }
        }

        public void AddAlbum(Album album)
        {
            if (!_companyTypes.Contains(CompanyType.RecordLabel))
            {
                throw new Exception("The company is not a record label");
            }

            _albums.Add(album);
        }

        public void RemoveAlbum(Album album)
        {
            if (!_companyTypes.Contains(CompanyType.RecordLabel))
            {
                throw new Exception("The company is not a record label");
            }

            _albums.Remove(album);
        }

        public void AddAdvertisementType(AdvertisementType type)
        {
            if (!_companyTypes.Contains(CompanyType.Advertiser))
            {
                throw new Exception("The company is not an advertiser");
            }

            _advertisementTypesOfInterest.Add(type);
        }

        public void RemoveAdvertisementType(AdvertisementType type)
        {
            if (!_companyTypes.Contains(CompanyType.Advertiser))
            {
                throw new Exception("The company is not an advertiser");
            }

            _advertisementTypesOfInterest.Remove(type);
        }
    }
}