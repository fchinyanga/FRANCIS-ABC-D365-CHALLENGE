
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
// Created via this command line: "C:\Users\Fchinyanga\AppData\Roaming\MscrmTools\XrmToolBox\Plugins\DLaB.EarlyBoundGenerator\crmsvcutil.exe" /url:"https://francissingularmsdynamics.api.crm4.dynamics.com" /namespace:"Francis_ABC.D365.Entities" /out:"C:\Users\Fchinyanga\source\repos\Francis-ABC.D365\Francis-ABC.D365.Entities\OptionSets.cs" /SuppressGeneratedCodeAttribute:"true" /codecustomization:"DLaB.CrmSvcUtilExtensions.OptionSet.CustomizeCodeDomService,DLaB.CrmSvcUtilExtensions" /codegenerationservice:"DLaB.CrmSvcUtilExtensions.OptionSet.CustomCodeGenerationService,DLaB.CrmSvcUtilExtensions" /codewriterfilter:"DLaB.CrmSvcUtilExtensions.OptionSet.CodeWriterFilterService,DLaB.CrmSvcUtilExtensions" /namingservice:"DLaB.CrmSvcUtilExtensions.NamingService,DLaB.CrmSvcUtilExtensions" /metadataproviderservice:"DLaB.CrmSvcUtilExtensions.BaseMetadataProviderService,DLaB.CrmSvcUtilExtensions" 
//------------------------------------------------------------------------------

namespace Francis_ABC.D365.Entities
{
	
	
	[System.Runtime.Serialization.DataContractAttribute()]
	public enum ActivityParty_InstanceTypeCode
	{
		
		[System.Runtime.Serialization.EnumMemberAttribute()]
		[OptionSetMetadataAttribute("Not Recurring", 0)]
		NotRecurring = 0,
		
		[System.Runtime.Serialization.EnumMemberAttribute()]
		[OptionSetMetadataAttribute("Recurring Exception", 3)]
		RecurringException = 3,
		
		[System.Runtime.Serialization.EnumMemberAttribute()]
		[OptionSetMetadataAttribute("Recurring Future Exception", 4)]
		RecurringFutureException = 4,
		
		[System.Runtime.Serialization.EnumMemberAttribute()]
		[OptionSetMetadataAttribute("Recurring Instance", 2)]
		RecurringInstance = 2,
		
		[System.Runtime.Serialization.EnumMemberAttribute()]
		[OptionSetMetadataAttribute("Recurring Master", 1)]
		RecurringMaster = 1,
	}
	
	[System.Runtime.Serialization.DataContractAttribute()]
	public enum ActivityParty_ParticipationTypeMask
	{
		
		[System.Runtime.Serialization.EnumMemberAttribute()]
		[OptionSetMetadataAttribute("BCC Recipient", 3)]
		BCCRecipient = 4,
		
		[System.Runtime.Serialization.EnumMemberAttribute()]
		[OptionSetMetadataAttribute("CC Recipient", 2)]
		CCRecipient = 3,
		
		[System.Runtime.Serialization.EnumMemberAttribute()]
		[OptionSetMetadataAttribute("Customer", 10)]
		Customer = 11,
		
		[System.Runtime.Serialization.EnumMemberAttribute()]
		[OptionSetMetadataAttribute("Optional attendee", 5)]
		Optionalattendee = 6,
		
		[System.Runtime.Serialization.EnumMemberAttribute()]
		[OptionSetMetadataAttribute("Organizer", 6)]
		Organizer = 7,
		
		[System.Runtime.Serialization.EnumMemberAttribute()]
		[OptionSetMetadataAttribute("Owner", 8)]
		Owner = 9,
		
		[System.Runtime.Serialization.EnumMemberAttribute()]
		[OptionSetMetadataAttribute("Regarding", 7)]
		Regarding = 8,
		
		[System.Runtime.Serialization.EnumMemberAttribute()]
		[OptionSetMetadataAttribute("Required attendee", 4)]
		Requiredattendee = 5,
		
		[System.Runtime.Serialization.EnumMemberAttribute()]
		[OptionSetMetadataAttribute("Resource", 9)]
		Resource = 10,
		
		[System.Runtime.Serialization.EnumMemberAttribute()]
		[OptionSetMetadataAttribute("Sender", 0)]
		Sender = 1,
		
		[System.Runtime.Serialization.EnumMemberAttribute()]
		[OptionSetMetadataAttribute("To Recipient", 1)]
		ToRecipient = 2,
	}
	
	[System.Runtime.Serialization.DataContractAttribute()]
	public enum activitypointer_DeliveryPriorityCode
	{
		
		[System.Runtime.Serialization.EnumMemberAttribute()]
		[OptionSetMetadataAttribute("High", 2)]
		High = 2,
		
		[System.Runtime.Serialization.EnumMemberAttribute()]
		[OptionSetMetadataAttribute("Low", 0)]
		Low = 0,
		
		[System.Runtime.Serialization.EnumMemberAttribute()]
		[OptionSetMetadataAttribute("Normal", 1)]
		Normal = 1,
	}
	
	[System.Runtime.Serialization.DataContractAttribute()]
	public enum ActivityPointer_InstanceTypeCode
	{
		
		[System.Runtime.Serialization.EnumMemberAttribute()]
		[OptionSetMetadataAttribute("Not Recurring", 0)]
		NotRecurring = 0,
		
		[System.Runtime.Serialization.EnumMemberAttribute()]
		[OptionSetMetadataAttribute("Recurring Exception", 3)]
		RecurringException = 3,
		
		[System.Runtime.Serialization.EnumMemberAttribute()]
		[OptionSetMetadataAttribute("Recurring Future Exception", 4)]
		RecurringFutureException = 4,
		
		[System.Runtime.Serialization.EnumMemberAttribute()]
		[OptionSetMetadataAttribute("Recurring Instance", 2)]
		RecurringInstance = 2,
		
		[System.Runtime.Serialization.EnumMemberAttribute()]
		[OptionSetMetadataAttribute("Recurring Master", 1)]
		RecurringMaster = 1,
	}
	
	[System.Runtime.Serialization.DataContractAttribute()]
	public enum ActivityPointer_PriorityCode
	{
		
		[System.Runtime.Serialization.EnumMemberAttribute()]
		[OptionSetMetadataAttribute("High", 2)]
		High = 2,
		
		[System.Runtime.Serialization.EnumMemberAttribute()]
		[OptionSetMetadataAttribute("Low", 0)]
		Low = 0,
		
		[System.Runtime.Serialization.EnumMemberAttribute()]
		[OptionSetMetadataAttribute("Normal", 1)]
		Normal = 1,
	}
	
	[System.Runtime.Serialization.DataContractAttribute()]
	public enum ActivityPointer_StatusCode
	{
		
		[System.Runtime.Serialization.EnumMemberAttribute()]
		[OptionSetMetadataAttribute("Canceled", 2)]
		Canceled = 3,
		
		[System.Runtime.Serialization.EnumMemberAttribute()]
		[OptionSetMetadataAttribute("Completed", 1)]
		Completed = 2,
		
		[System.Runtime.Serialization.EnumMemberAttribute()]
		[OptionSetMetadataAttribute("Open", 0)]
		Open = 1,
		
		[System.Runtime.Serialization.EnumMemberAttribute()]
		[OptionSetMetadataAttribute("Scheduled", 3)]
		Scheduled = 4,
	}
	
	[System.Runtime.Serialization.DataContractAttribute()]
	public enum ComponentState
	{
		
		[System.Runtime.Serialization.EnumMemberAttribute()]
		[OptionSetMetadataAttribute("Deleted", 2)]
		Deleted = 2,
		
		[System.Runtime.Serialization.EnumMemberAttribute()]
		[OptionSetMetadataAttribute("Deleted Unpublished", 3)]
		DeletedUnpublished = 3,
		
		[System.Runtime.Serialization.EnumMemberAttribute()]
		[OptionSetMetadataAttribute("Published", 0)]
		Published = 0,
		
		[System.Runtime.Serialization.EnumMemberAttribute()]
		[OptionSetMetadataAttribute("Unpublished", 1)]
		Unpublished = 1,
	}
	
	[System.Runtime.Serialization.DataContractAttribute()]
	public enum Contact_abc_StatusReason
	{
		
		[System.Runtime.Serialization.EnumMemberAttribute()]
		[OptionSetMetadataAttribute("Active In-Force", 0, "#0000ff")]
		ActiveInForce = 865820000,
		
		[System.Runtime.Serialization.EnumMemberAttribute()]
		[OptionSetMetadataAttribute("Inactive Cancelled", 2, "#0000ff")]
		InactiveCancelled = 865820002,
		
		[System.Runtime.Serialization.EnumMemberAttribute()]
		[OptionSetMetadataAttribute("Inactive Matured", 1, "#0000ff")]
		InactiveMatured = 865820001,
	}
	
	[System.Runtime.Serialization.DataContractAttribute()]
	public enum Contact_abc_TypeOfClient
	{
		
		[System.Runtime.Serialization.EnumMemberAttribute()]
		[OptionSetMetadataAttribute("Corporate Client.", 0, "#0000ff")]
		CorporateClient = 865820000,
		
		[System.Runtime.Serialization.EnumMemberAttribute()]
		[OptionSetMetadataAttribute("Individual Client", 1, "#0000ff")]
		IndividualClient = 865820001,
	}
	
	[System.Runtime.Serialization.DataContractAttribute()]
	public enum Contact_abc_TypeofInvestment
	{
		
		[System.Runtime.Serialization.EnumMemberAttribute()]
		[OptionSetMetadataAttribute("Local Unit Trusts", 2, "#0000ff")]
		LocalUnitTrusts = 865820002,
		
		[System.Runtime.Serialization.EnumMemberAttribute()]
		[OptionSetMetadataAttribute("Long Term Investment", 0, "#0000ff")]
		LongTermInvestment = 865820000,
		
		[System.Runtime.Serialization.EnumMemberAttribute()]
		[OptionSetMetadataAttribute("Offshore Unit Trusts", 1, "#0000ff")]
		OffshoreUnitTrusts = 865820001,
		
		[System.Runtime.Serialization.EnumMemberAttribute()]
		[OptionSetMetadataAttribute("Short Term Investment", 3, "#0000ff")]
		ShortTermInvestment = 865820003,
	}
	
	[System.Runtime.Serialization.DataContractAttribute()]
	public enum Contact_AccountRoleCode
	{
		
		[System.Runtime.Serialization.EnumMemberAttribute()]
		[OptionSetMetadataAttribute("Decision Maker", 0)]
		DecisionMaker = 1,
		
		[System.Runtime.Serialization.EnumMemberAttribute()]
		[OptionSetMetadataAttribute("Employee", 1)]
		Employee = 2,
		
		[System.Runtime.Serialization.EnumMemberAttribute()]
		[OptionSetMetadataAttribute("Influencer", 2)]
		Influencer = 3,
	}
	
	[System.Runtime.Serialization.DataContractAttribute()]
	public enum Contact_Address1_AddressTypeCode
	{
		
		[System.Runtime.Serialization.EnumMemberAttribute()]
		[OptionSetMetadataAttribute("Bill To", 0)]
		BillTo = 1,
		
		[System.Runtime.Serialization.EnumMemberAttribute()]
		[OptionSetMetadataAttribute("Other", 3)]
		Other = 4,
		
		[System.Runtime.Serialization.EnumMemberAttribute()]
		[OptionSetMetadataAttribute("Primary", 2)]
		Primary = 3,
		
		[System.Runtime.Serialization.EnumMemberAttribute()]
		[OptionSetMetadataAttribute("Ship To", 1)]
		ShipTo = 2,
	}
	
	[System.Runtime.Serialization.DataContractAttribute()]
	public enum Contact_Address1_FreightTermsCode
	{
		
		[System.Runtime.Serialization.EnumMemberAttribute()]
		[OptionSetMetadataAttribute("FOB", 0)]
		FOB = 1,
		
		[System.Runtime.Serialization.EnumMemberAttribute()]
		[OptionSetMetadataAttribute("No Charge", 1)]
		NoCharge = 2,
	}
	
	[System.Runtime.Serialization.DataContractAttribute()]
	public enum Contact_Address1_ShippingMethodCode
	{
		
		[System.Runtime.Serialization.EnumMemberAttribute()]
		[OptionSetMetadataAttribute("Airborne", 0)]
		Airborne = 1,
		
		[System.Runtime.Serialization.EnumMemberAttribute()]
		[OptionSetMetadataAttribute("DHL", 1)]
		DHL = 2,
		
		[System.Runtime.Serialization.EnumMemberAttribute()]
		[OptionSetMetadataAttribute("FedEx", 2)]
		FedEx = 3,
		
		[System.Runtime.Serialization.EnumMemberAttribute()]
		[OptionSetMetadataAttribute("Full Load", 5)]
		FullLoad = 6,
		
		[System.Runtime.Serialization.EnumMemberAttribute()]
		[OptionSetMetadataAttribute("Postal Mail", 4)]
		PostalMail = 5,
		
		[System.Runtime.Serialization.EnumMemberAttribute()]
		[OptionSetMetadataAttribute("UPS", 3)]
		UPS = 4,
		
		[System.Runtime.Serialization.EnumMemberAttribute()]
		[OptionSetMetadataAttribute("Will Call", 6)]
		WillCall = 7,
	}
	
	[System.Runtime.Serialization.DataContractAttribute()]
	public enum Contact_Address2_AddressTypeCode
	{
		
		[System.Runtime.Serialization.EnumMemberAttribute()]
		[OptionSetMetadataAttribute("Default Value", 0)]
		DefaultValue = 1,
	}
	
	[System.Runtime.Serialization.DataContractAttribute()]
	public enum Contact_Address2_FreightTermsCode
	{
		
		[System.Runtime.Serialization.EnumMemberAttribute()]
		[OptionSetMetadataAttribute("Default Value", 0)]
		DefaultValue = 1,
	}
	
	[System.Runtime.Serialization.DataContractAttribute()]
	public enum Contact_Address2_ShippingMethodCode
	{
		
		[System.Runtime.Serialization.EnumMemberAttribute()]
		[OptionSetMetadataAttribute("Default Value", 0)]
		DefaultValue = 1,
	}
	
	[System.Runtime.Serialization.DataContractAttribute()]
	public enum Contact_Address3_AddressTypeCode
	{
		
		[System.Runtime.Serialization.EnumMemberAttribute()]
		[OptionSetMetadataAttribute("Default Value", 0)]
		DefaultValue = 1,
	}
	
	[System.Runtime.Serialization.DataContractAttribute()]
	public enum Contact_Address3_FreightTermsCode
	{
		
		[System.Runtime.Serialization.EnumMemberAttribute()]
		[OptionSetMetadataAttribute("Default Value", 0)]
		DefaultValue = 1,
	}
	
	[System.Runtime.Serialization.DataContractAttribute()]
	public enum Contact_Address3_ShippingMethodCode
	{
		
		[System.Runtime.Serialization.EnumMemberAttribute()]
		[OptionSetMetadataAttribute("Default Value", 0)]
		DefaultValue = 1,
	}
	
	[System.Runtime.Serialization.DataContractAttribute()]
	public enum Contact_CustomerSizeCode
	{
		
		[System.Runtime.Serialization.EnumMemberAttribute()]
		[OptionSetMetadataAttribute("Default Value", 0)]
		DefaultValue = 1,
	}
	
	[System.Runtime.Serialization.DataContractAttribute()]
	public enum Contact_CustomerTypeCode
	{
		
		[System.Runtime.Serialization.EnumMemberAttribute()]
		[OptionSetMetadataAttribute("Default Value", 0)]
		DefaultValue = 1,
	}
	
	[System.Runtime.Serialization.DataContractAttribute()]
	public enum Contact_EducationCode
	{
		
		[System.Runtime.Serialization.EnumMemberAttribute()]
		[OptionSetMetadataAttribute("Default Value", 0)]
		DefaultValue = 1,
	}
	
	[System.Runtime.Serialization.DataContractAttribute()]
	public enum Contact_FamilyStatusCode
	{
		
		[System.Runtime.Serialization.EnumMemberAttribute()]
		[OptionSetMetadataAttribute("Divorced", 2)]
		Divorced = 3,
		
		[System.Runtime.Serialization.EnumMemberAttribute()]
		[OptionSetMetadataAttribute("Married", 1)]
		Married = 2,
		
		[System.Runtime.Serialization.EnumMemberAttribute()]
		[OptionSetMetadataAttribute("Single", 0)]
		Single = 1,
		
		[System.Runtime.Serialization.EnumMemberAttribute()]
		[OptionSetMetadataAttribute("Widowed", 3)]
		Widowed = 4,
	}
	
	[System.Runtime.Serialization.DataContractAttribute()]
	public enum Contact_GenderCode
	{
		
		[System.Runtime.Serialization.EnumMemberAttribute()]
		[OptionSetMetadataAttribute("Female", 1)]
		Female = 2,
		
		[System.Runtime.Serialization.EnumMemberAttribute()]
		[OptionSetMetadataAttribute("Male", 0)]
		Male = 1,
	}
	
	[System.Runtime.Serialization.DataContractAttribute()]
	public enum Contact_HasChildrenCode
	{
		
		[System.Runtime.Serialization.EnumMemberAttribute()]
		[OptionSetMetadataAttribute("Default Value", 0)]
		DefaultValue = 1,
	}
	
	[System.Runtime.Serialization.DataContractAttribute()]
	public enum Contact_LeadSourceCode
	{
		
		[System.Runtime.Serialization.EnumMemberAttribute()]
		[OptionSetMetadataAttribute("Default Value", 0)]
		DefaultValue = 1,
	}
	
	[System.Runtime.Serialization.DataContractAttribute()]
	public enum Contact_msdyn_orgchangestatus
	{
		
		[System.Runtime.Serialization.EnumMemberAttribute()]
		[OptionSetMetadataAttribute("Ignore", 2, "#0000ff")]
		Ignore = 2,
		
		[System.Runtime.Serialization.EnumMemberAttribute()]
		[OptionSetMetadataAttribute("No Feedback", 0, "#0000ff")]
		NoFeedback = 0,
		
		[System.Runtime.Serialization.EnumMemberAttribute()]
		[OptionSetMetadataAttribute("Not at Company", 1, "#0000ff")]
		NotatCompany = 1,
	}
	
	[System.Runtime.Serialization.DataContractAttribute()]
	public enum Contact_PaymentTermsCode
	{
		
		[System.Runtime.Serialization.EnumMemberAttribute()]
		[OptionSetMetadataAttribute("2% 10, Net 30", 1)]
		_210Net30 = 2,
		
		[System.Runtime.Serialization.EnumMemberAttribute()]
		[OptionSetMetadataAttribute("Net 30", 0)]
		Net30 = 1,
		
		[System.Runtime.Serialization.EnumMemberAttribute()]
		[OptionSetMetadataAttribute("Net 45", 2)]
		Net45 = 3,
		
		[System.Runtime.Serialization.EnumMemberAttribute()]
		[OptionSetMetadataAttribute("Net 60", 3)]
		Net60 = 4,
	}
	
	[System.Runtime.Serialization.DataContractAttribute()]
	public enum Contact_PreferredAppointmentDayCode
	{
		
		[System.Runtime.Serialization.EnumMemberAttribute()]
		[OptionSetMetadataAttribute("Friday", 5)]
		Friday = 5,
		
		[System.Runtime.Serialization.EnumMemberAttribute()]
		[OptionSetMetadataAttribute("Monday", 1)]
		Monday = 1,
		
		[System.Runtime.Serialization.EnumMemberAttribute()]
		[OptionSetMetadataAttribute("Saturday", 6)]
		Saturday = 6,
		
		[System.Runtime.Serialization.EnumMemberAttribute()]
		[OptionSetMetadataAttribute("Sunday", 0)]
		Sunday = 0,
		
		[System.Runtime.Serialization.EnumMemberAttribute()]
		[OptionSetMetadataAttribute("Thursday", 4)]
		Thursday = 4,
		
		[System.Runtime.Serialization.EnumMemberAttribute()]
		[OptionSetMetadataAttribute("Tuesday", 2)]
		Tuesday = 2,
		
		[System.Runtime.Serialization.EnumMemberAttribute()]
		[OptionSetMetadataAttribute("Wednesday", 3)]
		Wednesday = 3,
	}
	
	[System.Runtime.Serialization.DataContractAttribute()]
	public enum Contact_PreferredAppointmentTimeCode
	{
		
		[System.Runtime.Serialization.EnumMemberAttribute()]
		[OptionSetMetadataAttribute("Afternoon", 1)]
		Afternoon = 2,
		
		[System.Runtime.Serialization.EnumMemberAttribute()]
		[OptionSetMetadataAttribute("Evening", 2)]
		Evening = 3,
		
		[System.Runtime.Serialization.EnumMemberAttribute()]
		[OptionSetMetadataAttribute("Morning", 0)]
		Morning = 1,
	}
	
	[System.Runtime.Serialization.DataContractAttribute()]
	public enum Contact_PreferredContactMethodCode
	{
		
		[System.Runtime.Serialization.EnumMemberAttribute()]
		[OptionSetMetadataAttribute("Any", 0)]
		Any = 1,
		
		[System.Runtime.Serialization.EnumMemberAttribute()]
		[OptionSetMetadataAttribute("Email", 1)]
		Email = 2,
		
		[System.Runtime.Serialization.EnumMemberAttribute()]
		[OptionSetMetadataAttribute("Fax", 3)]
		Fax = 4,
		
		[System.Runtime.Serialization.EnumMemberAttribute()]
		[OptionSetMetadataAttribute("Mail", 4)]
		Mail = 5,
		
		[System.Runtime.Serialization.EnumMemberAttribute()]
		[OptionSetMetadataAttribute("Phone", 2)]
		Phone = 3,
	}
	
	[System.Runtime.Serialization.DataContractAttribute()]
	public enum Contact_ShippingMethodCode
	{
		
		[System.Runtime.Serialization.EnumMemberAttribute()]
		[OptionSetMetadataAttribute("Default Value", 0)]
		DefaultValue = 1,
	}
	
	[System.Runtime.Serialization.DataContractAttribute()]
	public enum Contact_StatusCode
	{
		
		[System.Runtime.Serialization.EnumMemberAttribute()]
		[OptionSetMetadataAttribute("Active", 0)]
		Active = 1,
		
		[System.Runtime.Serialization.EnumMemberAttribute()]
		[OptionSetMetadataAttribute("Inactive", 1)]
		Inactive = 2,
	}
	
	[System.Runtime.Serialization.DataContractAttribute()]
	public enum Contact_TerritoryCode
	{
		
		[System.Runtime.Serialization.EnumMemberAttribute()]
		[OptionSetMetadataAttribute("Default Value", 0)]
		DefaultValue = 1,
	}
	
	[System.Runtime.Serialization.DataContractAttribute()]
	public enum Email_CorrelationMethod
	{
		
		[System.Runtime.Serialization.EnumMemberAttribute()]
		[OptionSetMetadataAttribute("ConversationIndex", 5)]
		ConversationIndex = 5,
		
		[System.Runtime.Serialization.EnumMemberAttribute()]
		[OptionSetMetadataAttribute("CustomCorrelation", 7)]
		CustomCorrelation = 7,
		
		[System.Runtime.Serialization.EnumMemberAttribute()]
		[OptionSetMetadataAttribute("InReplyTo", 3)]
		InReplyTo = 3,
		
		[System.Runtime.Serialization.EnumMemberAttribute()]
		[OptionSetMetadataAttribute("None", 0)]
		None = 0,
		
		[System.Runtime.Serialization.EnumMemberAttribute()]
		[OptionSetMetadataAttribute("Skipped", 1)]
		Skipped = 1,
		
		[System.Runtime.Serialization.EnumMemberAttribute()]
		[OptionSetMetadataAttribute("SmartMatching", 6)]
		SmartMatching = 6,
		
		[System.Runtime.Serialization.EnumMemberAttribute()]
		[OptionSetMetadataAttribute("TrackingToken", 4)]
		TrackingToken = 4,
		
		[System.Runtime.Serialization.EnumMemberAttribute()]
		[OptionSetMetadataAttribute("XHeader", 2)]
		XHeader = 2,
	}
	
	[System.Runtime.Serialization.DataContractAttribute()]
	public enum Email_EmailReminderStatus
	{
		
		[System.Runtime.Serialization.EnumMemberAttribute()]
		[OptionSetMetadataAttribute("NotSet", 0)]
		NotSet = 0,
		
		[System.Runtime.Serialization.EnumMemberAttribute()]
		[OptionSetMetadataAttribute("ReminderExpired", 2)]
		ReminderExpired = 2,
		
		[System.Runtime.Serialization.EnumMemberAttribute()]
		[OptionSetMetadataAttribute("ReminderInvalid", 3)]
		ReminderInvalid = 3,
		
		[System.Runtime.Serialization.EnumMemberAttribute()]
		[OptionSetMetadataAttribute("ReminderSet", 1)]
		ReminderSet = 1,
	}
	
	[System.Runtime.Serialization.DataContractAttribute()]
	public enum Email_EmailReminderType
	{
		
		[System.Runtime.Serialization.EnumMemberAttribute()]
		[OptionSetMetadataAttribute("If I do not receive a reply by", 0)]
		IfIdonotreceiveareplyby = 0,
		
		[System.Runtime.Serialization.EnumMemberAttribute()]
		[OptionSetMetadataAttribute("If the email is not opened by", 1)]
		Iftheemailisnotopenedby = 1,
		
		[System.Runtime.Serialization.EnumMemberAttribute()]
		[OptionSetMetadataAttribute("Remind me anyways at", 2)]
		Remindmeanywaysat = 2,
	}
	
	[System.Runtime.Serialization.DataContractAttribute()]
	public enum Email_Notifications
	{
		
		[System.Runtime.Serialization.EnumMemberAttribute()]
		[OptionSetMetadataAttribute("None", 0)]
		None = 0,
		
		[System.Runtime.Serialization.EnumMemberAttribute()]
		[OptionSetMetadataAttribute("The message was saved as a Microsoft Dynamics 365 email record, but not all the a" +
			"ttachments could be saved with it. An attachment cannot be saved if it is blocke" +
			"d or if its file type is invalid.", 1)]
		ThemessagewassavedasaMicrosoftDynamics365emailrecordbutnotalltheattachmentscouldbesavedwithitAnattachmentcannotbesavedifitisblockedorifitsfiletypeisinvalid = 1,
		
		[System.Runtime.Serialization.EnumMemberAttribute()]
		[OptionSetMetadataAttribute("Truncated body.", 2)]
		Truncatedbody = 2,
	}
	
	[System.Runtime.Serialization.DataContractAttribute()]
	public enum Email_PriorityCode
	{
		
		[System.Runtime.Serialization.EnumMemberAttribute()]
		[OptionSetMetadataAttribute("High", 2)]
		High = 2,
		
		[System.Runtime.Serialization.EnumMemberAttribute()]
		[OptionSetMetadataAttribute("Low", 0)]
		Low = 0,
		
		[System.Runtime.Serialization.EnumMemberAttribute()]
		[OptionSetMetadataAttribute("Normal", 1)]
		Normal = 1,
	}
	
	[System.Runtime.Serialization.DataContractAttribute()]
	public enum Email_StatusCode
	{
		
		[System.Runtime.Serialization.EnumMemberAttribute()]
		[OptionSetMetadataAttribute("Canceled", 4, "#666666")]
		Canceled = 5,
		
		[System.Runtime.Serialization.EnumMemberAttribute()]
		[OptionSetMetadataAttribute("Completed", 1, "#358717")]
		Completed = 2,
		
		[System.Runtime.Serialization.EnumMemberAttribute()]
		[OptionSetMetadataAttribute("Draft", 0, "#3b79b7")]
		Draft = 1,
		
		[System.Runtime.Serialization.EnumMemberAttribute()]
		[OptionSetMetadataAttribute("Failed", 7, "#ea0600")]
		Failed = 8,
		
		[System.Runtime.Serialization.EnumMemberAttribute()]
		[OptionSetMetadataAttribute("Pending Send", 5, "#bf991f")]
		PendingSend = 6,
		
		[System.Runtime.Serialization.EnumMemberAttribute()]
		[OptionSetMetadataAttribute("Received", 3, "#358717")]
		Received = 4,
		
		[System.Runtime.Serialization.EnumMemberAttribute()]
		[OptionSetMetadataAttribute("Sending", 6, "#bf991f")]
		Sending = 7,
		
		[System.Runtime.Serialization.EnumMemberAttribute()]
		[OptionSetMetadataAttribute("Sent", 2, "#358717")]
		Sent = 3,
	}
	
	[System.Runtime.Serialization.DataContractAttribute()]
	public enum IsInherited
	{
		
		[System.Runtime.Serialization.EnumMemberAttribute()]
		[OptionSetMetadataAttribute("Direct User (Basic) access level and Team privileges", 1)]
		DirectUser_BasicaccesslevelandTeamprivileges = 1,
		
		[System.Runtime.Serialization.EnumMemberAttribute()]
		[OptionSetMetadataAttribute("Team privileges only", 0)]
		Teamprivilegesonly = 0,
	}
	
	[System.Runtime.Serialization.DataContractAttribute()]
	public enum SocialProfile_Community
	{
		
		[System.Runtime.Serialization.EnumMemberAttribute()]
		[OptionSetMetadataAttribute("Cortana", 0, "#0000ff")]
		Cortana = 5,
		
		[System.Runtime.Serialization.EnumMemberAttribute()]
		[OptionSetMetadataAttribute("Direct Line", 1, "#0000ff")]
		DirectLine = 6,
		
		[System.Runtime.Serialization.EnumMemberAttribute()]
		[OptionSetMetadataAttribute("Direct Line Speech", 3, "#0000ff")]
		DirectLineSpeech = 8,
		
		[System.Runtime.Serialization.EnumMemberAttribute()]
		[OptionSetMetadataAttribute("Email", 4, "#0000ff")]
		Email = 9,
		
		[System.Runtime.Serialization.EnumMemberAttribute()]
		[OptionSetMetadataAttribute("Facebook", 13, "", "Facebook item.")]
		Facebook = 1,
		
		[System.Runtime.Serialization.EnumMemberAttribute()]
		[OptionSetMetadataAttribute("GroupMe", 5, "#0000ff")]
		GroupMe = 10,
		
		[System.Runtime.Serialization.EnumMemberAttribute()]
		[OptionSetMetadataAttribute("Kik", 6, "#0000ff")]
		Kik = 11,
		
		[System.Runtime.Serialization.EnumMemberAttribute()]
		[OptionSetMetadataAttribute("Line", 11, "#0000ff")]
		Line = 3,
		
		[System.Runtime.Serialization.EnumMemberAttribute()]
		[OptionSetMetadataAttribute("Microsoft Teams", 2, "#0000ff")]
		MicrosoftTeams = 7,
		
		[System.Runtime.Serialization.EnumMemberAttribute()]
		[OptionSetMetadataAttribute("Other", 15, "", "Other default")]
		Other = 0,
		
		[System.Runtime.Serialization.EnumMemberAttribute()]
		[OptionSetMetadataAttribute("Skype", 8, "#0000ff")]
		Skype = 13,
		
		[System.Runtime.Serialization.EnumMemberAttribute()]
		[OptionSetMetadataAttribute("Slack", 9, "#0000ff")]
		Slack = 14,
		
		[System.Runtime.Serialization.EnumMemberAttribute()]
		[OptionSetMetadataAttribute("Telegram", 7, "#0000ff")]
		Telegram = 12,
		
		[System.Runtime.Serialization.EnumMemberAttribute()]
		[OptionSetMetadataAttribute("Twitter", 14, "", "Twitter.")]
		Twitter = 2,
		
		[System.Runtime.Serialization.EnumMemberAttribute()]
		[OptionSetMetadataAttribute("Wechat", 12, "#0000ff")]
		Wechat = 4,
		
		[System.Runtime.Serialization.EnumMemberAttribute()]
		[OptionSetMetadataAttribute("WhatsApp", 10, "#0000ff")]
		WhatsApp = 15,
	}
	
	[System.Runtime.Serialization.DataContractAttribute()]
	public enum SystemUser_AccessMode
	{
		
		[System.Runtime.Serialization.EnumMemberAttribute()]
		[OptionSetMetadataAttribute("Administrative", 1)]
		Administrative = 1,
		
		[System.Runtime.Serialization.EnumMemberAttribute()]
		[OptionSetMetadataAttribute("Delegated Admin", 5)]
		DelegatedAdmin = 5,
		
		[System.Runtime.Serialization.EnumMemberAttribute()]
		[OptionSetMetadataAttribute("Non-interactive", 4)]
		Noninteractive = 4,
		
		[System.Runtime.Serialization.EnumMemberAttribute()]
		[OptionSetMetadataAttribute("Read", 2)]
		Read = 2,
		
		[System.Runtime.Serialization.EnumMemberAttribute()]
		[OptionSetMetadataAttribute("Read-Write", 0)]
		ReadWrite = 0,
		
		[System.Runtime.Serialization.EnumMemberAttribute()]
		[OptionSetMetadataAttribute("Support User", 3)]
		SupportUser = 3,
	}
	
	[System.Runtime.Serialization.DataContractAttribute()]
	public enum SystemUser_Address1_AddressTypeCode
	{
		
		[System.Runtime.Serialization.EnumMemberAttribute()]
		[OptionSetMetadataAttribute("Default Value", 0)]
		DefaultValue = 1,
	}
	
	[System.Runtime.Serialization.DataContractAttribute()]
	public enum SystemUser_Address1_ShippingMethodCode
	{
		
		[System.Runtime.Serialization.EnumMemberAttribute()]
		[OptionSetMetadataAttribute("Default Value", 0)]
		DefaultValue = 1,
	}
	
	[System.Runtime.Serialization.DataContractAttribute()]
	public enum SystemUser_Address2_AddressTypeCode
	{
		
		[System.Runtime.Serialization.EnumMemberAttribute()]
		[OptionSetMetadataAttribute("Default Value", 0)]
		DefaultValue = 1,
	}
	
	[System.Runtime.Serialization.DataContractAttribute()]
	public enum SystemUser_Address2_ShippingMethodCode
	{
		
		[System.Runtime.Serialization.EnumMemberAttribute()]
		[OptionSetMetadataAttribute("Default Value", 0)]
		DefaultValue = 1,
	}
	
	[System.Runtime.Serialization.DataContractAttribute()]
	public enum SystemUser_CALType
	{
		
		[System.Runtime.Serialization.EnumMemberAttribute()]
		[OptionSetMetadataAttribute("Administrative", 1)]
		Administrative = 1,
		
		[System.Runtime.Serialization.EnumMemberAttribute()]
		[OptionSetMetadataAttribute("Basic", 2)]
		Basic = 2,
		
		[System.Runtime.Serialization.EnumMemberAttribute()]
		[OptionSetMetadataAttribute("Device Basic", 4)]
		DeviceBasic = 4,
		
		[System.Runtime.Serialization.EnumMemberAttribute()]
		[OptionSetMetadataAttribute("Device Enterprise", 8)]
		DeviceEnterprise = 8,
		
		[System.Runtime.Serialization.EnumMemberAttribute()]
		[OptionSetMetadataAttribute("Device Essential", 6)]
		DeviceEssential = 6,
		
		[System.Runtime.Serialization.EnumMemberAttribute()]
		[OptionSetMetadataAttribute("Device Professional", 3)]
		DeviceProfessional = 3,
		
		[System.Runtime.Serialization.EnumMemberAttribute()]
		[OptionSetMetadataAttribute("Enterprise", 7)]
		Enterprise = 7,
		
		[System.Runtime.Serialization.EnumMemberAttribute()]
		[OptionSetMetadataAttribute("Essential", 5)]
		Essential = 5,
		
		[System.Runtime.Serialization.EnumMemberAttribute()]
		[OptionSetMetadataAttribute("Field Service", 11)]
		FieldService = 11,
		
		[System.Runtime.Serialization.EnumMemberAttribute()]
		[OptionSetMetadataAttribute("Professional", 0)]
		Professional = 0,
		
		[System.Runtime.Serialization.EnumMemberAttribute()]
		[OptionSetMetadataAttribute("Project Service", 12)]
		ProjectService = 12,
		
		[System.Runtime.Serialization.EnumMemberAttribute()]
		[OptionSetMetadataAttribute("Sales", 9)]
		Sales = 9,
		
		[System.Runtime.Serialization.EnumMemberAttribute()]
		[OptionSetMetadataAttribute("Service", 10)]
		Service = 10,
	}
	
	[System.Runtime.Serialization.DataContractAttribute()]
	public enum SystemUser_EmailRouterAccessApproval
	{
		
		[System.Runtime.Serialization.EnumMemberAttribute()]
		[OptionSetMetadataAttribute("Approved", 1)]
		Approved = 1,
		
		[System.Runtime.Serialization.EnumMemberAttribute()]
		[OptionSetMetadataAttribute("Empty", 0)]
		Empty = 0,
		
		[System.Runtime.Serialization.EnumMemberAttribute()]
		[OptionSetMetadataAttribute("Pending Approval", 2)]
		PendingApproval = 2,
		
		[System.Runtime.Serialization.EnumMemberAttribute()]
		[OptionSetMetadataAttribute("Rejected", 3)]
		Rejected = 3,
	}
	
	[System.Runtime.Serialization.DataContractAttribute()]
	public enum SystemUser_IncomingEmailDeliveryMethod
	{
		
		[System.Runtime.Serialization.EnumMemberAttribute()]
		[OptionSetMetadataAttribute("Forward Mailbox", 3)]
		ForwardMailbox = 3,
		
		[System.Runtime.Serialization.EnumMemberAttribute()]
		[OptionSetMetadataAttribute("Microsoft Dynamics 365 for Outlook", 1)]
		MicrosoftDynamics365forOutlook = 1,
		
		[System.Runtime.Serialization.EnumMemberAttribute()]
		[OptionSetMetadataAttribute("None", 0)]
		None = 0,
		
		[System.Runtime.Serialization.EnumMemberAttribute()]
		[OptionSetMetadataAttribute("Server-Side Synchronization or Email Router", 2)]
		ServerSideSynchronizationorEmailRouter = 2,
	}
	
	[System.Runtime.Serialization.DataContractAttribute()]
	public enum SystemUser_InviteStatusCode
	{
		
		[System.Runtime.Serialization.EnumMemberAttribute()]
		[OptionSetMetadataAttribute("Invitation Accepted", 4)]
		InvitationAccepted = 4,
		
		[System.Runtime.Serialization.EnumMemberAttribute()]
		[OptionSetMetadataAttribute("Invitation Expired", 3)]
		InvitationExpired = 3,
		
		[System.Runtime.Serialization.EnumMemberAttribute()]
		[OptionSetMetadataAttribute("Invitation Near Expired", 2)]
		InvitationNearExpired = 2,
		
		[System.Runtime.Serialization.EnumMemberAttribute()]
		[OptionSetMetadataAttribute("Invitation Not Sent", 0)]
		InvitationNotSent = 0,
		
		[System.Runtime.Serialization.EnumMemberAttribute()]
		[OptionSetMetadataAttribute("Invitation Rejected", 5)]
		InvitationRejected = 5,
		
		[System.Runtime.Serialization.EnumMemberAttribute()]
		[OptionSetMetadataAttribute("Invitation Revoked", 6)]
		InvitationRevoked = 6,
		
		[System.Runtime.Serialization.EnumMemberAttribute()]
		[OptionSetMetadataAttribute("Invited", 1)]
		Invited = 1,
	}
	
	[System.Runtime.Serialization.DataContractAttribute()]
	public enum SystemUser_msdyn_AgentType
	{
		
		[System.Runtime.Serialization.EnumMemberAttribute()]
		[OptionSetMetadataAttribute("Application user", 0, "#0000ff")]
		Applicationuser = 192350000,
		
		[System.Runtime.Serialization.EnumMemberAttribute()]
		[OptionSetMetadataAttribute("Bot application user", 1, "#0000ff")]
		Botapplicationuser = 192350001,
	}
	
	[System.Runtime.Serialization.DataContractAttribute()]
	public enum SystemUser_msdyn_BotProvider
	{
		
		[System.Runtime.Serialization.EnumMemberAttribute()]
		[OptionSetMetadataAttribute("None", 2, "#0000ff", "Indicates that the user is not a bot")]
		None = 192350002,
		
		[System.Runtime.Serialization.EnumMemberAttribute()]
		[OptionSetMetadataAttribute("Other", 1, "#0000ff", "Other type of bot")]
		Other = 192350001,
		
		[System.Runtime.Serialization.EnumMemberAttribute()]
		[OptionSetMetadataAttribute("Virtual Agent", 0, "#0000ff", "CCI first party Bot")]
		VirtualAgent = 192350000,
	}
	
	[System.Runtime.Serialization.DataContractAttribute()]
	public enum SystemUser_msdyn_UserType
	{
		
		[System.Runtime.Serialization.EnumMemberAttribute()]
		[OptionSetMetadataAttribute("BOT User", 1, "#0000ff")]
		BOTUser = 192350001,
		
		[System.Runtime.Serialization.EnumMemberAttribute()]
		[OptionSetMetadataAttribute("CRM User", 0, "#0000ff")]
		CRMUser = 192350000,
	}
	
	[System.Runtime.Serialization.DataContractAttribute()]
	public enum SystemUser_OutgoingEmailDeliveryMethod
	{
		
		[System.Runtime.Serialization.EnumMemberAttribute()]
		[OptionSetMetadataAttribute("Microsoft Dynamics 365 for Outlook", 1)]
		MicrosoftDynamics365forOutlook = 1,
		
		[System.Runtime.Serialization.EnumMemberAttribute()]
		[OptionSetMetadataAttribute("None", 0)]
		None = 0,
		
		[System.Runtime.Serialization.EnumMemberAttribute()]
		[OptionSetMetadataAttribute("Server-Side Synchronization or Email Router", 2)]
		ServerSideSynchronizationorEmailRouter = 2,
	}
	
	[System.Runtime.Serialization.DataContractAttribute()]
	public enum SystemUser_PreferredAddressCode
	{
		
		[System.Runtime.Serialization.EnumMemberAttribute()]
		[OptionSetMetadataAttribute("Mailing Address", 0)]
		MailingAddress = 1,
		
		[System.Runtime.Serialization.EnumMemberAttribute()]
		[OptionSetMetadataAttribute("Other Address", 1)]
		OtherAddress = 2,
	}
	
	[System.Runtime.Serialization.DataContractAttribute()]
	public enum SystemUser_PreferredEmailCode
	{
		
		[System.Runtime.Serialization.EnumMemberAttribute()]
		[OptionSetMetadataAttribute("Default Value", 0)]
		DefaultValue = 1,
	}
	
	[System.Runtime.Serialization.DataContractAttribute()]
	public enum SystemUser_PreferredPhoneCode
	{
		
		[System.Runtime.Serialization.EnumMemberAttribute()]
		[OptionSetMetadataAttribute("Home Phone", 2)]
		HomePhone = 3,
		
		[System.Runtime.Serialization.EnumMemberAttribute()]
		[OptionSetMetadataAttribute("Main Phone", 0)]
		MainPhone = 1,
		
		[System.Runtime.Serialization.EnumMemberAttribute()]
		[OptionSetMetadataAttribute("Mobile Phone", 3)]
		MobilePhone = 4,
		
		[System.Runtime.Serialization.EnumMemberAttribute()]
		[OptionSetMetadataAttribute("Other Phone", 1)]
		OtherPhone = 2,
	}
	
	[System.Runtime.Serialization.DataContractAttribute()]
	public enum Task_PriorityCode
	{
		
		[System.Runtime.Serialization.EnumMemberAttribute()]
		[OptionSetMetadataAttribute("High", 2)]
		High = 2,
		
		[System.Runtime.Serialization.EnumMemberAttribute()]
		[OptionSetMetadataAttribute("Low", 0)]
		Low = 0,
		
		[System.Runtime.Serialization.EnumMemberAttribute()]
		[OptionSetMetadataAttribute("Normal", 1)]
		Normal = 1,
	}
	
	[System.Runtime.Serialization.DataContractAttribute()]
	public enum Task_StatusCode
	{
		
		[System.Runtime.Serialization.EnumMemberAttribute()]
		[OptionSetMetadataAttribute("Canceled", 4)]
		Canceled = 6,
		
		[System.Runtime.Serialization.EnumMemberAttribute()]
		[OptionSetMetadataAttribute("Completed", 3)]
		Completed = 5,
		
		[System.Runtime.Serialization.EnumMemberAttribute()]
		[OptionSetMetadataAttribute("Deferred", 5)]
		Deferred = 7,
		
		[System.Runtime.Serialization.EnumMemberAttribute()]
		[OptionSetMetadataAttribute("In Progress", 1)]
		InProgress = 3,
		
		[System.Runtime.Serialization.EnumMemberAttribute()]
		[OptionSetMetadataAttribute("Not Started", 0)]
		NotStarted = 2,
		
		[System.Runtime.Serialization.EnumMemberAttribute()]
		[OptionSetMetadataAttribute("Waiting on someone else", 2)]
		Waitingonsomeoneelse = 4,
	}
	
	[System.Runtime.Serialization.DataContractAttribute()]
	public enum Team_MembershipType
	{
		
		[System.Runtime.Serialization.EnumMemberAttribute()]
		[OptionSetMetadataAttribute("Guests", 3)]
		Guests = 3,
		
		[System.Runtime.Serialization.EnumMemberAttribute()]
		[OptionSetMetadataAttribute("Members", 1)]
		Members = 1,
		
		[System.Runtime.Serialization.EnumMemberAttribute()]
		[OptionSetMetadataAttribute("Members and guests", 0)]
		Membersandguests = 0,
		
		[System.Runtime.Serialization.EnumMemberAttribute()]
		[OptionSetMetadataAttribute("Owners", 2)]
		Owners = 2,
	}
	
	[System.Runtime.Serialization.DataContractAttribute()]
	public enum Team_TeamType
	{
		
		[System.Runtime.Serialization.EnumMemberAttribute()]
		[OptionSetMetadataAttribute("AAD Office Group", 3)]
		AADOfficeGroup = 3,
		
		[System.Runtime.Serialization.EnumMemberAttribute()]
		[OptionSetMetadataAttribute("AAD Security Group", 2)]
		AADSecurityGroup = 2,
		
		[System.Runtime.Serialization.EnumMemberAttribute()]
		[OptionSetMetadataAttribute("Access", 1)]
		Access = 1,
		
		[System.Runtime.Serialization.EnumMemberAttribute()]
		[OptionSetMetadataAttribute("Owner", 0)]
		Owner = 0,
	}
	
	[System.Runtime.Serialization.DataContractAttribute()]
	public enum msdyn_msdyn_requirementrelationship_msdyn_resourcegroupings
	{
		
		[System.Runtime.Serialization.EnumMemberAttribute()]
		[OptionSetMetadataAttribute("Organizational Unit", 0, "#0000ff")]
		OrganizationalUnit = 192350000,
		
		[System.Runtime.Serialization.EnumMemberAttribute()]
		[OptionSetMetadataAttribute("Related Resource Pools", 1, "#0000ff")]
		RelatedResourcePools = 192350001,
		
		[System.Runtime.Serialization.EnumMemberAttribute()]
		[OptionSetMetadataAttribute("Location", 2, "#0000ff")]
		Location = 192350002,
	}
	
	[System.Runtime.Serialization.DataContractAttribute()]
	public enum msdyn_oc_daysofweek
	{
		
		[System.Runtime.Serialization.EnumMemberAttribute()]
		[OptionSetMetadataAttribute("Sun", 0, "#0000ff", "Sunday")]
		Sun = 192350000,
		
		[System.Runtime.Serialization.EnumMemberAttribute()]
		[OptionSetMetadataAttribute("Mon", 1, "#0000ff", "Monday")]
		Mon = 192350001,
		
		[System.Runtime.Serialization.EnumMemberAttribute()]
		[OptionSetMetadataAttribute("Tue", 2, "#0000ff", "Tuesday")]
		Tue = 192350002,
		
		[System.Runtime.Serialization.EnumMemberAttribute()]
		[OptionSetMetadataAttribute("Wed", 3, "#0000ff", "Wednesday")]
		Wed = 192350003,
		
		[System.Runtime.Serialization.EnumMemberAttribute()]
		[OptionSetMetadataAttribute("Thu", 4, "#0000ff", "Thursday")]
		Thu = 192350004,
		
		[System.Runtime.Serialization.EnumMemberAttribute()]
		[OptionSetMetadataAttribute("Fri", 5, "#0000ff", "Friday")]
		Fri = 192350005,
		
		[System.Runtime.Serialization.EnumMemberAttribute()]
		[OptionSetMetadataAttribute("Sat", 6, "#0000ff", "Saturday")]
		Sat = 192350006,
	}
}
