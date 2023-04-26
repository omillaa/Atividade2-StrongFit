using Microsoft.AspNetCore.Mvc;
using Atividade2.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Atividade2.Controllers
{
    public class TreinoController : Controller
    {
        public Contexto context { get; set; }
        public static IList<Treino> listaTreinos = new List<Treino>() { };
        public IActionResult Index()
        {
            return View(listaTreinos);
        }
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Treino trein)
        {
            listaTreinos.Add(trein);
            trein.TreinoId = listaTreinos.Select(p => trein.TreinoId).Max() + 1;
            return RedirectToAction("Index");
        }
        public IActionResult Edit(int id)
        {
            var treinos = context.Personais.Find(id);
            ViewBag.TreinoId = new SelectList(context.Treinos.OrderBy(t => t.TreinoId), "TreinoId", "Nome do Treino");
            return View(treinos);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(Treino trein)
        {
            context.Entry(trein).State = EntityState.Modified;
            context.SaveChanges();
            return RedirectToAction("Index");
        }
        public IActionResult Delete(int id)
        {
            var treinos = context.Treinos.Include(t => t.TreinoId).FirstOrDefault(t => t.TreinoId == id);
            return View(treinos);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Delete(Treino trein)
        {
            listaTreinos.Remove(trein);
            context.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}
