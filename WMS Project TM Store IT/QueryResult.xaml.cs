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

namespace WMS_Project_TM_Store_IT
{
    /// <summary>
    /// Interaction logic for QueryResult.xaml
    /// </summary>
    public partial class QueryResult : Window
    {
        public QueryResult(DataBaseUser data)
        {
            InitializeComponent();
            OK.Focus();
            if (data == null)
            {
                Result.Text = "No such user in the database!";
            }
            else
            {
                Result.Text = "User ID\t" + "User Name\t" + "User Group\n"
                                + data.UserID + "\t" + data.UserName + "\t" + data.UserGroup;
            }
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void Button_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter)
            {
                this.Close();
            }
        }
    }
}
