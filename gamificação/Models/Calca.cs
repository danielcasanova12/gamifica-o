using Gamificacao.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gamificacao.Models
{
    public class Calca : ProdutoModel
    {
        public TamanhoRoupa Tamanho { get; set; }
        public CorRoupa Cor { get; set; }

        public Calca(TamanhoRoupa tamanho, CorRoupa cor, long produtoID, string codigo, string nome, decimal preco,
            decimal desconto, CategoriaEnum categoria) : base(produtoID, codigo, nome, preco, desconto,categoria)
        {
            Tamanho = tamanho;
            Cor = cor;

        }

        public override decimal CalcularValorDoDesconto(Promocao? promocao)
        {
            decimal desconto = 0;

            if (promocao == null)
            {
                return desconto;
            }



            if (promocao.TipoDesconto == TipoDesconto.Porcentagem)
            {
                // desconto de porcentagem específico para camisetas
                desconto = (promocao.ValorDesconto / 100) * Preco;
            }
            else if (promocao.TipoDesconto == TipoDesconto.ValorFixo)
            {
                // desconto de valor fixo específico para camisetas
                desconto = promocao.ValorDesconto;
            }

            return desconto;

        }

    }
}
