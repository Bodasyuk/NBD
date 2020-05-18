using DAL.Models;
using DAL.Repositoriy;
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
    /// Логика взаимодействия для ucMyData.xaml
    /// </summary>
    public partial class ucMyData : UserControl
    {
        string Nick;
        UR uR;
        public ucMyData(string nick)
        {
            this.Nick = nick;
            InitializeComponent();
            uR = new UR();
            User user = new User();
            user = uR.GetUserByNick(Nick);
            TB1.Text = user.person.Name;
            TB2.Text = user.person.Surname;
            TB3.Text = user.person.Mail;
        }

        private void DataGrid_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Info info = new Info();
            info.Name = TB1.Text;
            info.Surname = TB2.Text;
            info.Mail = TB3.Text;
            uR.UpdateFieldInfo(Nick, "person", info);
        }
    }
}
