using System.Security.Claims;
using DayanShop.Application.FacadePattern.FSDShoping;
using DayanShop.Application.StoreServices.CartService;
using DayanShop.Domains.Entities;
using DayanShop.Utilities.Helpers;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace DayanShop.Controllers
{
    [Authorize]
    public class CartController : Controller
    {
        private readonly IFSDShoping _shoping;
        private readonly CookieManagement cookiesManeger;

        public CartController(IFSDShoping shoping, CookieManagement cookiesManeger)
        {
            _shoping = shoping;
            this.cookiesManeger = cookiesManeger;
        }
        public async Task<IActionResult> CartList()
        {
            var claimIdentity = (ClaimsIdentity)User.Identity;
            var claim = claimIdentity.FindFirst(ClaimTypes.NameIdentifier);
            string userId = claim.Value;
            var result = await _shoping.CartService.GetMyCart(cookiesManeger.GetBrowserId(HttpContext), userId);

            return View(result.Data);
        }
        [HttpPost]
        public async Task<IActionResult> AddToCart(int id,int Count)//id = Product Id
        {
            var claimIdentity = (ClaimsIdentity)User.Identity;
            var claim = claimIdentity.FindFirst(ClaimTypes.NameIdentifier);
            string userId = claim.Value;
            var resultAdd = await _shoping.CartService.AddToCart(id, cookiesManeger.GetBrowserId(HttpContext),Count,userId);
            if (resultAdd.IsSuccess)
            {
                TempData["success"] = "result.Message";
                return Redirect($"/Shop/ProductDetaile/{id}");
            }
            else
            {
                TempData["error"] = "result.Message";
                return Redirect($"/Shop/ProductDetaile/{id}");
            }
        }

        public async Task<IActionResult> Add(int id)//id = cartItemId
        {
            var result = await _shoping.CartService.Add(id);
            return Redirect("/Cart/CartList");
        }
        public async Task<IActionResult> Sub(int id)//id = cartItemId
        {
            var result = await _shoping.CartService.LowOff(id);
            return Redirect("/Cart/CartList");
        }
    }
}
