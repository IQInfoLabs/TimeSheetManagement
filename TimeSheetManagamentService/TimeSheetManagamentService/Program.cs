using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceProcess;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace TimeSheetManagamentService
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        static void Main()
        {
            if (Environment.UserInteractive)
            {
                TimeManagement.Instance.EnableFileWatch();
                Thread.Sleep(100000);
            }
            else
            {
                ServiceBase[] ServicesToRun;
                ServicesToRun = new ServiceBase[]
                {
                new TimeSheetManagement()
                };
                ServiceBase.Run(ServicesToRun);
            }
        }
    }
}
