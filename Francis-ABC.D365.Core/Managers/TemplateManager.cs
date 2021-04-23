namespace Francis_ABC.D365.Core.Managers
{
  namespace BES.D365.Core.Managers
  {
    using System;
    using System.Collections.Concurrent;
    using System.Collections.Generic;
    using System.Linq;
    using Francis_ABC.D365.Entities;
    using Microsoft.Crm.Sdk.Messages;
    using Microsoft.Xrm.Sdk;
    using Microsoft.Xrm.Sdk.Query;

    /// <summary>
    /// The TemplateManager class
    /// </summary>
    public sealed class TemplateManager
    {
      /// <summary>
      /// The number of minutes the cache is valid for
      /// </summary>
      private const int CacheValidMinutes = 5;

      /// <summary>
      /// The object used to lock the template manager on a thread
      /// </summary>
      private static readonly object LockTemplateCache = new object();

      /// <summary>
      /// Prevents a default instance of the <see cref="TemplateManager"/> class from being created.
      /// </summary>
      private TemplateManager()
      {
      }

      /// <summary>
      /// Gets the template cache
      /// </summary>
      private static ConcurrentDictionary<Guid, Template> TemplateCache { get; } = new ConcurrentDictionary<Guid, Template>();

      /// <summary>
      /// Gets or sets the time when the template cache expires
      /// </summary>
      private static DateTime? TemplateCacheExpiry { get; set; } = DateTime.Now.AddMinutes(CacheValidMinutes);

      /// <summary>
      /// Retrieve a Template record with the name "Title" and related Entity
      /// </summary>
      /// <param name="service">The organization service</param>
      /// <param name="tracingService">The tracing service</param>
      /// <param name="templateId">The id of the template to retrieve</param>
      /// <param name="ignoreCache">A value indicating whether to ignore cache</param>
      /// <returns>The template</returns>
      public static Template GetTemplate(IOrganizationService service, ITracingService tracingService, Guid templateId, bool ignoreCache = false)
      {
        lock (LockTemplateCache)
        {
          GetTemplates(service, tracingService, ignoreCache);

          if (TemplateCache.TryGetValue(templateId, out Template template))
          {
            return template;
          }
          else
          {
            throw new KeyNotFoundException($"The template {templateId} could not be found.");
          }
        }
      }

      /// <summary>
      /// Retrieve a Template record with the name "Title"
      /// </summary>
      /// <param name="service">The organization service</param>
      /// <param name="tracingService">The tracing service</param>
      /// <param name="templateName">The name of the template to retrieve</param>
      /// <param name="ignoreCache">A value indicating whether to ignore cache</param>
      /// <returns>Template Entity</returns>
      public static Template GetTemplate(IOrganizationService service, ITracingService tracingService, string templateName, bool ignoreCache = false)
      {
        lock (LockTemplateCache)
        {
          GetTemplates(service, tracingService, ignoreCache);

          var templates = TemplateCache.Where(t => t.Value.Title == templateName);

          switch (templates.Count())
          {
            case 1: return templates.First().Value;
            default: return null;
          }
        }
      }

      /// <summary>
      /// Retrieve a Template record with the name "Title" and related Entity
      /// </summary>
      /// <param name="service">The organization service</param>
      /// <param name="tracingService">The tracing service</param>
      /// <param name="templateTitle">The title of the template</param>
      /// <param name="templateTypeCode">The logical name of the entity the template relates to</param>
      /// <param name="ignoreCache">A value indicating whether to ignore cache</param>
      /// <returns>The template</returns>
      public static Template GetTemplate(IOrganizationService service, ITracingService tracingService, string templateTitle, string templateTypeCode, bool ignoreCache = false)
      {
        lock (LockTemplateCache)
        {
          GetTemplates(service, tracingService, ignoreCache);

          var templates = TemplateCache.Where(t => t.Value.Title == templateTitle && t.Value.TemplateTypeCode == templateTypeCode);

          switch (templates.Count())
          {
            case 1: return templates.First().Value;
            default: return null;
          }
        }
      }

      /// <summary>
      /// Get the templates
      /// </summary>
      /// <param name="service">The organization service</param>
      /// <param name="tracingService">The tracing service</param>
      /// <param name="ignoreCache">A value indicating whether to ignore cache</param>
      /// <returns>Template Entity</returns>
      public static ConcurrentDictionary<Guid, Template> GetTemplates(IOrganizationService service, ITracingService tracingService, bool ignoreCache = false)
      {
        lock (LockTemplateCache)
        {
          if (ignoreCache || TemplateCache.None() || DateTime.Now > TemplateCacheExpiry)
          {
            TemplateCache.Clear();

            var query = new QueryExpression()
            {
              EntityName = Template.EntityLogicalName,
              ColumnSet = new ColumnSet(true),
            };

            var entities = service.RetrieveMultiple(query).Entities;

            foreach (var template in entities.Select(e => e.ToEntity<Template>()))
            {
              TemplateCache.TryAdd(template.Id, template);
            }

            TemplateCacheExpiry = DateTime.Now.AddMinutes(CacheValidMinutes);
          }

          return TemplateCache;
        }
      }

      /// <summary>
      /// Creates an Email entity from a template and value entity
      /// </summary>
      /// <param name="service">The organization service</param>
      /// <param name="tracingService">The tracing service</param>
      /// <param name="templateId">The id of the template to instantiate</param>
      /// <param name="entityReference">The entity to use to substitute values in the template</param>
      /// <returns>An Email Entity</returns>
      public static List<Email> InstantiateTemplate(IOrganizationService service, ITracingService tracingService, Guid templateId, EntityReference entityReference)
      {
        InstantiateTemplateRequest request = new InstantiateTemplateRequest();

        request.TemplateId = templateId;
        request.ObjectId = entityReference.Id;
        request.ObjectType = entityReference.LogicalName;

        InstantiateTemplateResponse response = (InstantiateTemplateResponse)service.Execute(request);

        return response.EntityCollection.Entities.Select(e => e.ToEntity<Email>()).ToList();
      }
    }
  }
}
