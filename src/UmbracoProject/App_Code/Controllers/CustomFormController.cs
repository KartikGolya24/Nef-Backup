using Microsoft.AspNetCore.Mvc;
using Umbraco.Cms.Core.Cache;
using Umbraco.Cms.Core.Logging;
using Umbraco.Cms.Core.Routing;
using Umbraco.Cms.Core.Services;
using Umbraco.Cms.Core.Web;
using Umbraco.Cms.Infrastructure.Persistence;
using Umbraco.Cms.Web.Website.Controllers;
using Umbraco.Forms.Core.Models;
using Umbraco.Forms.Core.Persistence.Dtos;
using Umbraco.Forms.Core.Services;

namespace UmbracoProject.App_Code.Controllers;

public class CustomFormController(
    IRecordService recordService,
    IFormService formService,
    IUmbracoContextAccessor umbracoContextAccessor,
    IUmbracoDatabaseFactory umbracoDatabaseFactory,
    ServiceContext serviceContext,
    AppCaches appCaches,
    IProfilingLogger profilingLogger,
    IPublishedUrlProvider publishedUrlProvider
    ) : SurfaceController(umbracoContextAccessor, umbracoDatabaseFactory, serviceContext, appCaches, profilingLogger, publishedUrlProvider)
{
    /// <summary>
    /// 
    /// </summary>
    /// <param name="requestModel"></param>
    /// <returns></returns>
    /// <exception cref="InvalidOperationException"></exception>
    [HttpPost]
    public async Task<IActionResult> SubmitForm([FromBody] List<KeyValuePair<string, string>> requestModel)
    {
        if (requestModel is not null && requestModel.Count > 0)
        {
            var submittedValues = requestModel.ToDictionary(kvp => kvp.Key, kvp => kvp.Value);

            _ = Guid.TryParse(submittedValues["formId"], out Guid formId);

            Form? form = formService.Get(formId) ?? throw new InvalidOperationException($"Could not find form with ID: {formId}");

            var record = new Record
            {
                Created = DateTime.Now,
                Form = form.Id,
                Culture = Thread.CurrentThread.CurrentCulture.Name,
            };
            foreach (Field field in form.AllFields)
            {
                try
                {

                    var recordField = new RecordField(field)
                    {
                        Alias = field.Alias,
                        FieldId = field.Id,
                        Key = Guid.NewGuid(),
                        Record = record.Id,
                        Values = new List<object>() { string.IsNullOrWhiteSpace(submittedValues[field.Alias]) ? string.Empty : submittedValues[field.Alias] }
                    };
                    record.RecordFields.Add(field.Id, recordField);
                }
                catch (Exception ex)
                {
                }
            }
            await recordService.SubmitAsync(record, form);
            return Ok();
        }

        return BadRequest();

    }

}
