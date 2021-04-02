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
            Console.WriteLine();
            int indexConta = PegarConta();
            double valorSaque = 0;
            bool b = false;
            do
            {
                Console.Write("DIGITE O VALOR A SER SACADO: ");
                b = double.TryParse(Console.ReadLine(), out valorSaque);
                if (b == false) Console.WriteLine("VALOR DEVE SER UM NÚMERO!");
            } while (b == false);
            
            listContas[indexConta].Sacar(valorSaque);
        }
        private static void Depositar()
        {
            Console.Clear();
            Console.WriteLine("--- DEPÓSITO ---");
            Console.WriteLine();
            int indexConta = PegarConta();
            double valorDeposito = 0;
            bool b = false;
            do
            {
                Console.Write("DIGITE O VALOR A SER DEPOSITADO: ");
                b = double.TryParse(Console.ReadLine(), out valorDeposito);
                if (b == false) Console.WriteLine("VALOR DEVE SER UM NÚMERO!");
            } while (b == false);
            listContas[indexConta].Depositar(valorDeposito);
        }
        private static void Transferir()
        {
            Console.Clear();
            Console.WriteLine("--- TRANSFERÊNCIA ---");
            Console.WriteLine("\nCONTA DE ORIGEM");
            int indexOrigem = PegarConta();
            Console.WriteLine("\nCONTA DE DESTINO");
            int indexDestino = PegarConta();

            double valorTransferencia = 0;
            bool b = false;
            do
            {
                Console.Write("DIGITE O VALOR A SER TRANSFERIDO: ");
                b = double.TryParse(Console.ReadLine(), out valorTransferencia); 
                if (b == false) Console.WriteLine("VALOR DEVE SER UM NÚMERO!");   
            } while (b == false);
            listContas[indexOrigem].Transferir(valorTransferencia, listContas[indexDestino]);
        }
        private static int PegarConta()
        {
            int indexConta = 0;
            bool b = false;
            do
            {
                Console.Write("DIGITE O NÚMERO DA CONTA: ");
                indexConta = int.Parse(Console.ReadLine());
                if (randomList.Contains(indexConta))
                {
                    b = true;
                    indexConta = randomList.IndexOf(indexConta);
                }
                else
                {
                    Console.WriteLine("\nCONTA INEXISTENTE!");
                    Console.WriteLine("PRESSIONE UMA TECLA PARA VISUALIZAR A LISTA DE CONTAS");
                    Console.ReadKey();
                    ListarContas();                    
                }
            } while (b == false); 
            return indexConta;  
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
            int IN_tipoConta = PegarTipoConta();
            double IN_saldo = 0, IN_credito = 0;
            bool b = false;
            Console.Write("DIGITE O NOME DO CLIENTE: ");
            string IN_nome = Console.ReadLine();
            
            do
            {
                Console.Write("DIGITE O SALDO INICIAL: ");
                b = double.TryParse(Console.ReadLine(), out IN_saldo);
                if (b == false) Console.WriteLine("VALOR DEVE SER UM NÚMERO!");
            } while (b == false);
            

            do
            {
                Console.Write("DIGITE O CRÉDITO: ");
                b = double.TryParse(Console.ReadLine(), out IN_credito);   
                if (b == false) Console.WriteLine("VALOR DEVE SER UM NÚMERO!");
            } while (b == false);
            
            int numConta = id_Conta(id,randomList);
            Console.WriteLine("NÚMERO DA CONTA SERÁ: {0}",numConta);
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

        private static int PegarTipoConta()
        {
            bool b = false;
            int IN_tipoConta = 0;
            do
            {
                Console.Write("DIGITE 1 PARA CONTA FÍSICA OU 2 PARA CONTA JURÍDICA: ");
                bool sucesso = Int32.TryParse(Console.ReadLine(),out IN_tipoConta);
                if (sucesso && (IN_tipoConta == 1 || IN_tipoConta == 2))
                {
                    b = true;
                }
                else
                {
                    Console.WriteLine("\nTIPO DE CONTA INEXISTENTE!");
                    Console.WriteLine("TENTE NOVAMENTE\n"); 
                }
            } while (b == false);
            return IN_tipoConta;
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
