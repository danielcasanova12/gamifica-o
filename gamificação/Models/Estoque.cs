using gamificacao.Enums;
using System;
using System.Collections.Generic;
using System.Linq;

namespace gamificacao.Models
{
    public class Estoque
    {
        private List<Produto> _produtos;
        private List<Promocao> promocoes;
        public Estoque()
        {
            _produtos = new List<Produto>();
            promocoes = new List<Promocao>();
        }

        public void AdicionarPromocao(Promocao promocao)
        {
            foreach (var produto in _produtos)
            {
                if (promocao.Produtos.Contains(produto))
                {
                    produto.Desconto = promocao.ValorDesconto;
                }
            }
        }



        public void AdicionarProduto(Produto produto)
        {
            _produtos.Add(produto);
        }

        public List<Produto> ListarProdutos(int code)
        {
            List<Produto> produtosFiltrados = new List<Produto>();
            foreach (var produto in _produtos)
            {
                if (code == produto.Tipo)
                {
                    produtosFiltrados.Add(produto);
                }
            }
            return produtosFiltrados;
        }

        public void RemoverProduto(int codigo)
        {
            var produto = _produtos.FirstOrDefault(p => p.Codigo == codigo);
            if (produto != null)
            {
                _produtos.Remove(produto);
            }
        }
        public Produto ObterProdutoPorCodigo(int codigo,int tipo)
        {
            return _produtos.FirstOrDefault(p => p.Codigo == codigo && p.Tipo == tipo);
        }




        public Produto AdicionarProdutoNoCarrinho(int codigo, int tipo)
        {
            List<Produto> produtosFiltrados = ListarProdutos(tipo);
            var produto = produtosFiltrados.FirstOrDefault(p => p.Codigo == codigo);
            if (produto != null)
            {
                Promocao promocao = promocoes.FirstOrDefault(pr => pr.Produtos.Contains(produto));
                if (promocao != null)
                {
                    decimal desconto = 0;
                    if (promocao.TipoDesconto == TipoDesconto.Porcentagem)
                    {
                        desconto = produto.Preco * (promocao.ValorDesconto / 100);
                    }
                    else if (promocao.TipoDesconto == TipoDesconto.ValorFixo)
                    {
                        desconto = promocao.ValorDesconto;
                    }
                    produto.Desconto = desconto;
                }
                else
                {
                    produto.Desconto = 0;
                }
                _produtos.Remove(produto);
                return produto;
            }
            return null;
        }

        public List<Produto> ListarProdutosPorCategoria(string categoria)
        {
            List<Produto> produtosPorCategoria = new List<Produto>();
            foreach (Produto produto in _produtos)
            {
                if (Enum.TryParse(categoria, out CategoriaProduto categoriaProduto) && produto.Categoria == categoriaProduto)
                {
                    produtosPorCategoria.Add(produto);
                }




            }
            return produtosPorCategoria;
        }



    }
}


