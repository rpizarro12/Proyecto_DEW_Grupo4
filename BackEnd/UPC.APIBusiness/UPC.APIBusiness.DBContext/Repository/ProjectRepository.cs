using System;
using System.Collections.Generic;
using System.Text;
using DBEntity;
using Dapper;
using System.Data;
using System.Linq;

namespace DBContext
{
    public class ProjectRepository : BaseRepository, IProjectRepository
    {
        public EntityProject GetProject(int id)
        {
            var entityProject = new EntityProject();
            var imageRepository = new ImageRepository();

            try
            {
                using(var db = GetSqlConnection())
                {
                    const string sql = @"usp_ObtenerProyecto";

                    var p = new DynamicParameters();
                    p.Add(name: "@IDPROYECTO", value: id, dbType: DbType.Int32,direction:ParameterDirection.Input);

                    entityProject = db.Query<EntityProject>(sql: sql, param: p, commandType: CommandType.StoredProcedure).FirstOrDefault();

                    if (entityProject != null)
                    {
                        //entityProject.images = imageRepository.GetImages(entityProject.idproyecto);
                    }
                }
            }
            catch(Exception ex)
            {

            }
            return entityProject;
        }

        public List<EntityProject> GetProjects()
        {
            var entitiesProjects = new List<EntityProject>();
            var imageRepository = new ImageRepository();

            try
            {
                using (var db=GetSqlConnection())
                {
                    //nombre del procedimiento almacenado
                    const string sql = @"usp_ListarProyectos";


                    //colocamos parametros
                    entitiesProjects = db.Query<EntityProject>(sql:sql,commandType:CommandType.StoredProcedure).ToList();

                    foreach(var pro in entitiesProjects)
                    {
                        //pro.images = imageRepository.GetImages(pro.idproyecto);
                    }
                }
            }
            catch (Exception ex)
            {

            }

            return entitiesProjects;
        }
    }
}
