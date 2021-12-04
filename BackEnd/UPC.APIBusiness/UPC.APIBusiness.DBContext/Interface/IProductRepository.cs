using System;
using System.Collections.Generic;
using System.Text;
using DBEntity;

namespace DBContext
{
    public interface IProductRepository
    {
        List<EntityProduct> GetProducts();

        EntityProduct GetProduct(int id);

        List<EntityProduct> GetProductsType(string type);
        
    }
}
