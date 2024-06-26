﻿using JewelryProduction.BusinessObject.Filter;
using JewelryProduction.BusinessObject.Models;

namespace JewelryProduction.Repository.ProductStoneRepository
{
    public interface IProductStoneRepository
    {
        List<ProductStone> GetAll(FilterModel filterModel);

        ProductStone GetById(Guid productId, Guid stoneId);

        ProductStone Create(ProductStone productStone);

        bool Update(ProductStone productStone);

        bool Delete(Guid productId, Guid stoneId);

        int TotalItem();
    }
}