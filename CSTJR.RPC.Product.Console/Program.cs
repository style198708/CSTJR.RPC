using CSTJR.RPC.Common;
using CSTJR.RPC.Product.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSTJR.RPC.Product.Console
{
    class Program
    {
        static void Main(string[] args)
        {
            Task.Run(() => RPCHelp.Server<ProductService.Processor>(new ProductService.Processor(new RProductService()), "Port"));
            System.Console.Read();
        }
    }
}
