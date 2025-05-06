
using Microsoft.EntityFrameworkCore;
using ControleDeContatos.Models;

namespace ControleDeContatos.Data
   
{
    //A classe DbContext é como uma ponte entre o sistema e o Banco de Dados, nela se encontram a representação das tabelas existentes.
    public class BancoContext : DbContext
    {
        public BancoContext(DbContextOptions<BancoContext> options) : base(options)
        {

        }

        //Tabela de Contatos, sendo do tipo ContatoModel e usando seus atributos como as colunas da tabela
        public DbSet<ContatoModel> Contatos { get; set; }

    }
}
