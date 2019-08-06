using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Globalization;
using System.IO;
using System.Linq;
using System.ServiceProcess;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

using System.Diagnostics;
using Newtonsoft.Json;
using System.IO;

namespace ServiceTest
{
    public partial class Service1 : ServiceBase
    {
        public Service1()
        {
            InitializeComponent();
        }

        protected override void OnStart(string[] args)
        {
            string config = File.ReadAllText("startup.json");

            EsStartupConfig startupConfig = JsonConvert.DeserializeObject<EsStartupConfig>(config);

            foreach (string appPath in startupConfig.run)
            {
                Process.Start(appPath);
            }
        }

        private void UpdateTaskProgress(string standardOuputLine)
        {
            //throw new NotImplementedException();
        }

        protected override void OnStop()
        {
        }
    }
}
