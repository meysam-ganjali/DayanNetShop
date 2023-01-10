using System.ComponentModel.DataAnnotations.Schema;

namespace DayanShop.Domains.Entities;

public class Order
{
    public int Id { get; set; }
    public DateTime CreatedDate { get; set; } = DateTime.Now;
    public string UserId { get; set; }
    [ForeignKey("UserId")]
    public ApplicationUser ApplicationUser { get; set; }
    public long TootalAmount { get; set; }
    public OrderState OrderState { get; set; } = OrderState.Processing;
    public ICollection<OrderDetaile> OrderDetailes { get; set; }   
    public int RequestPayId { get; set; }
    [ForeignKey("RequestPayId")]
    public virtual RequestPay RequestPay { get; set; }
    public string Address { get; set; }
    public string State { get; set; }
    public string City { get; set; }
    public string PostalCode { get; set; }
    public string Phone { get; set; }



}
public class RequestPay
{
    public int Id { get; set; }
    public Guid Guid { get; set; }
    public string UserId { get; set; }
    [ForeignKey("UserId")]
    public  ApplicationUser User { get; set; }
    public int Amount { get; set; }
    public bool IsPay { get; set; }
    public DateTime? PayDate { get; set; }
    public string? Authority { get; set; }
    public long RefId { get; set; } = 0;
    public virtual ICollection<Order> Orders { get; set; }
}

public class OrderDetaile
{
    public int Id { get; set; }
    public int OrderId { get; set; }
    [ForeignKey("OrderId")]
    public Order Order { get; set; }
    public int ProductId { get; set; }
    [ForeignKey("ProductId")]
    public Product Product { get; set; }
    public int ProductCount { get; set; }
    public long ProductPrice { get; set; }
    public long TotalRow { get; set; }
}
public enum OrderState
{
    Processing = 0,
    Canceled = 1,
    Delivered = 2,
}