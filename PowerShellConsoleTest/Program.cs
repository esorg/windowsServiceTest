using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Management.Automation;
using System.Text;
using System.Threading.Tasks;

using System.Diagnostics;
using Newtonsoft.Json;
using System.IO;

namespace PowerShellConsoleTest
{


    class Program
    {
        static void Main(string[] args)
        {
            string config = File.ReadAllText("startup.json");
            
            EsStartupConfig startupConfig = JsonConvert.DeserializeObject<EsStartupConfig>(config);

            foreach (string appPath in startupConfig.run)
            {
                Process.Start(appPath);
            }
        }
    }
}
