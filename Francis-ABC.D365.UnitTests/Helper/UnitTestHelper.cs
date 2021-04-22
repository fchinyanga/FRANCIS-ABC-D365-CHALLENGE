namespace Francis_ABC.D365.UnitTests.Helper
{
  using System;
  using System.Collections.Generic;
  using FakeXrmEasy;
  using FakeXrmEasy.Extensions;
  using Francis_ABC.D365.Core.Logging;
  using Francis_ABC.D365.Plugins.Entities;
  using Francis_ABC.D365.UnitTests.Mock;
  using Microsoft.Xrm.Sdk;
  using Microsoft.Xrm.Sdk.Metadata;

  /// <summary>
  /// The Unit Test Helper class
  /// </summary>
  public sealed class UnitTestHelper
  {
    /// <summary>
    /// Initializes a new instance of the <see cref="UnitTestHelper"/> class.
    /// </summary>
    public UnitTestHelper()
    {
      this.XrmFakedContext = new XrmFakedContext();

      this.OrganizationService = this.XrmFakedContext.GetOrganizationService();
      this.ExecutionContext = this.XrmFakedContext.GetDefaultPluginContext();
      this.NotificationService = this.XrmFakedContext.GetFakedServiceEndpointNotificationService();
      this.ServiceProvider = new FakedServiceProvider(this.XrmFakedContext);
      this.TracingService = new DynamicsTracingService(this.XrmFakedContext.GetFakeTracingService(), this.XrmFakedContext.GetDefaultPluginContext());

      this.Entities = new UnitTestHelperEntities(this.XrmFakedContext, this.OrganizationService);
      this.InitialiseMetadata();
    }

    /// <summary>
    /// Gets the Xrm Faked Context
    /// </summary>
    public XrmFakedContext XrmFakedContext { get; }

    /// <summary>
    /// Gets the Xrm Faked Relationship
    /// </summary>
    public XrmFakedRelationship XrmFakedRelationship { get; }

    /// <summary>
    /// Gets the Organization Service
    /// </summary>
    public IOrganizationService OrganizationService { get; }

    /// <summary>
    /// Gets the Plugin Execution Context
    /// </summary>
    public IPluginExecutionContext ExecutionContext { get; }

    /// <summary>
    /// Gets the Notification Service
    /// </summary>
    public IServiceEndpointNotificationService NotificationService { get; }

    /// <summary>
    /// Gets the Service Provider
    /// </summary>
    public IServiceProvider ServiceProvider { get; }

    /// <summary>
    /// Gets the Tracing Service
    /// </summary>
    public ITracingService TracingService { get; }

    /// <summary>
    /// Gets the Entities
    /// </summary>
    public UnitTestHelperEntities Entities { get; }




    /// <summary>
    /// Initialise the metadata
    /// </summary>
    private void InitialiseMetadata()
    {
      EntityMetadata entityMetadataAccount = new EntityMetadata
      {
        LogicalName = Contact.EntityLogicalName,
      };

      entityMetadataAccount.SetAttribute(
        new PicklistAttributeMetadata
        {
          SchemaName = Contact.EntitySchemaName,
          LogicalName = Contact.EntityLogicalName,
          DisplayName = new Label("Contact", 1033),
          RequiredLevel = new AttributeRequiredLevelManagedProperty(AttributeRequiredLevel.None),
          OptionSet = new OptionSetMetadata
          {
            IsGlobal = false,
            OptionSetType = OptionSetType.Picklist,
            Options = {
              new OptionMetadata(new Label(new LocalizedLabel("Preferred Customer", 1033), null), 1),
              new OptionMetadata(new Label(new LocalizedLabel("Standard", 1033), null), 2)
            }
          },
        });

      this.XrmFakedContext.InitializeMetadata(new List<EntityMetadata>
      {
        entityMetadataAccount
      });
    }
  }
}
