using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ProyectoProem.Models;

namespace ProyectoProem.Controllers
{
    public class ClientesController : Controller 
    {
        ProyectDB _dbContext;
        public ClientesController(ProyectDB dbContext)
        {
            this._dbContext = dbContext;
        }

        public IActionResult Index(string id, int codigo, string nombre, string direccion)
        {
            if (int.TryParse(id, out int Id))
            {
                _dbContext.Add(new Clientes(Id, codigo, nombre, direccion));
                _dbContext.SaveChanges();
            }
            return View();
        }

        public IActionResult ListaClientes(string valor)
        {
            var model = new ClientesListModel();
            var query = _dbContext.Clientes.AsQueryable();
            if (!string.IsNullOrEmpty(valor))
            {
                query = query.Where(x => x.Nombre.Contains(valor));
            }
            model.Clientes = query.ToList();
            return View(model);
        }
        public IActionResult Editar(string id)
        {
            Clientes model;
            int.TryParse(id, out int Id);
            if (int.Parse(id) == 0)
            {
                model = new();
            }
            else
            {
                model = _dbContext.Clientes.Find(Id);
            }

            if (model != null)
            {
                return View(model);
            }

            return RedirectToAction("ListaClientes");
        }
        [HttpPost]
        public IActionResult Editar(Clientes model)
        {
            Clientes modelAux;
            if(model is not null)
            {
                if(model.Id == 0)
                {
                    _dbContext.Clientes.Add(model);
                }
                else
                {
                    _dbContext.Clientes.Attach(model);
                    _dbContext.Entry(model).State = EntityState.Modified;

                }
            }
            _dbContext.SaveChanges();

            return RedirectToAction("ListaClientes");
        }
        public IActionResult Eliminar(int id)
        {
            Clientes model;
            model = _dbContext.Clientes.ToList().Find(x => x.Id == id);
            _dbContext.Clientes.Remove(model);
            _dbContext.Entry(model).State = EntityState.Deleted;
            _dbContext.SaveChanges();
            return RedirectToAction("ListaClientes");
        }
        //public IActionResult Eliminar(Clientes model)
        //{
        //    if (model is not null)
        //    {
        //        _dbContext.Clientes.Remove(model);
        //        _dbContext.Entry(model).State = EntityState.Deleted;
        //        _dbContext.SaveChanges();
        //    }
        //    return RedirectToAction("ListaClientes");
        //}
    }
}
