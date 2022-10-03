using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Soccer_parttwo.Interfaces
{
    internal interface IReader
    {
        IList<Fottball> GetFootballData(string fileLocation);
    }
}
