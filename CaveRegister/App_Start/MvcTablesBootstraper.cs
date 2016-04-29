using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MvcTables.Configuration;

namespace CaveRegister
{
    public class MvcTablesBootstraper
    {
        public static void Bootstrap()
        {
            ConfigureMvcTables.InTheSameAssembly.As<MvcTablesBootstraper>();
        }
    }
}
