using System;
using System.Collections.Generic;
using System.Collections.Immutable;

namespace MiniProject04.xor
{
    public class Person
    {
        public int IdPerson { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public DateTime BirthDate { get; set; }

        private ICollection<Picture> _pictures;

        public ICollection<Picture> Pictures => _pictures.ToImmutableHashSet();

        public Person(int idPerson, string name, string surname, DateTime birthDate)
        {
            IdPerson = idPerson;
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
    }
}