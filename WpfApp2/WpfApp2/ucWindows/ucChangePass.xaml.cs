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
    public partial class ucChangePass : UserControl
    {
        US us;
        UR ur;
        string Nick;
        public ucChangePass(string nick)
        {
            us = new US();
            ur = new UR();
            InitializeComponent();
            this.Nick = nick;
        }        
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            User user = new User();
            user = ur.GetUserByNick(Nick);

            if (OldPassword.Password.ToString() == user.Pass)
            {
                ur.UpdateField(Nick, "Pass", NewPassword.Password.ToString());
            }

        }
    }
}
