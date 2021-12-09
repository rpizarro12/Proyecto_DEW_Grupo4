using Dapper;
using DBEntity;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace DBContext
{
    public class UserRepository : BaseRepository, IUserRepository
    {
        public BaseResponse Insert(EntityUser user)
        {
            var returnEntity = new BaseResponse();

            try
            {
                using (var db = GetSqlConnection())
                {
                    const string sql = @"usp_NuevoUsuario";

                    var p = new DynamicParameters();
                    p.Add(name: "@IDUSUARIO", dbType: DbType.Int32, direction: ParameterDirection.Output);
                    p.Add(name: "@LOGINUSUARIO", value: user.loginusuario, dbType: DbType.String, direction: ParameterDirection.Input);
                    p.Add(name: "@PASSWORDUSUARIO", value: user.passwordusuario, dbType: DbType.String, direction: ParameterDirection.Input);
                    p.Add(name: "@IDPERFIL", value: user.idperfil, dbType: DbType.Int32, direction: ParameterDirection.Input);
                    p.Add(name: "@NOMBRES", value: user.nombres, dbType: DbType.String, direction: ParameterDirection.Input);
                    p.Add(name: "@APELLIDOPATERNO", value: user.apellidopaterno, dbType: DbType.String, direction: ParameterDirection.Input);
                    p.Add(name: "@APELLIDOMATERNO", value: user.apellidomaterno, dbType: DbType.String, direction: ParameterDirection.Input);
                    p.Add(name: "@DOCUMENTOIDENTIDAD", value: user.documentoidentidad, dbType: DbType.String, direction: ParameterDirection.Input);
                    p.Add(name: "@USUARIOCREA", value: user.UsuarioCrea, dbType: DbType.Int32, direction: ParameterDirection.Input);

                    db.Query<EntityUser>(
                        sql: sql,
                        param: p,
                        commandType: CommandType.StoredProcedure
                        ).FirstOrDefault();

                    int idusuario = p.Get<int>("@IDUSUARIO");

                    if(idusuario>0)
                    {
                        returnEntity.issuccess = true;
                        returnEntity.errorcode = "0000";
                        returnEntity.errormessage = string.Empty;
                        returnEntity.data = new
                        {
                            id = idusuario,
                            nombre = user.nombres + " " + user.apellidopaterno + " " + user.apellidopaterno
                        };
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

            catch (Exception ex)
            {
                returnEntity.issuccess = false;
                returnEntity.errorcode = "0001";
                returnEntity.errormessage = ex.Message;
                returnEntity.data = null;
            }

            return returnEntity;
        }

        public BaseResponse Login(EntityLogin login)
        {
            var returnEntity = new BaseResponse();
            var loginResponse = new EntityLoginResponse();

            try
            {
                using (var db = GetSqlConnection())
                {
                    const string sql = @"usp_user_login";

                    var p = new DynamicParameters();
                    p.Add(name: "@LOGINUSUARIO", value: login.loginusuario, dbType: DbType.String, direction: ParameterDirection.Input);
                    p.Add(name: "@PASSWORDUSUARIO", value: login.passwordusuario, dbType: DbType.String, direction: ParameterDirection.Input);

                    loginResponse = db.Query<EntityLoginResponse>(
                        sql: sql,
                        param: p,
                        commandType: CommandType.StoredProcedure
                        ).FirstOrDefault();

                    if (loginResponse != null)
                    {
                        returnEntity.issuccess = true;
                        returnEntity.errorcode = "0000";
                        returnEntity.errormessage = string.Empty;
                        returnEntity.data = loginResponse;
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
    }
}
