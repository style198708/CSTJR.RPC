using CSTJR.RPC.Common;
using CSTJR.RPC.Information.Contracts;
using System.Threading.Tasks;

namespace CSTJR.RPC.Information.Console
{
    class Program
    {
        static void Main(string[] args)
        {
            Task.Run(() => RPCHelp.Server<InformationService.Processor>(new InformationService.Processor(new RInformationService()), "Port"));
            System.Console.Read();
        }
    }
}
