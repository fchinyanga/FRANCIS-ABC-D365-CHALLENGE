using System;

namespace Francis_ABC.D365.UnitTests.Mock
{
  using FakeXrmEasy;
  using Microsoft.Xrm.Sdk;

  class FakedOrganizationServiceFactory : IOrganizationServiceFactory
  {
    public FakedOrganizationServiceFactory()
    {
      this.XrmFakedContext = new XrmFakedContext();
    }

    public FakedOrganizationServiceFactory(XrmFakedContext xrmFakedContext)
    {
      this.XrmFakedContext = xrmFakedContext;
    }

    private XrmFakedContext XrmFakedContext { get; }

    public IOrganizationService CreateOrganizationService(Guid? userId)
    {
      if (userId != null)
      {
        this.XrmFakedContext.CallerId = new EntityReference("systemuser", userId.Value);
      }

      return this.XrmFakedContext.GetOrganizationService();
    }
  }
}
