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
    /// Interaction logic for LoginPage.xaml
    /// </summary>
    public partial class LoginPage : Page
    {
        public LoginPage()
        {
            InitializeComponent();
        }

        private void Login_Button_Click(object sender, RoutedEventArgs e)
        {
            User currentUser = AppData.db.Users.FirstOrDefault(u => u.Login == TxbLogin.Text);

            if (currentUser == null)
            {
                MessageBox.Show("Пользователь не найден!");
                return;
            }

            if (currentUser.Login == TxbLogin.Text && currentUser.Password == TxbPassword.Password)
            {
                MessageBox.Show("Вы авторизованы");
                AppData.CurrentAccessLevel = currentUser.Role.RoleAccessLevel;
                NavigationService.Navigate(new MainMarketWindow());
            } 
            else
            {
                MessageBox.Show("Password is incorrect");
            }
        }

        private void Anon_Button_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new MainMarketWindowAnonimous());
        }
    }
}
