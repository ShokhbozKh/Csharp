using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

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
