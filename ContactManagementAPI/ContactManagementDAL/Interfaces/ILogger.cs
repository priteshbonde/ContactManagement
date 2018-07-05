using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ContactManagementDAL.Interfaces
{
    public interface ILogger
    {
        int Log(string exception);
    }
}
