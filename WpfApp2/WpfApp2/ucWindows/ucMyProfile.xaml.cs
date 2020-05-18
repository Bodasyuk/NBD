using DAL.Models;
using DAL.Repositoriy;
using MongoDB.Bson;
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
    /// Логика взаимодействия для ucMyProfile.xaml
    /// </summary>
    public partial class ucMyProfile : UserControl
    {
        string Nick;
        UR uR;
        PR pR;
        public ucMyProfile(string nick)
        {
            this.Nick = nick;
            InitializeComponent();
            uR = new UR();
            pR = new PR();
            Posts pr = new Posts();
            User ur = new User();
            ur = uR.GetUserByNick(Nick);
            
            
            List<string> List1 = new List<string>();
            List<string> List2 = new List<string>();
            List1=ur.Followers;
            List2 = ur.Following;
            List<Posts> lis = new List<Posts>();
            lis = pR.GetPostsByUserId(uR.GetUserId(Nick));
            dataGridView1.ItemsSource = List1;
            dataGridView2.ItemsSource = List2;
            dataGridView3.ItemsSource = lis;
        }

        private void DataGrid_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void DataGrid_SelectionChanged_1(object sender, SelectionChangedEventArgs e)
        {

        }

        private void DataGrid_SelectionChanged_2(object sender, SelectionChangedEventArgs e)
        {

        }

        
    }
}
