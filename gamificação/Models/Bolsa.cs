using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Gamificacao.Models;
using Gamificacao.Enums;
namespace Gamificacao.Models
{
    public class Bolsa : Acessorio
    {
        public string Material { get; set; }
        public int NumeroCompartimentos { get; set; }
        public TamanhoAcessorio Tamanho { get; set; }

        public Bolsa(string material, int numeroCompartimentos, TamanhoAcessorio tamanho, CorAcessorio corAcessorio,
            long produtoID, string codigo, string nome, decimal preco,
            decimal desconto, CategoriaEnum categoria) : base(corAcessorio,produtoID, codigo, nome, preco, desconto,categoria)
        {
            Tamanho = tamanho;
            Material = material;
            NumeroCompartimentos = numeroCompartimentos;
        }
    }

}
