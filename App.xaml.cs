using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;
using Your_Kcal_Day.Class;

namespace Your_Kcal_Day
{
    /// <summary>
    /// Logika interakcji dla klasy App.xaml
    /// </summary>
    public partial class App : Application
    {
        public App()
        {
            System.Diagnostics.Debug.WriteLine(this.StartupUri);

        }
        protected override void OnStartup(StartupEventArgs e)

        {
            ProfileData profile = new ProfileData();
            if(profile.isSet())
                this.StartupUri = new System.Uri("Profile.xaml", System.UriKind.Relative);

        }




    }
}
