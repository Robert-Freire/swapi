using System;
using System.Collections.Specialized;
using System.Configuration;

/// <summary>
/// The Configuration namespace.
/// In this namespace we put constants and configuration values
/// </summary>
namespace Swapi.Configuration
{
    /// <summary>
    /// Class AppConfigurationManager.
    /// Returns app configuration information
    /// </summary>
    /// <seealso cref="Swapi.IAppConfigurationManager" />
    public class AppConfigurationManager : IAppConfigurationManager
    {
        private readonly NameValueCollection appSettings = ConfigurationManager.AppSettings;

        /// <summary>
        /// Gets the root uri where it is stored the API
        /// </summary>
        /// <value>The root uri if the API server</value>
        public String AppServer
        {
            get
            {
                return appSettings["appServer"];
            }
        }

    }
}
