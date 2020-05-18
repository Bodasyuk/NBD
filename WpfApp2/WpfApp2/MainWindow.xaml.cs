using DAL.Services;
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

namespace WpfApp2
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    //дописати серч вікно та коммвікно зробити вікно новин
    public partial class MainWindow : Window
    {
        US us;
        public MainWindow()
        {
            InitializeComponent();
            us = new US();
        }

        private void LOGIN(object sender, RoutedEventArgs e)
        {
            if(us.CheckPassword(NickName.Text, PasswordLogin.Password.ToString()))
            {
                
                Profile main = new Profile(NickName.Text)
                {
                    WindowStartupLocation = WindowStartupLocation.CenterScreen
                };
                main.ShowDialog();
                this.Close();
            }
            else
            {
                NickName.Text = "";
            }
        }

        private void OFF(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void Register(object sender, RoutedEventArgs e)
        {
            Registr main = new Registr()
            {
                WindowStartupLocation = WindowStartupLocation.CenterScreen
            };
            main.ShowDialog();
            this.Close();
        }

        private void NameLogin_TextChanged(object sender, TextChangedEventArgs e)
        {

        }
    }
}
