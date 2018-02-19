using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DA.Base
{
        public class DataBaseHelper
        {
        public static string GetDbProvider()
        {
            return ConfigurationManager.ConnectionStrings["DBServerConnection"].ProviderName;
        }
        public static string GetDbConnectionString()
        {
            return ConfigurationManager.ConnectionStrings["DBServerConnection"].ConnectionString;

        }
    }
}
