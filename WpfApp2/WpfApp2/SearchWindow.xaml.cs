using DAL.Models;
using DAL.Repositoriy;
using DAL.Services;
using Insta.Services;
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
    /// Логика взаимодействия для SearchWindow.xaml
    /// </summary>
    public partial class SearchWindow : Window
    {
        
        List<string> ls = new List<string>();
        string PersonNickName;
        UR repository;
        PR postRepository;
        PS postServices;
        US services;
        User user;
        List<Posts> posts;
        bool isAnyPosts = false;
        bool tempLike = false;
        Posts currentPost;
        int indexOfPost = 0;
        string PersonNickName2;
        public SearchWindow(string nick, string nick2)
        {
            InitializeComponent();
            PersonNickName = nick;
            PersonNickName2 = nick2;
            //
            repository = new UR();
            services = new US();
            postServices = new PS();
            postRepository = new PR();
            //
            user = new User();
            user = repository.GetUserByNick(PersonNickName);
            UserName.Content = user.person.Name;
            UserSurname.Content = user.person.Surname;
            UserMail.Content = user.person.Mail;
            //
            currentPost = new Posts();
            posts = new List<Posts>();
            posts = postRepository.GetPostsByUserId(repository.GetUserId(PersonNickName));
            if (posts != null && posts.Count > 0)
            {
                currentPost = posts[indexOfPost];

                DG1.ItemsSource = currentPost.comment;
                isAnyPosts = true;
            }
            else
            {
                Main.Content = "No posts yet";



            }
            //
            if (tempLike)
            {
                btnLike.Background = Brushes.Green;
                tempLike = true;
            }

            user = repository.GetUserByNick(PersonNickName2);
            if (services.CheckAlreadyFollow(user.Nick, PersonNickName))
            {
                btnFollow.Background = Brushes.Green;
            }



        }

        private void Follow(object sender, RoutedEventArgs e)
        {
            user = repository.GetUserByNick(PersonNickName2);
            if (!services.CheckAlreadyFollow(user.Nick, PersonNickName))
            {
                services.Follow(user.Nick, PersonNickName);
                services.Follow(PersonNickName, user.Nick);
                btnFollow.Background = Brushes.Green;
            }

        }

        private void Unfollow(object sender, RoutedEventArgs e)
        {
            
            user = repository.GetUserByNick(PersonNickName2);
            
            List<string> list = new List<string>();
            list = user.Following;
            list.Remove(PersonNickName);
            user = repository.GetUserByNick(PersonNickName);
            List<string> list2 = new List<string>();
            list = user.Followers;
            list.Remove(PersonNickName2);
            repository.UpdateFieldFollow(PersonNickName2, "Following", list);
            repository.UpdateFieldFollow(PersonNickName, "Followers", list2);
            Color color = (Color)ColorConverter.ConvertFromString("#0288d1");
            SolidColorBrush brush = new SolidColorBrush(color);
            btnFollow.Background = brush;
        }


        private void Comment(object sender, RoutedEventArgs e)
        {

        }

        private void Like(object sender, RoutedEventArgs e)
        {

            postRepository.UpdateLikes(currentPost.Id, true);
            
        }



        private void NextPost(object sender, RoutedEventArgs e)
        {
            
            if (isAnyPosts)
            {
                indexOfPost++;
                if (indexOfPost < posts.Count)
                {
                    currentPost = posts[indexOfPost];
                    Main.Content = currentPost.comment;
                    
                    if (tempLike==false)
                    {
                        btnLike.Background = Brushes.Green;
                        tempLike = true;
                    }
                    else
                    {
                        Color color = (Color)ColorConverter.ConvertFromString("#0288d1");
                        SolidColorBrush brush = new SolidColorBrush(color);
                        btnLike.Background = brush;
                        tempLike = false;
                    }
                }
                else
                {
                    indexOfPost--;
                    currentPost = posts[indexOfPost];
                    Main.Content = currentPost.comment;

                }
            }


        }
        private void Grid_MouseDown(object sender, MouseButtonEventArgs e)
        {
            DragMove();
        }
        private void OFF(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void PreviusPost(object sender, RoutedEventArgs e)
        {
            
            if (isAnyPosts)
            {
                if (indexOfPost > 0)
                {
                    indexOfPost--;
                    currentPost = posts[indexOfPost];
                    Main.Content = currentPost.comment;
                    
                    if (tempLike)
                    {
                        btnLike.Background = Brushes.Green;
                        tempLike = true;
                    }
                    else
                    {
                        Color color = (Color)ColorConverter.ConvertFromString("#0288d1");
                        SolidColorBrush brush = new SolidColorBrush(color);
                        btnLike.Background = brush;
                        tempLike = false;
                    }
                }
                else
                {
                   
                    
                }
            }

        }

        private void PersonsWhoComment(object sender, RoutedEventArgs e)
        {
            
            CommWindow main = new CommWindow(currentPost.Id, repository.GetUserId(PersonNickName), PersonNickName, PersonNickName2)
            {
                WindowStartupLocation = WindowStartupLocation.CenterScreen
            };
            main.ShowDialog();
            this.Close();
        }

        private void DataGrid_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }
    }
}
