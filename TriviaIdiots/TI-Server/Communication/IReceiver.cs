using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace TI_Server.Communication
{
    interface IReceiver
    {
        Task handlePackage(string message);
    }
}
