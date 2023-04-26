using Atividade2.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace Atividade2.Controllers
{
    public class PersonalController : Controller
    {
        public Contexto context { get; set; }
        public static IList<Personal> listaPersonais = new List<Personal>() { };
        public IActionResult Index()
        {
            return View(listaPersonais);
        }
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Personal pers)
        {
            listaPersonais.Add(pers);
            pers.PersonalId = listaPersonais.Select(p => p.PersonalId).Max() + 1;
            return RedirectToAction("Index");
        }
        public IActionResult Edit(int id)
        {
            var personais = context.Personais.Find(id);
            ViewBag.TreinoId = new SelectList(context.Personais.OrderBy(p => p.PersonalId), "PersonalId", "Nome do Personal");
            return View(personais);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(Personal pers)
        {
            context.Entry(pers).State = EntityState.Modified;
            context.SaveChanges();
            return RedirectToAction("Index");
        }
        public IActionResult Delete(int id)
        {
            var personais = context.Personais.Include(p => p.PersonalId).FirstOrDefault(p => p.PersonalId == id);
            return View(personais);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Delete(Personal pers)
        {
            context.Remove(pers);
            context.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}
