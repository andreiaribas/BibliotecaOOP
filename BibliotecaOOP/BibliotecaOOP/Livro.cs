using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace BibliotecaOOP
{
    public class Livro
    {
        private int Id { get; set; }
        public string Titulo { get; set; } 
        public string Autor { get; set; } 
        public string Editora { get; set; }
        private int QuantidadeExemplaresAtual { get; set; }

        private int QuantidadeExemplaresTotal { get; set; }

        public Livro(int id, string titulo, string autor, string editora, int quantidadeExemplaresAtual, int quantidadeExemplaresTotal)
        {
            Id = id;
            Titulo = titulo;
            Autor = autor;
            Editora = editora;
            QuantidadeExemplaresAtual = quantidadeExemplaresAtual;
            QuantidadeExemplaresTotal = quantidadeExemplaresTotal;
        }

        public void EmprestarLivro(int quantidadeEmprestada)
        {
            QuantidadeExemplaresAtual -= quantidadeEmprestada;
        }

        public void DevolverLivro(int quantidadeDevolvida)
        {
            QuantidadeExemplaresAtual += quantidadeDevolvida;
        }

        public void AdicionarExemplarLivro(int quantidadeExemplar)
        {
            QuantidadeExemplaresTotal += quantidadeExemplar;
        }

        public int ObterIdLivro()
        {
            return Id;
        }

        public int ObterQntExemplaresAtual()
        {
            return QuantidadeExemplaresAtual;
        }

        public int ObterQntExemplaresTotal()
        {
            return QuantidadeExemplaresTotal;
        }
    }
}
