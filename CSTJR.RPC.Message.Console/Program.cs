using CSTJR.RPC.Common;
using CSTJR.RPC.Message.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSTJR.RPC.Message.Console
{
    public class Program
    {
        static void Main(string[] args)
        {
            Task.Run(() => RPCHelp.Server<MessageService.Processor>(new MessageService.Processor(new RMessageService()), "Port"));
            System.Console.Read();
        }
    }
}
