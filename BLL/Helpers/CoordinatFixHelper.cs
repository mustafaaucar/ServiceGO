using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Helpers
{
    public static class CoordinatFixHelper
    {
        public static decimal FixCoordinate(decimal coordinate)
        {
            return coordinate / 1_000_000M;
        }
    }
}
