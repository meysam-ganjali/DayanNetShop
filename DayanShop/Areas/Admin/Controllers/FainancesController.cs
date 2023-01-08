using DayanShop.Application.FacadePattern.FSDFainances;
using DayanShop.Application.StoreServices.Fainances;
using DayanShop.Domains.Entities;
using DayanShop.Utilities.DTOs;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ZarinPal.Class;

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
        public IActionResult OrderList(string? searchKey,OrderState? orderState, int pageSize = 50, int page = 1)
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

        [HttpPost]
        public async Task<IActionResult> DeliveryOrder(int id)// id = Order Id
        {
            var result = await _fainances.OrderDelivery.DeliveryASync(id);
            return Json(result);
        }
        [HttpPost]
        public async Task<IActionResult> CanselOrder(int id)// id = Order Id
        {
            var result = await _fainances.CancelOrder.CancelASync(id);
            return Json(result);
        }

        public async Task<IActionResult> OrderDetailes(int id)//id = OrderId
        {
            var result = await _fainances.OrderDetailes.GetAsync(id);
            return View(result.Data);
        }
        public IActionResult RequestPayList(string? searchKey, OrderState? orderState, int pageSize = 50, int page = 1)
        {
            var result = _fainances.RequestFAdmin.GetAsync(new RequestRequestPayDto
            {
                PageSize = pageSize,
                Page = page,
                SearchKey = searchKey
            });
            return View(result);
        }
    }
}
