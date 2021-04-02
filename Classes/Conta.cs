using System;
using System.Collections.Generic;
using Bank_Transfer.Enum;
namespace Bank_Transfer.Classes
{
    public class Conta
    {
        private TipoConta TipoConta { get; set; }
        
        private int idConta { get; set; }
        private string Nome { get; set; }

        private double Saldo { get; set; }

        private double Credito { get;set; }

        
        public Conta(TipoConta tipoConta, int idconta, string nome, double saldo, double credito)
        {
            this.TipoConta = tipoConta;
            this.idConta = idconta;
            this.Saldo = saldo;
            this.Credito = credito;
            this.Nome = nome;
        }

        public bool Sacar(double valorSaque)
        {
            Console.WriteLine();
            //Validação de saldo suficiente
            if (this.Saldo - valorSaque < (this.Credito *-1))
            {
                Console.WriteLine("SALDO INSUFICIENTE!");
                Console.WriteLine("SEU LIMITE DE SAQUE É R${0:0.00}",(this.Saldo+this.Credito));
                Console.ReadKey();
                return false;          
            }
            else
            {
                this.Saldo -= valorSaque;
                Console.WriteLine("SALDO ATUAL DA CONTA DE {0} É R${1:0.00}",this.Nome,this.Saldo);
                Console.ReadKey();
                return true;    
            }      
        }
        
        public void Depositar(double valorDeposito)
        {
            Console.WriteLine();
            this.Saldo += valorDeposito;
            Console.WriteLine("SALDO ATUAL DA CONTA DE {0} É R${1:0.00}",this.Nome,this.Saldo);
            Console.ReadKey();
        }

        public void Transferir(double valorTransferencia, Conta contaDestino)
        {
            if (this.Sacar(valorTransferencia))
            {
                contaDestino.Depositar(valorTransferencia);
            }
        }
        
        public override string ToString()
        {
            string print = "";
            print += "Tipo Conta: " + this.TipoConta + " | ";
            print += "Nome: " + this.Nome + " | ";
            print += "Saldo: R$ " + this.Saldo + " | ";
            print += "Credito: R$ " + this.Credito;
            return print;
        }

    }
}