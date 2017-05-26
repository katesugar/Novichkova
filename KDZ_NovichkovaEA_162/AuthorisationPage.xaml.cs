using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
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
using System.IO;
using System.Data.Entity;

namespace KDZ_NovichkovaEA_162
{
    /// <summary>
    /// Логика взаимодействия для RegistrationPage.xaml
    /// </summary>
    public partial class RegistrationPage : Page
    {
        public RegistrationPage()
        {
            InitializeComponent();
        }
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                string[] str = System.IO.File.ReadAllLines("users.txt");
                StringBuilder login = new StringBuilder(loginBox.Text);
                StringBuilder password = new StringBuilder(passwordBox.Password);
                for (int i = 0; i < login.Length; i++)
                {
                    if (!Char.IsLower(login[i])) login[i] = Char.ToLower(login[i]);
                }
                for (int i = 0; i < password.Length; i++)
                {
                    if (!Char.IsLower(password[i])) password[i] = Char.ToLower(password[i]);
                }
                if (str[0] == login.ToString() && str[1] == password.ToString())
                {
                    MainPage mainPage = new MainPage();
                    NavigationService.Navigate(mainPage);
                }
            }
            catch (Exception)
            {
                MessageBox.Show("ex");
            }
        }
    
        private void BackButton_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.GoBack();
        }

        MediaPlayer mediaPlayer = new MediaPlayer();
        private void PlayButton_Click(object sender, RoutedEventArgs e)
        {
            mediaPlayer.Open(new Uri("music.mp3", UriKind.Relative));
            mediaPlayer.Play();
        }

        private void StopButton_Click(object sender, RoutedEventArgs e)
        {
            mediaPlayer.Stop();
        }
    }

}