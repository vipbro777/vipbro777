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
using TimerTest.Models;

namespace TimerTest.Views
{
    /// <summary>
    /// Interaction logic for AddItem.xaml
    /// </summary>
    public partial class AddItem : Page
    {
        public AddItem()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.GoBack();
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            decimal price;
            int discount;

            if (TxbTitle.Text.Length == 0)
            {
                MessageBox.Show("Заполните поле Наименование!");
                return;
            }
            else if (TxbDescription.Text.Length == 0)
            {
                MessageBox.Show("Заполните поле Описание!");
                return;
            }
            else if (TxbManufacturer.Text.Length == 0)
            {
                MessageBox.Show("Заполните поле Производитель!");
                return;
            }
            else if (TxbPrice.Text.Length == 0)
            {
                MessageBox.Show("Заполните поле Цена!");
                return;
            }
            else if (!decimal.TryParse(TxbPrice.Text, out price))
            {
                MessageBox.Show("Введите корректное число для поля Цены!");
                return;
            }
            else if (!int.TryParse(TxbDiscount.Text, out discount))
            {
                MessageBox.Show("Введите корректное число для поля Скидка!");
                return;
            }
            else if (TxbPhotoPath.Text.Length == 0)
            {
                MessageBox.Show("Введите путь до фотографии");
                return;
            }

            Item newItem = new Item()
            {
                Name = TxbTitle.Text,
                Description = TxbDescription.Text,
                Manufacturer = TxbManufacturer.Text,
                Price = price,
                Photo_Path = TxbPhotoPath.Text
            };

            if (TxbDiscount.Text.Length != 0)
            {
                newItem.Discount_Percent = discount;
            }

            AppData.db.Items.Add(newItem);
            AppData.db.SaveChanges();
            MessageBox.Show("Изменения сохранены!");
            NavigationService.GoBack();
        }
    }
}
