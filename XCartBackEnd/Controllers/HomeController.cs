using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using XCart.BL;
using XCart.DAL;
using XCart.DBEntities;

namespace XCartBackEnd.Controllers
{
    //[Authorize(Roles ="customer")]
    //[Route("api/[controller]")]
    [ApiController]
   
    public class HomeController : ControllerBase
    {
        private readonly HomeBL homebl;
        public HomeController(HomeBL _homebl)
        {
           homebl = _homebl;
        }


        [HttpGet]
        [Route("home")]
        public IEnumerable<PRODUCTS> AllProducts()
        {

            return homebl.getAllProduct();
        }
        [HttpGet]
        [Route("category")]
        public object Cate()
        {

            return homebl.cate();
        }

        [HttpGet]
        [Route("category/search/{category}")]
        public object CateSearch(string category)
        {

            return homebl.catesearch(category);
        }

        [HttpGet]
        [Route("home/{search}")]
        public IEnumerable<PRODUCTS> AllseachProducts(string search)
        {

            return homebl.seachProduct(search);
        }

        [HttpGet("product/{id}")]
        public PRODUCTS Get(int id)
        {
            return homebl.ProductWithId(id);
        }


    }
}