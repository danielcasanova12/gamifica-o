using gamificacao.Models;
using gamificacao.Enums;
using gamificacao.Iniciando;

var carrinho = new CarrinhoDeCompras();
var estoque = new Estoque();
var pagamento = new Pagamento();
int opcao = 0;
int escolha;



new BaseDeDados(estoque).PopularBaseDeDados();

Promocao promocaoCalcados = new Promocao(TipoDesconto.Porcentagem, 20);
estoque.AdicionarPromocao(promocaoCalcados, 0);


void addcarrinho(int tipo)
{
    while (true)
    {

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
            while (opcao != 4)
            {
                Console.WriteLine("O que você deseja adicionar ao carrinho?");
                Console.WriteLine("1 - Acesorios");
                Console.WriteLine("2 - Calça");
                Console.WriteLine("3 - Camisetas");
                Console.WriteLine("4 - Finalizar compra");

                opcao = int.Parse(Console.ReadLine());

                switch (opcao)
                {
                    case 1:
                        addcarrinho(0);
                        break;

                    case 2:
                        addcarrinho(20);

                        break;
                    case 3:
                        addcarrinho(10);
                        break;
                    case 4:
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
            carrinho.AdicionarPromocao(promocaoCalcados,0);
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

