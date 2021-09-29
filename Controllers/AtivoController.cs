using CadastroEstoque.DTOs;
using CadastroEstoque.Service;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace CadastroEstoque.Controllers
{
    public class AtivoController : Controller
    {
        private readonly IAtivoService service;

        private readonly ICategoriaService serv;

        public AtivoController(IAtivoService service, ICategoriaService serv)
        {
            this.service = service;
            this.serv = serv;
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

        public  async Task<IActionResult> Create()
        {
            var dto = new AtivoDTO();
            dto.Categorias = (await serv.GetAllAsync()).ToList();
            return View(dto);
        }

        [HttpGet]
        [Route("obterLista")]
        public async Task<IActionResult> ObterLista()
        {
            return Ok(await service.GetAllAsync());
        }

        [HttpPost]        
        public async Task<IActionResult> Create(AtivoDTO dto)
        {
            if (ModelState.IsValid)
            {
                await service.AddAsync(dto);
                return Json(new { success = true });
            }

            return Json(new { success = false, erros = ModelState.Select(s => new
                {
                    s.Key,
                    Valid = s.Value.ValidationState == Microsoft.AspNetCore.Mvc.ModelBinding.ModelValidationState.Invalid ? false : true,
                    msg = s.Value.Errors.FirstOrDefault(),
                    
                })
            });
        }

        public async Task<IActionResult> Edit(Guid id)
        {
            var edicoes = await service.GetByIdAsync(id);
            return View(edicoes);
        }

        [HttpPost]
        public async Task<IActionResult> Update(AtivoDTO ativo)
        {
            var edicoes = await service.UpdateAsync(ativo);
            return RedirectToAction("List");
        }

        public async Task<IActionResult> Details(Guid id)
        {
            if (id != Guid.Empty)
            {
                var edicoes = await service.GetByIdAsync(id);

                var days = (DateTime.Now - edicoes.DataCompra).Days / 30;
                var taxaMes = edicoes.Categoria.Taxa / 12;
                var taxaReal = taxaMes * days;
                var dep = (taxaReal * edicoes.ValorProduto) / 100;
                var valorDepre = edicoes.ValorProduto - dep;
                edicoes.Depreciacao = valorDepre;
                return View(edicoes);
            }
            else
                return View();
        }


        public async Task<IActionResult> Delete(Guid id)
        {
            if (id != Guid.Empty)
            {
                var edicoes = await service.GetByIdAsync(id);
                return View(edicoes);
            }
            return View(new AtivoDTO());
        }

        [HttpPost]
        public async Task<IActionResult> Deletar(Guid id)
        {
            var edicoes = await service.Delete(id);
            return Json(new { success = true });
        }
        
    }
}
