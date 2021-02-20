using System.ComponentModel;

namespace FinalProject.Models
{
    public class SeatModel : INotifyPropertyChanged
    {
        public int IdSeat { get; set; }
        public bool IsAvialable { get; set; }

        private string _background;
        public string Background
        {
            get
            {
                if (_background == "Yellow") return "Yellow";
                else if (IsAvialable) return "Green";
                else return "Red";
            }

            set
            {
                if (_background == value) _background = "Green";
                else _background = value;
                OnPropertyChanged("Background");
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        protected void OnPropertyChanged(PropertyChangedEventArgs e)
        {
            PropertyChanged?.Invoke(this, e);
        }

        protected void OnPropertyChanged(string propertyName)
        {
            OnPropertyChanged(new PropertyChangedEventArgs(propertyName));
        }
    }
}
