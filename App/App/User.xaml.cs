using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
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
        SqlConnection con = new SqlConnection("Server=PC; Database=Djudo;Integrated security=True");

        public User()
        {
            InitializeComponent();
        }

        private void butAdd_Click(object sender, RoutedEventArgs e)
        {
            VisibleTrue();
            groupBox.Header = "Добавить";
        }

        void VisibleTrue()
        {
            groupBox.Visibility = Visibility.Visible;
            butAdd.IsEnabled = false;
            butDelete.IsEnabled = false;
            butEdit.IsEnabled = false;
            DataGrid.Visibility = Visibility.Hidden;
            ClearTextBox();
        }
        void VisibleFalse()
        {
            groupBox.Visibility = Visibility.Hidden;
            butAdd.IsEnabled = true;
            butDelete.IsEnabled = true;
            butEdit.IsEnabled = true;
            DataGrid.Visibility = Visibility.Visible;
        }

        private void butEdit_Click(object sender, RoutedEventArgs e)
        {
            VisibleTrue();
            groupBox.Header = "Редактировать";
        }

        private void butDelete_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (DataGrid.SelectedItem != null && DataGrid.SelectedIndex != - 1)
                {
                    //DialogResult dialogResult = MessageBox.Show("Вы уверены, что хотите удалить эту запись таблицы?", "Проверка", MessageBoxButtons.YesNo);
                    //if (dialogResult == DialogResult.Yes)
                    //{
                    DataRowView row = (DataRowView)DataGrid.SelectedItems[0];
                    string query = "DELETE  FROM [dbo].[User] WHERE [Id] =" + row["Id"];
                        SqlCommand cmd = new SqlCommand(query, con);
                        con.Open();
                        cmd.ExecuteNonQuery();
                        con.Close();
                        LoadTable();
                    //}
                }
                else { MessageBox.Show("Выберите запись для удаления"); }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Что-то пошло не так, попробуйте снова. Ошибка:" + ex.Message);
            }
        }

        private void butOK_Click(object sender, RoutedEventArgs e)
        {
            VisibleFalse();
        }

        public void LoadTable()
        {
            string myTable = "SELECT [Id] as 'Id', [FIO] as 'ФИО', [Login] as 'Логин', [Password] as 'Пароль', [Admin] as 'Администратор' FROM [dbo].[User]";
            con.Open();
            SqlDataAdapter da = new SqlDataAdapter(myTable, con);
            DataTable dt = new DataTable("Employee");
            da.Fill(dt);
            DataGrid.ItemsSource = dt.DefaultView;
            con.Close();
            DataGrid.Columns[0].Visibility = Visibility.Hidden;
        }

        void ClearTextBox()
        {
            foreach (Control c in containerCanvas.Children)
            {
                foreach (Control ctl in containerCanvas.Children)
                {
                    if (ctl.GetType() == typeof(CheckBox))
                        ((CheckBox)ctl).IsChecked = false;
                    if (ctl.GetType() == typeof(TextBox))
                        ((TextBox)ctl).Text = String.Empty;
                }
            }
        }
    }
}
