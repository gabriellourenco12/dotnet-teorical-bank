using System;
using Bank_Transfer.Enum;
using Bank_Transfer.Classes;
using System.Collections.Generic;

namespace Bank_Transfer
{
    class Program
    {
        static List<Conta> listContas = new List<Conta>();
         
        static List<int> randomList = new List<int>();
        static Random id = new Random();

        static void Main(string[] args)
        {
            
            string opcaoUsuario = ObterOpcaoUsuario();

            while (opcaoUsuario.ToUpper() != "X")
            {
                switch (opcaoUsuario)
                {
                    case "1":
                        ListarContas();
                        break;
                    case "2":
                        InserirContas();
                        break;
                    case "3":
                        Sacar();
                        break;
                    case "4":
                        Depositar();
                        break;
                    case "5":
                        Transferir();
                        break;
                    case "C":
                        Console.Clear();
                        break;
                    
                    default:
                        throw new ArgumentOutOfRangeException();
                }
                opcaoUsuario = ObterOpcaoUsuario();
            }
            Console.WriteLine("OBRIGADO POR UTILIZAR NOSSOS SERVIÇOS");
            Console.WriteLine("TEORICAL BANK DESEJA A VOCÊ UM ÓTIMO DIA!");
            Console.ReadKey();
        }

        private static void Sacar()
        {
            Console.Clear();
            Console.WriteLine("--- SAQUE ---");
            Console.Write("\nDIGITE O NÚMERO DA CONTA: ");
            int indexConta = int.Parse(Console.ReadLine());
            
            Console.Write("DIGITE O VALOR A SER SACADO: ");
            double valorSaque = double.Parse(Console.ReadLine());

            listContas[indexConta].Sacar(valorSaque);
        }
        private static void Depositar()
        {
            Console.Clear();
            Console.WriteLine("--- DEPÓSITO ---");
            Console.Write("\nDIGITE O NÚMERO DA CONTA: ");
            int indexConta = int.Parse(Console.ReadLine());
            
            Console.Write("DIGITE O VALOR A SER DEPOSITADO: ");
            double valorDeposito = double.Parse(Console.ReadLine());

            listContas[indexConta].Depositar(valorDeposito);
        }
        private static void Transferir()
        {
            Console.Clear();
            Console.WriteLine("--- TRANSFERÊNCIA ---");
            Console.Write("\nDIGITE O NÚMERO DA CONTA DE ORIGEM: ");
            int indexOrigem = int.Parse(Console.ReadLine());
            Console.Write("DIGITE O NÚMERO DA CONTA DE DESTINO: ");
            int indexDestino = int.Parse(Console.ReadLine());

            Console.Write("DIGITE O VALOR A SER TRANSFERIDO: ");
            double valorTransferencia = double.Parse(Console.ReadLine());
            
            listContas[indexOrigem].Transferir(valorTransferencia, listContas[indexDestino]);
        }
        private static void ListarContas()
        {
            Console.Clear();
            Console.WriteLine("--- LISTAR CONTAS ---");

            if (listContas.Count == 0)
            {
                Console.WriteLine("NENHUMA CONTA CADASTRADA.");
                Console.ReadKey();
                return;
            }

            for (int i = 0; i < listContas.Count; i++)
            {
                Conta conta = listContas[i];
                Console.Write("#{0} - ", randomList[i]);
                Console.WriteLine(conta.ToString());
            }
            Console.ReadKey();
        }

                      
        private static void InserirContas()
        {
            Console.Clear();
            Console.WriteLine("--- INSERIR NOVA CONTA ---");
            Console.WriteLine();
            Console.Write("DIGITE 1 PARA CONTA FÍSICA OU 2 PARA CONTA JURÍDICA: ");
            int IN_tipoConta = int.Parse(Console.ReadLine());

            Console.Write("DIGITE O NOME DO CLIENTE: ");
            string IN_nome = Console.ReadLine();
            
            Console.Write("DIGITE O SALDO INICIAL: ");
            double IN_saldo = double.Parse(Console.ReadLine());

            Console.Write("DIGITE O CRÉDITO: ");
            double IN_credito = double.Parse(Console.ReadLine());
            int numConta = id_Conta(id,randomList);
            Console.Write("NÚMERO DA CONTA SERÁ: {0}",numConta);
            Conta novaConta = new Conta(tipoConta: (TipoConta)IN_tipoConta,
                                        idconta: numConta,
                                        nome: IN_nome,
                                        saldo: IN_saldo,
                                        credito: IN_credito);
            randomList.Add(numConta);
            listContas.Add(novaConta);
            Console.ReadKey();
            Console.Clear();
        }
        private static int id_Conta(Random id, List<int> randomList)
        {
            int numConta = 0;
  	        numConta = id.Next(1, 100);
  	        while(randomList.Contains(numConta))
              {
                numConta = id.Next(1, 100);
              }
            return numConta;
        }               

        private static string ObterOpcaoUsuario()
        {
            Console.WriteLine();
            Console.WriteLine("TEORICAL BANK AO SEU DISPOR!");
            Console.WriteLine("INFORME A OPÇÃO DESEJADA:\n");
            Console.WriteLine("1 - LISTAR CONTAS");
            Console.WriteLine("2 - INSERIR NOVA CONTA");
            Console.WriteLine("3 - SACAR");
            Console.WriteLine("4 - DEPOSITAR");
            Console.WriteLine("5 - TRANSFERIR");
            Console.WriteLine("C - LIMPAR TELA");
            Console.WriteLine("X - SAIR");
            Console.WriteLine();

            string opcaoUsuario = Console.ReadLine().ToUpper();
            Console.WriteLine();
            return opcaoUsuario;
        }
    }
}
