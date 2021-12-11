using DBContext;
using DBEntity;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using NSwag.Annotations;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Security.Claims;
using System.Threading.Tasks;
using UPC.E31B.APIBusiness.API.Security;

namespace UPC.Business.API.Controllers
{
    /// <summary>
    /// 
    /// </summary>
    [Produces("application/json")]
    [Route("api/User")]
    [ApiController]
    public class UserController : Controller
    {

        /// <summary>
        /// Constructor
        /// </summary>
        protected readonly IUserRepository _UserRepository;


        /// <summary>
        /// 
        /// </summary>
        /// <param name="UserRepository"></param>
        public UserController(IUserRepository UserRepository)
        {
            _UserRepository = UserRepository;

        }

        /// <summary>
        /// RPM: Cambio de Authorize por AllowAnonymous para permitir registro
        /// </summary>
        /// <param name="user"></param>
        /// <returns></returns>
        [Produces("application/json")]
        [AllowAnonymous]
        [HttpPost]
        [Route("insert")]
        public ActionResult Insert(EntityUser user)
        {
            var identity = User.Identity as ClaimsIdentity;
            IEnumerable<Claim> claims = identity.Claims;

            //var idusuario = claims.Where(p => p.Type == "client_codigo_usuario").FirstOrDefault()?.Value;
            var documentoidentidad = claims.Where(p => p.Type == "client_numero_documento").FirstOrDefault()?.Value;

            //user.UsuarioCrea = int.Parse(idusuario);
                        
            var ret = _UserRepository.Insert(user);
            return Json(ret);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="login"></param>
        /// <returns></returns>
        [Produces("application/json")]
        [AllowAnonymous]
        [HttpPost]
        [Route("login")]
        public async Task<ActionResult> Login(EntityLogin login)
        {
            var ret = _UserRepository.Login(login);

            if(ret.data!=null)
            {
                var loginresponse = ret.data as EntityLoginResponse;
                var idusuario = loginresponse.idusuario.ToString();
                var documentoidentidad = loginresponse.documentoidentidad;

                var token = JsonConvert
                    .DeserializeObject<AccessToken>(
                        await new Authentication()
                        .GenerateToken(documentoidentidad, idusuario)
                    ).access_token;

                loginresponse.token = token;
                ret.data = loginresponse;
            }

            return Json(ret);
        }
    }
}