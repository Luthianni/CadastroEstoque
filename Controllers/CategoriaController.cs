using CadastroEstoque.DTOs;
using CadastroEstoque.Service;
using Microsoft.AspNetCore.Mvc;
using System;
using System.IO;
using System.Threading.Tasks;

namespace CadastroEstoque.Controllers
{
    public class CategoriaController : Controller
    {
        private readonly ICategoriaService service;

        public CategoriaController(ICategoriaService service)
        {
            this.service = service;
        }

        public async Task<IActionResult> Index()
        {
            var list = await service.GetAllAsync();
            return View(list);
        }

        public async Task<IActionResult> List()
        {
            var list = await service.GetAllAsync();

            return View(list);
        }
        public IActionResult Create()
        {
            return View();
        }

        [HttpGet]
        [Route("ObterTodos")]
        public async Task<IActionResult> ObterTodos()
        {
            return Ok(await service.GetAllAsync());
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(CategoriaDTO dto)
        {
            if (ModelState.IsValid)
            {
                await service.AddAsync(dto);
            }
            return RedirectToAction("List");
        }


        public async Task<IActionResult> Edit(Guid Id)
        {
            var edicoes = await service.GetByIdAsync(Id);
            return View(edicoes);
        }

        [HttpPost]
        public async Task<IActionResult> Update(CategoriaDTO categoria)
        {
            var edicoes = await service.UpdateAsync(categoria);
            return RedirectToAction("List");
            
        }

        public async Task<IActionResult> Details(Guid Id)
        {
            var edicoes = await service.GetByIdAsync(Id);
            return View(edicoes);
        }

        public async Task<IActionResult> Delete(Guid Id)
        {
            var edicoes = await service.GetByIdAsync(Id);
            return View(edicoes);
        }
        [HttpPost]
        public async Task<IActionResult> Deletar(Guid Id)
        {
            var edicoes = await service.Delete(Id);
            return RedirectToAction("List");
        }
    }
}
