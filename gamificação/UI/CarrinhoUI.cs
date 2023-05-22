using Gamificacao.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace gamificacao.UI
{
    public class CarrinhoUI
    {


        public void AdicionarProdutoAoCarrinho(Estoque estoque,CarrinhoDeCompras carrinho,int tipo)
        {
            while (true)
            {

                 //List<Produto> filtrados = estoque.ListarProdutos(tipo);
                List<ProdutoModel> filtrados = estoque.ListarProdutos(tipo);
                foreach (var pro in filtrados)
                {
                    decimal valorTotalItem = pro.Preco - pro.Desconto;
                    Console.WriteLine($"{pro.Codigo} - {pro.Nome} ({pro.Preco:C2} - {pro.Desconto:C2} = {valorTotalItem:C2})");
                }
                estoque.ListarProdutos(tipo);
                Console.WriteLine("Digite o código do produto que deseja adicionar ao carrinho (ou 0 para sair):");
                int codigo = int.Parse(Console.ReadLine());
                if (codigo == 0)
                {
                    break;
                }
                var produto = estoque.AdicionarProdutoNoCarrinho(codigo, tipo);
                if (produto != null)
                {
                    carrinho.AdicionarProduto(produto);
                }
                else
                {
                    Console.WriteLine("Produto não encontrado no estoque.");
                }
            }
        }
    }
}
