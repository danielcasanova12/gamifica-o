using Gamificacao.Models;
using Gamificacao.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gamificacao.Iniciando
{
    public class BaseDeDados
    {
        private Estoque _estoque;

        public BaseDeDados(Estoque estoque)
        {
            _estoque = estoque;
        }

        public void PopularBaseDeDados()
        {
            _estoque.RegistrarProduto(new Calcado(
                TamanhoSapato.Numero33, "Nike", TamanhoAcessorio.P,
                1, "1", "Tenis azul", 300, 0, CorAcessorio.Preto, CategoriaEnum.Acessorio));
            _estoque.RegistrarProduto(new Calcado(
                TamanhoSapato.Numero33, "Adidas", TamanhoAcessorio.P,
                2, "2", "Tenis preto", 250, 0, CorAcessorio.Preto, CategoriaEnum.Acessorio));


            _estoque.RegistrarProduto(new Bolsa("couro",3,
                TamanhoAcessorio.G, CorAcessorio.Branco,
                3, "3", "Bolsa", 540, 0, CategoriaEnum.Acessorio));

            _estoque.RegistrarProduto(new Calca(TamanhoRoupa.G, CorRoupa.Branco,
               4, "4", "Calca", 200, 0,CategoriaEnum.Calca));


            _estoque.RegistrarProduto(new Camisa(TamanhoRoupa.G, CorRoupa.Branco,
               5, "5", "Camisa preta", 100, 0, CategoriaEnum.Camiseta));


        }

    }
}
