using DemoBackAppWebFormsTest.BLL;
using DemoBackAppWebFormsTest.BLL.IService;
using DemoBackAppWebFormsTest.DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace DemoBackAppWebFormsTest.Controllers
{
    public class CategoriesController : ApiController
    {
        private readonly ICategoryService _service;

        public CategoriesController(ICategoryService service)
        {
            _service = service;
        }

        /// <summary>
        /// Retrieves all categories.
        /// </summary>
        [HttpGet]
        [Route("api/categories")]
        public IHttpActionResult GetCategories()
        {
            try
            {
                List<Category> categories = _service.GetAllCategories();
                return Ok(categories);
            }
            catch (Exception ex)
            {
                return InternalServerError(ex);
            }
        }

        /// <summary>
        /// Retrieves a specific category by ID.
        /// </summary>
        [HttpGet]
        [Route("api/categories/{id}")]
        public IHttpActionResult GetCategory(int id)
        {
            try
            {
                Category category = _service.GetCategory(id);
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
        /// Creates a new category.
        /// </summary>
        [HttpPost]
        [Route("api/categories")]
        public IHttpActionResult CreateCategory([FromBody] Category category)
        {
            try
            {
                if (category == null)
                    return BadRequest("Category data is required.");

                _service.CreateCategory(category);
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
        /// Updates an existing category.
        /// </summary>
        [HttpPut]
        [Route("api/categories/{id}")]
        public IHttpActionResult UpdateCategory(int id, [FromBody] Category category)
        {
            try
            {
                if (category == null)
                    return BadRequest("Category data is required.");

                if (id != category.Id)
                    return BadRequest("Category ID mismatch.");

                _service.UpdateCategory(category);
                return Ok("Category updated successfully.");
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
        /// Deletes a category by ID.
        /// </summary>
        [HttpDelete]
        [Route("api/categories/{id}")]
        public IHttpActionResult DeleteCategory(int id)
        {
            try
            {
                _service.RemoveCategory(id);
                return Ok("Category deleted successfully.");
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
