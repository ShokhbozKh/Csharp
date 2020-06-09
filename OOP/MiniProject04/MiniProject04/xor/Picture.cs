using System;

namespace MiniProject04.xor
{
    public class Picture
    {
        public int IdPicture { get; set; }
        public string AuthorName { get; set; }
        public string Description { get; set; }
        public DateTime PaintDate { get; set; }

        /*
         * xor
         */
        private Person _personOwner;

        public Person PersonOwner
        {
            get => _personOwner;
            set
            {
                if (_personOwner == null && _museumOwner == null && value != null)
                {
                    _personOwner = value;
                    _personOwner.AddPicutre(this);
                }
                else if (_personOwner != null && value == null)
                {
                    _personOwner.RemovePicture(this);
                    _personOwner = null;
                }
                else if (_museumOwner != null && value != null)
                {
                    _museumOwner.RemovePicture(this);
                    _museumOwner = null;
                    _personOwner = value;
                    _personOwner.AddPicutre(this);
                }
                else if (_personOwner != null && value != null)
                {
                    _personOwner.RemovePicture(this);
                    _personOwner = value;
                    _personOwner.AddPicutre(this);
                }
            }
        }

        private Museum _museumOwner;

        public Museum MuseumOwner
        {
            get => _museumOwner;
            set
            {
                if (_museumOwner == null && _personOwner == null && value != null)
                {
                    _museumOwner = value;
                    _museumOwner.AddPicture(this);
                }
                else if (_museumOwner != null && value == null)
                {
                    _museumOwner.RemovePicture(this);
                    _museumOwner = null;
                }
                else if (_personOwner != null && value != null)
                {
                    _personOwner.RemovePicture(this);
                    _personOwner = null;
                    _museumOwner = value;
                    _museumOwner.AddPicture(this);
                }
                else if (_museumOwner != null && value != null)
                {
                    _museumOwner.RemovePicture(this);
                    _museumOwner = value;
                    _museumOwner.AddPicture(this);
                }
            }
        }

        public Picture(int idPicture, string authorName, string description, DateTime paintDate)
        {
            IdPicture = idPicture;
            AuthorName = authorName;
            Description = description;
            PaintDate = paintDate;
        }
    }
}