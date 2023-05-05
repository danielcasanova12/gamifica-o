using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using gamificacao.Enums;

namespace gamificacao.Models
{
    public abstract class Acessorio : Produto
    {
        public TamanhoAcessorio Tamanho { get; set; }
        public CorAcessorio Cor { get; set; }
        public override decimal CalcularDesconto(Promocao promocao)
        {
            decimal desconto = 0;
            if (promocao != null)
            {
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
            }
            return Preco - desconto;
        
    }


    }


}

