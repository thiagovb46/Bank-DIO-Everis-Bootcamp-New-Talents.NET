using System;
using System.Collections.Generic;
namespace Conta
{
    public class Conta
    {
        private String name_client {get; set;}
        private float saldo{get; set;}
        private float credit {get; set;}
        private TipoConta tipoConta {get;set;}
        private int acount_number{get;set;}
        public int getAccount_Number()
        {
            return this.acount_number;
            
        }
         public Conta(TipoConta tipo,String name, float balance,float credit,int numero)
    {
        this.tipoConta=tipo;
        this.name_client=name;
        this.saldo=balance;
        this.credit=credit;
        this.acount_number=numero;
    }
    public bool sacar(float valor)
    {
        if(this.saldo-valor<credit*-1)
        {
            return false;
        }
        this.saldo-=valor;
        return true;
    }
    public void depositar(float valor_dep)
    {
        this.saldo+=valor_dep;

    }
    public bool transferir(float valor, Conta ContaDestino)
    {
        if(sacar(valor))
        {
            ContaDestino.depositar(valor);
            return true;
        }
        return false;
    
    }
    public override string ToString()
		{
            string retorno = "";
            retorno += "TipoConta " + this.tipoConta+ " | ";
            retorno += "Número da Conta "+ this.acount_number+"|";
            retorno += "Nome " + this.name_client + " | ";
            retorno += "Saldo " + this.saldo+ " | ";
            retorno += "Crédito " + this.credit;
			return retorno;
		}
    
    }
}