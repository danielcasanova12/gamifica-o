using gamificacao.UI;
using Gamificacao.Enums;
using Gamificacao.Iniciando;
using Gamificacao.Models;

var carrinho = new CarrinhoDeCompras();
var estoque = new Estoque();
var pagamento = new Pagamento();


var carrinhos = new CarrinhoUI();

new BaseDeDados(estoque).PopularBaseDeDados();

Promocao promocaoCalcados = new Promocao(TipoDesconto.Porcentagem, 20);
estoque.AdicionarPromocao(promocaoCalcados, 0);



int escolha = 0;
int opcao = 0;

do
{
    Console.WriteLine("O que você deseja fazer?");
    Console.WriteLine("1 - Adicionar produto ao carrinho");
    Console.WriteLine("2 - Ver produtos no carrinho");
    Console.WriteLine("3 - Pagar");
    Console.WriteLine("4 - Sair");
    string escolhaInput = Console.ReadLine();

    if (!int.TryParse(escolhaInput, out escolha))
    {
        Console.WriteLine("Opção inválida. Digite novamente.");
        continue;
    }

    switch (escolha)
    {
        case 1:
            while (opcao != 4)
            {
                Console.WriteLine("O que você deseja adicionar ao carrinho?");
                Console.WriteLine("1 - Acessórios");
                Console.WriteLine("2 - Calça");
                Console.WriteLine("3 - Camisetas");
                Console.WriteLine("4 - Finalizar compra");

                string opcaoInput = Console.ReadLine();
                if (!int.TryParse(opcaoInput, out opcao))
                {
                    Console.WriteLine("Opção inválida. Digite novamente.");
                    continue;
                }

                switch (opcao)
                {
                    case 1:
                        carrinhos.AdicionarProdutoAoCarrinho(estoque, carrinho, 0);
                        break;
                    case 2:
                        carrinhos.AdicionarProdutoAoCarrinho(estoque, carrinho, 20);
                        break;
                    case 3:
                        carrinhos.AdicionarProdutoAoCarrinho(estoque, carrinho, 10);
                        break;
                    case 4:
                        break;
                    default:
                        Console.WriteLine("Opção inválida. Digite novamente.");
                        break;
                }
            }
            break;
        case 2:
            carrinho.ListarProdutos();
            break;
        case 3:
            carrinho.AdicionarPromocao(promocaoCalcados, 0);
            pagamento.RealizarPagamento(carrinho);
            Console.WriteLine("Compra realizada com sucesso!");
            Console.WriteLine("Obrigado por utilizar o nosso sistema!");
            escolha = 4;
            break;
        case 4:
            Console.WriteLine("Obrigado por utilizar o nosso sistema!");
            break;
        default:
            Console.WriteLine("Opção inválida. Digite novamente.");
            break;
    }
} while (escolha != 4);


