using System;
using System.Collections.Generic;
using System.Collections.Immutable;

namespace Assignment_04.XOR
{
    public class Museum
    {
        public Guid IdMuseum { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
        public string Description { get; set; }
        public DateTime FoundationDate { get; set; }

        private readonly ICollection<Picture> _pictures;

        public ICollection<Picture> Pictures => _pictures.ToImmutableHashSet();

        public Museum(string name, string address, string description, DateTime foundationDate)
        {
            IdMuseum = Guid.NewGuid();
            Name = name;
            Address = address;
            Description = description;
            FoundationDate = foundationDate;

            _pictures = new HashSet<Picture>();
        }

        public void AddPicture(Picture picture)
        {
            if (picture == null || _pictures.Contains(picture))
            {
                return;
            }

            _pictures.Add(picture);
            picture.MuseumOwner = this;
        }

        public void RemovePicture(Picture picture)
        {
            if (picture == null || !_pictures.Contains(picture))
            {
                return;
            }

            _pictures.Remove(picture);
            picture.MuseumOwner = null;
        }

        public override string ToString()
        {
            return $"Museum: [{Name}]";
        }
    }
}