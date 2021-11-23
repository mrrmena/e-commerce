using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace e_commerce.Data.Command
{
    public abstract class BaseCommand
    {
        public abstract CommandType commandType { get; }
    }
}
