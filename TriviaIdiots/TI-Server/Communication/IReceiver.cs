using System;
using System.Collections.Generic;
using System.Text;

namespace TI_Server.Communication
{
    interface IReceiver
    {
        void handlePackage(string message);
    }
}
