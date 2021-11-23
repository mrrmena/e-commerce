using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace e_commerce.Data.Command
{
    public class IncreaseTimeCommand : BaseCommand
    {
        public override CommandType commandType => CommandType.IncreaceTime;
        public int hour { get; private set; }

        public IncreaseTimeCommand(string line)
        {
            string[] lineProps = line.Split(' ');
            if (lineProps[0].ToLower() != "increase_time")
            {
                throw new Exception("wrong object type");
            }
            hour = Convert.ToInt32(lineProps[1]);
        }
    }
}
