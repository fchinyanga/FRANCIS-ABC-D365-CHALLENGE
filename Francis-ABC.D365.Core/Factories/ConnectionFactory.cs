namespace Francis_ABC.D365.Core.Factories
{
  using System;
  using System.Configuration;
  using System.Reflection;
  using System.ServiceModel.Description;
  using Microsoft.Xrm.Sdk;
  using Microsoft.Xrm.Sdk.Client;

  /// <summary>
  /// The ConnectionFactory
  /// </summary>
  public sealed class ConnectionFactory
  {
    /// <summary>
    /// The number of minutes that a token must be valid for in the future before a new token will be requested
    /// </summary>
    private const int TokenValidityBuffer = 5;

    /// <summary>
    /// Object used to lock the LockOrganisationServiceManagement
    /// </summary>
    private static readonly object LockOrganisationServiceManagement = new object();

    /// <summary>
    /// Prevents a default instance of the <see cref="ConnectionFactory"/> class from being created.
    /// </summary>
    private ConnectionFactory()
    {
    }

    /// <summary>
    /// Gets or sets the static organisation service management object
    /// </summary>
    private static IServiceManagement<IOrganizationService> OrganisationServiceManagement { get; set; } = null;

    /// <summary>
    /// Gets or sets the static authentication credentials
    /// </summary>
    private static AuthenticationCredentials AuthenticationCredentials { get; set; } = null;

    /// <summary>
    /// Gets or sets the static token credentials
    /// </summary>
    private static AuthenticationCredentials TokenCredentials { get; set; } = null;

    /// <summary>
    /// Gets the Organisation Service Proxy
    /// </summary>
    public static OrganizationServiceProxy OrganizationServiceProxy
    {
      get
      {
        lock (LockOrganisationServiceManagement)
        {
          if (OrganisationServiceManagement == null)
          {
            AuthenticationCredentials = new AuthenticationCredentials();
            AuthenticationCredentials.ClientCredentials.UserName.UserName = ConfigurationManager.AppSettings["integrationusername"];
            AuthenticationCredentials.ClientCredentials.UserName.Password = ConfigurationManager.AppSettings["integrationpassword"];

            OrganisationServiceManagement = ServiceConfigurationFactory.CreateManagement<IOrganizationService>(new Uri(ConfigurationManager.AppSettings["OrganisationServiceAddress"]));

            switch (OrganisationServiceManagement.AuthenticationType)
            {
              case AuthenticationProviderType.ActiveDirectory: /* No additional authentication required */ break;
              default: TokenCredentials = OrganisationServiceManagement.Authenticate(AuthenticationCredentials); break;
            }

            // Apply fix described at http://dotnetdust.blogspot.co.za/2014/02/improved-method-to-avoid.html to avoid race conditions during multi-thread operations
            Type type = OrganisationServiceManagement.GetType();
            MethodInfo method = type.GetMethod("EnableProxyTypes", new[] { typeof(Assembly) });
            method.Invoke(OrganisationServiceManagement, new object[] { typeof(Francis_ABC.D365.Entities.SystemUser).Assembly });
          }

          return GetProxy<IOrganizationService, OrganizationServiceProxy>();
        }
      }
    }

    /// <summary>
    /// Generic method to obtain discovery/organization service proxy instance.
    /// </summary>
    /// <typeparam name="TService">
    /// Set IDiscoveryService or IOrganizationService type to request respective service proxy instance.
    /// </typeparam>
    /// <typeparam name="TProxy">
    /// Set the return type to either DiscoveryServiceProxy or OrganizationServiceProxy type based on TService type.
    /// </typeparam>
    /// <param name="serviceManagement">An instance of IServiceManagement</param>
    /// <returns>An organisation service proxy instance</returns>
    private static TProxy GetProxy<TService, TProxy>()
        where TService : class
        where TProxy : ServiceProxy<TService>
    {
      Type classType = typeof(TProxy);

      switch (OrganisationServiceManagement.AuthenticationType)
      {
        case AuthenticationProviderType.ActiveDirectory:
          return (TProxy)classType.GetConstructor(new Type[] { typeof(IServiceManagement<TService>), typeof(ClientCredentials) }).Invoke(new object[] { OrganisationServiceManagement, AuthenticationCredentials.ClientCredentials });
        default:
          // Note: This limits the safe use of the returned IOrganizationService to TokenValidityBuffer minutes
          if (TokenCredentials == null || TokenCredentials.SecurityTokenResponse.Token.ValidTo < DateTime.UtcNow.AddMinutes(TokenValidityBuffer))
          {
            TokenCredentials = OrganisationServiceManagement.Authenticate(AuthenticationCredentials);
          }

          return (TProxy)classType.GetConstructor(new Type[] { typeof(IServiceManagement<TService>), typeof(SecurityTokenResponse) }).Invoke(new object[] { OrganisationServiceManagement, TokenCredentials.SecurityTokenResponse });
      }
    }
  }
}
