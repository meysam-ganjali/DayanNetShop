using DayanShop.Application.FacadePattern.FSDFainances;
using DayanShop.Application.StoreServices.Fainances;
using DayanShop.Domains.Entities;
using DayanShop.Utilities.DTOs;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace DayanShop.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles=SD.ManagerRole)]
    public class FainancesController : Controller
    {
        private readonly IFSDFainances _fainances;

        public FainancesController(IFSDFainances fainances)
        {
            _fainances = fainances;
        }
        public IActionResult OrderList(string? searchKey,OrderState? orderState, int pageSize = 2, int page = 1)
        {
            var result = _fainances.OrdersInfo.GetAsync(new RequestGetOrderDto
            {
                PageSize = pageSize,
                OrderState = orderState,
                Page = page,
                SearchKey =searchKey
            });
            return View(result);
        }
    }
}
