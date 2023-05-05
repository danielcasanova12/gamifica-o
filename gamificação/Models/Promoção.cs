using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using gamificacao.Enums;

namespace gamificacao.Models
{
    public class Promocao
    {
        public decimal ValorDesconto { get; set; }
        public TipoDesconto TipoDesconto { get; set; }
        public List<Produto> Produtos { get; set; } = new List<Produto>();

        public decimal CalcularDesconto(Produto produto)
        {
            if (!Produtos.Contains(produto))
            {
                return 0;
            }

            if (TipoDesconto == TipoDesconto.Porcentagem)
            {
                return produto.Preco * ValorDesconto / 100;
            }
            else if (TipoDesconto == TipoDesconto.ValorFixo)
            {
                return ValorDesconto;
            }

            return 0;
        }
    }
}
