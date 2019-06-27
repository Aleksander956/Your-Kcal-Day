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
using System.Windows.Shapes;
using Your_Kcal_Day.Class;
using Newtonsoft.Json.Linq;
using System.ComponentModel; // CancelEventArgs

namespace Your_Kcal_Day
{
    /// <summary>
    /// Logika interakcji dla klasy Profile.xaml
    /// </summary>
    public partial class Profile : Window
    {
        AddProductWindow productWindow;
        ProfileData ProfileData;
        ObservableCollection<Eat> EatData = new ObservableCollection<Eat>();
        String ActualDay;


        public Profile()
        {
            InitializeComponent();

            this.loadProfile();


            EatList.ItemsSource = EatData;

            var dateAndTime = DateTime.Now;
            var date = dateAndTime.Date;
            selectDate.Text = date.ToString("dd.MM.yyyy");

            //ChangeDay(date.ToString("dd.MM.yyyy"));
        }




        private void Change_profile_Click(object sender, RoutedEventArgs e)
        {
            MainWindow mainW = new MainWindow();
            mainW.Show();
        }

        private void ChangeDay(String Date)
        {
            EatData.Clear();
            ActualDay = Date;

            LoadEats(Date);
            EatList.ItemsSource = EatData;
        }

        public void loadProfile()
        {
            this.ProfileData = new ProfileData();
            waga_info.Content = "Waga: " + this.ProfileData.get("waga") + " kg";
            wzrost_info.Content = "Wzrost: " + this.ProfileData.get("wzrost") + " cm";
            String sexL = this.ProfileData.get("plec");
            plec_info.Content = "Płeć: " + ((sexL == "F") ? "Kobieta" : "Mężyczna");

            double wzrost = Convert.ToDouble(this.ProfileData.get("wzrost"));
            double waga = Convert.ToDouble(this.ProfileData.get("waga"));
            double bmi = Math.Round(waga / ((wzrost / 100) * (wzrost / 100)), 2);
            bmi_data.Content = "BMI: " + bmi;
        }


        private Boolean LoadEats(String Date)
        {
            var items = this.ProfileData.LoadEats(Date);
           
            foreach (JObject row in items)
            {
                EatData.Add(new Eat()
                {
                    Nazwa = row.GetValue("Nazwa").ToString(),
                    Kcal = row.GetValue("Kcal").ToString()
                });
            }
            CalcSumCal();
            return true;
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            productWindow.Owner = this;
        }

        public void AddProductEat(object sender, String Nazwa, float Kcal)
        {
            EatData.Add(new Eat()
            {
                Nazwa = Nazwa,
                Kcal = Kcal.ToString()
            });

            ProfileData.SaveEats(ActualDay, EatData.ToArray());
            CalcSumCal();
        }



        private void Button_Click(object sender, RoutedEventArgs e)
        {
            productWindow = new AddProductWindow();
            productWindow.Owner = this;
            productWindow.AddItem += new AddItemHandler(AddProductEat);

            productWindow.Show();
        }

        private void CalcSumCal()
        {
            double sum = 0;

            foreach(Eat eat in EatData)
            {
                sum += Convert.ToDouble(eat.Kcal);
            }

            System.Diagnostics.Debug.WriteLine(sum);
            sum_cal.Content = "Suma kalorii: "+sum;
        }

        private void SelectDate_DataContextChanged(object sender, SelectionChangedEventArgs e)
        {
            ChangeDay(selectDate.Text);
        }

        private void RemoveSelected_Click(object sender, RoutedEventArgs e)
        {
            EatData.RemoveAt(EatList.SelectedIndex);
            ProfileData.SaveEats(ActualDay, EatData.ToArray());
            CalcSumCal();
        }

        void Window_Closing(object sender, CancelEventArgs e)
        {
            Application.Current.Shutdown();
        }

        private void Change_profile_Click_1(object sender, RoutedEventArgs e)
        {
            Settings settingsWindow = new Settings();
            settingsWindow.refreshProfile += new RefreshProfilHandler(loadProfile);
            settingsWindow.Show();
        }
    }
}
