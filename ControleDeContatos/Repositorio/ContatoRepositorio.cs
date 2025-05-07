using ControleDeContatos.Data;
using ControleDeContatos.Models;

namespace ControleDeContatos.Repositorio
{
    //O repositório irá se comunicar com o banco de dados por meio do BancoContext
    //Aqui se encontrará os métodos que irão manipular o banco de dados: Consulta, adição, remoção e etc

    public class ContatoRepositorio : IContatoRepositorio
    {
        //Injeção de depêndencia:
        private readonly BancoContext _bancoContext;

        //Injeção de depêndencia: Classe vai receber um contexto já instanciado pelo ASP.NET em vez de instanciar
        public ContatoRepositorio(BancoContext bancoContext)
        {
            _bancoContext = bancoContext;
        }

        public ContatoModel ListarPorId(int id)
        {
            return _bancoContext.Contatos.FirstOrDefault(x => x.Id == id);
        }

        //Criação da consulta dos contatos, vai retorna uma lista de Contatos da tabela Contatos.
        public List<ContatoModel> BuscarTodos()
        {
            //Comando LINQ para retornar uma lista do banco de dados
            return _bancoContext.Contatos.ToList();
        }

        //Criação do método de adição de dados na tabela contatos, recebendo como parâmetro um  objeto contato
        public ContatoModel Adicionar(ContatoModel contato)
        {

            _bancoContext.Contatos.Add(contato);
            _bancoContext.SaveChanges();
            return contato;
        }

        public ContatoModel Atualizar(ContatoModel contato)
        {
            ContatoModel contatoDB = ListarPorId(contato.Id);

            if (contatoDB == null) throw new System.Exception("Houve um erro na atualização do contato");

            contatoDB.Nome = contato.Nome;
            contatoDB.Email = contato.Email;
            contatoDB.Celular = contato.Celular;

            _bancoContext.Contatos.Update(contatoDB);
            _bancoContext.SaveChanges();

            return contatoDB;
        }

        public bool Apagar(int id)
        {
            ContatoModel contatoDB = ListarPorId(id);

            if (contatoDB == null) throw new System.Exception("Houve um erro na deleção do contato");

            _bancoContext.Contatos.Remove(contatoDB);
            _bancoContext.SaveChanges();

            return true;

        }

    }
}
