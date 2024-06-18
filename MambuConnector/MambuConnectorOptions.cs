namespace MambuConnector
{
    /// <summary>
    /// Options to use mambu connector.
    /// </summary>
    public class MambuConnectorOptions
    {
        /// <summary>
        /// URL of mambu.
        /// </summary>
        public string Url { get; set; }
        /// <summary>
        /// User to authenticate in mambu.
        /// </summary>
        public string User { get; set; }
        /// <summary>
        /// Password of user.
        /// </summary>
        public string Password { get; set; }
    }
}
