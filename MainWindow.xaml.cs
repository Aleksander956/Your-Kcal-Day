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
using System.Windows.Navigation;
using System.Windows.Shapes;
using Your_Kcal_Day.Class;

namespace Your_Kcal_Day
{
    /// <summary>
    /// Logika interakcji dla klasy MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {

        String UserSex = "";

        public MainWindow()
        {
            InitializeComponent();
        }

        private void Start_button_Click(object sender, RoutedEventArgs e)
        {
            /*
            System.IO.File.WriteAllText(AppDomain.CurrentDomain.BaseDirectory + "test.txt", "hello");
            Console.WriteLine(AppDomain.CurrentDomain.BaseDirectory);
            System.Diagnostics.Debug.WriteLine(AppDomain.CurrentDomain.BaseDirectory);
            */

            // Walidacja
            var WagaisNumeric = int.TryParse(waga_input.Text, out int n);
            var WzrostisNumeric = int.TryParse(wzrost_input.Text, out int f);
            if (UserSex == "")
            {
                MessageBox.Show("Wybierz płeć!");
            }
            else if(waga_input.Text == "" || !WagaisNumeric)
            {
                MessageBox.Show("Nieprawidłowa wartość wagi!");
            }
            else if (waga_input.Text == "" || !WzrostisNumeric)
            {
                MessageBox.Show("Nieprawidłowa wartość wzrostu!");
            }
            else
            {
                ProfileData profile = new ProfileData();
                profile.set("waga", waga_input.Text);
                profile.set("wzrost", wzrost_input.Text);
                profile.set("plec", UserSex);
                profile.save();

                Profile ProfileWindow = new Profile();
                ProfileWindow.Show();
                this.Hide();
            }

            //profile.Show();
        }
        private void SelectSex(object sender, RoutedEventArgs e)
        {
            if (SexInputF.IsChecked == true)
                UserSex = "F";
            else if (SexInputM.IsChecked == true)
                UserSex = "M";
            else
                UserSex = "";
        }

    }
}
