using DayanShop.Core.Data;
using DayanShop.Domains.Entities;
using DayanShop.Utilities.DTOs;
using Microsoft.EntityFrameworkCore;

namespace DayanShop.Application.StoreServices.Fainances;

public interface IEditRequestPay
{
    Task<ResultDto<RequestPay>> ConfirmRequestPayAsync(Guid requestGuid, string authority, string status, int refId);
}

public class EditRequestPay : IEditRequestPay
{
    private readonly DayanShopContext _db;

    public EditRequestPay(DayanShopContext db)
    {
        _db = db;
    }

    public async Task<ResultDto<RequestPay>> ConfirmRequestPayAsync(Guid requestGuid, string authority, string status, int refId)
    {
        var requestInDb = await _db.RequestPays
            .Include(p=>p.User)
            .FirstOrDefaultAsync(r => r.Guid == requestGuid);
        if (requestInDb == null)
        {
            return new ResultDto<RequestPay>()
            {
                IsSuccess = false,
                Message = "Request Pay Not Found"
            };
        }

        if (status == "OK")
        {
            requestInDb.Authority = authority;
            requestInDb.IsPay = true;
            requestInDb.PayDate = DateTime.Now;
            requestInDb.RefId = refId;
            await _db.SaveChangesAsync();
            return new ResultDto<RequestPay>
            {
                Message =
                    $"درخواست پرداخت {requestInDb.Id} مربوط به کاربر {requestInDb.User.FirstName} {requestInDb.User.LastName} با کد کاربری {requestInDb.User.Id} با موفقیت به اتمام رسید",
                IsSuccess = true,
                Data = requestInDb
            };
        }
        else
        {
            return new ResultDto<RequestPay>
            {
                IsSuccess = false,
                Message = "خطایی رخ داده است"
            };
        }
    }
}