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
using System.Text.RegularExpressions;

using System.Data.Linq;
using System.Data.Linq.Mapping;
using System.Data.SqlClient;
namespace WMS_Project_TM_Store_IT
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            this.reset();
            
        }

        public void reset()
        {
            Username.Text = string.Empty;
            Password.Password = string.Empty;
            Username.Focus();
        }

        #region ActionListener
        private void Reset_Click(object sender, RoutedEventArgs e)
        {
            this.reset();
        }

        private void Exit_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void SignIn_Click(object sender, RoutedEventArgs e)
        {
            SignIn_Clicked();      
        }

        private void SignIn_Clicked()
        {
            //regex pattern check
            string pattern = @"[A-Z0-9a-z_]+";
            if (!Regex.IsMatch(Username.Text, pattern) || !Regex.IsMatch(Password.Password, pattern))
            {
                MessageBox.Show("Incorrect input, check and try again!");
                Username.Focus();
                return;
            }

            CONNECTION.DbHandle = new DataBaseHandler();
            //set attributes
            CONNECTION.DbHandle.Password = Password.Password;
            CONNECTION.DbHandle.Username = Username.Text;
            
            //test
           



            //endtest



            if (CONNECTION.DbHandle.DB_Query_Result())
            {
                
                UserFrame userFrame = new UserFrame();
                userFrame.Show();
                this.Close();
            }
            else
            {
                MessageBox.Show("The combination of username and password you have entered is incorrect!");
                this.reset();
            }
        }

        private void Username_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter)
            {
                Password.Focus();
            }
          
        }

        private void Password_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter)
            {
                SignIn_Clicked();
            }
        }
        #endregion ActionListener
    }
}
