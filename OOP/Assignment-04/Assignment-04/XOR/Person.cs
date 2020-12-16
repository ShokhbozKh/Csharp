using System;
using System.Collections.Generic;
using System.Collections.Immutable;

namespace Assignment_04.XOR
{
    public class Person
    {
        public Guid IdPerson { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public DateTime BirthDate { get; set; }

        private readonly ICollection<Picture> _pictures;

        public ICollection<Picture> Pictures => _pictures.ToImmutableHashSet();

        public Person(string name, string surname, DateTime birthDate)
        {
            IdPerson = Guid.NewGuid();
            Name = name;
            Surname = surname;
            BirthDate = birthDate;

            _pictures = new HashSet<Picture>();
        }

        public void AddPicutre(Picture picture)
        {
            if (picture == null || _pictures.Contains(picture))
            {
                return;
            }

            _pictures.Add(picture);
            picture.PersonOwner = this;
        }

        public void RemovePicture(Picture picture)
        {
            if (picture == null || !_pictures.Contains(picture))
            {
                return;
            }

            _pictures.Remove(picture);
            picture.PersonOwner = null;
        }

        public override string ToString()
        {
            return $"Person: [{Name}]";
        }
    }
}
