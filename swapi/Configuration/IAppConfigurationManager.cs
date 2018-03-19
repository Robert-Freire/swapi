namespace Swapi.Configuration
{
    /// <summary>
    /// Class AppConfigurationManager.
    /// Returns app configuration information
    /// </summary>
    public interface IAppConfigurationManager
    {
        /// <summary>
        /// Gets the root uri where it is stored the API
        /// </summary>
        /// <value>The root uri if the API server</value>
        string AppServer { get; }
    }
}