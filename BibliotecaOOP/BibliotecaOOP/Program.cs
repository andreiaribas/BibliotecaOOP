using System.Collections.Generic;

namespace BibliotecaOOP
{
    internal class Program
    {
        static void Main(string[] args)
        {

            Biblioteca novaBiblioteca1 = new Biblioteca(new List<Pessoa>(), new List<Livro>());


            string opcao = "";

            do
            {
                Console.WriteLine(@"

  -----------------------------------------------------------------------

        Para escolher uma opção, digite o número correspondente:

        1 - Cadastrar Pessoa
        2 - Cadastrar Livro
        3 - Adicionar exemplares a um livro já cadastrado
        4 - Emprestar Livro
        5 - Devolver Livro
        6 - Listar todos os livros
        7 - Listar todas as pessoas cadastradas
        8 - Listar todos livros emprestados
        9 - Listar livros emprestados para uma pessoa
        0 - SAIR

  -----------------------------------------------------------------------

        ");

                opcao = Console.ReadLine();
                Console.WriteLine("\n");

                switch (opcao)
                {
                    case "1":
                        Console.WriteLine("Para cadastrar a pessoa, digite os seguintes dados:");
                        Console.Write("ID:");
                        int idPessoa = int.Parse(Console.ReadLine());

                        if (novaBiblioteca1.PessoaJaCadastrada(idPessoa))
                        {
                            Console.WriteLine("\nEssa pessoa já está cadastrada");
                            break;
                        }

                        Console.Write("Nome:");
                        string nome = Console.ReadLine();

                        Console.Write("CPF:");
                        string cpf = Console.ReadLine();

                        Console.Write("Telefone:");
                        string tel = Console.ReadLine();

                        Pessoa novaPessoa = new Pessoa(idPessoa, nome, cpf, tel);
                        novaBiblioteca1.CadastrarPessoa(novaPessoa);
                        Console.WriteLine("\nPessoa cadastrada");
                        break;

                    case "2":
                        Console.WriteLine("Para cadastrar um livro, digite os seguintes dados:");
                        Console.Write("ID: ");
                        int idLivro = int.Parse(Console.ReadLine());

                        if (novaBiblioteca1.LivroJaCadastrado(idLivro))
                        {
                            Console.WriteLine("\nEsse livro já está cadastrado");
                            break;
                        }

                        Console.Write("Título: ");
                        string titulo = Console.ReadLine();

                        Console.Write("Autor: ");
                        string autor = Console.ReadLine();

                        Console.Write("Editora: ");
                        string editora = Console.ReadLine();

                        Console.Write("Quantidade de exemplares: ");
                        int exemplares = int.Parse(Console.ReadLine());

                        Livro novoLivro = new Livro(idLivro, titulo, autor, editora, exemplares, exemplares);
                        novaBiblioteca1.CadastrarLivro(novoLivro);
                        Console.WriteLine("\nLivro cadastrado");
                        break;

                    case "3":
                        Console.WriteLine("Para adicionar exemplares, digite os seguintes dados:");
                        Console.Write("ID do livro: ");
                        int idLivro2 = int.Parse(Console.ReadLine());

                        if (!(novaBiblioteca1.LivroJaCadastrado(idLivro2)))
                        {
                            Console.WriteLine("\nEsse livro não está cadastrado.");
                            break;
                        }

                        Console.Write("Quantidade de exemplares a adicionar: ");
                        int exemplares1 = int.Parse(Console.ReadLine());

                        Livro livroIdCorrespondente = novaBiblioteca1.ConsultarLivroPorId(idLivro2);
                        livroIdCorrespondente.DevolverLivro(exemplares1);
                        livroIdCorrespondente.AdicionarExemplarLivro(exemplares1);
                        Console.Write($"\nAdicionado {exemplares1} exemplar(es) ao livro {livroIdCorrespondente.Titulo}.");
                        break;

                    case "4":
                        Console.WriteLine("Para emprestar um livro, digite os seguintes dados:");
                        Console.Write("ID do livro: ");
                        int idLivro3 = int.Parse(Console.ReadLine());

                        if (!(novaBiblioteca1.LivroJaCadastrado(idLivro3)))
                        {
                            Console.WriteLine("\nEsse livro não está cadastrado");
                            break;
                        }
                        if (novaBiblioteca1.ConsultarLivroPorId(idLivro3).ObterQntExemplaresAtual() <= 0)
                        {
                            Console.WriteLine($"\nEsse livro não está disponível. Está emprestado para outra pessoa.");
                            break;
                        }

                        Console.Write("ID da pessoa: ");
                        int idPessoa2 = int.Parse(Console.ReadLine());

                        if (!(novaBiblioteca1.PessoaJaCadastrada(idPessoa2)))
                        {
                            Console.WriteLine("\nEssa pessoa não está cadastrada");
                            break;
                        }
                        novaBiblioteca1.EmprestarLivroBiblioteca(idLivro3, idPessoa2);
                        Console.WriteLine($"\nLivro {novaBiblioteca1.ConsultarLivroPorId(idLivro3).Titulo} emprestado para {novaBiblioteca1.ConsultarPessoaPorId(idPessoa2).ObterNomePessoa()}.");

                        break;

                    case "5":
                        Console.WriteLine("Para devolver um livro, digite os seguintes dados:");
                        Console.Write("ID do livro: ");
                        int idLivro4 = int.Parse(Console.ReadLine());

                        if (!(novaBiblioteca1.LivroJaCadastrado(idLivro4)))
                        {
                            Console.WriteLine("\nEsse livro não está cadastrado");
                            break;
                        }

                        Console.Write("ID da pessoa: ");
                        int idPessoa3 = int.Parse(Console.ReadLine());

                        if (!(novaBiblioteca1.PessoaJaCadastrada(idPessoa3)))
                        {
                            Console.WriteLine("\nEssa pessoa não está cadastrada");
                            break;
                        }

                        var livrosEmprestados = novaBiblioteca1.ConsultarPessoaPorId(idPessoa3).ObterLivrosEmprestados();
                        if (livrosEmprestados == null || livrosEmprestados.Count == 0)
                        {
                            Console.WriteLine("\nNão há livros a serem devolvidos!");
                            break;
                        }
                        novaBiblioteca1.DevolverLivroBiblioteca(idLivro4, idPessoa3);
                        Console.WriteLine($"\nLivro {novaBiblioteca1.ConsultarLivroPorId(idLivro4).Titulo} que estava com {novaBiblioteca1.ConsultarPessoaPorId(idPessoa3).ObterNomePessoa()} foi devolvido.");
                        break;

                    case "6":
                        Console.WriteLine("Lista de todos os livros:");
                        novaBiblioteca1.ListarLivros();
                        break;

                    case "7":
                        Console.WriteLine("Lista de todas as pessoas:");
                        novaBiblioteca1.ListarPessoas();
                        break;

                    case "8":
                        Console.WriteLine("Lista de todos os livros emprestados:");
                        novaBiblioteca1.ListarTodosLivrosEmprestados();
                        break;

                    case "9":
                        Console.WriteLine("Para listar os livros que alguém pegou emprestado, digite:");
                        Console.Write("ID da pessoa: ");
                        int idPessoa4 = int.Parse(Console.ReadLine());

                        if (!(novaBiblioteca1.PessoaJaCadastrada(idPessoa4)))
                        {
                            Console.WriteLine("\nEssa pessoa não está cadastrada");
                            break;
                        }

                        novaBiblioteca1.ListarLivrosEmprestados(idPessoa4);
                        break;
                }
            } while (opcao != "0");
        }
    }
}