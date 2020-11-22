using SL.XamarinRealize.Repositories;
using System;
using System.IO;
using System.Reflection;
using Xamarin.Forms;

namespace SL.XamarinRealize
{
    public partial class App : Application
    {
        public static int Money { get; set; } = 0;
        private const string DATABASE_NAME_EVENT = "Events.db";
        private const string DATABASE_NAME_ITEMS = "Items.db";
        private static EventRepositoryAsync databaseE;
        public  static EventRepositoryAsync DatabaseE
        {
            get
            {
                if (databaseE == null)
                {
                    string dbPath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), DATABASE_NAME_EVENT);
                    if (!File.Exists(dbPath))
                    {
                        var assembly = IntrospectionExtensions.GetTypeInfo(typeof(App)).Assembly;
                        var s = assembly.GetManifestResourceNames();
                        using (Stream stream = assembly.GetManifestResourceStream(s[0]))
                        {
                            using (FileStream fs = new FileStream(dbPath, FileMode.OpenOrCreate))
                            {
                                stream.CopyTo(fs);
                                fs.Flush();
                            }
                        }
                    }
                    databaseE = new EventRepositoryAsync(dbPath);  
                }
                return databaseE;
            }
        }
        private static ItemRepositoryAsync databaseI;
        public static ItemRepositoryAsync DatabaseI
        {
            get
            {
                if (databaseI == null)
                {
                    string dbPath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), DATABASE_NAME_ITEMS);
                    if (!File.Exists(dbPath))
                    {
                        var assembly = IntrospectionExtensions.GetTypeInfo(typeof(App)).Assembly;
                        var s = assembly.GetManifestResourceNames();
                        using (Stream stream = assembly.GetManifestResourceStream(s[1]))
                        {
                            using (FileStream fs = new FileStream(dbPath, FileMode.OpenOrCreate))
                            {
                                stream.CopyTo(fs);
                                fs.Flush();
                            }
                        }
                    }
                    databaseI = new ItemRepositoryAsync(dbPath);
                }
                return databaseI;
            }
        }
        public App()
        {
            InitializeComponent();

            MainPage = new NavigationPage(new MainPage());
            
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
