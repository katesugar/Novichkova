using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KDZ_NovichkovaEA_162
{
    public class Song
    {
        public string Name;
        public Album Album;
        public Artist Artist;
        public string Genre;
        private int year;

        public int Year
        {
            get { return year; }
            set { if (value < 0 || value > 2017) throw new ArgumentException("Год не может иметь отрицательное значение или значение больше, чем 2017."); else { year = value; }; }
        }


        public Song()
        {

        }
        public override string ToString()
        {
            return string.Format("{0} - {1}", Name, Artist);
        }

    }
}
