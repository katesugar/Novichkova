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
        public int Year;

        public Song()
        {

        }
        public override string ToString()
        {
            return string.Format("{0} - {1}", Name, Artist);
        }

    }
}
