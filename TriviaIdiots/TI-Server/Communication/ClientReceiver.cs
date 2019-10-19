using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace TI_Server.Communication
{
    class ClientReceiver : IReceiver
    {
        public ClientReceiver()
        {

        }
        public void handlePackage(string message)
        {
            throw new NotImplementedException();
        }

        Task IReceiver.handlePackage(string message)
        {
            throw new NotImplementedException();
        }
    }
}
