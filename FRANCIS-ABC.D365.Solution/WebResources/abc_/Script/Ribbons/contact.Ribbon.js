﻿if (typeof ABC === "undefined") { var ABC = {}; }
if (ABC.Script === undefined) { ABC.Script = {}; }
if (ABC.Script.Ribbons === undefined) { ABC.Script.Ribbons= {}; }
if (ABC.Script.Ribbons.contact === undefined) { ABC.Script.Ribbons.contact = {}; }
if (ABC.Script.Ribbons.contact.Ribbon === undefined) {
  ABC.Script.Ribbons.contact.Ribbon = {

    extendInvestment: function(context) {
      context.ui.setFormNotification("Extending Investment By 6 Months... Please wait...", "INFO", "extend");
      debugger;
      var contactID = context.data.entity.getId().replace("{", "").replace("}", "");
      debugger;
      try {
        D365.Core.WebApi.Retrieve(context,
          Francis_ABC.Entities.contact.ODataEntitySet,
          contactID,
          [Francis_ABC.Entities.contact.Fields.abc_investmentperiod, Francis_ABC.Entities.contact.Fields.abc_joiningdate],
          function (abc_contact) {
            var currentInvestment = abc_contact.abc_investmentperiod;
            var newInvestmentDate = currentInvestment + 6;
            var joiningDate = new Date(abc_contact.abc_joiningdate);
            var newInvestmentMaturityDate = new Date(joiningDate.setMonth(joiningDate.getMonth() + newInvestmentDate));

            debugger;
            try {
            var body = {
              "abc_investmentperiod": newInvestmentDate,
              "abc_joiningdate": newInvestmentMaturityDate,
              "abc_statusreason": Francis_ABC.OptionSets.contact.abc_statusreason.ActiveInForce
              };
              D365.Core.WebApi.Patch(context, "contacts("+ abc_contact.contactid+")?$select=abc_investmentperiod", JSON.stringify(body),
                function (updated_abc_contact) {
                  debugger;
                  context.data.refresh().then(function (success) {
                    console.log('refreshed');
                    context.ui.clearFormNotification("extend");
                    context.ui.setFormNotification("Investment Extended By 6 Months", "INFO", "extended");
                    setTimeout(function () {
                      context.ui.clearFormNotification("extended");
                    }, 1000);
                    debugger;
                  }, function (error) {
                      console.log('error refreshing');
                      context.ui.clearFormNotification("extend");
                      debugger;
                  });
                  debugger;
                },
                function (error) {
                  console.log(error);
                  context.ui.clearFormNotification("extend");
                  debugger;
                }
              );
            }
            catch (error) {
              console.log(error);
              context.ui.clearFormNotification("extend");
              debugger;
            }
          },
          function (error) {
            console.log(error);
            context.ui.clearFormNotification("extend");
            debugger;
            alert('Error found while retrieing');
          }
        );
      }
      catch (err) {
        console.log(err.message);
        alert(err.message);
      }

    },

    setStatusReasonToMatured: function (context) {
      var contactID = context.data.entity.getId().replace("{", "").replace("}", "");
      context.ui.setFormNotification("Changing Status Reason... Please wait...", "INFO", "setStatusReason");
      try {
        D365.Core.WebApi.Retrieve(context,
          'contacts',
          contactID,
          [Francis_ABC.Entities.contact.Fields.abc_investmentperiod, Francis_ABC.Entities.contact.Fields.abc_joiningdate],
          function (abc_contact) {
            debugger;
            try {
              var joiningDate = new Date(abc_contact.abc_joiningdate);
              var investmentMaturityDate = new Date(joiningDate.setMonth(joiningDate.getMonth() + abc_contact.abc_investmentperiod));
              var currentDate = new Date();
              var investMaturityDateWithoutTime = new Date(investmentMaturityDate.getFullYear(), investmentMaturityDate.getMonth(), investmentMaturityDate.getDate());
              debugger;
              var currentDateWithoutTime = new Date(currentDate.getFullYear(), currentDate.getMonth(), currentDate.getDate());
            } catch (ex) {
              console.log(ex.message);
            }
            if (investMaturityDateWithoutTime > currentDateWithoutTime) {
              debugger;
              alert('Your investment is not yet matured.\ The investment maturity date is ' + investMaturityDateWithoutTime);
            }
            else {
              try {
                var body = {
                  "abc_statusreason": Francis_ABC.OptionSets.contact.abc_statusreason.InactiveMatured,

                };
                D365.Core.WebApi.Patch(context, "contacts("+ abc_contact.contactid+")?$select=abc_investmentperiod", JSON.stringify(body),
                  function (updated_abc_contact) {
                    debugger;
                    context.data.refresh().then(function (success) {
                      console.log('refreshed');
                      context.ui.clearFormNotification("setStatusReason");
                      context.ui.setFormNotification("Status Reason set to Matured", "INFO", "statusReasonChanged");
                      setTimeout(function () {
                        context.ui.clearFormNotification("statusReasonChanged");
                      }, 1000);
                      debugger;
                    }, function (error) {
                        console.log('error refreshing');
                        context.ui.clearFormNotification("setStatusReason");
                      debugger;
                    });
                    debugger;
                  },
                  function (error) {
                    console.log(error);
                    context.ui.clearFormNotification("setStatusReason");
                    debugger;
                  }
                );
              } catch (ex) {
                debugger;
                context.ui.clearFormNotification("setStatusReason");
                console.log(ex.message);
              }
            }
          },
          function (error) {
            console.log(error);
            context.ui.clearFormNotification("setStatusReason");
            debugger;
          }
          
        );

      }
      catch(ex) {
        console.log(ex.message);

      }
    }

  }

}