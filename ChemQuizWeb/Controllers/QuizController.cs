using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ChemQuizWeb.Controllers
{
    [Authorize]
    [Route("[controller]")]
    public class QuizController : Controller
    {   
        
    }
}
