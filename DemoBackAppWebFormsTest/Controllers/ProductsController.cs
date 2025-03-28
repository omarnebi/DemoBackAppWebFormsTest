using DemoBackAppWebFormsTest.BLL.IService;
using DemoBackAppWebFormsTest.DAL.Models;
using System;
using System.Collections.Generic;
using System.Web.Http;

namespace DemoBackAppWebFormsTest.Controllers
{
    public class ProductsController : ApiController
    {
        private readonly IProductService _productService;

        public ProductsController(IProductService productService)
        {
            _productService = productService;
        }

        /// <summary>
        /// Get all Products.
        /// </summary>
        [HttpGet]
        [Route("api/products")]
        public IHttpActionResult GetAllProducts()
        {
            try
            {
                List<Product> AllProducts = _productService.GetAll();
                return Ok(AllProducts);
            }
            catch (Exception ex)
            {
                return InternalServerError(ex);
            }
        }

        /// <summary>
        /// Get Product by ID.
        /// </summary>
        [HttpGet]
        [Route("api/products/{id}")]
        public IHttpActionResult GetProductById(int id)
        {
            try
            {
                Product CurentProduct = _productService.GetById(id);
                return Ok(CurentProduct);
            }
            catch (KeyNotFoundException ex)
            {
                return NotFound();
            }
            catch (Exception ex)
            {
                return InternalServerError(ex);
            }
        }

        /// <summary>
        /// Create Product.
        /// </summary>
        [HttpPost]
        [Route("api/products")]
        public IHttpActionResult AddProduct([FromBody] Product Product)
        {
            try
            {
                if (Product == null)
                    return BadRequest("Product data is required");

                _productService.Add(Product);
                return Ok(" new product created");
            }
            catch (ArgumentException ex)
            {
                return BadRequest(ex.Message);
            }
            catch (Exception ex)
            {
                return InternalServerError(ex);
            }
        }

        /// <summary>
        /// Edit curent product.
        /// </summary>
        [HttpPut]
        [Route("api/products/{id}")]
        public IHttpActionResult EditProduct(int id, [FromBody] Product Product)
        {
            try
            {
                if (Product == null)
                    return BadRequest("Product attributes is required");

                if (id != Product.Id)
                    return BadRequest("Product is not  found");

                _productService.Edit(Product);
                return Ok("Product updated with new data");
            }
            catch (KeyNotFoundException ex)
            {
                return NotFound();
            }
            catch (Exception ex)
            {
                return InternalServerError(ex);
            }
        }

        /// <summary>
        /// remove  object product by Id.
        /// </summary>
        [HttpDelete]
        [Route("api/products/{id}")]
        public IHttpActionResult RemoveProductById(int id)
        {
            try
            {
                _productService.Remove(id);
                return Ok("Product by id removed");
            }
            catch (KeyNotFoundException ex)
            {
                return NotFound();
            }
            catch (Exception ex)
            {
                return InternalServerError(ex);
            }
        }
    }
}
