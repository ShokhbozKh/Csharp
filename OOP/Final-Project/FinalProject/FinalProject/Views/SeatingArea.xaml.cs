using System.Collections.ObjectModel;
using System.Windows.Controls;

namespace FinalProject.Views
{
    /// <summary>
    /// Interaction logic for SeatingArea.xaml
    /// </summary>
    public partial class SeatingArea : UserControl
    {
        public ObservableCollection<int> Seats { get; set; }
        public SeatingArea()
        {
            LoadData();
            InitializeComponent();
        }

        void LoadData()
        {
            Seats = new ObservableCollection<int>();

            for (int i = 0; i < 20; i++) Seats.Add(i);

        }
    }
}
