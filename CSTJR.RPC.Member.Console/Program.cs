using CSTJR.RPC.Common;
using CSTJR.RPC.Member.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSTJR.RPC.Member.Console
{
    class Program
    {
        static void Main(string[] args)
        {
            Task.Run(() => RPCHelp.Server<MemberService.Processor>(new MemberService.Processor(new RMemberService()), "Port"));
            System.Console.ReadLine();
        }
    }
}
