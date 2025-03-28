using DemoBackAppWebFormsTest.BLL.IService;
using DemoBackAppWebFormsTest.DAL.Models;
using System;
using System.Collections.Generic;

using System.Web.Http;


namespace DemoBackAppWebFormsTest.Controllers
{
    public class CategoriesController : ApiController
    {
        
        private readonly ICategoryService _categroyservice;

       
        public CategoriesController(ICategoryService service)
        {
            _categroyservice = service;
        }

        /// <summary>
        /// Get all categories.
        /// </summary>
       
        [HttpGet]
        [Route("api/categories")]
        public IHttpActionResult GetAllCategories()
        {
            try
            {

                
                List<Category> categories = _categroyservice.GetAll();
                return Ok(categories);
            }
            catch (Exception ex)
            {
                return InternalServerError(ex);
            }
        }

        /// <summary>
        ///  Get curent category by ID.
        /// </summary>
      
        [HttpGet]
        [Route("api/categories/{id}")]
        public IHttpActionResult GetCategoryById(int id)
        {
            try
            {

                Category category = _categroyservice.GetById(id);
                return Ok(category);

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
        /// Create a new category.
        /// </summary>
      
        [HttpPost]
        [Route("api/categories")]
        public IHttpActionResult AddCategory([FromBody] Category category)
        {
            try
            {
                if (category == null)
                    return BadRequest("Category attributes is required.");

                _categroyservice.Add(category);
                return Ok("Category created successfully.");
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
        /// Edit curent category.
        /// </summary>
      
        [HttpPut]
        [Route("api/categories/{id}")]
        public IHttpActionResult EditCategory(int id, [FromBody] Category category)
        {
            try
            {
                if (category == null)
                    return BadRequest("give all attributes of categrory");

                if (id != category.Id)
                    return BadRequest("Category id  is not found");

                _categroyservice.Edit(category);
                return Ok("Category edited");
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
        /// Delete curent category  by id
        /// </summary>
      
        [HttpDelete]
        [Route("api/categories/{id}")]
        public IHttpActionResult RemoveCategory(int id)
        {
            try
            {
                _categroyservice.Remove(id);
                return Ok("Category by id Removed");
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
