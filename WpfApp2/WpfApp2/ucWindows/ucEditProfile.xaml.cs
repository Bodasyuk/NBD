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
    /// Логика взаимодействия для ucEditProfile.xaml
    /// </summary>
    public partial class ucEditProfile : UserControl
    {
        US uS;
        UR ur;
        string Nick;
        public ucEditProfile(string nick)
        {
            InitializeComponent();
            FillComboBox();
            uS = new US();
            ur = new UR();
            this.Nick = nick;
        }       
        private void FillComboBox()
        {
            OptionComboBox.Items.Add("Edit name");
            OptionComboBox.Items.Add("Edit surname");
            OptionComboBox.Items.Add("Edit mail");
            OptionComboBox.Items.Add("Edit nickname");
        }
        private void EditNewData_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if (OptionComboBox.SelectedItem.ToString() == "Edit name")
            {
                ur.UpdateField(Nick, "Name", EditNewData.Text);
            }
            else if (OptionComboBox.SelectedItem.ToString() == "Edit surname")
            {
                ur.UpdateField(Nick, "Surname", EditNewData.Text);
            }
            else if (OptionComboBox.SelectedItem.ToString() == "Edit mail")
            {
                if (uS.CheckMail2(EditNewData.Text))
                {
                    ur.UpdateField(Nick, "Mail", EditNewData.Text);
                }
                else
                {
                    EditNewData.Text = "";
                }
            }
            else if (OptionComboBox.SelectedItem.ToString() == "Edit nickname")
            {
                if (uS.CheckNick(EditNewData.Text))
                {
                    ur.UpdateField(Nick, "Nick", EditNewData.Text);
                }
                else
                {
                    EditNewData.Text = "";
                }
            }
        }


        private void OptionComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            EditNewData.Text = "";
        }
    }
}
