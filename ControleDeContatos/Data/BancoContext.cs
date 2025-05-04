
using Microsoft.EntityFrameworkCore;
using ControleDeContatos.Models;

namespace ControleDeContatos.Data
   
{
    public class BancoContext : DbContext
    {
        public BancoContext(DbContextOptions<BancoContext> options) : base(options)
        {

        }

        public DbSet<ContatoModel> Contatos { get; set; }

        //teste teste teste
    }
}
