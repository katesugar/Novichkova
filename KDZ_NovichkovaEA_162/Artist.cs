using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KDZ_NovichkovaEA_162
{
    public class Artist
    {
        public string Name;
        private int age;

        public int Age
        {
            get { return age; }
            set { if (value < 0) throw new ArgumentException("Возраст не может быть отрицательным."); else { age = value; }; }
        }

        public Artist()
        {

        }
        public override string ToString()
        {
            return Name;
        }

    }
}
