using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Gamificacao.Enums;

namespace Gamificacao.Models
{
    public class Calcado : Acessorio
    {

        public TamanhoSapato TamanhoSapato { get; set; }
        public string Marca { get; set; }

        public Calcado(TamanhoSapato tamanhoSapato, string marca,
            TamanhoAcessorio tamanhoAcessorio,
            long produtoID, string codigo, string nome, decimal preco, decimal desconto,
            CorAcessorio corAcessorio, CategoriaEnum categoria) : base(corAcessorio,
                produtoID, codigo, nome, preco, desconto,categoria)
        {
            TamanhoSapato = tamanhoSapato;
            Marca = marca;
        }
    }

}
