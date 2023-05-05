using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using gamificacao.Enums;
using gamificacao.Models;
namespace gamificacao.Models
{
    public abstract class Produto
    {
        public int Codigo { get; set; }
        public int Tipo { get; set; }
        public string Nome { get; set; }
        public decimal Preco { get; set; }
        public decimal Desconto { get; set; }

        public CategoriaProduto Categoria { get; set; }


        public abstract decimal CalcularDesconto(Promocao promocao);

    }

}
