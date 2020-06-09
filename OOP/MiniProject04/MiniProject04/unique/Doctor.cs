using System;
using System.Collections.Generic;

namespace MiniProject04
{
    public class Doctor
    {
        private static readonly IDictionary<int, Doctor> _licenseCodeDict = new Dictionary<int, Doctor>();

        public int IdDoctor { get; set; }
        public string Name { get; set; }

        public string Specialization { get; set; }

        /*
         * unique
         */
        private int _licenseCode;

        public int LicenseCode
        {
            get => _licenseCode;
            set
            {
                if (_licenseCodeDict.ContainsKey(value))
                {
                    throw new Exception("Doctor with such license code already exists");
                }

                _licenseCodeDict.Remove(_licenseCode);
                _licenseCode = value;
                _licenseCodeDict.Add(_licenseCode, this);
            }
        }

        public DateTime EmploymentDate { get; set; }

        public Doctor(int idDoctor, string name, string specialization, int licenseCode, DateTime employmentDate)
        {
            IdDoctor = idDoctor;
            Name = name;
            Specialization = specialization;
            LicenseCode = licenseCode;
            EmploymentDate = employmentDate;
        }

        public Doctor(int idDoctor, string name, string specialization, int licenseCode) : this(idDoctor, name,
            specialization, licenseCode, DateTime.Today)
        {
        }
    }
}