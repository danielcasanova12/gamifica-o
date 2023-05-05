using gamificacao.Models;
using gamificacao.Enums;

var carrinho = new CarrinhoDeCompras();
var estoque = new Estoque();


//GerenciaEstoque gerenciaEstoque = new GerenciaEstoque();
var pagamento = new Pagamento();
int opcao = 0;
int escolha;




estoque.AdicionarProduto(new Bolsa()
{
    Codigo = 1,
    Tipo = 1,
    Nome = "Bolsa Feminina",
    Preco = 9112.90m,
    Categoria = CategoriaProduto.Acessorio,
    Cor = CorAcessorio.Preto,
    Tamanho = TamanhoAcessorio.G,
    Material = "Couro",
    NumeroCompartimentos = 4
});

estoque.AdicionarProduto(new Sapato()
{
    Codigo = 1,
    Tipo = 2,
    Nome = "Sapato Social Masculino",
    Preco = 149.90m,
    Categoria = CategoriaProduto.Acessorio,
    Cor = CorAcessorio.Preto,
    Tamanho = TamanhoAcessorio.G,
    TamanhoSapato = TamanhoSapato.Numero42,
    Marca = "Calvin Klein"
});

estoque.AdicionarProduto(new Calca()
{
    Codigo = 1,
    Tipo = 3,
    Nome = "Calça Jeans unisex",
    Preco = 89.90m,
    Categoria = CategoriaProduto.Calca,
    Tamanho = TamanhoCalca.M,
    Cor = CorRoupa.Azul
});
estoque.AdicionarProduto(new Calca()
{
    Codigo = 2,
    Tipo = 3,
    Nome = "Calça Tactel unisex",
    Preco = 89.90m,
    Categoria = CategoriaProduto.Calca,
    Tamanho = TamanhoCalca.M,
    Cor = CorRoupa.Azul
});
estoque.AdicionarProduto(new Calca()
{
    Codigo = 3,
    Tipo = 3,
    Nome = "Calça Leg Feminina",
    Preco = 89.90m,
    Categoria = CategoriaProduto.Calca,
    Tamanho = TamanhoCalca.M,
    Cor = CorRoupa.Azul
});
estoque.AdicionarProduto(new Calca()
{
    Codigo = 4,
    Tipo = 3,
    Nome = "Calça Jeans Masculina",
    Preco = 89.90m,
    Categoria = CategoriaProduto.Calca,
    Tamanho = TamanhoCalca.M,
    Cor = CorRoupa.Azul
});
estoque.AdicionarProduto(new Calca()
{
    Codigo = 1,
    Tipo = 4,
    Nome = "Camisa peruana",
    Preco = 89.90m,
    Categoria = CategoriaProduto.Calca,
    Tamanho = TamanhoCalca.M,
    Cor = CorRoupa.Azul
});
estoque.AdicionarProduto(new Calca()
{
    Codigo = 2,
    Tipo = 4,
    Nome = "Camisa lala",
    Preco = 89.90m,
    Categoria = CategoriaProduto.Calca,
    Tamanho = TamanhoCalca.M,
    Cor = CorRoupa.Azul
});
estoque.AdicionarProduto(new Calca()
{
    Codigo = 3,
    Tipo = 4,
    Nome = "Camisa polo",
    Preco = 89.90m,
    Categoria = CategoriaProduto.Calca,
    Tamanho = TamanhoCalca.M,
    Cor = CorRoupa.Azul
});


Promocao promocaoCalcas = new Promocao();
promocaoCalcas.ValorDesconto = 50;
promocaoCalcas.TipoDesconto = TipoDesconto.Porcentagem;
List<Produto> calcas = estoque.ListarProdutos(3);
promocaoCalcas.Produtos = calcas;

estoque.AdicionarPromocao(promocaoCalcas);

Promocao promocaoAcessorios = new Promocao();
promocaoAcessorios.ValorDesconto = 20;
promocaoAcessorios.TipoDesconto = TipoDesconto.Porcentagem;
List<Produto> produtosAcessorios2 = estoque.ListarProdutosPorCategoria("Acessorio");

promocaoAcessorios.Produtos = produtosAcessorios2;
estoque.AdicionarPromocao(promocaoAcessorios);








void addcarrinho(int tipo)
{
    while (true)
    {

        List<Produto> filtrados = estoque.ListarProdutos(tipo);
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

do
{
    Console.WriteLine("O que você deseja fazer?");
    Console.WriteLine("1 - Adicionar produto ao carrinho");
    Console.WriteLine("2 - Ver produtos no carrinho");
    Console.WriteLine("3 - Pagar");
    Console.WriteLine("4 - Sair");
    escolha = int.Parse(Console.ReadLine());

    switch (escolha)
    {
        case 1:
            while (opcao != 5)
            {
                Console.WriteLine("O que você deseja adicionar ao carrinho?");
                Console.WriteLine("1 - Bolsa");
                Console.WriteLine("2 - Sapato");
                Console.WriteLine("3 - Calça");
                Console.WriteLine("4 - Camisetas");
                Console.WriteLine("5 - Finalizar compra");

                opcao = int.Parse(Console.ReadLine());

                switch (opcao)
                {
                    case 1:
                        addcarrinho(1);
                        break;
                    case 2:
                        addcarrinho(2);
                        break;

                    case 3:
                        addcarrinho(3);

                        break;
                    case 4:
                        addcarrinho(4);
                        break;
                    case 5:
                        break;

                    default:
                        Console.WriteLine("Opção inválida.");
                        break;
                }


            }
            break;
        case 2:
            carrinho.ListarProdutos();
            break;
        case 3:
            carrinho.AplicarPromocao(promocaoAcessorios);
            carrinho.AplicarPromocao(promocaoCalcas);
            pagamento.RealizarPagamento(carrinho);
            Console.WriteLine("Compra realizada com suseso!");
            Console.WriteLine("Obrigado por utilizar o nosso sistema!");
            escolha = 4;
            break;
        case 4:
            Console.WriteLine("Obrigado por utilizar o nosso sistema!");
            break;
        default:
            Console.WriteLine("Opção inválida. Tente novamente.");
            break;
    }
} while (escolha != 4);

