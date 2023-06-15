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
    /// Interaction logic for EditItem.xaml
    /// </summary>
    public partial class EditItem : Page
    {
        Item itemToEdit;

        public EditItem(Item _itemToEdit)
        {
            InitializeComponent();
            itemToEdit = _itemToEdit;

            TxbTitle.Text = itemToEdit.Name;
            TxbDescription.Text = itemToEdit.Description;
            TxbManufacturer.Text = itemToEdit.Manufacturer;
            TxbPrice.Text = itemToEdit.Price.ToString();
            TxbDiscount.Text = itemToEdit.Discount_Percent.ToString();
            TxbPhotoPath.Text = itemToEdit.Photo_Path;
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

            itemToEdit.Name = TxbTitle.Text;
            itemToEdit.Description = TxbDescription.Text;
            itemToEdit.Manufacturer = TxbManufacturer.Text;
            itemToEdit.Price = price;
            itemToEdit.Discount_Percent = discount;
            itemToEdit.Photo_Path = TxbPhotoPath.Text;

            AppData.db.SaveChanges();
            MessageBox.Show("Изменения сохранены!");
            NavigationService.GoBack();
        }
    }
}

