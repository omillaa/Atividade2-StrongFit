using Microsoft.AspNetCore.Mvc;
using Atividade2.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Atividade2.Controllers
{
    public class ExercicioController : Controller
    {
        public Contexto context { get; set; }
        public static IList<Exercicio> listaExercicio = new List<Exercicio>(){ };
        public IActionResult Index()
        {
            return View(listaExercicio);
        }
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Exercicio exerc)
        {
            listaExercicio.Add(exerc);
            exerc.ExercicioId = listaExercicio.Select(m => m.ExercicioId).Max() + 1;
            return RedirectToAction("Index");
        }
        public IActionResult Details(int id)
        {
            var exercicios = context.Exercicio.Include(t => t.Treinos).FirstOrDefault(e => e.ExercicioId == id);
            return View(exercicios);
        }
        public IActionResult Edit(int id)
        {
            var exercicios = context.Exercicio.Find(id);
            ViewBag.TreinoId = new SelectList(context.Treinos.OrderBy(t => t.TreinoId), "TrenoId", "Nome do Exercício");
            return View(exercicios);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(Exercicio exerc)
        {
            context.Entry(exerc).State = EntityState.Modified; 
            context.SaveChanges();
            return RedirectToAction("Index");
        }
        public IActionResult Delete(int id) 
        {
            var exercicios = context.Exercicio.Include(t => t.Treinos).FirstOrDefault(e => e.ExercicioId == id);
            return View(exercicios);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Delete(Exercicio exerc)
        {
            context.Remove(exerc);
            context.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}
