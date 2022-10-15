using System.Collections.Generic;
using ChemQuizWeb.Core.Entities;
using ChemQuizWeb.Core.Interfaces.Services;
using Microsoft.AspNetCore.Mvc;

namespace ChemQuizWeb.Controllers.API
{

    [Route("api/[controller]")]
    [ApiController]
    public class CategoryController : Controller
    {
        private IService<Category> categoryService;

        public CategoryController(IService<Category> _categoryService)
        {
            categoryService = _categoryService;
        }

        [HttpGet]
        [ProducesResponseType(typeof(List<Category>), 200)]
        public IActionResult Get() => Ok(categoryService.FindAll());
    }
}
