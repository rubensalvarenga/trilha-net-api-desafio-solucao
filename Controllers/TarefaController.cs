using App.MVC.Desafio.Context;
using App.MVC.Desafio.Models;
using Microsoft.AspNetCore.Mvc;

namespace App.MVC.Desafio.Controllers
{
    public class TarefaController : Controller
    {
        private readonly AgendaContext _context;

        public TarefaController(AgendaContext context)
        {

            _context = context;
        }
        public IActionResult Index()
        {
            var tarefa = _context.Tarefas.ToList();

            return View(tarefa);
        }

        public IActionResult Criar()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Criar(Tarefa tarefa)
        {
            if (ModelState.IsValid)
            {
                _context.Tarefas.Add(tarefa);
                _context.SaveChanges();
                return RedirectToAction("Index");

            }
            return View(tarefa);
        }

        public IActionResult Detalhes(int id)
        {
            var tarefa = _context.Tarefas.Find(id);

            if (tarefa == null)
            {
                return RedirectToAction(nameof(Index));
            }

            return View(tarefa);
        }

        public IActionResult Editar(int id)
        {
            var tarefa = _context.Tarefas.Find(id);

            if (tarefa == null)
            {
                return RedirectToAction(nameof(Index));
            }

            return View(tarefa);
        }

        [HttpPost]
        public IActionResult Editar(Tarefa tarefa)
        {
            var tarefaBanco = _context.Tarefas.Find(tarefa.Id);

            tarefaBanco.Titulo = tarefa.Titulo;
            tarefaBanco.Descricao = tarefa.Descricao;
            tarefaBanco.Data = tarefa.Data;
            tarefaBanco.Status = tarefa.Status;

            _context.Tarefas.Update(tarefaBanco);
            _context.SaveChanges();

            return RedirectToAction(nameof(Index));
        }

        public IActionResult Excluir(int id)
        {
            var tarefa = _context.Tarefas.Find(id);

            if (tarefa == null)
            {
                return RedirectToAction(nameof(Index));
            }

            return View(tarefa);

        }

        [HttpPost]
        public IActionResult Excluir(Tarefa tarefa)
        {
            var tarefaBanco = _context.Tarefas.Find(tarefa.Id);

            _context.Tarefas.Remove(tarefaBanco);
            _context.SaveChanges();

            return RedirectToAction(nameof(Index));

        }

        
        public IActionResult PesquisaTitulo(string titulo)
        {
               var tarefas = _context.Tarefas.Where(x => x.Titulo.Contains(titulo)).ToList();
              
            return View(tarefas);

        }

        public IActionResult PesquisaData(DateTime data, DateTime data1)
        {
            
            var tarefas = _context.Tarefas.Where(x => x.Data >= data && x.Data <= data1).ToList();
          
            return View(tarefas);

        }

        public IActionResult PesquisaStatus(EnumTarefa status)
        {

            var tarefas = _context.Tarefas.Where(x => x.Status == status).ToList();

            return View(tarefas);

        }

    }
}
