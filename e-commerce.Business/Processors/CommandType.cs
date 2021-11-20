using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace e_commerce.Business.Processors
{
    public enum CommandType
    {
        [Description("create")]
        create,
        [Description("get")]
        get,
        [Description("increase")]
        increace,

    }
}
