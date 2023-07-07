using Microsoft.EntityFrameworkCore;
using App.MVC.Desafio.Models;

namespace App.MVC.Desafio.Context
{
    public class AgendaContext : DbContext
    {
        public AgendaContext(DbContextOptions<AgendaContext> options) : base(options)
        {

        }

        public DbSet<Tarefa> Tarefas { get; set; }
    }
}
