using System;
using System.Collections.Generic;
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
using System.Windows.Shapes;

namespace Exercise03
{
    /// <summary>
    /// Interaction logic for Task2.xaml
    /// </summary>
    public partial class Task2 : Window
    {
        public Task2()
        {
            InitializeComponent();

            ComboBoxItem student = new ComboBoxItem();
            ComboBoxItem teacher = new ComboBoxItem();
            ComboBoxItem staff = new ComboBoxItem();

            student.Content = "Student";
            student.IsSelected = true;
            teacher.Content = "Teacher";
            staff.Content = "Staff";

            StatusCombobox.Items.Add(student);
            StatusCombobox.Items.Add(teacher);
            StatusCombobox.Items.Add(staff);

            statusTextBox.Text = StatusCombobox.SelectionBoxItem.ToString();
        }

        private void ComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            ComboBoxItem item = (ComboBoxItem)StatusCombobox.SelectedItem;
            string itemText = item.Content.ToString();
            statusTextBox.Text = itemText;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }
    }
}
