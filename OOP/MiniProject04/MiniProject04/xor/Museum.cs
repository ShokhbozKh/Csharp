using System;
using System.Collections.Generic;
using System.Collections.Immutable;

namespace MiniProject04.xor
{
    public class Museum
    {
        public int IdMuseum { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
        public string Description { get; set; }
        public DateTime FoundationDate { get; set; }

        private ICollection<Picture> _pictures;

        public ICollection<Picture> Pictures => _pictures.ToImmutableHashSet();

        public Museum(int idMuseum, string name, string address, string description, DateTime foundationDate)
        {
            IdMuseum = idMuseum;
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
    }
}