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
using System.IO;
using System.Text.RegularExpressions;

namespace KDZ_NovichkovaEA_162
{
    /// <summary>
    /// Логика взаимодействия для EditingPage.xaml
    /// </summary>
    public partial class EditingPage : Page
    {
        
        public EditingPage()
        {
            InitializeComponent();


        }

        private void ButtonAdd_Click(object sender, RoutedEventArgs e)
        {
            try
            {

                Song editedSong = new Song
                {
                    Name = AddNameOfSongTextBox.Text,
                    Artist = new Artist
                    {
                        Name = AddNameOfArtistTextBox.Text,
                        Age = int.Parse(AddAgeTextBox.Text)
                    },
                    Album = new Album
                    {
                        Name = AddNameOfAlbumTextBox.Text,
                        Year = int.Parse(AddYearOfAlbumTextBox.Text)
                    },
                    Year = int.Parse(AddYearOfSongTextBox.Text),
                    Genre = AddGenreTextBox.Text
                };
                MainPage mainPage = new MainPage();
                mainPage.songs.Add(editedSong);
                mainPage.SaveData();
                NavigationService.Navigate(mainPage);
            }
            catch (Exception)
            {
                MessageBox.Show("Ошибка!", "Повторите ввод!", MessageBoxButton.OK);

            }
        }

        private void Home_Click(object sender, RoutedEventArgs e)
        {
            MainPage mainPage = new MainPage();
            NavigationService.Navigate(mainPage);
        }
    }
}
