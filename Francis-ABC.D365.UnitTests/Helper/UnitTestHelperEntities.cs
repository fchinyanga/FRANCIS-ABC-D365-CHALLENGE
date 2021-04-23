namespace Francis_ABC.D365.UnitTests
{
  using System;
  using System.Collections.Generic;
  using FakeXrmEasy;
  using Francis_ABC.D365.Entities;
  using Microsoft.Xrm.Sdk;

  /// <summary>
  /// The UnitTestHelperEntitiesClass
  /// </summary>
  public class UnitTestHelperEntities
  {
    /// <summary>
    /// Initializes a new instance of the <see cref="UnitTestHelperEntities"/> class.
    /// </summary>
    /// <param name="xrmFakedContext">The faked XRM Context</param>
    /// <param name="organizationService">The organization service</param>
    public UnitTestHelperEntities(XrmFakedContext xrmFakedContext, IOrganizationService organizationService)
    {
      this.XrmFakedContext = xrmFakedContext;
      this.OrganizationService = organizationService;

      this.InitialiseEntities();
      this.InitialiseRelationships();
      this.InitialiseXrmFakedContext();
      //this.InitialiseAssociations();
    }

    private XrmFakedContext XrmFakedContext { get; set; }

    private IOrganizationService OrganizationService { get; set; }

    public Contact ContactTestContact1 { get; private set; }

    public Contact ContactTestContact2 { get; private set; }
    /// </summary>
    public SystemUser SystemUserTestUser1 { get; private set; }

    /// <summary>
    /// Gets the Test User 2 System User
    /// </summary>
    public SystemUser SystemUserTestUser2 { get; private set; }

    #region Teams

    /// <summary>
    /// Gets the Test Team 1 Team
    /// </summary>
    public Team TeamTestTeam1 { get; private set; }

    /// <summary>
    /// Gets the Test Team QualityAndControl
    /// </summary>
    public Team TeamQualityAndControl { get; private set; }

    #endregion

    #region Templates

    /// <summary>
    /// Gets the Test Template 1 Template
    /// </summary>
    public Template TemplateTestTemplate1 { get; private set; }

    #endregion
    private void InitialiseEntities()
    {
      #region System Users

      this.SystemUserTestUser1 = new SystemUser
      {
        SystemUserId = new Guid("98179D20-0F49-44FB-9F8A-939C757FB108"),
        FirstName = "Test",
        LastName = "User 1",
      };

      this.SystemUserTestUser2 = new SystemUser
      {
        SystemUserId = new Guid("1341DDA1-0892-44A1-9A67-29C5FA23AEEB"),
        FirstName = "Test",
        LastName = "User 2",
      };

      #endregion

      #region Teams

      this.TeamTestTeam1 = new Team
      {
        TeamId = new Guid("62A6F5B5-0B09-4211-AB27-E72C57E5C68F"),
        Name = "Test Team 1",
        TeamType = new OptionSetValue((int)Team_TeamType.Owner),
      };

      this.TeamQualityAndControl = new Team
      {
        TeamId = new Guid("7E07EED8-9A49-43B8-AD84-7FDD2A520D67"),
        Name = "Quality & Control",
        TeamType = new OptionSetValue((int)Team_TeamType.Owner),
      };

      #endregion

      #region Templates

      this.TemplateTestTemplate1 = new Template
      {
        TemplateId = new Guid("5d846574-c3ed-4305-acf5-d8e80da5f0e6"),
        Title = "ABC Client WelcomeD",
        Subject = "Welcome To ABC CHALLENGE",
        Body = "Test Template 1 Body",
        TemplateTypeCode = Contact.EntityLogicalName,
      };

      this.ContactTestContact1 = new Contact
      {
        Id = new Guid("F128A4C8-966D-48AB-A63A-F44735CBDF04"),
        ContactId = new Guid("38AE02E7-2780-4E49-A851-3359B0677F0F"),
        Address1_Country = "GB",
      };

      this.ContactTestContact2 = new Contact
      {
        ContactId = new Guid("6356d45d-cbec-e811-a960-000d3ab98726"),
        Address1_Country = "GB",
      };
    }

    private void InitialiseRelationships()
    {
      this.XrmFakedContext.AddRelationship(SystemUserRoles.EntitySchemaName, new XrmFakedRelationship()
      {
        RelationshipType = XrmFakedRelationship.enmFakeRelationshipType.ManyToMany,
        IntersectEntity = SystemUserRoles.EntityLogicalName,
        Entity1LogicalName = SystemUser.EntityLogicalName,
        Entity1Attribute = SystemUserRoles.Fields.SystemUserId,
        Entity2LogicalName = Role.EntityLogicalName,
        Entity2Attribute = SystemUserRoles.Fields.RoleId
      });

      this.XrmFakedContext.AddRelationship(TeamMembership.EntitySchemaName, new XrmFakedRelationship()
      {
        RelationshipType = XrmFakedRelationship.enmFakeRelationshipType.ManyToMany,
        IntersectEntity = TeamMembership.EntityLogicalName,
        Entity1LogicalName = SystemUser.EntityLogicalName,
        Entity1Attribute = TeamMembership.Fields.SystemUserId,
        Entity2LogicalName = Team.EntityLogicalName,
        Entity2Attribute = TeamMembership.Fields.TeamId
      });
    }

    private void InitialiseXrmFakedContext()
    {
      this.XrmFakedContext.Initialize(
        new List<Entity>
        {

          this.ContactTestContact1,
          this.ContactTestContact2,

          // System Users
          this.SystemUserTestUser1,
          this.SystemUserTestUser2,

          // Teams
          this.TeamTestTeam1,
          this.TeamQualityAndControl,

          // Templates
          this.TemplateTestTemplate1,
        });
    }

    private void InitialiseAssociations()
    {
      /* #region System User Roles

       this.OrganizationService.Execute(new AssociateRequest
       {
         Target = this.SystemUserTestUser1.ToEntityReference(),

       });

       #endregion

       #region Team Membership

       this.OrganizationService.Execute(new AssociateRequest
       {
         Target = this.SystemUserTestUser1.ToEntityReference(),
         RelatedEntities = new EntityReferenceCollection() { this.TeamTestTeam1.ToEntityReference(), },
         Relationship = new Relationship(TeamMembership.EntitySchemaName)
       });

       this.OrganizationService.Execute(new AssociateRequest
       {
         Target = this.SystemUserTestUser2.ToEntityReference(),
         RelatedEntities = new EntityReferenceCollection() { this.TeamQualityAndControl.ToEntityReference(), },
         Relationship = new Relationship(TeamMembership.EntitySchemaName)
       });

       #endregion

       #region Contract Discipline

       /*   this.OrganizationService.Execute(new AssociateRequest
          {

          });
       #endregion
       */
    }
  }
  #endregion
}
