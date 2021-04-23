namespace Francis_ABC.D365.UnitTests
{
  using Francis_ABC.D365.Core.Managers.BES.D365.Core.Managers;
  using Francis_ABC.D365.Entities;
  using Francis_ABC.D365.UnitTests.Helper;
  using Xunit;

  public class TemplateManagerTests
  {

    [Fact]
    public void GetTemplateTemplateTitle()
    {
      UnitTestHelper unitTestHelper = new UnitTestHelper();

      var template = TemplateManager.GetTemplate(unitTestHelper.OrganizationService, unitTestHelper.TracingService, unitTestHelper.Entities.TemplateTestTemplate1.Title, Contact.EntityLogicalName);

      Assert.NotNull(template);
      Assert.Equal(unitTestHelper.Entities.TemplateTestTemplate1.TemplateId, template.TemplateId);
    }



    [Fact]
    public void GetTemplateTemplateId()
    {
      UnitTestHelper unitTestHelper = new UnitTestHelper();

      var template = TemplateManager.GetTemplate(unitTestHelper.OrganizationService, unitTestHelper.TracingService, unitTestHelper.Entities.TemplateTestTemplate1.TemplateId.Value);

      Assert.NotNull(template);
      Assert.Equal(unitTestHelper.Entities.TemplateTestTemplate1.Title, template.Title);
    }

    [Fact]
    public void GetTemplates()
    {
      UnitTestHelper unitTestHelper = new UnitTestHelper();

      var templates = TemplateManager.GetTemplates(unitTestHelper.OrganizationService, unitTestHelper.TracingService);

      Assert.NotEmpty(templates);
    }


    /*

    [Fact]
    public void GetTemplateTemplateIdKeyNotFoundException()
    {
      UnitTestHelper unitTestHelper = new UnitTestHelper();

      Assert.Throws<KeyNotFoundException>(() =>
      {
        var template = TemplateManager.GetTemplate(unitTestHelper.OrganizationService, unitTestHelper.TracingService, Guid.Empty);
      });
    }

   /* [Fact]
    public void GetTemplateTemplateTitleNotFound()
    {
      UnitTestHelper unitTestHelper = new UnitTestHelper();

      var template = TemplateManager.GetTemplate(unitTestHelper.OrganizationService, unitTestHelper.TracingService, "Template does not exist", Contact.EntityLogicalName);

      Assert.Null(template);
    }*/

    /* [Fact]
     public void InstantiateTemplate()
     {
       UnitTestHelper unitTestHelper = new UnitTestHelper();

       Assert.Throws<PullRequestException>(() =>
       {
         // InstantiateTemplateRequest not yet supported by FakeXrmEasy
         var emails = TemplateManager.InstantiateTemplate(unitTestHelper.OrganizationService, unitTestHelper.TracingService, unitTestHelper.Entities.TemplateTestTemplate1.TemplateId.Value, unitTestHelper.Entities.ContactTestContact1.ToEntityReference());

         // Assert.Single(emails);
       });
     }*/
  }
}
