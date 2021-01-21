using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ChemQuizWeb.Data;
using ChemQuizWeb.Services;
using Microsoft.AspNetCore.Authorization;
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
