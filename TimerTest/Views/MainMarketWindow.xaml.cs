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
using TimerTest.Models;

namespace TimerTest.Views
{
    /// <summary>
    /// Interaction logic for MainMarketWindow.xaml
    /// </summary>
    public partial class MainMarketWindow : Page
    {
        private List<Item> allData;

        public MainMarketWindow()
        {
            InitializeComponent();
        }

        private void Page_Loaded(object sender, RoutedEventArgs e)
        {
            allData = AppData.db.Items.ToList();
            DataListView.ItemsSource = allData;
        }

        private void Delete_Button_Click(object sender, RoutedEventArgs e)
        {
            var button = sender as Button;
            var item = button.DataContext as Item;

            if (MessageBox.Show("Вы уверены, что хотите удалить запись?", "Предупреждение!", MessageBoxButton.YesNo, MessageBoxImage.Warning) == MessageBoxResult.No)
            {
                return;
            }
            AppData.db.Items.Remove(item);
            AppData.db.SaveChanges();
            DataListView.ItemsSource = AppData.db.Items.ToList();
        }

        private void Add_Item_Button(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new AddItem());
        }

        private void Edit_Click(object sender, RoutedEventArgs e)
        {
            var button = sender as Button;
            var item = button.DataContext as Item;
            MessageBox.Show(item.Name);

            MessageBox.Show("Вы собираетесь изменить что-то");
            NavigationService.Navigate(new EditItem(item));
        }

        private void TextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (TxbSearch.Text.Length == 0)
            {
                allData = AppData.db.Items.ToList();
            } 
            else
            {
                allData = AppData.db.Items.Where(x => x.Name.Contains(TxbSearch.Text)).ToList();
            }

            TxbSearchStatus.Visibility = allData.Count != 0 ? Visibility.Hidden : Visibility.Visible;
            DataListView.ItemsSource = allData;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            AppData.CurrentAccessLevel = 0;
            NavigationService.GoBack();
        }
    }
}
