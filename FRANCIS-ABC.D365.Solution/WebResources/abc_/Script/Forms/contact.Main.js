if (typeof ABC === "undefined") { var ABC = {}; }
if (ABC.Script === undefined) { ABC.Script = {}; }
if (ABC.Script.Form === undefined) { ABC.Script.Form = {}; }
if (ABC.Script.Form.contact === undefined) { ABC.Script.Form.contact = {}; }
if (ABC.Script.Form.contact.Main === undefined) {
  ABC.Script.Form.contact.Main = {
    onLoad: function (context) {
      ABC.Script.Form.contact.Main.attachEvents(context);
      ABC.Script.Form.contact.Main.businessRules(context);
    },

    onSave: function (context) {

    },

    attachEvents: function (context) {
      var formContext = context.getFormContext();
      formContext.getAttribute(Francis_ABC.Entities.contact.Fields.abc_typeofclient).addOnChange(ABC.Script.Form.contact.Main.clientTypeOnChange);
      formContext.getAttribute(Francis_ABC.Entities.contact.Fields.preferredcontactmethodcode).addOnChange(ABC.Script.Form.contact.Main.preferredMethodOfContactOnChange);
    },

    businessRules: function (context) {
      try {
        var formContext = context.getFormContext();
        var clientType = formContext.getAttribute(Francis_ABC.Entities.contact.Fields.abc_typeofclient).getValue();
        var methodOfContact = formContext.getAttribute(Francis_ABC.Entities.contact.Fields.preferredcontactmethodcode).getValue();
        var corparateClientControl = formContext.getControl(Francis_ABC.Entities.contact.Fields.abc_corporateclientname);
        var individualClientControl = formContext.getControl(Francis_ABC.Entities.contact.Fields.abc_individualclientname);
        corparateClientControl.setVisible(clientType === Francis_ABC.OptionSets.contact.abc_typeofclient.CorporateClient);
        individualClientControl.setVisible(clientType === Francis_ABC.OptionSets.contact.abc_typeofclient.IndividualClient);
        formContext.getAttribute(Francis_ABC.Entities.contact.Fields.emailaddress1).setRequiredLevel(methodOfContact === Francis_ABC.OptionSets.contact.preferredcontactmethodcode.Email ? Francis_ABC.RequiredLevel.required.Required : Francis_ABC.RequiredLevel.required.None
          );
        formContext.getAttribute(Francis_ABC.Entities.contact.Fields.mobilephone).setRequiredLevel(methodOfContact === Francis_ABC.OptionSets.contact.preferredcontactmethodcode.Phone ? Francis_ABC.RequiredLevel.required.Required : Francis_ABC.RequiredLevel.required.None
        );
        individualClientControl.setDisabled(formContext.getAttribute(Francis_ABC.Entities.contact.Fields.contactid) != null);
        debugger;
        corparateClientControl.setDisabled(formContext.getAttribute(Francis_ABC.Entities.contact.Fields.contactid) != null );
      }
      catch (ex) {
        console.log(ex.message);
      }

    },
    dateOfBirthOnChange: function(context) {
      //this.businessRules(context);
    },
    clientTypeOnChange: function (context) {
      ABC.Script.Form.contact.Main.businessRules(context);
    },

    preferredMethodOfContactOnChange: function (context) {
      ABC.Script.Form.contact.Main.businessRules(context);
    }

  }
}