using DayanShop.Application.FacadePattern.FSDFainances;
using DayanShop.Application.FacadePattern.FSDShoping;
using DayanShop.Domains.Entities;
using DayanShop.Utilities.Helpers;
using Dto.Payment;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using DayanShop.Application.StoreServices.Fainances;
using Microsoft.AspNetCore.Authorization;
using ZarinPal.Class;

namespace DayanShop.Controllers
{
    [Authorize]
    public class PayController : Controller
    {
        private readonly IFSDShoping _cartService;
        private readonly IFSDFainances _peyment;
        private readonly CookieManagement cookiesManeger;
        private readonly Payment _payment;
        private readonly Authority _authority;
        private readonly Transactions _transactions;
        public PayController(IFSDShoping cartService, IFSDFainances peyment, CookieManagement cookiesManeger)
        {
            _cartService = cartService;
            _peyment = peyment;
            this.cookiesManeger = cookiesManeger;
            var expose = new Expose();
            _payment = expose.CreatePayment();
            _authority = expose.CreateAuthority();
            _transactions = expose.CreateTransactions();
        }
        public async Task<IActionResult> PaymentIndex()
        {
            var claimIdentity = (ClaimsIdentity)User.Identity;
            var claim = claimIdentity.FindFirst(ClaimTypes.NameIdentifier);
            string userId = claim.Value;
            var userCart = await _cartService.CartService.GetMyCart(cookiesManeger.GetBrowserId(HttpContext), userId);
            if (userCart.Data.SumAmount > 0)
            {
                var requestPay = await _peyment.AddRequestPay.Execute(userCart.Data.SumAmount, userId);
                // ارسال در گاه پرداخت
                
                var result = await _payment.Request(new DtoRequest()
                {
                    Mobile = requestPay.Data.UserPhone,
                    CallbackUrl = $"https://localhost:44360/Pay/Verify?guid={requestPay.Data.guid}&cartId={userCart.Data.Id}&userId={userId}",
                    Description = $"پرداخت فاکتور {requestPay.Data.RequestPayId} مربوط به کاربر {requestPay.Data.UserFullName}",
                    Email = requestPay.Data.Email,
                    Amount = (int)requestPay.Data.Amount,
                    MerchantId = "XXXXXXXX-XXXX-XXXX-XXXX-XXXXXXXXXXXX"
                }, ZarinPal.Class.Payment.Mode.sandbox);
                return Redirect($"https://sandbox.zarinpal.com/pg/StartPay/{result.Authority}");


            }
            else
            {
                return RedirectToAction("CartList", "Cart");
            }

        }
        public async Task<IActionResult> Verify(Guid guid, string authority, string status,long cartId,string userId)
        {

           var requestPay = await _peyment.GetRequestPay.Execute(guid);
            
            var verification = await _payment.Verification(new DtoVerification
            {
                Amount = requestPay.Data.Amount,
                MerchantId = "XXXXXXXX-XXXX-XXXX-XXXX-XXXXXXXXXXXX",
                Authority = authority
            }, Payment.Mode.sandbox);

            if (verification.Status == 100)
            {
                var confirmRequest = await _peyment.EditRequestPay.ConfirmRequestPayAsync(guid, authority, status, verification.RefId);
                if (confirmRequest.IsSuccess)
                {
                  
                    var addOrder = await _peyment.AddNewOrder.CreateAsync(new RequestAddNewOrderSericeDto
                    {
                        CartId = cartId,
                        RequestPayId = confirmRequest.Data.Id,
                        UserId = userId
                    });
                    
                    return View(confirmRequest.Data);
                }
                else
                {
                    ViewBag.Error = "err";
                    return View();
                }
            }
            else
            {
                return null;
            }

        }
    }
}
