using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using XCart.DAL;
using XCart.BL.AdminBL;
using XCart.DBEntities;
using Microsoft.AspNetCore.Authorization;

namespace XCartBackEnd.Controllers.Admin
{
    [Route("Admin/products")]
    [ApiController]
    [Authorize(Roles = "admin")]
    public class ProductsOperationsController : ControllerBase
    {
        ProductsOperationsBL productsoperationsbl;
        public ProductsOperationsController(DbXCART db)
        {
            productsoperationsbl = new ProductsOperationsBL(db);
        }
        
        [HttpGet("allproducts")]
        public IEnumerable<PRODUCTS> Get()
        {
            return productsoperationsbl.GetAllProducts() ;
        }

        [HttpGet("alldeactiveproducts")]
        public IEnumerable<PRODUCTS> GetDeactive()
        {
            return productsoperationsbl.GetDeactiveProducts();
        }


        [HttpGet("product/{id}")]
        public PRODUCTS Get(int id)
        {
            return productsoperationsbl.ProductWithId(id);
        }
        [HttpGet("category/{category}")]
        public IEnumerable<PRODUCTS> ProductsOfcategory(string category)
        {
            return productsoperationsbl.ProductsOfcategory(category);
        }


        [HttpPost("create")]
        public int Post(PRODUCTS product)
        {
            return productsoperationsbl.AddProduct(product);
        }

        
        [HttpPut("edit")]
        public int Put( PRODUCTS product)
        {
            return productsoperationsbl.ModifyProduct(product);
        }

        [HttpDelete("delete/{id}")]
        public int Delete(int id)
        {
            return productsoperationsbl.DiscardProduct(id);
        }

        [HttpDelete("active/{id}")]
        public int Activate(int id)
        {
            return productsoperationsbl.Activate(id);
        }
    }
}
