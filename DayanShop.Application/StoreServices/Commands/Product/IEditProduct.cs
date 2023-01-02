using DayanShop.Core.Data;

namespace DayanShop.Application.StoreServices.Commands.Product;

public interface IEditProduct
{
    
}

public class EditProduct : IEditProduct
{
    private readonly DayanShopContext _db;

    public EditProduct(DayanShopContext db)
    {
        _db = db;
    }
}