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

namespace UPC.APIBusiness.API.Controllers
{
    /// <summary>
    /// 
    /// </summary>
    [Produces("application/json")]
    [Route("api/product")]
    public class ProductController : Controller
    {
        /// <summary>
        /// 
        /// </summary>
        protected readonly IProductRepository _ProductRepository;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="ProductRepository"></param>
        public ProductController(IProductRepository ProductRepository)
        {
            _ProductRepository = ProductRepository;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [Produces("application/json")]
        [AllowAnonymous] 
        [HttpGet]
        [Route("getproduct")]
        public ActionResult GetProduct(int id)
        {
            var ret = _ProductRepository.GetProduct(id);
            return Json(ret);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        [Produces("application/json")]
        [AllowAnonymous]
        [HttpGet]
        [Route("getproducts")]
        public ActionResult GetProducts()
        {
            var ret = _ProductRepository.GetProducts();
            return Json(ret);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="type"></param>
        /// <returns></returns>
        [Produces("application/json")]
        [AllowAnonymous]
        [HttpGet]
        [Route("getproductstype")]
        public ActionResult GetProductsType(string type)
        {
            var ret = _ProductRepository.GetProductsType(type);
            return Json(ret);
        }
    }
}
