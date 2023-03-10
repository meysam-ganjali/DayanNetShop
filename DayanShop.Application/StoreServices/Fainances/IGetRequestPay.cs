using DayanShop.Core.Data;
using DayanShop.Domains.Entities;
using DayanShop.Utilities.DTOs;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations.Schema;

namespace DayanShop.Application.StoreServices.Fainances;

public interface IGetRequestPay
{
    Task<ResultDto<RequestPayDto>> Execute(Guid guid);
}

public class GetRequestPay : IGetRequestPay
{
    private readonly DayanShopContext _context;

    public GetRequestPay(DayanShopContext context)
    {
        _context = context;
    }

    public async Task<ResultDto<RequestPayDto>> Execute(Guid guid)
    {
        var requestPay = await _context.RequestPays.FirstOrDefaultAsync(p => p.Guid == guid);

        if (requestPay != null)
        {
            return new ResultDto<RequestPayDto>()
            {
                Data = new RequestPayDto()
                {
                    Amount = requestPay.Amount,
                    Id = requestPay.Id,

                }
            };
        }
        else
        {
            return new ResultDto<RequestPayDto>
            {
                Message = "request pay not found",
                IsSuccess = false
            };
        }
    }
}
public class RequestPayDto
{
    public int Amount { get; set; }
    public int Id { get; set; }


}