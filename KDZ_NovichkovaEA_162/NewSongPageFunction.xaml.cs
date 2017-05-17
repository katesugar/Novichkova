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

namespace KDZ_NovichkovaEA_162
{
    /// <summary>
    /// Логика взаимодействия для NewSongPageFunction.xaml
    /// </summary>
    public partial class NewSongPageFunction : PageFunction<Song>
    {
        public NewSongPageFunction()
        {
            InitializeComponent();
        }

        private void ButtonAdd_Click(object sender, RoutedEventArgs e)
        {
            Song song = new Song
            {
                Name = AddNameOfSongTextBox.Text,
                Artist = new Artist
                {
                    Name=AddNameOfArtistTextBox.Text,
                    Age = int.Parse(AddAgeTextBox.Text)
                },
                Album = new Album
                {
                    Name = AddNameOfAlbumTextBox.Text,
                    Year = int.Parse(AddYearOfAlbumTextBox.Text)
                },
                Year=int.Parse(AddYearOfSongTextBox.Text)
            };
            
        }
    }
}
