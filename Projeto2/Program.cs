﻿
using Projeto;

List<CCorrente> contas = new List<CCorrente>();
int Menu()
{
    string? i;
    int op;
    Console.WriteLine("1. Acesso Administrativo");
    Console.WriteLine("2. Caixa Eletronico");
    Console.WriteLine("0. Sair");
    Console.WriteLine("\nOpção: ");

    i = Console.ReadLine();
    Int32.TryParse(i, out op);
    return op;
}

void AcessoAdmin()
{
    string? i;
    int op;
    do
    {
        Console.WriteLine("\n\n---Acesso ADM---");
        Console.WriteLine("1. Cadastro Conta Corrente");
        Console.WriteLine("2. Mostrar Saldo de todas as contas");
        Console.WriteLine("3. Excluir Conta");
        Console.WriteLine("0. Voltar");
        Console.WriteLine("\nOpção: ");
        i = Console.ReadLine();
        Int32.TryParse(i, out op);
        switch (op)
        {
            case 1:
                Console.Clear();
                CadastroConta();
                break;
            case 2:
                Console.Clear();
                MostrarSaldo();
                break;
            case 3:
                Console.Clear();
                ExcluirConta();
                break;
            case 0: break;
            default:
                Console.WriteLine("Invalido, redigite.");
                break;
        }
    } while (op != 0);
    Console.Clear();
}

void CadastroConta()
{
    Console.WriteLine("Digite o numero da conta: ");
    string Numero = Console.ReadLine();
    double limite;
    CCorrente conta = contas.Find(c => c.Numero == Numero);
    if (conta == null)
    {
        Console.WriteLine("Digite o limite da conta: ");
        string? i = Console.ReadLine();
        bool x = Double.TryParse(i, out limite);
        while (limite < 0 || !x)
        {
            Console.Write("Invalido, redigite: ");
            i = Console.ReadLine();
            x = Double.TryParse(i, out limite);
        }
        contas.Add(new CCorrente(Numero, limite));
    }
    else
    {
        Console.WriteLine("Conta ja existente!");
    }
}

void MostrarSaldo()
{
    Console.WriteLine("Saldo de todas as contas: ");
    Console.WriteLine("(numero) - (saldo)");
    foreach (var conta in contas)
    {
        Console.WriteLine(conta.Numero + " - " + conta.Saldo);
    }
}
void ExcluirConta()
{
    Console.WriteLine("Digite o numero da conta que voce deseja excluir: ");
    string Numero = Console.ReadLine();
    CCorrente conta = contas.Find(c => c.Numero == Numero);
    if (conta != null)
    {
        conta.Status = false;
        Console.WriteLine("Conta excluida com sucesso!");
    }
    else
    {
        Console.WriteLine("Conta nao encontrada.");
    }
}
void CaixaEletronico()
{
    string? i;
    int op;
    bool x;
    double valor;
    Console.WriteLine("Digite o numero da conta que deseja consultar: ");
    string numero = Console.ReadLine();
    CCorrente conta = contas.Find(c => c.Numero == numero);
    if (conta != null)
    {
        do
        {
            Console.WriteLine("\n\n---Caixa Eletronico---");
            Console.WriteLine("1. Saque");
            Console.WriteLine("2. Deposito");
            Console.WriteLine("3. Transferencia");
            Console.WriteLine("0. Voltar");
            Console.WriteLine("\nOpção: ");
            i = Console.ReadLine();
            Int32.TryParse(i, out op);
            switch (op)
            {
                case 1:
                    Console.Clear();
                    Console.WriteLine("Qual o valor do saque?: ");
                    i = Console.ReadLine();
                    x = Double.TryParse(i, out valor);
                    while (valor < 0 || !x)
                    {
                        Console.Write("Redigite o valor: ");
                        i = Console.ReadLine();
                        x = Double.TryParse(i, out valor);
                    }
                    if (conta.Saque(valor))
                    {
                        Console.WriteLine("Saque realizado");
                    }
                    else
                    {
                        Console.WriteLine("Saldo acima do limite ):");
                    }
                    break;
                case 2:
                    Console.Clear();
                    Console.WriteLine("Qual o valor do depósito?: ");
                    i = Console.ReadLine();
                    x = Double.TryParse(i, out valor);
                    while (!x)
                    {
                        Console.Write("Invalido, redigite: ");
                        i = Console.ReadLine();
                        x = Double.TryParse(i, out valor);
                    }
                    if (conta.Depositar(valor))
                    {
                        Console.WriteLine("Deposito realizado");
                    }
                    else
                    {
                        Console.WriteLine("Valor invalido para depositar");
                    }
                    break;
                case 3:
                    Console.Clear();
                    Console.Write("Digite o numero da conta destino: ");
                    string destino = Console.ReadLine();
                    CCorrente cDestino = contas.Find(c => c.Numero == destino);
                    if (cDestino != null)
                    {
                        Console.Write("Qual o valor da transação?: ");
                        i = Console.ReadLine();
                        Double.TryParse(i, out valor);
                        if (conta.Transferir(cDestino, valor))
                            Console.WriteLine("Transferencia realizada");
                        else
                            Console.WriteLine("Nao foi possivel realizar a transferencia. Tente novamente.");
                    }
                    else
                    {
                        Console.WriteLine("Conta de destino não encontrada.");
                    }
                    break;
                case 0:
                    Console.Clear();
                    break;
                default:
                    Console.WriteLine("Invalido, redigite.");
                    break;
            }
        } while (op != 0);
    }
    else
    {
        Console.WriteLine("Conta nao encontrada.");
    }
}
int escolha;

do
{
    Console.WriteLine("\n\n===Menu===");
    escolha = Menu();
    switch (escolha)
    {

        case 1:
            Console.Clear();
            AcessoAdmin();
            break;
        case 2:
            Console.Clear();
            CaixaEletronico();
            break;
        case 0:
            Console.Clear();
            Console.WriteLine("Caixa desligado...");
            break;
        default:
            Console.WriteLine("Invalido, redigite.");
            break;
    }
} while (escolha != 0);