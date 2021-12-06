using System;
using System.Collections.Generic;
using System.Text;
using DBEntity;

namespace DBContext
{
    public interface IProductRepository
    {
        BaseResponse GetProducts();

        BaseResponse GetProduct(int id);

        BaseResponse GetProductsType(string type);

        BaseResponse Insert(EntityProduct product);
        
    }
}
