using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ServiceProcess;
using System.IO;
using System.Reflection;

namespace CSTJR.RPC.Web
{
    public class ServerHelp
    {

        public static readonly string ServerPath = System.Configuration.ConfigurationManager.AppSettings["Server"];
        /// <summary>
        /// 安装服务
        /// </summary>
        public static void InstallWindowService(string serviceName, ref string Msg)
        {
            ////要安装的服务文件（就是用 InstallUtil.exe 工具安装时的参数）
            DirectoryInfo directory = new DirectoryInfo(Path.Combine(ServerPath, serviceName));
            FileInfo fileInfo = directory.GetFiles("*.exe").FirstOrDefault();
            if (!ServiceIsExisted(serviceName))
            {
                try
                {
                    //System.Configuration.Install.ManagedInstallerClass.InstallHelper(args);
                    ServerAPIHelp.Install(
                                serviceName,                                // 服务名
                                serviceName,                             // 显示名称
                                fileInfo.FullName,      // 映像路径，可带参数，若路径有空格，需给路径（不含参数）套上双引号
                                "服务",                         // 服务描述
                                ServiceStartType.Auto,                 // 启动类型
                                ServiceAccount.LocalService,           // 运行帐户，可选，默认是LocalSystem，即至尊帐户
                                null                    // 依赖服务，要填服务名称，没有则为null或空数组，可选
                                );
                    Msg = "服务安装成功！";
                    //Console.WriteLine("服务安装成功！");
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                    return;
                }
            }
            else
            {
                Msg = "该服务已经存在，不用重复安装。";
            }
        }

        /// <summary>
        /// 卸载服务
        /// </summary>
        /// <param name="serviceName"></param>
        public static void UnInstallWindowService(string serviceName, ref string Msg)
        {

            try
            {
                if (ServiceIsExisted(serviceName))
                {
                    ServerAPIHelp.Uninstall(serviceName);
                    Msg = "卸载服务成功！";
                    //string path = serviceName + ".exe";
                    ////UnInstall Service  
                    //System.Configuration.Install.AssemblyInstaller myAssemblyInstaller = new System.Configuration.Install.AssemblyInstaller();
                    //myAssemblyInstaller.UseNewContext = true;
                    //myAssemblyInstaller.Path = fileInfo.FullName;
                    //myAssemblyInstaller.Uninstall(null);
                    //myAssemblyInstaller.Dispose();

                    //Console.WriteLine("");
                }
                else
                {
                    Msg = "服务不存在！";
                    //Console.WriteLine("服务不存在！");
                }

            }
            catch (Exception)
            {
                Msg = "卸载服务失败！";
            }
        }

        /// <summary>
        /// 开启服务
        /// </summary>
        /// <param name="windowsServiceName">服务名称</param>
        public static void StartWindowsService(string windowsServiceName, ref string Msg)
        {
            using (ServiceController control = new ServiceController(windowsServiceName))
            {
                if (control.Status == ServiceControllerStatus.Stopped)
                {
                    Console.WriteLine("服务启动......");
                    control.Start();
                    Console.WriteLine("服务已经启动......");
                    Msg = "服务启动成功！";
                }
                else if (control.Status == ServiceControllerStatus.Running)
                {
                    Msg = "服务已经启动......";
                    //Console.WriteLine("服务已经启动......");
                }
            }

        }

        /// <summary>
        /// 停止服务
        /// </summary>
        /// <param name="windowsServiceName">服务名称</param>
        public static void StopWindowsService(string windowsServiceName, ref string Msg)
        {
            using (ServiceController control = new ServiceController(windowsServiceName))
            {
                if (control.Status == ServiceControllerStatus.Running)
                {
                    Console.WriteLine("服务停止......");
                    control.Stop();
                    Console.WriteLine("服务已经停止......");
                    Msg = "服务停止成功！";
                }
                else if (control.Status == ServiceControllerStatus.Stopped)
                {
                    Msg = "服务已经停止......";
                    //Console.WriteLine("服务已经停止......");
                }
            }
        }

        /// <summary>  
        /// 检查指定的服务是否存在  
        /// </summary>  
        /// <param name="serviceName">要查找的服务名字</param>  
        /// <returns></returns>  
        private static bool ServiceIsExisted(string svcName)
        {
            ServiceController[] services = ServiceController.GetServices();
            foreach (ServiceController s in services)
            {
                if (s.ServiceName == svcName)
                {
                    return true;
                }
            }
            return false;

        }
    }
}