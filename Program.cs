using System;
using System.Collections.Generic;

namespace Conta
{
    class Program
    {
        static List<Conta> data = new List<Conta>();
        static void Main(string[] args)
        {   int menu=1,id=1;
            while(menu!=0)
            {   menu = Option_menu();
                switch(menu)
                {
                    case 1:
                        Listar();
                    break;
                    case 2:
                        Cadastro(id);
                        id++;
                    break;
                    case 3:
                        Transferir();
                    break;
                    case 4:
                        sacar();
                    break;
                    case 5:
                        depositar();
                    break;
                    case 0:
                        Console.WriteLine("Obrigado, volte sempre! ");
                    break;
                }
            }
        }
        public static void depositar()
        {
            Console.WriteLine("Digite a conta do depósito");
            if(int.TryParse(Console.ReadLine(),out int number_account))
            {
                Conta destiny_account = VerifiedExistAcount(number_account);
                if(destiny_account!=null)
                {
                    Console.WriteLine("Digite o valor do depósito");
                    if(float.TryParse(Console.ReadLine(),out float value_)&&value_>0)
                    {
                        destiny_account.depositar(value_);
                        Console.WriteLine("Depósito realizado com sucesso");
                        return;
                    }
                    else
                        Console.WriteLine("Por favor digite um valor válido");
                    
                }
            }


        }
        public static void sacar()
        {
            Console.WriteLine("Digite o número da conta");
            if(int.TryParse(Console.ReadLine(),out int number_account))
            {   Conta account = VerifiedExistAcount(number_account);
                if(account==null)
                {
                    Console.WriteLine("Por favor digite um número de conta válido");
                    return;
                }
                Console.WriteLine("Digite o Valor do saque");
                if(float.TryParse(Console.ReadLine(),out float value_)&&value_>0)
                {
                    if(account.sacar(value_))
                    {
                        Console.WriteLine("Saque relizado com sucesso");
                        return;
                    }
                    Console.WriteLine("O Saldo é insuficiente");
                    return;
                }
                Console.WriteLine("O valor digitado não é valido, digite um valor numérico");
            return;
            }
            Console.WriteLine("O número digitado não é valido, digite um valor numérico da Conta");
        }
       public static void Finish_Screen()
       {
            Console.WriteLine("Tecle Enter para continuar");
            Console.ReadLine();
            return;
       }
        public static void Listar()
        {   if(data.Count<1)
            {
                Console.WriteLine("Não há contas cadastradas");
                Finish_Screen();
                return;
            }
            foreach(Conta obj in data)
                Console.WriteLine(obj.ToString());
            Finish_Screen();
        }
        public static bool Cadastro (int id) 
        {
            TipoConta tipo_conta = new TipoConta();
            int tipo;
            string nome;
            float saldo,credito;
            Console.WriteLine();
            Console.WriteLine("Digite o nome do proprietário da conta: ");
            nome = Console.ReadLine();
            Console.WriteLine("Digite o valor do depósito inicial da conta");
            while(!(float.TryParse(Console.ReadLine(),out saldo))||saldo<0)
            {
                Console.WriteLine("Por Favor Digite um valor válido maior ou igual a zero");
            }
            Console.WriteLine("Digite o valor credito da conta");
            while(!(float.TryParse(Console.ReadLine(),out credito))||credito<0)
            {
                Console.WriteLine("Por Favor Digite um valor válido maior ou igual a zero");
            }
            Console.WriteLine("Digite o tipo da conta 1 - Para Pessoa física  2- Para pessoa Jurídica");
            while(int.TryParse(Console.ReadLine(),out tipo)==false||(tipo!=1&&tipo!=2) )
            {
                Console.WriteLine("Digite um tipo de conta válido 1 - Para Pessoa física  2- Para pessoa Jurídica");
            }
            tipo_conta=(TipoConta)tipo; 
            Conta Insert = new Conta(tipo_conta,nome,saldo,credito,id);
            data.Add(Insert);
            Console.WriteLine("Conta Criada com sucesso");
            Console.WriteLine("Tecle Enter para continuar");
            return true;      
        }
        public static int Option_menu ()
        {
            Console.WriteLine("1 - Listar Contas");
            Console.WriteLine("2 - Cadastrar Contas");
            Console.WriteLine("3 - Transferir");
            Console.WriteLine("4 - Sacar");
            Console.WriteLine("5 - Depositar");
            Console.WriteLine("0 - Sair");
            if (int.TryParse(Console.ReadLine(),out int menu))
                return menu;
            return -1;            
         }
         public static bool Transferir()
         {  
             Console.WriteLine("Digite o número da conta de Origem");
             if(int.TryParse(Console.ReadLine(),out int account_origin))
             {
                Conta obj_Account_origin = VerifiedExistAcount(account_origin);
                if(obj_Account_origin==null)
                {
                    Console.WriteLine("Essa conta não existe, por favor tente novamente");
                    return false;
                }
                Console.WriteLine("Digite a conta de Destino da transferência");
                if(int.TryParse(Console.ReadLine(),out int account_destiny))
                {   
                    Conta obj_Account_destiny = VerifiedExistAcount(account_destiny); 
                    if((obj_Account_destiny)==null)
                    {
                        Console.WriteLine("Essa conta não existe, por favor tente novamente");
                        return false;
                    }
                    Console.WriteLine("Digite o valor da trasnferência");
                    if(float.TryParse(Console.ReadLine(),out float transfer_value))
                    {
                        if(obj_Account_origin.transferir(transfer_value,obj_Account_destiny)==false) 
                        {
                            Console.WriteLine("Saldo Insuficiente");
                            return false;
                        } 
                        Console.WriteLine("Trasnferência Realizada com sucesso");
                        return true;
                    }
                    Console.WriteLine("Digite um valor válido");
                }
            }
                    else 
                    Console.WriteLine("Por favor digite um número de conta válido");
                    return false;
        }
        public static Conta VerifiedExistAcount(int account)
        {
            foreach(Conta obj in data) 
            {
                if(obj.getAccount_Number()==account)
                    return obj;
            }
            return null;
        }
    }
}