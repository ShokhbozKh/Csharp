using Notes.Data;
using System;
using System.Data;
using System.IO;
using Xamarin.Forms;

namespace Notes
{
    public partial class App : Application
    {
        static NoteDatabase _dbContext;

        public static NoteDatabase DbContext
        {
            get
            {
                if(_dbContext == null)
                {
                    _dbContext = new NoteDatabase(Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "Notes.db3"));
                }

                return _dbContext;
            }
        }
        public App()
        {
            InitializeComponent();

            MainPage = new NavigationPage(new NotesPage());
        }

        protected override void OnStart()
        {
        }

        protected override void OnSleep()
        {
        }

        protected override void OnResume()
        {
        }
    }
}
