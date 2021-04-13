namespace Francis_ABC.D365.Plugins
{
  using Microsoft.Xrm.Sdk;

  /// <summary>
  /// The ILocalPluginContext interface
  /// </summary>
  public interface ILocalPluginContext
  {
    /// <summary>
    /// Gets the organization service
    /// </summary>
    IOrganizationService OrganizationService { get; }

    /// <summary>
    /// Gets the plugin execution context
    /// </summary>
    IPluginExecutionContext PluginExecutionContext { get; }

    /// <summary>
    /// Gets the tracing service
    /// </summary>
    ITracingService TracingService { get; }

    /// <summary>
    /// Gets the notification service
    /// </summary>
    IServiceEndpointNotificationService NotificationService { get; }

    /// <summary>
    /// Writes a trace message to the CRM trace log
    /// </summary>
    /// <param name="message">The message</param>
    void Trace(string message);
  }
}
