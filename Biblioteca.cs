using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BibliotecaOOP
{
    public class Biblioteca
    {
        private List<Pessoa> Pessoas { get; set; }
        private List<Livro> Livros { get; set; }

        public Biblioteca(List<Pessoa> pessoas, List<Livro> livros)
        {
            Pessoas = pessoas;
            Livros = livros;
        }

        public void CadastrarPessoa(Pessoa novaPessoa)
        {
            if (Pessoas == null)
                Pessoas = new List<Pessoa>();
            Pessoas.Add(novaPessoa);
        }

        public bool PessoaJaCadastrada(int idPessoa)
        {
            // se for null significa que não existe ainda
            return ConsultarPessoaPorId(idPessoa) != null;
        }

        public void CadastrarLivro(Livro novoLivro)
        {
            if (Livros == null)
            {
                Livros = new List<Livro>();
            }
            Livros.Add(novoLivro);
        }

        public bool LivroJaCadastrado(int idLivro)
        {
            // se for null significa que não existe ainda
            return ConsultarLivroPorId(idLivro) != null;
        }

        public void EmprestarLivroBiblioteca(int idLivro, int idPessoa)
        {
            Livro novoLivro = ConsultarLivroPorId(idLivro);
            Pessoa pessoa = ConsultarPessoaPorId(idPessoa);
            novoLivro.EmprestarLivro(1);
            if (pessoa != null)
                pessoa.AdicionarLivroLista(novoLivro);
        }

        public void DevolverLivroBiblioteca(int idLivro, int idPessoa)
        {
            Pessoa pessoa = ConsultarPessoaPorId(idPessoa);
            Livro novoLivro = ConsultarLivroPorId(idLivro);
            novoLivro.DevolverLivro(1);
            if (pessoa == null)
            {
                return;
            }
            else
            {
                pessoa.RemoverLivroLista(idLivro);
            }
        }

        public Livro ConsultarLivroPorId(int id)
        {
            return
                Livros.Where(idLivro =>
                    idLivro.ObterIdLivro() == id).FirstOrDefault();
        }

        public Pessoa ConsultarPessoaPorId(int id)
        {
            return
                Pessoas.Where(idPessoa =>
                    idPessoa.ObterIdPessoa() == id).FirstOrDefault();
        }

        public void ListarPessoas()
        {

            foreach (var pessoa in Pessoas)
            {
                Console.WriteLine(pessoa.ObterNomePessoa());
            }
        }

        public void ListarLivros()
        {

            foreach (var livro in Livros)
            {
                Console.WriteLine($"Título: {livro.Titulo}\n" +
                    $"Quantidade de exemplar(es) disponíveis para empréstimo: {livro.ObterQntExemplaresAtual()}\n" +
                    $"Quantidade de exemplar(es) total: {livro.ObterQntExemplaresTotal()}\n");
            }
        }

        public void ListarLivrosEmprestados(int idPessoa)
        {
            Pessoa pessoa = ConsultarPessoaPorId(idPessoa);

            if (pessoa.ObterLivrosEmprestados() == null || pessoa.ObterLivrosEmprestados().Count <= 0)
            {
                Console.WriteLine("Não há livros a listar.");
            }
            else
            {
                Console.WriteLine($"Lista de livros emprestados para {pessoa.ObterNomePessoa()}");
                foreach (var livro in pessoa.ObterLivrosEmprestados())
                {
                    Console.WriteLine($"Título: {livro.Titulo}, Autor: {livro.Autor}");
                }
            }
        }

        public void ListarTodosLivrosEmprestados()
        {
            bool haLivros = false;

            foreach (var pessoa in Pessoas)
            {
                if (pessoa.ObterLivrosEmprestados() == null || pessoa.ObterLivrosEmprestados().Count == 0)
                {
                    continue;
                }
                foreach (var livro in pessoa.ObterLivrosEmprestados())
                {
                    Console.WriteLine($"{livro.Titulo} está emprestado para {pessoa.ObterNomePessoa()}.");
                    haLivros = true;
                }
            }

            if (haLivros == false)
            {
                Console.WriteLine("Não há livros emprestados.");
            }
        }

        public List<Pessoa> ObterPessoas()
        {
            return Pessoas;
        }
    }
}
