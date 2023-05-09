using Gamificacao.Enums;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Gamificacao.Models
{
    public class Estoque
    {
        private List<ProdutoModel> _produtos;
        private List<Promocao> _promocoes;
        public Estoque()
        {
            _produtos = new List<ProdutoModel>();
            _promocoes = new List<Promocao>();
        }

        public void AdicionarPromocao(Promocao promocao,int code)
        {
            
            foreach (var produto in _produtos)
            {
                if (produto.Categoria == (CategoriaEnum)code)
                {
                    // produto.Desconto = promocao.ValorDesconto;
                    produto.DefinirDesconto(promocao.ValorDesconto);
                }
            }
        }



        public void RegistrarProduto(ProdutoModel produto)
        {
            _produtos.Add(produto);
        }

        public List<ProdutoModel> ListarProdutos(int code)
        {
            List<ProdutoModel> produtosFiltrados = new List<ProdutoModel>();
            foreach (var produto in _produtos)
            {
                if (produto.Categoria == (CategoriaEnum)code)
                {
                    produtosFiltrados.Add(produto);
                }



            }
            return produtosFiltrados;
        }

        public void RemoverProduto(int codigo)
        {
            var produto = _produtos.FirstOrDefault(p => p.ProdutoID == codigo);
            if (produto != null)
            {
                _produtos.Remove(produto);
            }
        }
        public ProdutoModel ObterProdutoPorCodigo(int codigo,int tipo)
        {
            return _produtos.FirstOrDefault(p => p.ProdutoID == codigo );//&& p.Tipo == tipo
        }


        public void AplicarPromocao( CategoriaEnum categoria)
        {
            var produtosFiltrados = _produtos.Where(p => p.Categoria == categoria);
            var promocao = _promocoes.FirstOrDefault(pr => pr.Produtos().Intersect(produtosFiltrados).Any());

            if (promocao != null)
            {
                decimal desconto ;
                foreach (var produto in produtosFiltrados)
                {
                    if (promocao.TipoDesconto == TipoDesconto.Porcentagem)
                    {
                        desconto = produto.Preco * (promocao.ValorDesconto / 100);
                        produto.DefinirDesconto(desconto);
                    }
                    else if (promocao.TipoDesconto == TipoDesconto.ValorFixo)
                    {
                        desconto = promocao.ValorDesconto;
                        produto.DefinirDesconto(desconto);
                    }
                }
            }
        }


        public ProdutoModel AdicionarProdutoNoCarrinho(int codigo, int tipo)
        {
            List<ProdutoModel> produtosFiltrados = ListarProdutos(tipo);
            var produto = produtosFiltrados.FirstOrDefault(p => p.ProdutoID == codigo);
            if (produto != null)
            {
                Promocao promocao = _promocoes.FirstOrDefault(pr => pr.Produtos().Contains(produto));
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
                    produto.DefinirDesconto(desconto);
                }
                else
                {
                    produto.DefinirDesconto(0);
                }
                _produtos.Remove(produto);
                return produto;
            }
            return null;
        }


        public List<ProdutoModel> ListarProdutosPorCategoria(string categoria)
        {
            List<ProdutoModel> produtosPorCategoria = new List<ProdutoModel>();
            foreach (ProdutoModel produto in _produtos)
            {
               // if (Enum.TryParse(categoria, out CategoriaProduto categoriaProduto) && produto.Categoria == categoriaProduto)
              //  {
                    produtosPorCategoria.Add(produto);
               // }




            }
            return produtosPorCategoria;
        }


        public IReadOnlyCollection<ProdutoModel> ProdutosEstoque()
        {
            return _produtos.AsReadOnly();
            //return new List<ProdutoModel>(_produtos);
        }
    }
}


