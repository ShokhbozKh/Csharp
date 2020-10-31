using System;
using System.IO;
using Xamarin.Forms;

namespace NotesApp
{
    public partial class MainPage : ContentPage
    {
        readonly string _fileName = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData));
        public MainPage()
        {
            InitializeComponent();

            if (File.Exists(_fileName))
            {
                editor.Text = File.ReadAllText(_fileName);
            }
        }

        private void Button_Clicked(object sender, EventArgs e)
        {
            File.WriteAllText(_fileName, editor.Text);
        }

        private void Button_Clicked_1(object sender, EventArgs e)
        {
            if (File.Exists(_fileName))
            {
                File.Delete(_fileName);
            }

            editor.Text = string.Empty;
        }
    }
}
