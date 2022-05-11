using Microsoft.AspNetCore.Mvc;
using ProyectoProem.Models;

namespace ProyectoProem.Controllers
{
    public class PagosController : Controller
    {
        ProyectDB _dbContext;
        public PagosController(ProyectDB dbContext)
        {
            this._dbContext = dbContext;
        }
        public IActionResult Index()
        {
            return View();
        }
    }
}
