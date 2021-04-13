
namespace Francis_ABC.D365.Plugins.Plugins
{

  using Francis_ABC.D365.Core.Helpers.Plugins.Create;
  using Francis_ABC.D365.Core.Managers;
  using Francis_ABC.D365.Entities;

  [CrmPluginRegistration(
    MessageNameEnum.Create,
    Contact.EntityLogicalName,
    StageEnum.PreOperation,
    ExecutionModeEnum.Synchronous,
    "",
    "Francis_ABC.D365.Plugins.Plugins.ContactPreOperationCreate",
    1,
    IsolationModeEnum.Sandbox,
    Id = "53c1f0cc-0a36-ea11-a813-000d3ab3626x",
    Description = "Francis_ABC.D365.Plugins.Plugins.ContactPreOperationCreate")]
  public class ContactPreOperationCreate : PluginBase
  {
    public ContactPreOperationCreate(string unsecure, string secure)
        : base(typeof(ContactPreOperationCreate))
    {
    }

    protected override void ExecuteCrmPlugin(LocalPluginContext localContext)
    {
      Contact contact = InputParameters.GetTarget(localContext.PluginExecutionContext).ToEntity<Contact>();
      ContactManager.SetValuesForReadOnlyFields(localContext.OrganizationService, localContext.TracingService, contact);
    }
  }

  /*public class ContactPreOperationCreate : IPlugin
  {
    public void Execute(IServiceProvider serviceProvider)
    {
      try
      {
        IPluginExecutionContext context = (IPluginExecutionContext)serviceProvider.GetService(typeof(IPluginExecutionContext));
        if (context.InputParameters.Contains("Target") && context.InputParameters["Target"] is Entity)
        {
          ITracingService trace = (ITracingService)serviceProvider.GetService(typeof(ITracingService));
          IOrganizationServiceFactory serviceFactory = (IOrganizationServiceFactory)serviceProvider.GetService(typeof(IOrganizationServiceFactory));
          IOrganizationService service = serviceFactory.CreateOrganizationService(context.UserId);

          if (context.MessageName.ToLower() == "create" && context.Stage == 20)
          {
            Entity targetEntity = context.InputParameters["Target"] as Entity;
            int age = 0;
            double amountInvested = 0.0;
            int investmentPeriod = 0;
            double interestRate = 0.0;
            double estimatedReturnValue = 0;
            DateTime maturityDate = DateTime.Now;
            DateTime joiningDate = DateTime.Now;
            DateTime dob = DateTime.Now;

            if (targetEntity.LogicalName.ToLower() != "abc_contact")
            {
              return;
            }
            age = calculateAge(dob);
            targetEntity["abc_age"] = age;

            maturityDate = calculateMaturityDate(joiningDate, investmentPeriod);
            targetEntity["abc_maturitydate"] = maturityDate;

            estimatedReturnValue = calculateEstimatedReturnValue(joiningDate, amountInvested, investmentPeriod, interestRate);
            targetEntity["abc_estimatedreturnvalue"] = estimatedReturnValue;

            //optionset
            // targetEntity["abc_statusreason"] = estimatedReturnValue;
          }
        }
      }
      catch (Exception ex)
      {
        throw new InvalidPluginExecutionException(ex.Message);
      }

    }

    private double calculateEstimatedReturnValue(DateTime joiningDate, double amountInvested, int investmentPeriod, double interestRate)
    {
      return 1000000.00;
    }

    private DateTime calculateMaturityDate(DateTime joiningDate, int investmentPeriod)
    {
      return DateTime.Now.AddYears(10);
    }

    private int calculateAge(DateTime? dob)
    {
      return 50;
    }
  }*/
}
