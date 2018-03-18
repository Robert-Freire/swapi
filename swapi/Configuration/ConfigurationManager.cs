using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Swapi
{
    public class AppConfigurationManager : IAppConfigurationManager
    {
        private readonly NameValueCollection appSettings = ConfigurationManager.AppSettings;

        public String AppServer
        {
            get
            {
                return appSettings["appServer"];
            }
        }

    }
}
