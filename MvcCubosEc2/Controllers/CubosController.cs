using Microsoft.AspNetCore.Mvc;
using MvcCubosEc2.Models;
using MvcCubosEc2.Repositories;

namespace MvcCubosEc2.Controllers
{
    public class CubosController : Controller
    {
        private RepositoryCubos repo;

        public CubosController(RepositoryCubos repo)
        {
            this.repo = repo;
        }

        public async Task<IActionResult> GetCubos()
        {
            List<Cubo> cubos = await this.repo.GetCubosAsync();
            return View(cubos);
        }


        [HttpGet]
        public async Task<ActionResult<Cubo>> FindCubo(int id)
        {
            Cubo cubo = await this.repo.FindCuboAsync(id);
            return View(cubo);
        }

        public IActionResult CreateCubo()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> CreateCubo(Cubo cubo)
        {
            await this.repo.CreateCuboAsync(cubo.Nombre,cubo.Marca,cubo.Imagen,cubo.Precio);
            return RedirectToAction("GetCubos");
        }

        public async Task<ActionResult<Cubo>> UpdateCubo(int id)
        {
            Cubo cubo = await this.repo.FindCuboAsync(id);
            return View(cubo);
        }

        [HttpPost]
        public async Task<ActionResult> UpdateCubo(Cubo cubo)
        {
            await this.repo.UpdateCuboAsync(cubo.IdCubo,cubo.Nombre,cubo.Marca,cubo.Imagen,cubo.Precio);
            return RedirectToAction("GetCubos");
        }

        public async Task<ActionResult> DeleteCubo(int id)
        {
            await this.repo.DeleteCuboAsync(id);
            return RedirectToAction("GetCubos");
        }
    }
}
