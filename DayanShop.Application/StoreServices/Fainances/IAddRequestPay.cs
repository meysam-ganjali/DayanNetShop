using DayanShop.Core.Data;
using DayanShop.Domains.Entities;
using DayanShop.Utilities.DTOs;

namespace DayanShop.Application.StoreServices.Fainances;

public interface IAddRequestPay
{
   Task<ResultDto<ResultRequestPayDto>> Execute(long Amount, string UserId);
}

public class AddRequestPay : IAddRequestPay
{
    private readonly DayanShopContext _context;

    public AddRequestPay(DayanShopContext context)
    {
        _context = context;
    }
    public async Task<ResultDto<ResultRequestPayDto>> Execute(long Amount, string UserId)
    {
        var user =await  _context.ApplicationUsers.FindAsync(UserId);
        RequestPay requestPay = new RequestPay()
        {
            Amount = (int)Amount,
            Guid = Guid.NewGuid(),
            IsPay = false,
            User = user,

        };
        _context.RequestPays.Add(requestPay);
        await _context.SaveChangesAsync();

        return new ResultDto<ResultRequestPayDto>()
        {
            Data = new ResultRequestPayDto
            {
                guid = requestPay.Guid,
                Amount = requestPay.Amount,
                Email = user.Email,
                RequestPayId = requestPay.Id,
                UserPhone = user.UserPhone,
                UserFullName =$"{user.FirstName} {user.LastName} - {user.Id}"
            },
            IsSuccess = true,
        };
    }
}
public class ResultRequestPayDto
{
    public Guid guid { get; set; }
    public long Amount { get; set; }
    public string Email { get; set; }
    public long RequestPayId { get; set; }
    public string UserPhone { get; set; }
    public string UserFullName { get; set; }
}