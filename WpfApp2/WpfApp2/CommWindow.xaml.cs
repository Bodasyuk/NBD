using DAL.Models;
using DAL.Repositoriy;
using DAL.Services;
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
using System.Windows.Shapes;

namespace WpfApp2
{
    /// <summary>
    /// Логика взаимодействия для CommWindow.xaml
    /// </summary>
    public partial class CommWindow : Window
    {
        PR uS;
        UR uR;
        ObjectId Id1;
        ObjectId Id2;
        string Nick;
        string Nick2;
        public CommWindow(ObjectId id1, ObjectId id2, string nick, string nick2)
        
        {
            uR = new UR();
            uS=new PR();
            this.Nick = nick;
            this.Nick2 = nick2;
            InitializeComponent();
            this.Id1 = id1;
            this.Id2 = id2;
        }

        private void PersonNickName_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            uS.AddComment(Id1, Id2, tb1.Text);
            Posts posts = new Posts();
            posts=uS.GetPostsById(Id1);
            Comments comm = new Comments();
            comm.comm = tb1.Text;
            comm.OwnerId = uR.GetUserId(Nick2);
            posts.comment.Add(comm);
            uS.UpdatePost(Id1, posts);

        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            Profile main = new Profile(Nick)
            {
                WindowStartupLocation = WindowStartupLocation.CenterScreen
            };
            main.ShowDialog();
            this.Close();
        }
    }
}
