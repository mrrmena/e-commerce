using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace e_commerce.Structure
{
    public abstract class Storable : IStorable
    {
        public string key { get; set; }
    }
}
