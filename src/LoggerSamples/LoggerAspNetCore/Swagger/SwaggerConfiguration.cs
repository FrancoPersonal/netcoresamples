namespace LoggerAspNetCore.Swagger
{
    /// <summary>
    /// Defines the <see cref="SwaggerConfiguration" />.
    /// </summary>
    public class SwaggerConfiguration
    {
        /// <summary>
        /// <para>/swagger/v1/swagger.json</para>..
        /// </summary>
        public const string EndpointUrl = "../swagger/v1/swagger.json";

        /// <summary>
        /// <para>Jorge Serrano</para>..
        /// </summary>
        public const string ContactName = "Contact Name";

        /// <summary>
        /// <para>http://fakeurl</para>..
        /// </summary>
        public const string ContactUrl = "http://fakeurl";

        /// <summary>
        /// <para>v1</para>..
        /// </summary>
        public const string DocNameV1 = "v1";

        /// <summary>
        /// <para>Foo API</para>..
        /// </summary>
        public const string DocInfoTitle = "Sample API";

        /// <summary>
        /// Gets the DocInfoDescription
        /// <para>Foo Api - Sample Web API in ASP.NET Core 2</para>..
        /// </summary>
        public static string DocInfoDescription => $"{DocInfoTitle} - Sample Web API in ASP.NET Core 2";

        /// <summary>
        /// Gets the EndpointDescription
        /// <para>Foo API v1</para>..
        /// </summary>
        public static string EndpointDescription => $"{DocInfoTitle} {DocNameV1}";
    }
}
