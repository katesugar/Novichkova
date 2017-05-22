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
        List<Password> passwords = new List<Password>();
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            
            if (loginBox.Text == "g")
            {

                var Md5pass = CalculateMD5Hash(passwordBox.Password);
               
                if (passwordBox.Password == "g")
                {
                    MainPage mainPage = new MainPage();
                    NavigationService.Navigate(mainPage);

                }
                else
                {
                    MessageBox.Show("Неправильный логин или пароль!", "ОШИБКА!", MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }
            else
            {
                MessageBox.Show("Неправильный логин или пароль!", "ОШИБКА!", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void BackButton_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.GoBack();
        }

        public string CalculateMD5Hash(string input)

        {

            // step 1, calculate MD5 hash from input

            MD5 md5 = System.Security.Cryptography.MD5.Create();

            byte[] inputBytes = System.Text.Encoding.ASCII.GetBytes(input);

            byte[] hash = md5.ComputeHash(inputBytes);

            // step 2, convert byte array to hex string

            StringBuilder sb = new StringBuilder();

            for (int i = 0; i < hash.Length; i++)

            {

                sb.Append(hash[i].ToString("X2"));

            }

            return sb.ToString();

        }
        //public List<Password> LoadPassword()
        //{
        //    string line;
        //    List<Password> result = new List<Password>();
        //    System.IO.StreamReader file = new System.IO.StreamReader("../../passwords.txt");
        //    while ((line = file.ReadLine()) != null)
        //    {
        //        var temp = line.Split(':');
        //        result.Add();

        //    }

        //    file.Close();
        //    return result;
        //}
        public void SavePassword()
        {
            using (FileStream fs = new FileStream("../../passwords.txt", FileMode.Open))
            {
                using (StreamWriter sw = new StreamWriter(fs, Encoding.GetEncoding(1251)))
                {
                    for (int i = 0; i < passwords.Count; i++)
                    {
                        sw.WriteLine("{0}:{1}", passwords[i].ThisLogin, passwords[i].ThisPassword);
                    }

                }
            }
        }
    }

}