using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BibliotecaOOP
{
    public class Pessoa
    {
        private int Id { get; set; }
        private string Nome { get; set; }
        private string Cpf { get; set; }
        public string Telefone { get; set; }
        private List<Livro> LivrosEmprestados { get; set; }

        public Pessoa(int id, string nome, string cpf, string telefone)
        {
            Id = id;
            Nome = nome;
            Cpf = cpf;
            Telefone = telefone;
        }

        public void AdicionarLivroLista(Livro novoLivro)
        {
            if (LivrosEmprestados == null)
            {
                LivrosEmprestados = new List<Livro>();
            }

            LivrosEmprestados.Add(novoLivro);
        }

        public void RemoverLivroLista(int idLivro)
        {
            if (LivrosEmprestados == null)
            {
                return;
            }
            else
            {
                LivrosEmprestados.RemoveAll(livro => livro.ObterIdLivro() == idLivro);
            }
        }

        public int ObterIdPessoa()
        {
            return Id;
        }

        public string ObterNomePessoa()
        {
            return Nome;
        }

        public string ObterCPFPessoa()
        {
            return Cpf;
        }

        public List<Livro> ObterLivrosEmprestados()
        {
            return LivrosEmprestados;
        }

    }
}
