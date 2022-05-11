using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Proyecto_Proem.Models;
using ProyectoProem.Models;

namespace ProyectoProem.Controllers
{
    public class FacturasController : Controller
    {
        ProyectDB _dbContext;
        public FacturasController(ProyectDB dbContext)
        {
            this._dbContext = dbContext;
        }
        public IActionResult Index(string id, int clienteid, int numero, DateTime fecha, List<Items> items)
        {
            if (int.TryParse(id, out int Id))
            {
                _dbContext.Facturas.Add(new Facturas(Id, clienteid, numero, fecha, items));
                _dbContext.SaveChanges();
            }
                return View();
        }

        public IActionResult ListaFacturas(string valor)
        {
            var model = new FacturasListModel();
            var query = _dbContext.Facturas.AsQueryable();
            if (!string.IsNullOrEmpty(valor))
            {
                query = query.Where(x => x.Numero == int.Parse(valor));
            }
            model.Facturas = query.ToList();
            foreach (var item in model.Facturas)
            {
                item.Cliente = _dbContext.Clientes.Find(item.ClienteId);
            }
            return View(model);
        }

        [HttpPost]
        public IActionResult Editar(Facturas model, List<Items> items)
        {
            if(model is not null)
            {
                if(model.Id == 0)
                {
                    model.Items = items;
                    _dbContext.Facturas.Add(model);
                }
                else
                {
                    _dbContext.Facturas.Attach(model);
                    _dbContext.Entry(model).State = EntityState.Modified;
                    _dbContext.SaveChanges();
                }
            }

            return RedirectToAction("ListaFacturas");   
        }
        public IActionResult Editar(int Suiposito)
        {
            Facturas model;
            if (Suiposito == 0)
            {
                model = new();
            }
            else
            {
                model = _dbContext.Facturas.ToList().Find(x => x.Id == Suiposito);
            }

            List<KeyValuePair<int, string>> tipos = new();
            foreach (var item in _dbContext.Clientes)
            {
                tipos.Add(new KeyValuePair<int, string>(item.Id, item.Nombre));
            }
            SelectList items = new(tipos, "Key", "Value");

            ViewBag.Tipos = items;

            if (model != null)
            {
                return View(model); 
            }
            return RedirectToAction("ListaFacturas");
        }

        
        //public IActionResult Eliminar()
        //{

        //}
    }
}
