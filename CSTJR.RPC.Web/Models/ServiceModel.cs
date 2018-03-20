using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CSTJR.RPC.Web.Models
{
    public class ServiceModel
    {
        /// <summary>
        /// 服务名称
        /// </summary>
        public string ServerName { get; set; }

        /// <summary>
        /// 服务文件
        /// </summary>
        public string ServerFile { get; set; }

        /// <summary>
        /// 文件路径
        /// </summary>
        public string ServerPath { get; set; }

        /// <summary>
        /// 文件路径
        /// </summary>
        public string Statu { get; set; }

    }
}