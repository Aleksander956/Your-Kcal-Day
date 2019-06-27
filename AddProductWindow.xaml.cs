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
using System.ComponentModel;
namespace Your_Kcal_Day
{
    /// <summary>
    /// Logika interakcji dla klasy AddProductWindow.xaml
    /// </summary>
    public delegate void AddItemHandler(object sender, String Nazwa, float Kcal);
    public partial class AddProductWindow : Window
    {

        private ICollectionView defaultView;
        public AddProductWindow()
        {
            InitializeComponent();
            Products p = new Products();
            List<Product> items = p.getList();


            /*
            this.defaultView = new CollectionViewSource() { Source = items };
            ICollectionView Itemlist = this.defaultView.View;
            var customFiltr = new Predicate<object>(item => ((Product)item).Nazwa.Contains("Max"));
            Itemlist.Filter = customFiltr;
            */
            this.defaultView = CollectionViewSource.GetDefaultView(items);
            this.defaultView.Filter =
                new Predicate<object>(item => ((Product)item).Nazwa.Contains(product_name.Text));
            ProductList.ItemsSource = this.defaultView;
        }

        public void searchProduct(object sender, EventArgs e)
        {
            this.defaultView.Refresh();
        }

        public event AddItemHandler AddItem;

        private void Button_Click(object sender, RoutedEventArgs e)
        {

           Product selected = (Product)ProductList.SelectedItem;
            if (selected == null)
                MessageBox.Show("Zaznacz produkt, który chcesz dodać.");
            else
            {
                
                AddItem(this, selected.Nazwa, float.Parse(selected.Kcal) * (float.Parse(product_weight.Text)/100) );
            }
            


        }
    }
}
