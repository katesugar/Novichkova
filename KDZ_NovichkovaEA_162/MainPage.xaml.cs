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
using System.IO;
using System.Data.Entity;

namespace KDZ_NovichkovaEA_162
{
    /// <summary>
    /// Логика взаимодействия для MainPage.xaml
    /// </summary>
    public partial class MainPage : Page
    {
        public MainPage()
        {
            InitializeComponent();
            songs = DataLoad();
            listofmusicBox.ItemsSource = songs;
            selectedSong = listofmusicBox.SelectedIndex;
            
        }
        public List<Song> songs = new List<Song>();
        public int selectedSong;

        public List<Song> DataLoad()
        {
            listofmusicBox.Items.Refresh();
            string line;
            List<Song> result = new List<Song>();
            System.IO.StreamReader file = new System.IO.StreamReader("../../listofmusic.txt");
            while ((line = file.ReadLine()) != null)
            {
                var temp = line.Split(',');
                result.Add(new Song
                {
                    Name = temp[0],
                    Artist = new Artist
                    {
                        Name = temp[1],
                        Age = int.Parse(temp[2])
                    },
                    Album = new Album
                    {
                        Name = temp[3],
                        Year = int.Parse(temp[4])

                    },
                    Year = int.Parse(temp[5]),
                    Genre = temp[6]
                }
                    );

            }

            file.Close();
            return result;

        }
        public void SaveData()
        {
            using (FileStream fs = new FileStream("../../listofmusic.txt", FileMode.Create))
            {
                using (StreamWriter sw = new StreamWriter(fs, Encoding.GetEncoding(1251)))
                {
                    for (int i = 0; i < songs.Count; i++)
                    {
                        sw.WriteLine("{0},{1},{2},{3},{4},{5},{6}", songs[i].Name, songs[i].Artist.Name, songs[i].Artist.Age, songs[i].Album.Name, songs[i].Album.Year, songs[i].Year, songs[i].Genre);
                    }

                }
            }
            listofmusicBox.Items.Refresh();
        }


        private void AddButton_Click(object sender, RoutedEventArgs e)
        {
            NewSongPage newSongPage = new NewSongPage();
            NavigationService.Navigate(newSongPage);

        }

        private void SearchTextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (SearchSong.IsChecked == true)
            {
                if (string.IsNullOrWhiteSpace(SearchTextBox.Text)) listofmusicBox.ItemsSource = songs;
                else listofmusicBox.ItemsSource = songs.FindAll(song => song.Name.ToUpper().Contains(SearchTextBox.Text.ToUpper()));
            }
            if(SearchArtist.IsChecked==true)
            {
                if (string.IsNullOrWhiteSpace(SearchTextBox.Text)) listofmusicBox.ItemsSource = songs;
                else listofmusicBox.ItemsSource = songs.FindAll(song => song.Artist.Name.ToUpper().Contains(SearchTextBox.Text.ToUpper()));
            }

        }

        private void DeleteButton_Click(object sender, RoutedEventArgs e)
        {
            if (listofmusicBox.SelectedIndex != -1)
            {
                songs.RemoveAt(listofmusicBox.SelectedIndex);
                SaveData();
                listofmusicBox.Items.Refresh();
            }
        }

        private void EditButton_Click(object sender, RoutedEventArgs e)
        {
            if (listofmusicBox.SelectedItem == null) return;

            Song selectedSong = listofmusicBox.SelectedItem as Song;

            EditingPage editingPage = new EditingPage();
            NavigationService.Navigate(editingPage);
            editingPage.AddNameOfSongTextBox.Text = selectedSong.Name;
            editingPage.AddNameOfArtistTextBox.Text = selectedSong.Artist.Name;
            editingPage.AddAgeTextBox.Text = selectedSong.Artist.Age.ToString();
            editingPage.AddNameOfAlbumTextBox.Text = selectedSong.Album.Name;
            editingPage.AddYearOfAlbumTextBox.Text = selectedSong.Album.Year.ToString();
            editingPage.AddYearOfSongTextBox.Text = selectedSong.Year.ToString();
            editingPage.AddGenreTextBox.Text = selectedSong.Genre;
            songs.RemoveAt(listofmusicBox.SelectedIndex);
            SaveData();
            listofmusicBox.Items.Refresh();        
        }

        private void InfoButton_Click(object sender, RoutedEventArgs e)
        {
            if (listofmusicBox.SelectedItem == null) return;

            Song selectedSong = listofmusicBox.SelectedItem as Song;
            InfoPage infoPage = new InfoPage();
            NavigationService.Navigate(infoPage);
            Binding binding = new Binding();
            binding.Source = selectedSong.Name;
            infoPage.NameOfSong.SetBinding(TextBlock.TextProperty, binding);
            Binding binding1 = new Binding();
            binding1.Source = selectedSong.Year;
            infoPage.YearOfSong.SetBinding(TextBlock.TextProperty, binding1);
            Binding binding2 = new Binding();
            binding2.Source = selectedSong.Artist.Name;
            infoPage.NameOfArtist.SetBinding(TextBlock.TextProperty, binding2);
            Binding binding3 = new Binding();
            binding3.Source = selectedSong.Artist.Age;
            infoPage.AgeOfArtist.SetBinding(TextBlock.TextProperty, binding3);
            Binding binding4 = new Binding();
            binding4.Source = selectedSong.Album.Name;
            infoPage.NameOfAlbum.SetBinding(TextBlock.TextProperty, binding4);
            Binding binding5 = new Binding();
            binding5.Source = selectedSong.Album.Year;
            infoPage.YearOfAlbum.SetBinding(TextBlock.TextProperty, binding5);
            Binding binding6 = new Binding();
            binding6.Source = selectedSong.Genre;
            infoPage.Genre.SetBinding(TextBlock.TextProperty, binding6);
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
