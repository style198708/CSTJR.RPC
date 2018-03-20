using CSTJR.RPC.Web.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.IO;

namespace CSTJR.RPC.Web.Controllers
{
    public class HomeController : Controller
    {
        // GET: Home
        public ActionResult Index()
        {

            List<ServiceModel> list = GetServiceList();
            return View(list);
        }

        /// <summary>
        /// 执行行服务
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        public JsonResult ExecCommand(string Command, string ServeName)
        {
            string Msg = string.Empty;
            switch (Command)
            {
                case "InstallWindowService": ServerHelp.InstallWindowService(ServeName, ref Msg); break;
                case "UnInstallWindowService": ServerHelp.UnInstallWindowService(ServeName, ref Msg); break;
                case "StartWindowsService": ServerHelp.StartWindowsService(ServeName, ref Msg); break;
                case "StopWindowsService": ServerHelp.StopWindowsService(ServeName, ref Msg); break;
            };
            return new JsonResult() { Data = Msg };
        }


        public List<ServiceModel> GetServiceList()
        {
            List<ServiceModel> list = new List<ServiceModel>();
            string Path = System.Configuration.ConfigurationManager.AppSettings["Server"];
            DirectoryInfo directory = new DirectoryInfo(Path);
            foreach (DirectoryInfo info in directory.GetDirectories())
            {
                ServiceModel serviceModel = new ServiceModel();
                serviceModel.ServerName = info.Name;
                FileInfo file = info.GetFiles().Where(p => p.Extension == ".exe").FirstOrDefault();
                serviceModel.ServerFile = file.Name;
                serviceModel.ServerPath = file.FullName;
                serviceModel.Statu = "正常";
                list.Add(serviceModel);
            }
            return list;
        }
    }
}