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
using System.Windows.Shapes;
using WpfApp2.ucWindows;

namespace WpfApp2
{
    /// <summary>
    /// Логика взаимодействия для Profile.xaml
    /// </summary>
    public partial class Profile : Window
    {
        string Nick;
        PR pr;
        UR ur;
        public Profile(string nick)
        {
            InitializeComponent();
            this.Nick = nick;
            pr = new PR();
            ur = new UR();
        }        
        private void LogOut_Click(object sender, RoutedEventArgs e)
        {
            MainWindow main = new MainWindow()
            {
                WindowStartupLocation = WindowStartupLocation.CenterScreen
            };
            main.ShowDialog();
            this.Close();
        }

        private void OFF(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void FindPerson_Click(object sender, RoutedEventArgs e)
        {
            GridPerson.Children.Clear();
            GridPerson.Children.Add(new ucFindPerson(Nick));
        }

        private void MyProfile_Click(object sender, RoutedEventArgs e)
        {
            GridPerson.Children.Clear();
            GridPerson.Children.Add(new ucMyProfile(Nick));
        }




        private void Change_Pass_Click(object sender, RoutedEventArgs e)
        {
            GridPerson.Children.Clear();
            GridPerson.Children.Add(new ucChangePass(Nick));
        }

        private void Edit_Profile_Click(object sender, RoutedEventArgs e)
        {
            GridPerson.Children.Clear();
            GridPerson.Children.Add(new ucEditProfile(Nick));
        }

        private void Add_Post_Click(object sender, RoutedEventArgs e)
        {
            Posts posts = new Posts();
            User user = new User();
            user = ur.GetUserByNick(Nick);
            posts.UserId = user.Id;
            posts.likes = 0;
            pr.AddPost(posts);
        }

        private void My_Data_Click(object sender, RoutedEventArgs e)
        {
            GridPerson.Children.Clear();
            GridPerson.Children.Add(new ucMyData(Nick));
        }
    }
}
