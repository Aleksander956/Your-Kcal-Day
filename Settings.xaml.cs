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
using Your_Kcal_Day.Class;
namespace Your_Kcal_Day
{
    public delegate void RefreshProfilHandler();
    /// <summary>
    /// Logika interakcji dla klasy Settings.xaml
    /// </summary>
    /// 
    public partial class Settings : Window
    {
        ProfileData prof;
        public event RefreshProfilHandler refreshProfile;
        public Settings()
        {
            InitializeComponent();
            prof = new ProfileData();
            waga_input.Text = prof.get("waga");
            wzrost_input.Text = prof.get("wzrost");
        }

        private void Start_button_Click(object sender, RoutedEventArgs e)
        {
            ProfileData profile = new ProfileData();
            profile.set("waga", waga_input.Text);
            profile.set("wzrost", wzrost_input.Text);
            profile.save();
            this.refreshProfile();
            this.Hide();
           
        }
    }
}
