using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using Thrift;
using Thrift.Protocol;
using Thrift.Server;
using Thrift.Transport;
using TYSystem.BaseFramework.Common.Helper;

namespace CSTJR.RPC.Common
{
    public class RPCHelp
    {
        /// <summary>
        /// 服务器IP
        /// </summary>
        private static string ServerIP { get; set; }
        ///// <summary>
        ///// 端口
        ///// </summary>
        //private static int Port { get; set; }

        static RPCHelp()
        {
            ServerIP = ConfigHelper.GetValue("Server", "localhost");
        }


        /// <summary>
        /// 初始化服务器
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="entity"></param>
        public static void Server<T>(T entity, string serverPort) where T : TProcessor
        {
            try
            {
                int Port = int.Parse(ConfigHelper.GetValue(serverPort, "8090"));

                TServerSocket serverTransport = new TServerSocket(Port);

                TBinaryProtocol.Factory factory = new TBinaryProtocol.Factory();

                TServer server = new TThreadPoolServer(entity, serverTransport, new TTransportFactory(), factory);

                Console.WriteLine(string.Format("服务端正在监听{0}端口", Port));

                server.Serve();
            }
            catch (TTransportException ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        /// <summary>
        /// 端口协议
        /// </summary>
        /// <returns></returns>
        public static TProtocol GetTransport(string serverPort)
        {
            int Port = int.Parse(ConfigHelper.GetValue(serverPort, "8090"));
            TTransport transport = new TSocket(ServerIP, Port);
            if (!transport.IsOpen)
                transport.Open();
            return new TBinaryProtocol(transport);

        }
    }
}
