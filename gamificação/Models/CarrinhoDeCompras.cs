using Gamificacao.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gamificacao.Models
{
    public class CarrinhoDeCompras
    {
        public List<ProdutoModel> Produtos { get; set; } = new List<ProdutoModel>();
        public List<Promocao> Promocoes { get; set; } = new List<Promocao>();

        public void AdicionarProduto(ProdutoModel produto)
        {
            Produtos.Add(produto);
        }
        public void ListarProdutos()
        {
            if (Produtos.Any())
            {
                Console.WriteLine("Produtos no carrinho:");
                foreach (var produto in Produtos)
                {
                    Console.WriteLine($"{produto.Codigo} - {produto.Nome} ({produto.Preco:C2})");
                }
            }
            else
            {
                Console.WriteLine("O carrinho está vazio.");
            }
        }



        public decimal ObterValorTotal()
        {
            decimal valorTotal = Produtos.Sum(produto => produto.Preco);

            foreach (var promocao in Promocoes)
            {
                if (promocao.TipoDesconto == TipoDesconto.Porcentagem)
                {
                    valorTotal -= (promocao.ValorDesconto / 100) * valorTotal;
                }
                else
                {
                    valorTotal -= promocao.ValorDesconto;
                }
            }

            return valorTotal;
        }
        public void AdicionarPromocao(Promocao promocao, int code)
        {

            foreach (var produtos in Produtos)
            {
                if (produtos.Categoria == (CategoriaEnum)code)
                {
                    // produto.Desconto = promocao.ValorDesconto;
                    produtos.DefinirDesconto(promocao.ValorDesconto);
                }
            }
        }


    }

}
