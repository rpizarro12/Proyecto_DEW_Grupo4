using System;
using System.Collections.Generic;
using System.Text;
using DBEntity;
using Dapper;
using System.Data;
using System.Linq;
namespace DBContext
{
    public class ImageRepository : BaseRepository, IImageRepository
    {
        public List<EntityImage> GetImages(int id)
        {
            var entitiesImages = new List<EntityImage>();
            try
            {
                using (var db = GetSqlConnection())
                {
                    const string sql = @"usp_Listar_Images_X_Proyecto";

                    var p = new DynamicParameters();
                    p.Add(name: "@IDPROYECTO", value: id, dbType: DbType.Int32, direction: ParameterDirection.Input);

                    entitiesImages = db.Query<EntityImage>(sql: sql, param: p, commandType: CommandType.StoredProcedure).ToList();
                }
            }
            catch(Exception ex)
            {

            }

            return entitiesImages;
        }
    }
}
