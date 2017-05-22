using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KDZ_NovichkovaEA_162
{
    public class Album
    {
        public string Name;
        private int year;

        public int Year
        {
            get { return year; }
            set { if (value < 0 || value > 2017) throw new ArgumentException("Год не может иметь отрицательное значение или значение больше, чем 2017."); else { year = value; }; }
        }

        public Album()
        {

        }
        public override string ToString()
        {
            return Name + " " + Year;
        }

    }
}
