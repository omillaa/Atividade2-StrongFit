using Atividade2.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace Atividade2.Controllers
{
    public class AlunoController : Controller
    {
        public Contexto context { get; set; }
        public static IList<Aluno> listaAlunos = new List<Aluno>() { };
        public IActionResult Index()
        {
            return View(listaAlunos);
        }
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Aluno al)
        {
            listaAlunos.Add(al);
            al.AlunoId = listaAlunos.Select(m => m.AlunoId).Max() + 1;
            return RedirectToAction("Index");
        }
        public IActionResult Details(int id)
        {
            var alunos = context.Alunos.Include(p => p.Personal).FirstOrDefault(e => e.AlunoId == id);
            return View(alunos);
        }
        public IActionResult Edit(int id)
        {
            var alunos = context.Alunos.Find(id);
            ViewBag.PersonalId = new SelectList(context.Personais.OrderBy(p => p.PersonalId), "AlunoId", "Nome do Aluno");
            return View(alunos);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(Aluno al)
        {
            context.Entry(al).State = EntityState.Modified;
            context.SaveChanges();
            return RedirectToAction("Index");
        }
        public IActionResult Delete(int id)
        {
            var alunos = context.Alunos.Include(p => p.Personal).FirstOrDefault(a => a.AlunoId == id);
            return View(alunos);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Delete(Aluno al)
        {
            context.Remove(al);
            context.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}
