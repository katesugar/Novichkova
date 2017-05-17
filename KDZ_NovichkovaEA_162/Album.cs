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
        public int Year;

        public Album()
        {

        }
        public override string ToString()
        {
            return Name + " " + Year;
        }

    }
}
