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
using System.Configuration;
using System.Data.SqlClient;
using System.Data;

namespace KDZ_NovichkovaEA_162
{
    /// <summary>
    /// Логика взаимодействия для RegistrationWindow.xaml
    /// </summary>
    public partial class RegistrationWindow : Window
    {
        
        public RegistrationWindow()
        {
            InitializeComponent();
            
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
           if(loginBox.Text == "guest")
            {
                if(passwordBox.Password == "guestpassword")
                {
                    this.Close();
                    
                }
                else
                {
                    MessageBox.Show("Неправильный логин или пароль!", "ОШИБКА!", MessageBoxButton.OKCancel, MessageBoxImage.Error);
                }
            }
           else
            {
                MessageBox.Show("Неправильный логин или пароль!", "ОШИБКА!", MessageBoxButton.OKCancel, MessageBoxImage.Error);
            }
        }
    }
}
