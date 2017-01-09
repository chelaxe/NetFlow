using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rubenhak.NetflowExporter
{
    public static class DateHelpers
    {
        public static uint GetEpoch()
        {
            return (uint)(DateTime.Now - new DateTime(1970, 1, 1)).TotalSeconds;
        }

        public static uint GetUpTimeMS()
        {
            return (uint)Environment.TickCount;
        }
    }
}
