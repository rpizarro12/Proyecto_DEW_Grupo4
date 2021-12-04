using System;
using System.Collections.Generic;
using System.Text;
using DBEntity;
using Dapper;
using System.Data;
using System.Linq;

namespace DBContext
{
    public class ProductRepository : BaseRepository, IProductRepository
    {
        public EntityProduct GetProduct(int id)
        {
            var entityProduct = new EntityProduct();
            
            try
            {
                using(var db = GetSqlConnection())
                {
                    const string sql = @"usp_ObtenerProducto";

                    var p = new DynamicParameters();
                    p.Add(name: "@IDPRODUCTO", value: id, dbType: DbType.Int32, direction: ParameterDirection.Input);

                    entityProduct = db.Query<EntityProduct>(sql: sql, param: p, commandType: CommandType.StoredProcedure).FirstOrDefault();

                }
            }
            catch(Exception ex)
            {

            }
            return entityProduct;
        }

        public List<EntityProduct> GetProducts()
        {
            var entitiesProducts = new List<EntityProduct>();
            

            try
            {
                using(var db = GetSqlConnection())
                {
                    const string sql = @"usp_ListarProductos";

                    entitiesProducts = db.Query<EntityProduct>(sql: sql, commandType: CommandType.StoredProcedure).ToList();
                }
            }
            catch(Exception ex)
            {

            }
            return entitiesProducts;
        }

        public List<EntityProduct> GetProductsType(string type)
        {
            var entitiesProducts = new List<EntityProduct>();

            try
            {
                using(var db = GetSqlConnection())
                {
                    const string sql = @"usp_ListarTipoProducto";

                    var p = new DynamicParameters();
                    p.Add(name: "@TIPO", value: type, dbType: DbType.String, direction: ParameterDirection.Input);

                    entitiesProducts = db.Query<EntityProduct>(sql: sql, param: p, commandType: CommandType.StoredProcedure).ToList();
                }
            }
            catch(Exception ex)
            {

            }
            return entitiesProducts;
        }
    }
}
