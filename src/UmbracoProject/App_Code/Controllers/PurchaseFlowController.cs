using Microsoft.AspNetCore.Mvc;
using UmbracoProject.App_Code.Models;
using UmbracoProject.App_Code.Services;

namespace UmbracoProject.App_Code.Controllers
{
    [Route("purchase-flow")]
    public class PurchaseFlowController : Controller
    {
        private readonly IPurchaseFlowService _purchaseFlowService;
        private readonly ILogger<PurchaseFlowController> _logger;

        public PurchaseFlowController(IPurchaseFlowService purchaseFlowService, ILogger<PurchaseFlowController> logger)
        {
            _purchaseFlowService = purchaseFlowService;
            _logger = logger;
        }

        //{domain/purchase-flow/check-address?adresseGUID=""}
        [HttpGet("check-address")]
        public async Task<IActionResult> CheckAddress(string adresseGUID)
        {
            ResponseModel response = new();
            try
            {
                var result = await _purchaseFlowService.CheckAddressAsync(adresseGUID);
                response.Data = result;
                response.IsSucceeded = true;
                return Ok(response);
            }
            catch (Exception ex)
            {
                _logger.LogError($"Error while checking address '{adresseGUID}' controller 'PurchaseFlowController' action 'CheckAddress(string adresseGUID)' Error '{ex.Message}' StackTrace '{ex.StackTrace}' ");
                response.IsSucceeded = false;
                response.Error = ex.Message;
                return StatusCode(StatusCodes.Status500InternalServerError, response);
            }

        }

        //{domain/purchase-flow/get-calendar-dates?orderType=""&adresseguid=""}
        [HttpGet("get-calendar-dates")]
        public async Task<IActionResult> GetCalendarDatesAsync(int orderType, string? adresseguid)
        {
            ResponseModel response = new();
            try
            {
                var result = await _purchaseFlowService.GetCalendarDatesAsync(orderType, adresseguid);
                response.Data = result;
                response.IsSucceeded = true;
                return Ok(response);
            }
            catch (Exception ex)
            {
                _logger.LogError($"Error while getting calendar delivary dates for orderType '{orderType}', addressguid '{adresseguid}' controller 'PurchaseFlowController' action 'GetCalendarDatesAsync(int orderType, string? adresseguid)' Error '{ex.Message}' StackTrace '{ex.StackTrace}' ");
                response.IsSucceeded = false;
                response.Error = ex.Message;
                return StatusCode(StatusCodes.Status500InternalServerError, response);
            }

        }
    }
}
