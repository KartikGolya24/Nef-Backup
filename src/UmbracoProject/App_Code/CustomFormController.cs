using Microsoft.AspNetCore.Mvc;
using Umbraco.Cms.Core.Cache;
using Umbraco.Cms.Core.Logging;
using Umbraco.Cms.Core.Routing;
using Umbraco.Cms.Core.Services;
using Umbraco.Cms.Core.Web;
using Umbraco.Cms.Infrastructure.Persistence;
using Umbraco.Cms.Web.Common.Controllers;
using Umbraco.Cms.Web.Website.Controllers;
using Umbraco.Forms.Core.Models;
using Umbraco.Forms.Core.Persistence.Dtos;
using Umbraco.Forms.Core.Services;
using UmbracoProject.App_Code.Models;

namespace UmbracoProject.App_Code
{
    public class CustomFormController : SurfaceController
    {
        private readonly IRecordService _recordService;
        private readonly IFormService _formService;

        public CustomFormController(IUmbracoContextAccessor umbracoContextAccessor, IUmbracoDatabaseFactory umbracoDatabaseFactory, ServiceContext serviceContext, AppCaches appCaches, IProfilingLogger profilingLogger, IPublishedUrlProvider publishedUrlProvider, IRecordService recordService, IFormService formService) : base(umbracoContextAccessor, umbracoDatabaseFactory, serviceContext, appCaches, profilingLogger, publishedUrlProvider)
        {
            _recordService = recordService;
            _formService = formService;
        }

        [ValidateAntiForgeryToken]
        [HttpPost]
        public async Task<IActionResult> SubmitForm(SunbeamStoryFormRequestModel requestModel)
        {
            // Form has single field with alias of "name".
            Form? form = _formService.Get(requestModel.FormId);
            if (form == null)
            {
                throw new InvalidOperationException($"Could not find form with ID: {requestModel.FormId} Error Line 28 controller CustomFormController");
            }

            var submittedValues = new Dictionary<string, object>
            {
                { "fuldeNavn", requestModel.fuldeNavn },
                { "adresse", requestModel.adresse ?? string.Empty },
                { "telefon", requestModel?.telefon == null ? 0 : requestModel.telefon },
                { "email", requestModel.email }, 
                { "gSRNNummer", requestModel?.gSRNNummer == null ? 0 : requestModel.gSRNNummer },
                { "evtKommentar", requestModel?.evtKommentar ?? string.Empty }
            };

            var record = new Record
            {
                Created = DateTime.Now,
                Form = form.Id,
                Culture = Thread.CurrentThread.CurrentCulture.Name,
            };

            foreach (Field field in form.AllFields)
            {
                var recordField = new RecordField(field)
                {
                    Alias = field.Alias,
                    FieldId = field.Id,
                    Key = Guid.NewGuid(),
                    Record = record.Id,
                    Values = new List<object>() { submittedValues[field.Alias] }
                };
                record.RecordFields.Add(field.Id, recordField);
            }

            await _recordService.SubmitAsync(record, form);

            TempData["submitMessage"] = "Thank you";
            return Redirect(requestModel.ReturnUrl);
        }
    }
}
