namespace Francis_ABC.D365.UnitTests.Mock
{
  using System;
  using FakeXrmEasy;

  public class FakedServiceProvider : IServiceProvider
  {
    public FakedServiceProvider()
    {
      this.XrmFakedContext = new XrmFakedContext();
    }

    public FakedServiceProvider(XrmFakedContext xrmFakedContext)
    {
      this.XrmFakedContext = xrmFakedContext;
    }

    private XrmFakedContext XrmFakedContext { get; }

    public object GetService(Type serviceType)
    {
      switch (serviceType.Name)
      {
        case "IOrganizationServiceFactory": return new FakedOrganizationServiceFactory(this.XrmFakedContext);
        default: throw new InvalidOperationException($"Unhandled service type: {serviceType}");
      }
    }
  }
}
