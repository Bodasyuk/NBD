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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace WpfApp2.ucWindows
{
    /// <summary>
    /// Логика взаимодействия для ucFindPerson.xaml
    /// </summary>
    public partial class ucFindPerson : UserControl
    {
        string Nick;
        UR ur;
        US us;
        public ucFindPerson(string nick)
        {
            InitializeComponent();
            us = new US();
            ur = new UR();
            this.Nick = nick;
        }

        private void PersonNickName_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            User user = new User();
            user = ur.GetUserByNick(PersonNickName.Text);
            if (us.CheckNick(user.Nick)==false)
            {
                SearchWindow main = new SearchWindow(user.Nick, Nick)
                {
                    WindowStartupLocation = WindowStartupLocation.CenterScreen
                };
                main.ShowDialog();
            }
            else
            {
                PersonNickName.Text = "";
            }
        }
    }
}
