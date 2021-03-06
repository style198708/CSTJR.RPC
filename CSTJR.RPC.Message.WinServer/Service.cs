﻿using CSTJR.RPC.Common;
using CSTJR.RPC.Message.Contracts;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Linq;
using System.ServiceProcess;
using System.Text;
using System.Threading.Tasks;

namespace CSTJR.RPC.Message.WinServer
{
    partial class Service : ServiceBase
    {
        public Service()
        {
            InitializeComponent();
        }

        protected override void OnStart(string[] args)
        {
            Task.Run(() => RPCHelp.Server<MessageService.Processor>(new MessageService.Processor(new RMessageService()), "Port"));
        }

        protected override void OnStop()
        {
            // TODO: 在此处添加代码以执行停止服务所需的关闭操作。
        }
    }
}
