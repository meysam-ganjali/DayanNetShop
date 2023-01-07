using DayanShop.Application.StoreServices.Commands.Slider;
using DayanShop.Application.StoreServices.Queries.Slider;
using DayanShop.Core.Data;
using Microsoft.AspNetCore.Hosting;

namespace DayanShop.Application.FacadePattern.FSDSlider;

public interface IFSDSlider
{
    ICreateSlider CreateSlider { get; }
    IShowSlider ShowSlider { get; }
}

public class FSDSlider : IFSDSlider
{
    private readonly DayanShopContext _db;
    private readonly IHostingEnvironment _environment;

    public FSDSlider(DayanShopContext db, IHostingEnvironment environment)
    {
        _db = db;
        _environment = environment;
    }

    private ICreateSlider _createSlider;
    public ICreateSlider CreateSlider
    {
        get
        {
            return _createSlider = _createSlider ?? new CreateSlider(_db, _environment);
        }
    }


    IShowSlider _showSlider;
    public IShowSlider ShowSlider
    {
        get
        {
            return _showSlider = _showSlider ?? new ShowSlider(_db);
        }
    }
}