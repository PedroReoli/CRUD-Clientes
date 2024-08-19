using Microsoft.AspNetCore.Mvc;
using SeuProjeto.Models;
using System.Collections.Generic;
using System.Linq;

namespace SeuProjeto.Controllers
{
    public class HomeController : Controller
    {
        private static List<Cliente> clientes = new List<Cliente>();

        // Método para listar todos os clientes
        public IActionResult Index()
        {
            return View(clientes);  // Vai buscar a view em /Views/Home/Index.cshtml
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();  // Vai buscar a view em /Views/Home/Create.cshtml
        }

        [HttpPost]
        public IActionResult Create(Cliente cliente)
        {
            if (cliente != null)
            {
                cliente.Id = clientes.Count > 0 ? clientes.Max(c => c.Id) + 1 : 1;
                clientes.Add(cliente);
                return RedirectToAction("Index");
            }
            return View(cliente);
        }

        [HttpGet]
        public IActionResult Edit(int id)
        {
            var cliente = clientes.FirstOrDefault(c => c.Id == id);
            if (cliente == null)
            {
                return NotFound();
            }
            return View(cliente);  // Vai buscar a view em /Views/Home/Edit.cshtml
        }

        [HttpPost]
        public IActionResult Edit(Cliente cliente)
        {
            var clienteExistente = clientes.FirstOrDefault(c => c.Id == cliente.Id);
            if (clienteExistente != null)
            {
                clienteExistente.Nome = cliente.Nome;
                clienteExistente.Email = cliente.Email;
                clienteExistente.Telefone = cliente.Telefone;
                clienteExistente.Endereco = cliente.Endereco;
                return RedirectToAction("Index");
            }
            return View(cliente);
        }

        public IActionResult Details(int id)
        {
            var cliente = clientes.FirstOrDefault(c => c.Id == id);
            if (cliente == null)
            {
                return NotFound();
            }
            return View(cliente);  // Vai buscar a view em /Views/Home/Details.cshtml
        }

        [HttpGet]
        public IActionResult Delete(int id)
        {
            var cliente = clientes.FirstOrDefault(c => c.Id == id);
            if (cliente == null)
            {
                return NotFound();
            }
            return View(cliente);  // Vai buscar a view em /Views/Home/Delete.cshtml
        }

        [HttpPost]
        public IActionResult DeleteConfirmed(int id)
        {
            var cliente = clientes.FirstOrDefault(c => c.Id == id);
            if (cliente != null)
            {
                clientes.Remove(cliente);
                return RedirectToAction("Index");
            }
            return NotFound();
        }
    }
}
