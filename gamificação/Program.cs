using gamificacao.UI;
using Gamificacao.Enums;
using Gamificacao.Iniciando;
using Gamificacao.Models;

var carrinho = new CarrinhoDeCompras();
var estoque = new Estoque();
var pagamento = new Pagamento();
int opcao = 0;
int escolha;

var carrinhos = new CarrinhoUI();

new BaseDeDados(estoque).PopularBaseDeDados();

Promocao promocaoCalcados = new Promocao(TipoDesconto.Porcentagem, 20);
estoque.AdicionarPromocao(promocaoCalcados, 0);




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
                        //addCarrinho(0);
                        carrinhos.AdicionarProdutoAoCarrinho(estoque, carrinho,0);
                        break;

                    case 2:
                        //addCarrinho(20);
                        carrinhos.AdicionarProdutoAoCarrinho(estoque, carrinho, 20);

                        break;
                    case 3:
                        //addCarrinho(10);
                        carrinhos.AdicionarProdutoAoCarrinho(estoque, carrinho, 10);
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

