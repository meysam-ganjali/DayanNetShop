using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DayanShop.Domains.Entities;
using DayanShop.Utilities.DTOs;

namespace DayanShop.Application.StoreServices.Queries.Category;

    public interface IParentCategoryInformation
    {
        Task<ResultDto<IEnumerable<ParentCategory>>> GetAllParentCategoryAsync(string? searchKey);
    }