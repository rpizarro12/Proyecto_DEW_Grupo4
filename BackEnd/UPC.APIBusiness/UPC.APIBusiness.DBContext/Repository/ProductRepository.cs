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
        public BaseResponse GetProduct(int id)
        {
            var returnEntity = new BaseResponse();
            var entityProduct = new EntityProduct();
            
            try
            {
                using(var db = GetSqlConnection())
                {
                    const string sql = @"usp_ObtenerProducto";

                    var p = new DynamicParameters();
                    p.Add(name: "@IDPRODUCTO", value: id, dbType: DbType.Int32, direction: ParameterDirection.Input);

                    entityProduct = db.Query<EntityProduct>(sql: sql, param: p, commandType: CommandType.StoredProcedure).FirstOrDefault();

                    if (entityProduct != null)
                    {
                        returnEntity.issuccess = true;
                        returnEntity.errorcode = "0000";
                        returnEntity.errormessage = string.Empty;
                        returnEntity.data = entityProduct;
                    }
                    else
                    {
                        returnEntity.issuccess = false;
                        returnEntity.errorcode = "0000";
                        returnEntity.errormessage = string.Empty;
                        returnEntity.data = null;
                    }
                }
            }
            catch(Exception ex)
            {
                returnEntity.issuccess = false;
                returnEntity.errorcode = "0001";
                returnEntity.errormessage = ex.Message;
                returnEntity.data = null;
            }
            return returnEntity;
        }

        public BaseResponse GetProducts()
        {
            var returnEntity = new BaseResponse();
            var entitiesProducts = new List<EntityProduct>();
            

            try
            {
                using(var db = GetSqlConnection())
                {
                    const string sql = @"usp_ListarProductos";

                    entitiesProducts = db.Query<EntityProduct>(sql: sql, commandType: CommandType.StoredProcedure).ToList();

                    if (entitiesProducts.Count > 0)
                    {
                        returnEntity.issuccess = true;
                        returnEntity.errorcode = "0000";
                        returnEntity.errormessage = string.Empty;
                        returnEntity.data = entitiesProducts;
                    }
                    else
                    {
                        returnEntity.issuccess = false;
                        returnEntity.errorcode = "0000";
                        returnEntity.errormessage = string.Empty;
                        returnEntity.data = null;
                    }
                }
            }
            catch(Exception ex)
            {
                returnEntity.issuccess = false;
                returnEntity.errorcode = "0001";
                returnEntity.errormessage = ex.Message;
                returnEntity.data = null;
            }
            return returnEntity;
        }

        public BaseResponse GetProductsType(string type)
        {
            var returnEntity = new BaseResponse();
            var entitiesProducts = new List<EntityProduct>();

            try
            {
                using(var db = GetSqlConnection())
                {
                    const string sql = @"usp_ListarTipoProducto";

                    var p = new DynamicParameters();
                    p.Add(name: "@TIPO", value: type, dbType: DbType.String, direction: ParameterDirection.Input);

                    entitiesProducts = db.Query<EntityProduct>(sql: sql, param: p, commandType: CommandType.StoredProcedure).ToList();

                    if (entitiesProducts.Count > 0)
                    {
                        returnEntity.issuccess = true;
                        returnEntity.errorcode = "0000";
                        returnEntity.errormessage = string.Empty;
                        returnEntity.data = entitiesProducts;
                    }
                    else
                    {
                        returnEntity.issuccess = false;
                        returnEntity.errorcode = "0000";
                        returnEntity.errormessage = string.Empty;
                        returnEntity.data = null;
                    }
                }
            }
            catch(Exception ex)
            {
                returnEntity.issuccess = false;
                returnEntity.errorcode = "0001";
                returnEntity.errormessage = ex.Message;
                returnEntity.data = null;
            }
            return returnEntity;
        }

        public BaseResponse Insert(EntityProduct product)
        {
            throw new NotImplementedException();
        }
    }
}
