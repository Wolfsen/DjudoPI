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

namespace App
{
    /// <summary>
    /// Логика взаимодействия для User.xaml
    /// </summary>
    public partial class User : Window
    {
        public User()
        {
            InitializeComponent();
        }

        private void butAdd_Click(object sender, RoutedEventArgs e)
        {

        }
        void VisibleTrue()
        {
            label_F.Visibility = Visibility.Visible;
            label_I.Visibility = Visibility.Visible;
            label_O.Visibility = Visibility.Visible;
            label_password.Visibility = Visibility.Visible;
            label_login.Visibility = Visibility.Visible;
            CheckBoxAdmin.Visibility = Visibility.Visible;
            textBox_F.Visibility = Visibility.Visible;
            textBox_I.Visibility = Visibility.Visible;
            textBox_O.Visibility = Visibility.Visible;
            textBox_Password.Visibility = Visibility.Visible;
            textBox_Login.Visibility = Visibility.Visible;
            butAdd.IsEnabled = false;
            butDelete.IsEnabled = false;
            butEdit.IsEnabled = false;
            DataGrid.Visibility = Visibility.Hidden;
        }
    }
}
