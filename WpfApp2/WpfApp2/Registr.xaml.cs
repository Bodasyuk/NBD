using DAL.Models;
using DAL.Repositoriy;
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
using System.Windows.Shapes;

namespace WpfApp2
{
    /// <summary>
    /// Логика взаимодействия для Registr.xaml
    /// </summary>
    public partial class Registr : Window
    {
        US us;
        UR Ur;
        public Registr()
        {
            InitializeComponent();
            us = new US();
            Ur = new UR();
        }

        private void Reg(object sender, RoutedEventArgs e)
        {
            if (PasswordReg.Password.ToString() == PasswordReg2.Password.ToString() && us.CheckNick(NickName.Text) && us.CheckMail2(Mail.Text))
            {
                User users=new User();
                Info info = new Info();
                users.Nick = NickName.Text;
                users.Pass = PasswordReg.Password.ToString();
                info.Name = Name.Text;
                info.Surname = Surname.Text;
                info.Mail = Mail.Text;
                users.person = info;
                Ur.Add(users);
                MainWindow main = new MainWindow()
                {
                    WindowStartupLocation = WindowStartupLocation.CenterScreen
                };
                main.ShowDialog();
                this.Close();
            }
            else
            {
                NickName.Text = "";
                Name.Text = "";
                Surname.Text = "";
                Mail.Text = "";
            }
        }

        private void OFF(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void NameRegistr_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void Surname_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void Mail_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void Nick_TextChanged(object sender, TextChangedEventArgs e)
        {

        }
    }
}
