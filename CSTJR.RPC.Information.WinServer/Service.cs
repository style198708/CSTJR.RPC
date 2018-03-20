using CSTJR.RPC.Common;
using CSTJR.RPC.Information.Contracts;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Linq;
using System.ServiceProcess;
using System.Text;
using System.Threading.Tasks;

namespace CSTJR.RPC.Information.WinServer
{
    partial class Service : ServiceBase
    {
        public Service()
        {
            InitializeComponent();
        }

        protected override void OnStart(string[] args)
        {
            Task.Run(() => RPCHelp.Server<InformationService.Processor>(new InformationService.Processor(new RInformationService()), "Port"));
        }

        protected override void OnStop()
        {
            // TODO: 在此处添加代码以执行停止服务所需的关闭操作。
        }
    }
}
